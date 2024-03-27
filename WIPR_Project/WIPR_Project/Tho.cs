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
        public Tho(string id, string taiKhoan, string matKhau, string hoTen, string ngaySinh, string email, string sDT, string gioiTinh, string diaChi) : base(id, taiKhoan, matKhau, hoTen, ngaySinh, email, sDT, gioiTinh, diaChi)
        {

        }

    }
}