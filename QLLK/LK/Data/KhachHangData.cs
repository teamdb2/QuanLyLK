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
    class KhachHangData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            DB2Command cmd = new DB2Command("SELECT * FROM QLLK5.KHACHHANG");
            data.Load(cmd);
            return data;
        }

        public void Them(KhachHangInfo kh)
        {
            DB2Command cmd = new DB2Command("INSERT INTO QLLK5.KHACHHANG(MAKH, TENKHACHHNAG, GIOITINH, DIACHI, SDT) VALUES('" + kh.MaKH + "', '" + kh.TenKH + "','" + kh.GioiTinh + "','" + kh.DiaChi + "','"+kh.Sdt+"')");
            data.Load(cmd);
        }

        public void Sua(KhachHangInfo kh, string maKH)
        {
            DB2Command cmd = new DB2Command("UPDATE QLLK5.KHACHHANG SET MAKH = '" + kh.MaKH + "', TENKHACHHNAG = '" + kh.TenKH + "', GIOITINH='"+kh.GioiTinh+"', DIACHI='"+kh.DiaChi+"',SDT='"+kh.Sdt+"' WHERE MAKH = '" + maKH + "'");
            data.Load(cmd);
        }

        public void Xoa(string maKH)
        {
            DB2Command cmd = new DB2Command("DELETE FROM QLLK5.KHACHHANG WHERE MAKH = '" + maKH + "'");
            data.Load(cmd);
        }
    }
}
