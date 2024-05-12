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
    /// Interaction logic for WMucGiaChinhXac.xaml
    /// </summary>
    public partial class WMucGiaChinhXac : Window
    {
        public WMucGiaChinhXac()
        {
            InitializeComponent();
        }
        ThoDAO thoDAO = new ThoDAO();
        public int idNgayLamViec;
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            foreach(char check in txtMucGia.Text)
            {
                if (!Char.IsDigit(check))
                {
                    MessageBox.Show("Vui lòng chi nhập số!");
                    return;
                }
            }
            thoDAO.Sua("dateWork", idNgayLamViec, $" price = '{txtMucGia.Text}'");
            this.Close();
        }
    }
}
