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

namespace pkSqlGrepTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        // inner component
        
        Task taskRefleshIndex = null;
        Task taskSearch = null;

        List<SqlIndex> listSqls = new List<SqlIndex>();

        // inner action
        private void requestLoadIndex()
        {
            if (taskRefleshIndex != null && !taskRefleshIndex.IsCompleted)
            {
                return;
            }

            drawEnterLoadIndex();

            taskRefleshIndex =
                SqlFileFacade.RequestRefleshRepos()
                .ContinueWith((t) => {
                    this.Invoke(new Action(drawEndLoadIndex));
                    taskRefleshIndex = null;
                })
                .ContinueWith((t) => { requestSearch(); });
        }

        private void requestSearch()
        {
            if (taskSearch != null && !taskSearch.IsCompleted)
            {
                return;
            }
            if (taskRefleshIndex != null && !taskRefleshIndex.IsCompleted)
            {
                taskRefleshIndex.Wait();
            }
            drawEnterSearch();

            var searchToken = txSearchToken.Text;
            var regex = cbCondRegex.Checked;
            var word = cbCondWord.Checked;

            taskSearch = SqlFileFacade.RequestSearch(searchToken, SqlMatch.withRegex(regex), SqlMatch.withWord(word))
                .ContinueWith((t) => {
                    listSqls.Clear();
                    listSqls.AddRange(t.Result);
                    this.Invoke(new Action(drawEndSearch));
                    taskSearch = null;
                });
        }

        // draw

        private void drawStatusBar()
        {

        }

        private void drawEnterLoadIndex()
        {
            toolStripStatusLabel1.Text = "ロード中...";
            btSearch.Enabled = false;
        }
        private void drawEndLoadIndex()
        {
            toolStripStatusLabel1.Text = "";
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
            var sqlTexts = lbList.SelectedItems.OfType<SqlIndex>()
                            .Select( (idx) =>
                            {
                                return "-- "
                                        + idx.Title + "\r\n"
                                        + idx.Sql + "\r\n";
                            });

            var content = string.Join("\r\n\r\n", sqlTexts);

            txContent.Text = content;
        }

        // event

        private void Form1_Load(object sender, EventArgs e)
        {
            requestLoadIndex();
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            // TODO: 検索をリクエストする
            requestSearch();
        }

        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawSqlContext();
        }

        private void refleshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new LoadDialog();

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
                txContent.SelectAll();
        }

        private void lbList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                for (var i=0; i<lbList.Items.Count; i++)
                {
                    lbList.SetSelected(i, true);
                }
            }
        }
    }
}
