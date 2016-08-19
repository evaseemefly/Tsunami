using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;


namespace Tsunami
{
    public class EarthQuakeEvent
    {
        //public static string backupDir { get; set; }

        /// <summary>
        /// 监控路径
        /// </summary>
        public static string watcher_Path { get; set; }

        public static string copy_Path { get; set; }

        private static Form1.DgShowMessage dg_show;

        public EarthQuakeEvent(string watcher_path,string copy_path)
        {
            watcher_Path = watcher_path;
            copy_Path = copy_path;
            Initialize();
        }

        public void Initialize()
        {
            String temp;
            temp = System.Windows.Forms.Application.StartupPath;
            //backupDir = temp + "\\backup\\";
            //StreamReader sr = new StreamReader(temp + "\\config.txt", Encoding.Default);
            //watcher_Path = sr.ReadLine();

            if (watcher_Path == null)
            {
                MessageBox.Show("please write GTS products directory into the file of config.txt");
                System.Environment.Exit(0);
            }
            //sr.Close();

        }
        public void Run(object dg)
        {

            //while (true)
            //{
            dg_show = dg as Form1.DgShowMessage;
                WatcherStrat(watcher_Path, "*.txt");
                //Thread.Sleep(5000);
            //}


        }
        private static void WatcherStrat(string path, string filter)
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.Filter = filter;
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = false;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Created += new FileSystemEventHandler(OnProcess);
            return;
        }

        private static void ShowAndSong(string msg)
        {
            dg_show(msg);
           // PlaySong();
        }

        private static void OnProcess(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                try
                {
                    System.IO.File.Copy(e.FullPath,Path.Combine(copy_Path , e.Name), true);
                    ShowAndSong(e.Name);
                    return;
                }
                catch(Exception ex)
                {
                    return;
                }
                
                //Form1 form1_obj = new Form1();
                //if (form1_obj.dataGridView1.Rows.Count < 5)
                //{
                //    form1_obj.dataGridView1.Rows.Add(e.Name);
                //}

//                DataGridViewRow row = new DataGridViewRow();
//                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
//                textboxcell.Value = e.Name;
//                row.Cells.Add(textboxcell);

               
             }
        }

        public void ShowMsg(string msg)
        {

        }


    }
}
