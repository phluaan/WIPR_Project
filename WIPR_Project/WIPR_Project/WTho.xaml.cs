using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for WTho.xaml
    /// </summary>
    public partial class WTho : Window
    {
        public WTho()
        {
            InitializeComponent();
        }
        public Account userAccount = new Account();
        ThoDAO thoDAO = new ThoDAO();
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    gridThongTinChiTiet.Height = 470;
                    gridThongTinChiTiet.Width = 830;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    gridThongTinChiTiet.Height = 620;
                    gridThongTinChiTiet.Width = 1300;
                    IsMaximized = true;
                }
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnDangBai_Click(object sender, RoutedEventArgs e)
        {
            WDangBai wDangBai = new WDangBai();
            wDangBai.userAccount = userAccount;
            wDangBai.ShowDialog();
        }

        private void btnLoiMoi_Click(object sender, RoutedEventArgs e)
        {
            HiddenTab(sender, e);
            dgridLoiMoi.Visibility = Visibility.Visible;
            LoadLoiMoi(sender, e);
        }
        private void LoadLoiMoi(object sender, RoutedEventArgs e)
        {
            dgridLoiMoi.ItemsSource = thoDAO.TruyXuatLoiMoi(userAccount.IdInforUser, userAccount.UserRole).DefaultView;
        }
        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            HiddenTab(sender, e);
            tabTimKiemTho.Visibility = Visibility.Visible;
        }
        private void btnTienDo_Click(object sender, RoutedEventArgs e)
        {
            HiddenTab(sender, e);
            tabTienDo.Visibility = Visibility.Visible;
            dgridTienDo.Visibility = Visibility.Visible;
            tabTienDo.SelectedIndex = 0;
        }
        private void tabTienDo_SelectionChanged(object sender, RoutedEventArgs e)
        {
            LoadTienDo((tabTienDo.SelectedItem as TabItem).Tag.ToString());
        }
        private void LoadTienDo(string tiendo)
        {
            dgridTienDo.ItemsSource = thoDAO.TruyXuatNgayLamViec(userAccount.IdInforUser, tiendo, userAccount.UserRole).DefaultView;
        }
        private void HiddenTab(object sender, RoutedEventArgs e)
        {
            tabTimKiemTho.Visibility = Visibility.Hidden;
            dgridLoiMoi.Visibility = Visibility.Hidden;
            tabTienDo.Visibility = Visibility.Hidden;
            dgridTienDo.Visibility = Visibility.Hidden;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbbDichVu.SelectedIndex = 0;
            cbbKhuVuc.SelectedIndex = 0;
            cbbKinhNghiem.SelectedIndex = 0;
            cbbMucGia.SelectedIndex = 0;
        }
        private void cbCheck_Checked(object sender, RoutedEventArgs e)
        {
            if(tabTienDo.SelectedIndex == 2)
            {
                WDanhGia wDanhGia = new WDanhGia();
                var selectedLoiMoi = dgridTienDo.SelectedItem as DataRowView;
                int idNguoiDung = Convert.ToInt32(selectedLoiMoi["idNguoiDung"]);
                int idDanhGia = Convert.ToInt32(selectedLoiMoi["idEvaluation"]);
                wDanhGia.idNguoiDung = idNguoiDung;
                wDanhGia.idTho = userAccount.IdInforUser;
                wDanhGia.idDanhGia = idDanhGia;
                wDanhGia.userRole = userAccount.UserRole;
                wDanhGia.ShowDialog();
                return;
            }
            if (dgridTienDo.SelectedItem != null)
            {
                var selectedLoiMoi = dgridTienDo.SelectedItem as DataRowView;
                int idNgayLamViec = Convert.ToInt32(selectedLoiMoi["id"]);
                string tiendo = selectedLoiMoi["progress"].ToString() == "ChuaBatDau" ? "DangTienHanh" : "DaHoanThanh";
                thoDAO.Sua("dateWork", idNgayLamViec, $" progress = '{tiendo}' ");

                LoadTienDo((tabTienDo.SelectedItem as TabItem).Tag.ToString());
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
                int idNgayLamViec = thoDAO.IdTiepTheo("dateWork");
                int idNgayBan = thoDAO.IdTiepTheo("busyDate");
                thoDAO.XacNhan(idNgayLamViec, userAccount.IdInforUser, idNguoiDung, dichvu, ngayLamViec, idNgayBan);

                btnTuChoi_Click(sender, e);
            }
        }

        private void btnTuChoi_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                string idloimoi = selectedLoiMoi["id"].ToString();
                thoDAO.Xoa("RequestUser", idloimoi);
                LoadLoiMoi(sender, e);
            }
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                int idBaiViet = Convert.ToInt32(selectedLoiMoi["idPost"]);
                BaiViet bviet = thoDAO.TruyXuatBV(idBaiViet, "InforPostTho");

                WBaiViet wBaiViet = new WBaiViet();
                wBaiViet.baiViet = bviet;
                wBaiViet.userAccount = userAccount;
                wBaiViet.ShowDialog();
            }
        }
        private void Cbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wpnlThongTin.Children.Clear();
            string khuvuc = cbbKhuVuc.SelectedItem == null ? "" : (cbbKhuVuc.SelectedItem as ComboBoxItem).Tag.ToString();
            string kinhnghiem = cbbKinhNghiem.SelectedItem == null ? "" : (cbbKinhNghiem.SelectedItem as ComboBoxItem).Tag.ToString();
            string mucgia = cbbMucGia.SelectedItem == null ? "" : (cbbMucGia.SelectedItem as ComboBoxItem).Tag.ToString();
            string dichvu = cbbDichVu.SelectedItem == null ? "" : (cbbDichVu.SelectedItem as ComboBoxItem).Tag.ToString();

            List<BaiViet> listBaiViet = thoDAO.TruyXuatDSBaiViet(khuvuc, kinhnghiem, mucgia, dichvu, "InforPostNguoiDung");
            if (listBaiViet == null) return;
            foreach (BaiViet baiViet in listBaiViet)
            {
                UCYeuCau uCYeuCau = new UCYeuCau();
                uCYeuCau.UpdateUserControl(baiViet, userAccount);

                wpnlThongTin.Children.Add(uCYeuCau);
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


        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

            /*try
            {
                if (Index > 0)
                {
                    Index -= 6;
                }
                else return;
                conn.Open();
                int currentIndexMax = Index + 6;
                wpnlThongTin.Children.Clear();

                string sqlSTR = "SELECT * FROM QLyBaiViet";
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                int currentIndex = 0;
                while (reader.Read())
                {
                    UCKhoiCoBan uCKhoiCoBan = new UCKhoiCoBan();
                    uCKhoiCoBan.txbHoTen.Text = reader["HoTen"].ToString();
                    uCKhoiCoBan.txbKhuVuc.Text = reader["DiaChi"].ToString();
                    uCKhoiCoBan.txbDichVu.Text = reader["DichVu"].ToString();
                    uCKhoiCoBan.txbKinhNghiem.Text = reader["KinhNghiem"].ToString();
                    uCKhoiCoBan.txbMucGia.Text = reader["MucGia"].ToString();

                    uCKhoiCoBan.Height = 400;
                    uCKhoiCoBan.Width = 350;
                    uCKhoiCoBan.Margin = new Thickness(5);
                    if (currentIndex >= Index && currentIndex < currentIndexMax)
                    {
                        wpnlThongTin.Children.Add(uCKhoiCoBan);
                    }
                    currentIndex++;
                }
                reader.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Lỗi: " + exc.Message);
            }
            finally
            {
                conn.Close();
            }*/
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           /* try
            {
                Index += 6;
                wpnlThongTin.Children.Clear();
                conn.Open();
                string sqlSTR = "SELECT * FROM QLyBaiViet";
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                int currentIndex = 0;
                while (reader.Read())
                {
                    UCKhoiCoBan uCKhoiCoBan = new UCKhoiCoBan();
                    uCKhoiCoBan.txbHoTen.Text = reader["HoTen"].ToString();
                    uCKhoiCoBan.txbKhuVuc.Text = reader["DiaChi"].ToString();
                    uCKhoiCoBan.txbDichVu.Text = reader["DichVu"].ToString();
                    uCKhoiCoBan.txbKinhNghiem.Text = reader["KinhNghiem"].ToString();
                    uCKhoiCoBan.txbMucGia.Text = reader["MucGia"].ToString();

                    uCKhoiCoBan.Height = 400;
                    uCKhoiCoBan.Width = 350;
                    uCKhoiCoBan.Margin = new Thickness(5);
                    if (currentIndex >= Index && currentIndex < Index + 6)
                    {
                        wpnlThongTin.Children.Add(uCKhoiCoBan);
                    }
                    currentIndex++;
                }
                reader.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Lỗi: " + exc.Message);
            }
            finally
            {
                conn.Close();
            }*/
        }

        private void btnLichLamViec_Click(object sender, RoutedEventArgs e)
        {
            WLichBan wLichBan = new WLichBan();
            wLichBan.ShowDialog();
        }
    }
}
