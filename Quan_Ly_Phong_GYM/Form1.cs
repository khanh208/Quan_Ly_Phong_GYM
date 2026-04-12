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

        // BỔ SUNG: Sự kiện Load để thực hiện phân quyền ngay khi mở Form
        private void Form1_Load(object sender, EventArgs e)
        {
            lblUserActive.Text = $"Xin chào: {Session.HoTen} ({Session.ChucVu})";

            // Chuẩn hóa chuỗi trước khi so sánh
            string quyen = Session.ChucVu.Trim().ToUpper();

            // Nếu là NHÂN VIÊN (ghi đúng chữ trong Database của em, ví dụ: "NHÂN VIÊN")
            if (quyen == "NHÂN VIÊN" || quyen == "NHANVIEN")
            {
                // Ẩn các chức năng chỉ dành cho Admin
                btnThongKe.Visible = false;      // Thống kê
                btnNhanVien.Visible = false;     // Quản lý Nhân viên
                btnGoiTap.Visible = false;       // Quản lý Gói tập
                btnKhuyenMai.Visible = false;    // Quản lý Khuyến mãi
                button1.Visible = false;         // Quản lý Huấn luyện viên (Nút này đang mang tên button1)
            }
            ucDashboard ucDash = new ucDashboard();
            addUserControl(ucDash);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // --- CÁC NÚT NGHIỆP VỤ (Đã có của em) ---

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

        private void btnKhachVangLai_Click(object sender, EventArgs e)
        {
            ucKhachVangLai uc = new ucKhachVangLai();
            addUserControl(uc);
        }

        // --- BỔ SUNG: CÁC NÚT DÀNH CHO ADMIN ---

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ucThongKe uc = new ucThongKe();
            addUserControl(uc);
            // uc.ThongKeDoanhThu(); // Nếu em có hàm load mặc định
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ucQuanLyNhanVien uc = new ucQuanLyNhanVien();
            addUserControl(uc);
            uc.LoadData();
        }

        // --- ĐĂNG XUẤT ---

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                Application.Restart(); // Khởi động lại để hiện Form Login
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Mở Form đổi mật khẩu lên dưới dạng hộp thoại (phải xử lý xong mới quay lại Form chính được)
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ucDashboard ucDash = new ucDashboard();
            addUserControl(ucDash);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            ucCheckIn uc = new ucCheckIn();
            addUserControl(uc);
        }

        private void btnDangKyPY_Click(object sender, EventArgs e)
        {
            ucDangKyPT uc = new ucDangKyPT();
            addUserControl(uc);
        }
    }
}