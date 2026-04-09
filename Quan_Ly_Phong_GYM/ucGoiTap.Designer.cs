namespace Quan_Ly_Phong_GYM
{
    partial class ucGoiTap
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
            this.txtTenGoi = new System.Windows.Forms.TextBox();
            this.lblTenGoi = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.numThoiHan = new System.Windows.Forms.NumericUpDown();
            this.lblThoiHan = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlSearchArea = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtSearchGoiTap = new System.Windows.Forms.TextBox();
            this.dgvGoiTap = new System.Windows.Forms.DataGridView();
            this.txtMaGoi = new System.Windows.Forms.TextBox();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlSearchArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiTap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenGoi
            // 
            this.txtTenGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenGoi.Location = new System.Drawing.Point(226, 90);
            this.txtTenGoi.Name = "txtTenGoi";
            this.txtTenGoi.Size = new System.Drawing.Size(179, 30);
            this.txtTenGoi.TabIndex = 0;
            // 
            // lblTenGoi
            // 
            this.lblTenGoi.AutoSize = true;
            this.lblTenGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTenGoi.Location = new System.Drawing.Point(38, 95);
            this.lblTenGoi.Name = "lblTenGoi";
            this.lblTenGoi.Size = new System.Drawing.Size(84, 25);
            this.lblTenGoi.TabIndex = 1;
            this.lblTenGoi.Text = "Tên gói:";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGia.Location = new System.Drawing.Point(38, 153);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(48, 25);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Giá:";
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGia.Location = new System.Drawing.Point(226, 148);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(179, 30);
            this.txtGia.TabIndex = 3;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.txtMaGoi);
            this.pnlInput.Controls.Add(this.btnLamMoi);
            this.pnlInput.Controls.Add(this.btnXoa);
            this.pnlInput.Controls.Add(this.btnSua);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.txtGhiChu);
            this.pnlInput.Controls.Add(this.lblGhiChu);
            this.pnlInput.Controls.Add(this.numThoiHan);
            this.pnlInput.Controls.Add(this.lblThoiHan);
            this.pnlInput.Controls.Add(this.lblGia);
            this.pnlInput.Controls.Add(this.txtGia);
            this.pnlInput.Controls.Add(this.lblTenGoi);
            this.pnlInput.Controls.Add(this.txtTenGoi);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(500, 685);
            this.pnlInput.TabIndex = 4;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLamMoi.Location = new System.Drawing.Point(226, 417);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(134, 46);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoa.Location = new System.Drawing.Point(82, 417);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(123, 46);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSua.Location = new System.Drawing.Point(226, 352);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(134, 46);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThem.Location = new System.Drawing.Point(82, 352);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(123, 46);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGhiChu.Location = new System.Drawing.Point(226, 273);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(163, 30);
            this.txtGhiChu.TabIndex = 7;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGhiChu.Location = new System.Drawing.Point(38, 273);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(85, 25);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // numThoiHan
            // 
            this.numThoiHan.Location = new System.Drawing.Point(226, 211);
            this.numThoiHan.Name = "numThoiHan";
            this.numThoiHan.Size = new System.Drawing.Size(163, 30);
            this.numThoiHan.TabIndex = 5;
            // 
            // lblThoiHan
            // 
            this.lblThoiHan.AutoSize = true;
            this.lblThoiHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblThoiHan.Location = new System.Drawing.Point(38, 211);
            this.lblThoiHan.Name = "lblThoiHan";
            this.lblThoiHan.Size = new System.Drawing.Size(160, 25);
            this.lblThoiHan.TabIndex = 4;
            this.lblThoiHan.Text = "Thời hạn (Ngày):";
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.pnlSearchArea);
            this.pnlData.Controls.Add(this.dgvGoiTap);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlData.Location = new System.Drawing.Point(500, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(775, 685);
            this.pnlData.TabIndex = 5;
            // 
            // pnlSearchArea
            // 
            this.pnlSearchArea.Controls.Add(this.lblTimKiem);
            this.pnlSearchArea.Controls.Add(this.txtSearchGoiTap);
            this.pnlSearchArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchArea.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchArea.Name = "pnlSearchArea";
            this.pnlSearchArea.Size = new System.Drawing.Size(775, 35);
            this.pnlSearchArea.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(50, 3);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(101, 25);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm Kiếm:";
            // 
            // txtSearchGoiTap
            // 
            this.txtSearchGoiTap.Location = new System.Drawing.Point(157, 0);
            this.txtSearchGoiTap.Name = "txtSearchGoiTap";
            this.txtSearchGoiTap.Size = new System.Drawing.Size(491, 30);
            this.txtSearchGoiTap.TabIndex = 0;
            this.txtSearchGoiTap.TextChanged += new System.EventHandler(this.txtSearchGoiTap_TextChanged);
            // 
            // dgvGoiTap
            // 
            this.dgvGoiTap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGoiTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoiTap.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvGoiTap.Location = new System.Drawing.Point(6, 36);
            this.dgvGoiTap.Name = "dgvGoiTap";
            this.dgvGoiTap.RowHeadersWidth = 51;
            this.dgvGoiTap.RowTemplate.Height = 24;
            this.dgvGoiTap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoiTap.Size = new System.Drawing.Size(769, 649);
            this.dgvGoiTap.TabIndex = 1;
            this.dgvGoiTap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoiTap_CellClick);
            // 
            // txtMaGoi
            // 
            this.txtMaGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaGoi.Location = new System.Drawing.Point(226, 36);
            this.txtMaGoi.Name = "txtMaGoi";
            this.txtMaGoi.Size = new System.Drawing.Size(179, 30);
            this.txtMaGoi.TabIndex = 17;
            this.txtMaGoi.Visible = false;
            // 
            // ucGoiTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlInput);
            this.Name = "ucGoiTap";
            this.Size = new System.Drawing.Size(1275, 685);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlSearchArea.ResumeLayout(false);
            this.pnlSearchArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiTap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenGoi;
        private System.Windows.Forms.Label lblTenGoi;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.NumericUpDown numThoiHan;
        private System.Windows.Forms.Label lblThoiHan;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSearchGoiTap;
        private System.Windows.Forms.DataGridView dgvGoiTap;
        private System.Windows.Forms.Panel pnlSearchArea;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtMaGoi;
    }
}
