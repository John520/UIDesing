using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIDesing.dataSql;
using UIDesing.dataSql.data;
namespace UIDesing
{
    static class Program
    {
        //常量定义区域
        public static Form1 form1 = null;

        //数据库工具定义
        //文件ID
        public static int fileId=0;
        //文件名
        public static String fileNmae = "";
       
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
