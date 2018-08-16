namespace pkSqlGrepTool.ui
{
    partial class SearchDialog
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
            this.txWord = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txWord
            // 
            this.txWord.Location = new System.Drawing.Point(12, 12);
            this.txWord.Name = "txWord";
            this.txWord.Size = new System.Drawing.Size(295, 19);
            this.txWord.TabIndex = 0;
            this.txWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txWord_KeyDown);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(313, 12);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(63, 19);
            this.btSearch.TabIndex = 1;
            this.btSearch.Text = "検索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 44);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchDialog";
            this.Text = "検索";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txWord;
        private System.Windows.Forms.Button btSearch;
    }
}