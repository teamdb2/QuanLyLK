using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LK.Info;

namespace LK.Info
{
    class TaiKhoanInfo
    {
        private int id;
        private NhanVienInfo nhanVien = new NhanVienInfo();
        private string matKhau;
        private int quyen;

        public int Id { get => id; set => id = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int Quyen { get => quyen; set => quyen = value; }
        internal NhanVienInfo NhanVien { get => nhanVien; set => nhanVien = value; }
    }
}
