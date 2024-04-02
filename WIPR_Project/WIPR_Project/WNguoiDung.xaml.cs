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
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        public WNguoiDung()
        {
            InitializeComponent();


        }
        public string IdNguoiDungHienTai;
        NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnTools_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WNguoiDung_Loaded(object sender, RoutedEventArgs e)
        {
            cbbDichVu.SelectedIndex = 0;
            cbbKhuVuc.SelectedIndex = 0;
            cbbKinhNghiem.SelectedIndex = 0;
            cbbMucGia.SelectedIndex = 0;
        }
        private void Cbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                wpnlThongTin.Children.Clear();
                string khuvuc = cbbKhuVuc.SelectedItem == null ? "" : (cbbKhuVuc.SelectedItem as ComboBoxItem).Tag.ToString();
                string kinhnghiem = cbbKinhNghiem.SelectedItem == null ? "" : (cbbKinhNghiem.SelectedItem as ComboBoxItem).Tag.ToString();
                string mucgia = cbbMucGia.SelectedItem == null ? "" : (cbbMucGia.SelectedItem as ComboBoxItem).Tag.ToString();
                string dichvu = cbbDichVu.SelectedItem == null ? "" : (cbbDichVu.SelectedItem as ComboBoxItem).Tag.ToString();

                List<BaiViet> listBaiViet = nguoiDungDAO.TruyXuatDSBaiViet(khuvuc, kinhnghiem, mucgia, dichvu, "QlyBaiViet");
                if (listBaiViet == null) return;
                string maid = "";
                foreach (BaiViet baiViet in listBaiViet)
                {
                    UCKhoiCoBan uCKhoiCoBan = new UCKhoiCoBan();
                    uCKhoiCoBan.IdBaiVietHienTai = baiViet.Id;
                    uCKhoiCoBan.txbHoTen.Text = baiViet.HoTen;
                    uCKhoiCoBan.txbKhuVuc.Text = baiViet.DiaChi;
                    uCKhoiCoBan.txbDichVu.Text = baiViet.DichVu;
                    uCKhoiCoBan.txbKinhNghiem.Text = baiViet.KinhNghiem;
                    uCKhoiCoBan.txbMucGia.Text = baiViet.MucGia;

                    uCKhoiCoBan.Height = 330;
                    uCKhoiCoBan.Width = 250;
                    uCKhoiCoBan.Margin = new Thickness(5);
                    uCKhoiCoBan.IdDoiTuonggHienTai = IdNguoiDungHienTai;
                    uCKhoiCoBan.doiTuongHT = "QlyBaiViet";
                    maid += baiViet.Id + " ";
                    wpnlThongTin.Children.Add(uCKhoiCoBan);
                }
        }
        private void cbbKhuVuc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cbb_SelectionChanged(sender, e);
        }
        private void cbbKinhNghiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cbb_SelectionChanged(sender, e);
        }
        private void cbbMucGia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cbb_SelectionChanged(sender, e);
        }

        private void cbbDichVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cbb_SelectionChanged(sender, e);
        }

        private void btnDangBai_Click(object sender, RoutedEventArgs e)
        {
            WDangBai wDangBai = new WDangBai();
            wDangBai.idDoiTuongDangNhap = IdNguoiDungHienTai;
            wDangBai.doiTuongDangNhap = "QlyNguoiDung";
            wDangBai.baiDangDoiTuong = "QlyYeuCau";
            wDangBai.ShowDialog();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
