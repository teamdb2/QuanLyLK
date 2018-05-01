using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LK.Data;
using LK.Info;

namespace LK.Controller
{
    class LinhKienCtrl
    {
        LinhKienData data = new LinhKienData();
        public void HienThiVaoDGV(DataGridView dGV,
                                  BindingNavigator bN,
                                  TextBox txtMaLK,
                                  TextBox txtTenLK,
                                  TextBox txtNhanHieu,
                                  TextBox txtTSKyThuat,
                                  TextBox txtGiaBan,
                                  TextBox txtGiaNhap)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaLK.DataBindings.Clear();
            txtMaLK.DataBindings.Add("Text", bS, "MALINHKIEN", false, DataSourceUpdateMode.Never);

            txtTenLK.DataBindings.Clear();
            txtTenLK.DataBindings.Add("Text", bS, "TENLINHKIEN", false, DataSourceUpdateMode.Never);

            txtNhanHieu.DataBindings.Clear();
            txtNhanHieu.DataBindings.Add("Text", bS, "NHANHIEU", false, DataSourceUpdateMode.Never);

            txtTSKyThuat.DataBindings.Clear();
            txtTSKyThuat.DataBindings.Add("Text", bS, "THONGSOKYTHUAT", false, DataSourceUpdateMode.Never);

            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", bS, "GIABAN", false, DataSourceUpdateMode.Never);

            txtGiaNhap.DataBindings.Clear();
            txtGiaNhap.DataBindings.Add("Text", bS, "GIANHAP", false, DataSourceUpdateMode.Never);



            bN.BindingSource = bS;
            dGV.DataSource = bS;
            dGV.Columns[0].HeaderText = "Mã Linh Kiện";
            dGV.Columns[1].HeaderText = "Tên Linh Kiện";
            dGV.Columns[2].HeaderText = "Nhãn Hiệu";
            dGV.Columns[3].HeaderText = "Thông Số Kỹ Thuật";
            dGV.Columns[4].HeaderText = "Giá Bán";
            dGV.Columns[5].HeaderText="Giá Nhập";
            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void HienThiVaoComboBox(ComboBox cboLinhKien)
        {
            cboLinhKien.DataSource = data.DanhSach();
            cboLinhKien.DisplayMember = "TENLINHKIEN";
            cboLinhKien.ValueMember = "MALINHKIEN";
        }

        public void Them(LinhKienInfo lk)
        {
            data.Them(lk);
        }

        public void Sua(LinhKienInfo lk, string maLK)
        {
            data.Sua(lk, maLK);
        }

        public void Xoa(string maLK)
        {
            data.Xoa(maLK);
        }
    }
}
