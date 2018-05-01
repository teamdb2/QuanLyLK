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
                                  CheckBox chkGioiTinh,
                                  DateTimePicker dtpNgaySinh,
                                  ComboBox cboChucVu,
                                  DateTimePicker dtpNgayVaoLam
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

            chkGioiTinh.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "GIOITINH", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = (string)e.Value == "F";
            };
            chkGioiTinh.DataBindings.Add(gt);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", bS, "NGAYSINH", false, DataSourceUpdateMode.Never);

            cboChucVu.DataBindings.Clear();
            cboChucVu.DataBindings.Add("SelectedValue", bS, "MACV", false, DataSourceUpdateMode.Never);



            dtpNgayVaoLam.DataBindings.Clear();
            dtpNgayVaoLam.DataBindings.Add("Value", bS, "NGAYVAOLAM", false, DataSourceUpdateMode.Never);

           

            bN.BindingSource = bS;
            dGV.DataSource = bS;
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