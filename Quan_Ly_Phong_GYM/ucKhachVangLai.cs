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
            decimal soLuong = numSoLuong.Value;
            decimal donGia = 0;
            // Loại bỏ dấu chấm/phẩy nếu có để chuyển thành số
            string cleanPrice = txtDonGia.Text.Replace(".", "").Replace(",", "");
            decimal.TryParse(cleanPrice, out donGia);

            decimal tong = soLuong * donGia;
            lblThanhTien.Text = tong.ToString("N0") + " VNĐ";
        }

        // Sự kiện khi thay đổi số lượng hoặc đơn giá
        private void numSoLuong_ValueChanged(object sender, EventArgs e) => TinhTien();
        private void txtDonGia_TextChanged(object sender, EventArgs e) => TinhTien();

        // 3. Nút Thanh toán và Lưu vào SQL
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (numSoLuong.Value <= 0 || string.IsNullOrEmpty(txtDonGia.Text)) return;

            string donGia = txtDonGia.Text.Replace(".", "").Replace(",", "");
            string query = $"INSERT INTO VeNgay (SoLuong, DonGia, NgayBan, GhiChu) " +
                           $"VALUES ({numSoLuong.Value}, {donGia}, GETDATE(), N'{txtGhiChu.Text.Trim()}')";

            if (db.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Bán vé và thu tiền thành công!", "Thông báo");
                LoadDataVeNgay();
                // Tự động mở xem trước hóa đơn sau khi lưu thành công
                ShowPrintPreview();
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
            ShowPrintPreview();
        }

        // Vẽ nội dung tờ vé tập
        private void PrintTicketContent(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 18, FontStyle.Bold);
            Font fontInfo = new Font("Arial", 12);
            Font fontFooter = new Font("Arial", 10, FontStyle.Italic);

            int y = 50;
            g.DrawString("PHÒNG TẬP GYM", fontTitle, Brushes.Black, 80, y); y += 40;
            g.DrawString("VÉ TẬP VÃNG LAI (DAILY PASS)", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 60, y); y += 50;

            g.DrawString($"Ngày bán: {DateTime.Now:dd/MM/yyyy HH:mm}", fontInfo, Brushes.Black, 50, y); y += 30;
            g.DrawString($"Số lượng: {numSoLuong.Value}", fontInfo, Brushes.Black, 50, y); y += 30;
            g.DrawString($"Đơn giá: {txtDonGia.Text} VNĐ", fontInfo, Brushes.Black, 50, y); y += 30;
            g.DrawLine(Pens.Black, 50, y, 300, y); y += 10;

            g.DrawString($"TỔNG TIỀN: {lblThanhTien.Text}", new Font("Arial", 14, FontStyle.Bold), Brushes.Red, 50, y); y += 60;

            g.DrawString("Chúc bạn có buổi tập hiệu quả!", fontFooter, Brushes.Gray, 70, y);
        }
    }
}