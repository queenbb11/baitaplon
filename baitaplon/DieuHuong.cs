using System;
using System.Windows.Forms;
using Quanlythuvien; // Import namespace chứa form Quanly_Nhanvien

namespace baitaplon
{
    public static class DieuHuong
    {
        /// <summary>
        /// Hàm này đóng vai trò là "Bộ não" điều khiển luồng chạy của ứng dụng
        /// </summary>
        public static void ChayUngDung()
        {
            // Vòng lặp để giữ ứng dụng chạy cho đến khi người dùng muốn thoát hẳn
            bool isRunning = true;

            while (isRunning)
            {
                // Bước 1: Khởi tạo và hiển thị Form Đăng Nhập
                using (Dangnhap frmLogin = new Dangnhap())
                {
                    DialogResult loginResult = frmLogin.ShowDialog();

                    // TRƯỜNG HỢP A: Đăng nhập thành công -> Vào Trang chủ
                    if (loginResult == DialogResult.OK)
                    {
                        using (Trangchu frmHome = new Trangchu())
                        {
                            DialogResult homeResult = frmHome.ShowDialog();

                            // Nếu Trang chủ trả về Retry (Đăng xuất) -> Lặp lại vòng while (Mở lại Login)
                            if (homeResult == DialogResult.Retry)
                            {
                                continue;
                            }
                            // Nếu đóng trang chủ (Cancel hoặc OK) -> Thoát vòng lặp
                            else
                            {
                                isRunning = false;
                            }
                        }
                    }
                    // TRƯỜNG HỢP B: Người dùng bấm nút "Đăng ký" ở form Login -> Vào Đăng ký
                    else if (loginResult == DialogResult.Retry)
                    {
                        using (Dangki frmRegister = new Dangki())
                        {
                            DialogResult regResult = frmRegister.ShowDialog();

                            // Đăng ký thành công (OK) -> Lặp lại vòng while (Quay lại Login để đăng nhập)
                            if (regResult == DialogResult.OK)
                            {
                                continue;
                            }
                            // Nếu hủy đăng ký -> Thoát
                            else
                            {
                                isRunning = false;
                            }
                        }
                    }
                    // TRƯỜNG HỢP C: Người dùng tắt form đăng nhập -> Thoát ứng dụng
                    else
                    {
                        isRunning = false;
                    }
                }
            }
        }
    }
}