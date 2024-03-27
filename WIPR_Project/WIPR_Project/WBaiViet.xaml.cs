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
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
        public string IdBaiVietChiTiet;
        public string IdNguoiDungHienTai;
        public string IdThoHT;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BaiViet baiViet = doiTuongDAO.TruyXuat("Id = " + IdBaiVietChiTiet);
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
            IdThoHT = baiViet.IdTho;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnThue_Click(object sender, RoutedEventArgs e)
        {
            DoiTuong nguoiDung = doiTuongDAO.TruyXuat("QlyTho", IdNguoiDungHienTai);
            doiTuongDAO.GuiLoiMoi(nguoiDung, doiTuongDAO.IdTiepTheo("LoiMoi").ToString(), IdThoHT, IdBaiVietChiTiet);

        }
    }
}
