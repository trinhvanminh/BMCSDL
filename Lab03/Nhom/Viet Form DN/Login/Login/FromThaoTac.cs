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
    public partial class FromThaoTac : Form
    {
        SinhVienBLL bllSV;
        string manv, matkhau;
        public FromThaoTac(string tk, string mk)
        {
            InitializeComponent();
            bllSV = new SinhVienBLL();
            manv = tk;
            matkhau = mk;
        }
        public void ShowAllSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien(manv);
            dt_GridView_tbl_sv.DataSource = dt;
        }
        

        private void FromThaoTac_Load(object sender, EventArgs e)
        {
            ShowAllSinhVien();
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNgaySinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgaySinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập của sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu của sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return false;
            }
            return true;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tbl_SinhVien sv = new tbl_SinhVien();
                sv.MaSV = txtMaSV.Text;
                sv.HoTen = txtHoTen.Text;
                sv.NgaySinh = txtNgaySinh.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.MaLop = txtMaLop.Text;
                sv.TenDN = txtTenDN.Text;
                sv.MatKhau = txtMatKhau.Text;
                if(bllSV.CheckMaLop(manv,sv))
                {
                    if (bllSV.InsertSinhVien(sv))
                        ShowAllSinhVien();
                    else
                        MessageBox.Show("Đã xảy ra lỗi trog quá trình thêm dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Giáo viên không quản lý lớp "+sv.MaLop+".", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            tbl_SinhVien sv = new tbl_SinhVien();
            sv.MaSV = txtMaSV.Text;
            sv.MaLop = txtMaLop.Text;
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Nhập mã sinh viên hoặc chọn hàng để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
            }
            else if(!bllSV.CheckMaLop(manv, sv))
            {
                MessageBox.Show("Giáo viên không quản lý lớp " + sv.MaLop + ".", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if(MessageBox.Show("Bạn có muốn xoá hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
                if (bllSV.DeleteSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Đã xảy ra lỗi trog quá trình xoá dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
            }
        }

        private void dt_GridView_tbl_sv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < dt_GridView_tbl_sv.Rows.Count - 1)
            {
                txtMaSV.Text = dt_GridView_tbl_sv.Rows[index].Cells["MaSv"].Value.ToString();
                txtHoTen.Text = dt_GridView_tbl_sv.Rows[index].Cells["HoTen"].Value.ToString();

                DateTime ns = DateTime.Parse(dt_GridView_tbl_sv.Rows[index].Cells["NgaySinh"].Value.ToString());
                txtNgaySinh.Text = ns.ToString("dd/MM/yyyy");
                
                txtDiaChi.Text = dt_GridView_tbl_sv.Rows[index].Cells["DiaChi"].Value.ToString();
                txtMaLop.Text = dt_GridView_tbl_sv.Rows[index].Cells["MaLop"].Value.ToString();
                txtTenDN.Text = dt_GridView_tbl_sv.Rows[index].Cells["TenDN"].Value.ToString();
                byte[] b_arr = (byte[])dt_GridView_tbl_sv.Rows[index].Cells["MatKhau"].Value;
                txtMatKhau.Text = Encoding.UTF8.GetString(b_arr);
            }
            else
            {
                txtMaSV.Text = String.Empty;
                txtHoTen.Text = String.Empty;
                txtNgaySinh.Text = String.Empty;
                txtDiaChi.Text = String.Empty;
                txtMaLop.Text = String.Empty;
                txtTenDN.Text = String.Empty;
                txtMatKhau.Text = String.Empty;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tbl_SinhVien sv = new tbl_SinhVien();
                sv.MaSV = txtMaSV.Text;
                sv.HoTen = txtHoTen.Text;
                sv.NgaySinh = txtNgaySinh.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.MaLop = txtMaLop.Text;
                sv.TenDN = txtTenDN.Text;
                sv.MatKhau = txtMatKhau.Text;


                if (bllSV.CheckMaLop(manv, sv))
                {
                    if (bllSV.UpdateSinhVien(sv))
                        ShowAllSinhVien();
                    else
                        MessageBox.Show("Đã xảy ra lỗi trog quá trình thêm dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Giáo viên không quản lý lớp " + sv.MaLop + ".", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
            }
        }

        private void eye_Click(object sender, EventArgs e)
        {
            if(txtMatKhau.UseSystemPasswordChar)
            {
                //mang icon eyeslash lên đầu để ẩn icon eye
                eyeslash.BringToFront();
                //hiển thị bản rõ pwd
                txtMatKhau.PasswordChar = '\0';
                //UseSystemPasswordChar = false
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void eyeslash_Click(object sender, EventArgs e)
        {
            //nếu mk là bản rõ
            if (txtMatKhau.PasswordChar == '\0')
            {
                eye.BringToFront();
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            tbl_SinhVien sv = new tbl_SinhVien();
            sv.MaLop = txtMaLop.Text;
          
            string info = txtSearch.Text;
            if (!string.IsNullOrEmpty(info) && !bllSV.CheckMaLop(manv, sv))
            {
                DataTable dt = bllSV.SearchSV(info);
                dt_GridView_tbl_sv.DataSource = dt;
            }
            else
            {
                ShowAllSinhVien();
            }

        }

        private void dt_GridView_tbl_sv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < dt_GridView_tbl_sv.Rows.Count - 1)
            {
                string masv = dt_GridView_tbl_sv.Rows[index].Cells["MaSv"].Value.ToString();
                string hoten = dt_GridView_tbl_sv.Rows[index].Cells["HoTen"].Value.ToString();
                FormSuaDiem fsd = new FormSuaDiem(manv, matkhau, masv, hoten);
                fsd.ShowDialog();
            }

        }
    }
}
