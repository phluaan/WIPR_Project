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
using System.Data.Common;

namespace WIPR_Project
{
    public partial class WNguoiDung : Window
    {
        public WNguoiDung()
        {
            InitializeComponent();
            
        }
        public Account userAccount = new Account();
        NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        List<UCKhoiCoBan> listUCKhoiCoBan = new List<UCKhoiCoBan>();
        List<UCYeuCau> listUCYeuCau = new List<UCYeuCau>();
        private void LoadThongTinGiaoDien(int id)
        {
            DoiTuong doiTuong = nguoiDungDAO.TruyXuatDT(id);
            txbName.Text = doiTuong.HoTen;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount ==2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    gridThongTinChiTiet.Height = 530;
                    gridThongTinChiTiet.Width = 830;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    gridThongTinChiTiet.Height = 670;
                    gridThongTinChiTiet.Width = 1300;
                    IsMaximized = true;
                }
            }
        }
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnLoiMoi_Click(object sender, RoutedEventArgs e)
        {
            HiddenTab(sender, e);
            dgridLoiMoi.Visibility = Visibility.Visible;
            LoadLoiMoi(sender, e);
        }
        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            HiddenTab(sender, e);
            wpnlTimKiem.Visibility = Visibility.Visible;
            tabYeuCauNguoiDung.Visibility = Visibility.Visible;
            UploadUCKhoiCoBan();
        }
        private void btnTienDo_Click(object sender, RoutedEventArgs e)
        {
            HiddenTab(sender, e);
            tabTienDo.Visibility = Visibility.Visible;
            dgridTienDo.Visibility = Visibility.Visible;
            tabTienDo.SelectedIndex = 0;
        }
        private void LoadLoiMoi(object sender, RoutedEventArgs e)
        {
            dgridLoiMoi.ItemsSource = nguoiDungDAO.TruyXuatLoiMoi(userAccount.IdInforUser, userAccount.UserRole).DefaultView;
        }

        private void HiddenTab(object sender, RoutedEventArgs e)
        {
            tabYeuCauNguoiDung.Visibility = Visibility.Hidden;
            dgridLoiMoi.Visibility = Visibility.Hidden;
            tabTienDo.Visibility = Visibility.Hidden;
            dgridTienDo.Visibility = Visibility.Hidden;
        }
        private void tabTienDo_SelectionChanged(object sender, RoutedEventArgs e)
        {
            LoadTienDo((tabTienDo.SelectedItem as TabItem).Tag.ToString());
        }
        private void LoadTienDo(string tiendo)
        {
            dgridTienDo.ItemsSource = nguoiDungDAO.TruyXuatNgayLamViec(userAccount.IdInforUser, tiendo, userAccount.UserRole).DefaultView;
        }
        private void cbCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabTienDo.SelectedIndex == 2)
            {
                WDanhGia wDanhGia = new WDanhGia();
                var selectedLoiMoi = dgridTienDo.SelectedItem as DataRowView;
                int idTho = Convert.ToInt32(selectedLoiMoi["idTho"]);
                int idNgayLamViec = Convert.ToInt32(selectedLoiMoi["id"]);
                int idDanhGia = Convert.ToInt32(selectedLoiMoi["idEvaluation"]);
                wDanhGia.idTho = idTho;
                wDanhGia.idNguoiDung = userAccount.IdInforUser;
                wDanhGia.idNgayLamViec = idNgayLamViec;
                wDanhGia.userRole = userAccount.UserRole;
                wDanhGia.idDanhGia = idDanhGia;
                wDanhGia.ShowDialog();
                return;
            }
        }

        private void btnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                int idNguoiDung = Convert.ToInt32(selectedLoiMoi["idNguoiDung"]);
                DateTime ngayLamViec = Convert.ToDateTime(selectedLoiMoi["dateWork"]);
                string dichvu = selectedLoiMoi["job"].ToString();
                int idNgayLamViec = nguoiDungDAO.IdTiepTheo("dateWork");
                int idNgayBan = nguoiDungDAO.IdTiepTheo("busyDate");
                string mucgia = selectedLoiMoi["price"].ToString();
                nguoiDungDAO.XacNhan(idNgayLamViec, userAccount.IdInforUser, idNguoiDung, dichvu, ngayLamViec, idNgayBan, mucgia);

                btnTuChoi_Click(sender, e);
            }
        }

        private void btnTuChoi_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                string idloimoi = selectedLoiMoi["id"].ToString();
                nguoiDungDAO.Xoa("RequestUser", idloimoi);
                LoadLoiMoi(sender, e);
            }
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                int idBaiViet = Convert.ToInt32(selectedLoiMoi["idPost"]);
                BaiViet bviet = nguoiDungDAO.TruyXuatBV(idBaiViet, "InforPostTho");

                WBaiViet wBaiViet = new WBaiViet();
                wBaiViet.baiViet = bviet;
                wBaiViet.userAccount = userAccount;
                wBaiViet.ShowDialog();
            }
        }

        private void WNguoiDung_Loaded(object sender, RoutedEventArgs e)
        {
            cbbDichVu.SelectedIndex = 0;
            cbbKhuVuc.SelectedIndex = 0;
            cbbKinhNghiem.SelectedIndex = 0;
            cbbMucGia.SelectedIndex = 0;

            LoadThongTinGiaoDien(userAccount.IdInforUser);
        }
        private void Cbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listUCKhoiCoBan.Clear();
            string khuvuc = cbbKhuVuc.SelectedItem == null ? "" : (cbbKhuVuc.SelectedItem as ComboBoxItem).Tag.ToString();
            string kinhnghiem = cbbKinhNghiem.SelectedItem == null ? "" : (cbbKinhNghiem.SelectedItem as ComboBoxItem).Tag.ToString();
            string mucgia = cbbMucGia.SelectedItem == null ? "" : (cbbMucGia.SelectedItem as ComboBoxItem).Tag.ToString();
            string dichvu = cbbDichVu.SelectedItem == null ? "" : (cbbDichVu.SelectedItem as ComboBoxItem).Tag.ToString();

            List<BaiViet> ListBaiViet = nguoiDungDAO.TruyXuatDSBaiViet(khuvuc, kinhnghiem, mucgia, dichvu, "InforPostTho");
            if (ListBaiViet == null) return;
            foreach (BaiViet baiViet in ListBaiViet)
            {
                UCKhoiCoBan uCKhoiCoBan = new UCKhoiCoBan();
                uCKhoiCoBan.UpdateUserControl(baiViet, userAccount);

                listUCKhoiCoBan.Add(uCKhoiCoBan);
            }
            cbbSapXep_SelectionChanged(sender, e);
        }
        private void cbbSapXep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbSapXep.SelectedIndex == 1)
            {
                listUCKhoiCoBan.Sort((x, y) => y.luotThue.CompareTo(x.luotThue));
            }
            else if (cbbSapXep.SelectedIndex == 2)
            {
                listUCKhoiCoBan.Sort((x, y) => y.danhGiaTB.CompareTo(x.danhGiaTB));
            }
            UploadUCKhoiCoBan();
        }
        private void UploadUCKhoiCoBan()
        {
            wpnlThongTin.Children.Clear();
            foreach (UCKhoiCoBan uc in listUCKhoiCoBan)
            {
                wpnlThongTin.Children.Add(uc);
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
            wDangBai.userAccount = userAccount;
            wDangBai.ShowDialog();
        }
        private void btnLichLamViec_Click(object sender, RoutedEventArgs e)
        {
            WLichBan wLichBan = new WLichBan();
            wLichBan.ShowDialog();
        }

        private void btnTranngCaNhan_Click(object sender, RoutedEventArgs e)
        {
            wpnlTimKiem.Visibility = Visibility.Hidden;
            listUCYeuCau.Clear();
            List<BaiViet> ListBaiViet = nguoiDungDAO.TruyXuatBaiVietCaNhan(userAccount.IdInforUser, "InforPostNguoiDung");
            if (ListBaiViet == null) return;
            foreach (BaiViet baiViet in ListBaiViet)
            {
                UCYeuCau uCYeuCau = new UCYeuCau();
                uCYeuCau.UpdateUserControl(baiViet, userAccount);

                listUCYeuCau.Add(uCYeuCau);
            }
            UploadUCYeuCau();
        }
        private void UploadUCYeuCau()
        {
            wpnlThongTin.Children.Clear();
            foreach (UCYeuCau uc in listUCYeuCau)
            {
                wpnlThongTin.Children.Add(uc);
            }
        }

        private void btnThoYeuThich_Click(object sender, RoutedEventArgs e)
        {
            wpnlThongTin.Children.Clear();
            foreach (UCKhoiCoBan uc in listUCKhoiCoBan)
            {
                if(uc.IDYeuThich != -1)
                    wpnlThongTin.Children.Add(uc);
            }
        }
    }
}
