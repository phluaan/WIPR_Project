using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class BaiViet
    {
        private int id;
        private int idDoiTuong;
        private string tenDoiTuong;
        private string dichVu;
        private string kinhNghiem;
        private string mucGia;
        private DateTime ngayDang;
        private string khuVuc;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdDoiTuong
        {
            get { return idDoiTuong; }
            set { idDoiTuong = value; }
        }
        public string TenDoiTuong
        {
            get { return tenDoiTuong; }
            set { tenDoiTuong = value; }
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

        public DateTime NgayDang
        {
            get { return ngayDang; }
            set { ngayDang = value; }
        }
        
        public string KhuVuc
        {
            get { return khuVuc; }
            set { khuVuc = value; }
        }
        public BaiViet()
        {

        }
        public BaiViet(int id, int idDoiTuong, string tenDoiTuong, string dichVu, string kinhNghiem, string mucGia, DateTime ngayDang, string khuVuc)
        {
            this.id = id;
            this.idDoiTuong = idDoiTuong;
            this.tenDoiTuong = tenDoiTuong;
            this.dichVu = dichVu;
            this.kinhNghiem = kinhNghiem;
            this.mucGia = mucGia;
            this.ngayDang = ngayDang;
            this.khuVuc = khuVuc;
        }
    }
}