namespace Quan_Ly_Phong_GYM
{
    partial class ucDangKy
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
            this.cboHoiVien = new System.Windows.Forms.ComboBox();
            this.cboGoiTap = new System.Windows.Forms.ComboBox();
            this.cboHLV = new System.Windows.Forms.ComboBox();
            this.cboKhuyenMai = new System.Windows.Forms.ComboBox();
            this.dtpNgayDK = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.lblHoiVien = new System.Windows.Forms.Label();
            this.lblGoiTap = new System.Windows.Forms.Label();
            this.lblHLV = new System.Windows.Forms.Label();
            this.lblKhuyenMai = new System.Windows.Forms.Label();
            this.lblNgayDangKy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboHoiVien
            // 
            this.cboHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboHoiVien.FormattingEnabled = true;
            this.cboHoiVien.Location = new System.Drawing.Point(233, 63);
            this.cboHoiVien.Name = "cboHoiVien";
            this.cboHoiVien.Size = new System.Drawing.Size(163, 33);
            this.cboHoiVien.TabIndex = 0;
            // 
            // cboGoiTap
            // 
            this.cboGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboGoiTap.FormattingEnabled = true;
            this.cboGoiTap.Location = new System.Drawing.Point(233, 133);
            this.cboGoiTap.Name = "cboGoiTap";
            this.cboGoiTap.Size = new System.Drawing.Size(163, 33);
            this.cboGoiTap.TabIndex = 1;
            this.cboGoiTap.SelectedIndexChanged += new System.EventHandler(this.TinhToanPhieu);
            // 
            // cboHLV
            // 
            this.cboHLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboHLV.FormattingEnabled = true;
            this.cboHLV.Location = new System.Drawing.Point(233, 205);
            this.cboHLV.Name = "cboHLV";
            this.cboHLV.Size = new System.Drawing.Size(163, 33);
            this.cboHLV.TabIndex = 2;
            // 
            // cboKhuyenMai
            // 
            this.cboKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboKhuyenMai.FormattingEnabled = true;
            this.cboKhuyenMai.Location = new System.Drawing.Point(233, 279);
            this.cboKhuyenMai.Name = "cboKhuyenMai";
            this.cboKhuyenMai.Size = new System.Drawing.Size(163, 33);
            this.cboKhuyenMai.TabIndex = 3;
            this.cboKhuyenMai.SelectedIndexChanged += new System.EventHandler(this.TinhToanPhieu);
            // 
            // dtpNgayDK
            // 
            this.dtpNgayDK.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNgayDK.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNgayDK.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDK.Location = new System.Drawing.Point(233, 351);
            this.dtpNgayDK.Name = "dtpNgayDK";
            this.dtpNgayDK.Size = new System.Drawing.Size(163, 30);
            this.dtpNgayDK.TabIndex = 4;
            this.dtpNgayDK.ValueChanged += new System.EventHandler(this.TinhToanPhieu);
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNgayHetHan.Location = new System.Drawing.Point(239, 413);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Size = new System.Drawing.Size(64, 25);
            this.lblNgayHetHan.TabIndex = 5;
            this.lblNgayHetHan.Text = "label1";
            // 
            // lblHoiVien
            // 
            this.lblHoiVien.AutoSize = true;
            this.lblHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblHoiVien.Location = new System.Drawing.Point(47, 71);
            this.lblHoiVien.Name = "lblHoiVien";
            this.lblHoiVien.Size = new System.Drawing.Size(88, 25);
            this.lblHoiVien.TabIndex = 6;
            this.lblHoiVien.Text = "Hội viên:";
            // 
            // lblGoiTap
            // 
            this.lblGoiTap.AutoSize = true;
            this.lblGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGoiTap.Location = new System.Drawing.Point(47, 141);
            this.lblGoiTap.Name = "lblGoiTap";
            this.lblGoiTap.Size = new System.Drawing.Size(80, 25);
            this.lblGoiTap.TabIndex = 7;
            this.lblGoiTap.Text = "Gói tập:";
            // 
            // lblHLV
            // 
            this.lblHLV.AutoSize = true;
            this.lblHLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblHLV.Location = new System.Drawing.Point(47, 213);
            this.lblHLV.Name = "lblHLV";
            this.lblHLV.Size = new System.Drawing.Size(57, 25);
            this.lblHLV.TabIndex = 8;
            this.lblHLV.Text = "HLV:";
            // 
            // lblKhuyenMai
            // 
            this.lblKhuyenMai.AutoSize = true;
            this.lblKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblKhuyenMai.Location = new System.Drawing.Point(47, 287);
            this.lblKhuyenMai.Name = "lblKhuyenMai";
            this.lblKhuyenMai.Size = new System.Drawing.Size(122, 25);
            this.lblKhuyenMai.TabIndex = 9;
            this.lblKhuyenMai.Text = "Khuyến mãi:";
            // 
            // lblNgayDangKy
            // 
            this.lblNgayDangKy.AutoSize = true;
            this.lblNgayDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNgayDangKy.Location = new System.Drawing.Point(47, 356);
            this.lblNgayDangKy.Name = "lblNgayDangKy";
            this.lblNgayDangKy.Size = new System.Drawing.Size(138, 25);
            this.lblNgayDangKy.TabIndex = 10;
            this.lblNgayDangKy.Text = "Ngày đăng ký:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(47, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ngày hết hạn:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTongTien.Location = new System.Drawing.Point(233, 468);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(163, 30);
            this.txtTongTien.TabIndex = 12;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTongTien.Location = new System.Drawing.Point(47, 473);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 25);
            this.lblTongTien.TabIndex = 13;
            this.lblTongTien.Text = "Tổng tiển:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGhiChu.Location = new System.Drawing.Point(233, 540);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(163, 22);
            this.txtGhiChu.TabIndex = 14;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGhiChu.Location = new System.Drawing.Point(47, 543);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(85, 25);
            this.lblGhiChu.TabIndex = 15;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDangKy.Location = new System.Drawing.Point(444, 0);
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.RowHeadersWidth = 51;
            this.dgvDangKy.RowTemplate.Height = 24;
            this.dgvDangKy.Size = new System.Drawing.Size(1019, 768);
            this.dgvDangKy.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThanhToan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 768);
            this.panel1.TabIndex = 17;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThanhToan.Location = new System.Drawing.Point(117, 617);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(165, 41);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // ucDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDangKy);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNgayDangKy);
            this.Controls.Add(this.lblKhuyenMai);
            this.Controls.Add(this.lblHLV);
            this.Controls.Add(this.lblGoiTap);
            this.Controls.Add(this.lblHoiVien);
            this.Controls.Add(this.lblNgayHetHan);
            this.Controls.Add(this.dtpNgayDK);
            this.Controls.Add(this.cboKhuyenMai);
            this.Controls.Add(this.cboHLV);
            this.Controls.Add(this.cboGoiTap);
            this.Controls.Add(this.cboHoiVien);
            this.Controls.Add(this.panel1);
            this.Name = "ucDangKy";
            this.Size = new System.Drawing.Size(1463, 768);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboHoiVien;
        private System.Windows.Forms.ComboBox cboGoiTap;
        private System.Windows.Forms.ComboBox cboHLV;
        private System.Windows.Forms.ComboBox cboKhuyenMai;
        private System.Windows.Forms.DateTimePicker dtpNgayDK;
        private System.Windows.Forms.Label lblNgayHetHan;
        private System.Windows.Forms.Label lblHoiVien;
        private System.Windows.Forms.Label lblGoiTap;
        private System.Windows.Forms.Label lblHLV;
        private System.Windows.Forms.Label lblKhuyenMai;
        private System.Windows.Forms.Label lblNgayDangKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.DataGridView dgvDangKy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThanhToan;
    }
}
