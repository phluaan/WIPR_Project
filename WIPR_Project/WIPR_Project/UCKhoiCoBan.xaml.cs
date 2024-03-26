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
        public string IdBaiVietHienTai;
        public string IdNguoiDungHienTai;
        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            WBaiViet wBaiViet = new WBaiViet();
            wBaiViet.IdBaiVietChiTiet = IdBaiVietHienTai;
            wBaiViet.IdNguoiDungHienTai = IdNguoiDungHienTai;
            wBaiViet.ShowDialog();
        }
    }
}
