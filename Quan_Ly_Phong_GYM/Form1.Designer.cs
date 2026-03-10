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
            this.panelMenu.Controls.Add(this.btnThongKe);
            this.panelMenu.Controls.Add(this.btnDangKy);
            this.panelMenu.Controls.Add(this.btnGoiTap);
            this.panelMenu.Controls.Add(this.btnHoiVien);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(191, 538);
            this.panelMenu.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(38, 322);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(116, 41);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // btnDangKy
            // 
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(38, 252);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(116, 38);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            // 
            // btnGoiTap
            // 
            this.btnGoiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnGoiTap.ForeColor = System.Drawing.Color.White;
            this.btnGoiTap.Location = new System.Drawing.Point(38, 184);
            this.btnGoiTap.Name = "btnGoiTap";
            this.btnGoiTap.Size = new System.Drawing.Size(116, 37);
            this.btnGoiTap.TabIndex = 1;
            this.btnGoiTap.Text = "Gói tập";
            this.btnGoiTap.UseVisualStyleBackColor = true;
            // 
            // btnHoiVien
            // 
            this.btnHoiVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnHoiVien.ForeColor = System.Drawing.Color.White;
            this.btnHoiVien.Location = new System.Drawing.Point(38, 112);
            this.btnHoiVien.Name = "btnHoiVien";
            this.btnHoiVien.Size = new System.Drawing.Size(116, 39);
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
            this.panelHeader.Location = new System.Drawing.Point(191, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(735, 89);
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
            this.pnlMain.Location = new System.Drawing.Point(191, 89);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(735, 449);
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
    }
}

