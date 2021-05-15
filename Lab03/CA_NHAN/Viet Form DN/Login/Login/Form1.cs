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
            SqlConnection con = new SqlConnection(@"Data Source=Minh-PC\MSSQLSERVER02;Initial Catalog=QLSV;Integrated Security=True");
            try
            {
                con.Open();
                string tk = txtTK.Text;
                string mk = txtMK.Text;
                string sql = "select * from SINHVIEN where '" + tk + "' = TENDN and HASHBYTES('MD5','" + mk + "') = MATKHAU";

                string sql_nv = "select * from NHANVIEN where '" + tk + "' = TENDN and HASHBYTES('SHA1','" + mk + "') = MATKHAU";

                //select * from SINHVIEN where 'NVA' = TENDN and HASHBYTES('MD5','123456') = MATKHAU
                //select* from NHANVIEN where 'NVA' = TENDN and HASHBYTES('SHA1','abcd12') = MATKHAU

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read() == true)
                    MessageBox.Show("Đăng nhập thành công");
                else
                {
                    dta.Close();
                    cmd = new SqlCommand(sql_nv, con);
                    dta = cmd.ExecuteReader();
                    if (dta.Read() == true)
                        MessageBox.Show("Đăng nhập thành công");
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
;        }
    }
}
