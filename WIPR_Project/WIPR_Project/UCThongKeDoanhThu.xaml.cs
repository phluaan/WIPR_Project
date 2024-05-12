using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for UCTKDG.xaml
    /// </summary>
    public partial class UCThongKeDoanhThu : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ThoDAO thoDAO = new ThoDAO();
        public Account userAccount = new Account();
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] labels { get; set; }
        public string[] Ylabels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public UCThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6"
            ,"Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };

            List<int> listDoanhThu = new List<int>();
            for (int i = 1; i < 13; i++)
            {
                listDoanhThu.Add(thoDAO.TongDoanhThu(userAccount.IdInforUser, i, DateTime.Now.Year));
            }
            DataContext = this;
            SeriesCollection = new SeriesCollection()
            {
                new LineSeries()
                {
                    Title = DateTime.Now.Year.ToString(),
                    Values = new ChartValues<int>(listDoanhThu)
                }
            };
            Formatter = value => value.ToString();
            Ylabels = new[] { "0", "500000", "1000000", "1500000", "2000000", "2500000", "3000000" };
            var axisY = chartStar.AxisY.First() as Axis;
            if (axisY != null)
            {
                axisY.Labels = new[] { "0","500000", "1000000", "1500000", "2000000", "2500000","3000000" };
                axisY.LabelFormatter = value => labels[(int)value];
                axisY.MaxValue = 3000000;
                axisY.MinValue = 0;
            }
        }
    }
}