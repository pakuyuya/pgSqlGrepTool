namespace pkSqlGrepTool.ui
{
    partial class SettingDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txSqlFile_Directory = new System.Windows.Forms.TextBox();
            this.btChooseDir = new System.Windows.Forms.Button();
            this.cbSqlFile_ReadSubDir = new System.Windows.Forms.CheckBox();
            this.txSqlFile_Format = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txOpenArguments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txOpenTempfileExt = new System.Windows.Forms.TextBox();
            this.txOpenCommand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btSelectOpenProgram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ファイル配置ディレクトリ";
            // 
            // txSqlFile_Directory
            // 
            this.txSqlFile_Directory.Location = new System.Drawing.Point(10, 29);
            this.txSqlFile_Directory.Name = "txSqlFile_Directory";
            this.txSqlFile_Directory.Size = new System.Drawing.Size(348, 19);
            this.txSqlFile_Directory.TabIndex = 1;
            // 
            // btChooseDir
            // 
            this.btChooseDir.Location = new System.Drawing.Point(364, 27);
            this.btChooseDir.Name = "btChooseDir";
            this.btChooseDir.Size = new System.Drawing.Size(32, 23);
            this.btChooseDir.TabIndex = 2;
            this.btChooseDir.Text = "...";
            this.btChooseDir.UseVisualStyleBackColor = true;
            this.btChooseDir.Click += new System.EventHandler(this.btChooseDir_Click);
            // 
            // cbSqlFile_ReadSubDir
            // 
            this.cbSqlFile_ReadSubDir.AutoSize = true;
            this.cbSqlFile_ReadSubDir.Location = new System.Drawing.Point(10, 54);
            this.cbSqlFile_ReadSubDir.Name = "cbSqlFile_ReadSubDir";
            this.cbSqlFile_ReadSubDir.Size = new System.Drawing.Size(144, 16);
            this.cbSqlFile_ReadSubDir.TabIndex = 3;
            this.cbSqlFile_ReadSubDir.Text = "サブディレクトリも検索する";
            this.cbSqlFile_ReadSubDir.UseVisualStyleBackColor = true;
            // 
            // txSqlFile_Format
            // 
            this.txSqlFile_Format.FormattingEnabled = true;
            this.txSqlFile_Format.Items.AddRange(new object[] {
            "csv",
            "json"});
            this.txSqlFile_Format.Location = new System.Drawing.Point(10, 97);
            this.txSqlFile_Format.Name = "txSqlFile_Format";
            this.txSqlFile_Format.Size = new System.Drawing.Size(121, 20);
            this.txSqlFile_Format.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "ファイルフォーマット";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(244, 2);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(325, 2);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "キャンセル";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btOK);
            this.splitContainer1.Panel2.Controls.Add(this.btCancel);
            this.splitContainer1.Size = new System.Drawing.Size(413, 193);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 159);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txSqlFile_Format);
            this.tabPage1.Controls.Add(this.cbSqlFile_ReadSubDir);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btChooseDir);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txSqlFile_Directory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(419, 133);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "検索データ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btSelectOpenProgram);
            this.tabPage2.Controls.Add(this.txOpenArguments);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txOpenTempfileExt);
            this.tabPage2.Controls.Add(this.txOpenCommand);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(405, 133);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "プログラム";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txOpenArguments
            // 
            this.txOpenArguments.Location = new System.Drawing.Point(10, 66);
            this.txOpenArguments.Name = "txOpenArguments";
            this.txOpenArguments.Size = new System.Drawing.Size(386, 19);
            this.txOpenArguments.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "引数（{0}=ファイル名）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "一時ファイルの拡張子";
            // 
            // txOpenTempfileExt
            // 
            this.txOpenTempfileExt.Location = new System.Drawing.Point(10, 103);
            this.txOpenTempfileExt.Name = "txOpenTempfileExt";
            this.txOpenTempfileExt.Size = new System.Drawing.Size(109, 19);
            this.txOpenTempfileExt.TabIndex = 3;
            // 
            // txOpenCommand
            // 
            this.txOpenCommand.Location = new System.Drawing.Point(10, 29);
            this.txOpenCommand.Name = "txOpenCommand";
            this.txOpenCommand.Size = new System.Drawing.Size(348, 19);
            this.txOpenCommand.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "「プログラムから開く」プログラム";
            // 
            // btSelectOpenProgram
            // 
            this.btSelectOpenProgram.Location = new System.Drawing.Point(364, 27);
            this.btSelectOpenProgram.Name = "btSelectOpenProgram";
            this.btSelectOpenProgram.Size = new System.Drawing.Size(32, 23);
            this.btSelectOpenProgram.TabIndex = 5;
            this.btSelectOpenProgram.Text = "...";
            this.btSelectOpenProgram.UseVisualStyleBackColor = true;
            this.btSelectOpenProgram.Click += new System.EventHandler(this.btSelectOpenProgram_Click);
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 193);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingDialog";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.LoadDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txSqlFile_Directory;
        private System.Windows.Forms.Button btChooseDir;
        private System.Windows.Forms.CheckBox cbSqlFile_ReadSubDir;
        private System.Windows.Forms.ComboBox txSqlFile_Format;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txOpenCommand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txOpenTempfileExt;
        private System.Windows.Forms.TextBox txOpenArguments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSelectOpenProgram;
    }
}