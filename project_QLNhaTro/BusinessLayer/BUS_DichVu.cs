using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using DTO;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BUS_DichVu
    {
        
        DAL db = null;
        public BUS_DichVu()
        {
            db = new DAL();
        }
        public DataSet getTaiKhoan()
        {
            return db.ExecuteQueryDataSet("DichVu_Select", CommandType.StoredProcedure, null);
        }
        public bool themDichVu(ref string err, DTO_DichVu dv)
        {
            return db.MyExecuteNonQuery("DichVu_Insert", CommandType.StoredProcedure, ref err,
                new SqlParameter("@maDV", dv.DV_maDV),
                new SqlParameter("@tenDV", dv.DV_tenDV),
                new SqlParameter("@giaDV", dv.DV_giaDV)
                );
        }
    }
}
