using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_WIRP
{
    public partial class FNguoiDung : Form
    {
        public FNguoiDung()
        {
            InitializeComponent();
        }
        FDoiThongTin fDoiThongTin = new FDoiThongTin();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThoat3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnDoiThongTin_Click(object sender, EventArgs e)
        {
            fDoiThongTin.ShowDialog();
        }
    }
}
