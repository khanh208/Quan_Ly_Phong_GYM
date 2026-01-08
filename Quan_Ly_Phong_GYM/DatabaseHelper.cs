using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Phong_GYM
{
    internal class DatabaseHelper
    {
    }
}
public class DatabaseHelper
{
    // Thay đổi Chuỗi kết nối cho phù hợp với máy của em
    private string connectionString = @"Data Source=TEN_MAY_TINH;Initial Catalog=GymManagement;Integrated Security=True";

    // Hàm thực thi truy vấn SELECT (Lấy dữ liệu đổ vào DataGridView)
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