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

            // Khóa/Mở các ô nhập liệu chính để không bị sửa nhầm khi gia hạn
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
            // Lấy dữ liệu từ bảng DangKy, kết nối với các bảng danh mục
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
            query += " ORDER BY dk.NgayDangKy DESC";

            dgvDangKy.DataSource = db.ExecuteQuery(query);

            if (dgvDangKy.Columns.Count > 0)
            {
                // Ẩn các cột ID đi cho đẹp bảng
                if (dgvDangKy.Columns["MaDK"] != null) dgvDangKy.Columns["MaDK"].Visible = false;
                if (dgvDangKy.Columns["MaHV"] != null) dgvDangKy.Columns["MaHV"].Visible = false;
                if (dgvDangKy.Columns["MaGoi"] != null) dgvDangKy.Columns["MaGoi"].Visible = false;
                if (dgvDangKy.Columns["MaHLV"] != null) dgvDangKy.Columns["MaHLV"].Visible = false;
                if (dgvDangKy.Columns["MaKM"] != null) dgvDangKy.Columns["MaKM"].Visible = false;

                // Định dạng hiển thị
                if (dgvDangKy.Columns["NgayDangKy"] != null)
                    dgvDangKy.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";
                if (dgvDangKy.Columns["NgayHetHan"] != null)
                    dgvDangKy.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";
                if (dgvDangKy.Columns["TongTien"] != null)
                    dgvDangKy.Columns["TongTien"].DefaultCellStyle.Format = "N0";

                dgvDangKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
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

                txtGhiChu.Text = "Thao tác trên phiếu cũ số: " + r.Cells["MaDK"].Value.ToString();

                // Chuyển sang chế độ Gia hạn/Sửa HLV
                SwitchMode(true);
            }
        }

        #endregion

        #region --- CÁC NÚT CHỨC NĂNG ---

        // 1. MUA MỚI
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LuuPhieu(false);
        }

        // 2. GIA HẠN
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            LuuPhieu(true);
        }

        // Hàm dùng chung cho Mua mới và Gia hạn
        private void LuuPhieu(bool laGiaHan)
        {
            if (cboHoiVien.SelectedIndex == -1 || cboGoiTap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Hội viên và Gói tập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maHV = cboHoiVien.SelectedValue.ToString();
                string maGoi = cboGoiTap.SelectedValue.ToString();
                string maHLV = (cboHLV.SelectedIndex == -1) ? "NULL" : cboHLV.SelectedValue.ToString();
                string maKM = (cboKhuyenMai.SelectedIndex == -1) ? "NULL" : cboKhuyenMai.SelectedValue.ToString();

                // --- LOGIC TÍNH NGÀY HẾT HẠN MỚI ---
                DateTime ngayGiaoDich = DateTime.Now;
                DateTime ngayBatDauGoiMoi;

                // TÌM NGÀY HẾT HẠN XA NHẤT CỦA HỘI VIÊN NÀY TRONG BẢNG ĐĂNG KÝ
                string queryHanCu = $"SELECT MAX(NgayHetHan) AS HanCu FROM DangKy WHERE MaHV = {maHV}";
                DataTable dtHanCu = db.ExecuteQuery(queryHanCu);

                if (dtHanCu.Rows.Count > 0 && dtHanCu.Rows[0]["HanCu"] != DBNull.Value)
                {
                    DateTime hanCu = Convert.ToDateTime(dtHanCu.Rows[0]["HanCu"]);

                    // Nếu gói cũ vẫn còn hạn -> Cộng dồn ngày
                    if (hanCu > ngayGiaoDich)
                    {
                        ngayBatDauGoiMoi = hanCu;
                    }
                    else
                    {
                        // Đã hết hạn -> Tính từ hôm nay
                        ngayBatDauGoiMoi = ngayGiaoDich;
                    }
                }
                else
                {
                    // Chưa từng mua gói nào
                    ngayBatDauGoiMoi = ngayGiaoDich;
                }

                // Lấy số ngày của gói tập đang chọn
                DataTable dtGoi = db.ExecuteQuery($"SELECT ThoiHan FROM GoiTap WHERE MaGoi = {maGoi}");
                int soNgayGoi = Convert.ToInt32(dtGoi.Rows[0]["ThoiHan"]);

                // Tính ngày hết hạn cuối cùng
                DateTime ngayHetHanMoi = ngayBatDauGoiMoi.AddDays(soNgayGoi);

                // --- THỰC THI LƯU XUỐNG CSDL ---
                string tongTien = txtTongTien.Text.Replace(".", "").Replace(",", "");
                if (string.IsNullOrEmpty(tongTien)) tongTien = "0";

                string query = $@"INSERT INTO DangKy (MaHV, MaGoi, MaHLV, MaKM, NgayDangKy, NgayHetHan, TongTien, GhiChu) 
                        VALUES ({maHV}, {maGoi}, {maHLV}, {maKM}, '{ngayGiaoDich:yyyy-MM-dd HH:mm:ss}', 
                        '{ngayHetHanMoi:yyyy-MM-dd}', {tongTien}, N'{(laGiaHan ? "Gia hạn" : "Mua mới")}')";

                // Chỉ cần Insert vào bảng DangKy, không cần Update HoiVien nữa
                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show(laGiaHan ? $"Gia hạn thành công!\nHạn mới đến ngày: {ngayHetHanMoi:dd/MM/yyyy}" : "Mua gói tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputs();
                    SwitchMode(false);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // 3. CẬP NHẬT HLV 
        private void btnCapNhatHLV_Click(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow == null) return;
            string maDK = dgvDangKy.CurrentRow.Cells["MaDK"].Value.ToString();
            string maHLV = (cboHLV.SelectedIndex == -1) ? "NULL" : cboHLV.SelectedValue.ToString();

            if (db.ExecuteNonQuery($"UPDATE DangKy SET MaHLV = {maHLV} WHERE MaDK = {maDK}") > 0)
            {
                MessageBox.Show("Đã cập nhật HLV cho phiếu này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cboHoiVien.SelectedIndex = -1;
            cboGoiTap.SelectedIndex = -1;
            cboHLV.SelectedIndex = -1;
            cboKhuyenMai.SelectedIndex = -1;
            txtTongTien.Clear();
            lblNgayHetHan.Text = "__/__/____";
            txtGhiChu.Clear();
            dtpNgayDK.Value = DateTime.Now;
        }
        #endregion
    }
}