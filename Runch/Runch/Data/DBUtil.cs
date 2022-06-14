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
        private OleDbConnection conn;
        private OleDbCommand cmd;

        private Notification box;

        public OleDbConnection Connect()
        {
            string connStr = string.Format("Provider=OraOLEDB.Oracle;" +
                                            "OLEDB.NET=true;" +
                                            "PLSQLRSet=true;" +
                                            "Data Source=orcl;" +
                                            "User Id=runch;" +
                                            "Password=java1234;");
            try
            {
                conn = new OleDbConnection(connStr);
                conn.Open();
                return conn;
            }
            catch
            {
                box.DisplayWarning("접속");
                return null;
            }
        }

        public void Add(string sql)
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

    }
}
