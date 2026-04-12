using System;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class frmDoiMatKhau : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string passCu = txtMatKhauCu.Text.Trim();
            string passMoi = txtMatKhauMoi.Text.Trim();
            string xacNhan = txtXacNhan.Text.Trim();

            // 1. Kiểm tra không được để trống
            if (string.IsNullOrEmpty(passCu) || string.IsNullOrEmpty(passMoi) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra mật khẩu mới và xác nhận có khớp không
            if (passMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra mật khẩu cũ có đúng với DB không (Dựa vào Session.MaNV)
            string queryCheck = $"SELECT * FROM NhanVien WHERE MaNV = {Session.MaNV} AND MatKhau = '{passCu}'";
            DataTable dt = db.ExecuteQuery(queryCheck);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Cập nhật mật khẩu mới vào cơ sở dữ liệu
            string queryUpdate = $"UPDATE NhanVien SET MatKhau = '{passMoi}' WHERE MaNV = {Session.MaNV}";
            if (db.ExecuteNonQuery(queryUpdate) > 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công! Vui lòng ghi nhớ mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng Form sau khi đổi xong
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, không thể đổi mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form nếu đổi ý
        }
    }
}