using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DichVu
    {
        private string _DV_maDV;
        private string _DV_tenDV;
        private decimal _DV_giaDV;
        public string DV_maDV
        {
            get
            {
                return _DV_maDV;
            }
            set
            {
                _DV_maDV = value;
            }
        }
        public string DV_tenDV
        {
            get
            {
                return _DV_tenDV;
            }
            set
            {
                _DV_tenDV = value;
            }
        }
        public decimal DV_giaDV
        {
            get
            {
                return _DV_giaDV;
            }
            set
            {
                _DV_giaDV = value;
            }
        }
        public DTO_DichVu(string maDV, string tenDV, decimal giaDV)
        {
            this.DV_maDV = maDV;
            this.DV_tenDV = tenDV;
            this.DV_giaDV = giaDV;
        }
    }
}
