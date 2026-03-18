using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucGoiTap : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucGoiTap()
        {
            InitializeComponent();
        }

        private void ucGoiTap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // 1. Hàm nạp dữ liệu từ SQL lên bảng
        public void LoadData()
        {
            string query = "SELECT * FROM GoiTap";
            dgvGoiTap.DataSource = db.ExecuteQuery(query);


            // Đổi tên tiêu đề cột cho đẹp
            if (dgvGoiTap.Columns["MaGoi"] != null) dgvGoiTap.Columns["MaGoi"].HeaderText = "Mã Gói";
            dgvGoiTap.Columns["TenGoi"].HeaderText = "Tên Gói Tập";
            dgvGoiTap.Columns["Gia"].HeaderText = "Giá Tiền (VNĐ)";
            dgvGoiTap.Columns["ThoiHan"].HeaderText = "Thời Hạn (Ngày)";

            // Bổ sung hiển thị Ghi chú
            if (dgvGoiTap.Columns["GhiChu"] != null) dgvGoiTap.Columns["GhiChu"].HeaderText = "Ghi Chú";

            // Định dạng hiển thị tiền tệ (100,000)
            dgvGoiTap.Columns["Gia"].DefaultCellStyle.Format = "N0";
        }

        // 2. Chức năng Thêm Gói Tập (Đã thêm Ghi chú và chặn giá ảo)
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Bổ sung GhiChu vào câu lệnh INSERT
                string query = $"INSERT INTO GoiTap (TenGoi, Gia, ThoiHan, GhiChu) " +
                               $"VALUES (N'{txtTenGoi.Text.Trim()}', {txtGia.Text}, {numThoiHan.Value}, N'{txtGhiChu.Text.Trim()}')";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Thêm gói tập mới thành công!", "Thông báo");
                    LoadData();
                    ClearInputs();
                }
            }
        }

        // 3. Chức năng Sửa Gói Tập (Đã thêm Ghi chú)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvGoiTap.CurrentRow == null) return;

            string maGoi = dgvGoiTap.CurrentRow.Cells["MaGoi"].Value.ToString();

            if (ValidateInput())
            {
                // Bổ sung GhiChu vào câu lệnh UPDATE
                string query = $"UPDATE GoiTap SET TenGoi = N'{txtTenGoi.Text.Trim()}', " +
                               $"Gia = {txtGia.Text}, ThoiHan = {numThoiHan.Value}, " +
                               $"GhiChu = N'{txtGhiChu.Text.Trim()}' " +
                               $"WHERE MaGoi = {maGoi}";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Cập nhật gói tập thành công!", "Thông báo");
                    LoadData();
                }
            }
        }

        // 4. Chức năng Xóa Gói Tập
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGoiTap.CurrentRow == null) return;

            string maGoi = dgvGoiTap.CurrentRow.Cells["MaGoi"].Value.ToString();
            string tenGoi = dgvGoiTap.CurrentRow.Cells["TenGoi"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa gói '{tenGoi}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                string query = $"DELETE FROM GoiTap WHERE MaGoi = {maGoi}";
                db.ExecuteNonQuery(query);
                LoadData();
                ClearInputs();
            }
        }

        // 5. Hiển thị ngược dữ liệu khi Click vào bảng
        private void dgvGoiTap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGoiTap.Rows[e.RowIndex];
                txtTenGoi.Text = row.Cells["TenGoi"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
                numThoiHan.Value = Convert.ToDecimal(row.Cells["ThoiHan"].Value);

                // Tránh lỗi nếu giá trị GhiChu bị null
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
            }
        }

        // 6. Chặn người dùng nhập chữ vào ô Giá tiền
        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Hàm kiểm tra dữ liệu đầu vào (Đã nâng cấp chặn giá thấp "vô lý")
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenGoi.Text))
            {
                MessageBox.Show("Tên gói tập không được để trống!");
                return false;
            }

            if (!long.TryParse(txtGia.Text, out long gia))
            {
                MessageBox.Show("Vui lòng nhập giá tiền hợp lệ!");
                return false;
            }

            if (gia < 1000)
            {
                MessageBox.Show("Giá tiền quá thấp! Giá tối thiểu phải từ 10,000 VNĐ.");
                return false;
            }

            return true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtTenGoi.Clear();
            txtGia.Clear();
            txtGhiChu.Clear(); // Thêm xóa ghi chú
            numThoiHan.Value = 30;
        }

        private void txtSearchGoiTap_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchGoiTap.Text.Trim();

            // Tìm kiếm gói tập theo Tên hoặc Ghi chú
            string query = $"SELECT * FROM GoiTap WHERE TenGoi LIKE N'%{keyword}%' OR GhiChu LIKE N'%{keyword}%'";

            // Đổ lại dữ liệu vào bảng
            dgvGoiTap.DataSource = db.ExecuteQuery(query);

            // Đừng quên định dạng lại cột tiền tệ sau khi nạp lại dữ liệu
            if (dgvGoiTap.Columns["Gia"] != null)
            {
                dgvGoiTap.Columns["Gia"].DefaultCellStyle.Format = "N0";
            }
        }
    }
}