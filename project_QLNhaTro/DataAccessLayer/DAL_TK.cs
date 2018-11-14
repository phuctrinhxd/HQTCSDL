using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DataAccessLayer
{
    public class DAL_TK : DBConnect
    {
        //public DataTable getTK()
        //{
        //    var cmd = db.TaiKhoan_SelectAll();
        ////    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dtTaiKhoan = new DataTable();
        //    da.Fill(dtTaiKhoan);
        //    return dtTaiKhoan;
        //} 
        //public bool themTaiKhoan(DTO_TaiKhoan tk)
        //{
        //    try
        //    {
        //        // _conn.Open();
        //        //string SQL = string.Format("INSERT INTO dbo.TAIKHOAN(tenDangNhap, matKhau, hoTen, SDT, maQuyen) VALUES(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", tk.TK_tenDangNhap, tk.TK_matKhau, tk.TK_hoTen, tk.TK_SDT, tk.TK_maQuyen);
        //        // SqlCommand cmd = new SqlCommand("TaiKhoan_Insert", _conn);
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.Add("@tenDangNhap", SqlDbType.NChar).Value = tk.TK_tenDangNhap;
        //        //cmd.Parameters.Add("@matKhau", SqlDbType.NChar).Value = tk.TK_matKhau;
        //        //cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar).Value = tk.TK_hoTen;
        //        //cmd.Parameters.Add("@SDT", SqlDbType.NChar).Value = tk.TK_SDT;
        //        //cmd.Parameters.Add("@maQuyen", SqlDbType.NChar).Value = tk.TK_maQuyen;
        //        //if (cmd.ExecuteNonQuery() > 0)
        //        db.TaiKhoan_Insert(tk.TK_tenDangNhap, tk.TK_matKhau, tk.TK_hoTen, tk.TK_SDT, tk.TK_maQuyen);
        //            return true;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    finally
        //    {
        //        //_conn.Close();
        //    }
        //    return false;
        //}
        //public bool suaTaiKhoan(DTO_TaiKhoan tk)
        //{
        //    try
        //    {
        //        // ket noi
        //        _conn.Open();
        //        // Query string
        //        string SQL = string.Format("UPDATE dbo.TAIKHOAN SET tenDangNhap = '{0}', matKhau = '{1}', hoTen = '{2}', SDT = '{3}', maQuyen = '{4}' Where tenDangNhap = '{5}'", tk.TK_tenDangNhap, tk.TK_matKhau, tk.TK_hoTen, tk.TK_SDT, tk.TK_maQuyen, tk.TK_tenDangNhap);
        //        SqlCommand cmd = new SqlCommand(SQL, _conn);
        //        if (cmd.ExecuteNonQuery() > 0)
        //            return true;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    finally
        //    {
        //        _conn.Close();
        //    }
        //    return false;
        //}
        //public bool xoaTaiKhoan(string TK_tenDangNhap)
        //{
        //    try
        //    {
        //        _conn.Open();
        //        string SQL = string.Format("DELETE FROM TAIKHOAN WHERE tenDangNhap ='{0}'", TK_tenDangNhap);
        //        SqlCommand cmd = new SqlCommand(SQL, _conn);
        //        if (cmd.ExecuteNonQuery() > 0)
        //            return true;
        //    }
        //    catch(Exception e)
        //    {

        //    }
        //    finally
        //    {
        //        _conn.Close();
        //    }
        //    return false;
        //}
    }
}
