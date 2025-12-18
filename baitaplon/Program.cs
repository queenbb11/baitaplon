using System;
using System.Windows.Forms;
using baitaplon; // Nhớ dùng namespace chứa class DieuHuong

namespace Baitaplon
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DieuHuong.ChayUngDung();
        }
    }
}