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
    public partial class FDangNhap : Form
    {
        public FDangNhap()
        {
            InitializeComponent();
        }
        FNguoiDung fNguoiDung = new FNguoiDung();
        FDangKy fDangKy = new FDangKy();
        FTho fTho = new FTho();
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            fDangKy.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (rdoUser.Checked)
                fNguoiDung.ShowDialog();
            if (rdoTho.Checked)
                fTho.ShowDialog();
        }

        private void rdoHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHienThi.Checked)
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }
    }
}
