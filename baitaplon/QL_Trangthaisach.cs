

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace baitaplon
{
    public partial class QL_Trangthaisach : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");

        public QL_Trangthaisach()
        {
            InitializeComponent();
        }
        private void load_TrangThaiSach()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT * FROM TrangThaiSach";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);

            cmd.Dispose();
            con.Close();

            dgvQLTrangThaiSach.DataSource = tb;
            dgvQLTrangThaiSach.Refresh();
        }

        private void load_MaSach()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT MaS FROM Sach";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            cbbMaSach.DataSource = tb;
            cbbMaSach.DisplayMember = "MaS";
            cbbMaSach.ValueMember = "MaS";
            cbbMaSach.SelectedIndex = -1;
        }

        // ================= CHECK =================

        private bool kiemTraTrungMaS(string mas)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT COUNT(*) FROM TrangThaiSach WHERE MaS = @ma";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ma", mas);

            int kq = (int)cmd.ExecuteScalar();
            con.Close();

            return kq > 0;
        }

        // ================= BUTTON =================

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = cbbMaSach.SelectedValue?.ToString();
            string ten = txtTenTrangThai.Text.Trim();
            string mota = txtMoTa.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn mã sách!");
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên trạng thái không được để trống!");
                return;
            }

            if (kiemTraTrungMaS(ma))
            {
                MessageBox.Show("Mã sách đã tồn tại trạng thái!");
                return;
            }

            string sql =
                "INSERT INTO TrangThaiSach VALUES " +
                "('" + ma + "', N'" + ten + "', N'" + mota + "')";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Thêm mới thành công!");

            load_TrangThaiSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = cbbMaSach.SelectedValue?.ToString();
            string ten = txtTenTrangThai.Text.Trim();
            string mota = txtMoTa.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn mã sách!");
                return;
            }

            if (!kiemTraTrungMaS(ma))
            {
                MessageBox.Show("Mã sách không tồn tại!");
                return;
            }

            string sql =
                "UPDATE TrangThaiSach SET " +
                "Tentrangthai = N'" + ten + "', " +
                "Mota = N'" + mota + "' " +
                "WHERE MaS = '" + ma + "'";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Cập nhật thành công!");

            load_TrangThaiSach();
        }

        private void dgvQLTrangThaiSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvQLTrangThaiSach.Columns["chkChon"].Index)
            {
                dgvQLTrangThaiSach.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<string> dsMaSach = new List<string>();

            // 1. Lấy các dòng được tick trong DataGridView
            foreach (DataGridViewRow row in dgvQLTrangThaiSach.Rows)
            {
                bool chon = row.Cells["chkChon"].Value != null &&
                            Convert.ToBoolean(row.Cells["chkChon"].Value);

                if (chon)
                {
                    dsMaSach.Add(row.Cells["MaS"].Value.ToString());
                }
            }

            // 2. Nếu không tick dòng nào → xóa theo combobox
            if (dsMaSach.Count == 0)
            {
                string ma = cbbMaSach.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(ma))
                {
                    MessageBox.Show("Vui lòng chọn mã sách hoặc tick dòng cần xóa!");
                    return;
                }

                dsMaSach.Add(ma);
            }

            // 3. Xác nhận xóa
            DialogResult kq = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {dsMaSach.Count} bản ghi?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (kq == DialogResult.No) return;

            // 4. Thực hiện xóa
            foreach (string ma in dsMaSach)
            {
                string sql = $"DELETE FROM TrangThaiSach WHERE MaS = '{ma}'";
                Thuvien.ins_upd_del(sql);
            }

            MessageBox.Show("Xóa thành công!");
            load_TrangThaiSach();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            cbbMaSach.SelectedIndex = -1;
            cbbMaSach.Enabled = true;

            txtTenTrangThai.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();

            load_TrangThaiSach();
        }

        // ================= GRID =================

        private void dgvQLTrangThaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int i = e.RowIndex;

            cbbMaSach.SelectedValue =
                dgvQLTrangThaiSach.Rows[i].Cells["MaS"].Value.ToString();

            txtTenTrangThai.Text =
                dgvQLTrangThaiSach.Rows[i].Cells["Tentrangthai"].Value.ToString();

            txtMoTa.Text =
                dgvQLTrangThaiSach.Rows[i].Cells["Mota"].Value.ToString();

            cbbMaSach.Enabled = false;
        }

        // ================= LOAD FORM =================

        private void QL_Trangthaisach_Load(object sender, EventArgs e)
        {
            load_TrangThaiSach();
            load_MaSach();
            AddCheckBoxColumn();
        }

        // ================= CHECKBOX =================

        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "chkChon";
            chk.HeaderText = "Chọn";
            chk.Width = 60;
            dgvQLTrangThaiSach.Columns.Insert(0, chk);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                txtTimKiem.Focus();
                return;
            }

            // 2. SQL tìm kiếm
            string sql =
                "SELECT * FROM TrangThaiSach " +
                "WHERE MaS LIKE '%" + key + "%' " +
                "OR Tentrangthai LIKE N'%" + key + "%'";

            // 3. Đổ dữ liệu lên DataGridView
            DataTable tb = Thuvien.Getdatatable(sql);
            dgvQLTrangThaiSach.DataSource = tb;
            dgvQLTrangThaiSach.Refresh();
        }



        private void btnNhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook wb = excelApp.Workbooks.Open(ofd.FileName);
            Excel.Worksheet ws = wb.Sheets[1];
            Excel.Range range = ws.UsedRange;

            try
            {
                // Bỏ dòng tiêu đề → bắt đầu từ dòng 2
                for (int i = 2; i <= range.Rows.Count; i++)
                {
                    string ma = range.Cells[i, 1].Value?.ToString();
                    string ten = range.Cells[i, 2].Value?.ToString();
                    string mota = range.Cells[i, 3].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                        continue;

                    // Kiểm tra trùng → bỏ qua
                    if (kiemTraTrungMaS(ma))
                        continue;

                    string sql =
                        "INSERT INTO TrangThaiSach VALUES (" +
                        "'" + ma + "', " +
                        "N'" + ten + "', " +
                        "N'" + mota + "'" +
                        ")";

                    Thuvien.ins_upd_del(sql);
                }

                MessageBox.Show("Nhập file thành công!");
                load_TrangThaiSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập file: " + ex.Message);
            }
            finally
            {
                wb.Close(false);
                excelApp.Quit();

                Marshal.ReleaseComObject(ws);
                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(excelApp);
            }
        }

        private void btnXuatFile_Click_1(object sender, EventArgs e)
        {
            if (dgvQLTrangThaiSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.FileName = "TrangThaiSach.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook wb = excelApp.Workbooks.Add();
            Excel.Worksheet ws = wb.Sheets[1];

            try
            {
                // 1. Ghi tiêu đề cột
                for (int i = 0; i < dgvQLTrangThaiSach.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1] = dgvQLTrangThaiSach.Columns[i].HeaderText;
                }

                // 2. Ghi dữ liệu
                for (int i = 0; i < dgvQLTrangThaiSach.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvQLTrangThaiSach.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] =
                            dgvQLTrangThaiSach.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // 3. Tự căn cột
                ws.Columns.AutoFit();

                // 4. Lưu file
                wb.SaveAs(sfd.FileName);
                MessageBox.Show("Xuất file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
            }
            finally
            {
                wb.Close();
                excelApp.Quit();

                Marshal.ReleaseComObject(ws);
                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}
