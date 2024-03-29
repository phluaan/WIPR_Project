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
            string table = doiTuongHT == "QlyBaiViet" ? "QlyTho" : "QlyNguoiDung";
            string trangThai = doiTuongHT == "QlyBaiViet" ? "NguoiDungThueTho" : "ThoApplyNguoiDung";
            DoiTuong doiTuong = doiTuongDAO.TruyXuatDT(table, IdDoiTuonggHienTai);
            doiTuongDAO.GuiLoiMoi(doiTuong, doiTuongDAO.IdTiepTheo("LoiMoi").ToString(), idNguoiDangBai, IdBaiVietChiTiet, trangThai);
        }
        
        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            Calendar cal = new Calendar();

            StackPanel stkpanelCal = new StackPanel();
            stkpanelCal.Width = 200;


            cal.Height = 170;
            cal.Width = 200;
            cal.HorizontalAlignment = HorizontalAlignment.Left;
            cal.VerticalAlignment = VerticalAlignment.Top;
            cal.DisplayMode = CalendarMode.Decade;
            cal.IsTodayHighlighted = true;
            cal.SelectionMode = CalendarSelectionMode.MultipleRange;
            cal.Foreground = Brushes.White;

            CalendarDateRange range1 = new CalendarDateRange(new DateTime(2024, 3, 1), new DateTime(2024, 3, 7));
            CalendarDateRange range2 = new CalendarDateRange(new DateTime(2024, 3, 8), new DateTime(2024, 3, 8));
            CalendarDateRange range3 = new CalendarDateRange(new DateTime(2024, 3, 15), new DateTime(2024, 3, 15));
            CalendarDateRange range4 = new CalendarDateRange(new DateTime(2024, 3, 22), new DateTime(2024, 3, 22));
            CalendarDateRange range5 = new CalendarDateRange(new DateTime(2024, 3, 29), new DateTime(2024, 3, 29));

            cal.BlackoutDates.Add(range1);
            cal.BlackoutDates.Add(range2);
            cal.BlackoutDates.Add(range3);
            cal.BlackoutDates.Add(range4);
            cal.BlackoutDates.Add(range5);

            cal.BorderThickness = new Thickness(3);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = new Point(0, 0);
            linearGradientBrush.EndPoint = new Point(1, 1);
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            cal.BorderBrush = linearGradientBrush;

            Button btnLoiMoi = new Button();
            btnLoiMoi.Content = "Gửi lời mời";
            btnLoiMoi.FontSize = 16;
            btnLoiMoi.Background = new SolidColorBrush(Color.FromRgb(67, 67, 226));
            btnLoiMoi.Foreground = Brushes.White;
            btnLoiMoi.Height = 30;
            btnLoiMoi.Width = 120;

            stkpanelCal.Margin = new Thickness(btnCal.Margin.Left, btnCal.Margin.Top + btnCal.ActualHeight, 0, 0);

            stkpanelCal.Children.Add(cal);
            stkpanelCal.Children.Add(btnLoiMoi);
            gridBaiviet.Children.Add(stkpanelCal);
        }
    }
}
