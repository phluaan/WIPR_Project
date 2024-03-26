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


        private void btnTools_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WNguoiDung_Loaded(object sender, RoutedEventArgs e)
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

                    uCKhoiCoBan.IdNguoiDungHienTai = IdNguoiDungHienTai;
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
