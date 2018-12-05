using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pkSqlGrepTool.domain.sqlindex;
using pkSqlGrepTool.appcore;
using pkSqlGrepTool.ui;
using System.Text.RegularExpressions;
using pkSqlGrepTool.Properties;
using System.Threading;


namespace pkSqlGrepTool
{
    public partial class MainForm : Form
    {
        // inner component

        CancellationTokenSource ts = null;
        Task currentTask = null;
        bool allSelect_eventGuard = false;

        List<SqlIndex> listSqls = new List<SqlIndex>();

        public string HilightWord { get; set; } = "";

        // constructor / initialization

        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            requestLoadIndex();
        }
    
        ~MainForm()
        {
        }

        // common methods

        private Task assignTask(Action action)
        {
            ts = new CancellationTokenSource();
            var ct = ts.Token;

            return Task.Factory.StartNew(action, ct);
        }

        // validation

        private string validateSearch()
        {
            if (cbCondRegex.Checked)
            {
                try
                {
                    new Regex(txSearchToken.Text);
                }
                catch (ArgumentException ex)
                {
                    return "正規表現の構文が不正です。";
                }
            }
            return "";
        }

        // inner action

        private void requestLoadIndex()
        {
            if (currentTask != null && !currentTask.IsCompleted)
            {
                return;
            }

            drawEnterLoadIndex();

            currentTask =
                assignTask(() =>
                {
                    var subTask = SqlFileFacade.RequestRefleshRepos();
                    Task.WhenAll(subTask);
                })
                .ContinueWith((t) =>
                {
                    this.Invoke(new Action(drawEndLoadIndex));
                    currentTask = null;
                })
                .ContinueWith((t) => { requestSearch(); });
        }

        private void requestSearch()
        {
            var err = validateSearch();
            drawError(err);
            if (err != "")
            {
                return;
            }
            
            if (currentTask != null && !currentTask.IsCompleted)
            {
                return;
            }
            drawEnterSearch();

            var searchToken = txSearchToken.Text;
            var regex = cbCondRegex.Checked;
            var word = cbCondWord.Checked;
            var ignoreCase = !cbEnableCase.Checked;
            var includesCaption = !cbOnlyBody.Checked;

            enterTask("検索中");

            assignTask(() =>
            {
                var subTask = SqlFileFacade.RequestSearch(searchToken,
                                SqlMatch.withRegex(regex),
                                SqlMatch.withWord(word),
                                SqlMatch.withIgnoreCase(ignoreCase),
                                SqlMatch.withIncludesCaption(includesCaption))
                                .ContinueWith((t) =>
                                {
                                    listSqls.Clear();
                                    listSqls.AddRange(t.Result);
                                    this.Invoke(new Action(drawEndSearch));
                                    currentTask = null;
                                });
                Task.WaitAll(subTask);
            })
            .ContinueWith((t) => {
                releaseTask();
            });
        }

        private void findContent(string find)
        {
            if (find == "")
            {
                return;
            }
            var cont = rtContent.Text.ToLower();
            int startIdx = Math.Min((rtContent.SelectionStart) + find.Length, cont.Length-1);

            if (startIdx < 0)
            {
                return;
            }

            int resultIdx = cont.IndexOf(find, startIdx);
            if (resultIdx < 0)
            {
                resultIdx = cont.IndexOf(find);
            }

            if (resultIdx < 0)
            {
                clearHilight();
                return;
            }

            rtContent.Select(resultIdx, find.Length);
            rtContent.ScrollToCaret();

            if (HilightWord != find)
            {
                clearHilight();
                HilightWord = find;
                setHilight(find);
            }
        }

        private void clearHilight()
        {
            var s = rtContent.SelectionStart;
            var l = rtContent.SelectionLength;
            rtContent.SelectAll();
            rtContent.SelectionBackColor = rtContent.BackColor;
            rtContent.Select(s, l);
        }
        private void setHilight(string word)
        {
            var s = rtContent.SelectionStart;
            var l = rtContent.SelectionLength;

            int i = 0;
            rtContent.DeselectAll();
            while(i + word.Length <= rtContent.TextLength && (i = rtContent.Find(word, i, RichTextBoxFinds.None)) >= 0)
            {
                rtContent.Select(i, word.Length);
                rtContent.SelectionBackColor = Color.Yellow;
                i += word.Length;
            }
            rtContent.Select(s, l);
        }

