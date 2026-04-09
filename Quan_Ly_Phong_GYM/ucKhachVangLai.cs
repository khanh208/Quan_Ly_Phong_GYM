using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucKhachVangLai : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucKhachVangLai()
        {
            InitializeComponent();
        }

        private void ucKhachVangLai_Load(object sender, EventArgs e)
        {
            // Thiết lập giá mặc định khi vừa mở trang
            txtDonGia.Text = "50000";
            numSoLuong.Value = 1;
            LoadDataVeNgay();
            TinhTien();
            dgvVeNgay.Columns["MaVe"].HeaderText = "Mã vé";
            dgvVeNgay.Columns["NgayBan"].HeaderText = "Ngày bán";
            dgvVeNgay.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvVeNgay.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvVeNgay.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvVeNgay.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        // 1. Hàm nạp danh sách vé đã bán trong ngày hôm nay
        private void LoadDataVeNgay()
        {
            try
            {
                // Chỉ hiện các vé bán trong ngày hôm nay để nhân viên dễ quản lý
                string query = "SELECT MaVe, NgayBan, SoLuong, DonGia, (SoLuong * DonGia) as TongTien, GhiChu " +
                               "FROM VeNgay WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE) " +
                               "ORDER BY MaVe DESC";
                dgvVeNgay.DataSource = db.ExecuteQuery(query);

                if (dgvVeNgay.Columns["DonGia"] != null) dgvVeNgay.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                if (dgvVeNgay.Columns["TongTien"] != null) dgvVeNgay.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // 2. Logic tự động tính tiền
        private void TinhTien()
        {
            // 1. Lấy số lượng từ NumericUpDown
            decimal soLuong = numSoLuong.Value;

            // 2. Làm sạch chuỗi giá (bỏ dấu chấm/phẩy để tính toán)
            string cleanPrice = txtDonGia.Text.Replace(".", "").Replace(",", "");

            // 3. Khai báo biến đơn giá (CHỈ KHAI BÁO 1 LẦN)
            decimal donGia = 0;

            // 4. Kiểm tra xem người dùng nhập số hay nhập chữ "aaaa"
            if (!decimal.TryParse(cleanPrice, out donGia))
            {
                // Nếu nhập sai (ví dụ nhập chữ), hiện thông báo và dừng tính
                lblThanhTien.Text = "Giá không hợp lệ!";
                lblThanhTien.ForeColor = Color.Red;
                return;
            }

            // 5. Nếu là số hợp lệ, thực hiện tính tổng
            decimal tong = soLuong * donGia;

            // Hiển thị kết quả định dạng tiền tệ (N0)
            lblThanhTien.Text = tong.ToString("N0") + " VNĐ";
            lblThanhTien.ForeColor = Color.Red;
        }

        // Sự kiện khi thay đổi số lượng hoặc đơn giá
        private void numSoLuong_ValueChanged(object sender, EventArgs e) => TinhTien();
        private void txtDonGia_TextChanged(object sender, EventArgs e) => TinhTien();

        // 3. Nút Thanh toán và Lưu vào SQL
        private bool KiemTraHopLe()
        {
            decimal donGia = 0;
            string cleanPrice = txtDonGia.Text.Replace(".", "").Replace(",", "");

            // Chặn nếu đơn giá không phải là số hoặc <= 0
            if (!decimal.TryParse(cleanPrice, out donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ (phải là số và lớn hơn 0)!", "Lỗi nhập liệu");
                txtDonGia.Focus();
                return false;
            }

            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi");
                return false;
            }

            return true;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            // Lấy thông tin từ Session (Nhân viên đang trực)
            int maNV = Session.MaNV;
            string donGia = txtDonGia.Text.Replace(".", "").Replace(",", "");
            decimal tongTien = numSoLuong.Value * Convert.ToDecimal(donGia);

            // Lưu vào SQL (Thêm cột MaNV để biết ai bán vé này)
            string query = $"INSERT INTO VeNgay (SoLuong, DonGia, NgayBan, GhiChu, MaNV) " +
                           $"VALUES ({numSoLuong.Value}, {donGia}, GETDATE(), N'{txtGhiChu.Text.Trim()}', {maNV})";

            if (db.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show($"Đã thu {tongTien:N0} VNĐ. Đang mở hóa đơn...", "Thành công");
                LoadDataVeNgay();

                // CHỈ IN SAU KHI LƯU THÀNH CÔNG
                ShowPrintPreview();

                // Xóa trắng thông tin để chuẩn bị bán vé tiếp theo
                txtGhiChu.Clear();
                numSoLuong.Value = 1;
            }
        }

        // 4. Chức năng In vé (Xem trước khi in)
        private void ShowPrintPreview()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintTicketContent);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }

        private void btnInVe_Click(object sender, EventArgs e)
        {
            if (dgvVeNgay.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trong danh sách bên dưới để in lại!");
                return;
            }

            // Nếu em muốn gắt hơn, có thể thêm kiểm tra quyền Admin mới được in lại
            if (Session.ChucVu != "Admin")
            {
                MessageBox.Show("Chỉ Quản lý mới có quyền in lại hóa đơn!");
                return;
            }

            ShowPrintPreview();
        }

        // Vẽ nội dung tờ vé tập
        private void PrintTicketContent(object sender, PrintPageEventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào đang được chọn không
            var row = dgvVeNgay.CurrentRow;
            if (row == null) return;

            Graphics g = e.Graphics;

            // 2. KHAI BÁO CÁC LOẠI FONT (Đây là phần em đang bị thiếu)
            Font fontTitle = new Font("Arial", 18, FontStyle.Bold);
            Font fontInfo = new Font("Arial", 12, FontStyle.Regular);
            Font fontBold = new Font("Arial", 12, FontStyle.Bold);
            Font fontFooter = new Font("Arial", 10, FontStyle.Italic);

            // 3. THIẾT LẬP VỊ TRÍ VÀ VẼ
            int y = 50;
            g.DrawString("PHÒNG TẬP GYM", fontTitle, Brushes.Black, 80, y); y += 40;
            g.DrawString("VÉ TẬP VÃNG LAI (DAILY PASS)", fontBold, Brushes.Black, 60, y); y += 50;

            // Lấy dữ liệu an toàn từ DataGridView
            string maVe = row.Cells["MaVe"].Value?.ToString() ?? "0";
            string ngayBan = Convert.ToDateTime(row.Cells["NgayBan"].Value).ToString("dd/MM/yyyy HH:mm");
            string soLuong = row.Cells["SoLuong"].Value?.ToString() ?? "0";

            // Định dạng tiền tệ có dấu phân cách nghìn
            decimal donGiaRaw = Convert.ToDecimal(row.Cells["DonGia"].Value);
            decimal tongTienRaw = Convert.ToDecimal(row.Cells["TongTien"].Value);
            string donGia = donGiaRaw.ToString("N0");
            string tongTien = tongTienRaw.ToString("N0");

            // Vẽ thông tin chi tiết
            g.DrawString($"Mã hóa đơn: {maVe}", fontInfo, Brushes.Black, 50, y); y += 30;
            g.DrawString($"Ngày bán: {ngayBan}", fontInfo, Brushes.Black, 50, y); y += 30;
            g.DrawString($"Số lượng: {soLuong}", fontInfo, Brushes.Black, 50, y); y += 30;
            g.DrawString($"Đơn giá: {donGia} VNĐ", fontInfo, Brushes.Black, 50, y); y += 30;

            // Vẽ đường kẻ ngang
            g.DrawLine(Pens.Black, 50, y, 350, y); y += 10;

            // Vẽ tổng tiền nổi bật bằng màu đỏ
            g.DrawString($"TỔNG TIỀN: {tongTien} VNĐ", new Font("Arial", 14, FontStyle.Bold), Brushes.Red, 50, y); y += 60;

            // Vẽ lời chúc
            g.DrawString("Chúc bạn có buổi tập hiệu quả!", fontFooter, Brushes.Gray, 70, y);
        }
    }
}