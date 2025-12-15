using System;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
            // Code chạy khi trang chủ hiện lên
        }

        // Các hàm xử lý sự kiện khác của bạn giữ nguyên...
        private void panelSidebar_Paint(object sender, PaintEventArgs e) { }
        private void btnqlnv_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e){}

        private void btnLogout_Click_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo);

            if (traloi == DialogResult.Yes)
            {
                // Báo RETRY để Program biết và mở lại form Đăng nhập
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
        }
        

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (traloi == DialogResult.Yes)
            {
                // Thay vì dùng DialogResult.Cancel, hãy dùng lệnh này để ép chương trình tắt ngay lập tức
                Application.Exit();
            }
        }
    }
}