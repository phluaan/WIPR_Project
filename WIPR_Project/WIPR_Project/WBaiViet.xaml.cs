using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for WBaiViet.xaml
    /// </summary>
    public partial class WBaiViet : Window
    {
        public WBaiViet()
        {
            InitializeComponent();
            
        }
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
        public string IdBaiVietChiTiet;
        public string IdDoiTuonggHienTai;
        public string doiTuongHT;
        public string idNguoiDangBai;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtbThue.Text = doiTuongHT == "QlyBaiViet" ? "Thue" : "Apply";

            BaiViet baiViet = doiTuongDAO.TruyXuatBV("Id = " + IdBaiVietChiTiet, doiTuongHT);
            DateTime dt = Convert.ToDateTime(baiViet.NgaySinh);
            txbHoTen.Text = baiViet.HoTen;
            txbNgaySinh.Text = dt.ToString("dd/MM/yyyy");
            txbGioiTinh.Text = baiViet.GioiTinh;
            txbSDT.Text = baiViet.SDT;
            txbEmail.Text = baiViet.Email;
            txbDichVu.Text = baiViet.DichVu;
            txbDiaChi.Text = baiViet.DiaChi;
            txbMucGia.Text = baiViet.MucGia;
            txbKinhNghiem.Text = baiViet.KinhNghiem;
            idNguoiDangBai = baiViet.IdDoiTuong;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnThue_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selecDates = calLich.SelectedDate;
            if (selecDates.HasValue == false) selecDates = DateTime.Now;
            string table = doiTuongHT == "QlyBaiViet" ? "QlyTho" : "QlyNguoiDung";
            string trangThai = doiTuongHT == "QlyBaiViet" ? "Thue" : "Apply";
            DoiTuong doiTuong = doiTuongDAO.TruyXuatDT(table, IdDoiTuonggHienTai);
            doiTuongDAO.GuiLoiMoi(doiTuong, doiTuongDAO.IdTiepTheo("LoiMoi").ToString(), idNguoiDangBai, IdBaiVietChiTiet, trangThai, selecDates.ToString(), txbDichVu.Text);

        }

        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            calLich.Visibility = Visibility.Visible;
        }
    }
}
