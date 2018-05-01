using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LK.Data;
using LK.Info;
using IBM.Data.DB2;

namespace LK.Controller
{
    class PhieuBaoHanhCtrl
    {
        PhieuBaoHanhData data = new PhieuBaoHanhData();

        public void HienThiVaoDGV(DataGridView dGV,
                                  BindingNavigator bN,
                                  TextBox txtMaPBH,
                                  ComboBox cboTenLinhKien,
                                  TextBox txtTenKhachHang,
                                  TextBox txtThoiGianBH,
                                  DateTimePicker dtNgayMua,
                                  DateTimePicker dtNgayHetHan)
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DanhSach();

            txtMaPBH.DataBindings.Clear();
            txtMaPBH.DataBindings.Add("Text", bS, "MAPBH", false, DataSourceUpdateMode.Never);

            cboTenLinhKien.DataBindings.Clear();
            cboTenLinhKien.DataBindings.Add("SelectedValue", bS, "MALINHKIEN", false, DataSourceUpdateMode.Never);

            txtTenKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Add("Text", bS, "TENKH", false, DataSourceUpdateMode.Never);

            txtThoiGianBH.DataBindings.Clear();
            txtThoiGianBH.DataBindings.Add("Text", bS, "THOIGIANBAOHANH", false, DataSourceUpdateMode.Never);



            dtNgayMua.DataBindings.Clear();
            dtNgayMua.DataBindings.Add("Value", bS, "NGAYMUA", false, DataSourceUpdateMode.Never);

            
            dtNgayHetHan.DataBindings.Clear();
            dtNgayHetHan.DataBindings.Add("Text", bS, "NGAYHETHAN", false, DataSourceUpdateMode.Never);
            
            bN.BindingSource = bS;
            dGV.DataSource = bS;

            /*dGV.Columns[0].HeaderText = "Mã Phiếu Bảo Hành";
            dGV.Columns[1].HeaderText = "Tên Linh Kiện";
            dGV.Columns[2].HeaderText = "Tên Khách Hàng";
            dGV.Columns[3].HeaderText = "Thời Gian Bảo Hành";
            dGV.Columns[4].HeaderText = "Ngày Mua";
            dGV.Columns[5].HeaderText = "Ngày Hết Hạn";*/
            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void HienThiVaoComboBox(ComboBox cboPhieuBaoHanh)
        {
            cboPhieuBaoHanh.DataSource = data.DanhSach();
            cboPhieuBaoHanh.ValueMember = "MAPBH";
            
        }
        
       

        public void Them(PhieuBaoHanhInfo pbh)
        {
            data.Them(pbh);
        }

        public void Sua(PhieuBaoHanhInfo pbh, string maPBH)
        {
            data.Sua(pbh, maPBH);
        }

        public void Xoa(string maPBH)
        {
            data.Xoa(maPBH);
        }
    }
}
