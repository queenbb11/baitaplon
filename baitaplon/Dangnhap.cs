using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class Dangnhap : Form
    {
        // Cập nhật chuỗi kết nối
        string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bai_tap_lon;Integrated Security=True";

        public Dangnhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // txtPass.UseSystemPasswordChar = true; 
        }

        // Nút Đăng Nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập Tài khoản và Mật khẩu");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // 1. Sửa câu lệnh SQL theo bảng Dangky_Dangnhap
                    string sql = "SELECT TenNV FROM Dangky_Dangnhap WHERE Taikhoan=@u AND Matkhau=@p";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@u", txtUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@p", txtPass.Text.Trim());

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                // Lấy tên nhân viên để hiển thị
                                string ten = rd["TenNV"].ToString();
                                MessageBox.Show("Đăng nhập thành công! Xin chào " + ten);

                                // Báo OK để Program mở Trang chủ
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Sai Tài khoản hoặc Mật khẩu!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        // Nút "Quay lại Đăng ký"
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Báo RETRY để Program quay lại form Đăng ký
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

    }
}