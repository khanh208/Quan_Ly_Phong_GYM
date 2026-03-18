using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucHuanLuyenVien : UserControl
    {
        // Khai báo lớp dùng chung để kết nối SQL
        DatabaseHelper db = new DatabaseHelper();

        public ucHuanLuyenVien()
        {
            InitializeComponent();
        }

        private void ucHuanLuyenVien_Load(object sender, EventArgs e)
        {
            LoadData();
            // Thiết kế sẵn các lựa chọn chuyên môn nếu dùng ComboBox
            if (cboChuyenMon.Items.Count == 0)
            {
                cboChuyenMon.Items.AddRange(new string[] { "Gym", "Yoga", "Boxing", "Cardio", "Pilates" });
            }
        }

        // 1. Hàm nạp dữ liệu (Để public để Form1 có thể gọi)
        public void LoadData()
        {
            string query = "SELECT * FROM HuanLuyenVien";
            dgvHLV.DataSource = db.ExecuteQuery(query);

            // Đổi tên tiêu đề cột cho chuyên nghiệp
            if (dgvHLV.Columns["MaHLV"] != null) dgvHLV.Columns["MaHLV"].HeaderText = "Mã HLV";
            dgvHLV.Columns["HoTen"].HeaderText = "Họ và Tên";
            dgvHLV.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvHLV.Columns["ChuyenMon"].HeaderText = "Chuyên môn";
            dgvHLV.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        // 2. Chức năng Thêm HLV
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string query = $"INSERT INTO HuanLuyenVien (HoTen, SDT, ChuyenMon, TrangThai) " +
                               $"VALUES (N'{txtHoTen.Text.Trim()}', '{txtSDT.Text.Trim()}', " +
                               $"N'{cboChuyenMon.Text}', N'Đang làm việc')";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Thêm huấn luyện viên thành công!");
                    LoadData();
                    ClearInputs();
                }
            }
        }

        // 3. Chức năng Sửa HLV
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHLV.CurrentRow == null) return;
            string maHLV = dgvHLV.CurrentRow.Cells["MaHLV"].Value.ToString();

            if (ValidateInput())
            {
                string query = $"UPDATE HuanLuyenVien SET HoTen = N'{txtHoTen.Text.Trim()}', " +
                               $"SDT = '{txtSDT.Text.Trim()}', ChuyenMon = N'{cboChuyenMon.Text}' " +
                               $"WHERE MaHLV = {maHLV}";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Cập nhật thông tin HLV thành công!");
                    LoadData();
                }
            }
        }

        // 4. Chức năng Xóa HLV (Xác nhận trước khi xóa)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHLV.CurrentRow == null) return;
            string maHLV = dgvHLV.CurrentRow.Cells["MaHLV"].Value.ToString();
            string tenHLV = dgvHLV.CurrentRow.Cells["HoTen"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa HLV {tenHLV}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string query = $"DELETE FROM HuanLuyenVien WHERE MaHLV = {maHLV}";
                db.ExecuteNonQuery(query);
                LoadData();
                ClearInputs();
            }
        }

        // 5. Tìm kiếm tức thời theo Tên hoặc Chuyên môn
        private void txtSearchHLV_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearchHLV.Text.Trim();
            string query = $"SELECT * FROM HuanLuyenVien WHERE HoTen LIKE N'%{key}%' OR ChuyenMon LIKE N'%{key}%'";
            dgvHLV.DataSource = db.ExecuteQuery(query);
        }

        // 6. Đổ dữ liệu ngược lại ô nhập khi Click vào bảng
        private void dgvHLV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHLV.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                cboChuyenMon.Text = row.Cells["ChuyenMon"].Value.ToString();
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
            if (txtSDT.Text.Length != 10 || !txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!");
                return false;
            }
            return true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
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
        }
    }
}
