using CYQ.Data;
using CYQ.Data.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace TestPaging
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;


        private void Form1_Load(object sender, EventArgs e)
        {
  
            pagerControl1.DrawControl(GetCustomersInfo());//启动界面，一开始就显示出页数、条数、当前页等。
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);

        }
        /// <summary>  
        /// 页数变化时调用绑定数据方法  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            GetCustomersInfo();
        }  

        private void pagerControl1_Load(object sender, EventArgs e)
        {



        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }





        public int GetCustomersInfo()
        {

            //获取App.config中数据库连接信息
            string connectionStringconn2 = ConfigurationManager.ConnectionStrings["TestPaging.Properties.Settings.ConnectionString"].ConnectionString;
            //MessageBox.Show(conn2);

            conn = new SqlConnection(connectionStringconn2);
            //conn = new SqlConnection("server=KONQ7UUOMWZI70N; database=NORTHWND; uid=maco; pwd=123"); //连接数据库
            conn.Open();
            //SqlCommand cmd = new SqlCommand("select * from [NORTHWND].[dbo].[Customers]", conn);
           // SqlCommand cmd = new SqlCommand("prcPageResult", conn);
            SqlCommand cmd = new SqlCommand("pro_page", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
           // cmd.CommandText = "proc_get_customers"; //存储过程名称
            //"存储过程的参数名。如：@a", "数据值。4"
            //MessageBox.Show(pagerControl1.PageSize.ToString());
            SqlParameter parm = new SqlParameter("@startIndex", 1 + pagerControl1.PageSize * (pagerControl1.PageIndex-1));
            SqlParameter parm1 = new SqlParameter("@endIndex", pagerControl1.PageIndex + (pagerControl1.PageSize - 1) * pagerControl1.PageIndex);

            

            cmd.Parameters.Add(parm);
            cmd.Parameters.Add(parm1);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataSet ds = new DataSet();

            sda.Fill(ds);


            dataGridView1.DataSource = ds.Tables[1];
            //MessageBox.Show(pagerControl1.PageSize.ToString()); 
            //MessageBox.Show(ds.Tables[0].Rows[0][0].ToString());//91记录条数
           // MessageBox.Show(dataGridView1.RowCount.ToString());
            pagerControl1.RecordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = ds.Tables[1].Rows[i][0];//ID
                dataGridView1.Rows[i].Cells[1].Value = ds.Tables[1].Rows[i][1];//CustomerID
                dataGridView1.Rows[i].Cells[2].Value = ds.Tables[1].Rows[i][2];//CompanyName
                dataGridView1.Rows[i].Cells[3].Value = ds.Tables[1].Rows[i][3];//ContactName
                dataGridView1.Rows[i].Cells[4].Value = ds.Tables[1].Rows[i][4];//ContactTitle
                dataGridView1.Rows[i].Cells[5].Value = ds.Tables[1].Rows[i][5];//Address 
                dataGridView1.Rows[i].Cells[6].Value = ds.Tables[1].Rows[i][6];//City
                dataGridView1.Rows[i].Cells[7].Value = ds.Tables[1].Rows[i][9];//Country



            }
            conn.Close();
            return pagerControl1.RecordCount;
           
        }

        
    }
}
