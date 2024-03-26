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
        public WTrangChu()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <9; i++)
            {
                UCKhoiCoBan ucKhoiCoBan = new UCKhoiCoBan();
                ucKhoiCoBan.Width = 200;
                ucKhoiCoBan.Height = 200;

                //wpnlThongTin.Children.Add(ucKhoiCoBan);
            }
        }
    }
}
