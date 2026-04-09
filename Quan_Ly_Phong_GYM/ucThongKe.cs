using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucThongKe : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucThongKe()
        {
            InitializeComponent();
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {

            // Thiết lập ngày mặc định: Từ đầu tháng đến hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            LoadNhanVien();
            ThongKeDoanhThu();
        }

        // Nạp danh sách nhân viên vào ComboBox để lọc
        private void LoadNhanVien()
        {
            try
            {
                // 1. Lấy danh sách nhân viên từ DB
                string sql = "SELECT MaNV, HoTen FROM NhanVien WHERE TrangThai = N'Đang làm việc'";
                DataTable dt = db.ExecuteQuery(sql);

                // 2. TẠO DÒNG "TẤT CẢ NHÂN VIÊN" MỒI VÀO ĐẦU BẢNG
                DataRow dr = dt.NewRow();
                dr["MaNV"] = 0; // Gán ID bằng 0 để nhận diện là chọn tất cả
                dr["HoTen"] = "--- Tất cả nhân viên ---";
                dt.Rows.InsertAt(dr, 0); // Chèn vào vị trí đầu tiên (index 0)

                // 3. Đổ dữ liệu vào ComboBox
                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "HoTen";  // Tên hiển thị cho người dùng xem
                cboNhanVien.ValueMember = "MaNV";     // Giá trị ẩn bên dưới để code xử lý
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách nhân viên: " + ex.Message);
            }
        }

        private void ThongKeDoanhThu()
        {
            // 1. Lấy ngày từ DateTimePicker
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd 00:00:00");
            string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd 23:59:59");

            // 2. Lấy MaNV an toàn (Tránh lỗi Crash)
            int maNV = 0;
            if (cboNhanVien.SelectedValue != null && int.TryParse(cboNhanVien.SelectedValue.ToString(), out int id))
            {
                maNV = id;
            }

            // Tạo chuỗi lọc SQL
            string filterNV = (maNV > 0) ? $" AND MaNV = {maNV}" : "";

            try
            {
                // 3. SQL gộp doanh thu cho Biểu đồ
                string sqlGop = $@"
            SELECT Ngay, SUM(Tien) as DoanhThu FROM (
                SELECT CAST(NgayDangKy AS DATE) as Ngay, TongTien as Tien FROM DangKy 
                WHERE NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV}
                UNION ALL
                SELECT CAST(NgayBan AS DATE) as Ngay, (SoLuong * DonGia) as Tien FROM VeNgay 
                WHERE NgayBan BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV}
            ) t
            GROUP BY Ngay ORDER BY Ngay ASC";

                DataTable dtDoanhThu = db.ExecuteQuery(sqlGop);

                // Hiển thị tổng doanh thu lên Label
                decimal tong = 0;
                foreach (DataRow r in dtDoanhThu.Rows)
                    tong += Convert.ToDecimal(r["DoanhThu"]);

                lblTongDoanhThu.Text = tong.ToString("N0") + " VNĐ";

                // 4. Vẽ biểu đồ
                chartDoanhThu.Series.Clear();
                chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
                var series = chartDoanhThu.Series.Add("Tổng Doanh Thu");
                series.ChartType = SeriesChartType.Column;
                series.XValueMember = "Ngay";
                series.YValueMembers = "DoanhThu";
                chartDoanhThu.DataSource = dtDoanhThu;
                chartDoanhThu.DataBind();

                // 5. SQL chi tiết danh sách (Quan trọng: Chỉ rõ bảng khi lọc MaNV)
                string filterNV_DK = (maNV > 0) ? $" AND dk.MaNV = {maNV}" : "";
                string filterNV_VN = (maNV > 0) ? $" AND vn.MaNV = {maNV}" : "";

                string sqlChiTiet = $@"
            SELECT 'Hội Viên' as Loai, dk.NgayDangKy as Ngay, nv.HoTen as NguoiBan, dk.TongTien 
            FROM DangKy dk JOIN NhanVien nv ON dk.MaNV = nv.MaNV 
            WHERE dk.NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV_DK}
            UNION ALL
            SELECT 'Vãng Lai' as Loai, vn.NgayBan as Ngay, nv.HoTen as NguoiBan, (vn.SoLuong * vn.DonGia) as TongTien 
            FROM VeNgay vn JOIN NhanVien nv ON vn.MaNV = nv.MaNV 
            WHERE vn.NgayBan BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV_VN}
            ORDER BY Ngay DESC";

                dgvChiTiet.DataSource = db.ExecuteQuery(sqlChiTiet);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thống kê: " + ex.Message); }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int maNVChon = Convert.ToInt32(cboNhanVien.SelectedValue);

            string filter = "";
            // Nếu maNVChon > 0 nghĩa là đang chọn một người cụ thể
            if (maNVChon > 0)
            {
                filter = $" AND MaNV = {maNVChon}";
            }

            // Sau đó cộng chuỗi filter này vào câu SQL thống kê của em
            string sql = "SELECT ... FROM VeNgay WHERE NgayBan BETWEEN ... " + filter;

            ThongKeDoanhThu();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu(); // Nhấn nút là phải chạy lại hàm tính toán
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("DoanhThu");

                // Đổ tiêu đề từ DataGridView vào Excel (Dùng vòng lặp đơn giản)
                for (int i = 1; i <= dgvChiTiet.Columns.Count; i++)
                {
                    worksheet.Cell(1, i).Value = dgvChiTiet.Columns[i - 1].HeaderText;
                }

                // Đổ dữ liệu
                for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvChiTiet.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dgvChiTiet.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Lưu file
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Đã xuất file thành công!");
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }
    }
}
