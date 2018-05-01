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
    class ChucVuCtrl
    {
        ChucVuData data = new ChucVuData();

        public void HienThiVaoDGV(DataGridView dGV, BindingNavigator bN, TextBox txtMaCV, TextBox txtTenCV)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaCV.DataBindings.Clear();
            txtMaCV.DataBindings.Add("Text", bS, "MACV", false, DataSourceUpdateMode.Never);

            txtTenCV.DataBindings.Clear();
            txtTenCV.DataBindings.Add("Text", bS, "TENCV", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
            dGV.Columns[0].HeaderText = "Mã chức vụ";
            dGV.Columns[1].HeaderText = "Tên chức vụ";


            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

        }

        public void HienThiVaoComboBox(ComboBox cboChucVu)
        {
            cboChucVu.DataSource = data.DanhSach();
            cboChucVu.DisplayMember = "TENCV";
            cboChucVu.ValueMember = "MACV";
        }

        public void Them(ChucVuInfo cv)
        {
            data.Them(cv);
        }

        public void Sua(ChucVuInfo cv, string maCV)
        {
            data.Sua(cv, maCV);
        }

        public void Xoa(string maCV)
        {
            data.Xoa(maCV);
        }
    }
}
