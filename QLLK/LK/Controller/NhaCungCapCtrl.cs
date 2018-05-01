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
    class NhaCungCapCtrl
    {
        NhaCungCapData data = new NhaCungCapData();

        public void HienThiVaoDGV(DataGridView dGV, BindingNavigator bN, TextBox txtMaNCC, TextBox  txtTenNCC, TextBox txtDiaChiNCC)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", bS, "MANCC", false, DataSourceUpdateMode.Never);

            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", bS, "TENNCC", false, DataSourceUpdateMode.Never);

            txtDiaChiNCC.DataBindings.Clear();
            txtDiaChiNCC.DataBindings.Add("Text", bS, "DIACHI", false, DataSourceUpdateMode.Never);


            bN.BindingSource = bS;
            dGV.DataSource = bS;
            dGV.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dGV.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dGV.Columns[2].HeaderText = "Địa Chỉ Nhà Cung Cấp";
            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        public void HienThiVaoComboBox(ComboBox cboNhaCungCap)
        {
            cboNhaCungCap.DataSource = data.DanhSach();
            cboNhaCungCap.DisplayMember = "TENNCC";
            cboNhaCungCap.ValueMember = "MANCC";
        }

        public void Them(NhaCungCapInfo ncc)
        {
            data.Them(ncc);
        }

        public void Sua(NhaCungCapInfo ncc, string maNCC)
        {
            data.Sua(ncc, maNCC);
        }

        public void Xoa(string maNCC)
        {
            data.Xoa(maNCC);
        }
    }
}
