namespace Quan_Ly_Phong_GYM
{
    partial class ucHoiVien
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
            this.dgvHoiVien = new System.Windows.Forms.DataGridView();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoiVien
            // 
            this.dgvHoiVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoiVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoiVien.Location = new System.Drawing.Point(619, 84);
            this.dgvHoiVien.Name = "dgvHoiVien";
            this.dgvHoiVien.ReadOnly = true;
            this.dgvHoiVien.RowHeadersWidth = 51;
            this.dgvHoiVien.RowTemplate.Height = 24;
            this.dgvHoiVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoiVien.Size = new System.Drawing.Size(672, 397);
            this.dgvHoiVien.TabIndex = 0;
            this.dgvHoiVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoiVien_CellClick);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblHoTen.Location = new System.Drawing.Point(174, 102);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(75, 25);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNgaySinh.Location = new System.Drawing.Point(174, 162);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(105, 25);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGioiTinh.Location = new System.Drawing.Point(174, 219);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(88, 25);
            this.lblGioiTinh.TabIndex = 3;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSDT.Location = new System.Drawing.Point(174, 277);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(132, 25);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHoTen.Location = new System.Drawing.Point(338, 97);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(227, 30);
            this.txtHoTen.TabIndex = 5;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(338, 157);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(151, 30);
            this.dtpNgaySinh.TabIndex = 6;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác..."});
            this.cboGioiTinh.Location = new System.Drawing.Point(338, 211);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(151, 33);
            this.cboGioiTinh.TabIndex = 7;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSDT.Location = new System.Drawing.Point(338, 272);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(227, 30);
            this.txtSDT.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThem.Location = new System.Drawing.Point(229, 335);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(123, 46);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSua.Location = new System.Drawing.Point(373, 335);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(134, 46);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoa.Location = new System.Drawing.Point(229, 400);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(123, 46);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLamMoi.Location = new System.Drawing.Point(373, 400);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(134, 46);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(126, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 397);
            this.panel2.TabIndex = 14;
            // 
            // ucHoiVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHoiVien);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.panel2);
            this.Name = "ucHoiVien";
            this.Size = new System.Drawing.Size(1465, 812);
            this.Load += new System.EventHandler(this.ucHoiVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoiVien;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel panel2;
    }
}
