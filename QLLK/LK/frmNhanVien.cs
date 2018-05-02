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
using LK.Info;


namespace LK
{
    public partial class frmNhanVien : Form
    {
        private bool isThem = false;
        private string maNV = ""; // Mã nhân viên cũ
        private ChucVuCtrl cvCtrl = new ChucVuCtrl();
        private NhanVienCtrl nvCtrl = new NhanVienCtrl();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dataGridViewNV.AutoGenerateColumns = false;

            // Lấy dữ liệu vào DataGirdView
            nvCtrl.HienThiVaoDGV(dataGridViewNV, bindingNavigatorNV, txtMaNV, txtTenNV,txtEmail, cboChucVu);
            cvCtrl.HienThiVaoComboBox(cboChucVu);
            BatTat(true);

        }
        private void BatTat(bool giaTri)
        {
            txtMaNV.Enabled = !giaTri;
            txtTenNV.Enabled = !giaTri;
            txtEmail.Enabled = !giaTri;    
            cboChucVu.Enabled = !giaTri;
            btnThem.Enabled = giaTri;
            btnLuu.Enabled = !giaTri;
            btnXoa.Enabled = giaTri;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
           
        }

        private void cbChucVu_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtEmail.Text = "";
            cboChucVu.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = false;
            maNV = dataGridViewNV.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhân viên " + txtTenNV.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                nvCtrl.Xoa(txtMaNV.Text);

                frmNhanVien_Load(sender, e);
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
                MessageBox.Show("Mã nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaNV.Text.Length > 4)
                MessageBox.Show("Mã nhân viên chỉ cho phép tối đa 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenNV.Text == "")
                MessageBox.Show("Tên nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                NhanVienInfo n = new NhanVienInfo();
                n.MaNV = txtMaNV.Text;
                n.TenNV = txtTenNV.Text;
                n.Email = txtEmail.Text;

                n.Chucvu.MaCV = cboChucVu.SelectedValue.ToString();
              

                if (isThem)
                    nvCtrl.Them(n);
                else
                    nvCtrl.Sua(n, maNV);

                frmNhanVien_Load(sender, e);
            }
        }

        private void btnlammoi_Click_1(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
