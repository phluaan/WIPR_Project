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
            if (userAccount.UserRole == "Tho") btnHenLich.Visibility = Visibility.Hidden;
        }
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
        public Account userAccount = new Account();
        public BaiViet baiViet = new BaiViet();

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDanhGia();
            CapNhatBaiViet(sender, e);
        }
        private void LoadDanhGia()
        {
            wpnlDanhGia.Children.Clear();

            List<DanhGia> list = doiTuongDAO.TruyXuatDSDanhGia(baiViet.IdDoiTuong, baiViet.DichVu);
            if (list == null) return;
            foreach (DanhGia dg in list)
            {
                UCNhanXet uCNhanXet = new UCNhanXet();
                uCNhanXet.UpdateUserControl(dg);

                wpnlDanhGia.Children.Add(uCNhanXet);
            }
        }
        private void CapNhatBaiViet(object sender, RoutedEventArgs e)
        {
            DoiTuong doiTuong = doiTuongDAO.TruyXuatDT(baiViet.IdDoiTuong);
            txbHoTen.Text = baiViet.TenDoiTuong;
            txbDichVu.Text = baiViet.DichVu;
            txbDiaChi.Text = doiTuong.DiaChi;
            txbMucGia.Text = baiViet.MucGia;
            txbKinhNghiem.Text = baiViet.KinhNghiem;
            decimal tongSoSao = doiTuongDAO.TongSoSaoTheoCongViec(baiViet.IdDoiTuong, baiViet.DichVu);
            if (tongSoSao == 6)
                txbDanhGia.Text = "...";
            else
                txbDanhGia.Text = tongSoSao.ToString("0.#");

            if(userAccount.UserRole == "Tho")
            {
                btnChinhSua.Visibility = Visibility.Visible;
                btnHenLich.Visibility = Visibility.Hidden;
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnHenLich_Click(object sender, RoutedEventArgs e)
        {
            WLoiMoi wLoiMoi = new WLoiMoi();
            LoiMoi loiMoi = new LoiMoi(doiTuongDAO.IdTiepTheo("RequestUser"), baiViet.IdDoiTuong, userAccount.Id, baiViet.Id, userAccount.UserRole, DateTime.Now);
            wLoiMoi.loiMoi = loiMoi;
            wLoiMoi.ShowDialog();
        }

        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
            WChinhSuaBaiViet wChinhSuaBaiViet = new WChinhSuaBaiViet();
            wChinhSuaBaiViet.baiViet = baiViet;
            wChinhSuaBaiViet.userAccount = userAccount;
            wChinhSuaBaiViet.ShowDialog();
        }
    }
}
