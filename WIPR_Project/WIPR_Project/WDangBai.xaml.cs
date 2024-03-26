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
using System.Windows.Markup;

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for WDangBai.xaml
    /// </summary>
    public partial class WDangBai : Window
    {
        public WDangBai()
        {
            InitializeComponent();
        }
        ThoDAO thoDAO = new ThoDAO();

        public string IdThoDangNhap;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnDangBai_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string getMaxIdQuery = "SELECT MAX(CAST(Id AS INT)) FROM QLyBaiViet";
                SqlCommand getMaxIdBaiViet = new SqlCommand(getMaxIdQuery, conn);
                object maxIdResult = getMaxIdBaiViet.ExecuteScalar();
                int nextId = 0;
                if (maxIdResult != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(maxIdResult);
                    nextId = maxId + 1;
                }

                string sqlSTR_Tho = string.Format("SELECT * FROM QlyTho WHERE Id = {0}", IdThoDangNhap);
                SqlCommand cmd_Tho = new SqlCommand(sqlSTR_Tho, conn);
                SqlDataReader reader = cmd_Tho.ExecuteReader();
                if (reader.Read())
                {
                    string HoTen = reader["HoTen"].ToString();
                    string NgaySinh = reader["NgaySinh"].ToString();
                    string Email = reader["Email"].ToString();
                    string SDT = reader["SDT"].ToString();
                    string GioiTinh = reader["GioiTinh"].ToString();
                    string DiaChi = reader["DiaChi"].ToString();
                    reader.Close();
                    string DichVu = (cbbDichVu.SelectedItem as ComboBoxItem)?.Content?.ToString();
                    string KinhNghiem = (cbbKinhNghiem.SelectedItem as ComboBoxItem)?.Content?.ToString();
                    string MucGia = (cbbMucGia.SelectedItem as ComboBoxItem)?.Content?.ToString();

                    string sqlSTR = string.Format("INSERT INTO QLyBaiViet (Id, IdTho, DichVu, KinhNghiem, MucGia, HoTen, NgaySinh, Email, SDT, GioiTinh, DiaChi) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
                        nextId.ToString(), IdThoDangNhap, DichVu, KinhNghiem, MucGia, HoTen, NgaySinh, Email, SDT, GioiTinh, DiaChi);

                    SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Thành công");
                }
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

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
