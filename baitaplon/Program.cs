using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Biến cờ: false = Màn hình Đăng ký, true = Màn hình Đăng nhập
            bool isLoginScreen = false;

            while (true)
            {
                if (!isLoginScreen)
                {
                    // --- MÀN HÌNH 1: ĐĂNG KÝ ---
                    Dangki frmDangki = new Dangki();
                    DialogResult ketqua = frmDangki.ShowDialog();

                    if (ketqua == DialogResult.OK)
                    {
                        // Đăng ký thành công (hoặc bấm nút sang đăng nhập) -> Chuyển sang Login
                        isLoginScreen = true;
                    }
                    else
                    {
                        // Người dùng tắt form -> Thoát app
                        break;
                    }
                }
                else
                {
                    // --- MÀN HÌNH 2: ĐĂNG NHẬP ---
                    Dangnhap frmDangnhap = new Dangnhap();
                    DialogResult ketqua = frmDangnhap.ShowDialog();

                    if (ketqua == DialogResult.OK)
                    {
                        // --- MÀN HÌNH 3: TRANG CHỦ ---
                        // Dùng ShowDialog để bắt sự kiện Đăng xuất
                        Trangchu frmHome = new Trangchu();
                        DialogResult ketquaHome = frmHome.ShowDialog();

                        if (ketquaHome == DialogResult.Retry)
                        {
                            // Nếu Trang chủ trả về Retry (Đăng xuất) -> Vòng lặp chạy lại
                            // isLoginScreen vẫn là true -> Mở lại form Đăng nhập
                            continue;
                        }
                        else
                        {
                            // Thoát hẳn
                            break;
                        }
                    }
                    else if (ketqua == DialogResult.Retry)
                    {
                        // Bấm nút "Quay lại Đăng ký" -> Đổi cờ để mở form Đăng ký
                        isLoginScreen = false;
                    }
                    else
                    {
                        // Tắt form -> Thoát app
                        break;
                    }
                }
            }
        }
    }
}
