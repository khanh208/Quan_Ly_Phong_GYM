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

            // 2. Lấy MaNV an toàn
            int maNV = 0;
            if (cboNhanVien.SelectedValue != null && int.TryParse(cboNhanVien.SelectedValue.ToString(), out int id))
            {
                maNV = id;
            }

            // Tạo chuỗi lọc SQL cho Gói tập và Vé ngày
            string filterNV = (maNV > 0) ? $" AND MaNV = {maNV}" : "";

            // Xử lý riêng cho Gói PT (Vì bảng DangKyPT hiện tại không lưu MaNV người bán)
            // Nếu chọn "Tất cả nhân viên" (maNV == 0) thì mới cộng tiền PT vào
            string sqlGop_PT = (maNV == 0) ? $" UNION ALL SELECT CAST(NgayDangKy AS DATE) as Ngay, ThanhTien as Tien FROM DangKyPT WHERE NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}'" : "";
            string sqlChiTiet_PT = (maNV == 0) ? $" UNION ALL SELECT N'Gói PT' as Loai, pt.NgayDangKy as Ngay, N'Hệ thống' as NguoiBan, pt.ThanhTien FROM DangKyPT pt WHERE pt.NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}'" : "";

            try
            {
                // 3. SQL gộp doanh thu cho Biểu đồ (Đã bổ sung Gói PT)
                string sqlGop = $@"
            SELECT Ngay, SUM(Tien) as DoanhThu FROM (
                SELECT CAST(NgayDangKy AS DATE) as Ngay, TongTien as Tien FROM DangKy 
                WHERE NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV}
                
                UNION ALL
                
                SELECT CAST(NgayBan AS DATE) as Ngay, (SoLuong * DonGia) as Tien FROM VeNgay 
                WHERE NgayBan BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV}
                
                {sqlGop_PT}
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

                // 5. SQL chi tiết danh sách (Đã bổ sung Gói PT)
                string filterNV_DK = (maNV > 0) ? $" AND dk.MaNV = {maNV}" : "";
                string filterNV_VN = (maNV > 0) ? $" AND vn.MaNV = {maNV}" : "";

                string sqlChiTiet = $@"
            SELECT N'Gói Tập' as Loai, dk.NgayDangKy as Ngay, nv.HoTen as NguoiBan, dk.TongTien 
            FROM DangKy dk JOIN NhanVien nv ON dk.MaNV = nv.MaNV 
            WHERE dk.NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV_DK}
            
            UNION ALL
            
            SELECT N'Vãng Lai' as Loai, vn.NgayBan as Ngay, nv.HoTen as NguoiBan, (vn.SoLuong * vn.DonGia) as TongTien 
            FROM VeNgay vn JOIN NhanVien nv ON vn.MaNV = nv.MaNV 
            WHERE vn.NgayBan BETWEEN '{tuNgay}' AND '{denNgay}' {filterNV_VN}
            
            {sqlChiTiet_PT}
            
            ORDER BY Ngay DESC";

                dgvChiTiet.DataSource = db.ExecuteQuery(sqlChiTiet);

                // Căn chỉnh DataGridView cho đẹp
                if (dgvChiTiet.Columns.Count > 0)
                {
                    dgvChiTiet.Columns["Loai"].HeaderText = "Loại Thu";
                    dgvChiTiet.Columns["Ngay"].HeaderText = "Ngày Giao Dịch";
                    dgvChiTiet.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvChiTiet.Columns["NguoiBan"].HeaderText = "Người Thu Tiền";
                    dgvChiTiet.Columns["TongTien"].HeaderText = "Số Tiền (VNĐ)";
                    dgvChiTiet.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    dgvChiTiet.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thống kê: " + ex.Message); }
        }

        // Nút Lọc và Nút Thống kê giờ đây có cùng 1 chức năng, gọi thẳng hàm ThongKeDoanhThu
        private void btnLoc_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("DoanhThu");

                // Đổ tiêu đề từ DataGridView vào Excel
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

                // Căn chỉnh cột Excel cho vừa vặn chữ
                worksheet.Columns().AdjustToContents();

                // Lưu file
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "ThongKeDoanhThu.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Đã xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(sfd.FileName); // Mở file ngay sau khi lưu
                }
            }
        }
    }
}