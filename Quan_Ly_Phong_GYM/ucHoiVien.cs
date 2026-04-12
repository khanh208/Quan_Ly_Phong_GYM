using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucHoiVien : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucHoiVien()
        {
            InitializeComponent();
        }

        #region --- KHỞI TẠO & NẠP DỮ LIỆU ---

        private void ucHoiVien_Load(object sender, EventArgs e)
        {
            // 1. KHÓA UI: Chặn gõ quá 10 số và chặn chọn ngày sinh từ 10 năm đổ lại đây
            txtSDT.MaxLength = 10;
            dtpNgaySinh.MaxDate = DateTime.Now.AddYears(-10); // Khách tối thiểu phải 10 tuổi

            LoadData();
            SetupGridViewHeaders();
        }

        private void SetupGridViewHeaders()
        {
            if (dgvHoiVien.Columns.Count > 0)
            {
                dgvHoiVien.Columns["MaHV"].HeaderText = "Mã HV";
                dgvHoiVien.Columns["HoTen"].HeaderText = "Họ và Tên";
                dgvHoiVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvHoiVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                dgvHoiVien.Columns["SDT"].HeaderText = "Số điện thoại";// Giữ lại để xem trạng thái

                dgvHoiVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public void LoadData(string keyword = "")
        {
            string query = "SELECT * FROM HoiVien";
            if (!string.IsNullOrEmpty(keyword))
            {
                query += $" WHERE HoTen LIKE N'%{keyword}%' OR SDT LIKE '%{keyword}%'";
            }
            query += " ORDER BY MaHV DESC";
            dgvHoiVien.DataSource = db.ExecuteQuery(query);
        }

        #endregion

        #region --- TÌM KIẾM (SEARCH) ---

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        #endregion

        #region --- NGHIỆP VỤ THÊM - SỬA - XÓA ---

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string sdt = txtSDT.Text.Trim();
            if (IsSdtDuplicate(sdt))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $@"INSERT INTO HoiVien (HoTen, NgaySinh, GioiTinh, SDT) 
                            VALUES (N'{txtHoTen.Text.Trim()}', '{dtpNgaySinh.Value:yyyy-MM-dd}', N'{cboGioiTinh.Text}', '{sdt}')";

            if (db.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("Thêm hội viên thành công!");
                LoadData();
                ClearForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow == null || !ValidateInputs()) return;

            string maHV = txtMaHV.Text;
            if (IsSdtDuplicate(txtSDT.Text.Trim(), maHV))
            {
                MessageBox.Show("SĐT bị trùng với người khác!");
                return;
            }

            string sql = $@"UPDATE HoiVien SET 
                            HoTen = N'{txtHoTen.Text.Trim()}', 
                            NgaySinh = '{dtpNgaySinh.Value:yyyy-MM-dd}', 
                            GioiTinh = N'{cboGioiTinh.Text}', 
                            SDT = '{txtSDT.Text.Trim()}' 
                            WHERE MaHV = {maHV}";

            if (db.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn Hội viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dgvHoiVien.CurrentRow.Cells["MaHV"].Value.ToString();
            string ten = dgvHoiVien.CurrentRow.Cells["HoTen"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa hội viên: {ten}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM HoiVien WHERE MaHV = {id}";
                    if (db.ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Gọi lại hàm load dữ liệu của bạn
                    }
                }
                catch (Exception ex)
                {
                    // BẮT LỖI KHÓA NGOẠI (CHỐNG CRASH)
                    if (ex.Message.Contains("REFERENCE") || ex.Message.Contains("FOREIGN KEY") || ex.Message.Contains("conflict"))
                    {
                        MessageBox.Show("⛔ KHÔNG THỂ XÓA!\n\nHội viên này đã từng phát sinh giao dịch (mua gói tập, điểm danh...). Hệ thống đã khóa cứng lệnh xóa để bảo vệ lịch sử doanh thu.\n\n💡 Gợi ý: Bạn chỉ có thể Sửa thông tin của khách hàng này.",
                                        "Khóa bảo vệ dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region --- HÀM HỖ TRỢ (HELPER) ---

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // SĐT phải đúng 10 số và bắt đầu bằng số 0
            if (txtSDT.Text.Length != 10 || !txtSDT.Text.StartsWith("0"))
            {
                MessageBox.Show("SĐT phải gồm đúng 10 chữ số và bắt đầu bằng số 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Kiểm tra độ tuổi (Phòng hờ nếu MaxDate ở trên bị lỗi)
            if (DateTime.Now.Year - dtpNgaySinh.Value.Year < 10)
            {
                MessageBox.Show("Hội viên phải từ 10 tuổi trở lên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsSdtDuplicate(string sdt, string maHV = "")
        {
            string sql = (string.IsNullOrEmpty(maHV))
                ? $"SELECT COUNT(*) FROM HoiVien WHERE SDT = '{sdt}'"
                : $"SELECT COUNT(*) FROM HoiVien WHERE SDT = '{sdt}' AND MaHV <> {maHV}";

            return Convert.ToInt32(db.ExecuteQuery(sql).Rows[0][0]) > 0;
        }

        private void ClearForm()
        {
            txtMaHV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void dgvHoiVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvHoiVien.Rows[e.RowIndex];
                txtMaHV.Text = r.Cells["MaHV"].Value?.ToString();
                txtHoTen.Text = r.Cells["HoTen"].Value?.ToString();
                txtSDT.Text = r.Cells["SDT"].Value?.ToString();
                cboGioiTinh.Text = r.Cells["GioiTinh"].Value?.ToString();
                if (r.Cells["NgaySinh"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(r.Cells["NgaySinh"].Value);
            }
        }

        // Vẫn giữ CellFormatting để lễ tân nhìn bảng là biết ai hết hạn để nhắc đi gia hạn
        private void dgvHoiVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoiVien.Columns[e.ColumnIndex].Name == "NgayHetHan" && e.Value != null && e.Value != DBNull.Value)
            {
                DateTime han = Convert.ToDateTime(e.Value);
                if (han < DateTime.Now)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvHoiVien.Font, FontStyle.Bold);
                }
                else if ((han - DateTime.Now).TotalDays <= 3)
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                }
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        #endregion
    }
}