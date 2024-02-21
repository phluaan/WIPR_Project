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
        public FTho()
        {
            InitializeComponent();
        }

        private void btnDoiThongTin_Click(object sender, EventArgs e)
        {
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
