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
        FDangKy fDangKy = new FDangKy();
        FNguoiDung fNguoiDung = new FNguoiDung();
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            fDangKy.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (rdoUser.Checked)
                fNguoiDung.ShowDialog();
            if (rdoTho.Checked)
                return;
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
