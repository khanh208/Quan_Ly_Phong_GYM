using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucHuanLuyenVien : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucHuanLuyenVien()
        {
            InitializeComponent();
        }

        private void ucHuanLuyenVien_Load(object sender, EventArgs e)
        {
            // 1. KHÓA UI: Chặn gõ quá 10 số
            txtSDT.MaxLength = 10;

            // 2. Tự động gắn sự kiện chặn nhập chữ cho ô SĐT
            txtSDT.KeyPress += new KeyPressEventHandler(txtSDT_KeyPress);

            LoadData();

            // Thiết lập ComboBox nếu chưa có Item
            if (cboChuyenMon.Items.Count == 0)
            {
                cboChuyenMon.Items.AddRange(new string[] { "Gym", "Yoga", "Boxing", "Cardio", "Pilates" });
            }
        }

        // --- SỰ KIỆN CHẶN NHẬP CHỮ ---
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập phím điều khiển (như Backspace) và phím số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn phím không hợp lệ
            }
        }

        // 1. Hàm nạp dữ liệu
        public void LoadData()
        {
            try
            {
                string query = "SELECT MaHLV, HoTen, SDT, ChuyenMon, TrangThai FROM HLV";
                dgvHLV.DataSource = db.ExecuteQuery(query);

                // Đặt tên tiêu đề cột
                if (dgvHLV.Columns["MaHLV"] != null) dgvHLV.Columns["MaHLV"].HeaderText = "Mã HLV";
                if (dgvHLV.Columns["HoTen"] != null) dgvHLV.Columns["HoTen"].HeaderText = "Họ và Tên";
                if (dgvHLV.Columns["SDT"] != null) dgvHLV.Columns["SDT"].HeaderText = "Số điện thoại";
                if (dgvHLV.Columns["ChuyenMon"] != null) dgvHLV.Columns["ChuyenMon"].HeaderText = "Chuyên môn";
                if (dgvHLV.Columns["TrangThai"] != null) dgvHLV.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // 2. Chức năng Thêm HLV
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string query = $"INSERT INTO HLV (HoTen, SDT, ChuyenMon, TrangThai) " +
                               $"VALUES (N'{txtHoTen.Text.Trim()}', '{txtSDT.Text.Trim()}', " +
                               $"N'{cboChuyenMon.Text}', N'Đang làm việc')";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Thêm Huấn luyện viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputs();
                }
            }
        }

        // 3. Chức năng Sửa HLV
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHLV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn HLV cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHLV = dgvHLV.CurrentRow.Cells["MaHLV"].Value.ToString();

            if (ValidateInput())
            {
                string query = $"UPDATE HLV SET HoTen = N'{txtHoTen.Text.Trim()}', " +
                               $"SDT = '{txtSDT.Text.Trim()}', ChuyenMon = N'{cboChuyenMon.Text}' " +
                               $"WHERE MaHLV = {maHLV}";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        // 4. Chức năng Xóa HLV (Đã tích hợp bẫy lỗi Khóa Ngoại)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHLV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn HLV cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dgvHLV.CurrentRow.Cells["MaHLV"].Value.ToString();
            string ten = dgvHLV.CurrentRow.Cells["HoTen"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa HLV: {ten}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM HLV WHERE MaHLV = {id}";
                    if (db.ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý không cho xóa nếu dính Khóa Ngoại (Foreign Key Constraint)
                    if (ex.Message.Contains("REFERENCE") || ex.Message.Contains("FOREIGN KEY") || ex.Message.Contains("conflict"))
                    {
                        MessageBox.Show("⛔ KHÔNG THỂ XÓA!\n\nHuấn luyện viên này đang được xếp lịch dạy hoặc đã có lịch sử dạy học viên. Không thể xóa để tránh làm hỏng dữ liệu các gói PT!\n\n💡 Gợi ý: Hãy xóa/đổi HLV ở các phiếu đăng ký trước, hoặc chỉ cần sửa thông tin.",
                                        "Khóa bảo vệ dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 5. Tìm kiếm tức thời
        private void txtSearchHLV_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearchHLV.Text.Trim();
            string query = $"SELECT MaHLV, HoTen, SDT, ChuyenMon, TrangThai FROM HLV " +
                           $"WHERE HoTen LIKE N'%{key}%' OR ChuyenMon LIKE N'%{key}%'";
            dgvHLV.DataSource = db.ExecuteQuery(query);
        }

        // 6. Đổ dữ liệu ngược lại ô nhập khi Click vào bảng
        private void dgvHLV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHLV.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                cboChuyenMon.Text = row.Cells["ChuyenMon"].Value?.ToString();
            }
        }

        // --- HÀM KIỂM TRA ĐẦU VÀO (VALIDATION) ---
        private bool ValidateInput()
        {
            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên huấn luyện viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra Số điện thoại (Chính xác 10 số và phải bắt đầu bằng 0)
            if (txtSDT.Text.Length != 10 || !txtSDT.Text.StartsWith("0") || !txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("SĐT phải gồm đúng 10 chữ số và bắt đầu bằng số 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // Kiểm tra chuyên môn
            if (string.IsNullOrWhiteSpace(cboChuyenMon.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập chuyên môn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChuyenMon.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            cboChuyenMon.SelectedIndex = -1;
            txtSearchHLV.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }
    }
}