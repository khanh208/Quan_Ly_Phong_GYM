using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucDangKy : UserControl
    {
        // Khai báo lớp kết nối CSDL
        DatabaseHelper db = new DatabaseHelper();

        public ucDangKy()
        {
            InitializeComponent();
        }

        private void ucDangKy_Load(object sender, EventArgs e)
        {
            LoadAllComboBox();
            LoadData(); // Nạp danh sách lịch sử đăng ký lên bảng bên phải
        }

        // 1. Hàm nạp dữ liệu vào các ComboBox từ SQL
        public void LoadAllComboBox()
        {
            try
            {
                // Nạp Hội viên
                DataTable dtHV = db.ExecuteQuery("SELECT MaHV, HoTen FROM HoiVien");
                cboHoiVien.DataSource = dtHV;
                cboHoiVien.DisplayMember = "HoTen";
                cboHoiVien.ValueMember = "MaHV";

                // Nạp Gói tập
                DataTable dtGoi = db.ExecuteQuery("SELECT MaGoi, TenGoi FROM GoiTap");
                cboGoiTap.DataSource = dtGoi;
                cboGoiTap.DisplayMember = "TenGoi";
                cboGoiTap.ValueMember = "MaGoi";

                // Nạp HLV (Sử dụng tên bảng HLV theo CSDL của em)
                DataTable dtHLV = db.ExecuteQuery("SELECT MaHLV, HoTen FROM HLV");
                cboHLV.DataSource = dtHLV;
                cboHLV.DisplayMember = "HoTen";
                cboHLV.ValueMember = "MaHLV";

                // Nạp Khuyến mãi
                DataTable dtKM = db.ExecuteQuery("SELECT MaKM, TenKM FROM KhuyenMai");
                cboKhuyenMai.DataSource = dtKM;
                cboKhuyenMai.DisplayMember = "TenKM";
                cboKhuyenMai.ValueMember = "MaKM";

                // Reset các ô chọn về trạng thái trống khi mới mở trang
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nạp ComboBox: " + ex.Message); }
        }

        // 2. Hàm nạp danh sách đăng ký lên DataGridView (Dùng JOIN để hiện tên thay vì hiện ID)
        public void LoadData()
        {
            // Sử dụng LEFT JOIN để nếu không có HLV hoặc KM thì dòng đó vẫn hiện ra
            string query = @"SELECT dk.MaDK, hv.HoTen as [Hội Viên], gt.TenGoi as [Gói Tập], 
                            hlv.HoTen as [HLV], km.TenKM as [Khuyến Mãi], 
                            dk.NgayDangKy, dk.NgayHetHan, dk.TongTien
                            FROM DangKy dk
                            JOIN HoiVien hv ON dk.MaHV = hv.MaHV
                            JOIN GoiTap gt ON dk.MaGoi = gt.MaGoi
                            LEFT JOIN HLV hlv ON dk.MaHLV = hlv.MaHLV
                            LEFT JOIN KhuyenMai km ON dk.MaKM = km.MaKM
                            ORDER BY dk.MaDK DESC"; // Hiện phiếu mới nhất lên đầu

            dgvDangKy.DataSource = db.ExecuteQuery(query);

            if (dgvDangKy.Columns["TongTien"] != null)
                dgvDangKy.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }

        // 3. Hàm tính toán tự động mỗi khi người dùng thay đổi lựa chọn
        private void TinhToanPhieu(object sender, EventArgs e)
        {
            // Kiểm tra tránh lỗi khi ComboBox đang nạp dữ liệu (DataRowView)
            if (cboGoiTap.SelectedValue == null || cboGoiTap.SelectedValue is DataRowView) return;

            try
            {
                // Lấy thông tin Gói tập (Giá và Thời hạn)
                string maGoi = cboGoiTap.SelectedValue.ToString();
                DataTable dtGoi = db.ExecuteQuery($"SELECT Gia, ThoiHan FROM GoiTap WHERE MaGoi = {maGoi}");
                if (dtGoi.Rows.Count == 0) return;

                double giaGoc = Convert.ToDouble(dtGoi.Rows[0]["Gia"]);
                int soNgay = Convert.ToInt32(dtGoi.Rows[0]["ThoiHan"]);

                // Lấy % Khuyến mãi nếu có chọn
                double phanTramGiam = 0;
                if (cboKhuyenMai.SelectedValue != null && !(cboKhuyenMai.SelectedValue is DataRowView) && cboKhuyenMai.SelectedIndex != -1)
                {
                    DataTable dtKM = db.ExecuteQuery($"SELECT PhanTramGiam FROM KhuyenMai WHERE MaKM = {cboKhuyenMai.SelectedValue}");
                    if (dtKM.Rows.Count > 0)
                        phanTramGiam = Convert.ToDouble(dtKM.Rows[0]["PhanTramGiam"]);
                }

                // Công thức tính toán
                double tongTien = giaGoc * (1 - (phanTramGiam / 100));
                DateTime ngayHetHan = dtpNgayDK.Value.AddDays(soNgay);

                // Hiển thị lên giao diện
                txtTongTien.Text = tongTien.ToString("N0");
                lblNgayHetHan.Text = ngayHetHan.ToString("dd/MM/yyyy");
            }
            catch { /* Bỏ qua các lỗi nhỏ khi dữ liệu chưa khớp hoàn toàn */ }
        }

        // 4. Chức năng lưu Phiếu đăng ký (Thanh toán)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào bắt buộc
            if (cboHoiVien.SelectedIndex == -1 || cboHoiVien.SelectedValue is DataRowView ||
                cboGoiTap.SelectedIndex == -1 || cboGoiTap.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn Hội viên và Gói tập!", "Thông báo");
                return;
            }

            try
            {
                string maHV = cboHoiVien.SelectedValue.ToString();
                string maGoi = cboGoiTap.SelectedValue.ToString();

                // Xử lý giá trị NULL cho HLV và KM để tránh lỗi Foreign Key
                string maHLV = (cboHLV.SelectedIndex == -1 || cboHLV.SelectedValue is DataRowView)
                                ? "NULL" : cboHLV.SelectedValue.ToString();

                string maKM = (cboKhuyenMai.SelectedIndex == -1 || cboKhuyenMai.SelectedValue is DataRowView)
                                ? "NULL" : cboKhuyenMai.SelectedValue.ToString();

                // Chuẩn bị ngày tháng
                DateTime ngayDK = dtpNgayDK.Value;
                // Lấy lại thời hạn từ CSDL cho chắc chắn
                DataTable dtGoi = db.ExecuteQuery($"SELECT ThoiHan FROM GoiTap WHERE MaGoi = {maGoi}");
                int soNgay = Convert.ToInt32(dtGoi.Rows[0]["ThoiHan"]);
                DateTime ngayHH = ngayDK.AddDays(soNgay);

                // Xử lý tiền tệ
                string tongTienStr = txtTongTien.Text.Replace(".", "").Replace(",", "");

                // Câu lệnh INSERT vào SQL (Đảm bảo tên cột khớp với CSDL đã sửa)
                string query = $"INSERT INTO DangKy (MaHV, MaGoi, MaHLV, MaKM, NgayDangKy, NgayHetHan, TongTien, GhiChu) " +
                               $"VALUES ({maHV}, {maGoi}, {maHLV}, {maKM}, " +
                               $"'{ngayDK:yyyy-MM-dd}', '{ngayHH:yyyy-MM-dd}', {tongTienStr}, N'{txtGhiChu.Text.Trim()}')";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thanh toán");
                    LoadData(); // Cập nhật lại bảng lịch sử
                    ClearInputs();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu phiếu: " + ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            cboHoiVien.SelectedIndex = -1;
            cboGoiTap.SelectedIndex = -1;
            cboHLV.SelectedIndex = -1;
            cboKhuyenMai.SelectedIndex = -1;
            txtTongTien.Clear();
            lblNgayHetHan.Text = "__/__/____";
            txtGhiChu.Clear();
            dtpNgayDK.Value = DateTime.Now;
        }
    }
}