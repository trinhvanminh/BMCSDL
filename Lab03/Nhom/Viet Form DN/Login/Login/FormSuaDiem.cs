using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class FormSuaDiem : Form
    {

        
        string manv,mk, masv,hoten;
        ConnectSQL dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public FormSuaDiem(string ma_nv, string matkhau, string ma_sv, string ho_ten)
        {
            InitializeComponent();
            dc = new ConnectSQL();
            masv = ma_sv;
            hoten = ho_ten;
            manv = ma_nv;
            mk = matkhau;
        }
        public DataTable getBangDiem(string masv)
        {
            string sql = "select * from BANGDIEM where BANGDIEM.masv = '"+masv+"'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        private void dt_GridView_EditScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < dt_GridView_EditScore.Rows.Count - 1)
            { 
                txtMaHP.Text = dt_GridView_EditScore.Rows[index].Cells["MaHP"].Value.ToString();
                //byte[] b_arr = (byte[])dt_GridView_EditScore.Rows[index].Cells["DiemThi"].Value;

                //điểm thi kiểu varbinary
                //select diem_giaima = convert(varchar, DECRYPTBYASYMKEY(ASYMKEY_ID('NV01'), diemthi, N'123456'))
                txtDiem.Text = string.Empty;
            }
            else
            {
                txtDiem.Text = string.Empty;
                txtMaHP.Text = string.Empty;
            }
        }

        public bool UpdateDiem(string masv, string diemthi, string mahp)
        {
            string sql = "update bangdiem set diemthi=ENCRYPTBYASYMKEY(ASYMKEY_ID('"+manv+"'),convert(varbinary,@diemthi)) where masv = @masv and MAHP = @mahp";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@masv", SqlDbType.VarChar).Value = masv;
                cmd.Parameters.Add("@diemthi", SqlDbType.VarChar).Value = diemthi;
                cmd.Parameters.Add("@mahp", SqlDbType.VarChar).Value = mahp;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
            }
            else if (string.IsNullOrEmpty(txtMaHP.Text))
            {
                MessageBox.Show("Bạn chưa điền tên học phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHP.Focus();
            }
            else
            {
                if(UpdateDiem(masv, txtDiem.Text, txtMaHP.Text))
                {
                    DataTable dt = getBangDiem(masv);
                    dt_GridView_EditScore.DataSource = dt;
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình sửa dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            
        }
        public bool InsertDiem(string masv, string diemthi, string mahp)
        {
            string sql = "insert into bangdiem(MASV,MAHP,DIEMTHI) values(@masv, @mahp, ENCRYPTBYASYMKEY(ASYMKEY_ID('" + manv + "'),convert(varbinary,@diemthi)))";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@masv", SqlDbType.VarChar).Value = masv;
                cmd.Parameters.Add("@diemthi", SqlDbType.VarChar).Value = diemthi;
                cmd.Parameters.Add("@mahp", SqlDbType.VarChar).Value = mahp;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
            }
            else if (string.IsNullOrEmpty(txtMaHP.Text))
            {
                MessageBox.Show("Bạn chưa điền tên học phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHP.Focus();
            }
            else
            {
                if (InsertDiem(masv, txtDiem.Text, txtMaHP.Text))
                {
                    DataTable dt = getBangDiem(masv);
                    dt_GridView_EditScore.DataSource = dt;
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình thêm dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        public bool DeleteDiem(string masv, string mahp)
        {
            string sql = "Delete bangdiem where masv=@masv and mahp=@mahp";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@masv", SqlDbType.VarChar).Value = masv;
                cmd.Parameters.Add("@mahp", SqlDbType.VarChar).Value = mahp;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHP.Text))
            {
                MessageBox.Show("Bạn chưa điền tên học phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHP.Focus();
            }
            else if(MessageBox.Show("Bạn có muốn xoá hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DeleteDiem(masv, txtMaHP.Text))
                {
                    DataTable dt = getBangDiem(masv);
                    dt_GridView_EditScore.DataSource = dt;
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xoá dữ liệu.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void FormSuaDiem_Load(object sender, EventArgs e)
        {
            DataTable dt = getBangDiem(masv);
            dt_GridView_EditScore.DataSource = dt;
            lb_masv.Text = masv;
            lb_hoten.Text = hoten;
        }
    }
}