        private void requestSelectAllofList()
        {
            Task.Run(() =>
            {
                allSelect_eventGuard = true;
                this.Invoke(new Action(() =>
                {
                    for (var i = 0; i < lbList.Items.Count; i++)
                    {
                        lbList.SetSelected(i, true);
                    }
                }));
                allSelect_eventGuard = false;
            });
        }

        private void requestSelectList(List<int> indices)
        {
            Task.Run(() =>
            {
                lbList.ClearSelected();
                foreach (var i in indices)
                {
                    lbList.SetSelected(i, true);
                }
            });
        }

        // draw

        private void enterTask(string message)
        {
            this.Invoke(new Action(() =>
            {
                btCancel.Enabled = true;
                lbStatus.Text = message;
            }));
        }
        private void releaseTask()
        {
            this.Invoke(new Action(() =>
            {
                btCancel.Enabled = false;
                lbStatus.Text = "";
            }));
        }

        private void drawStatusBar(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        private void drawEnterLoadIndex()
        {
            drawStatusBar("ロード中...");
            btSearch.Enabled = false;
        }
        private void drawEndLoadIndex()
        {
            drawStatusBar("");
            btSearch.Enabled = true;
        }

        private void drawEnterSearch()
        {
        }

        private void drawEndSearch()
        {
            lbList.Items.Clear();
            lbList.Items.AddRange(listSqls.ToArray());
        }

        private void drawSqlContext()
        {
            if (currentTask != null)
            {
                return;
            }

            enterTask("ファイル内容描画中...");

            var items = new List<SqlIndex>();
            items.AddRange(lbList.SelectedItems.OfType<SqlIndex>());
            var result = "";

            assignTask(
                () =>
                {
                    Thread.Sleep(50);
                }).ContinueWith(
                (t) => {
                var sqlTexts = items.Select((idx) =>
                                {
                                    return "-- "
                                            + idx.Title + "\r\n"
                                            + idx.Sql + "\r\n";
                                });

                result = string.Join("\r\n" + Settings.Default.ContentView_Separator + "\r\n", sqlTexts);
            })
            .ContinueWith((t) => {
                this.Invoke(new Action(() =>
                {
                    rtContent.Text = result;
                    HilightWord = "";
                }));
            })
            .ContinueWith((t) => {
                releaseTask();
            });
        }

        private void drawError(string error)
        {
            drawStatusBar(error);
        }

        // event

        private Func<string, Task> generateOnFind()
        {
            return (string word) =>
                {
                    return Task.Run(() => {
                        this.Invoke(new Action(() =>
                        {
                            findContent(word);
                        }));
                    });
                };
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            requestSearch();
        }

        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allSelect_eventGuard && lbList.SelectedItems.Count != lbList.Items.Count)
            {
                return;
            }
            drawSqlContext();
        }

        private void refleshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SettingDialog();

            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                requestLoadIndex();
            }
        }

        private void リロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            requestLoadIndex();
        }

        private void txContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                rtContent.SelectAll();
        }

        private void lbList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                requestSelectAllofList();
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (lbList.SelectedIndices.Count > 0)
                {
                    var titles = lbList.SelectedItems.OfType<SqlIndex>().Select((sqlIdx) => sqlIdx.Title);
                    Clipboard.SetText(string.Join("\r\n", titles));

                    e.Handled = true;
                    var indices = lbList.SelectedIndices.OfType<int>().ToList();
                    requestSelectList(indices);
                }
            }
        }

        private void txSearchToken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                requestSearch();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (currentTask == null || currentTask.IsCompleted)
            {
                return;
            }

            ts.Cancel(true);
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            findContent(txFind.Text);
        }

        private void txFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                findContent(txFind.Text);
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            try
            {
                ExternalProgramFacade.OpenAsTempFile(rtContent.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
