using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class NhanVienBLL
    {
        NhanVienAction nva;
        public NhanVienBLL()
        {
            nva = new NhanVienAction();
        }
        public DataTable getAllNhanVien()
        {
            return nva.getAllNhanVien();
        }
        public bool InsertNhanVien(TB_NhanVien nv)
        {
            return nva.InsertNhanVien(nv);
        }

        public bool UpdateNhanVien(TB_NhanVien nv)
        {
            return nva.UpdateNhanVien(nv);
        }
        public bool DeleteNhanVien(string Manv)
        {
            return nva.DeleteNhanVien(Manv);
        }
    }
}
