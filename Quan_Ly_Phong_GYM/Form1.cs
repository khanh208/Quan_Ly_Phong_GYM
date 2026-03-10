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

        // Hàm dùng chung để hiển thị UserControl vào panel chính
        // Hàm dùng chung để hiển thị UserControl vào vùng TRỐNG (pnlMain)
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear(); // Xóa nội dung cũ trong vùng trắng
            pnlMain.Controls.Add(userControl); // Thêm nội dung mới vào vùng trắng
            userControl.BringToFront();
        }

        // Sự kiện khi bấm nút Hội Viên
        private void btnHoiVien_Click(object sender, EventArgs e)
        {
            ucHoiVien uc = new ucHoiVien();
            addUserControl(uc);
            uc.LoadData(); // Gọi nạp dữ liệu ngay sau khi hiển thị UserControl
        }

        // Tương tự cho các nút khác khi em tạo xong các UserControl tương ứng
        private void btnGoiTap_Click(object sender, EventArgs e)
        {
            // ucGoiTap uc = new ucGoiTap();
            // addUserControl(uc);
        }

    }
}