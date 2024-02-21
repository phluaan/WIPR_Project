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
    public partial class FTho : Form
    {
        FQuanLiBaiViet fQuanLiBaiViet = new FQuanLiBaiViet();
        FDoiThongTin fDoiThongTin = new FDoiThongTin();
        public FTho()
        {
            InitializeComponent();
        }

        private void btnDoiThongTin_Click(object sender, EventArgs e)
        {
            fDoiThongTin.ShowDialog();
        }

        private void btnQuanLiBaiViet_Click(object sender, EventArgs e)
        {
            fQuanLiBaiViet.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
