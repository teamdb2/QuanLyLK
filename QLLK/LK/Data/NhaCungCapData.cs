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
    class NhaCungCapData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            DB2Command cmd = new DB2Command("SELECT * FROM QLLK1.NHACUNGCAP");
            data.Load(cmd);
            return data;
        }

        public void Them(NhaCungCapInfo ncc)
        {
            DB2Command cmd = new DB2Command("INSERT INTO QLLK1.NHACUNGCAP(MANCC, TENNCC, DIACHI) VALUES('" + ncc.MaNCC + "', '" + ncc.TenNCC + "','"+ncc.DiaChiNCC+"')");
            data.Load(cmd);
        }

        public void Sua(NhaCungCapInfo ncc, string maNCC)
        {
            DB2Command cmd = new DB2Command("UPDATE QLLK1.NHACUNGCAP SET MANCC = '" + ncc.MaNCC + "', TENNCC = '" + ncc.TenNCC + "',DIACHI='" + ncc.DiaChiNCC + "' WHERE MANCC = '" + maNCC + "'");
            data.Load(cmd);
        }

        public void Xoa(string maNCC)
        {
            DB2Command cmd = new DB2Command("DELETE FROM QLLK1.NHACUNGCAP WHERE MANCC = '" + maNCC + "'");
            data.Load(cmd);
        }
    }
}
