namespace Quan_Ly_Phong_GYM
{
    partial class ucDangKyPT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDanhSachPT = new System.Windows.Forms.DataGridView();
            this.lblHoiVien = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblGoiBuoi = new System.Windows.Forms.Label();
            this.lblHLV = new System.Windows.Forms.Label();
            this.cboGoiBuoi = new System.Windows.Forms.ComboBox();
            this.cboHLV = new System.Windows.Forms.ComboBox();
            this.cboHoiVien = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPT)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDanhSachPT
            // 
            this.dgvDanhSachPT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachPT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachPT.Location = new System.Drawing.Point(450, 63);
            this.dgvDanhSachPT.Name = "dgvDanhSachPT";
            this.dgvDanhSachPT.RowHeadersWidth = 51;
            this.dgvDanhSachPT.RowTemplate.Height = 24;
            this.dgvDanhSachPT.Size = new System.Drawing.Size(1258, 786);
            this.dgvDanhSachPT.TabIndex = 39;
            // 
            // lblHoiVien
            // 
            this.lblHoiVien.AutoSize = true;
            this.lblHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblHoiVien.Location = new System.Drawing.Point(27, 71);
            this.lblHoiVien.Name = "lblHoiVien";
            this.lblHoiVien.Size = new System.Drawing.Size(92, 25);
            this.lblHoiVien.TabIndex = 38;
            this.lblHoiVien.Text = "Hội Viên:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTongTien);
            this.panel1.Controls.Add(this.lblThanhTien);
            this.panel1.Controls.Add(this.lblGoiBuoi);
            this.panel1.Controls.Add(this.lblHLV);
            this.panel1.Controls.Add(this.cboGoiBuoi);
            this.panel1.Controls.Add(this.cboHLV);
            this.panel1.Controls.Add(this.cboHoiVien);
            this.panel1.Controls.Add(this.lblHoiVien);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 964);
            this.panel1.TabIndex = 40;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTongTien.Location = new System.Drawing.Point(27, 276);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 25);
            this.lblTongTien.TabIndex = 49;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblThanhTien.Location = new System.Drawing.Point(213, 276);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(120, 25);
            this.lblThanhTien.TabIndex = 48;
            this.lblThanhTien.Text = "Thành tiền...";
            // 
            // lblGoiBuoi
            // 
            this.lblGoiBuoi.AutoSize = true;
            this.lblGoiBuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGoiBuoi.Location = new System.Drawing.Point(27, 213);
            this.lblGoiBuoi.Name = "lblGoiBuoi";
            this.lblGoiBuoi.Size = new System.Drawing.Size(87, 25);
            this.lblGoiBuoi.TabIndex = 47;
            this.lblGoiBuoi.Text = "Số Buổi:";
            // 
            // lblHLV
            // 
            this.lblHLV.AutoSize = true;
            this.lblHLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblHLV.Location = new System.Drawing.Point(27, 142);
            this.lblHLV.Name = "lblHLV";
            this.lblHLV.Size = new System.Drawing.Size(169, 25);
            this.lblHLV.TabIndex = 46;
            this.lblHLV.Text = "Huấn Luyện Viên:";
            // 
            // cboGoiBuoi
            // 
            this.cboGoiBuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboGoiBuoi.FormattingEnabled = true;
            this.cboGoiBuoi.Location = new System.Drawing.Point(218, 205);
            this.cboGoiBuoi.Name = "cboGoiBuoi";
            this.cboGoiBuoi.Size = new System.Drawing.Size(200, 33);
            this.cboGoiBuoi.TabIndex = 45;
            this.cboGoiBuoi.SelectedIndexChanged += new System.EventHandler(this.cboGoiBuoi_SelectedIndexChanged);
            // 
            // cboHLV
            // 
            this.cboHLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboHLV.FormattingEnabled = true;
            this.cboHLV.Location = new System.Drawing.Point(218, 139);
            this.cboHLV.Name = "cboHLV";
            this.cboHLV.Size = new System.Drawing.Size(200, 33);
            this.cboHLV.TabIndex = 44;
            // 
            // cboHoiVien
            // 
            this.cboHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboHoiVien.FormattingEnabled = true;
            this.cboHoiVien.Location = new System.Drawing.Point(218, 68);
            this.cboHoiVien.Name = "cboHoiVien";
            this.cboHoiVien.Size = new System.Drawing.Size(200, 33);
            this.cboHoiVien.TabIndex = 43;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLuu.Location = new System.Drawing.Point(137, 366);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(162, 46);
            this.btnLuu.TabIndex = 39;
            this.btnLuu.Text = "Lưu/Gia hạn";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // ucDangKyPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDanhSachPT);
            this.Controls.Add(this.panel1);
            this.Name = "ucDangKyPT";
            this.Size = new System.Drawing.Size(1718, 964);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDanhSachPT;
        private System.Windows.Forms.Label lblHoiVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cboHoiVien;
        private System.Windows.Forms.ComboBox cboGoiBuoi;
        private System.Windows.Forms.ComboBox cboHLV;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblGoiBuoi;
        private System.Windows.Forms.Label lblHLV;
        private System.Windows.Forms.Label lblTongTien;
    }
}
