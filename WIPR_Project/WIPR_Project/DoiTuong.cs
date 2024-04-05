using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class DoiTuong
    {
        private int id;
        private Account taiKhoan;
        private string hoTen;
        private DateTime ngaySinh;
        private string email;
        private string sDT;
        private string gioiTinh;
        private string diaChi;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Account TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string SDT
        {
            get { return sDT; }
            set { sDT = value; }
        }
        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public DoiTuong()
        {

        }

        public DoiTuong(int id, Account taiKhoan,string hoTen, DateTime ngaySinh, string email, string sDT, string gioiTinh, string diaChi)
        {
            this.id = id;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.email = email;
            this.sDT = sDT;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.taiKhoan = taiKhoan;
        }
    }
}