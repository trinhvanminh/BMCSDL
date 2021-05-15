using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class SinhVienAccess
    {
        ConnectSQL dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SinhVienAccess()
        {
            dc = new ConnectSQL();
        }
        public DataTable getAllSinhVien(string manv)
        {
            string sql = "select * from SINHVIEN where MALOP in (select malop from nhanvien join lop on nhanvien.MANV = lop.manv where nhanvien.manv = '" + manv + "' )";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool CheckMaLop(string manv, tbl_SinhVien sv)
        {
            string sql = "select * from sinhvien where @malop in (select malop from nhanvien join lop on nhanvien.MANV = lop.manv where nhanvien.manv = '"+manv+"' )";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@malop", SqlDbType.VarChar).Value = sv.MaLop;
                if (cmd.ExecuteScalar() == null)
                {
                    con.Close();
                    return false;
                }
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool InsertSinhVien(tbl_SinhVien sv)
        {   
            string sql = "insert into SinhVien(masv, hoten,ngaysinh,diachi,malop,tendn, matkhau) values(@masv, @hoten,convert(datetime, @ngaysinh,103),@diachi,@malop,@tendn,convert(varbinary,@matkhau))";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@masv", SqlDbType.VarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@ngaysinh", SqlDbType.VarChar).Value = sv.NgaySinh;
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.Parameters.Add("@malop", SqlDbType.VarChar).Value = sv.MaLop;
                cmd.Parameters.Add("@tendn", SqlDbType.VarChar).Value = sv.TenDN;
                cmd.Parameters.Add("@matkhau", SqlDbType.VarChar).Value = sv.MatKhau;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSinhVien(tbl_SinhVien sv)
        {
            string sql = "update SinhVien set hoten=@hoten,ngaysinh=convert(datetime, @ngaysinh,103),diachi=@diachi,malop=@malop,tendn=@tendn, matkhau=convert(varbinary,@matkhau) where masv = @masv";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@masv", SqlDbType.VarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@ngaysinh", SqlDbType.VarChar).Value = sv.NgaySinh;
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.Parameters.Add("@malop", SqlDbType.VarChar).Value = sv.MaLop;
                cmd.Parameters.Add("@tendn", SqlDbType.VarChar).Value = sv.TenDN;
                cmd.Parameters.Add("@matkhau", SqlDbType.VarChar).Value = sv.MatKhau;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool DeleteSinhVien(tbl_SinhVien sv)
        {
            string sql = "delete sinhvien where masv = @masv";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@masv", SqlDbType.VarChar).Value = sv.MaSV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public DataTable SearchSV(string info)
        {
            //tìm theo họ tên, mã sv, mã lớp
            string sql = "select * from sinhvien where hoten like N'%" + info + "%' or masv like '%" + info + "%' or malop like '%" + info + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
