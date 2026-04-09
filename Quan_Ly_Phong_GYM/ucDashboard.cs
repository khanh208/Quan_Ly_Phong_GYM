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
    public partial class ucDashboard : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();
        public ucDashboard()
        {
            InitializeComponent();
        }
        private void LoadDashboardData()
        {
            try
            {
                // 1. Lấy Tổng Hội Viên
                DataTable dtHoiVien = db.ExecuteQuery("SELECT COUNT(*) FROM HoiVien");
                lblTongHoiVien.Text = dtHoiVien.Rows[0][0].ToString();

                // 2. Lấy Doanh Thu Tháng (Sử dụng câu SQL gộp ở trên)
                string sqlDoanhThu = @"SELECT ISNULL(SUM(Tien), 0) FROM (
                                SELECT TongTien AS Tien FROM DangKy 
                                WHERE MONTH(NgayDangKy) = MONTH(GETDATE()) AND YEAR(NgayDangKy) = YEAR(GETDATE())
                                UNION ALL
                                SELECT (SoLuong * DonGia) AS Tien FROM VeNgay 
                                WHERE MONTH(NgayBan) = MONTH(GETDATE()) AND YEAR(NgayBan) = YEAR(GETDATE())
                             ) AS Result";
                DataTable dtDoanhThu = db.ExecuteQuery(sqlDoanhThu);
                decimal tongTien = Convert.ToDecimal(dtDoanhThu.Rows[0][0]);
                lblDoanhThuThang.Text = tongTien.ToString("N0") + " VNĐ";

                // 3. Lấy số người sắp hết hạn (3 ngày tới)
                string sqlHetHan = "SELECT COUNT(*) FROM DangKy WHERE NgayHetHan BETWEEN GETDATE() AND DATEADD(day, 3, GETDATE())";
                DataTable dtHetHan = db.ExecuteQuery(sqlHetHan);
                lblSapHetHan.Text = dtHetHan.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
            }
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            // 1. Chạy lần đầu ngay khi mở trang
            LoadDashboardData();

            // 2. Thiết lập Timer để chạy các lần tiếp theo
            Timer timerRefresh = new Timer();
            timerRefresh.Interval = 300000; // 5 phút = 300,000 ms
            timerRefresh.Tick += timerRefresh_Tick; // Gán sự kiện
            timerRefresh.Start(); // Bắt đầu đếm giờ
        }
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadDashboardData();

            // (Tùy chọn) In ra thông báo nhỏ ở góc để biết app vừa cập nhật
            Console.WriteLine("Dashboard vừa cập nhật lúc: " + DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
