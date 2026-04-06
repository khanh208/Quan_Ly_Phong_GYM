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
            LoadData();
            // Thiết lập ComboBox nếu chưa có Item
            if (cboChuyenMon.Items.Count == 0)
            {
                cboChuyenMon.Items.AddRange(new string[] { "Gym", "Yoga", "Boxing", "Cardio", "Pilates" });
            }
        }

        // 1. Hàm nạp dữ liệu - Đảm bảo dùng bảng HLV
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
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // 2. Chức năng Thêm HLV
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Dùng bảng HLV
                string query = $"INSERT INTO HLV (HoTen, SDT, ChuyenMon, TrangThai) " +
                               $"VALUES (N'{txtHoTen.Text.Trim()}', '{txtSDT.Text.Trim()}', " +
                               $"N'{cboChuyenMon.Text}', N'Đang làm việc')";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Thêm Huấn luyện viên vào SQL thành công!");
                    LoadData();
                    ClearInputs();
                }
            }
        }

        // 3. Chức năng Sửa HLV - Đã sửa tên bảng thành HLV
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHLV.CurrentRow == null) return;
            string maHLV = dgvHLV.CurrentRow.Cells["MaHLV"].Value.ToString();

            if (ValidateInput())
            {
                string query = $"UPDATE HLV SET HoTen = N'{txtHoTen.Text.Trim()}', " +
                               $"SDT = '{txtSDT.Text.Trim()}', ChuyenMon = N'{cboChuyenMon.Text}' " +
                               $"WHERE MaHLV = {maHLV}";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadData();
                }
            }
        }

        // 4. Chức năng Xóa HLV - Đã sửa tên bảng thành HLV
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHLV.CurrentRow == null) return;
            string maHLV = dgvHLV.CurrentRow.Cells["MaHLV"].Value.ToString();
            string tenHLV = dgvHLV.CurrentRow.Cells["HoTen"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa HLV {tenHLV}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string query = $"DELETE FROM HLV WHERE MaHLV = {maHLV}";
                if (db.ExecuteNonQuery(query) > 0)
                {
                    LoadData();
                    ClearInputs();
                }
            }
        }

        // 5. Tìm kiếm tức thời - Đã sửa tên bảng thành HLV
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

        // --- HÀM HỖ TRỢ ---
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên huấn luyện viên!");
                return false;
            }
            if (txtSDT.Text.Length < 10 || !txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
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