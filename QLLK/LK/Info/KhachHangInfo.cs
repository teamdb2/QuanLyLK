using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LK.Info
{
    class KhachHangInfo
    {
        private string maKH;
        private string tenKH;
        private string gioiTinh;
        private string diaChi;
        private int sdt;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int Sdt { get => sdt; set => sdt = value; }
    }
}
