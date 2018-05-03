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
    class NhanVienCtrl
    {
        NhanVienData data = new NhanVienData();

        public void HienThiVaoDGV(DataGridView dGV, 
                                  BindingNavigator bN, 
                                  TextBox txtMaNV, 
                                  TextBox txtTenNV,
                                  TextBox txtEmai,
                                  CheckBox chkGioiTinh,
                                  ComboBox cboChucVu, 
                                  TextBox txtDiaChi)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bS, "MANV", false, DataSourceUpdateMode.Never);

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", bS, "TENNHANVIEN", false, DataSourceUpdateMode.Never);

            txtEmai.DataBindings.Clear();
            txtEmai.DataBindings.Add("Text", bS, "EMAIL", false, DataSourceUpdateMode.Never);

           /* chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "GIOITINH", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "F";
            };
            chkGioiTinh.DataBindings.Add(gt);*/


            cboChucVu.DataBindings.Clear();
            cboChucVu.DataBindings.Add("SelectedValue", bS, "MACV", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "DIACHI", false, DataSourceUpdateMode.Never);


            
            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboNhanVien)
        {
            cboNhanVien.DataSource = data.DanhSach();
            cboNhanVien.DisplayMember = "TENNV";
            cboNhanVien.ValueMember = "MANV";
        }

        public void Them(NhanVienInfo nv)
        {
            data.Them(nv);
        }

        public void Sua(NhanVienInfo nv, string maNV)
        {
            data.Sua(nv, maNV);
        }

        public void Xoa(string maNV)
        {
            data.Xoa(maNV);
        }
    }
}
