using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class BaiViet
    {
        private string id;
        private string idTho;
        private string dichVu;
        private string kinhNghiem;
        private string mucGia;
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
        public string IdTho
        {
            get { return idTho; }
            set { idTho = value; }
        }
        public string DichVu
        {
            get { return dichVu; }
            set { dichVu = value; }
        }
        public string KinhNghiem
        {
            get { return kinhNghiem; }
            set { kinhNghiem = value; }
        }
        public string MucGia
        {
            get { return mucGia; }
            set { mucGia = value; }
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
        public BaiViet()
        {

        }
        public BaiViet(string id, string idTho, string dichVu, string kinhNghiem, string mucGia, string hoTen, string ngaySinh, string email, string sDT, string gioiTinh, string diaChi)
        {
            this.id = id;
            this.idTho = idTho;
            this.dichVu = dichVu;
            this.kinhNghiem = kinhNghiem;
            this.mucGia = mucGia;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.email = email;
            this.sDT = sDT;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
        }
        public BaiViet(string id, string idTho, string dichVu, string kinhNghiem, string mucGia)
        {
            this.id = id;
            this.idTho = idTho;
            this.dichVu = dichVu;
            this.kinhNghiem = kinhNghiem;
            this.mucGia = mucGia;
        }
    }
}