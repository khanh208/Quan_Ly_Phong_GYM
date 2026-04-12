using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Phong_GYM
{
    public partial class ucDangKyPT : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public ucDangKyPT()
        {
            InitializeComponent();
            this.Load += new EventHandler(ucDangKyPT_Load);
        }

        private void ucDangKyPT_Load(object sender, EventArgs e)
        {
            // 1. Tải dữ liệu vào các ComboBox
            LoadComboboxData();

            // 2. Tải danh sách các gói PT đã bán xuống bảng
            LoadDanhSachPT();
        }

        private void LoadComboboxData()
        {
            try
            {
                // Load danh sách Hội Viên
                string queryHV = "SELECT MaHV, HoTen FROM HoiVien";
                cboHoiVien.DataSource = db.ExecuteQuery(queryHV);
                cboHoiVien.DisplayMember = "HoTen";
                cboHoiVien.ValueMember = "MaHV";

                // Load danh sách HLV
                string queryHLV = "SELECT MaHLV, HoTen FROM HLV";
                cboHLV.DataSource = db.ExecuteQuery(queryHLV);
                cboHLV.DisplayMember = "HoTen";
                cboHLV.ValueMember = "MaHLV";

                // Load các mốc số buổi (Nếu bạn chưa cài trong Properties -> Items)
                cboGoiBuoi.Items.Clear();
                cboGoiBuoi.Items.Add("12 Buổi");
                cboGoiBuoi.Items.Add("30 Buổi");
                cboGoiBuoi.Items.Add("50 Buổi");

                // Mặc định chọn dòng đầu tiên (12 Buổi)
                if (cboGoiBuoi.Items.Count > 0)
                    cboGoiBuoi.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu danh mục: " + ex.Message);
            }
        }

        // Sự kiện tự động tính tiền khi thay đổi gói buổi
        private void cboGoiBuoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoiBuoi.SelectedItem != null)
            {
                // Lấy con số (VD: lấy số 12 từ chuỗi "12 Buổi")
                int soBuoi = int.Parse(cboGoiBuoi.Text.Split(' ')[0]);

                // Tính tiền (100.000 VNĐ / buổi)
                decimal thanhTien = soBuoi * 100000;

                lblThanhTien.Text = thanhTien.ToString("N0") + " VNĐ";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cboHoiVien.SelectedValue == null || cboHLV.SelectedValue == null || string.IsNullOrEmpty(cboGoiBuoi.Text))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Hội Viên, HLV và Số buổi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHV = cboHoiVien.SelectedValue.ToString();
            string maHLV = cboHLV.SelectedValue.ToString();

            int soBuoiMuaThem = int.Parse(cboGoiBuoi.Text.Split(' ')[0]);
            decimal tienMuaThem = soBuoiMuaThem * 100000;

            // ========================================================
            // 1. KIỂM TRA XEM KHÁCH ĐÃ CÓ GÓI VỚI HLV NÀY CHƯA?
            // ========================================================
            string checkTonTai = $"SELECT MaDK_PT, SoBuoiConLai FROM DangKyPT WHERE MaHV = {maHV} AND MaHLV = {maHLV} AND TrangThai = N'Đang tập'";
            DataTable dtTonTai = db.ExecuteQuery(checkTonTai);

            if (dtTonTai.Rows.Count > 0)
            {
                // --- TRƯỜNG HỢP A: GIA HẠN (Cộng dồn) ---
                string maDK = dtTonTai.Rows[0]["MaDK_PT"].ToString();
                int soBuoiCu = Convert.ToInt32(dtTonTai.Rows[0]["SoBuoiConLai"]);

                DialogResult dr = MessageBox.Show(
                    $"Khách hàng này đang có gói với HLV này (Còn lại {soBuoiCu} buổi).\n\nBạn có muốn GIA HẠN (cộng dồn thêm {soBuoiMuaThem} buổi) với số tiền phải thu thêm là {tienMuaThem:N0} VNĐ không?",
                    "Xác nhận Gia hạn", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // Cập nhật cộng dồn số buổi và tiền
                    string updateQuery = $@"
                        UPDATE DangKyPT 
                        SET TongSoBuoi = TongSoBuoi + {soBuoiMuaThem},
                            SoBuoiConLai = SoBuoiConLai + {soBuoiMuaThem},
                            ThanhTien = ThanhTien + {tienMuaThem}
                        WHERE MaDK_PT = {maDK}";

                    db.ExecuteNonQuery(updateQuery);
                    MessageBox.Show("Gia hạn và cộng dồn buổi PT thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // --- TRƯỜNG HỢP B: MUA MỚI TỪ ĐẦU ---

                // 1. Kiểm tra HLV có đang kèm quá 10 người không (Giới hạn mềm)
                string checkQuaTaiQuery = $"SELECT COUNT(DISTINCT MaHV) FROM DangKyPT WHERE MaHLV = {maHLV} AND SoBuoiConLai > 0";
                int soKhachDangKem = Convert.ToInt32(db.ExecuteQuery(checkQuaTaiQuery).Rows[0][0]);

                if (soKhachDangKem >= 10)
                {
                    DialogResult drHLV = MessageBox.Show(
                        $"CẢNH BÁO: HLV này đang kèm {soKhachDangKem} khách hàng (Đã đạt/vượt giới hạn 10 người).\n\nBạn có chắc chắn muốn tiếp tục thêm khách này vào lịch của HLV không?",
                        "Cảnh báo Quá tải", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (drHLV == DialogResult.No)
                    {
                        return; // Dừng thao tác để lễ tân chọn HLV khác
                    }
                }

                // 2. Tiến hành thêm mới vào Database
                string insertQuery = $"INSERT INTO DangKyPT (MaHV, MaHLV, TongSoBuoi, SoBuoiConLai, ThanhTien) VALUES ({maHV}, {maHLV}, {soBuoiMuaThem}, {soBuoiMuaThem}, {tienMuaThem})";

                if (db.ExecuteNonQuery(insertQuery) > 0)
                {
                    MessageBox.Show($"Đăng ký mới Gói PT thành công!\nTổng tiền thu: {tienMuaThem:N0} VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Tải lại bảng danh sách để cập nhật dữ liệu mới nhất
            LoadDanhSachPT();
        }

        private void LoadDanhSachPT()
        {
            // Câu lệnh SQL JOIN 3 bảng để lấy tên thay vì mã ID
            string query = @"
                SELECT 
                    dk.MaDK_PT,
                    hv.HoTen AS TenHoiVien,
                    hlv.HoTen AS TenHLV,
                    dk.TongSoBuoi,
                    dk.SoBuoiConLai,
                    dk.ThanhTien,
                    dk.NgayDangKy,
                    dk.TrangThai
                FROM DangKyPT dk
                JOIN HoiVien hv ON dk.MaHV = hv.MaHV
                JOIN HLV hlv ON dk.MaHLV = hlv.MaHLV
                ORDER BY dk.NgayDangKy DESC";

            dgvDanhSachPT.DataSource = db.ExecuteQuery(query);

            if (dgvDanhSachPT.Columns.Count > 0)
            {
                // Ẩn cột ID
                if (dgvDanhSachPT.Columns["MaDK_PT"] != null)
                    dgvDanhSachPT.Columns["MaDK_PT"].Visible = false;

                // Đổi tên các cột sang Tiếng Việt
                dgvDanhSachPT.Columns["TenHoiVien"].HeaderText = "Hội Viên";
                dgvDanhSachPT.Columns["TenHLV"].HeaderText = "Huấn Luyện Viên";
                dgvDanhSachPT.Columns["TongSoBuoi"].HeaderText = "Tổng Số Buổi";
                dgvDanhSachPT.Columns["SoBuoiConLai"].HeaderText = "Còn Lại";
                dgvDanhSachPT.Columns["ThanhTien"].HeaderText = "Tổng Tiền (VNĐ)";
                dgvDanhSachPT.Columns["NgayDangKy"].HeaderText = "Ngày Đăng Ký";
                dgvDanhSachPT.Columns["TrangThai"].HeaderText = "Trạng Thái";

                // Format lại định dạng hiển thị
                dgvDanhSachPT.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; // Hiển thị kiểu 1,000,000
                dgvDanhSachPT.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Căn giữa cho các cột số lượng
                dgvDanhSachPT.Columns["TongSoBuoi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDanhSachPT.Columns["SoBuoiConLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDanhSachPT.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Tự động kéo dãn các cột lấp đầy DataGridView
                dgvDanhSachPT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}