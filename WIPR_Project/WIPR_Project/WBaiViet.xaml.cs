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
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);

        public string IdBaiVietChiTiet;
        public string IdNguoiDungHienTai;
        public string IdThoHT;

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string sqlSTR = string.Format("SELECT * FROM QLyBaiViet WHERE Id = {0}", IdBaiVietChiTiet);
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                txbHoTen.Text = reader["HoTen"].ToString();
                txbNgaySinh.Text = reader["NgaySinh"].ToString();
                txbGioiTinh.Text = reader["GioiTinh"].ToString();
                txbSDT.Text = reader["SDT"].ToString();
                txbEmail.Text = reader["Email"].ToString();
                txbDichVu.Text = reader["DichVu"].ToString();
                txbDiaChi.Text = reader["DiaChi"].ToString();
                txbMucGia.Text = reader["MucGia"].ToString();
                txbKinhNghiem.Text = reader["kinhNghiem"].ToString();
                IdThoHT = reader["IdTho"].ToString();
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

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnThue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string getMaxIdQuery = "SELECT MAX(CAST(Id AS INT)) FROM LoiMoi";
                SqlCommand getMaxIdBaiViet = new SqlCommand(getMaxIdQuery, conn);
                object maxIdResult = getMaxIdBaiViet.ExecuteScalar();
                int nextId = 0;
                if (maxIdResult != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(maxIdResult);
                    nextId = maxId + 1;
                }

                string sqlSTR_NgDung = string.Format("SELECT * FROM QLyNguoiDung WHERE Id = {0}", IdNguoiDungHienTai);
                SqlCommand cmd_NgDung = new SqlCommand(sqlSTR_NgDung, conn);
                SqlDataReader reader = cmd_NgDung.ExecuteReader();
                reader.Read();
                string hoTen = reader["HoTen"].ToString();
                string ngaySinh = reader["NgaySinh"].ToString();
                string gioiTinh = reader["GioiTinh"].ToString();
                string sDT = reader["SDT"].ToString();
                string email = reader["Email"].ToString();
                string diaChi = reader["DiaChi"].ToString();
                reader.Close();

                string sqlSTR = string.Format("INSERT INTO LoiMoi (Id,IdTho,IdNguoiDung,IdBaiViet,HoTen,NgaySinh,Email,Sdt,GioiTinh,DiaChi) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", 
                    nextId.ToString(), IdThoHT, IdNguoiDungHienTai, IdBaiVietChiTiet, hoTen, ngaySinh, email, sDT, gioiTinh, diaChi);
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
    }
}
