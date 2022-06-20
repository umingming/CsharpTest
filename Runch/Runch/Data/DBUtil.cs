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
        private static readonly DBUtil _instance = new DBUtil();

        private OleDbConnection conn;
        //private OleDbCommand cmd;

        private Notification box = new Notification();

        private DBUtil()
        {
            //this.Open();
        }

        public static DBUtil This
        {
            get { return _instance; }
        }

        //private void Open()
        //{
        //    string connStr = string.Format("Provider=OraOLEDB.Oracle;" +
        //                                    "OLEDB.NET=true;" +
        //                                    "PLSQLRSet=true;" +
        //                                    "Data Source=orcl;" +
        //                                    "User Id=runch;" +
        //                                    "Password=java1234;");
        //    try
        //    {
        //        conn = new OleDbConnection(connStr);
        //    }
        //    catch
        //    {
        //        box.DisplayWarning("접속");
        //    }
        //}

        public OleDbConnection Connect()
        {
            try
            {
                string connStr = string.Format("Provider=OraOLEDB.Oracle;" +
                                                "OLEDB.NET=true;" +
                                                "PLSQLRSet=true;" +
                                                "Data Source=orcl;" +
                                                "User Id=runch;" +
                                                "Password=java1234;");

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

        //public void Add(string sql)
        //{
        //    cmd.CommandText = sql;
        //    cmd.ExecuteNonQuery();
        //}

    }
}
