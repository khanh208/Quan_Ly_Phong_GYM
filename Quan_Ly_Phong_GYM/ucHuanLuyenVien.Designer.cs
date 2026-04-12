namespace Quan_Ly_Phong_GYM
{
    partial class ucHuanLuyenVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblTenHLV = new System.Windows.Forms.Label();
            this.cboChuyenMon = new System.Windows.Forms.ComboBox();
            this.lblChuyenMon = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtSearchHLV = new System.Windows.Forms.TextBox();
            this.dgvHLV = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHLV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLamMoi.Location = new System.Drawing.Point(248, 397);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(134, 46);
            this.btnLamMoi.TabIndex = 24;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoa.Location = new System.Drawing.Point(104, 397);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(123, 46);
            this.btnXoa.TabIndex = 23;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSua.Location = new System.Drawing.Point(248, 332);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(134, 46);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThem.Location = new System.Drawing.Point(104, 332);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(123, 46);
            this.btnThem.TabIndex = 21;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSDT.Location = new System.Drawing.Point(208, 110);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(227, 30);
            this.txtSDT.TabIndex = 20;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHoTen.Location = new System.Drawing.Point(208, 56);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(227, 30);
            this.txtHoTen.TabIndex = 17;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSDT.Location = new System.Drawing.Point(44, 115);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(132, 25);
            this.lblSDT.TabIndex = 16;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // lblTenHLV
            // 
            this.lblTenHLV.AutoSize = true;
            this.lblTenHLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTenHLV.Location = new System.Drawing.Point(44, 61);
            this.lblTenHLV.Name = "lblTenHLV";
            this.lblTenHLV.Size = new System.Drawing.Size(97, 25);
            this.lblTenHLV.TabIndex = 13;
            this.lblTenHLV.Text = "Tên HLV:";
            // 
            // cboChuyenMon
            // 
            this.cboChuyenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboChuyenMon.FormattingEnabled = true;
            this.cboChuyenMon.Items.AddRange(new object[] {
            "Gym",
            "Yoga",
            "Boxing",
            "Cardio"});
            this.cboChuyenMon.Location = new System.Drawing.Point(208, 171);
            this.cboChuyenMon.Name = "cboChuyenMon";
            this.cboChuyenMon.Size = new System.Drawing.Size(227, 33);
            this.cboChuyenMon.TabIndex = 25;
            // 
            // lblChuyenMon
            // 
            this.lblChuyenMon.AutoSize = true;
            this.lblChuyenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblChuyenMon.Location = new System.Drawing.Point(44, 179);
            this.lblChuyenMon.Name = "lblChuyenMon";
            this.lblChuyenMon.Size = new System.Drawing.Size(130, 25);
            this.lblChuyenMon.TabIndex = 26;
            this.lblChuyenMon.Text = "Chuyên môn:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Đang làm việc",
            "Đã nghỉ"});
            this.cboTrangThai.Location = new System.Drawing.Point(208, 230);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(227, 33);
            this.cboTrangThai.TabIndex = 27;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTrangThai.Location = new System.Drawing.Point(44, 238);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(106, 25);
            this.lblTrangThai.TabIndex = 28;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 943);
            this.panel1.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTimKiem);
            this.panel3.Controls.Add(this.txtSearchHLV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(500, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1355, 35);
            this.panel3.TabIndex = 32;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTimKiem.Location = new System.Drawing.Point(55, 3);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(101, 25);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm Kiếm:";
            // 
            // txtSearchHLV
            // 
            this.txtSearchHLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchHLV.Location = new System.Drawing.Point(166, 3);
            this.txtSearchHLV.Name = "txtSearchHLV";
            this.txtSearchHLV.Size = new System.Drawing.Size(472, 30);
            this.txtSearchHLV.TabIndex = 0;
            this.txtSearchHLV.TextChanged += new System.EventHandler(this.txtSearchHLV_TextChanged);
            // 
            // dgvHLV
            // 
            this.dgvHLV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHLV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHLV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHLV.Location = new System.Drawing.Point(521, 56);
            this.dgvHLV.Name = "dgvHLV";
            this.dgvHLV.RowHeadersWidth = 51;
            this.dgvHLV.RowTemplate.Height = 24;
            this.dgvHLV.Size = new System.Drawing.Size(1188, 740);
            this.dgvHLV.TabIndex = 29;
            this.dgvHLV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHLV_CellClick);
            // 
            // ucHuanLuyenVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHLV);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblChuyenMon);
            this.Controls.Add(this.cboChuyenMon);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblTenHLV);
            this.Controls.Add(this.panel1);
            this.Name = "ucHuanLuyenVien";
            this.Size = new System.Drawing.Size(1855, 943);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHLV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblTenHLV;
        private System.Windows.Forms.ComboBox cboChuyenMon;
        private System.Windows.Forms.Label lblChuyenMon;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearchHLV;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridView dgvHLV;
    }
}
