using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucCheckIn : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucCheckIn()
        {
            InitializeComponent();

            // Đăng ký sự kiện gõ phím Enter cho TextBox (đảm bảo Enter ăn 100%)
            txtMaHV.KeyDown += new KeyEventHandler(txtMaHV_KeyDown);
        }

        private void ucCheckIn_Load(object sender, EventArgs e)
        {
            // 1. CHẠY HÀM DỌN DẸP LÚC QUA NGÀY MỚI (CHỐNG TREO HỆ THỐNG)
            DonDepCheckInCu();

            // 2. Tải danh sách người đang tập hôm nay
            LoadDanhSachDangTap();
        }

        // Hàm tự động check-out cho những người ngày hôm qua chưa check-out
        private void DonDepCheckInCu()
        {
            string query = @"
                UPDATE CheckIn 
                SET TrangThai = N'Hệ thống tự đóng', GioRa = GETDATE() 
                WHERE TrangThai = N'Đang tập' 
                AND CAST(GioVao AS DATE) < CAST(GETDATE() AS DATE)";

            db.ExecuteNonQuery(query);
        }

        private void LoadDanhSachDangTap()
        {
            // Chỉ hiển thị những người đang tập trong ngày hôm nay
            string query = @"
                SELECT c.MaCheckIn, c.MaHV, h.HoTen, c.GioVao 
                FROM CheckIn c 
                JOIN HoiVien h ON c.MaHV = h.MaHV 
                WHERE c.TrangThai = N'Đang tập' 
                AND CAST(c.GioVao AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY c.GioVao DESC";

            dgvDangTap.DataSource = db.ExecuteQuery(query);

            if (dgvDangTap.Columns.Count > 0)
            {
                if (dgvDangTap.Columns["MaCheckIn"] != null) dgvDangTap.Columns["MaCheckIn"].Visible = false; // Ẩn cột ID
                dgvDangTap.Columns["MaHV"].HeaderText = "Mã HV";
                dgvDangTap.Columns["HoTen"].HeaderText = "Hội Viên";
                dgvDangTap.Columns["GioVao"].HeaderText = "Giờ Vào";
                dgvDangTap.Columns["GioVao"].DefaultCellStyle.Format = "HH:mm:ss dd/MM/yyyy";
                dgvDangTap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            // Lấy chuỗi nhập vào (Có thể là Mã số hoặc Số điện thoại)
            string inputStr = txtMaHV.Text.Trim();
            if (string.IsNullOrEmpty(inputStr))
            {
                MessageBox.Show("Vui lòng nhập Mã Hội Viên hoặc Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1. TÌM HỘI VIÊN BẰNG MÃ HOẶC SỐ ĐIỆN THOẠI
            // Thay thế đoạn checkHVQuery cũ bằng đoạn này:
            string checkHVQuery = $@"
                    SELECT h.MaHV, h.HoTen, MAX(d.NgayHetHan) AS NgayHetHan 
                    FROM HoiVien h
                    LEFT JOIN DangKy d ON h.MaHV = d.MaHV
                    WHERE CAST(h.MaHV AS VARCHAR) = '{inputStr}' OR h.SDT = '{inputStr}'
                    GROUP BY h.MaHV, h.HoTen";
            DataTable dtHV = db.ExecuteQuery(checkHVQuery);

            if (dtHV.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Hội viên với Mã hoặc Số điện thoại này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHV.Clear();
                txtMaHV.Focus();
                return;
            }

            string maHV = dtHV.Rows[0]["MaHV"].ToString();
            string hoTen = dtHV.Rows[0]["HoTen"].ToString();

            // 2. KIỂM TRA HẠN DÙNG GÓI TẬP CƠ BẢN
            if (dtHV.Rows[0]["NgayHetHan"] != DBNull.Value)
            {
                DateTime hanDung = Convert.ToDateTime(dtHV.Rows[0]["NgayHetHan"]);
                if (hanDung.Date < DateTime.Now.Date)
                {
                    MessageBox.Show($"Hội viên {hoTen} ĐÃ HẾT HẠN GÓI TẬP!\nVui lòng yêu cầu gia hạn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHV.Clear();
                    txtMaHV.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Hội viên {hoTen} chưa mua gói tập nào!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHV.Clear();
                txtMaHV.Focus();
                return;
            }

            // 3. KIỂM TRA TRẠNG THÁI (ĐANG TRONG PHÒNG HAY ĐÃ VỀ)
            string checkInQuery = $"SELECT MaCheckIn FROM CheckIn WHERE MaHV = {maHV} AND TrangThai = N'Đang tập'";
            DataTable dtCheckIn = db.ExecuteQuery(checkInQuery);

            if (dtCheckIn.Rows.Count > 0)
            {
                // ============================================
                // LUỒNG 1: ĐANG TẬP -> THỰC HIỆN CHECK-OUT
                // ============================================
                string maCheckIn = dtCheckIn.Rows[0]["MaCheckIn"].ToString();
                string updateQuery = $"UPDATE CheckIn SET GioRa = GETDATE(), TrangThai = N'Đã về' WHERE MaCheckIn = {maCheckIn}";
                db.ExecuteNonQuery(updateQuery);
                MessageBox.Show($"Tạm biệt! Check-OUT thành công: {hoTen}", "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // ============================================
                // LUỒNG 2: CHƯA TẬP -> THỰC HIỆN CHECK-IN
                // ============================================

                // --- A. Kiểm tra và Trừ buổi PT (Nếu có) ---
                string checkPTQuery = $"SELECT TOP 1 MaDK_PT, SoBuoiConLai, HLV.HoTen AS TenHLV FROM DangKyPT JOIN HLV ON DangKyPT.MaHLV = HLV.MaHLV WHERE DangKyPT.MaHV = {maHV} AND DangKyPT.SoBuoiConLai > 0 ORDER BY NgayDangKy ASC";
                DataTable dtPT = db.ExecuteQuery(checkPTQuery);

                if (dtPT.Rows.Count > 0)
                {
                    int soBuoiCon = Convert.ToInt32(dtPT.Rows[0]["SoBuoiConLai"]);
                    string tenPT = dtPT.Rows[0]["TenHLV"].ToString();
                    string maDK_PT = dtPT.Rows[0]["MaDK_PT"].ToString();

                    DialogResult ptResult = MessageBox.Show(
                        $"Hội viên này đang có PT: {tenPT} (Còn lại: {soBuoiCon} buổi).\n\nHôm nay khách CÓ TẬP CÙNG HLV không? (Chọn Yes để trừ 1 buổi)",
                        "Điểm danh PT", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (ptResult == DialogResult.Cancel)
                    {
                        // Nếu lỡ bấm nhầm, cho phép hủy Check-in
                        txtMaHV.Clear();
                        txtMaHV.Focus();
                        return;
                    }
                    else if (ptResult == DialogResult.Yes)
                    {
                        // Trừ 1 buổi
                        string truBuoiQuery = $"UPDATE DangKyPT SET SoBuoiConLai = SoBuoiConLai - 1 WHERE MaDK_PT = {maDK_PT}";
                        db.ExecuteNonQuery(truBuoiQuery);
                        soBuoiCon = soBuoiCon - 1; // Cập nhật lại biến

                        MessageBox.Show($"Đã trừ 1 buổi PT. Còn lại: {soBuoiCon} buổi.", "Thông báo PT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xử lý nhắc nhở gia hạn
                        if (soBuoiCon > 0 && soBuoiCon <= 2)
                        {
                            MessageBox.Show($"LƯU Ý LỄ TÂN: Khách hàng này chỉ còn {soBuoiCon} buổi PT. Hãy nhắc nhở khách hàng gia hạn thêm nhé!", "Nhắc nhở Sale", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (soBuoiCon == 0)
                        {
                            db.ExecuteNonQuery($"UPDATE DangKyPT SET TrangThai = N'Đã hết buổi' WHERE MaDK_PT = {maDK_PT}");
                            MessageBox.Show($"Khách đã sử dụng HẾT BUỔI PT cuối cùng. Vui lòng yêu cầu khách gia hạn cho kỳ sau!", "Hết gói PT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // --- B. Lưu Check-in vào hệ thống ---
                string insertQuery = $"INSERT INTO CheckIn (MaHV, GioVao, TrangThai) VALUES ({maHV}, GETDATE(), N'Đang tập')";
                db.ExecuteNonQuery(insertQuery);
                MessageBox.Show($"Xin chào! Check-IN thành công: {hoTen}", "Check-in", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 4. Xóa ô nhập và tải lại bảng danh sách
            txtMaHV.Clear();
            txtMaHV.Focus();
            LoadDanhSachDangTap();
        }

        // Bắt sự kiện nhấn phím Enter trên TextBox
        private void txtMaHV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Chặn tiếng "ting" khó chịu của Windows
                btnCheckIn_Click(sender, e);
            }
        }
    }
}