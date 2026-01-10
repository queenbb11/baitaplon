using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class user : Form
    {
        SqlConnection con = new SqlConnection(
            "Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");

        public user()
        {
            InitializeComponent();
            this.Load += user_Load;
        }

        // ================= FORM LOAD =================
        private void user_Load(object sender, EventArgs e)
        {
            load_Theloai();
            load_Tacgia();
            load_Sach();
        }

        // ================= LOAD COMBOBOX =================
        private void load_Theloai()
        {
            string sql = "SELECT MaTL, TenTL FROM dbo.Theloai";
            Thuvien.hienthicbo(cboLoaisach_tk, sql, "MaTL", "TenTL");
            cboLoaisach_tk.SelectedIndex = -1;
        }

        private void load_Tacgia()
        {
            string sql = "SELECT MaTG, TenTG FROM dbo.Tacgia";
            Thuvien.hienthicbo(cboTacgia_tk, sql, "MaTG", "TenTG");
            cboTacgia_tk.SelectedIndex = -1;
        }

        // ================= LOAD DỮ LIỆU BAN ĐẦU =================
        private void load_Sach()
        {
            string sql =
                "SELECT Sach.MaS, Sach.TenS, Theloai.TenTL, Tacgia.TenTG, " +
                "       Nhaxuatban.TenNXB, Sach.Namxuatban, Sach.Tinhtrang " +
                "FROM dbo.Sach " +
                "JOIN dbo.Theloai ON Sach.MaTL = Theloai.MaTL " +
                "JOIN dbo.Tacgia ON Sach.MaTG = Tacgia.MaTG " +
                "JOIN dbo.Nhaxuatban ON Sach.MaNXB = Nhaxuatban.MaNXB";

            Thuvien.hienthi_luoi(dgvSach, sql);
        }

        // ================= TÌM KIẾM =================
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string ms = txtMaS_tk.Text.Trim();
            string ts = txtTenS_tk.Text.Trim();
            string ml = cboLoaisach_tk.SelectedValue?.ToString();
            string mtg = cboTacgia_tk.SelectedValue?.ToString();
            string sql = "SELECT * FROM Sach " +
                         "WHERE MaS LIKE N'%" + ms + "%' " +
                         "and TenS LIKE N'%" + ts + "%'" +
                         "and MaTL LIKE N'%" + ml + "%'" +
                         "and MaTG LIKE N'%" + mtg + "%'";

            DataTable tb = Thuvien.Getdatatable(sql);
            // đổ dl vào lưới
            dgvSach.DataSource = tb;
            dgvSach.Refresh();
        }


        // ================= RESET =================
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaS_tk.Clear();
            txtTenS_tk.Clear();
            cboLoaisach_tk.SelectedIndex = -1;
            cboTacgia_tk.SelectedIndex = -1;

            load_Sach();
        }

        private void btndx_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo);

            if (traloi == DialogResult.Yes)
            {
                // Báo RETRY để Program biết và mở lại form Đăng nhập
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
        }
    }
}
