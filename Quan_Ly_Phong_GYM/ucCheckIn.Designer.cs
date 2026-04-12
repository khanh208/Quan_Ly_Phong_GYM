namespace Quan_Ly_Phong_GYM
{
    partial class ucCheckIn
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
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.dgvDangTap = new System.Windows.Forms.DataGridView();
            this.lblMaHV = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMaHV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangTap)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCheckIn.Location = new System.Drawing.Point(113, 160);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(217, 41);
            this.btnCheckIn.TabIndex = 0;
            this.btnCheckIn.Text = "Check-in/Check-out";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // dgvDangTap
            // 
            this.dgvDangTap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDangTap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDangTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangTap.Location = new System.Drawing.Point(475, 63);
            this.dgvDangTap.Name = "dgvDangTap";
            this.dgvDangTap.RowHeadersWidth = 51;
            this.dgvDangTap.RowTemplate.Height = 24;
            this.dgvDangTap.Size = new System.Drawing.Size(1258, 786);
            this.dgvDangTap.TabIndex = 36;
            // 
            // lblMaHV
            // 
            this.lblMaHV.AutoSize = true;
            this.lblMaHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMaHV.Location = new System.Drawing.Point(59, 71);
            this.lblMaHV.Name = "lblMaHV";
            this.lblMaHV.Size = new System.Drawing.Size(125, 25);
            this.lblMaHV.TabIndex = 26;
            this.lblMaHV.Text = "Mã Hội Viên:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMaHV);
            this.panel1.Controls.Add(this.btnCheckIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 950);
            this.panel1.TabIndex = 37;
            // 
            // txtMaHV
            // 
            this.txtMaHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaHV.Location = new System.Drawing.Point(218, 63);
            this.txtMaHV.Multiline = true;
            this.txtMaHV.Name = "txtMaHV";
            this.txtMaHV.Size = new System.Drawing.Size(200, 33);
            this.txtMaHV.TabIndex = 38;
            // 
            // ucCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDangTap);
            this.Controls.Add(this.lblMaHV);
            this.Controls.Add(this.panel1);
            this.Name = "ucCheckIn";
            this.Size = new System.Drawing.Size(1745, 950);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangTap)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.DataGridView dgvDangTap;
        private System.Windows.Forms.Label lblMaHV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMaHV;
    }
}
