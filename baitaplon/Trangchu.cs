
using Quanlythuvien;
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
        private void Form1_Load(object sender, EventArgs e) { }

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

        private void btnqlnv_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý tác giả
            using (Quanly_Nhanvien frmNV = new Quanly_Nhanvien())
            {
                // ShowDialog có nghĩa là phải tắt form nhân viên thì mới quay lại được trang chủ
                frmNV.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý tác giả
            using (QuanlyTacgia frmNV = new QuanlyTacgia())
            {
                // ShowDialog có nghĩa là phải tắt form nhân viên thì mới quay lại được trang chủ
                frmNV.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý nhà xuất bản
            using (Nha_xuat_ban frmNV = new Nha_xuat_ban())
            {
                // ShowDialog có nghĩa là phải tắt form nhân viên thì mới quay lại được trang chủ
                frmNV.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý doc gia
            using (Quanly_Docgia frmNV = new Quanly_Docgia())
            {
                // ShowDialog có nghĩa là phải tắt form nhân viên thì mới quay lại được trang chủ
                frmNV.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }


        //form thể loại
        private void btnTheloai_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý thể loại
            using (Ql_theloai frmNV = new Ql_theloai())
            {
                // ShowDialog có nghĩa là phải tắt form nhân viên thì mới quay lại được trang chủ
                frmNV.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }

        //form ql sách
        private void btQlsach_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý sách
            using (Ql_Sach frmS = new Ql_Sach())
            {
                // ShowDialog có nghĩa là phải tắt form nhân viên thì mới quay lại được trang chủ
                frmS.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }
        //form ql kho sach
        private void btnQl_khosach_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý sách
            using (Ql_khosach frmS = new Ql_khosach())
            {
                // ShowDialog có nghĩa là phải tắt form thì mới quay lại được trang chủ
                frmS.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }

        private void btnQLTrangThaiSach_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý TTS
            using (QL_Trangthaisach frmS = new QL_Trangthaisach())
            {
                // ShowDialog có nghĩa là phải tắt form thì mới quay lại được trang chủ
                frmS.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }

        private void btnQLTraCuu_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 2. Khởi tạo và mở Form Quản lý TTS
            using (QL_Tracuu frmS = new QL_Tracuu())
            {
                // ShowDialog có nghĩa là phải tắt form thì mới quay lại được trang chủ
                frmS.ShowDialog();
            }

            // 3. Sau khi tắt form nhân viên thì hiện lại trang chủ
            this.Show();
        }
    }
}