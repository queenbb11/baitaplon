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

        }

        
        private void panelSidebar_Paint(object sender, PaintEventArgs e) { }
        private void btnqlnv_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        private void btnLogout_Click_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo);

            if (traloi == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (traloi == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnqlnv_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            using (Quanly_Nhanvien frmNV = new Quanly_Nhanvien())
            {
                frmNV.ShowDialog();
            }

            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (QuanlyTacgia frmNV = new QuanlyTacgia())
            {
                frmNV.ShowDialog();
            }

            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Nha_xuat_ban frmNV = new Nha_xuat_ban())
            {
                frmNV.ShowDialog();
            }

            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Quanly_Docgia frmNV = new Quanly_Docgia())
            {
                frmNV.ShowDialog();
            }

            this.Show();
        }

        private void btnTheloai_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Ql_theloai frmNV = new Ql_theloai())
            {
                frmNV.ShowDialog();
            }

            this.Show();
        }

        private void btQlsach_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Ql_Sach frmS = new Ql_Sach())
            {
                frmS.ShowDialog();
            }

            this.Show();
        }
        private void btnQl_khosach_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Ql_khosach frmS = new Ql_khosach())
            {
                frmS.ShowDialog();
            }
            this.Show();
        }

        private void btnQLTrangThaiSach_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (QL_Trangthaisach frmS = new QL_Trangthaisach())
            {
                frmS.ShowDialog();
            }
            this.Show();
        }

        private void btnQLTraCuu_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (QL_Tracuu frmS = new QL_Tracuu())
            {
                frmS.ShowDialog();
            }

            
            this.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            using (ThongKe frmS = new ThongKe())
            {
                frmS.ShowDialog();
            }

            this.Show();
        }

    }
}