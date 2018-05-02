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
    public partial class frmChucVu : Form
    {
        private bool isThem = false;
        private string maCV = "";
        private ChucVuCtrl cvCtrl = new ChucVuCtrl();

        public frmChucVu()
        {
            InitializeComponent();
        }
        private void BatTat(bool giaTri)
        {
            txtMaCV.Enabled = !giaTri;
            txtTenCV.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;

            btnThem.Enabled = giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
        }
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = false;
            maCV = dataGridViewCV.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chức vụ " + txtTenCV.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                cvCtrl.Xoa(txtMaCV.Text);

                frmChucVu_Load_1(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaCV.Text == "")
                MessageBox.Show("Mã chức vụ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaCV.Text.Length > 4)
                MessageBox.Show("Mã chức vụ chỉ cho phép tối đa 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenCV.Text == "")
                MessageBox.Show("Tên chức vụ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ChucVuInfo cv = new ChucVuInfo();
                cv.MaCV = txtMaCV.Text;
                cv.TenCV = txtTenCV.Text;

                if (isThem)
                    cvCtrl.Them(cv);
                else
                    cvCtrl.Sua(cv, maCV);

                frmChucVu_Load_1(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmChucVu_Load_1(sender, e);
        }

        private void frmChucVu_Load_1(object sender, EventArgs e)
        {

            // Lấy dữ liệu vào DataGirdView
            cvCtrl.HienThiVaoDGV(dataGridViewCV, bindingNavigatorCV, txtMaCV, txtTenCV);
            BatTat(true);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
