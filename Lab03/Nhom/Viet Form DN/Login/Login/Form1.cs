using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ConnectSQL dc = new ConnectSQL();
            try
            {
                SqlConnection con = dc.getConnect();
                string tk = txtTK.Text;
                string mk = txtMK.Text;
                string sql = "select * from NHANVIEN where '" + tk + "' = MANV and CONVERT(VARBINARY,'" + mk + "') = MATKHAU";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();
                
                if (dta.Read() == true)
                {
                    con.Close();

                    //tạo asymatric key
                    con = dc.getConnect();
                    string sql_2 = "IF NOT EXISTS (SELECT * FROM sys.asymmetric_keys WHERE name = '"+tk+"') CREATE ASYMMETRIC KEY "+tk+"   WITH ALGORITHM = RSA_512 ENCRYPTION BY PASSWORD = '"+mk+"'";
                    con.Open();
                    cmd = new SqlCommand(sql_2, con);
                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    FromThaoTac ftt = new FromThaoTac(tk, mk);
                    ftt.ShowDialog();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Tên đăng nhập và mật khẩu không hợp lệ");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
;        }

        
        private void eye_Click(object sender, EventArgs e)
        {
            if (txtMK.UseSystemPasswordChar)
            {
                eyeslash.BringToFront();
                txtMK.PasswordChar = '\0';
                txtMK.UseSystemPasswordChar = false;
            }
        }

        private void eyeslash_Click(object sender, EventArgs e)
        {
            if (txtMK.PasswordChar == '\0')
            {
                eye.BringToFront();
                txtMK.UseSystemPasswordChar = true;
            }
        }
    }
}
