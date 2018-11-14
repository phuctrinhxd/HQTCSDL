using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using DTO;

namespace BusinessLayer
{
    public class BUS_TaiKhoan
    {
        DAL db = null;
        public BUS_TaiKhoan()
        {
            db = new DAL();
        }
        public DataSet getTaiKhoan()
        {
            return db.ExecuteQueryDataSet("TaiKhoan_SelectAll", CommandType.StoredProcedure, null);
        }
        public bool themtaikhoan(ref string err, DTO_TaiKhoan tk)
        {
            return db.MyExecuteNonQuery("TaiKhoan_Insert", CommandType.StoredProcedure, ref err,
                new SqlParameter("@tenDangNhap", tk.TK_tenDangNhap),
                new SqlParameter("@matKhau", tk.TK_matKhau),
                new SqlParameter("@hoTen", tk.TK_hoTen),
                new SqlParameter("@SDT", tk.TK_SDT),
                new SqlParameter("@maQuyen", tk.TK_maQuyen)
                );
        }
        public bool suaTaiKhoan(ref string err, DTO_TaiKhoan tk)
        {
            return db.MyExecuteNonQuery("TaiKhoan_Update", CommandType.StoredProcedure, ref err,
                new SqlParameter("@tenDangNhap", tk.TK_tenDangNhap),
                new SqlParameter("@matKhau", tk.TK_matKhau),
                new SqlParameter("@hoTen", tk.TK_hoTen),
                new SqlParameter("@SDT", tk.TK_SDT),
                new SqlParameter("@maQuyen", tk.TK_maQuyen)
                );
        }
        public bool xoaTaiKhoan(ref string err, string TK_tenDangNhap)
        {
            return db.MyExecuteNonQuery("TaiKhoan_Delete", CommandType.StoredProcedure, ref err,
                new SqlParameter("@tenDangNhap", TK_tenDangNhap)
                );
        }
    }
}
