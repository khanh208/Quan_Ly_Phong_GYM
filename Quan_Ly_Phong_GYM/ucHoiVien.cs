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
    public partial class ucHoiVien : UserControl
    {
        // Khởi tạo đối tượng kết nối CSDL
        DatabaseHelper db = new DatabaseHelper();

        public ucHoiVien()
        {
            InitializeComponent();
        }

        // Sự kiện chạy khi UserControl vừa được nạp lên
        private void ucHoiVien_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm này để đổ dữ liệu từ SQL vào bảng ngay lập tức
        }

        // Hàm nạp dữ liệu từ SQL Server
        public void LoadData()
        {
            // Truy vấn lấy toàn bộ danh sách hội viên
            string query = "SELECT * FROM HoiVien";

            // Đổ dữ liệu vào DataGridView (đảm bảo dgvHoiVien là tên bảng của bạn)
            dgvHoiVien.DataSource = db.ExecuteQuery(query);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ giao diện
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string gioiTinh = cboGioiTinh.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;

            // 2. Kiểm tra bắt buộc điền hết thông tin
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả thông tin!", "Thông báo");
                return;
            }

            // 3. Kiểm tra SĐT (Phải là số và có đúng 10 chữ số)
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải bao gồm 10 chữ số và không chứa ký tự chữ!", "Lỗi định dạng");
                return;
            }

            // 4. Kiểm tra ngày sinh hợp lý (Ví dụ: Hội viên phải từ 5 đến 100 tuổi)
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh >= DateTime.Now || tuoi < 5 || tuoi > 100)
            {
                MessageBox.Show("Ngày sinh không hợp lý (Hội viên phải từ 5 tuổi trở lên)!", "Lỗi dữ liệu");
                return;
            }

            // 5. Nếu mọi thứ hợp lệ, tiến hành lưu vào Database
            // Sử dụng định dạng yyyy-MM-dd để SQL hiểu đúng, còn hiển thị vẫn là dd/MM/yyyy
            string sqlNgaySinh = ngaySinh.ToString("yyyy-MM-dd");

            string query = $"INSERT INTO HoiVien (HoTen, NgaySinh, GioiTinh, SDT) " +
                           $"VALUES (N'{hoTen}', '{sqlNgaySinh}', N'{gioiTinh}', '{sdt}')";

            if (db.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Thêm hội viên thành công!", "Thành công");
                LoadData(); // Nạp lại bảng
                ClearInputs(); // Xóa trắng các ô nhập
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy MaHV từ dòng đang chọn trong DataGridView
            string maHV = dgvHoiVien.CurrentRow.Cells["MaHV"].Value.ToString();

            string query = $"UPDATE HoiVien SET HoTen = N'{txtHoTen.Text}', " +
                           $"NgaySinh = '{dtpNgaySinh.Value.ToString("yyyy-MM-dd")}', " +
                           $"GioiTinh = N'{cboGioiTinh.Text}', SDT = '{txtSDT.Text}' " +
                           $"WHERE MaHV = {maHV}";

            if (db.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHV = dgvHoiVien.CurrentRow.Cells["MaHV"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hội viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = $"DELETE FROM HoiVien WHERE MaHV = {maHV}";
                db.ExecuteNonQuery(query);
                LoadData();
                ClearInputs();
            }
        }

        // Hàm xóa trắng các ô nhập liệu
        void ClearInputs()
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
        }

        // Sự kiện Click vào một ô/dòng trên DataGridView
        private void dgvHoiVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào một dòng hợp lệ (tránh nhấn vào tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại đang được nhấn
                DataGridViewRow row = dgvHoiVien.Rows[e.RowIndex];

                // Đổ dữ liệu từ các cột của dòng đó vào các Control tương ứng
                // Lưu ý: Tên cột trong ngoặc ["..."] phải khớp chính xác với tên cột trong CSDL
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();

                // Xử lý ngày sinh (Chuyển từ dữ liệu trong bảng sang kiểu DateTime)
                if (row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                }

                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();

                // Nếu em có dùng một Label hoặc TextBox ẩn để giữ MaHV (dùng khi Sửa/Xóa)
                // txtMaHV.Text = row.Cells["MaHV"].Value.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            cboGioiTinh.SelectedIndex = -1; // Bỏ chọn ComboBox
            dtpNgaySinh.Value = DateTime.Now; // Đưa ngày về hiện tại
        }

    }
}   