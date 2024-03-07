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
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
namespace WIPR_Project
{
    public partial class WNguoiDung : Window
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public WNguoiDung()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Luan", Position = "123", Email = "asdasd", Phone = "123" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "asdasd", Position = "1234", Email = "fgh", Phone = "123" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "sfsf", Position = "5766", Email = "hk", Phone = "123" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "fghf", Position = "56756", Email = "gh", Phone = "121" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "errt", Position = "234234", Email = "dh", Phone = "12" });
            members.Add(new Member { Number = "6", Character = "F", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "qew", Position = "90890", Email = "gr", Phone = "23" });
            members.Add(new Member { Number = "7", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "kh", Position = "234", Email = "hk", Phone = "12" });
            membersDataGrid.ItemsSource = members;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    
                    IsMaximized = true;
                }
            }
        }

    }
    public class Member
    {
        public string Character { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Brush BgColor { get; set; }
    }
}
