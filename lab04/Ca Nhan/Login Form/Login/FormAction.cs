using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class FormAction : Form
    {
        NhanVienBLL NvBLL;
        public FormAction()
        {
            InitializeComponent();
            NvBLL = new NhanVienBLL();
        }

        public void ShowAllNhanVien()
        {
            DataTable dt = NvBLL.getAllNhanVien();
            dtGV_tb_NV.DataSource = dt;
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Bạn chưa nhập email nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMK.Focus();
                return false;
            }
            return true;
        }

        private void FormAction_Load(object sender, EventArgs e)
        {
            ShowAllNhanVien();
        }

        private void dtGV_tb_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < dtGV_tb_NV.Rows.Count - 1)
            {
                txtMaNV.Text = dtGV_tb_NV.Rows[index].Cells["MaNv"].Value.ToString();
                txtHoTen.Text = dtGV_tb_NV.Rows[index].Cells["HoTen"].Value.ToString();
                txtEmail.Text = dtGV_tb_NV.Rows[index].Cells["Email"].Value.ToString();
                txtLuong.Text = dtGV_tb_NV.Rows[index].Cells["Luong"].Value.ToString();
                txtTenDN.Text = String.Empty;
                txtMK.Text = String.Empty;
            }
            else
            {
                txtMaNV.Text = String.Empty;
                txtHoTen.Text = String.Empty;
                txtEmail.Text = String.Empty;
                txtLuong.Text = String.Empty;
                txtTenDN.Text = String.Empty;
                txtMK.Text = String.Empty;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TB_NhanVien nv = new TB_NhanVien();
                nv.MaNV = txtMaNV.Text;
                nv.HoTen = txtHoTen.Text;
                nv.Email = txtEmail.Text;
                nv.Luong = txtLuong.Text;
                nv.TenDN = txtTenDN.Text;
                nv.MatKhau = txtMK.Text;
                if (NvBLL.InsertNhanVien(nv))
                    ShowAllNhanVien();
                else
                    MessageBox.Show("Đã xảy ra lỗi trog quá trình thêm dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn xoá hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (NvBLL.DeleteNhanVien(txtMaNV.Text))
                    ShowAllNhanVien();
                else
                    MessageBox.Show("Đã xảy ra lỗi trog quá trình xoá dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                TB_NhanVien nv = new TB_NhanVien();
                nv.MaNV = txtMaNV.Text;
                nv.HoTen = txtHoTen.Text;
                nv.Email = txtEmail.Text;
                nv.Luong = txtLuong.Text;
                nv.TenDN = txtTenDN.Text;
                nv.MatKhau = txtMK.Text;
                if (NvBLL.UpdateNhanVien(nv))
                    ShowAllNhanVien();
                else
                    MessageBox.Show("Đã xảy ra lỗi trog quá trình thêm dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        private void btnSaveDB_Click(object sender, EventArgs e)
        {

        }

        private void btnUnsave_Click(object sender, EventArgs e)
        {
            ShowAllNhanVien();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
