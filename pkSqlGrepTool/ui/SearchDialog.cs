using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pkSqlGrepTool.ui
{
    public partial class SearchDialog : Form
    {
        public SearchDialog()
        {
            InitializeComponent();
        }
        public Func<string, Task> SearchCallback { get; set; } = null;

        private void doCallback()
        {
            if (SearchCallback != null)
            {
                SearchCallback(txWord.Text)
                    .ContinueWith((t) =>
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.Activate();
                        }));
                    });
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            doCallback();
        }

        private void txWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doCallback();
            }
        }
    }
}
