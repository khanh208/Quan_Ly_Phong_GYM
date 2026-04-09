namespace Quan_Ly_Phong_GYM
{
    partial class ucDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTongHoiVien = new System.Windows.Forms.Label();
            this.lblDoanhThuThang = new System.Windows.Forms.Label();
            this.lblHoiVienDangTap = new System.Windows.Forms.Label();
            this.lblSapHetHan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Controls.Add(this.lblTongHoiVien);
            this.panel1.Location = new System.Drawing.Point(21, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 309);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.Controls.Add(this.lblHoiVienDangTap);
            this.panel2.Location = new System.Drawing.Point(21, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 336);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Controls.Add(this.lblSapHetHan);
            this.panel3.Location = new System.Drawing.Point(713, 422);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(719, 309);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel4.Controls.Add(this.lblDoanhThuThang);
            this.panel4.Location = new System.Drawing.Point(743, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(686, 336);
            this.panel4.TabIndex = 3;
            // 
            // lblTongHoiVien
            // 
            this.lblTongHoiVien.AutoSize = true;
            this.lblTongHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTongHoiVien.ForeColor = System.Drawing.Color.White;
            this.lblTongHoiVien.Location = new System.Drawing.Point(229, 0);
            this.lblTongHoiVien.Name = "lblTongHoiVien";
            this.lblTongHoiVien.Size = new System.Drawing.Size(220, 31);
            this.lblTongHoiVien.TabIndex = 0;
            this.lblTongHoiVien.Text = "TỔNG HỘI VIÊN";
            // 
            // lblDoanhThuThang
            // 
            this.lblDoanhThuThang.AutoSize = true;
            this.lblDoanhThuThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblDoanhThuThang.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuThang.Location = new System.Drawing.Point(226, 0);
            this.lblDoanhThuThang.Name = "lblDoanhThuThang";
            this.lblDoanhThuThang.Size = new System.Drawing.Size(280, 31);
            this.lblDoanhThuThang.TabIndex = 1;
            this.lblDoanhThuThang.Text = "DOANH THU THÁNG";
            // 
            // lblHoiVienDangTap
            // 
            this.lblHoiVienDangTap.AutoSize = true;
            this.lblHoiVienDangTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblHoiVienDangTap.ForeColor = System.Drawing.Color.White;
            this.lblHoiVienDangTap.Location = new System.Drawing.Point(216, 1);
            this.lblHoiVienDangTap.Name = "lblHoiVienDangTap";
            this.lblHoiVienDangTap.Size = new System.Drawing.Size(280, 31);
            this.lblHoiVienDangTap.TabIndex = 4;
            this.lblHoiVienDangTap.Text = "HỘI VIÊN ĐANG TẬP";
            // 
            // lblSapHetHan
            // 
            this.lblSapHetHan.AutoSize = true;
            this.lblSapHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblSapHetHan.ForeColor = System.Drawing.Color.White;
            this.lblSapHetHan.Location = new System.Drawing.Point(194, 0);
            this.lblSapHetHan.Name = "lblSapHetHan";
            this.lblSapHetHan.Size = new System.Drawing.Size(375, 31);
            this.lblSapHetHan.TabIndex = 1;
            this.lblSapHetHan.Text = "SẮP HẾT HẠN/ ĐÃ HẾT HẠN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(479, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(511, 46);
            this.label5.TabIndex = 4;
            this.label5.Text = "TRANG CHỦ TỔNG QUAN";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(1467, 840);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTongHoiVien;
        private System.Windows.Forms.Label lblHoiVienDangTap;
        private System.Windows.Forms.Label lblSapHetHan;
        private System.Windows.Forms.Label lblDoanhThuThang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timerRefresh;
    }
}
