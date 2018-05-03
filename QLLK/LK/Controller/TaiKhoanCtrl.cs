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
    class TaiKhoanCtrl
    {
        TaiKhoanData data = new TaiKhoanData();

        public void HienThiVaoDGV(DataGridView dGV, 
                                  BindingNavigator bN, 
                                  ComboBox cboNhanVien,
                                  ComboBox cboQuyenHan,
                                  TextBox txtMatKhau)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", bS, "MATKHAU", false, DataSourceUpdateMode.Never);

            cboNhanVien.DataBindings.Clear();
            cboNhanVien.DataBindings.Add("SelectedValue", bS, "MANV", false, DataSourceUpdateMode.Never);

            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add("SelectedIndex", bS, "QUYEN", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void Them(TaiKhoanInfo tk)
        {
            data.Them(tk);
        }

        public void Sua(TaiKhoanInfo tk)
        {
            data.Sua(tk);
        }

        public void Xoa(int id)
        {
            data.Xoa(id);
        }
    }
}
