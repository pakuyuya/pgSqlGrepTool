namespace pkSqlGrepTool.ui
{
    partial class LoadDialog
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
            this.txDir = new System.Windows.Forms.TextBox();
            this.btChooseDir = new System.Windows.Forms.Button();
            this.cbSubDir = new System.Windows.Forms.CheckBox();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ディレクトリ";
            // 
            // txDir
            // 
            this.txDir.Location = new System.Drawing.Point(72, 12);
            this.txDir.Name = "txDir";
            this.txDir.Size = new System.Drawing.Size(348, 19);
            this.txDir.TabIndex = 1;
            // 
            // btChooseDir
            // 
            this.btChooseDir.Location = new System.Drawing.Point(430, 10);
            this.btChooseDir.Name = "btChooseDir";
            this.btChooseDir.Size = new System.Drawing.Size(32, 23);
            this.btChooseDir.TabIndex = 2;
            this.btChooseDir.Text = "...";
            this.btChooseDir.UseVisualStyleBackColor = true;
            this.btChooseDir.Click += new System.EventHandler(this.btChooseDir_Click);
            // 
            // cbSubDir
            // 
            this.cbSubDir.AutoSize = true;
            this.cbSubDir.Location = new System.Drawing.Point(276, 37);
            this.cbSubDir.Name = "cbSubDir";
            this.cbSubDir.Size = new System.Drawing.Size(144, 16);
            this.cbSubDir.TabIndex = 3;
            this.cbSubDir.Text = "サブディレクトリも検索する";
            this.cbSubDir.UseVisualStyleBackColor = true;
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "csv",
            "json"});
            this.cbFormat.Location = new System.Drawing.Point(72, 66);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(121, 20);
            this.cbFormat.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "フォーマット";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(306, 98);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(387, 98);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "キャンセル";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // LoadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 133);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFormat);
            this.Controls.Add(this.cbSubDir);
            this.Controls.Add(this.btChooseDir);
            this.Controls.Add(this.txDir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadDialog";
            this.Text = "ファイルを読み込む";
            this.Load += new System.EventHandler(this.LoadDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txDir;
        private System.Windows.Forms.Button btChooseDir;
        private System.Windows.Forms.CheckBox cbSubDir;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
    }
}