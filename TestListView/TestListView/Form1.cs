using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestListView
{
    public partial class Form1 : Form
    {
        private string[] files;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {


        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
               
                listView1.Items.Clear();//每次点击事件后将ListView中的数据清空，重新显示
                imageList1.Images.Clear(); //每次点击事件后将imageList中的图片清空，重新显示
                files = this.openFileDialog1.FileNames;
                this.listView1.View = View.LargeIcon;
                
                this.listView1.BeginUpdate();
                for (int i = 0; i < files.Length; i++)
                {
                     
                   
                    this.imageList1.Images.Add(Image.FromFile(this.files[i]));
                  
                    this.listView1.Items.Add(this.files[i].Substring(this.files[i].LastIndexOf(@"\") + 1), i);
                    this.listView1.LargeImageList = this.imageList1;
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); //显示第一张
                    //pictureBox1.Image = Image.FromFile(files[i]); //显示最后一张
                   
                   
                }
                this.listView1.EndUpdate();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.pictureBox1.ImageLocation = this.files[this.listView1.SelectedItems[0].Index];
             
            }
                
        }

       
    }
}
