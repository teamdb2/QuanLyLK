using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LK.Info
{
    class NhanVienInfo
    {
        private string maNV;
        private string tenNV;   
        private string email;
 
        private ChucVuInfo chucvu = new ChucVuInfo();
     

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string Email { get => email; set => email = value; }
     
        public ChucVuInfo Chucvu { get => chucvu; set => chucvu = value; }
        
    }
}