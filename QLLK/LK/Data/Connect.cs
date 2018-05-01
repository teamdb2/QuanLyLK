using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using IBM.Data.DB2;

namespace LK.Data
{
    class Connect : DataTable
    {
        private static DB2Connection db2Conn;
        private static string connString = "Database=LK;Server=127.0.0.1:50000;UserID=db2admin;Password=123456";
        private DB2Command db2Cmd;
        private DB2DataAdapter db2DataAdapter;

        public Connect()
        {

        }

        public static bool OpenConnect()
        {
            try
            {
                if(db2Conn == null)
                    db2Conn = new DB2Connection(connString);
                if (db2Conn.State == ConnectionState.Closed)
                    db2Conn.Open();
                return true;
            }
            catch(DB2Exception e)
            {
                MessageBox.Show("Không thể kết nối tới server!\nLỗi: " + e.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db2Conn.Close();
                return false;
            }
        }

        public void Load(DB2Command cmd)
        {
            if (db2Conn == null || db2Conn.State == ConnectionState.Closed)
            {
                db2Conn = new DB2Connection(connString);
                db2Conn.Open();
            }
            db2Cmd = cmd;
            try
            {
                db2Cmd.Connection = db2Conn;

                db2DataAdapter = new DB2DataAdapter();
                db2DataAdapter.SelectCommand = db2Cmd;

                this.Clear();
                db2DataAdapter.Fill(this);
            }
            catch (DB2Exception e)
            {
                MessageBox.Show("Không thể thực thi câu lệnh SQL này!\nLỗi: " + e.Message, "Lỗi truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
	}
}
