using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.IO;

namespace TestPcStart
{
    public partial class Form1 : Form
    {

        public static bool start = true;
        public static int num = 0;
        public Form1()
        {
            
            InitializeComponent();
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked) //设置开机自启动  
            {
                
               // MessageBox.Show("设置开机自启动，需要修改注册表", "提示");

                
                //string path = Application.ExecutablePath;
                //RegistryKey rk = Registry.LocalMachine;
                //RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                //rk2.SetValue("JcShutdown", path);
                //rk2.Close();
                //rk.Close();   
                this.Close(); //关闭主线程窗口
                Thread thread1 = new Thread(new ThreadStart(showPic));
                thread1.Start();
                //System.Environment.Exit(0); //彻底关闭所有线程
               
               
               
            }
            else //取消开机自启动  
            {
               // MessageBox.Show("取消开机自启动，需要修改注册表", "提示");
               /* string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("JcShutdown", false);
                rk2.Close();
                rk.Close();
               */
               
                
            }
            
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
           
            //MessageBox.Show(DateTime.Now.ToLongDateString().ToString());
            //添加判断，防止重复赋值。
            
            if (num == 0)
            {
                num++;
                
                checkBox1.Checked = start;
                
                start = false;
               
               
            }
            
            if (num == 1)
            {       
                label1.BackColor = Color.Transparent; //label标签背景透明
                label2.BackColor = Color.Transparent; 
                label1.Text = DateTime.Now.ToLongDateString().ToString();
                SetInfo(label1.Text, label2);
               
            }
              
             
        }

       /// <summary>
       /// 右下角弹出图片
       /// </summary>
        public void showPic()
        {
           
            Form1 frmShowWarning = new Form1();//Form1为要弹出的窗体（提示框），
           
            //frmShowWarning.BackgroundImage = Image.FromFile(Application.StartupPath +"\\1.jpg");  //设置背景图片debug文件夹下
            //添加自动获取图片数量 modify by cfl 2018年3月20日09:15:19
            string dirPath = Application.StartupPath + "\\img\\";
            string[] files = Directory.GetFiles(dirPath, "*.jpg", SearchOption.AllDirectories);
  
            if (files.Length > 0)
            {
                List<string> list = new List<string>();
                GetPicName(files, list);
                SetPicBackground(frmShowWarning, GenerateRandomCode(files.Length),list);
            }
            frmShowWarning.TopMost = true;
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height);
            frmShowWarning.PointToScreen(p);
            frmShowWarning.Location = p;    
            frmShowWarning.Show();
            for (int i = 0; i <= frmShowWarning.Height; i++)
            {
                frmShowWarning.Location = new Point(p.X, p.Y - i);
                Thread.Sleep(5);//将线程沉睡时间调的越小升起的越快
                
                //this.Refresh();
                Application.DoEvents();            
            }
            Thread.Sleep(3000);
            System.Environment.Exit(0); //彻底关闭所有线程
        }
        /// <summary>
        /// 产生一个0-(num-1)的随机数 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int GenerateRandomCode(int num)
        {
           
            int result = 0;
            Random r = new Random();
            result = r.Next(0, num);
            /*for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result = r.Next(0, 10);
            }
             */
            return result;
        }
        /// <summary>
        /// 设置弹窗背景图片
        /// </summary>
        /// <param name="form"></param>
        /// <param name="num"></param>
        public static void SetPicBackground(Form form, int num,List<string> list)
        {

            string file = Application.StartupPath + "\\img\\" + list[num];
            Bitmap bmp = new Bitmap(Image.FromFile(file));

            PointBitmap lockbmp = new PointBitmap(bmp);
            //锁定Bitmap，通过Pixel访问颜色
            lockbmp.LockBits();

            //获取颜色
            Color color = lockbmp.GetPixel(10, 10);

            //从内存解锁Bitmap
            lockbmp.UnlockBits();
           // form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\"+list[num]); //debug文件目录下
            form.BackgroundImage = (Image)bmp;
            /*switch (num)
            {
                case 0: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\0.jpg");
                    break;
                case 1: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\1.jpg");
                    break;
                case 2: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\2.jpg");
                    break;
                case 3: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\3.jpg");
                    break;
                case 4: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\4.jpg");
                    break;
                case 5: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\5.jpg");
                    break;
                case 6: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\6.jpg");
                    break;
                case 7: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\7.jpg");
                    break;
                case 8: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\8.jpg");
                    break;
                case 9: form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\9.jpg");
                    break;

                default:
                    form.BackgroundImage = Image.FromFile(Application.StartupPath + "\\img\\6.jpg");
                    break;
            }
             */ 
        }
        /// <summary>
        /// 设置某月某日弹出的内容
        /// </summary>
        /// <param name="date"></param>
        /// <param name="label"></param>
        public static void SetInfo(string date,Label label)
        {
            XDocument doc = XDocument.Load(Application.StartupPath+"\\config.xml");
            var info = from p in doc.Descendants("Date")
                       select new
                       {
                           date = p.Attribute("date"),
                           text = p.Attribute("text")
                       };
            foreach (var v in info)
            {
                if (date.Equals((string)v.date))
                {
                    label.Text = (string)v.text;
                }
               // Console.WriteLine("date = {0},text = {1}",v.date, v.text);
            }
        }

        /// <summary>
        /// 根据路径获取图片名并添加进集合 modify by cfl 2018年3月20日
        /// </summary>
        public static void GetPicName(string[] files,List<string> list)
        {
            string picname = "";
            foreach (var item in files)
            {
                //获取图片名
               picname =  item.ToString().Replace(Application.StartupPath, "").Split('\\')[2]; //此处反斜杠
               list.Add(picname);
            }
        }
    }
}
