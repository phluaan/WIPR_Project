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

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for WTrangChu.xaml
    /// </summary>
    public partial class WTrangChu : Window
    {
        public StackPanel stkpanelDangKi = new StackPanel();
        public Border bd = new Border();
        public StackPanel stkpanelTemp = new StackPanel();
        public WTrangChu()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /*        private void btnRegister_Click(object sender, RoutedEventArgs e)
                {
                    stkpanelDangNhap.Visibility = Visibility.Collapsed;

                    TextBlock txb1 = new TextBlock();
                    txb1.Text = "Đăng kí";
                    txb1.FontSize = 40;
                    txb1.Foreground = Brushes.White;
                    txb1.FontWeight = FontWeights.Bold;
                    txb1.TextAlignment = TextAlignment.Center;

                    TextBlock txb2 = new TextBlock();
                    txb2.Text = "Tài khoản:";
                    txb2.Foreground = Brushes.White;
                    txb2.FontSize = 20;

                    TextBox txt1 = new TextBox();
                    txt1.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    txt1.Opacity = 0.7;
                    txt1.Margin = new Thickness(0, 10, 0, 10);
                    txt1.Height = 30;

                    TextBlock txb3 = new TextBlock();
                    txb3.Text = "Mật khẩu:";
                    txb3.Foreground = Brushes.White;
                    txb3.FontSize = 20;

                    PasswordBox passBox1 = new PasswordBox();
                    passBox1.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    passBox1.Opacity = 0.7;
                    passBox1.Margin = new Thickness(0, 10, 0, 10);
                    passBox1.Height = 30;

                    TextBlock txb4 = new TextBlock();
                    txb4.Text = "Nhập lại mật khẩu:";
                    txb4.Foreground = Brushes.White;
                    txb4.FontSize = 20;

                    PasswordBox passBox2 = new PasswordBox();
                    passBox2.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
                    passBox2.Opacity = 0.7;
                    passBox2.Margin = new Thickness(0, 10, 0, 10);
                    passBox2.Height = 30;

                    Button btnDangKi = new Button();
                    btnDangKi.Content = "Register";
                    btnDangKi.FontSize = 20;
                    btnDangKi.Background = new SolidColorBrush(Color.FromRgb(67, 67, 226));
                    btnDangKi.Foreground = Brushes.White;
                    btnDangKi.Height = 35;
                    btnDangKi.Width = 290;
                    btnDangKi.Margin = new Thickness(0, 20, 0, 0);

                    Button btnTroVe = new Button();
        btnTroVe.Content = "Trở về";
                    btnTroVe.FontSize = 15;
                    btnTroVe.Background = new SolidColorBrush(Color.FromRgb(67, 67, 226));
                    btnTroVe.Foreground = Brushes.White;
                    btnTroVe.Height = 20;
                    btnTroVe.Width = 290;
                    btnTroVe.Margin = new Thickness(0, 20, 0, 0);

                    stkpanelDangKi.Children.Add(txb1);
                    stkpanelDangKi.Children.Add(txb2);
                    stkpanelDangKi.Children.Add(txt1);
                    stkpanelDangKi.Children.Add(txb3);
                    stkpanelDangKi.Children.Add(passBox1);
                    stkpanelDangKi.Children.Add(txb4);
                    stkpanelDangKi.Children.Add(passBox2);
                    stkpanelDangKi.Children.Add(btnDangKi);
                    stkpanelDangKi.Children.Add(btnTroVe);


                    bd.Child = stkpanelDangKi;
                    bd.Margin = new Thickness(10);
                    bdMain.Child = bd;

                    btnTroVe.Click += BtnTroVe_Click;
                }
                private void BtnTroVe_Click(object sender, RoutedEventArgs e)
                {
                    bdMain.Child = stkpanelDangNhap;
                    stkpanelDangNhap.Visibility = Visibility.Visible;
                }
        */
        private void btnTho_Click(object sender, RoutedEventArgs e)
        {
            WTho wTho = new WTho();
            wTho.IdThoHienTai = "0";
            wTho.ShowDialog();
        }
        private void btnNguoiDung_Click(object sender, RoutedEventArgs e)
        {
            WNguoiDung wNguoiDung = new WNguoiDung();
            wNguoiDung.IdNguoiDungHienTai = "0";
            wNguoiDung.ShowDialog();
        }


        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            gridMain.Visibility = Visibility.Collapsed;


            Button btnTho = new Button();
            btnTho.Content = "Thợ";
            btnTho.FontSize = 20;
            btnTho.Background = new SolidColorBrush(Color.FromRgb(67, 67, 226));
            btnTho.Foreground = Brushes.White;
            btnTho.Height = 35;
            btnTho.Width = 290;
            btnTho.Margin = new Thickness(0, 20, 0, 0);

            Button btnNguoiDung = new Button();
            btnNguoiDung.Content = "Người dùng";
            btnNguoiDung.FontSize = 20;
            btnNguoiDung.Background = new SolidColorBrush(Color.FromRgb(67, 67, 226));
            btnNguoiDung.Foreground = Brushes.White;
            btnNguoiDung.Height = 35;
            btnNguoiDung.Width = 290;
            btnNguoiDung.Margin = new Thickness(0, 20, 0, 0);

            stkpanelTemp.Children.Add(btnTho);
            stkpanelTemp.Children.Add(btnNguoiDung);

            btnTho.Click += btnTho_Click;
            btnNguoiDung.Click += btnNguoiDung_Click;

            bd.Child = stkpanelTemp;
            bdMain.Child = bd;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}