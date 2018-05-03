using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demo7._30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool value = false;
        bool camera = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (value == false)
            {
                MessageBox.Show("请先开始预览");
            }
            else
            {
                if (camera == true)
                {
                    captrue.bStopPlay();
                    captrue.bStartPlay2(0);
                    camera = false;
                }
                else
                {
                    captrue.bStopPlay();
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                             captrue.bStartPlay();
                            break;
                        case 1:
                            captrue.bStartPlayRotate(90);
                            break;
                        case 2:
                             captrue.bStartPlayRotate(180);
                            break;
                        case 3:
                             captrue.bStartPlayRotate(270);
                            break;
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            captrue.bSetMode(0);
                            break;
                        case 1:
                            captrue.bSetMode(1);
                            captrue.bSetImageArea(100, 500, 9900, 9700);
                            break;
                        case 2:
                            captrue.bSetMode(4);
                            break;
                        case 3:
                            captrue.bSetMode(3);
                            break;
                    }
                  //  switch(checkBox1.Checked){
                  //      case true:

                 //   }
                    camera = true ;
                }
            }
        }
        /// <summary>
        /// 拍照按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if(camera == true){
                if (checkBox1.Checked)
                {
                    captrue.vSetSkewFlag(true);
                    captrue.vSetDelHBFlag(true);
                }
                else
                {
                    captrue.vSetSkewFlag(false);
                    captrue.vSetDelHBFlag(false);
                }
                if (checkBox2.Checked)
                {
                    captrue.vSetRemoveGBFlag(true);
                }
                else
                {
                    captrue.vSetRemoveGBFlag(false);
                }
            }

            string materialName = comboBox4.Text; //材料名称
            string savepicPath = textBox1.Text;  //保存路径 
            string time = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff",DateTimeFormatInfo.InvariantInfo); //当前时间
            string filename = "\\Manual" + time ; //manual 手册 指南
            string filePath = savepicPath + "\\"; //文件路径



            if (!string.IsNullOrEmpty(materialName))
            {
                filename = materialName;
                if (File.Exists(filePath+filename + ".jpg")) 
                {
                    int i = 1;
                    filename =  materialName + "_" + i;
                    while (File.Exists(filePath+filename + ".jpg"))
                    {
                        i++;
                        filename =  materialName + "_" + i;
                    }
                }
            }
            //如果是默认的路径，那么就创建该默认路径，否则按照手动选择的路径
            if (savepicPath.Equals("D:/temp"))
            {

                if (!Directory.Exists(savepicPath))
                {
                    Directory.CreateDirectory(savepicPath);
                }

            }

            if (captrue.bSaveJPG(filePath, filename))
            {
                captrueList.AddImage(filePath + filename + ".jpg");
            }
            else
            {
                MessageBox.Show("图片保存失败！");
            }

            

            //MessageBox.Show(textBox1.Text);

            //switch (comboBox3.SelectedIndex)
            //{
            //    case 0:
            //        captrue.bSaveJPG("D:\\","test");
            //        captrueList.AddImage("D:\\test.jpg");
            //        break;
            //    case 1:
            //        captrue.bSaveTIF("D:\\", "test");
            //        captrueList.AddImage("D:\\test.tif");
            //        break;
            //    case 2:
            //        captrue.bSaveGray("D:\\", "test");
            //        captrueList.AddImage("D:\\test.jpg");
            //        break;
            //}
            //captrue.bSaveJPG("D:\\","test");

            //设置图片保存位置
           // string savePath = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            captrue.bStopPlay();
            var str = false;
            //var str = captrue.bStartPlay();
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    str = captrue.bStartPlay();
                    break;
                case 1:
                    str = captrue.bStartPlayRotate(90);
                    break;
                case 2:
                    str = captrue.bStartPlayRotate(180);
                    break;
                case 3:
                    str = captrue.bStartPlayRotate(270);
                    break;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    captrue.bSetMode(0);
                    break;
                case 1:
                    captrue.bSetMode(1);
                    captrue.bSetImageArea(100, 500, 9900, 9700);
                    break;
                case 2:
                    captrue.bSetMode(4);
                    break;
                case 3:
                    captrue.bSetMode(3);
                    break;
            }
            if (checkBox1.Checked)
                {
                    captrue.vSetSkewFlag(true);
                    captrue.vSetDelHBFlag(true);
                }
                else
                {
                    captrue.vSetSkewFlag(false);
                    captrue.vSetDelHBFlag(false);
                }
            if(str == true){
                value = true;
                camera = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            captrue.bStopPlay();
            value = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            captrue.displayVideoPara();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            captrue.vZoomOut();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            captrue.vZoomIn();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0){
                captrue.bSetMode(0);
            }
            else if(comboBox1.SelectedIndex  == 1){
                captrue.bSetMode(1);
                captrue.bSetImageArea(100,500,9900,9700);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                captrue.bSetMode(4);
            }
            else
            {
                captrue.bSetMode(3);
            }
        }

        private void captrueList_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (value == false)
            {
               // MessageBox.Show("请先开始预览");
            }
            else
            {
                if (camera == false)
                {

                }
                else
                {
                    captrue.bStopPlay();
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            captrue.bStartPlay();
                            break;
                        case 1:
                            captrue.bStartPlayRotate(90);
                            break;
                        case 2:
                            captrue.bStartPlayRotate(180);
                            break;
                        case 3:
                            captrue.bStartPlayRotate(270);
                            break;
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            captrue.bSetMode(0);
                            break;
                        case 1:
                            captrue.bSetMode(1);
                            captrue.bSetImageArea(100, 500, 9900, 9700);
                            break;
                        case 2:
                            captrue.bSetMode(4);
                            break;
                        case 3:
                            captrue.bSetMode(3);
                            break;
                    }
                }
                
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            XDocument doc = XDocument.Load("FJCL.xml"); //读取配置文件，获取材料名称
            if (doc!=null)
            {
                var filenames = from n in doc.Descendants("FJCL") select n;
                foreach (string filename in filenames)
                {
                    comboBox4.Items.Add(filename);
                }
            }
            else
            {
                MessageBox.Show("debug 目录下缺少配置文件 FJCL.XML");
            }
           
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (camera == false)
            {

            }
            else
            {
                if (checkBox1.Checked)
                {
                    captrue.vSetSkewFlag(true);
                    captrue.vSetDelHBFlag(true);
                }
                else
                {
                    captrue.vSetSkewFlag(false);
                    captrue.vSetDelHBFlag(false);
                }
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (camera == false)
            {

            }
            else
            {
                if (checkBox2.Checked)
                {
                    captrue.vSetRemoveGBFlag(true);
                }
                else
                {
                    captrue.vSetRemoveGBFlag(false);
                }
            }
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            //comboBox4.SelectedIndex = 0;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }



    }
}
