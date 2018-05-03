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
    class NhanVienData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            DB2Command cmd = new DB2Command("SELECT N.*, C.TENCV FROM QLLK5.NHANVIEN N, QLLK5.CHUCVU C WHERE N.MACV = C.MACV");
            data.Load(cmd);
            return data;
        }

        public void Them(NhanVienInfo nv)
        {
            DB2Command cmd = new DB2Command("INSERT INTO QLLK5.NHANVIEN(MANV, TENNHANVIEN,EMAIL, GIOITINH, MACV,DIACHI) VALUES('" + nv.MaNV + "', '" + nv.TenNV + "','"+nv.Email+"', '" + nv.GioiTinh + "', '" + nv.Chucvu.MaCV+ "', '" + nv.DiaChi + "')");
            data.Load(cmd);
        }

        public void Sua(NhanVienInfo nv, string maNV)
        {
            DB2Command cmd = new DB2Command("UPDATE QLLK5.NHANVIEN SET MANV = '" + nv.MaNV + "', TENNHANVIEN = '" + nv.TenNV + "', EMAIL = '" + nv.Email + "', GIOITINH = '" + nv.GioiTinh + "','"+nv.Chucvu.MaCV+"', DIACHI = '" + nv.DiaChi + "' WHERE MANV = '" + maNV + "'");
            data.Load(cmd);
        }

        public void Xoa(string maNV)
        {
            DB2Command cmd = new DB2Command("DELETE FROM QLLK5.NHANVIEN WHERE MANV = '" + maNV + "'");
            data.Load(cmd);
        }
    }
}
