using DataConvert.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Test
{
    public partial class Form3 : Form
    {
        public static DialogResult checkResult; //用来判断连接是否成功

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //加载时，默认的初始值
            textBox1.Text = "127.0.0.1";
            textBox2.Text = "orcl";
            textBox3.Text = "pfuser";
            estateNametextBox.Text = "estate";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //先创建一个xml文档
            string path = @"C:\UserLoginInfo"; //记录用户登录信息
            string IP = textBox1.Text.Trim();
            string Sid = textBox2.Text.Trim();
            string userName = textBox3.Text.Trim();
            string passWord = textBox4.Text.Trim();
            string estateName = estateNametextBox.Text.Trim();
            string estateWord = estateWordtextBox.Text.Trim();
            if(IP.Equals("")){
                MessageBox.Show("服务器IP不能为空！");
            }
            else if (Sid.Equals(""))
            {
                 MessageBox.Show("数据库名不能为空！");
            }
            else if (userName.Equals(""))
            {
                 MessageBox.Show("pfuser用户名称不能为空！");
            }
            else if (passWord.Equals(""))
            {
                MessageBox.Show("pfuser用户密码不能为空！");
            }
            else if (estateName.Equals(""))
            {
                MessageBox.Show("estate用户名称不能为空！");
            }
            else if (estateWord.Equals(""))
            {
                MessageBox.Show("estate用户密码不能为空！");
            }else
            {
                XElement root = new XElement("Categories",
                    new XElement("Category",
                        new XElement("IP", IP),
                        new XElement("Sid", Sid),
                        new XElement("userName", userName),
                        new XElement("passWord", passWord),
                        new XElement("estateName",estateName),
                        new XElement("estateWord",estateWord))
                );
                root.Save(path);
                try
                {
                    bool result = SystemHandler.Instance.TestOracleConnection1(IP, Sid, userName, passWord);
                    bool result2 = SystemHandler.Instance.TestOracleConnection1(IP, Sid, estateName, estateWord);
                    if (result && result2)
                    {
                        MessageBox.Show("连接成功！");
                        checkResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("连接失败！");
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("连接失败！");
                }
            }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态
                this.Close();    //关闭登录窗口
            }
            else
            {
                MessageBox.Show("无法登录！");
            }
             
        }

    }
}
