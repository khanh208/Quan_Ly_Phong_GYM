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
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucKhuyenMai : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucKhuyenMai()
        {
            InitializeComponent();
        }

        private void ucKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            string query = "SELECT * FROM KhuyenMai";
            dgvKhuyenMai.DataSource = db.ExecuteQuery(query);

            if (dgvKhuyenMai.Columns["MaKM"] != null) dgvKhuyenMai.Columns["MaKM"].HeaderText = "Mã KM";
            dgvKhuyenMai.Columns["TenKM"].HeaderText = "Tên Chương Trình";
            dgvKhuyenMai.Columns["PhanTramGiam"].HeaderText = "% Giảm";
            dgvKhuyenMai.Columns["NgayBatDau"].HeaderText = "Bắt Đầu";
            dgvKhuyenMai.Columns["NgayKetThuc"].HeaderText = "Kết Thúc";

            dgvKhuyenMai.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvKhuyenMai.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string query = $"INSERT INTO KhuyenMai (TenKM, PhanTramGiam, NgayBatDau, NgayKetThuc, MoTa) " +
                               $"VALUES (N'{txtTenKM.Text.Trim()}', {numPhanTram.Value}, " +
                               $"'{dtpBatDau.Value:yyyy-MM-dd}', '{dtpKetThuc.Value:yyyy-MM-dd}', N'{txtMoTa.Text.Trim()}')";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!");
                    LoadData();
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKM.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chương trình!");
                return false;
            }

            // Kiểm tra logic: Ngày kết thúc không được nhỏ hơn ngày bắt đầu
            if (dtpKetThuc.Value.Date < dtpBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải sau hoặc bằng ngày bắt đầu!");
                return false;
            }

            return true;
        }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhuyenMai.Rows[e.RowIndex];
                txtTenKM.Text = row.Cells["TenKM"].Value.ToString();
                numPhanTram.Value = Convert.ToDecimal(row.Cells["PhanTramGiam"].Value);
                dtpBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                dtpKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
            }
        }

        // 1. Chức năng Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhuyenMai.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa!");
                return;
            }

            string maKM = dgvKhuyenMai.CurrentRow.Cells["MaKM"].Value.ToString();

            if (ValidateInput())
            {
                string query = $"UPDATE KhuyenMai SET TenKM = N'{txtTenKM.Text.Trim()}', " +
                               $"PhanTramGiam = {numPhanTram.Value}, " +
                               $"NgayBatDau = '{dtpBatDau.Value:yyyy-MM-dd}', " +
                               $"NgayKetThuc = '{dtpKetThuc.Value:yyyy-MM-dd}', " +
                               $"MoTa = N'{txtMoTa.Text.Trim()}' " +
                               $"WHERE MaKM = {maKM}";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Cập nhật khuyến mãi thành công!");
                    LoadData();
                }
            }
        }

        // 2. Chức năng Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhuyenMai.CurrentRow == null) return;

            string maKM = dgvKhuyenMai.CurrentRow.Cells["MaKM"].Value.ToString();
            string tenKM = dgvKhuyenMai.CurrentRow.Cells["TenKM"].Value.ToString();

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa mã '{tenKM}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                string query = $"DELETE FROM KhuyenMai WHERE MaKM = {maKM}";
                if (db.ExecuteNonQuery(query) > 0)
                {
                    LoadData();
                    ClearInputs();
                }
            }
        }

        // 3. Chức năng Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtTenKM.Clear();
            numPhanTram.Value = 0;
            dtpBatDau.Value = DateTime.Now;
            dtpKetThuc.Value = DateTime.Now;
            txtMoTa.Clear();
        }
    }
}