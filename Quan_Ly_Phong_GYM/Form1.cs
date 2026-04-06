using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear(); 
            pnlMain.Controls.Add(userControl); 
            userControl.BringToFront();
        }

        private void btnHoiVien_Click(object sender, EventArgs e)
        {
            ucHoiVien uc = new ucHoiVien();
            addUserControl(uc);
            uc.LoadData(); 
        }

        private void btnGoiTap_Click(object sender, EventArgs e)
        {
            ucGoiTap uc = new ucGoiTap();
            addUserControl(uc); 
            uc.LoadData();
        }
        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            ucKhuyenMai uc = new ucKhuyenMai();
            addUserControl(uc);
            uc.LoadData();
        }
        private void btnHLV_Click(object sender, EventArgs e)
        {
            ucHuanLuyenVien uc = new ucHuanLuyenVien();
            addUserControl(uc);
            uc.LoadData();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            ucDangKy uc = new ucDangKy();
            addUserControl(uc);
            uc.LoadAllComboBox();
            uc.LoadData();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ucThongKe uc = new ucThongKe();
            addUserControl(uc);
        }

        private void btnKhachVangLai_Click(object sender, EventArgs e)
        {
            ucKhachVangLai uc = new ucKhachVangLai();
            addUserControl(uc);
        }
    }
}