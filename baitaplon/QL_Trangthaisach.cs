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
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bai_tap_lon;Integrated Security=True");

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

        private bool kiemTraTrungMaS(string mas)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3 tạo đối tượng comand để thực thi câu lệnh sql
            string sql = "Select count (*) from TrangThaiSach Where MaS= '" + mas + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar(); //ép kiểu
            //kiểm tra
            if (kq > 0) return true; // trùng mã
            else return false; //không trùng
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();
            string ten = txtTenTrangThai.Text.Trim();
            string mota = txtMoTa.Text.Trim();
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Mã không được để trống!");
                txtMaSach.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên trạng thái không được để trống!");
                txtTenTrangThai.Focus();
                return;
            }
            // 2. Kiểm tra trùng mã
            if (kiemTraTrungMaS(ma))
            {
                MessageBox.Show("Trùng mã!");
                txtMaSach.Focus();
                return;
            }
            // 3. Câu lệnh SQL
            string sql =
                "INSERT INTO TrangThaiSach VALUES (" +
                "'" + ma + "', " +
                "N'" + ten + "', " +
                "N'" + mota + "'" +
                ")";
            // 4. Thực thi
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Thêm mới thành công!");

            load_TrangThaiSach();
    }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();
            string ten = txtTenTrangThai.Text.Trim();
            string mota = txtMoTa.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Mã sách không được để trống!");
                txtMaSach.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên trạng thái không được để trống!");
                txtTenTrangThai.Focus();
                return;
            }

            // 2. Kiểm tra tồn tại (KHÔNG kiểm tra trùng)
            if (!kiemTraTrungMaS(ma))
            {
                MessageBox.Show("Mã sách không tồn tại để sửa!");
                txtMaSach.Focus();
                return;
            }

            // 3. SQL UPDATE
            string sql =
                "UPDATE TrangThaiSach SET " +
                "Tentrangthai = N'" + ten + "', " +
                "Mota = N'" + mota + "' " +
                "WHERE MaS = '" + ma + "'";

            // 4. Thực thi
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Cập nhật thành công!");

            Thuvien.ins_upd_del(sql);
            load_TrangThaiSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();

            // 3. Xác nhận xóa
            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa trạng thái sách này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (kq == DialogResult.No)
                return;

            // 4. SQL DELETE
            string sql = "DELETE FROM TrangThaiSach WHERE MaS = '" + ma + "'";

            // 5. Thực thi
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Xóa thành công!");

            Thuvien.ins_upd_del(sql);
            load_TrangThaiSach();
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

        private void btnXuatFile_Click(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            // 1. Clear TextBox
            txtMaSach.Clear();
            txtTenTrangThai.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();

            // 2. Enable lại mã sách (nếu khi sửa/xóa bạn có disable)
            txtMaSach.Enabled = true;

            // 3. Load lại dữ liệu
            load_TrangThaiSach();

            // 4. Focus mặc định
            txtMaSach.Focus();
        }

        private void QL_Trangthaisach_Load(object sender, EventArgs e)
        {
            load_TrangThaiSach();
            AddCheckBoxColumn();
        }

        private void dgvQLTrangThaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // click header thì bỏ qua

            int i = e.RowIndex;

            txtMaSach.Text = dgvQLTrangThaiSach.Rows[i].Cells["MaS"].Value.ToString();
            txtTenTrangThai.Text = dgvQLTrangThaiSach.Rows[i].Cells["Tentrangthai"].Value.ToString();
            txtMoTa.Text = dgvQLTrangThaiSach.Rows[i].Cells["Mota"].Value.ToString();

            // Không cho sửa mã sách
            txtMaSach.Enabled = false;
        }
        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "chkChon";
            chk.HeaderText = "Chọn";
            chk.Width = 60;
            chk.TrueValue = true;
            chk.FalseValue = false;

            dgvQLTrangThaiSach.Columns.Insert(0, chk);
        }

        private void dgvQLTrangThaiSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvQLTrangThaiSach.Columns["chkChon"].Index)
            {
                dgvQLTrangThaiSach.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnXoaNhieu_Click(object sender, EventArgs e)
        {
            int dem = 0;

            // Đếm số dòng được chọn
            foreach (DataGridViewRow row in dgvQLTrangThaiSach.Rows)
            {
                bool chon = Convert.ToBoolean(row.Cells["chkChon"].Value);
                if (chon) dem++;
            }

            if (dem == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa!");
                return;
            }

            // Xác nhận xóa
            DialogResult kq = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {dem} dòng đã chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (kq == DialogResult.No)
                return;

            // Xóa từng dòng
            foreach (DataGridViewRow row in dgvQLTrangThaiSach.Rows)
            {
                bool chon = Convert.ToBoolean(row.Cells["chkChon"].Value);
                if (chon)
                {
                    string ma = row.Cells["MaS"].Value.ToString();
                    string sql = "DELETE FROM TrangThaiSach WHERE MaS = '" + ma + "'";
                    Thuvien.ins_upd_del(sql);
                }
            }

            MessageBox.Show("Xóa thành công!");
            load_TrangThaiSach();
        }

    
}
}
