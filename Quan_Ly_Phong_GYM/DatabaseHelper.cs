using System;
using System.Data;
using System.Data.SqlClient;

namespace Quan_Ly_Phong_GYM
{
    public class DatabaseHelper
    {
        // CHUỖI KẾT NỐI: Đã cập nhật theo máy KHANHNG208 và tài khoản sa của em
        // Lưu ý: Thay '123' bằng mật khẩu thật của tài khoản sa máy em
        private string connectionString = @"Data Source=KHANHNG208;Initial Catalog=QL_GYM;User ID=sa;Password=khanh208;TrustServerCertificate=True";

        // 1. Hàm thực thi truy vấn SELECT (Trả về bảng dữ liệu)
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi truy vấn: " + ex.Message);
            }
            return data;
        }

        // 2. Hàm thực thi INSERT, UPDATE, DELETE (Trả về số dòng thành công)
        public int ExecuteNonQuery(string query)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thực thi SQL: " + ex.Message);
            }
            return result;
        }
    }
}