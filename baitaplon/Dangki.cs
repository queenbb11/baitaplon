using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class Dangki : Form
    {
        // 1. Cập nhật chuỗi kết nối tới database 'bai_tap_lon'
        string conStr = @"Data Source=LAPTOP-CO8GN5HP\SQLEXPRESS;Initial Catalog=bai_tap_lon;Integrated Security=True;TrustServerCertificate=True";

        public Dangki()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Căn giữa
            // txtPass.UseSystemPasswordChar = true; // Bỏ comment dòng này nếu muốn ẩn pass
        }

        // Nút Đăng Ký
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu (Chỉ kiểm tra 3 trường có trong DB)
            if (string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tài khoản, Mật khẩu và Tên nhân viên!", "Thông báo");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // 2. Kiểm tra Tài khoản đã tồn tại chưa (Dùng cột Taikhoan)
                    string checkSql = "SELECT COUNT(*) FROM Dangky_Dangnhap WHERE Taikhoan = @u";
                    SqlCommand checkCmd = new SqlCommand(checkSql, con);
                    checkCmd.Parameters.AddWithValue("@u", txtUser.Text);

                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Tài khoản này đã tồn tại!", "Cảnh báo");
                        return;
                    }

                    // 3. Thêm mới (Dùng đúng tên bảng và cột trong hình)
                    string sql = "INSERT INTO Dangky_Dangnhap (Taikhoan, Matkhau, TenNV) VALUES (@u, @p, @ten)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@u", txtUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@p", txtPass.Text.Trim());
                        cmd.Parameters.AddWithValue("@ten", txtTenNV.Text.Trim());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đăng ký thành công! Chuyển sang đăng nhập.");

                        // Báo OK để Program chuyển sang Đăng nhập
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Nút "Đã có tài khoản? Đăng nhập ngay"
        private void btnToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}