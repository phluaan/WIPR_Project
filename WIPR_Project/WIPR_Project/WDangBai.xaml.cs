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
        public Account userAccount = new Account();

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnDangBai_Click(object sender, RoutedEventArgs e)
        {
            DoiTuong doiTuong = doiTuongDao.TruyXuatDT(userAccount.IdInforUser);
            string postfrom = userAccount.UserRole == "Tho" ? "InforPostTho" : "InforPostNguoiDung";
            BaiViet baiViet = new BaiViet(doiTuongDao.IdTiepTheo(postfrom), userAccount.IdInforUser, doiTuong.HoTen, (cbbDichVu.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                    (cbbKinhNghiem.SelectedItem as ComboBoxItem)?.Content?.ToString(), (cbbMucGia.SelectedItem as ComboBoxItem)?.Content?.ToString(), DateTime.Now, doiTuong.DiaChi);
            doiTuongDao.ThemBaiDang(baiViet, doiTuongDao.IdTiepTheo("Posts"), postfrom);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
