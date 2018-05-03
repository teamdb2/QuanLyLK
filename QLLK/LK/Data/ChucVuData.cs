using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LK.Info;
using IBM.Data.DB2;

namespace LK.Data
{
    class ChucVuData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            DB2Command cmd = new DB2Command("SELECT * FROM QLLK5.CHUCVU");
            data.Load(cmd);
            return data;
        }

        public void Them(ChucVuInfo cv)
        {
            DB2Command cmd = new DB2Command("INSERT INTO QLLK5.CHUCVU(MACV, TENCV) VALUES('" + cv.MaCV + "', '" + cv.TenCV + "')");
            data.Load(cmd);
        }

        public void Sua(ChucVuInfo cv, string maCV)
        {
            DB2Command cmd = new DB2Command("UPDATE QLLK5.CHUCVU SET MACV = '" + cv.MaCV + "', TENCV = '" + cv.TenCV + "' WHERE MACV = '" + maCV + "'");
            data.Load(cmd);
        }

        public void Xoa(string maCV)
        {
            DB2Command cmd = new DB2Command("DELETE FROM QLLK5.CHUCVU WHERE MACV = '" + maCV + "'");
            data.Load(cmd);
        }
    }
}
