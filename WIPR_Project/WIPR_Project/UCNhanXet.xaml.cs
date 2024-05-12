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
    /// Interaction logic for UCNhanXet.xaml
    /// </summary>
    public partial class UCNhanXet : UserControl
    {
        public UCNhanXet()
        {
            InitializeComponent();
        }
        DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
        public void UpdateUserControl(DanhGia dg)
        {
            DoiTuong dt = doiTuongDAO.TruyXuatDT(dg.IdNguoiDung);
            txbNhanXet.Text = dg.UserEvaluation;
            txbDanhGia.Text = dg.NumOfStar.ToString("0.#");
            txbName.Text = dt.HoTen;
        }
    }
}
