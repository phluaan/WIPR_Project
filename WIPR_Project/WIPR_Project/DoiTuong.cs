using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class DoiTuong
    {
        private string id;
        private string taiKhoan;
        private string matKhau;
        private string hoTen;
        private string ngaySinh;
        private string email;
        private string sDT;
        private string gioiTinh;
        private string diaChi;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string NgaySinh
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

        public DoiTuong(string id, string taiKhoan, string matKhau, string hoTen, string ngaySinh, string email, string sDT, string gioiTinh, string diaChi)
        {
            this.id = id;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.email = email;
            this.sDT = sDT;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
        }
    }
}