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
        public NguoiDung(int id, Account taiKhoan, string hoTen, DateTime ngaySinh, string email, string sDT, string gioiTinh, string diaChi) : base(id, taiKhoan ,hoTen, ngaySinh, email, sDT, gioiTinh, diaChi)
        {

        }
    }
}