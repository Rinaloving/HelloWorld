using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using DataConvert.Business;
using System.Xml.Linq;
namespace Test
{
    public partial class Form1 : Form
    {
        public static string currentProcid = ""; //proc_id
        public static string currentCheopinion = ""; //初审1
        public static string currentCheopinion2 = "";//初审2
        public static string currentCheopinion3 = "";//初审3
        public static string currentCheopinion4 = "";//初审4 
        public static string currentAudopinion = "";//复审
        public static string currentApropinion = "";//审批

        public static Form2 form2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Print_Process(IList<PROCESS> pr2, DataGridView dataGridView1)
        {

            for (int i = 0; i < pr2.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = pr2[i].PROC_ID;   //ID号
                dataGridView1.Rows[i].Cells[1].Value = pr2[i].PROCESS_NAME; //流程名称
                dataGridView1.Rows[i].Cells[2].Value = pr2[i].CURNO; //流程代码
                dataGridView1.Rows[i].Cells[3].Value = pr2[i].PRE_LENGTH; //编号长度
                dataGridView1.Rows[i].Cells[4].Value = pr2[i].EXECUTE_TIME; //执行时限
                if (pr2[i].ISVALID == 1)
                {
                    dataGridView1.Rows[i].Cells[5].Value = "是"; //是否启动
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "否"; //是否启动
                }
                if (pr2[i].ISFLOW == 1)
                {
                    dataGridView1.Rows[i].Cells[6].Value = "是"; //是否流程
                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Value = "否"; //是否流程
                }

                //MessageBox.Show(pr2[i].PROCESS_NAME);
                //dataGridView1.Rows[i].Cells[1].Value = caseNames[i]
            }

            //隐藏所有PROCESS表中列
            dataGridView1.Columns["PROC_ID"].Visible = false;
            dataGridView1.Columns["BUSIESS_ID"].Visible = false;
            dataGridView1.Columns["PROCESS_NAME"].Visible = false;
            dataGridView1.Columns["EXECUTE_TIME"].Visible = false;
            dataGridView1.Columns["PRE_LENGTH"].Visible = false;
            dataGridView1.Columns["PRE_NO"].Visible = false;
            dataGridView1.Columns["CURNO"].Visible = false;
            dataGridView1.Columns["PROCESS_DESC"].Visible = false;
            dataGridView1.Columns["PROC_ENTITY"].Visible = false;
            dataGridView1.Columns["ISVALID"].Visible = false;
            dataGridView1.Columns["ISFLOW"].Visible = false;
            dataGridView1.Columns["PSORTNUM"].Visible = false;
            dataGridView1.Columns["BUSRULENAME"].Visible = false;
            dataGridView1.Columns["BUSSTATELIST"].Visible = false;
            dataGridView1.Columns["PRIORITY"].Visible = false;
            dataGridView1.Columns["CASEFORM"].Visible = false;
            dataGridView1.Columns["APPNAME"].Visible = false;
            dataGridView1.Columns["PROC_CODE"].Visible = false;
            dataGridView1.Columns["CODERULE"].Visible = false;
        }

        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //读取C:\UserLoginInfo文件中的信息
            string path = @"C:\UserLoginInfo";
            XElement root = XElement.Load(path);
            string IP = root.Element("Category").Element("IP").Value;
            string Sid = root.Element("Category").Element("Sid").Value;
            string userName = root.Element("Category").Element("userName").Value;
            string passWord = root.Element("Category").Element("passWord").Value;

            SystemHandler.Instance.Estateconnectionstring = string.Format(SystemHandler.commonOracleDataBaseConnectionStr1, IP, Sid, userName, passWord);
            BUSIESS rt = SystemHandler.Instance.EstateContext.GetEntity<BUSIESS>("BUSIESS_NAME", treeView1.SelectedNode.Text);
            
            
          // MessageBox.Show(rt.BUSIESS_NAME);
           // dataGridView1.DataSource = rt;
           
          //显示数据方法
           if(rt != null)
           {
               if (treeView1.SelectedNode == null)
               {
                   MessageBox.Show("不存在该节点");
               }
               else
               {
                   if (treeView1.SelectedNode.Text == "更正登记")
                   {
                       //PROCESS pr = SystemHandler.Instance.EstateContext.GetEntity<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       //int m  = pr2.Count; //获取长度
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);


                   }
                   else if (treeView1.SelectedNode.Text == "数据管理")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "首次登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "转移登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "变更登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "查封登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "异议登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "预告登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "其它登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
                   else if (treeView1.SelectedNode.Text == "注销登记")
                   {
                       IList<PROCESS> pr2 = SystemHandler.Instance.EstateContext.GetList<PROCESS>("BUSIESS_ID", rt.BUSIESS_ID);
                       dataGridView1.DataSource = pr2;
                       Print_Process(pr2, dataGridView1);
                   }
               }
           }
           else
           {
               //MessageBox.Show("不存在改业务类型");
           }


            

        }

      

        private void dataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
            { //如果用户点击表格
                button1.Visible = true; //按钮可见
               int procid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
              // MessageBox.Show(procid.ToString());
               PROCPRESET pr = SystemHandler.Instance.EstateContext.GetEntity<PROCPRESET>("PROC_ID", procid);
               currentProcid = Convert.ToString(procid);
                if(pr != null){
                    // MessageBox.Show(pr.CHEOPINION);
                    currentCheopinion = pr.CHEOPINION;
                    currentCheopinion2 = pr.CHEOPINION2;
                    currentCheopinion3 = pr.CHEOPINION3;
                    currentCheopinion4 = pr.CHEOPINION4;
                    currentAudopinion = pr.AUDOPINION;
                    currentApropinion = pr.APROPINION;
                }
                else
                {
                    currentCheopinion = "";
                    currentCheopinion = "";
                    currentCheopinion2 = "";
                    currentCheopinion3 = "";
                    currentCheopinion4 = "";
                    currentAudopinion = "";
                    currentApropinion = "";
                }
                

            }
            //currentCellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //currentCellValue = dataGridView1.CurrentCell.Value.ToString();
           
        }

          private void button1_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            myForm.richTextBox1.Text = currentCheopinion;
            myForm.richTextBox2.Text = currentCheopinion2;
            myForm.richTextBox3.Text = currentCheopinion3;
            myForm.richTextBox4.Text = currentCheopinion4;
            myForm.richTextBox5.Text = currentAudopinion;
            myForm.richTextBox6.Text = currentApropinion;
            
            myForm.ShowDialog(); 
        }

          private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
          {

          }

    }


}
