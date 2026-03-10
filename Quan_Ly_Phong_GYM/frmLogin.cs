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
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo");
                return;
            }

            // Câu lệnh SQL kiểm tra sự tồn tại của tài khoản
            // Lưu ý: Tên bảng và cột phải khớp với file Huong_dan_du_an.txt
            string query = $"SELECT * FROM TaiKhoan WHERE Username = '{user}' AND Password = '{pass}'";

            DataTable result = db.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");

                // Mở Form chính (ví dụ Form1) và ẩn Form đăng nhập
                Form1 mainForm = new Form1();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi");
            }
        }
    }
}