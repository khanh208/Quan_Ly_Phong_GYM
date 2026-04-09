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
    public partial class frmLogin : Form
    {
        // Khởi tạo đối tượng DatabaseHelper
        DatabaseHelper db = new DatabaseHelper();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            // Truy vấn kiểm tra tài khoản và trạng thái làm việc
            string query = $"SELECT * FROM NhanVien WHERE TenDangNhap = '{user}' AND MatKhau = '{pass}' AND TrangThai = N'Đang làm việc'";
            DataTable dt = db.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                // 1. Lưu thông tin vào Session
                Session.MaNV = Convert.ToInt32(dt.Rows[0]["MaNV"]);
                Session.HoTen = dt.Rows[0]["HoTen"].ToString();
                Session.ChucVu = dt.Rows[0]["ChucVu"].ToString();

                // 2. Thông báo thành công và đóng Form Login để vào Form Chính
                MessageBox.Show($"Chào mừng {Session.HoTen} quay trở lại!", "Đăng nhập thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng, hoặc bạn đã nghỉ việc!", "Lỗi");
            }
        }
    }
}