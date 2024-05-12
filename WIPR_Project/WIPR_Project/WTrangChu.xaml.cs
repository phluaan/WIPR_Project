﻿using System;
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
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Account userAccount = doiTuongDAO.truyxuatAccount(txbTaiKhoan.Text, pswMatKhau.Password);
            if (userAccount == null) MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
            else
            {
                if (userAccount.UserRole == "Tho")
                {
                    WTho wTho = new WTho();
                    wTho.userAccount = userAccount;
                    wTho.ShowDialog();
                }
                else
                {
                    WNguoiDung wNguoiDung = new WNguoiDung();
                    wNguoiDung.userAccount = userAccount;
                    wNguoiDung.ShowDialog();
                }
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnTiepTheo_Click(object sender, RoutedEventArgs e)
        {
            Account userAccount = doiTuongDAO.truyxuatAccount(txbTaiKhoanDK.Text, pswMatKhauDK.Password);
            if (userAccount == null)
            {
                if (pswMatKhauDK.Password != pswNhapLaiMatKhauDK.Password)
                {
                    MessageBox.Show("Mật khẩu nhập lại không hợp lệ, hãy thử lại!");
                }
                else if (pswMatKhauDK.Password == pswNhapLaiMatKhauDK.Password)
                {
                    bdDangKi.Visibility = Visibility.Collapsed;
                    bdThongTin.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại!");
            }
        }

        private void btnDangKyTK_Click(object sender, RoutedEventArgs e)
        {
            bdMain.Visibility = Visibility.Collapsed;
            bdLuaChon.Visibility = Visibility.Visible;
            txbTaiKhoan.Text = string.Empty;
            pswMatKhau.Password = string.Empty;
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            bdLuaChon.Visibility = Visibility.Visible;
            bdDangKi.Visibility = Visibility.Collapsed;
            txbTaiKhoanDK.Text = string.Empty;
            pswMatKhauDK.Password = string.Empty;
            pswNhapLaiMatKhauDK.Password = string.Empty;
        }
        string Loai = "Tho";
        private void btnTho_Click(object sender, RoutedEventArgs e)
        {
            Loai = "Tho";
            bdLuaChon.Visibility = Visibility.Collapsed;
            bdDangKi.Visibility = Visibility.Visible;
        }

        private void btnNguoiDung_Click(object sender, RoutedEventArgs e)
        {
            Loai = "NguoiDung";
            bdLuaChon.Visibility = Visibility.Collapsed;
            bdDangKi.Visibility = Visibility.Visible;
        }

        private void btnLCQuayLai_Click(object sender, RoutedEventArgs e)
        {
            bdLuaChon.Visibility = Visibility.Collapsed;
            bdMain.Visibility = Visibility.Visible;
        }

        private void btnDKTK_Click(object sender, RoutedEventArgs e)
        {
            string khuvuc = cbbDiaChi.SelectedItem == null ? "" : (cbbDiaChi.SelectedItem as ComboBoxItem).Content.ToString();
            string gioiTinh = cbbGioiTinh.SelectedItem == null ? "" : (cbbGioiTinh.SelectedItem as ComboBoxItem).Content.ToString();
            DateTime? ngaySinh;
            if (dpNgaySinh.SelectedDate.HasValue)
            {
                ngaySinh = dpNgaySinh.SelectedDate.Value;
            }
            else
            {
                ngaySinh = null;
            }

            if (CheckNull(txtHoVaTen.Text, txtSDT.Text, txtEmail.Text, khuvuc, gioiTinh, ngaySinh))
            {
                doiTuongDAO.ThemTaiKhoan(doiTuongDAO.IdTiepTheo("InforUser"), txtHoVaTen.Text, ngaySinh, txtEmail.Text, txtSDT.Text, gioiTinh, khuvuc,
                                          doiTuongDAO.IdTiepTheo("Account"), txbTaiKhoanDK.Text, pswMatKhauDK.Password, Loai);
            }
        }
        private bool CheckNull(string name, string SDT, string email, string khuVuc, string gioiTinh, DateTime? ngaySinh)
        {
            if (name == "" || SDT == "" || email == "" || khuVuc == "" || gioiTinh == "" || ngaySinh == null)
            {
                MessageBox.Show("Thông tin không được để trống!");
                return false;
            }
            return true;
        }

        private void btnQL_Click(object sender, RoutedEventArgs e)
        {
            bdThongTin.Visibility = Visibility.Collapsed;
            bdDangKi.Visibility = Visibility.Visible;
        }
    }
}
