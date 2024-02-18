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
            tabPage1.Text = "Thợ đang thuê";
            tabPage2.Text = "Tìm thợ";
            tabPage3.Text = "Lời mời đã gửi";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
