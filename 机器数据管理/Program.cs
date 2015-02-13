using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 机器数据管理
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static string username = "";
        public static string logintime = "";
        public static string root = "";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
