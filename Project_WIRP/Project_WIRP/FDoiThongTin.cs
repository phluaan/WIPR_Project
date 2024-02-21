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
    public partial class FDoiThongTin : Form
    {
        public FDoiThongTin()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHienThi.Checked)
            {
                txtMK.PasswordChar = '\0';
                txtNhapLaiMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '*';
                txtNhapLaiMK.PasswordChar = '*';
            }
        }
    }
}
