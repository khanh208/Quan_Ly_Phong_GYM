using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucDashboard : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        // HÀM KHỞI TẠO (Luôn chạy đầu tiên khi mở Dashboard)
        public ucDashboard()
        {
            InitializeComponent();

            // 1. PHÂN QUYỀN: Ẩn Doanh thu nếu là nhân viên
            if (Session.ChucVu != null)
            {
                string quyen = Session.ChucVu.Trim().ToUpper();
                // Dùng Contains để bắt chính xác dù có dư khoảng trắng
                if (quyen.Contains("NHÂN VIÊN") || quyen.Contains("NHAN VIEN") || quyen.Contains("NHANVIEN"))
                {
                    panel4.Visible = false; // Ẩn panel màu xanh dương (Doanh thu)
                }
            }

            // 2. Chạy load dữ liệu ngay khi vừa khởi tạo
            LoadDashboardData();
        }

        // Hàm xử lý tải dữ liệu cho 4 ô
        private void LoadDashboardData()
        {
            try
            {
                // 1. Lấy Tổng Hội Viên
                DataTable dtHoiVien = db.ExecuteQuery("SELECT COUNT(*) FROM HoiVien");
                lblTongHoiVien.Text = "TỔNG HỘI VIÊN\n" + dtHoiVien.Rows[0][0].ToString();

                // 2. Lấy Doanh Thu Tháng 
                string sqlDoanhThu = @"SELECT ISNULL(SUM(Tien), 0) FROM (
                                SELECT TongTien AS Tien FROM DangKy 
                                WHERE MONTH(NgayDangKy) = MONTH(GETDATE()) AND YEAR(NgayDangKy) = YEAR(GETDATE())
                                UNION ALL
                                SELECT (SoLuong * DonGia) AS Tien FROM VeNgay 
                                WHERE MONTH(NgayBan) = MONTH(GETDATE()) AND YEAR(NgayBan) = YEAR(GETDATE())
                                UNION ALL
                                SELECT ThanhTien AS Tien FROM DangKyPT 
                                WHERE MONTH(NgayDangKy) = MONTH(GETDATE()) AND YEAR(NgayDangKy) = YEAR(GETDATE())
                             ) AS Result";
                DataTable dtDoanhThu = db.ExecuteQuery(sqlDoanhThu);
                decimal tongTien = Convert.ToDecimal(dtDoanhThu.Rows[0][0]);
                lblDoanhThuThang.Text = "DOANH THU THÁNG\n" + tongTien.ToString("N0") + " VNĐ";

                // 3. Lấy số người sắp hết hạn (3 ngày tới)
                string sqlHetHan = "SELECT COUNT(*) FROM DangKy WHERE NgayHetHan BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(day, 3, CAST(GETDATE() AS DATE))";
                DataTable dtHetHan = db.ExecuteQuery(sqlHetHan);
                lblSapHetHan.Text = "SẮP HẾT HẠN\n" + dtHetHan.Rows[0][0].ToString();

                // 4. Lấy số Hội viên đang tập
                string sqlDangTap = "SELECT COUNT(DISTINCT MaHV) FROM DangKy WHERE NgayHetHan >= CAST(GETDATE() AS DATE)";
                DataTable dtDangTap = db.ExecuteQuery(sqlDangTap);
                lblHoiVienDangTap.Text = "HỘI VIÊN ĐANG TẬP\n" + dtDangTap.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load dashboard: " + ex.Message);
            }
        }

        // Sự kiện Timer lặp lại mỗi 5 giây (đã cài đặt bên Designer)
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}