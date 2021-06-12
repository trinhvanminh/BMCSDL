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

                string sql = "select * from SINHVIEN where TENDN = '" + tk + "' and HASHBYTES('MD5','" + mk + "') = MATKHAU";
                string sql_nv = "select * from NHANVIEN where TENDN = '" + tk + "' and HASHBYTES('SHA1','" + mk + "') = MATKHAU";

                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();
                
                if (dta.Read() == true)
                {
                    con.Close();
                    FormAction fa = new FormAction();
                    fa.ShowDialog();
                }
                else
                {
                    dta.Close();
                    cmd = new SqlCommand(sql_nv, con);
                    dta = cmd.ExecuteReader();
                    if (dta.Read() == true)
                    {
                        con.Close();
                        FormAction fa = new FormAction();
                        fa.ShowDialog();
                    }    
                    else
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
;       }

        
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
