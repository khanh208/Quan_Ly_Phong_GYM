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
    public partial class ucThongKe : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();
        public ucThongKe()
        {
            InitializeComponent();
        }
        private void ThongKeDoanhThu()
        {
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd");

            try
            {
                // 1. Lấy tổng doanh thu
                string sqlTong = $"SELECT SUM(TongTien) FROM DangKy WHERE NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}'";
                DataTable dtTong = db.ExecuteQuery(sqlTong);

                if (dtTong.Rows.Count > 0 && dtTong.Rows[0][0] != DBNull.Value)
                {
                    double tong = Convert.ToDouble(dtTong.Rows[0][0]);
                    lblTongDoanhThu.Text = tong.ToString("N0") + " VNĐ";
                }
                else { lblTongDoanhThu.Text = "0 VNĐ"; }

                // 2. Lấy dữ liệu cho biểu đồ (Doanh thu theo từng ngày)
                string sqlBieuDo = $@"SELECT NgayDangKy, SUM(TongTien) as DoanhThu 
                             FROM DangKy 
                             WHERE NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}'
                             GROUP BY NgayDangKy 
                             ORDER BY NgayDangKy ASC";
                DataTable dtBieuDo = db.ExecuteQuery(sqlBieuDo);

                // Vẽ biểu đồ
                chartDoanhThu.Series.Clear();
                var series = chartDoanhThu.Series.Add("Doanh thu");
                series.XValueMember = "NgayDangKy";
                series.YValueMembers = "DoanhThu";
                chartDoanhThu.DataSource = dtBieuDo;
                chartDoanhThu.DataBind();

                // 3. Hiện chi tiết danh sách bên dưới
                dgvChiTiet.DataSource = db.ExecuteQuery($"SELECT * FROM DangKy WHERE NgayDangKy BETWEEN '{tuNgay}' AND '{denNgay}'");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thống kê: " + ex.Message); }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            ThongKeDoanhThu();
        }
    }
}
