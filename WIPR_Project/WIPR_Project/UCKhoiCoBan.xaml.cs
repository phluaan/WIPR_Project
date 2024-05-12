using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
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
        NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        public int luotThue = 0;
        public decimal danhGiaTB;
        public int IDYeuThich;

        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            WBaiViet wBaiViet = new WBaiViet();
            wBaiViet.userAccount = userAccount;
            wBaiViet.baiViet = baiViet;
            wBaiViet.ShowDialog();
        }

        public void UpdateUserControl(BaiViet baiViet, Account userAccount)
        {
            txbtest.Text = nguoiDungDAO.LuotThue(baiViet.IdDoiTuong, baiViet.DichVu).ToString();

            txbDichVu.Text = baiViet.DichVu;
            txbKinhNghiem.Text = baiViet.KinhNghiem;
            txbMucGia.Text = baiViet.MucGia;
            txbKhuVuc.Text = baiViet.KhuVuc;
            txbHoTen.Text = baiViet.TenDoiTuong;

            decimal tongSoSao = nguoiDungDAO.TongSoSaoTheoCongViec(baiViet.IdDoiTuong, baiViet.DichVu);
            if (tongSoSao == 6)
            {
                txbDanhGia.Text = "...";
            }
            else
            {
                txbDanhGia.Text = tongSoSao.ToString("0.#");
                this.danhGiaTB = tongSoSao;
            }

            Height = 300;
            Width = 300;
            Margin = new Thickness(10);
            this.baiViet = baiViet;
            this.userAccount = userAccount;
            this.luotThue = nguoiDungDAO.LuotThue(baiViet.IdDoiTuong, baiViet.DichVu);
            YeuThich(baiViet,  userAccount);
        }
        private void YeuThich(BaiViet baiViet, Account userAccount)
        {
            IDYeuThich = nguoiDungDAO.CheckYeuThich(baiViet.Id, userAccount.IdInforUser);
            if (IDYeuThich == -1)
            {
                icbtnYeuThich.Kind = PackIconMaterialKind.HeartCircleOutline;
            }
            else
            {
                icbtnYeuThich.Kind = PackIconMaterialKind.HeartCircle;
            }
        }
        
        private void btnYeuThich_Click(object sender, RoutedEventArgs e)
        {
            if (IDYeuThich == -1)
            {
                nguoiDungDAO.ThemYeuThich(nguoiDungDAO.IdTiepTheo("Favourite"), userAccount.IdInforUser, baiViet.Id);
            }
            else
            {   
                nguoiDungDAO.Xoa("Favourite", IDYeuThich.ToString());
            }
            YeuThich(baiViet, userAccount);
        }
    }
}
