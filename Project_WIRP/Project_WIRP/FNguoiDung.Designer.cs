namespace Project_WIRP
{
    partial class FNguoiDung
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabNguoiDung = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnHuyThue = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnThoat2 = new System.Windows.Forms.Button();
            this.btnThue = new System.Windows.Forms.Button();
            this.btnDoiThongTin = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnXoaLoiMoi = new System.Windows.Forms.Button();
            this.btnThoat3 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabNguoiDung.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabNguoiDung
            // 
            this.tabNguoiDung.Controls.Add(this.tabPage1);
            this.tabNguoiDung.Controls.Add(this.tabPage2);
            this.tabNguoiDung.Controls.Add(this.tabPage3);
            this.tabNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabNguoiDung.Location = new System.Drawing.Point(0, 0);
            this.tabNguoiDung.Name = "tabNguoiDung";
            this.tabNguoiDung.SelectedIndex = 0;
            this.tabNguoiDung.Size = new System.Drawing.Size(800, 450);
            this.tabNguoiDung.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Highlight;
            this.tabPage1.Controls.Add(this.btnHuyThue);
            this.tabPage1.Controls.Add(this.btnThoat);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thợ đang thuê";
            // 
            // btnHuyThue
            // 
            this.btnHuyThue.AutoSize = true;
            this.btnHuyThue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHuyThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThue.ForeColor = System.Drawing.SystemColors.Window;
            this.btnHuyThue.Location = new System.Drawing.Point(267, 366);
            this.btnHuyThue.Name = "btnHuyThue";
            this.btnHuyThue.Size = new System.Drawing.Size(105, 30);
            this.btnHuyThue.TabIndex = 17;
            this.btnHuyThue.Text = "Hủy thuê";
            this.btnHuyThue.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.AutoSize = true;
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThoat.Location = new System.Drawing.Point(403, 366);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(724, 322);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Highlight;
            this.tabPage2.Controls.Add(this.btnThoat2);
            this.tabPage2.Controls.Add(this.btnThue);
            this.tabPage2.Controls.Add(this.btnDoiThongTin);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.radioButton4);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.radioButton3);
            this.tabPage2.Controls.Add(this.radioButton2);
            this.tabPage2.Controls.Add(this.radioButton1);
            this.tabPage2.Controls.Add(this.txtTimKiem);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tìm thợ";
            // 
            // btnThoat2
            // 
            this.btnThoat2.AutoSize = true;
            this.btnThoat2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThoat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat2.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThoat2.Location = new System.Drawing.Point(686, 329);
            this.btnThoat2.Name = "btnThoat2";
            this.btnThoat2.Size = new System.Drawing.Size(76, 30);
            this.btnThoat2.TabIndex = 16;
            this.btnThoat2.Text = "Thoát";
            this.btnThoat2.UseVisualStyleBackColor = false;
            this.btnThoat2.Click += new System.EventHandler(this.btnThoat2_Click);
            // 
            // btnThue
            // 
            this.btnThue.AutoSize = true;
            this.btnThue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThue.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThue.Location = new System.Drawing.Point(592, 329);
            this.btnThue.Name = "btnThue";
            this.btnThue.Size = new System.Drawing.Size(76, 30);
            this.btnThue.TabIndex = 15;
            this.btnThue.Text = "Thuê";
            this.btnThue.UseVisualStyleBackColor = false;
            // 
            // btnDoiThongTin
            // 
            this.btnDoiThongTin.AutoSize = true;
            this.btnDoiThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDoiThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiThongTin.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDoiThongTin.Location = new System.Drawing.Point(29, 370);
            this.btnDoiThongTin.Name = "btnDoiThongTin";
            this.btnDoiThongTin.Size = new System.Drawing.Size(136, 30);
            this.btnDoiThongTin.TabIndex = 14;
            this.btnDoiThongTin.Text = "Đổi thông tin";
            this.btnDoiThongTin.UseVisualStyleBackColor = false;
            this.btnDoiThongTin.Click += new System.EventHandler(this.btnDoiThongTin_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(29, 106);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(733, 217);
            this.dataGridView2.TabIndex = 8;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.ForeColor = System.Drawing.SystemColors.Window;
            this.radioButton4.Location = new System.Drawing.Point(446, 35);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 20);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Mức giá";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tìm kiếm theo:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.SystemColors.Window;
            this.radioButton3.Location = new System.Drawing.Point(304, 35);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(80, 20);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Tên thợ";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.Window;
            this.radioButton2.Location = new System.Drawing.Point(168, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 20);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Khu vực";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.Window;
            this.radioButton1.Location = new System.Drawing.Point(29, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(79, 20);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Dịch vụ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(29, 66);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(492, 22);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyUp);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Highlight;
            this.tabPage3.Controls.Add(this.btnXoaLoiMoi);
            this.tabPage3.Controls.Add(this.btnThoat3);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lời mời đã gửi";
            // 
            // btnXoaLoiMoi
            // 
            this.btnXoaLoiMoi.AutoSize = true;
            this.btnXoaLoiMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXoaLoiMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLoiMoi.ForeColor = System.Drawing.SystemColors.Window;
            this.btnXoaLoiMoi.Location = new System.Drawing.Point(259, 349);
            this.btnXoaLoiMoi.Name = "btnXoaLoiMoi";
            this.btnXoaLoiMoi.Size = new System.Drawing.Size(131, 30);
            this.btnXoaLoiMoi.TabIndex = 18;
            this.btnXoaLoiMoi.Text = "Xóa lời mời";
            this.btnXoaLoiMoi.UseVisualStyleBackColor = false;
            // 
            // btnThoat3
            // 
            this.btnThoat3.AutoSize = true;
            this.btnThoat3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThoat3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat3.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThoat3.Location = new System.Drawing.Point(419, 349);
            this.btnThoat3.Name = "btnThoat3";
            this.btnThoat3.Size = new System.Drawing.Size(76, 30);
            this.btnThoat3.TabIndex = 17;
            this.btnThoat3.Text = "Thoát";
            this.btnThoat3.UseVisualStyleBackColor = false;
            this.btnThoat3.Click += new System.EventHandler(this.btnThoat3_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(59, 37);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(660, 279);
            this.dataGridView3.TabIndex = 0;
            // 
            // FNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabNguoiDung);
            this.Name = "FNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Người dùng";
            this.tabNguoiDung.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabNguoiDung;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btnHuyThue;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThoat2;
        private System.Windows.Forms.Button btnThue;
        private System.Windows.Forms.Button btnDoiThongTin;
        private System.Windows.Forms.Button btnXoaLoiMoi;
        private System.Windows.Forms.Button btnThoat3;
    }
}