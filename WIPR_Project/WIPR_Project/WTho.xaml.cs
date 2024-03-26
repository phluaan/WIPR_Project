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
            wDangBai.IdThoDangNhap = IdThoHienTai;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlSTR = "SELECT * FROM QLyBaiViet";
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);

                SqlDataReader reader = cmd.ExecuteReader();
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
                    wpnlThongTin.Children.Add(uCKhoiCoBan);

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
                try
                {
                    conn.Open();

                    string getMaxIdQuery = "SELECT MAX(CAST(Id AS INT)) FROM QlyThue";
                    SqlCommand getMaxId = new SqlCommand(getMaxIdQuery, conn);
                    object maxIdResult = getMaxId.ExecuteScalar();
                    int nextId = 0;
                    if (maxIdResult != DBNull.Value)
                    {
                        int maxId = Convert.ToInt32(maxIdResult);
                        nextId = maxId + 1;
                    }

                    string sqlSTR = string.Format("INSERT INTO QlyThue (Id, IdNguoiDung, IdTho) " +
                        "VALUES ('{0}', '{1}', '{2}')",
                        nextId.ToString(), idNguoiDung, IdThoHienTai);

                    SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show("Thành công");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("that bai " + exc);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void btnTuChoi_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                string idLoiMoi = selectedLoiMoi["Id"].ToString();
                try
                {
                    conn.Open();
                    string sqlSTR = string.Format("DELETE FROM LoiMoi WHERE Id = '{0}'", idLoiMoi);
                    SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show("thanh cong");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("that bai " + exc);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("");
            }

        }

        private void btnChiTiet_Click(object sender, RoutedEventArgs e)
        {
            if (dgridLoiMoi.SelectedItem != null)
            {
                var selectedLoiMoi = dgridLoiMoi.SelectedItem as DataRowView;
                string idBaiViet = selectedLoiMoi["Id"].ToString();
                MessageBox.Show($"Chi tiết của bài viết có IdBaiViet = {idBaiViet}");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xem chi tiết.");
            }
        }
        private void cbbKhuVuc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbKhuVuc.SelectedIndex != 0)
            {
                string selectedOption = (cbbKhuVuc.SelectedItem as ComboBoxItem).Content.ToString();
                string sqlSTR = $"SELECT * FROM QLyBaiViet WHERE DiaChi = N'{selectedOption}'";
                ThucThi(sqlSTR);
            }

        }
        private void cbbKinhNghiem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbKinhNghiem.SelectedIndex != 0)
            {
                string selectedOption = (cbbKinhNghiem.SelectedItem as ComboBoxItem).Content.ToString();
                string sqlSTR = $"SELECT * FROM QLyBaiViet WHERE KinhNghiem = N'{selectedOption}'";
                ThucThi(sqlSTR);
            }
        }
        private void cbbMucGia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbMucGia.SelectedIndex != 0)
            {
                string selectedOption = (cbbMucGia.SelectedItem as ComboBoxItem).Content.ToString();
                string sqlSTR = $"SELECT * FROM QLyBaiViet WHERE MucGia = N'{selectedOption}'";
                ThucThi(sqlSTR);
            }
        }

        private void cbbDichVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbDichVu.SelectedIndex != 0)
            {
                string selectedOption = (cbbDichVu.SelectedItem as ComboBoxItem).Content.ToString();
                string sqlSTR = $"SELECT * FROM QLyBaiViet WHERE DichVu = N'{selectedOption}'";
                ThucThi(sqlSTR);
            }
        }
        private void ThucThi(string sqlSTR)
        {
            try
            {
                wpnlThongTin.Children.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);

                SqlDataReader reader = cmd.ExecuteReader();
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
                    wpnlThongTin.Children.Add(uCKhoiCoBan);
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
