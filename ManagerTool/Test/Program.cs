using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DZTD());
           
            Form3 form3 = new Form3();
            form3.ShowDialog();
            if(form3.DialogResult == DialogResult.OK)
            {
                //Application.Run(new DZTD());
                Application.Run(new Form1());

            }
            else
            {
                return;
            }
        }
    }
}
