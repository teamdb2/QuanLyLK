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
    public partial class frmLinhKien : Form
    {
        private bool isThem = false;
        private string maLK = ""; // Mã nhân viên cũ
        private LinhKienCtrl lkCtrl = new LinhKienCtrl();
        public frmLinhKien()
        {
            InitializeComponent();
        }
        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if(txtGiaBan.Text.Trim(' ').Length > 3)
                {
                    string str_temp = txtGiaBan.Text;
                    long giaban = long.Parse(str_temp.Replace(",", ""));
                    txtGiaBan.Text = giaban.ToString("0,00.##");
                    txtGiaBan.Select(txtGiaBan.TextLength, 0);
                }
            }
            catch (Exception)
            {
              
                

            }
        }

        private void frmLinhKien_Load(object sender, EventArgs e)
        {
            // Chỉ hiển thị các cột được thiết kế
            //dgvtest.AutoGenerateColumns = false;
            // Lấy dữ liệu vào DataGirdView
            lkCtrl.HienThiVaoDGV(dgvtest, bindingNavigatorLK, txtMaLK, txtTenLK, txtNhanHieu, txtTSKyThuat, txtGiaBan, txtGiaNhap);
            BatTat(true);
        }
        private void BatTat(bool giaTri)
        {
            txtMaLK.Enabled = !giaTri;
            txtTenLK.Enabled = !giaTri;
            txtNhanHieu.Enabled = !giaTri;
            txtTSKyThuat.Enabled = !giaTri;
            txtGiaBan.Enabled = !giaTri;
            txtGiaNhap.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;
        
            btnThem.Enabled = giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = true;
            txtMaLK.Text = "";
            txtTenLK.Text = "";
            txtNhanHieu.Text = "";
            txtTSKyThuat.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(false);
            isThem = false;
            maLK= dgvtest.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa linh kiện " + txtTenLK.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                lkCtrl.Xoa(txtMaLK.Text);

                frmLinhKien_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaLK.Text == "")
                MessageBox.Show("Mã linh kiện không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaLK.Text.Length > 20)
                MessageBox.Show("Mã linh kiện chỉ cho phép tối đa 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenLK.Text == "")
                MessageBox.Show("Tên linh kiện không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtNhanHieu.Text == "")
                MessageBox.Show("Nhãn hiệu không được bỏ trống ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtGiaBan.Text == "")
                MessageBox.Show("Giá bán không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtGiaNhap.Text == "")
                MessageBox.Show("Giá Nhập không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                LinhKienInfo lk = new LinhKienInfo();
                lk.MaLK = txtMaLK.Text;
                lk.TenLK = txtTenLK.Text;
                lk.NhanHieu = txtNhanHieu.Text;
                lk.ThongSoKyThuat = txtTSKyThuat.Text;
                lk.GiaBan = Convert.ToInt32(txtGiaBan.Text.Replace(",", ""));

                lk.GiaNhap = Convert.ToInt32(txtGiaNhap.Text.Replace(",", ""));


                if (isThem)
                    lkCtrl.Them(lk);

                else
                    lkCtrl.Sua(lk, maLK);

                frmLinhKien_Load(sender, e);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmLinhKien_Load(sender, e);
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtGiaNhap.Text.Trim(' ').Length > 3)
                {
                    string str_temp = txtGiaNhap.Text;
                    long gianhap = long.Parse(str_temp.Replace(",", ""));
                    txtGiaNhap.Text = gianhap.ToString("0,00.##");
                    txtGiaNhap.Select(txtGiaNhap.TextLength, 0);
                }
            }
            catch (Exception)
            {



            }
        }
    }
}
