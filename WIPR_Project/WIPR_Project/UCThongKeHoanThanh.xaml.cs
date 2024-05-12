using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WIPR_Project
{
    /// <summary>
    /// Interaction logic for UCTKLT.xaml
    /// </summary>
    public partial class UCThongKeHoanThanh : UserControl
    {
        public void pieChart()
        {
            PointLabel = ChartPoint => string.Format("{0} ({1:p})", ChartPoint.X, ChartPoint.Participation);
            DataContext = this;
        }
        public Account userAccount = new Account();
        ThoDAO thoDAO = new ThoDAO();
        public int month;
        public void component()
        {
            int hoanthanh =  thoDAO.TongSoCongViecTheoTienDo(userAccount.IdInforUser, month, DateTime.Now.Year, "DaHoanThanh");
            int chuahoanthanh = thoDAO.TongSoCongViecTheoTienDo(userAccount.IdInforUser, month, DateTime.Now.Year, "DangTienHanh");
            if(hoanthanh != 0 || chuahoanthanh != 0)
            {
                double phantram = ((double)((double)hoanthanh / (double)(hoanthanh + chuahoanthanh) * 100));
                txbPercent.Text = phantram.ToString("0.00") + "%";
                SeriesCollection = new SeriesCollection
                {
                new PieSeries
                {
                    Title = "Hoàn thành",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(hoanthanh) },
                    DataLabels = false,
                    Fill = Brushes.LimeGreen,

                },
                new PieSeries
                {
                    Title = "Chưa hoàn thành",
                    Values = new ChartValues<ObservableValue> {new ObservableValue(chuahoanthanh) },
                    DataLabels = false,
                    Fill = Brushes.Gray
                }
                };
                myPieChart.Series = SeriesCollection;
                myPieChart.StartingRotationAngle = -90;
                DataContext = this;
            }
            else
            {
                txbPercent.Text = "0%";
            }
            txbComplete.Text = hoanthanh.ToString();
            txbNoComplete.Text = chuahoanthanh.ToString();
        }
        public SeriesCollection SeriesCollection { get; set; }

        public Func<ChartPoint, string> PointLabel { get; set; }
        public UCThongKeHoanThanh()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            pieChart();
            component();
            txbTime1.Text = String.Format($"Tháng {month}/{DateTime.Now.Year}");

        }
    }
}