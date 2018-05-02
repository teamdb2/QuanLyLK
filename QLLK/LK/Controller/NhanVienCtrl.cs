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
                                  TextBox txtEmail,
                                  ComboBox cboChucVu
                                  )
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bS, "MANV", false, DataSourceUpdateMode.Never);

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", bS, "TENNHANVIEN", false, DataSourceUpdateMode.Never);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bS, "EMAIL", false, DataSourceUpdateMode.Never);

            cboChucVu.DataBindings.Clear();
            cboChucVu.DataBindings.Add("SelectedValue", bS, "MACV", false, DataSourceUpdateMode.Never);


            bN.BindingSource = bS;
            dGV.DataSource = bS;
            dGV.Columns[0].HeaderText = "Mã nhân viên";
            dGV.Columns[1].HeaderText = "Tên nhân viên";
            dGV.Columns[2].HeaderText = "Email";
            dGV.Columns[3].HeaderText = "Chức vụ";


            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void HienThiVaoComboBox(ComboBox cboNhanVien)
        {
            cboNhanVien.DataSource = data.DanhSach();
            cboNhanVien.DisplayMember = "TENNHANVIEN";
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