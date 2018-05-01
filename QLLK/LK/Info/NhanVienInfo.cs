using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LK.Info
{
    class NhanVienInfo
    {
        private string maNV;
        private string tenNV;
        private string ngaySinh;
        private string email;
        private string gioiTinh;
        private string diaChi;
        private string ngayVaoLam;
        private ChucVuInfo chucvu = new ChucVuInfo();

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email { get => email; set => email = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public ChucVuInfo Chucvu { get => chucvu; set => chucvu = value; }
    }
}