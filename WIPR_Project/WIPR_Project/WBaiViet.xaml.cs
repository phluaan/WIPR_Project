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
            txtbThue.Text = userAccount.UserRole == "Tho" ? "Apply" : "Thue";
            DoiTuong doiTuong = doiTuongDAO.TruyXuatDT(baiViet.IdDoiTuong);
            DateTime dt = Convert.ToDateTime(doiTuong.NgaySinh);
            txbHoTen.Text = baiViet.TenDoiTuong;
            txbDichVu.Text = baiViet.DichVu;
            txbDiaChi.Text = doiTuong.DiaChi;
            txbMucGia.Text = baiViet.MucGia;
            txbKinhNghiem.Text = baiViet.KinhNghiem;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnHenLich_Click(object sender, RoutedEventArgs e)
        {
            /*DateTime? selecDates = calLich.SelectedDate;
            if (selecDates.HasValue == false) selecDates = DateTime.Now;
            DateTime dt = selecDates;*/
            WLoiMoi wLoiMoi = new WLoiMoi();
            wLoiMoi.ShowDialog();

            int idTho = userAccount.UserRole == "Tho" ? userAccount.Id : baiViet.IdDoiTuong;
            int idNguoiDung = userAccount.UserRole == "NguoiDung" ? userAccount.Id : baiViet.IdDoiTuong;
            doiTuongDAO.GuiLoiMoi(doiTuongDAO.IdTiepTheo("RequestUser"), idTho, idNguoiDung, baiViet.Id, userAccount.UserRole, DateTime.Now);

        }
    }
}
