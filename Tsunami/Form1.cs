using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Media;

namespace Tsunami
{
    
    public partial class Form1 : Form
    {
        

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        
       
        
//        public static extern uint mciSendString(string lpstrCommand,
//string lpstrReturnString, uint uReturnLength, uint hWndCallback);
       [DllImport("winmm.dll")]
       static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EarthQuakeEvent eqe = new EarthQuakeEvent();
            DgShowMessage dg = new DgShowMessage(ShowMessage);
            Thread t = new Thread(new ParameterizedThreadStart(eqe.Run));
             t.Start(dg);
            t.IsBackground = true;
           
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
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count].DefaultCellStyle.Font = new Font("宋体", 9, FontStyle.Strikeout);
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count].DefaultCellStyle.BackColor = Color.Green;
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count].DefaultCellStyle.BackColor = Color.Green;
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count].Cells[0].Style.ForeColor = Color.Red;
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count].DefaultCellStyle.BackColor = Color.Blue;
            PlaySong();
            
            System.Media.SystemSounds.Question.Play();
            System.Media.SystemSounds.Question.Play();
            System.Media.SystemSounds.Question.Play();
            System.Media.SystemSounds.Question.Play();
            System.Media.SystemSounds.Question.Play();
            System.Media.SystemSounds.Question.Play();


        }
      
        public void PlaySong()
        {
            PlaySound("c:\\sound.wav", UIntPtr.Zero,
          (uint)0x0010);
            System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer(@"c:\sound.wav");
            simpleSound.Play();
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            string tempt = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sound.wav");
                //assembly = Assembly.GetExecutingAssembly();
                //sp = new System.Media.SoundPlayer(assembly.GetManifestResourceStream(tempt));
                sp.SoundLocation= "C:/sound.wav";
                sp.Play();

            try
            {
                //Assembly assembly;
                
                //sp.SoundLocation = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sound.wav");
                //sp.PlayLooping();
                
                //mciSendString(@"close temp_alias", null, 0, 0);
                //mciSendString(@"open " + tempt + " alias temp_alias", null, 0, 0);
                //mciSendString("play temp_alias repeat", null, 0, 0);
            }
            catch (Exception ex)
            {

                throw;
            }
            

            //mciSendString(@"open ""sound.wav"" alias temp_alias", null, 0, 0);
            //mciSendString("play temp_alias repeat", null, 0, 0);

        }
        public void StopSong()
        {
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
            //1 获取文件名
            var name = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            string fullPath = Path.Combine(Application.StartupPath, "backup", name);
            //2           
            this.richTextBox1.Text = ReadFile(fullPath).ToString();



        }
    }

}