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
    class LinhKienData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            DB2Command cmd = new DB2Command("SELECT * FROM LK.LINHKIEN");
            data.Load(cmd);
            return data;
        }

        public void Them(LinhKienInfo lk)
        {
            string query = string.Format(@"INSERT INTO LK.LINHKIEN(MALINHKIEN,TENLINHKIEN,NHANHIEU,THONGSOKYTHUAT,GIABAN,GIANHAP) 
                                            VALUES('{0}','{1}','{2}','{3}',{4},{5})",lk.MaLK,lk.TenLK,lk.NhanHieu,lk.ThongSoKyThuat,lk.GiaBan,lk.GiaNhap);
            DB2Command cmd = new DB2Command(query);
            data.Load(cmd);
        }

        public void Sua(LinhKienInfo lk, string maLK)
        {
            string query = string.Format(@"UPDATE LK.LINHKIEN SET TENLINHKIEN='{1}',NHANHIEU='{2}',THONGSOKYTHUAT='{3}',GIABAN={4},GIANHAP={5} WHERE MALINHKIEN='{0}'", lk.MaLK, lk.TenLK, lk.NhanHieu, lk.ThongSoKyThuat, lk.GiaNhap, lk.GiaNhap);
                                           
            DB2Command cmd = new DB2Command(query);

            data.Load(cmd);
        }

        public void Xoa(string maLK)
        {
            string query=string.Format(@"DELETE FROM LK.LINHKIEN WHERE MALINHKIEN='{0}'",maLK);
            DB2Command cmd = new DB2Command(query);
            data.Load(cmd);
        }
    }
}
