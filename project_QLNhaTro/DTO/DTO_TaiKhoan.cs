using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {
        private string _TK_tenDangNhap;
        private string _TK_matKhau;
        private string _TK_hoTen;
        private string _TK_SDT;
        private string _TK_maQuyen;

        public string TK_tenDangNhap
        {
            get
            {
                return _TK_tenDangNhap;
            }
            set
            {
                _TK_tenDangNhap = value;
            }
        }
        public string TK_matKhau
        {
            get
            {
                return _TK_matKhau;
            }
            set
            {
                _TK_matKhau = value;
            }
        }
        public string TK_hoTen
        {
            get
            {
                return _TK_hoTen;
            }
            set
            {
                _TK_hoTen = value;
            }
        }
        public string TK_SDT
        {
            get
            {
                return _TK_SDT;
            }
            set
            {
                _TK_SDT = value;
            }
        }
        public string TK_maQuyen
        {
            get
            {
                return _TK_maQuyen;
            }
            set
            {
                _TK_maQuyen = value;
            }
        }
        public DTO_TaiKhoan()
        {

        }
        public DTO_TaiKhoan (string tenDangNhap, string matKhau, string hoTen, string SDT, string maQuyen)
        {
            this.TK_tenDangNhap = tenDangNhap;
            this.TK_matKhau = matKhau;
            this.TK_hoTen = hoTen;
            this.TK_SDT = SDT;
            this.TK_maQuyen = maQuyen;
        }
    }
}
