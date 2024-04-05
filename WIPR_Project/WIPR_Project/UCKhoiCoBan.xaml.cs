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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for UCKhoiCoBan.xaml
    /// </summary>
    public partial class UCKhoiCoBan : UserControl
    {
        public UCKhoiCoBan()
        {
            InitializeComponent();
        }
        public Account userAccount = new Account();
        public BaiViet baiViet = new BaiViet();
        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            WBaiViet wBaiViet = new WBaiViet();
            wBaiViet.userAccount = userAccount;
            wBaiViet.baiViet = baiViet;
            wBaiViet.ShowDialog();
        }

        public void UpdateUserControl(BaiViet baiViet, Account userAccount)
        {
            txbDichVu.Text = baiViet.DichVu;
            txbKinhNghiem.Text = baiViet.KinhNghiem;
            txbMucGia.Text = baiViet.MucGia;
            txbKhuVuc.Text = baiViet.KhuVuc;
            txbHoTen.Text = baiViet.TenDoiTuong;

            Height = 330;
            Width = 250;
            Margin = new Thickness(5);
            this.baiViet = baiViet;
            this.userAccount = userAccount;
        }
    }
}
