using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBM.Data.DB2;
using LK.Controller;
using LK.Data;
using LK.Info;

namespace LK
{
    public partial class frmNhaCungCap : Form
    {
        private bool isThem = false;
        private string maNCC = "";
        private NhaCungCapCtrl nccCtrl = new NhaCungCapCtrl();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void BatTat(bool giaTri)
        {
            txtMaNCC.Enabled = !giaTri;
            txtTenNCC.Enabled = !giaTri;
            txtDiaChiNCC.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;

            btnThem.Enabled = giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChiNCC.Text = "";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = false;
            maNCC = dataGridViewNCC.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chức vụ " + txtTenNCC.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                nccCtrl.Xoa(txtMaNCC.Text);

                frmNhaCungCap_Load(sender, e);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
                MessageBox.Show("Mã chức vụ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaNCC.Text.Length > 20)
                MessageBox.Show("Mã chức vụ chỉ cho phép tối đa 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenNCC.Text == "")
                MessageBox.Show("Tên chức vụ không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                NhaCungCapInfo ncc = new NhaCungCapInfo();
                ncc.MaNCC = txtMaNCC.Text;
                ncc.TenNCC = txtTenNCC.Text;
                ncc.DiaChiNCC= txtDiaChiNCC.Text;

                if (isThem)
                    nccCtrl.Them(ncc);
                else
                    nccCtrl.Sua(ncc, maNCC);

                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmNhaCungCap_Load(sender, e);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            nccCtrl.HienThiVaoDGV(dataGridViewNCC, bindingNavigatorNCC, txtMaNCC,txtTenNCC, txtDiaChiNCC);
            BatTat(true);
        }
    }
}
