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
    /// Interaction logic for WLoiMoi.xaml
    /// </summary>
    public partial class WLoiMoi : Window
    {
        public WLoiMoi()
        {
            InitializeComponent();
        }
        public LoiMoi loiMoi = new LoiMoi();
        private DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
        private void WLoiMoi_Loaded(object sender, RoutedEventArgs e)
        {
            List<DateTime> listDt = doiTuongDAO.TruyXuatNgayBan(loiMoi.IdTho);
            listDt.AddRange(doiTuongDAO.TruyXuatNgayBan(loiMoi.IdNguoiDung));
            foreach (DateTime busydate in listDt)
            {
                calLoiMoi.BlackoutDates.Add(new CalendarDateRange(busydate));
            }
        }
        private void btnGuiLoiMoi_Click(object sender, RoutedEventArgs e)
        {
            loiMoi.DateWork = Convert.ToDateTime(calLoiMoi.SelectedDate);
            doiTuongDAO.GuiLoiMoi(loiMoi);
            btThoat_Click(sender, e);
        }

        private void btThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
