using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for WLichBan.xaml
    /// </summary>
    public partial class WLichBan : Window
    {
        public WLichBan()
        {
            InitializeComponent();
        }
        Account userAccount = new Account();
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
        private void WLichBan_Loaded(object sender, RoutedEventArgs e)
        {
            List<DateTime> listDt = doiTuongDAO.TruyXuatNgayBan(userAccount.IdInforUser);
            foreach (DateTime busydate in listDt)
            {
                calLichBan.BlackoutDates.Add(new CalendarDateRange(busydate));
            }
        }
        
        private void btDatLichBan_Click(object sender, RoutedEventArgs e)
        {
            List<DateTime> selectedDates = new List<DateTime>();
            foreach (DateTime selectedDate in calLichBan.SelectedDates)
            {
                selectedDates.Add(selectedDate);
            }

            foreach (DateTime selectedDate in selectedDates)
            {
                doiTuongDAO.ThemNgayBan(doiTuongDAO.IdTiepTheo("busyDate"), userAccount.IdInforUser, userAccount.UserRole, selectedDate);
            }
            btnThoat_Click(sender, e);
        }


        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
