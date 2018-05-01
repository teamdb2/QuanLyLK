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
            DB2Command cmd = new DB2Command("SELECT N.*, CV.TENCV FROM LK.NHANVIEN N, LK.CHUCVU CV WHERE N.MACV = CV.MACV");
            data.Load(cmd);
            return data;
        }

        public void Them(NhanVienInfo nv)
        {
            DB2Command cmd = new DB2Command("INSERT INTO LK.NHANVIEN(MANV, TENNHANVIEN, EMAIL, GIOITINH, NGAYSINH, MACV, NGAYVAOLAM) VALUES('" + nv.MaNV + "', '" + nv.TenNV + "', '" + nv.Email + "', '" + nv.GioiTinh + "', '" + nv.NgaySinh + "', '" + nv.NgayVaoLam + "', '" + nv.Chucvu.MaCV + "')");
            data.Load(cmd);
        }

        public void Sua(NhanVienInfo nv, string maNV)
        {
            DB2Command cmd = new DB2Command("UPDATE LK.NHANVIEN SET MANV = '" + nv.MaNV + "', TENNHANVIEN = '" + nv.TenNV + "',EMAIL='"+nv.Email+ "', GIOITINH = '" + nv.GioiTinh + "', NGAYSINH = '" + nv.NgaySinh + "',, MACV = '" + nv.Chucvu.MaCV + "', NGAYVAOLAM = '" + nv.NgayVaoLam + "' WHERE MANV = '" + maNV + "'");
            data.Load(cmd);
        }

        public void Xoa(string maNV)
        {
            DB2Command cmd = new DB2Command("DELETE FROM LK.NHANVIEN WHERE MANV = '" + maNV + "'");
            data.Load(cmd);
        }
    }
}