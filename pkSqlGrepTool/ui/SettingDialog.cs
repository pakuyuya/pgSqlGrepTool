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
    public partial class SettingDialog : Form
    {
        public SettingDialog()
        {
            InitializeComponent();
        }

        private void LoadDialog_Load(object sender, EventArgs e)
        {
            txSqlFile_Directory.Text = Settings.Default.SqlFile_Directory;
            txSqlFile_Format.Text = Settings.Default.SqlFile_Format;
            cbSqlFile_ReadSubDir.Checked = Settings.Default.SqlFile_ReadSubDir;
            txOpenCommand.Text = Settings.Default.OpenCommand;
            txOpenArguments.Text = Settings.Default.OpenArguments;
            txOpenTempfileExt.Text = Settings.Default.OpenTempfileExt;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Settings.Default["SqlFile_Directory"] = txSqlFile_Directory.Text;
            Settings.Default["SqlFile_Format"] = txSqlFile_Format.Text;
            Settings.Default["SqlFile_ReadSubDir"] = cbSqlFile_ReadSubDir.Checked;
            Settings.Default["OpenCommand"] = txOpenCommand.Text;
            Settings.Default["OpenArguments"] = txOpenArguments.Text;
            Settings.Default["OpenTempfileExt"] = txOpenTempfileExt.Text;
            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btChooseDir_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            dlg.SelectedPath = txSqlFile_Directory.Text;

            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txSqlFile_Directory.Text = dlg.SelectedPath;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btSelectOpenProgram_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.FileName = txOpenCommand.Text;

            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txOpenCommand.Text = dlg.FileName;
            }
        }
    }
}
