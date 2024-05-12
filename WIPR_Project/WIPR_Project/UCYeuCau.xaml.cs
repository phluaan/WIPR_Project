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
    /// Interaction logic for UCYeuCau.xaml
    /// </summary>
    public partial class UCYeuCau : UserControl
    {
        public UCYeuCau()
        {
            InitializeComponent();
        }
        public Account userAccount = new Account();
        public BaiViet baiViet = new BaiViet();
        ThoDAO thoDAO = new ThoDAO();
        public void UpdateUserControl(BaiViet baiViet, Account userAccount)
        {
            txbDichVu.Text = baiViet.DichVu;
            txbKinhNghiem.Text = baiViet.KinhNghiem;
            txbMucGia.Text = baiViet.MucGia;
            txbKhuVuc.Text = baiViet.KhuVuc;
            txbHoTen.Text = baiViet.TenDoiTuong;
            DoiTuong dt = thoDAO.TruyXuatDT(baiViet.IdDoiTuong);
            txbSDT.Text = dt.SDT;
            txbMoTa.Text = baiViet.ChiTiet;

            Height = 340;
            Width = 600;
            Margin = new Thickness(15);
            this.baiViet = baiViet;
            this.userAccount = userAccount;

            if(userAccount.UserRole == "NguoiDung")
            {
                btnChinhSua.Visibility = Visibility.Visible;
                btnHenLich.Visibility = Visibility.Hidden;
            }
        }

        private void btnHenLich_Click(object sender, RoutedEventArgs e)
        {
            WLoiMoi wLoiMoi = new WLoiMoi();
            LoiMoi loiMoi = new LoiMoi(thoDAO.IdTiepTheo("RequestUser"), userAccount.Id, baiViet.IdDoiTuong, baiViet.Id, userAccount.UserRole, DateTime.Now);
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
