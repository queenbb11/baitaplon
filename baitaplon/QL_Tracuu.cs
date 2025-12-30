using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class QL_Tracuu : Form
    {
        SqlConnection con = new SqlConnection(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bai_tap_lon;Integrated Security=True"
        );

        public QL_Tracuu()
        {
            InitializeComponent();
            QL_TraCuu_Load(this, EventArgs.Empty);
        }

        // ================= LOAD FORM =================
        private void QL_TraCuu_Load(object sender, EventArgs e)
        {
            // Nạp tiêu chí tra cứu
            cbbTieuChi.Items.Clear();
            cbbTieuChi.Items.Add("Tên sách");
            cbbTieuChi.Items.Add("Thể loại");
            cbbTieuChi.Items.Add("Tác giả");
            cbbTieuChi.Items.Add("Nhà xuất bản");
            cbbTieuChi.Items.Add("Trạng thái");

            cbbTieuChi.SelectedIndex = 0;

            // KHÔNG load dữ liệu khi mới mở form
            dgvQLTraCuu.DataSource = null;
            dgvQLTraCuu.Rows.Clear();
            dgvQLTraCuu.ReadOnly = true;
            dgvQLTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            string tieuChi = cbbTieuChi.Text;

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tra cứu!");
                txtTuKhoa.Focus();
                return;
            }

            string cotTimKiem = "";

            if (tieuChi == "Tên sách") cotTimKiem = "s.TenS";
            else if (tieuChi == "Thể loại") cotTimKiem = "tl.TenTL";
            else if (tieuChi == "Tác giả") cotTimKiem = "tg.TenTG";
            else if (tieuChi == "Nhà xuất bản") cotTimKiem = "nxb.TenNXB";
            else if (tieuChi == "Trạng thái") cotTimKiem = "s.Tinhtrang";

            if (string.IsNullOrEmpty(cotTimKiem))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tra cứu!");
                return;
            }

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql =
                "SELECT s.MaS AS [Mã sách], s.TenS AS [Tên sách], " +
                "tl.TenTL AS [Thể loại], tg.TenTG AS [Tác giả], " +
                "nxb.TenNXB AS [NXB], s.Tinhtrang AS [Trạng thái] " +
                "FROM Sach s " +
                "JOIN TheLoai tl ON s.MaTL = tl.MaTL " +
                "JOIN TacGia tg ON s.MaTG = tg.MaTG " +
                "JOIN NhaXuatBan nxb ON s.MaNXB = nxb.MaNXB " +
                "WHERE " + cotTimKiem + " LIKE N'%" + tuKhoa + "%'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!");
                dgvQLTraCuu.DataSource = null;
                return;
            }

            dgvQLTraCuu.DataSource = tb;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            cbbTieuChi.SelectedIndex = 0;
            dgvQLTraCuu.DataSource = null;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
