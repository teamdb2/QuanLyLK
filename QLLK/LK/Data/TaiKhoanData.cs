using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IBM.Data.DB2;
using LK.Info;

namespace LK.Data
{
    class TaiKhoanData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            DB2Command cmd = new DB2Command("SELECT T.*, N.TENNHANVIEN FROM QLLK5.TAIKHOAN T, QLLK5.NHANVIEN N WHERE T.MANV = N.MANV");
            data.Load(cmd);
            return data;
        }

        public DataTable ChiTiet(string maNV, string matKhau)
        {
            DB2Command cmd = new DB2Command("SELECT T.*, N.TENNHANVIEN FROM QLLK5.TAIKHOAN T, QLLK5.NHANVIEN N WHERE T.MANV = N.MANV AND T.MANV = '" + maNV + "' AND T.MATKHAU = '" + matKhau + "'");
            data.Load(cmd);
            return data;
        }

        public void Them(TaiKhoanInfo tk)
        {
            DB2Command cmd = new DB2Command("INSERT INTO QLLK5.TAIKHOAN(MANV, MATKHAU, QUYEN) VALUES('" + tk.NhanVien.MaNV + "', '" + tk.MatKhau + "', " + tk.Quyen + ")");
            data.Load(cmd);
        }

        public void Sua(TaiKhoanInfo tk)
        {
            DB2Command cmd = new DB2Command("UPDATE QLLK5.TAIKHOAN SET MANV = '" + tk.NhanVien.MaNV + "', MATKHAU = '" + tk.MatKhau + "', QUYEN = " + tk.Quyen + " WHERE ID = " + tk.Id);
            data.Load(cmd);
        }

        public void Xoa(int id)
        {
            DB2Command cmd = new DB2Command("DELETE FROM QLLK5.TAIKHOAN WHERE ID = " + id);
            data.Load(cmd);
        }
    }
}
