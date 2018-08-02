namespace pkSqlGrepTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btSearch = new System.Windows.Forms.Button();
            this.lable1 = new System.Windows.Forms.Label();
            this.cbCondRegex = new System.Windows.Forms.CheckBox();
            this.cbCondWord = new System.Windows.Forms.CheckBox();
            this.txSearchToken = new System.Windows.Forms.TextBox();
            this.lbList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txContent = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refleshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.リロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(881, 463);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btSearch);
            this.splitContainer3.Panel1.Controls.Add(this.lable1);
            this.splitContainer3.Panel1.Controls.Add(this.cbCondRegex);
            this.splitContainer3.Panel1.Controls.Add(this.cbCondWord);
            this.splitContainer3.Panel1.Controls.Add(this.txSearchToken);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lbList);
            this.splitContainer3.Size = new System.Drawing.Size(183, 463);
            this.splitContainer3.SplitterDistance = 108;
            this.splitContainer3.TabIndex = 0;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(12, 54);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(156, 23);
            this.btSearch.TabIndex = 4;
            this.btSearch.Text = "検索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(12, 10);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(50, 12);
            this.lable1.TabIndex = 3;
            this.lable1.Text = "SQL検索";
            // 
            // cbCondRegex
            // 
            this.cbCondRegex.AutoSize = true;
            this.cbCondRegex.Location = new System.Drawing.Point(87, 85);
            this.cbCondRegex.Name = "cbCondRegex";
            this.cbCondRegex.Size = new System.Drawing.Size(72, 16);
            this.cbCondRegex.TabIndex = 2;
            this.cbCondRegex.Text = "正規表現";
            this.cbCondRegex.UseVisualStyleBackColor = true;
            // 
            // cbCondWord
            // 
            this.cbCondWord.AutoSize = true;
            this.cbCondWord.Enabled = false;
            this.cbCondWord.Location = new System.Drawing.Point(12, 85);
            this.cbCondWord.Name = "cbCondWord";
            this.cbCondWord.Size = new System.Drawing.Size(69, 16);
            this.cbCondWord.TabIndex = 1;
            this.cbCondWord.Text = "単語のみ";
            this.cbCondWord.UseVisualStyleBackColor = true;
            // 
            // txSearchToken
            // 
            this.txSearchToken.Location = new System.Drawing.Point(12, 29);
            this.txSearchToken.Name = "txSearchToken";
            this.txSearchToken.Size = new System.Drawing.Size(156, 19);
            this.txSearchToken.TabIndex = 0;
            this.txSearchToken.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txSearchToken_KeyDown);
            // 
            // lbList
            // 
            this.lbList.DisplayMember = "Title";
            this.lbList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbList.FormattingEnabled = true;
            this.lbList.ItemHeight = 12;
            this.lbList.Location = new System.Drawing.Point(0, 0);
            this.lbList.Name = "lbList";
            this.lbList.ScrollAlwaysVisible = true;
            this.lbList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbList.Size = new System.Drawing.Size(183, 351);
            this.lbList.TabIndex = 0;
            this.lbList.TabStop = false;
            this.lbList.SelectedIndexChanged += new System.EventHandler(this.lbList_SelectedIndexChanged);
            this.lbList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbList_KeyDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txContent);
            this.splitContainer2.Size = new System.Drawing.Size(694, 463);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 0;
            // 
            // txContent
            // 
            this.txContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txContent.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txContent.Location = new System.Drawing.Point(0, 0);
            this.txContent.Multiline = true;
            this.txContent.Name = "txContent";
            this.txContent.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txContent.Size = new System.Drawing.Size(694, 434);
            this.txContent.TabIndex = 0;
            this.txContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txContent_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refleshToolStripMenuItem,
            this.リロードToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refleshToolStripMenuItem
            // 
            this.refleshToolStripMenuItem.Name = "refleshToolStripMenuItem";
            this.refleshToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.refleshToolStripMenuItem.Text = "読み込み...";
            this.refleshToolStripMenuItem.Click += new System.EventHandler(this.refleshToolStripMenuItem_Click);
            // 
            // リロードToolStripMenuItem
            // 
            this.リロードToolStripMenuItem.Name = "リロードToolStripMenuItem";
            this.リロードToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.リロードToolStripMenuItem.Text = "リロード";
            this.リロードToolStripMenuItem.Click += new System.EventHandler(this.リロードToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(881, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 487);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "SQL抽出閲覧君";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.CheckBox cbCondRegex;
        private System.Windows.Forms.CheckBox cbCondWord;
        private System.Windows.Forms.TextBox txSearchToken;
        private System.Windows.Forms.ListBox lbList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txContent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refleshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem リロードToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

