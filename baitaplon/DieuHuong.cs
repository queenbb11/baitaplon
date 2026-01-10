
using System.Windows.Forms;

namespace baitaplon
{
    public static class DieuHuong
    {
        public static void ChayUngDung()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (Dangnhap login = new Dangnhap())
                {
                    DialogResult rs = login.ShowDialog();

                    // Thoát chương trình
                    if (rs == DialogResult.Cancel)
                        break;

                    // Mở form đăng ký
                    if (rs == DialogResult.Retry)
                    {
                        using (Dangki dk = new Dangki())
                        {
                            dk.ShowDialog();
                        }
                        continue;
                    }

                    // Đăng nhập thành công
                    if (rs == DialogResult.OK)
                    {
                        // ===== ADMIN =====
                        if (login.IsAdmin)
                        {
                            using (Trangchu admin = new Trangchu())
                            {
                                if (admin.ShowDialog() == DialogResult.Retry)
                                    continue; // Logout → quay lại đăng nhập
                                else
                                    break;
                            }
                        }
                        // ===== USER =====
                        else
                        {
                            using (user user = new user())
                            {
                                if (user.ShowDialog() == DialogResult.Retry)
                                    continue; // Logout
                                else
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
