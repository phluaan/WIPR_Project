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
        ThoDAO thoDAO = new ThoDAO();

        public string IdThoDangNhap;
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
            DoiTuong tho = thoDAO.TruyXuat("QlyTho", IdThoDangNhap);
            BaiViet baiViet = new BaiViet(thoDAO.IdTiepTheo("QlyBaiViet").ToString(), IdThoDangNhap, (cbbDichVu.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                    (cbbKinhNghiem.SelectedItem as ComboBoxItem)?.Content?.ToString(), (cbbMucGia.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                    tho.HoTen, tho.NgaySinh, tho.Email, tho.SDT, tho.GioiTinh, tho.DiaChi);
            thoDAO.ThemBaiDang(baiViet);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
