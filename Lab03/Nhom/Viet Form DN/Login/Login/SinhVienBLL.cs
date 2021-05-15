using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class SinhVienBLL
    {
        SinhVienAccess AccessSv;
        public SinhVienBLL()
        {
            AccessSv = new SinhVienAccess();
        }
        public DataTable getAllSinhVien(string manv)
        {
            return AccessSv.getAllSinhVien(manv);
        }
        public bool InsertSinhVien(tbl_SinhVien sv)
        {
            return AccessSv.InsertSinhVien(sv);
        }
        public bool UpdateSinhVien(tbl_SinhVien sv)
        {
            return AccessSv.UpdateSinhVien(sv);
        }
        public bool DeleteSinhVien(tbl_SinhVien sv)
        {
            return AccessSv.DeleteSinhVien(sv);
        }
        public DataTable SearchSV(string info)
        {
            return AccessSv.SearchSV(info);
        }
        //kiểm tra xem giáo viên đó có dạy lớp có mã lớp đó không
        public bool CheckMaLop(string manv, tbl_SinhVien sv)
        {
            return AccessSv.CheckMaLop(manv, sv);
        }
    }
}
