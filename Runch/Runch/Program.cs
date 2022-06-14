using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runch.Data;

namespace Runch
{
    internal static class Program
    {
        private static DBUtil db = new DBUtil();
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            db.Connect();

            new LoginForm().Show();
            Application.Run();
        }
    }
}
