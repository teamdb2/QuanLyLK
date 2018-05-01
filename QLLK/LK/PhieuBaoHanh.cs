using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LK.Controller;
using LK.Data;
using LK.Info;
using IBM.Data.DB2;

namespace LK
{
    public partial class PhieuBaoHanh : Form
    {
        private bool isThem = false;
        private string maPBH = ""; 
        private LinhKienCtrl lkCtrl = new LinhKienCtrl();
        private PhieuBaoHanhCtrl pbhCtrl = new PhieuBaoHanhCtrl();

        private void BatTat(bool giaTri)
        {
            txtMaPBH.Enabled = !giaTri;
            cboTenLinhKien.Enabled = !giaTri;
            txtTenKhachHang.Enabled = !giaTri;
            txtThoiGianBH.Enabled = !giaTri;
            dtNgayMua.Enabled = !giaTri;
            dtNgayHetHan.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;

            btnThem.Enabled = giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
        }

        public PhieuBaoHanh()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            txtMaPBH.Text = "";
            cboTenLinhKien.SelectedValue= "";
            txtTenKhachHang.Text = "";
            txtThoiGianBH.Text = "";
            dtNgayMua.Value = DateTime.Now;
            dtNgayHetHan.Value = DateTime.Now;


            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = false;
            maPBH = dataGridViewPBH.CurrentRow.Cells[0].Value.ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa phiếu bảo hành " + txtMaPBH.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                pbhCtrl.Xoa(txtMaPBH.Text);

                PhieuBaoHanh_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPBH.Text == "")
                MessageBox.Show("Mã phiếu bảo hành không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaPBH.Text.Length > 10)
                MessageBox.Show("Mã phiếu bảo hành chỉ cho phép tối đa 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else if (cboTenLinhKien.Text == "")
              //  MessageBox.Show("Tên linh kiện không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenKhachHang.Text=="")
                MessageBox.Show("Tên khách hàng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtThoiGianBH.Text == "")
                MessageBox.Show("Thời gian bảo hành không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                PhieuBaoHanhInfo pbh = new PhieuBaoHanhInfo();
                pbh.MaPBH = txtMaPBH.Text;
                pbh.Linhkien.MaLK = cboTenLinhKien.SelectedValue.ToString();

                pbh.TenKH = txtTenKhachHang.Text;
                pbh.TgBaoHanh = Convert.ToInt32(txtThoiGianBH.Text);
                pbh.NgayMua = dtNgayMua.Value.ToShortDateString();
                pbh.NgayHetHan = dtNgayHetHan.Value.ToShortDateString();
                //pbh.NgayMua = dtNgayMua.sel.Value.ToString("dd-MMM-yyyy");
                //pbh.NgayMua = dtNgayMua.Value.Date.ToString("dd/MMM/yyyy");
                //pbh.NgayHetHan = dtNgayHetHan.Value.Date.ToString("dd/MM/yyyy");
               

                if (isThem)
                    pbhCtrl.Them(pbh);
                else
                    pbhCtrl.Sua(pbh, maPBH);

                PhieuBaoHanh_Load(sender, e);
            }

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            PhieuBaoHanh_Load(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PhieuBaoHanh_Load(object sender, EventArgs e)
        {

            dataGridViewPBH.AutoGenerateColumns = false;
            pbhCtrl.HienThiVaoDGV(dataGridViewPBH, bindingNavigatorPBH, txtMaPBH, cboTenLinhKien, txtTenKhachHang, txtThoiGianBH, dtNgayMua, dtNgayHetHan);
            lkCtrl.HienThiVaoComboBox(cboTenLinhKien);
            BatTat(true);
                
        }
        
    }
}
