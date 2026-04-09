using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions; // Thư viện để kiểm tra định dạng chữ (Regex)
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucQuanLyNhanVien : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void ucQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            // 1. PHÂN QUYỀN: Nếu không phải ADMIN thì xóa sạch giao diện và đuổi ra
            string quyen = Session.ChucVu.Trim().ToUpper();
            if (quyen != "ADMIN")
            {
                this.Controls.Clear();
                Label lblError = new Label();
                lblError.Text = "BẠN KHÔNG CÓ QUYỀN TRUY CẬP KHU VỰC NÀY!";
                lblError.ForeColor = Color.Red;
                lblError.Font = new Font("Arial", 16, FontStyle.Bold);
                lblError.AutoSize = true;
                lblError.Location = new Point(100, 100);
                this.Controls.Add(lblError);
                return;
            }

            // 2. Cấu hình ban đầu cho ComboBox
            if (cboChucVu.Items.Count == 0)
                cboChucVu.Items.AddRange(new string[] { "Admin", "NhanVien" });

            if (cboTrangThai.Items.Count == 0)
                cboTrangThai.Items.AddRange(new string[] { "Đang làm việc", "Nghỉ việc" });

            LoadData();
        }

        // --- CÁC HÀM NGHIỆP VỤ ---

        public void LoadData()
        {
            try
            {
                string query = "SELECT MaNV, HoTen, SDT, TenDangNhap, MatKhau, ChucVu, TrangThai FROM NhanVien";
                dgvNhanVien.DataSource = db.ExecuteQuery(query);

                // Định dạng tiêu đề cột
                if (dgvNhanVien.Columns["MaNV"] != null) dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                dgvNhanVien.Columns["HoTen"].HeaderText = "Họ và Tên";
                dgvNhanVien.Columns["SDT"].HeaderText = "SĐT";
                dgvNhanVien.Columns["TenDangNhap"].HeaderText = "Tài khoản";
                dgvNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
                dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức vụ";
                dgvNhanVien.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách: " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Kiểm tra trùng tên đăng nhập
            string checkUser = $"SELECT * FROM NhanVien WHERE TenDangNhap = '{txtTenDangNhap.Text.Trim()}'";
            if (db.ExecuteQuery(checkUser).Rows.Count > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                return;
            }

            string query = $"INSERT INTO NhanVien (HoTen, SDT, TenDangNhap, MatKhau, ChucVu, TrangThai) " +
                           $"VALUES (N'{txtHoTen.Text.Trim()}', '{txtSDT.Text.Trim()}', " +
                           $"'{txtTenDangNhap.Text.Trim()}', '{txtMatKhau.Text}', N'{cboChucVu.Text}', N'{cboTrangThai.Text}')";

            if (db.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
                ClearInputs();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn nhân viên nào ở bảng chưa
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa trong bảng!");
                return;
            }

            // 2. Lấy Mã NV từ dòng đang chọn
            string maNV = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();

            // 3. Kiểm tra định dạng (SĐT 10 số, Tên không để trống...) trước khi lưu
            if (!ValidateInput()) return;

            // 4. Thực thi lệnh UPDATE
            // Các giá trị trong TextBox bây giờ bao gồm cả cái cũ và cái mới em vừa sửa
            string query = $@"UPDATE NhanVien SET 
                        HoTen = N'{txtHoTen.Text.Trim()}', 
                        SDT = '{txtSDT.Text.Trim()}', 
                        MatKhau = '{txtMatKhau.Text}', 
                        ChucVu = N'{cboChucVu.Text}', 
                        TrangThai = N'{cboTrangThai.Text}' 
                      WHERE MaNV = {maNV}";

            if (db.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                LoadData(); // Load lại bảng để thấy sự thay đổi
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;

            int idChon = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["MaNV"].Value);

            // CHẶN TỰ XÓA CHÍNH MÌNH
            if (idChon == Session.MaNV)
            {
                MessageBox.Show("Bạn không thể tự xóa chính mình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = $"DELETE FROM NhanVien WHERE MaNV = {idChon}";
                db.ExecuteNonQuery(query);
                LoadData();
                ClearInputs();
            }
        }

        // --- CÁC HÀM GIỚI HẠN NHẬP LIỆU (INPUT VALIDATION) ---

        private bool ValidateInput()
        {
            // 1. Chặn để trống
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                cboChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            // 2. Chặn SĐT không đủ 10 số
            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!");
                return false;
            }

            // 3. Chặn Tên đăng nhập có dấu hoặc khoảng cách (Dùng Regex)
            if (!Regex.IsMatch(txtTenDangNhap.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Tên đăng nhập chỉ được chứa chữ cái không dấu và số!");
                return false;
            }

            return true;
        }

        // Chỉ cho nhập số vào ô SĐT
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        // Chặn dấu cách và ký tự đặc biệt ở Tên đăng nhập
        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        // --- CÁC HÀM TIỆN ÍCH ---

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // 1. Hiện Mã NV lên TextBox (Cột đầu tiên thường là Index 0)
                txtMaNV.Text = row.Cells[0].Value?.ToString();

                // 2. Các ô còn lại (giữ nguyên code cũ của em)
                txtHoTen.Text = row.Cells[1].Value?.ToString();
                txtSDT.Text = row.Cells[2].Value?.ToString();
                txtTenDangNhap.Text = row.Cells[3].Value?.ToString();
                txtMatKhau.Text = row.Cells[4].Value?.ToString();
                cboChucVu.Text = row.Cells[5].Value?.ToString();
                cboTrangThai.Text = row.Cells[6].Value?.ToString();

                // Khóa luôn ô Tài khoản vì không nên cho sửa User
                txtTenDangNhap.ReadOnly = true;
            }
        }

        private void ClearInputs()
        {
            txtHoTen.Clear(); txtSDT.Clear(); txtTenDangNhap.Clear(); txtMatKhau.Clear();
            txtTenDangNhap.ReadOnly = false;
            cboChucVu.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ClearInputs(); }

        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            string k = txtSearchNV.Text.Trim();
            dgvNhanVien.DataSource = db.ExecuteQuery($"SELECT * FROM NhanVien WHERE HoTen LIKE N'%{k}%' OR TenDangNhap LIKE '%{k}%'");
        }
    }
}