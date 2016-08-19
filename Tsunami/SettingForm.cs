using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tsunami
{
    public partial class SettingForm : Form
    {
        public string watcher_path;

        public string copy_path;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txt_path.Text != null)
            {
                this.watcher_path = this.txt_path.Text;
            }
            if (this.oFd_watcherPath.ShowDialog() == DialogResult.OK)
            {
                this.watcher_path = oFd_watcherPath.SelectedPath;
            }
            this.txt_path.Text = this.watcher_path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.watcher_path = txt_path.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.txt_CopyPath.Text != null)
            {
                copy_path = this.txt_CopyPath.Text;
            }
            if (this.oFd_copyPath.ShowDialog() == DialogResult.OK)
            {
                copy_path = oFd_copyPath.SelectedPath;
            }
            this.txt_CopyPath.Text = copy_path;
        }
    }
}
