using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WIPR_Project
{
    public class Tho : DoiTuong
    {
        public Tho() { }
        public Tho(int id, Account taiKhoan, string hoTen, DateTime ngaySinh, string email, string sDT, string gioiTinh, string diaChi) : base(id, taiKhoan, hoTen, ngaySinh, email, sDT, gioiTinh, diaChi)
        {

        }

    }
}