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
    class KhachHangCtrl
    {
        KhachHangData data = new KhachHangData();

        public void HienThiVaoDGV(DataGridView dGV, BindingNavigator bN, TextBox txtMaKH, TextBox txtTenKH, CheckBox chkGioiTinh, TextBox txtDiaChi, TextBox txtSDT)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", bS, "MAKH", false, DataSourceUpdateMode.Never);

            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", bS, "TENKHACHHNAG", false, DataSourceUpdateMode.Never);

            chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "GIOITINH", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "F";
            };
            chkGioiTinh.DataBindings.Add(gt);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "DIACHI", false, DataSourceUpdateMode.Never);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bS, "SDT", false, DataSourceUpdateMode.Never);


            bN.BindingSource = bS;
            dGV.DataSource = bS;
            dGV.Columns[0].HeaderText = "Mã Khách Hàng";
            dGV.Columns[1].HeaderText = "Tên Khách Hàng";
            dGV.Columns[2].HeaderText = "Giới Tính";
            dGV.Columns[3].HeaderText = "Địa Chỉ";
            dGV.Columns[4].HeaderText = "Số Điện Thoại";


            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        public void HienThiVaoComboBox(ComboBox cboKhachHang)
        {
            cboKhachHang.DataSource = data.DanhSach();
            cboKhachHang.DisplayMember = "TENKH";
            cboKhachHang.ValueMember = "MAKH";
        }

        public void Them(KhachHangInfo kh)
        {
            data.Them(kh);
        }

        public void Sua(KhachHangInfo kh, string maKH)
        {
            data.Sua(kh, maKH);
        }

        public void Xoa(string maKH)
        {
            data.Xoa(maKH);
        }
    }
}
