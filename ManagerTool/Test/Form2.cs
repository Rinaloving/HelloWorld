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

namespace Test
{
    
    public partial class Form2 : Form
    {
        public static Form1 form1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(richTextBox1.Text);
            //MessageBox.Show(Test.Form1.currentProcid); //获取ID号
            PROCPRESET pr = SystemHandler.Instance.EstateContext.GetEntity<PROCPRESET>("PROC_ID", Test.Form1.currentProcid);
            if(pr != null){
                pr.CHEOPINION = richTextBox1.Text;
                pr.CHEOPINION2 = richTextBox2.Text;
                pr.CHEOPINION3 = richTextBox3.Text;
                pr.CHEOPINION4 = richTextBox4.Text;
                pr.AUDOPINION = richTextBox5.Text;
                pr.APROPINION = richTextBox6.Text;
                SystemHandler.Instance.EstateContext.Update(pr);
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("该表未建立，执行失败！");
            }
           


        }
    }
}
