using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LK.Info;
using IBM.Data.DB2;

namespace LK.Data
{
    class PhieuBaoHanhData
    {
        Connect data = new Connect();

        public DataTable DanhSach()
        {
            DB2Command cmd = new DB2Command("SELECT P.*, N.TENLINHKIEN FROM QLLK5.PHIEUBAOHANH P, QLLK5.LINHKIEN N WHERE N.MALINHKIEN = P.MALINHKIEN");
            data.Load(cmd);
            return data;
        }

        public void Them(PhieuBaoHanhInfo pbh)
        {
            DB2Command cmd = new DB2Command("INSERT INTO QLLK5.PHIEUBAOHANH(MAPBH, MALINHKIEN, TENKH,THOIGIANBAOHANH, NGAYMUA, NGAYHETHAN) VALUES('" + pbh.MaPBH + "', '" + pbh.Linhkien.MaLK+ "','"+pbh.TenKH+"','" +pbh.TgBaoHanh+ "','"+pbh.NgayMua+"','"+pbh.NgayHetHan+"')");
            data.Load(cmd);
        }

        public void Sua(PhieuBaoHanhInfo pbh, string maPBH)
        {
            DB2Command cmd = new DB2Command("UPDATE QLLK5.PHIEUBAOHANH SET MAPBH = '" + pbh.MaPBH + "', MALINHKIEN = '" + pbh.Linhkien.MaLK + "',TENKH='" + pbh.TenKH + "',THOIGIANBAOHANH='"+pbh.TgBaoHanh+"',NGAYMUA='"+pbh.NgayMua+"',NGAYHETHAN='"+pbh.NgayHetHan+"' WHERE MAPBH = '" + maPBH + "'");
            data.Load(cmd);
        }

        public void Xoa(string maPBH)
        {
            DB2Command cmd = new DB2Command("DELETE FROM QLLK5.PHIEUBAOHANH WHERE MAPBH = '" + maPBH + "'");
            data.Load(cmd);
        }
    }
}
