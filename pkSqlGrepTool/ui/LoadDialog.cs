using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using pkSqlGrepTool.Properties;

namespace pkSqlGrepTool.ui
{
    public partial class LoadDialog : Form
    {
        public LoadDialog()
        {
            InitializeComponent();
        }

        private void LoadDialog_Load(object sender, EventArgs e)
        {
            txDir.Text = Settings.Default.SqlFile_Directory;
            cbFormat.Text = Settings.Default.SqlFile_Format;
            cbSubDir.Checked = Settings.Default.SqlFile_ReadSubDir;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Settings.Default["SqlFile_Directory"] = txDir.Text;
            Settings.Default["SqlFile_Format"] = cbFormat.Text;
            Settings.Default["SqlFile_ReadSubDir"] = cbSubDir.Checked;
            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btChooseDir_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            dlg.SelectedPath = txDir.Text;

            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txDir.Text = dlg.SelectedPath;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
