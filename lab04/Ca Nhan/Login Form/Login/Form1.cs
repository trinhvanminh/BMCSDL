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
using System.Security.Cryptography;

namespace Login
{
    public partial class Form1 : Form
    {
        SHA1CryptoServiceProvider sh;
        MD5CryptoServiceProvider md;
        public Form1()
        {
            InitializeComponent();
            sh = new SHA1CryptoServiceProvider();
            md = new MD5CryptoServiceProvider();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ConnectSQL dc = new ConnectSQL();
            try
            {
                SqlConnection con = dc.getConnect();
                string tk = txtTK.Text;
                string mk = txtMK.Text;
                byte[] sh_mk = sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(mk));
                string sh_mk_string = "0x" + BitConverter.ToString(sh_mk).Replace("-", "");
                //MessageBox.Show(BitConverter.ToString(sh_mk));
                byte[] md_mk = md.ComputeHash(ASCIIEncoding.ASCII.GetBytes(mk));
                string md_mk_string = "0x" + BitConverter.ToString(md_mk).Replace("-", "");
                //MessageBox.Show(BitConverter.ToString(md_mk));

                string sql_nv = "select * from NHANVIEN where TENDN = N'" + tk + "' and MATKHAU = "+ sh_mk_string +";";
                string sql_sv = "select * from SINHVIEN where TENDN = N'" + tk + "' and MATKHAU = "+ md_mk_string +";";

                con.Open();
                SqlCommand cmd = new SqlCommand(sql_nv, con);
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
                    cmd = new SqlCommand(sql_sv, con);
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
            catch (Exception)
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
