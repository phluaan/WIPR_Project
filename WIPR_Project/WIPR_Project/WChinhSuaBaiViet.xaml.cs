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

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for WChinhSuaBaiViet.xaml
    /// </summary>
    public partial class WChinhSuaBaiViet : Window
    {
        public WChinhSuaBaiViet()
        {
            InitializeComponent();
        }
        public BaiViet baiViet = new BaiViet();
        public Account userAccount = new Account();
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            if (!checkNull())
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!");
                return;
            }
            baiViet.DichVu = (cbbDichVu.SelectedItem as ComboBoxItem)?.Content?.ToString();
            baiViet.KinhNghiem = (cbbKinhNghiem.SelectedItem as ComboBoxItem)?.Content?.ToString();
            baiViet.MucGia = (cbbMucGia.SelectedItem as ComboBoxItem)?.Content?.ToString();
            baiViet.ChiTiet = txtChiTiet.Text;

            string table = userAccount.UserRole == "Tho" ? "InforPostTho" : "InforPostNguoiDung";
            doiTuongDAO.SuaBaiViet(table, baiViet);
            btnThoat_Click(sender, e);
        }
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool checkNull()
        {
            if (cbbDichVu.SelectedValue == null || cbbDichVu.SelectedValue == null || cbbDichVu.SelectedValue == null)
                return false;
            return true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
