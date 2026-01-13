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
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace baitaplon
{
    public partial class QLThe : Form
    {
        public QLThe()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
       "Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");

        private void load_The()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT * FROM The";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            dgvQLThe.Columns["NgayCap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvQLThe.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvQLThe.DataSource = tb;
            dgvQLThe.Refresh();
        }

        private void load_MaDG()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT MaDG FROM DocGia";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            cbbMaDG.DataSource = tb;
            cbbMaDG.DisplayMember = "MaDG";
            cbbMaDG.ValueMember = "MaDG";
            cbbMaDG.SelectedIndex = -1;
        }

       private void QLThe_Load(object sender, EventArgs e)
        {
            load_The();
            load_MaDG();
            AddCheckBoxColumn();
        }  

        private bool kiemTraTrungMaThe(string mathe)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT COUNT(*) FROM The WHERE MaThe = @ma";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ma", mathe);

            int kq = (int)cmd.ExecuteScalar();
            con.Close();

            return kq > 0;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mathe = txtMaThe.Text.Trim();
            string madg = cbbMaDG.SelectedValue?.ToString();
            string trangthai = cbbTrangThai.Text;
            DateTime ngayCap = dtpNgayCap.Value.Date;
            DateTime ngayHetHan = dtpNgayHetHan.Value.Date;

            if (ngayHetHan < ngayCap)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn hoặc bằng ngày cấp!");
                return;
            }

            if (ngayCap > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày cấp không được lớn hơn ngày hiện tại!");
                return;
            }

            if (string.IsNullOrWhiteSpace(mathe) || madg == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (kiemTraTrungMaThe(mathe))
            {
                MessageBox.Show("Mã thẻ đã tồn tại!");
                return;
            }

            string sql =
                "INSERT INTO The VALUES (" +
                "N'" + mathe + "', " +
                "N'" + madg + "', " +
                "'" + dtpNgayCap.Value.ToString("yyyy-MM-dd") + "', " +
                "'" + dtpNgayHetHan.Value.ToString("yyyy-MM-dd") + "', " +
                "N'" + trangthai + "')";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Thêm thẻ thành công!");

            load_The();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mathe = txtMaThe.Text.Trim();
            DateTime ngayCap = dtpNgayCap.Value.Date;
            DateTime ngayHetHan = dtpNgayHetHan.Value.Date;

            if (ngayHetHan < ngayCap)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn hoặc bằng ngày cấp!");
                return;
            }

            if (ngayCap > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày cấp không được lớn hơn ngày hiện tại!");
                return;
            }

            if (!kiemTraTrungMaThe(mathe))
            {
                MessageBox.Show("Mã thẻ không tồn tại!");
                return;
            }

            string sql =
                "UPDATE The SET " +
                "MaDG = N'" + cbbMaDG.SelectedValue + "', " +
                "NgayCap = '" + dtpNgayCap.Value.ToString("yyyy-MM-dd") + "', " +
                "NgayHetHan = '" + dtpNgayHetHan.Value.ToString("yyyy-MM-dd") + "', " +
                "TrangThai = N'" + cbbTrangThai.Text + "' " +
                "WHERE MaThe = N'" + mathe + "'";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Cập nhật thành công!");

            load_The();
        }

        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "chkChon";
            chk.HeaderText = "Chọn";
            chk.Width = 60;
            dgvQLThe.Columns.Insert(0, chk);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<string> dsMaThe = new List<string>();

            foreach (DataGridViewRow row in dgvQLThe.Rows)
            {
                bool chon = row.Cells["chkChon"].Value != null &&
                            Convert.ToBoolean(row.Cells["chkChon"].Value);

                if (chon)
                    dsMaThe.Add(row.Cells["MaThe"].Value.ToString());
            }

            if (dsMaThe.Count == 0)
            {
                if (string.IsNullOrWhiteSpace(txtMaThe.Text))
                {
                    MessageBox.Show("Vui lòng chọn thẻ cần xóa!");
                    return;
                }
                dsMaThe.Add(txtMaThe.Text.Trim());
            }

            DialogResult kq = MessageBox.Show(
                $"Xóa {dsMaThe.Count} thẻ?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (kq == DialogResult.No) return;

            foreach (string ma in dsMaThe)
            {
                string sql = "DELETE FROM The WHERE MaThe = N'" + ma + "'";
                Thuvien.ins_upd_del(sql);
            }

            MessageBox.Show("Xóa thành công!");
            load_The();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();

            string sql =
                "SELECT * FROM The " +
                "WHERE MaThe LIKE '%" + key + "%' " +
                "OR MaDG LIKE '%" + key + "%'" +
                "OR TrangThai Like N'%" + key +"%'";

            DataTable tb = Thuvien.Getdatatable(sql);
            dgvQLThe.DataSource = tb;
            dgvQLThe.Refresh();
        }

        private void dgvQLThe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int i = e.RowIndex;

            txtMaThe.Text = dgvQLThe.Rows[i].Cells["MaThe"].Value.ToString();

            cbbMaDG.SelectedValue = dgvQLThe.Rows[i].Cells["MaDG"].Value.ToString();

            dtpNgayCap.Value = Convert.ToDateTime(dgvQLThe.Rows[i].Cells["NgayCap"].Value);

            dtpNgayHetHan.Value = Convert.ToDateTime(dgvQLThe.Rows[i].Cells["NgayHetHan"].Value);

            cbbTrangThai.Text = dgvQLThe.Rows[i].Cells["TrangThai"].Value.ToString();

            txtMaThe.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaThe.Clear();
            txtMaThe.Enabled = true;

            cbbMaDG.SelectedIndex = -1;
            cbbMaDG.Enabled = true;

            cbbTrangThai.SelectedIndex = -1;

            dtpNgayCap.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now;
        }

        private void btnNhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(ofd.FileName);
                Excel.Worksheet ws = wb.Sheets[1];
                Excel.Range rg = ws.UsedRange;

                for (int i = 2; i <= rg.Rows.Count; i++)
                {
                    string maThe = rg.Cells[i, 1].Value?.ToString();
                    string maDG = rg.Cells[i, 2].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(maThe) || string.IsNullOrWhiteSpace(maDG))
                        continue;

                    if (kiemTraTrungMaThe(maThe))
                        continue;

                    DateTime ngayCap = DateTime.Parse(rg.Cells[i, 3].Value.ToString());
                    DateTime ngayHH = DateTime.Parse(rg.Cells[i, 4].Value.ToString());
                    string trangThai = rg.Cells[i, 5].Value?.ToString() ?? "Còn hạn";

                    string sql =
                        "INSERT INTO The VALUES (" +
                        "N'" + maThe + "', N'" + maDG + "', " +
                        "'" + ngayCap.ToString("yyyy-MM-dd") + "', " +
                        "'" + ngayHH.ToString("yyyy-MM-dd") + "', " +
                        "N'" + trangThai + "')";

                    Thuvien.ins_upd_del(sql);
                }

                wb.Close(false);
                app.Quit();

                MessageBox.Show("Nhập file thành công!");
                load_The();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập file: " + ex.Message);
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvQLThe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.FileName = "DanhSachTheThuVien.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Add();
                Excel.Worksheet ws = wb.Sheets[1];

                // 1. Ghi tiêu đề cột
                for (int i = 1; i < dgvQLThe.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1] = dgvQLThe.Columns[i].HeaderText;
                }

                // 2. Ghi dữ liệu
                for (int i = 0; i < dgvQLThe.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvQLThe.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] =
                            dgvQLThe.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                ws.Columns.AutoFit();
                wb.SaveAs(sfd.FileName);

                wb.Close();
                app.Quit();

                MessageBox.Show("Xuất file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
            }
        }
    }
}
