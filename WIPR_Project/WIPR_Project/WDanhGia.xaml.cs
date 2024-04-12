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
    /// Interaction logic for WDanhGia.xaml
    /// </summary>
    public partial class WDanhGia : Window
    {
        public WDanhGia()
        {
            InitializeComponent();
        }
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
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
                //this.IsEnabled = false;
                //btnThoat.IsEnabled = true;
                if (idDanhGia == 0)
                {
                    return;
                }
                DanhGia dg = doiTuongDAO.TruyXuatDanhGia(idDanhGia);
                rBarSoSao.Value = Convert.ToDouble(dg.NumOfStar);
                txtDanhGia.Text = dg.UserEvaluation;
            }
        }
        private void btnGuiDanhGia_Click(object sender, RoutedEventArgs e)
        {
            int idDanhGia = doiTuongDAO.IdTiepTheo("Evaluation");
            doiTuongDAO.ThemDanhGia(idDanhGia, idTho, idNguoiDung, Convert.ToDecimal(rBarSoSao.Value), txtDanhGia.Text);
            doiTuongDAO.Sua("dateWork", idNgayLamViec, $" idEvaluation = '{idDanhGia}'");
            btnThoat_Click(sender, e);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
