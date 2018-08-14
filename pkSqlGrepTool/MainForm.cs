﻿using System;
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
        public MainForm()
        {
            InitializeComponent();
        }


        // inner component

        CancellationTokenSource ts = null;
        Task currentTask = null;

        List<SqlIndex> listSqls = new List<SqlIndex>();

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

            enterTask("検索中");

            assignTask(() =>
            {
                var subTask = SqlFileFacade.RequestSearch(searchToken,
                                SqlMatch.withRegex(regex),
                                SqlMatch.withWord(word),
                                SqlMatch.withIgnoreCase(ignoreCase))
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

        private void findContent()
        {
            var find = txFind.Text.ToLower();
            if (find == "")
            {
                return;
            }
            var cont = txContent.Text.ToLower();
            int startIdx = Math.Min((txContent.SelectionStart) + 1, cont.Length-1);

            int resultIdx = cont.IndexOf(find, startIdx);
            if (resultIdx < 0)
            {
                resultIdx = cont.IndexOf(find);
            }

            if (resultIdx < 0)
            {
                return;
            }

            txContent.Focus();
            txContent.Select(resultIdx, find.Length);
            txContent.ScrollToCaret();
        }

        private void requestSelectAllofList()
        {
            Task.Run(() =>
            {
                this.Invoke(new Action(() =>
                {
                    for (var i = 0; i < lbList.Items.Count; i++)
                    {
                        lbList.SetSelected(i, true);
                    }
                }));
            });
        }

        private void requestCopyListSelection(List<int> indices, List<SqlIndex> sqlIndices)
        {
            if (lbList.SelectedIndices.Count > 0)
            {
                Task.Run(() =>
                {
                    var titles = sqlIndices.Select((sqlIdx) => sqlIdx.Title);
                    Clipboard.SetText(string.Join("\r\n", titles));

                    lbList.ClearSelected();
                    foreach (var i in indices)
                    {
                        lbList.SetSelected(i, true);
                    }
                });
            }
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
            enterTask("ファイル内容描画中...");

            var items = new List<SqlIndex>(lbList.SelectedItems.OfType<SqlIndex>());
            var result = "";

            assignTask(() =>
            {
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
                    txContent.Text = result;
                }));
            })
            .ContinueWith((t) => { releaseTask(); });
        }

        private void drawError(string error)
        {
            drawStatusBar(error);
        }

        // event

        private void Form1_Load(object sender, EventArgs e)
        {
            requestLoadIndex();
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
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
                requestSelectAllofList();
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                var indices = lbList.SelectedIndices.OfType<int>().ToList();
                var sqlIndices = lbList.SelectedItems.OfType<SqlIndex>().ToList();
                requestCopyListSelection(indices, sqlIndices);
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
            findContent();
        }

        private void txFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                findContent();
            }
        }
    }
}
