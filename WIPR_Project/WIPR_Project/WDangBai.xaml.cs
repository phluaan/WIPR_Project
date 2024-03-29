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
using System.Windows.Markup;

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for WDangBai.xaml
    /// </summary>
    public partial class WDangBai : Window
    {
        public WDangBai()
        {
            InitializeComponent();
        }
        DoiTuongDAO doiTuongDao = new DoiTuongDAO();

        public string idDoiTuongDangNhap;
        public string doiTuongDangNhap;
        public string baiDangDoiTuong;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnDangBai_Click(object sender, RoutedEventArgs e)
        {
            DoiTuong doiTuong = doiTuongDao.TruyXuatDT(doiTuongDangNhap, idDoiTuongDangNhap);
            BaiViet baiViet = new BaiViet(doiTuongDao.IdTiepTheo(baiDangDoiTuong).ToString(), idDoiTuongDangNhap, (cbbDichVu.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                    (cbbKinhNghiem.SelectedItem as ComboBoxItem)?.Content?.ToString(), (cbbMucGia.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                    doiTuong.HoTen, doiTuong.NgaySinh, doiTuong.Email, doiTuong.SDT, doiTuong.GioiTinh, doiTuong.DiaChi);
            doiTuongDao.ThemBaiDang(baiViet, baiDangDoiTuong);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
