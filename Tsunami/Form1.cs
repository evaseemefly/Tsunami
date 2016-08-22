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

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

        }

       public delegate void DgShowMessage(string msg);

        public void ShowMessage(string msg)
        {
            
            //1 若datagrd中超过五行则执行清除
            if (this.dataGridView1.Rows.Count > 5)
            {
                this.dataGridView1.Rows.RemoveAt(0);
            }
            this.dataGridView1.Rows.Add(msg);           
            PlaySong();
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
            
            //mciSendString(@"close temp_alias", null, 0, 0);

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
                //while ((line = sr.ReadLine()) != null)
                //{
                //    result
                //    Console.WriteLine(line.ToString());
                //}
                //FileStream file = new FileStream(path, FileMode.Open);
                //file.Seek(0, SeekOrigin.Begin);
                //file.Read(byData, 0, 100); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
                //Decoder d = Encoding.Default.GetDecoder();
                //d.GetChars(byData, 0, byData.Length, charData, 0);
                //Console.WriteLine(charData);
                //file.Close();
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

            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.Font= new Font("Tahoma", 10, FontStyle.Regular);
            //1 停止播放音乐
            StopSong();

            //2 获取文件名
            var name = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            
            string fullPath = Path.Combine(copy_Path, name);
            //3 在右侧的textbox中展示          
            var str= ReadFile(fullPath).ToString();
            this.richTextBox1.Text = str;

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!CheckLoadConfig())
            {
                return;
            }
            EarthQuakeEvent eqe = new EarthQuakeEvent(watcher_Path,copy_Path);
            DgShowMessage dg = new DgShowMessage(ShowMessage);
            Thread t = new Thread(new ParameterizedThreadStart(eqe.Run));
            t.Start(dg);
            t.IsBackground = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadSong();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            StopSong();
        }
    }

}