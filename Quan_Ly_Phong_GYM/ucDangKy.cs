using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucDangKy : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();
        private bool isEditMode = false; // Biến đánh dấu: true = Đang chọn phiếu cũ, false = Mua mới

        public ucDangKy()
        {
            InitializeComponent();
        }

        private void ucDangKy_Load(object sender, EventArgs e)
        {
            LoadAllComboBox();
            LoadData();
            SwitchMode(false); // Mặc định là chế độ mua mới
        }

        // Chuyển đổi trạng thái nút bấm để giới hạn chức năng
        private void SwitchMode(bool editMode)
        {
            isEditMode = editMode;
            btnThanhToan.Enabled = !editMode;   // Tự điền tay -> Mua mới sáng
            btnGiaHan.Enabled = editMode;      // Chọn phiếu cũ -> Gia hạn sáng
            btnCapNhatHLV.Enabled = editMode;  // Chọn phiếu cũ -> Đổi HLV sáng

            // Khóa/Mở các ô nhập liệu
            cboHoiVien.Enabled = !editMode;
            cboGoiTap.Enabled = !editMode;
        }

        #region --- DỮ LIỆU & TÌM KIẾM ---

        public void LoadAllComboBox()
        {
            try
            {
                cboHoiVien.DataSource = db.ExecuteQuery("SELECT MaHV, HoTen FROM HoiVien");
                cboHoiVien.DisplayMember = "HoTen"; cboHoiVien.ValueMember = "MaHV";

                cboGoiTap.DataSource = db.ExecuteQuery("SELECT MaGoi, TenGoi FROM GoiTap");
                cboGoiTap.DisplayMember = "TenGoi"; cboGoiTap.ValueMember = "MaGoi";

                cboHLV.DataSource = db.ExecuteQuery("SELECT MaHLV, HoTen FROM HLV");
                cboHLV.DisplayMember = "HoTen"; cboHLV.ValueMember = "MaHLV";

                cboKhuyenMai.DataSource = db.ExecuteQuery("SELECT MaKM, TenKM FROM KhuyenMai");
                cboKhuyenMai.DisplayMember = "TenKM"; cboKhuyenMai.ValueMember = "MaKM";

                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nạp dữ liệu: " + ex.Message); }
        }

        public void LoadData(string keyword = "")
        {
            // Lấy thêm các cột Ma... để lát nữa mình gán SelectedValue cho chính xác
            string query = @"SELECT dk.MaDK, dk.MaHV, dk.MaGoi, dk.MaHLV, dk.MaKM,
                    hv.HoTen as [Hội Viên], gt.TenGoi as [Gói Tập], 
                    hlv.HoTen as [HLV], km.TenKM as [Khuyến Mãi], 
                    dk.NgayDangKy, dk.NgayHetHan, dk.TongTien
                    FROM DangKy dk
                    JOIN HoiVien hv ON dk.MaHV = hv.MaHV
                    JOIN GoiTap gt ON dk.MaGoi = gt.MaGoi
                    LEFT JOIN HLV hlv ON dk.MaHLV = hlv.MaHLV
                    LEFT JOIN KhuyenMai km ON dk.MaKM = km.MaKM";

            if (!string.IsNullOrEmpty(keyword))
            {
                query += $" WHERE hv.HoTen LIKE N'%{keyword}%' OR hv.SDT LIKE '%{keyword}%'";
            }
            query += " ORDER BY dk.MaDK DESC";

            dgvDangKy.DataSource = db.ExecuteQuery(query);

            // Ẩn các cột ID đi cho đẹp bảng
            if (dgvDangKy.Columns["MaHV"] != null) dgvDangKy.Columns["MaHV"].Visible = false;
            if (dgvDangKy.Columns["MaGoi"] != null) dgvDangKy.Columns["MaGoi"].Visible = false;
            if (dgvDangKy.Columns["MaHLV"] != null) dgvDangKy.Columns["MaHLV"].Visible = false;
            if (dgvDangKy.Columns["MaKM"] != null) dgvDangKy.Columns["MaKM"].Visible = false;

            if (dgvDangKy.Columns["TongTien"] != null)
                dgvDangKy.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadData(txtSearch.Text.Trim());

        #endregion

        #region --- TÍNH TOÁN & CLICK BẢNG ---

        private void TinhToanPhieu(object sender, EventArgs e)
        {
            if (cboGoiTap.SelectedValue == null || cboGoiTap.SelectedValue is DataRowView) return;
            try
            {
                DataTable dtGoi = db.ExecuteQuery($"SELECT Gia, ThoiHan FROM GoiTap WHERE MaGoi = {cboGoiTap.SelectedValue}");
                double giaGoc = Convert.ToDouble(dtGoi.Rows[0]["Gia"]);
                int soNgay = Convert.ToInt32(dtGoi.Rows[0]["ThoiHan"]);

                double giam = 0;
                if (cboKhuyenMai.SelectedValue != null && !(cboKhuyenMai.SelectedValue is DataRowView))
                {
                    DataTable dtKM = db.ExecuteQuery($"SELECT PhanTramGiam FROM KhuyenMai WHERE MaKM = {cboKhuyenMai.SelectedValue}");
                    if (dtKM.Rows.Count > 0) giam = Convert.ToDouble(dtKM.Rows[0]["PhanTramGiam"]);
                }

                txtTongTien.Text = (giaGoc * (1 - (giam / 100))).ToString("N0");
                lblNgayHetHan.Text = dtpNgayDK.Value.AddDays(soNgay).ToString("dd/MM/yyyy");
            }
            catch { }
        }

        private void dgvDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào dòng hợp lệ (không phải tiêu đề)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvDangKy.Rows[e.RowIndex];

                // Gán giá trị dựa trên ID (Chính xác 100%)
                cboHoiVien.SelectedValue = r.Cells["MaHV"].Value;
                cboGoiTap.SelectedValue = r.Cells["MaGoi"].Value;

                if (r.Cells["MaHLV"].Value != DBNull.Value)
                    cboHLV.SelectedValue = r.Cells["MaHLV"].Value;
                else
                    cboHLV.SelectedIndex = -1;

                if (r.Cells["MaKM"].Value != DBNull.Value)
                    cboKhuyenMai.SelectedValue = r.Cells["MaKM"].Value;
                else
                    cboKhuyenMai.SelectedIndex = -1;

                // Các thông tin khác
                txtGhiChu.Text = "Thao tác trên phiếu cũ số: " + r.Cells["MaDK"].Value.ToString();

                // Chuyển sang chế độ Gia hạn/Sửa HLV
                SwitchMode(true);
            }
        }

        #endregion

        #region --- CÁC NÚT CHỨC NĂNG ---

        // 1. MUA MỚI (Chỉ chạy khi isEditMode = false)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LuuPhieu(false);
        }

        // 2. GIA HẠN (Chỉ chạy khi chọn phiếu cũ)
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            LuuPhieu(true);
        }

        // Hàm dùng chung cho Mua mới và Gia hạn
        private void LuuPhieu(bool laGiaHan)
        {
            if (cboHoiVien.SelectedIndex == -1 || cboGoiTap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Hội viên và Gói tập!"); return;
            }

            try
            {
                string maHV = cboHoiVien.SelectedValue.ToString();
                string maGoi = cboGoiTap.SelectedValue.ToString();
                string maHLV = (cboHLV.SelectedIndex == -1) ? "NULL" : cboHLV.SelectedValue.ToString();
                string maKM = (cboKhuyenMai.SelectedIndex == -1) ? "NULL" : cboKhuyenMai.SelectedValue.ToString();

                // --- LOGIC TÍNH NGÀY BẮT ĐẦU VÀ KẾT THÚC ---
                DateTime ngayGiaoDich = DateTime.Now; // Ngày giờ lúc ấn nút
                DateTime ngayBatDauGoiMoi;

                // 1. Lấy ngày hết hạn hiện tại của hội viên từ Database (Bảng HoiVien)
                DataTable dtHV = db.ExecuteQuery($"SELECT NgayHetHan FROM HoiVien WHERE MaHV = {maHV}");

                if (dtHV.Rows.Count > 0 && dtHV.Rows[0]["NgayHetHan"] != DBNull.Value)
                {
                    DateTime hanCu = Convert.ToDateTime(dtHV.Rows[0]["NgayHetHan"]);

                    // So sánh với thời điểm hiện tại
                    if (hanCu > ngayGiaoDich)
                    {
                        // CASE A: Vẫn còn hạn -> Ngày bắt đầu gói mới là ngày hết hạn cũ (Cộng dồn)
                        ngayBatDauGoiMoi = hanCu;
                    }
                    else
                    {
                        // CASE B: Đã hết hạn -> Ngày bắt đầu là ngay bây giờ
                        ngayBatDauGoiMoi = ngayGiaoDich;
                    }
                }
                else
                {
                    // Trường hợp hội viên mới chưa từng mua gói nào
                    ngayBatDauGoiMoi = ngayGiaoDich;
                }

                // 2. Lấy số ngày của gói tập được chọn
                DataTable dtGoi = db.ExecuteQuery($"SELECT ThoiHan FROM GoiTap WHERE MaGoi = {maGoi}");
                int soNgayGoi = Convert.ToInt32(dtGoi.Rows[0]["ThoiHan"]);

                // 3. Tính ngày hết hạn mới
                DateTime ngayHetHanMoi = ngayBatDauGoiMoi.AddDays(soNgayGoi);

                // --- THỰC THI SQL ---
                string tongTien = txtTongTien.Text.Replace(".", "").Replace(",", "");

                // Lưu vào lịch sử DangKy (NgayDangKy là lúc thu tiền, NgayHetHan là hạn mới)
                string query = $@"INSERT INTO DangKy (MaHV, MaGoi, MaHLV, MaKM, NgayDangKy, NgayHetHan, TongTien, GhiChu) 
                        VALUES ({maHV}, {maGoi}, {maHLV}, {maKM}, '{ngayGiaoDich:yyyy-MM-dd HH:mm:ss}', 
                        '{ngayHetHanMoi:yyyy-MM-dd}', {tongTien}, N'{(laGiaHan ? "Gia hạn" : "Mua mới")}')";

                // Cập nhật lại hạn dùng trong bảng Hội Viên
                string updateHV = $"UPDATE HoiVien SET NgayHetHan = '{ngayHetHanMoi:yyyy-MM-dd}' WHERE MaHV = {maHV}";

                if (db.ExecuteNonQuery(query) > 0 && db.ExecuteNonQuery(updateHV) > 0)
                {
                    MessageBox.Show(laGiaHan ? "Gia hạn thành công!" : "Mua gói thành công!");
                    LoadData();
                    ClearInputs();
                    SwitchMode(false);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // 3. CẬP NHẬT HLV (Chỉ đổi HLV trên phiếu đang chọn)
        private void btnCapNhatHLV_Click(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow == null) return;
            string maDK = dgvDangKy.CurrentRow.Cells["MaDK"].Value.ToString();
            string maHLV = (cboHLV.SelectedIndex == -1) ? "NULL" : cboHLV.SelectedValue.ToString();

            if (db.ExecuteNonQuery($"UPDATE DangKy SET MaHLV = {maHLV} WHERE MaDK = {maDK}") > 0)
            {
                MessageBox.Show("Đã cập nhật HLV cho phiếu này!");
                LoadData();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            SwitchMode(false);
        }

        private void ClearInputs()
        {
            cboHoiVien.SelectedIndex = -1; cboGoiTap.SelectedIndex = -1;
            cboHLV.SelectedIndex = -1; cboKhuyenMai.SelectedIndex = -1;
            txtTongTien.Clear(); lblNgayHetHan.Text = "__/__/____";
            txtGhiChu.Clear(); dtpNgayDK.Value = DateTime.Now;
        }
        #endregion
    }
}