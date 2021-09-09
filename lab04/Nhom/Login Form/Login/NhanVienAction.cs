using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    class NhanVienAction
    {
        ConnectSQL dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        AES aes_obj;
        SHA1CryptoServiceProvider sh;
        public NhanVienAction()
        {
            dc = new ConnectSQL();
            //key.length must be 32 character
            aes_obj = new AES("17126011712601171260117126011712");
            sh = new SHA1CryptoServiceProvider();
        }
        public DataTable getAllNhanVien()
        {
            string sql = "EXEC SP_SEL_ENCRYPT_NHANVIEN";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            //giai ma luong

            DataTable dtCloned = dt.Clone();
            dtCloned.Columns["Luong"].DataType = typeof(String);

          

            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                DataRow row2 = dtCloned.Rows[i];
                byte[] luong = (byte[])row["Luong"];
                row2["Luong"] = aes_obj.Decrypt(luong);

            }

            //byte[] encrypted_bytes = aes_obj.Encrypt("80.000");
            //string decrypted_string = aes_obj.Decrypt(encrypted_bytes);
            //MessageBox.Show(decrypted_string);

            return dtCloned;
        }
        //-------------------------------------------------------------------------------------------------------------
        public bool InsertNhanVien(TB_NhanVien nv)
        {
            string sql = "EXEC SP_INS_ENCRYPT_NHANVIEN @manv, @hoten, @email, @luong, @tendn, @matkhau";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = nv.MaNV;
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = nv.HoTen;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = nv.Email;
                cmd.Parameters.Add("@luong", SqlDbType.VarBinary).Value = aes_obj.Encrypt(nv.Luong);
                cmd.Parameters.Add("@tendn", SqlDbType.NVarChar).Value = nv.TenDN;
                cmd.Parameters.Add("@matkhau", SqlDbType.VarBinary).Value = sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(nv.MatKhau));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateNhanVien(TB_NhanVien nv)
        {
            string sql = "update NHANVIEN set hoten=@hoten,email=@email,luong=@luong,tendn=@tendn, matkhau=@matkhau where manv = @manv";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = nv.MaNV;
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = nv.HoTen;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = nv.Email;
                cmd.Parameters.Add("@luong", SqlDbType.VarBinary).Value = aes_obj.Encrypt(nv.Luong);
                cmd.Parameters.Add("@tendn", SqlDbType.NVarChar).Value = nv.TenDN;
                cmd.Parameters.Add("@matkhau", SqlDbType.VarBinary).Value = sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(nv.MatKhau));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool DeleteNhanVien(string Manv)
        {
            string sql = "delete nhanvien where manv = @manv";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Manv;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
