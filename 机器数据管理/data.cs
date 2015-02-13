using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace 机器数据管理
{
    class data
    {
        public string conStr;
        private static OleDbConnection DbConn = null;

        public data(string str)
        {
            conStr = str;
            string dsn = "provider=microsoft.jet.oledb.4.0;data source=" + str;
            DbConn = new OleDbConnection(dsn);//定义新的数据连接控件并初始化
        }
        public data()
        {
            string str = Application.StartupPath;

            conStr = str + "\\data.mdb";
            string dsn = "provider=microsoft.jet.oledb.4.0;data source=" + conStr;
            DbConn = new OleDbConnection(dsn);//定义新的数据连接控件并初始化
        }

        public DataTable getTable(string strSql)
        {
            DataTable dt = new DataTable();
            //定义并初始化适配器
            OleDbDataAdapter adapter = new OleDbDataAdapter(strSql, DbConn);
            try
            {
                DbConn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ee)
            {
                DbConn.Close();
                adapter.Dispose();
                return null;
            }
            DbConn.Close();
            return dt;
        }

        public void readData(string tableName, ref DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dt = getTable("Select * from " + tableName);
            dgv.DataSource = dt;
        }

        public string execSql(string strSql)
        {
            OleDbCommand comm = new OleDbCommand(strSql, DbConn);
            try
            {
                DbConn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                DbConn.Close();
                comm.Dispose();
                MessageBox.Show(ee.Message);
                return ee.Message;
            }
            DbConn.Close();
            return "OK";
        }
    }
}
