using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runch.Domain;

namespace Runch.Data
{
    internal class DBUtil
    {
        private OleDbConnection connection;
        private Notification box;

        public void Connect()
        {
            string connectionString = string.Format("Provider=OraOLEDB.Oracle;" +
            "OLEDB.NET=true;" +
            "PLSQLRSet=true;" +
            "Data Source=orcl;" +
            "User Id=runch;" +
            "Password=java1234;");

            try
            {
                connection = new OleDbConnection(connectionString);
                connection.Open();
            }
            catch
            {
                box.DisplayWarning("접속");
            }
        }
    }
}
