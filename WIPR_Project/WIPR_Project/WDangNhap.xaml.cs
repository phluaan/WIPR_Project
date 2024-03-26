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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WTho wTho = new WTho();
            wTho.IdThoHienTai = "0";
            wTho.ShowDialog();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WNguoiDung wNguoiDung = new WNguoiDung();
            wNguoiDung.IdNguoiDungHienTai = "0";
            wNguoiDung.ShowDialog();
        }
        /*private void btnThoat_Click(object sender, RoutedEventArgs e)
{
this.Close();
}

private void btnDangNhap_Click(object sender, RoutedEventArgs e)
{
WNguoiDung wNguoiDung = new WNguoiDung();
wNguoiDung.ShowDialog();
}

private void btnDangKy_Click(object sender, RoutedEventArgs e)
{
WTho wTho = new WTho();
wTho.ShowDialog();
}*/
    }
}
