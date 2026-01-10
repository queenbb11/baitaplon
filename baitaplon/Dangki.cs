using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class Dangki : Form
    {
        private string conStr =
            @"Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True;TrustServerCertificate=True";

        public Dangki()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "" || txtTenUser.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    string checkSql =
                        "SELECT COUNT(*) FROM Dangky_Dangnhap WHERE Taikhoan=@u";

                    SqlCommand checkCmd = new SqlCommand(checkSql, con);
                    checkCmd.Parameters.AddWithValue("@u", txtUser.Text.Trim());

                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!");
                        return;
                    }

                    string insertSql = @"
                        INSERT INTO Dangky_Dangnhap(Taikhoan, Matkhau, TenUser)
                        VALUES (@u, @p, @t)";

                    SqlCommand cmd = new SqlCommand(insertSql, con);
                    cmd.Parameters.AddWithValue("@u", txtUser.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", txtPass.Text.Trim());
                    cmd.Parameters.AddWithValue("@t", txtTenUser.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đăng ký thành công!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
