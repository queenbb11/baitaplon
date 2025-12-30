using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bai_tap_lon;Integrated Security=True"
        );

        private void ThongKe_Load(object sender, EventArgs e)
        {
            cbbThongKe.Items.Clear();
            cbbThongKe.Items.Add("Thống kê sách theo thể loại");
            cbbThongKe.Items.Add("Thống kê sách theo tác giả");
            cbbThongKe.SelectedIndex = 0;

            dgvThongKe.DataSource = null;
            dgvThongKe.ReadOnly = true;
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string loaiThongKe = cbbThongKe.Text;
            string sql = "";

            if (loaiThongKe == "Thống kê sách theo thể loại")
            {
                sql =
                    "SELECT tl.TenTL AS [Thể loại], COUNT(s.MaS) AS [Số lượng sách] " +
                    "FROM TheLoai tl " +
                    "LEFT JOIN Sach s ON tl.MaTL = s.MaTL " +
                    "GROUP BY tl.TenTL";
            }
            else if (loaiThongKe == "Thống kê sách theo tác giả")
            {
                sql =
                    "SELECT tg.TenTG AS [Tác giả], COUNT(s.MaS) AS [Số lượng sách] " +
                    "FROM TacGia tg " +
                    "LEFT JOIN Sach s ON tg.MaTG = s.MaTG " +
                    "GROUP BY tg.TenTG";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại thống kê!");
                return;
            }

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê!");
                dgvThongKe.DataSource = null;
                return;
            }

            dgvThongKe.DataSource = tb;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
