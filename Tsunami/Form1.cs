using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Media;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Drawing;
using System.Configuration;

namespace Tsunami
{
    
    public partial class Form1 : Form
    {

        public string watcher_Path = null;

        public string copy_Path = null;

        SoundPlayer player = new SoundPlayer();

        Thread t;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //this.dataGridView1.AllowUserToAddRows = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
           //读取配置文件中的监控路径及备份路径
           this.copy_Path = LoadAppSetting("copypath");
            this.watcher_Path = LoadAppSetting("sourcepath");
            this.tsb_CloseSong.Enabled = false;
        }

       public delegate void DgShowMessage(string msg,DateTime dt);

        public void ShowMessage(string msg)
        {
            
            //1 若datagrd中超过五行则执行清除
           // if (this.dataGridView1.Rows.Count > 20)
            //{
            //    this.dataGridView1.Rows.RemoveAt(0);
            //}
            //this.dataGridView1.Rows.Add(msg);           
            //PlaySong();
        }
      
        /// <summary>
        /// 读取配置文件中的声音路径
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string LoadAppSetting(string key)
        {
            foreach (string item in ConfigurationManager.AppSettings)
            {
                if (item == key)
                {
                    return ConfigurationManager.AppSettings[key];
                }
            }
            return null;
        }

        public void LoadSong()
        {
            //加载音乐文件
            var sonpath = LoadAppSetting("songpath");
            player.SoundLocation = @sonpath;
            player.Load();
        }

        public void PlaySong()
        {
            this.player.PlayLooping();
            try
            {
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
        public void StopSong()
        {
            this.player.Stop();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //this.dataGridView1[]
        }

        
        public string ReadFile(string path)
        {
            byte[] byData = new byte[100];
            char[] charData = new char[1000];
            string result = null;
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                
                result= sr.ReadToEnd();
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //将选中的行字体取消加粗
            //dataGridView1.SelectedRows[0].DefaultCellStyle.Font= new Font("Tahoma", 10, FontStyle.Regular);

            //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.Font= new Font("Tahoma", 10, FontStyle.Regular);
            //1 停止播放音乐
            StopSong();

            //2 获取文件名
            //var name = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            
            //string fullPath = Path.Combine(copy_Path, name);
            //3 在右侧的textbox中展示          
            //var str= ReadFile(fullPath).ToString();
            //this.richTextBox1.Text = str;

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.watcher_path = this.watcher_Path == null ? null : this.watcher_Path;
            settingForm.ShowDialog();
            if (settingForm.DialogResult == DialogResult.OK)
            {
                this.copy_Path = settingForm.copy_path;
                this.watcher_Path = settingForm.watcher_path;
            }
        }

        /// <summary>
        /// 判断几个配置文件及监控路径是否已经加载上
        /// </summary>
        /// <returns></returns>
        private bool CheckLoadConfig()
        {
            if (this.copy_Path == null || watcher_Path == null)
            {
                MessageBox.Show("请选择监控路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            
            return true;
        }

        private void AddInfo2Lv(string name,DateTime dt)
        {
            this.PlaySong();
            ListViewItem lv_item = new ListViewItem(name);
            lv_item.Font= new Font("Tahoma", 10, FontStyle.Bold);
            lv_item.SubItems.Add(dt.ToShortTimeString());
            lv_item.EnsureVisible();
            if (this.lv_fileInfo.Items.Count > 20)
            {
                this.lv_fileInfo.Items.Clear();
                this.richTextBox1.Clear();
            }
            this.lv_fileInfo.Items.Add(lv_item);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!CheckLoadConfig())
            {
                return;
            }
            LoadSong();
            EarthQuakeEvent eqe = new EarthQuakeEvent(watcher_Path,copy_Path);
            DgShowMessage dg = new DgShowMessage(AddInfo2Lv);
            if (t == null)
            {
                t = new Thread(new ParameterizedThreadStart(eqe.Run));                
            }
            if (t.ThreadState != ThreadState.Running&&t.ThreadState!=ThreadState.Stopped&&t.ThreadState!=ThreadState.Aborted)
            {
                t = new Thread(new ParameterizedThreadStart(eqe.Run));
                t.Start(dg);
                t.IsBackground = true;
            }
            
            this.tsb_Start.Enabled = false;
            this.tsb_StopWatch.Enabled = true;
            //this.tsb_Start.Enabled = true;
            this.tsb_CloseSong.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            StopSong();

            //LoadSong();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           // StopSong();
        }

        private void lv_fileInfo_Click(object sender, EventArgs e)
        {
            //1 点击后
            this.lv_fileInfo.SelectedItems[0].SubItems[0].Font= new Font("Tahoma", 10, FontStyle.Regular);
            //2 停止播放音乐
            StopSong();

            //3 获取文件名
            var name = this.lv_fileInfo.SelectedItems[0].SubItems[0].Text.ToString();

            string fullPath = Path.Combine(copy_Path, name);
            //4 在右侧的textbox中展示          
            var str = ReadFile(fullPath).ToString();
            this.richTextBox1.Text = str;

        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (this.t != null)
            {
                t.Abort();
                
                this.tsb_Start.Enabled = true;
                this.tsb_CloseSong.Enabled = false;
                this.tsb_StopWatch.Enabled = false;
            }
        }
    }

}