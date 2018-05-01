using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LK.Data;
using LK.Controller;
using IBM.Data.DB2;
using LK.Info;

namespace LK
{
    public partial class frmKhachHang : Form
    {
        private bool isThem = false;
        private string maKH = "";
        private KhachHangCtrl khCtrl = new KhachHangCtrl();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void BatTat(bool giaTri)
        {
            txtMaKH.Enabled = !giaTri;
            txtTenKH.Enabled = !giaTri;
            chKGioiTinh.Enabled = !giaTri;
            txtDiaChi.Enabled = !giaTri;
            txtSDT.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;

            btnThem.Enabled = giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
        }


        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            khCtrl.HienThiVaoDGV(dataGridViewKH, bindingNavigatorKH, txtMaKH, txtTenKH,chKGioiTinh,txtDiaChi,txtSDT);
            BatTat(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            chKGioiTinh.Checked = false;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = false;
            maKH = dataGridViewKH.CurrentRow.Cells[0].Value.ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng " + txtTenKH.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                khCtrl.Xoa(txtMaKH.Text);

                frmKhachHang_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
                MessageBox.Show("Mã khách hàng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaKH.Text.Length > 4)
                MessageBox.Show("Mã khách hàng chỉ cho phép tối đa 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenKH.Text == "")
                MessageBox.Show("Tên khách hàng không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtDiaChi.Text == "")
                MessageBox.Show("Địa chỉ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtSDT.Text == "")
                MessageBox.Show("Số điện thoại khách không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                KhachHangInfo kh = new KhachHangInfo();
                kh.MaKH = txtMaKH.Text;
                kh.TenKH = txtTenKH.Text;
                if(chKGioiTinh.Checked==true)
                {
                    kh.GioiTinh = "F";

                }
                else
                {
                    kh.GioiTinh = "M";
                }

                kh.DiaChi = txtDiaChi.Text;
                kh.Sdt = Convert.ToInt32(txtSDT.Text);

                if (isThem)
                    khCtrl.Them(kh);
                else
                    khCtrl.Sua(kh, maKH);

                frmKhachHang_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
