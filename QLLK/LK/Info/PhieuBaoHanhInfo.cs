using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LK.Info;

namespace LK.Info
{
    class PhieuBaoHanhInfo
    {
        private string maPBH;
        private LinhKienInfo linhkien = new LinhKienInfo();
        private string tenKH;
        private int tgBaoHanh;
        private string ngayMua;
        private string ngayHetHan;

        public string MaPBH { get => maPBH; set => maPBH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int TgBaoHanh { get => tgBaoHanh; set => tgBaoHanh = value; }
        public string NgayMua { get => ngayMua; set => ngayMua = value; }
        public string NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        internal LinhKienInfo Linhkien { get => linhkien; set => linhkien = value; }
    }

       
}
