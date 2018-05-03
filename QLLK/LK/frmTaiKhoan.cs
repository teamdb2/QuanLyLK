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
    public partial class frmTaiKhoan : Form
    {
        private bool isThem = false;
        private TaiKhoanCtrl tkCtrl = new TaiKhoanCtrl();
        private NhanVienCtrl nvCtrl = new NhanVienCtrl();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        private void BatTat(bool giaTri)
        {
            cboNhanVien.Enabled = !giaTri;
            cboQuyenHan.Enabled = !giaTri;
            txtMatKhau.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;

            btnThem.Enabled = giaTri;
            btnLuu.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu vào DataGirdView
            tkCtrl.HienThiVaoDGV(dataGridViewTK, bindingNavigatorTK, cboNhanVien, cboQuyenHan, txtMatKhau);

            // Lấy danh sách nhân viên vào ComboBox
            nvCtrl.HienThiVaoComboBox(cboNhanVien);
            BatTat(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            cboNhanVien.Text = "";
            cboQuyenHan.Text = "";
            txtMatKhau.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            cboNhanVien.Text = "";
            cboQuyenHan.Text = "";
            txtMatKhau.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản " + cboNhanVien.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridViewTK.CurrentRow.Cells[0].Value.ToString());

                tkCtrl.Xoa(id);

                frmTaiKhoan_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.Text == "")
                MessageBox.Show("Chưa chọn nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cboQuyenHan.Text == "")
                MessageBox.Show("Chưa chọn quyền hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMatKhau.Text == "")
                MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                TaiKhoanInfo tk = new TaiKhoanInfo();
                tk.NhanVien.MaNV = cboNhanVien.SelectedValue.ToString();
                tk.MatKhau = txtMatKhau.Text;
                tk.Quyen = cboQuyenHan.SelectedIndex;

                if (isThem)
                    tkCtrl.Them(tk);
                else
                {
                    tk.Id = Convert.ToInt32(dataGridViewTK.CurrentRow.Cells[0].Value.ToString());
                    tkCtrl.Sua(tk);
                }

                frmTaiKhoan_Load(sender, e);
            }
        }

      

        private void dataGridViewTK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewTK.Columns[e.ColumnIndex].Name == "colmatkhau")
            {
                e.Value = "**********";
            }

            if (dataGridViewTK.Columns[e.ColumnIndex].Name == "colquyenhan")
            {
                if (e.Value.ToString() == "0")
                    e.Value = "Quản lý";
                else
                    e.Value = "Nhân viên";
            }
        }
    }
}
