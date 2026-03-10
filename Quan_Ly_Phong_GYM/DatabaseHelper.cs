using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Phong_GYM
{
    // Chỉ để duy nhất một class DatabaseHelper bên trong namespace này
    public class DatabaseHelper
    {
        // Cập nhật chuỗi kết nối phù hợp với máy của bạn

        private string connectionString = @"Data Source=KHANHNG208;Initial Catalog=QL_GYM;User ID=sa;Password=khanh208;TrustServerCertificate=True";        // Hàm thực thi truy vấn SELECT
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }

        // Hàm thực thi INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();
            }
            return result;
        }
    }
}