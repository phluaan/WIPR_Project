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
            ObservableCollection<Tho> ndung = new ObservableCollection<Tho>();
        }
        public string IdThoHienTai;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
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
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

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
            wDangBai.idDoiTuongDangNhap = IdThoHienTai;
            wDangBai.doiTuongDangNhap = "QlyTho";
            wDangBai.baiDangDoiTuong = "QlyBaiViet";
            wDangBai.ShowDialog();
        }

        private void btnLoiMoi_Click(object sender, RoutedEventArgs e)
        {

            tabTimKiemTho.Visibility = Visibility.Collapsed;
            dgridLoiMoi.Visibility = Visibility.Visible;
        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            tabTimKiemTho.Visibility = Visibility.Visible;
            dgridLoiMoi.Visibility = Visibility.Collapsed;

        }
        private int userControlCount = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbbDichVu.SelectedIndex = 0;
            cbbKhuVuc.SelectedIndex = 0;
            cbbKinhNghiem.SelectedIndex = 0;
            cbbMucGia.SelectedIndex = 0;

            //Lời mời tạm thời chưa hướng đối tượng vì cần design gridLoiMoi
            conn.Open();
            string query = "SELECT * FROM LoiMoi";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgridLoiMoi.ItemsSource = dataTable.DefaultView;
            conn.Close();
        }

        private void btnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                string idNguoiDung = selectedLoiMoi["IdNguoiDung"].ToString();
                int idThue = thoDAO.IdTiepTheo("QlyThue");
                thoDAO.XacNhanThue(idThue.ToString(), idNguoiDung, IdThoHienTai);

                string idloimoi = selectedLoiMoi["Id"].ToString();
                thoDAO.Xoa("LoiMoi", idloimoi);

                //dgridLoiMoi.Items.Clear();
                //Window_Loaded(sender, e);
            }
        }

        private void btnTuChoi_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                string idloimoi = selectedLoiMoi["Id"].ToString();
                thoDAO.Xoa("LoiMoi", idloimoi);
            }
        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                string idBaiViet = selectedLoiMoi["IdBaiViet"].ToString();
                WBaiViet wBaiViet = new WBaiViet();
                wBaiViet.IdBaiVietChiTiet = idBaiViet;
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

            List<BaiViet> listBaiViet = thoDAO.TruyXuatDSBaiViet(khuvuc, kinhnghiem, mucgia, dichvu,"QlyYeuCau");
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
                uCKhoiCoBan.IdDoiTuonggHienTai = IdThoHienTai;
                uCKhoiCoBan.doiTuongHT = "QlyYeuCau";
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

        private int Index = 0;
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

            try
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
                    uCKhoiCoBan.IdBaiVietHienTai = reader["Id"].ToString();
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
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    uCKhoiCoBan.IdBaiVietHienTai = reader["Id"].ToString();
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
            }
        }
    }
}
