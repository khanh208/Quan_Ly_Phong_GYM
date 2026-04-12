namespace Quan_Ly_Phong_GYM
{
    partial class ucKhachVangLai
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnInVe = new System.Windows.Forms.Button();
            this.dgvVeNgay = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeNgay)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numSoLuong
            // 
            this.numSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numSoLuong.Location = new System.Drawing.Point(255, 125);
            this.numSoLuong.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(190, 30);
            this.numSoLuong.TabIndex = 0;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.ValueChanged += new System.EventHandler(this.numSoLuong_ValueChanged);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSoLuong.Location = new System.Drawing.Point(97, 130);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(96, 25);
            this.lblSoLuong.TabIndex = 1;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDonGia.Location = new System.Drawing.Point(255, 180);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(190, 30);
            this.txtDonGia.TabIndex = 2;
            this.txtDonGia.Click += new System.EventHandler(this.txtDonGia_TextChanged);
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDonGia.Location = new System.Drawing.Point(97, 185);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(141, 25);
            this.lblDonGia.TabIndex = 3;
            this.lblDonGia.Text = "Đơn giá: (1 vé)";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblThanhTien.Location = new System.Drawing.Point(250, 239);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(70, 25);
            this.lblThanhTien.TabIndex = 4;
            this.lblThanhTien.Text = "0 VNĐ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(97, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thành tiền:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXacNhan.Location = new System.Drawing.Point(102, 363);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(134, 43);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận:";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnInVe
            // 
            this.btnInVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnInVe.Location = new System.Drawing.Point(288, 363);
            this.btnInVe.Name = "btnInVe";
            this.btnInVe.Size = new System.Drawing.Size(134, 43);
            this.btnInVe.TabIndex = 7;
            this.btnInVe.Text = "In vé:";
            this.btnInVe.UseVisualStyleBackColor = true;
            this.btnInVe.Click += new System.EventHandler(this.btnInVe_Click);
            // 
            // dgvVeNgay
            // 
            this.dgvVeNgay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVeNgay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVeNgay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeNgay.Location = new System.Drawing.Point(527, 75);
            this.dgvVeNgay.Name = "dgvVeNgay";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVeNgay.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVeNgay.RowHeadersWidth = 51;
            this.dgvVeNgay.RowTemplate.Height = 24;
            this.dgvVeNgay.Size = new System.Drawing.Size(1178, 812);
            this.dgvVeNgay.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numSoLuong);
            this.panel1.Controls.Add(this.lblSoLuong);
            this.panel1.Controls.Add(this.txtDonGia);
            this.panel1.Controls.Add(this.lblDonGia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.lblThanhTien);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnInVe);
            this.panel1.Controls.Add(this.btnXacNhan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 1041);
            this.panel1.TabIndex = 9;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGhiChu.Location = new System.Drawing.Point(255, 289);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(190, 30);
            this.txtGhiChu.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(97, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ghi chú:";
            // 
            // ucKhachVangLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvVeNgay);
            this.Controls.Add(this.panel1);
            this.Name = "ucKhachVangLai";
            this.Size = new System.Drawing.Size(1931, 1041);
            this.Load += new System.EventHandler(this.ucKhachVangLai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeNgay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnInVe;
        private System.Windows.Forms.DataGridView dgvVeNgay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGhiChu;
    }
}
