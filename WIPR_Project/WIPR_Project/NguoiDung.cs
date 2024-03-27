using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class NguoiDung : DoiTuong
    {
        public NguoiDung() { }
        public NguoiDung(string id, string taiKhoan, string matKhau, string hoTen, string ngaySinh, string email, string sDT, string gioiTinh, string diaChi) : base(id, taiKhoan, matKhau, hoTen, ngaySinh, email, sDT, gioiTinh, diaChi)
        {

        }
    }
}