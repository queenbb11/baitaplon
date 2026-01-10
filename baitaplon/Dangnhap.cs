using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class Dangnhap : Form
    {
        private string conStr =
            @"Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True;TrustServerCertificate=True";

        // Trả về cho DieuHuong
        public bool IsAdmin { get; private set; }
        public string TenUser { get; private set; }

        public Dangnhap()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!");
                return;
            }

            // ================= ADMIN CỐ ĐỊNH =================
            if (user == "admin" && pass == "admin")
            {
                IsAdmin = true;
                TenUser = "ADMIN";

                MessageBox.Show("Đăng nhập Admin thành công!");
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            // ================= USER TRONG DATABASE =================
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    string sql = @"
                        SELECT TenUser
                        FROM Dangky_Dangnhap
                        WHERE Taikhoan = @u AND Matkhau = @p";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@u", user);
                    cmd.Parameters.AddWithValue("@p", pass);

                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        IsAdmin = false;
                        TenUser = rd["TenUser"].ToString();

                        MessageBox.Show("Đăng nhập thành công!");
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
