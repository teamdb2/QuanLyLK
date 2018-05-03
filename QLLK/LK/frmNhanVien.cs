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
    public partial class frmNhanVien : Form
    {
        private bool isThem = false;
        private string maNV = ""; // Mã nhân viên cũ
        private NhanVienCtrl nvCtrl = new NhanVienCtrl();
        private ChucVuCtrl cvCtrl = new ChucVuCtrl();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void BatTat(bool giaTri)
        {
            txtMaNV.Enabled = !giaTri;
            txtTenNV.Enabled = !giaTri;
            txtEmail.Enabled = !giaTri;
            chkGioiTinh.Enabled = !giaTri;
            cboChucVu.Enabled = !giaTri;
            txtDiaChi.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;

            btnThem.Enabled = giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtEmail.Text = "";
            chkGioiTinh.Text = "";
            cboChucVu.Text = "";
            txtDiaChi.Text = "";
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            nvCtrl.HienThiVaoDGV(dataGridViewNV, bindingNavigatorNV, txtMaNV, txtTenNV, txtEmail, chkGioiTinh, cboChucVu, txtDiaChi);
            BatTat(true);
            cvCtrl.HienThiVaoComboBox(cboChucVu);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = false;
            maNV = dataGridViewNV.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
                MessageBox.Show("Mã nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaNV.Text.Length > 4)
                MessageBox.Show("Mã nhân viên chỉ cho phép tối đa 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenNV.Text == "")
                MessageBox.Show("Tên nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtEmail.Text == "")
                MessageBox.Show("Nhãn hiệu không được bỏ trống ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                NhanVienInfo n = new NhanVienInfo();
                n.MaNV = txtMaNV.Text;
                n.TenNV = txtTenNV.Text;
                n.Email = txtEmail.Text;

                if (chkGioiTinh.Checked == true)
                {
                    n.GioiTinh = "F";

                }
                else
                {
                    n.GioiTinh = "M";
                }
                n.DiaChi = txtDiaChi.Text;

                n.Chucvu.MaCV = cboChucVu.SelectedValue.ToString();

                if (isThem)
                    nvCtrl.Them(n);
                else
                    nvCtrl.Sua(n, maNV);

                frmNhanVien_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {

            frmNhanVien_Load(sender, e);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
