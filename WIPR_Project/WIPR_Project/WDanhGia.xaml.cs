using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Interop;
using WpfImage = System.Windows.Controls.Image;
namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for WDanhGia.xaml
    /// </summary>
    public partial class WDanhGia : Window
    {
        public WDanhGia()
        {
            InitializeComponent();
        }
        NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        public int idTho;
        public int idNguoiDung;
        public int idNgayLamViec;
        public string userRole;
        public int idDanhGia;
        private void WDanhGia_Loaded(object sender, RoutedEventArgs e)
        {
            if(userRole=="NguoiDung" && idDanhGia == 0)
            {
                btnGuiDanhGia.Visibility = Visibility;
            }
            else
            {
                if (idDanhGia == 0)
                {
                    return;
                }
                DanhGia dg = nguoiDungDAO.TruyXuatDanhGia(idDanhGia);
                rBarSoSao.Value = Convert.ToDouble(dg.NumOfStar);
                txtDanhGia.Text = dg.UserEvaluation;
            }
        }
        private void btnGuiDanhGia_Click(object sender, RoutedEventArgs e)
        {
            int idDanhGia = nguoiDungDAO.IdTiepTheo("Evaluation");
            nguoiDungDAO.ThemDanhGia(idDanhGia, idTho, idNguoiDung, Convert.ToDecimal(rBarSoSao.Value), txtDanhGia.Text);
            nguoiDungDAO.Sua("dateWork", idNgayLamViec, $" idEvaluation = '{idDanhGia}'");
            btnThoat_Click(sender, e);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int selectedImageCount = 0;
        private void btnImagePlus_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    if (selectedImageCount < 5)
                    {
                        WpfImage image = CreateResizedImage(filename, 80, 80);
                        image.Margin = new Thickness(5);
                        wrapImage.Children.Add(image);
                        selectedImageCount++; // Tăng biến đếm sau khi thêm hình ảnh
                    }
                    else
                    {
                        break; // Thoát khỏi vòng lặp nếu đã chọn đủ 5 hình ảnh
                    }
                }
            }
        }
        private WpfImage CreateResizedImage(string imagePath, int width, int height)
        {
            // Load hình ảnh từ đường dẫn
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(imagePath);

            // Resize hình ảnh
            System.Drawing.Bitmap resizedBitmap = new System.Drawing.Bitmap(width, height);
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(resizedBitmap))
            {
                graphics.DrawImage(bitmap, 0, 0, width, height);
            }

            // Chuyển đổi hình ảnh sang dạng BitmapSource
            System.Windows.Media.Imaging.BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                resizedBitmap.GetHbitmap(),
                IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            // Tạo mới Image từ BitmapSource
            WpfImage image = new WpfImage();
            image.Source = bitmapSource;

            return image;
        }
    }
}
