using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
namespace WIPR_Project
{
    public partial class WNguoiDung : Window
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public WNguoiDung()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            ObservableCollection<NguoiDung>  ndung = new ObservableCollection<NguoiDung>();


            ndung.Add(new NguoiDung { Id ="0", TaiKhoan="0", MatKhau="0",HoTen="Luan", NgaySinh=DateTime.Now, Email = "asdasd", SDT = "123" , GioiTinh = "Nam",DiaChi = "KT" });
            thosDataGrid.ItemsSource = ndung;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    
                    IsMaximized = true;
                }
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnTimTho_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThoDangThue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoiMoiDaGui_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEye_Click(object sender, RoutedEventArgs e)
        {
            UCBaiViet ucBaiViet = new UCBaiViet();
            thosDataGrid.Visibility = Visibility.Hidden;
            gThongTinChiTiet.Visibility = Visibility.Visible;
            gThongTinChiTiet.Children.Add(ucBaiViet);
            ucBaiViet.btnThoat.Click += btnThoatBaiViet;
        }
        private void btnThoatBaiViet(object sender, RoutedEventArgs e)
        {
            thosDataGrid.Visibility = Visibility.Visible;
            gThongTinChiTiet.Visibility= Visibility.Hidden;
        }
    }
}
