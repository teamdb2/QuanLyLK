using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LK.Info
{
    class LinhKienInfo
    {
        private string maLK;
        private string tenLK;
        private string nhanHieu;
        private string thongSoKyThuat;
        private int giaBan;
        private int giaNhap;

        public string MaLK { get => maLK; set => maLK = value; }
        public string TenLK { get => tenLK; set => tenLK = value; }
        public string NhanHieu { get => nhanHieu; set => nhanHieu = value; }
        public string ThongSoKyThuat { get => thongSoKyThuat; set => thongSoKyThuat = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
    }
}
