namespace Quan_Ly_Phong_GYM
{
    partial class Form1
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnVangLai = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnGoiTap = new System.Windows.Forms.Button();
            this.btnHoiVien = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.DarkViolet;
            this.panelMenu.Controls.Add(this.btnVangLai);
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btnKhuyenMai);
            this.panelMenu.Controls.Add(this.btnThongKe);
            this.panelMenu.Controls.Add(this.btnDangKy);
            this.panelMenu.Controls.Add(this.btnGoiTap);
            this.panelMenu.Controls.Add(this.btnHoiVien);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(214, 538);
            this.panelMenu.TabIndex = 0;
            // 
            // btnVangLai
            // 
            this.btnVangLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVangLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnVangLai.ForeColor = System.Drawing.Color.White;
            this.btnVangLai.Location = new System.Drawing.Point(38, 90);
            this.btnVangLai.Name = "btnVangLai";
            this.btnVangLai.Size = new System.Drawing.Size(139, 39);
            this.btnVangLai.TabIndex = 6;
            this.btnVangLai.Text = "Vãng lai";
            this.btnVangLai.UseVisualStyleBackColor = true;
            this.btnVangLai.Click += new System.EventHandler(this.btnKhachVangLai_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(21, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Huấn luyện viên";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnHLV_Click);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.White;
            this.btnKhuyenMai.Location = new System.Drawing.Point(38, 333);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(139, 41);
            this.btnKhuyenMai.TabIndex = 4;
            this.btnKhuyenMai.Text = "Khuyến mãi";
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(38, 404);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(139, 41);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(38, 212);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(139, 38);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnGoiTap
            // 
            this.btnGoiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnGoiTap.ForeColor = System.Drawing.Color.White;
            this.btnGoiTap.Location = new System.Drawing.Point(38, 273);
            this.btnGoiTap.Name = "btnGoiTap";
            this.btnGoiTap.Size = new System.Drawing.Size(139, 37);
            this.btnGoiTap.TabIndex = 1;
            this.btnGoiTap.Text = "Gói tập";
            this.btnGoiTap.UseVisualStyleBackColor = true;
            this.btnGoiTap.Click += new System.EventHandler(this.btnGoiTap_Click);
            // 
            // btnHoiVien
            // 
            this.btnHoiVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnHoiVien.ForeColor = System.Drawing.Color.White;
            this.btnHoiVien.Location = new System.Drawing.Point(38, 150);
            this.btnHoiVien.Name = "btnHoiVien";
            this.btnHoiVien.Size = new System.Drawing.Size(139, 39);
            this.btnHoiVien.TabIndex = 0;
            this.btnHoiVien.Text = "Hội viên";
            this.btnHoiVien.UseVisualStyleBackColor = true;
            this.btnHoiVien.Click += new System.EventHandler(this.btnHoiVien_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Indigo;
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(214, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(712, 109);
            this.panelHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ForeColor = System.Drawing.Color.Thistle;
            this.label1.Location = new System.Drawing.Point(105, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ PHÒNG GYM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(214, 109);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(712, 429);
            this.pnlMain.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 538);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnGoiTap;
        private System.Windows.Forms.Button btnHoiVien;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnKhuyenMai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVangLai;
    }
}

