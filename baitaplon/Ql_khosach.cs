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
using ex_cel = Microsoft.Office.Interop.Excel;

namespace baitaplon
{
    public partial class Ql_khosach : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");

        public Ql_khosach()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void load_Sach()
        {
            string sql = "SELECT * FROM Sach";
            Thuvien.hienthicbo(cboMaS, sql, "MaS", "TenS");
            Thuvien.hienthicbo(cboMaS_tk, sql, "MaS", "TenS");
        }

        private void load_Khosach()
        {
            string sql = "Select Khosach. *,TenS from Khosach, Sach where Khosach.MaS = Sach.MaS; ";
            Thuvien.hienthi_luoi(dgvKhosach, sql);
        }

        private void Ql_khosach_Load(object sender, EventArgs e)
        {
            load_Sach();
            load_Khosach();
        }

        // kiểm tra trùng MaK 
        private bool checktrungMaK(string mk)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT COUNT(*) FROM Khosach WHERE MaK = '" + mk + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            con.Close();

            return kq > 0;
        }

        // ===== THÊM =====
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mk = txtMaK.Text.Trim();
            string ms = cboMaS.SelectedValue.ToString();

            // kiểm tra rỗng trước khi Parse
            if (string.IsNullOrWhiteSpace(txtSLN.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng nhập!");
                txtSLN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSLX.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng xuất!");
                txtSLX.Focus();
                return;
            }

            int sln, slx;
            try
            {
                sln = int.Parse(txtSLN.Text.Trim());
                slx = int.Parse(txtSLX.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Số lượng nhập / xuất phải là số nguyên!");
                return;
            }

            // kiểm tra trùng mã
            if (checktrungMaK(mk))
            {
                txtMaK.Focus();
                MessageBox.Show("Trùng mã kho");
                return;
            }
            string sql =
                "INSERT INTO Khosach (MaK, MaS, SoluongN, SoluongX) " +
                "VALUES (N'" + mk + "', N'" + ms + "', " + sln + ", " + slx + ")";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Thêm mới thành công!");
            load_Khosach();
        }

        // ===== SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            string mk = txtMaK.Text.Trim();
            string ms = cboMaS.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(txtSLN.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng nhập!");
                txtSLN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSLX.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng xuất!");
                txtSLX.Focus();
                return;
            }

            int sln, slx;
            try
            {
                sln = int.Parse(txtSLN.Text.Trim());
                slx = int.Parse(txtSLX.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Số lượng nhập / xuất phải là số nguyên!");
                return;
            }

            string sql =
                "UPDATE Khosach SET " +
                "MaS = N'" + ms + "', " +
                "SoluongN = " + sln + ", " +
                "SoluongX = " + slx + " " +   
                "WHERE MaK = '" + mk + "'";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Sửa thành công!!!");
            load_Khosach();
        }

        // ===== XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ms = cboMaS.Text;
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa không?", "Delete",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.No)
                return;

            string sql = "DELETE FROM Khosach WHERE MaS = '" + ms + "' ";
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Xóa thành công");
            load_Khosach();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaK.Clear();
            cboMaS.SelectedIndex = -1;
            txtSLN.Clear();
            txtSLX.Clear();
            txtMaK.Enabled = true;
            txtMaK.Focus();
            load_Khosach();
        }

        // ===== TÌM KIẾM =====
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mk = txtMaK_tk.Text.Trim();
            string ms = cboMaS_tk.SelectedValue?.ToString();

            string sql = "SELECT * FROM Khosach " +
                         "WHERE MaK LIKE N'%" + mk + "%' " +
                         "AND MaS LIKE N'%" + ms + "%'";

            DataTable tb = Thuvien.Getdatatable(sql);
            dgvKhosach.DataSource = tb;
            dgvKhosach.Refresh();
        }

        // ===== XUẤT EXCEL =====
        public void ExportExcel_Khosach(DataTable tb, string sheetname)
        {
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbook oBook = oExcel.Workbooks.Add(Type.Missing);
            ex_cel.Worksheet oSheet = (ex_cel.Worksheet)oBook.Worksheets.get_Item(1);

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;

            oSheet.Name = sheetname;

            // HEADER
            ex_cel.Range head = oSheet.get_Range("A1", "G1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH KHO SÁCH";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // TIÊU ĐỀ CỘT
            oSheet.Cells[3, 1] = "STT";
            oSheet.Cells[3, 2] = "MÃ KHO";
            oSheet.Cells[3, 3] = "MÃ SÁCH";
            oSheet.Cells[3, 4] = "TÊN SÁCH";
            oSheet.Cells[3, 5] = "SL NHẬP";
            oSheet.Cells[3, 6] = "SL XUẤT";
            oSheet.Cells[3, 7] = "SL TỒN";

            ((ex_cel.Range)oSheet.Columns[1]).ColumnWidth = 7.5;
            ((ex_cel.Range)oSheet.Columns[2]).ColumnWidth = 12;
            ((ex_cel.Range)oSheet.Columns[3]).ColumnWidth = 12;
            ((ex_cel.Range)oSheet.Columns[4]).ColumnWidth = 25;
            ((ex_cel.Range)oSheet.Columns[5]).ColumnWidth = 10;
            ((ex_cel.Range)oSheet.Columns[6]).ColumnWidth = 10;
            ((ex_cel.Range)oSheet.Columns[7]).ColumnWidth = 10;

            ex_cel.Range rowHead = oSheet.get_Range("A3", "G3");
            rowHead.Font.Bold = true;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            rowHead.Borders.LineStyle = ex_cel.XlLineStyle.xlContinuous;

            if (tb.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            int rowStart = 4;
            int colCount = 7;
            object[,] arr = new object[tb.Rows.Count, colCount];

            for (int r = 0; r < tb.Rows.Count; r++)
            {
                arr[r, 0] = r + 1;
                arr[r, 1] = tb.Rows[r]["MaK"]?.ToString();
                arr[r, 2] = tb.Rows[r]["MaS"]?.ToString();
                arr[r, 3] = tb.Rows[r]["TenS"]?.ToString();
                arr[r, 4] = tb.Rows[r]["SoluongN"]?.ToString();
                arr[r, 5] = tb.Rows[r]["SoluongX"]?.ToString();
                arr[r, 6] = tb.Rows[r]["SoluongT"]?.ToString();
            }

            int rowEnd = rowStart + tb.Rows.Count - 1;

            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, 1];
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, colCount];
            ex_cel.Range range = oSheet.get_Range(c1, c2);

            range.Value2 = arr;
            range.Borders.LineStyle = ex_cel.XlLineStyle.xlContinuous;

            oSheet.get_Range("A4", "A" + rowEnd).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range("E4", "G" + rowEnd).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
        }

        private void btnXuatfile_Click(object sender, EventArgs e)
        {
            string mk = txtMaK_tk.Text.Trim();
            string ms = cboMaS_tk.SelectedValue?.ToString() ?? "";

            string sql =
                "SELECT k.MaK, k.MaS, s.TenS, k.SoluongN, k.SoluongX, k.SoluongT " +
                "FROM Khosach k " +
                "JOIN Sach s ON k.MaS = s.MaS " +
                "WHERE k.MaK LIKE N'%" + mk + "%' " +
                "AND k.MaS LIKE N'%" + ms + "%'";

            System.Data.DataTable tb = Thuvien.Getdatatable(sql);
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            ExportExcel_Khosach(tb, "DSKhoSach");
        }

        private void dgvTheloai_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvKhosach.Rows[e.RowIndex].IsNewRow)
                return;
            dgvKhosach.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgvKhosach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int i = e.RowIndex;
            txtMaK.Text = dgvKhosach.Rows[i].Cells[0].Value.ToString();
            cboMaS.Text = dgvKhosach.Rows[i].Cells[1].Value.ToString();
            txtSLN.Text = dgvKhosach.Rows[i].Cells[2].Value.ToString();
            txtSLX.Text = dgvKhosach.Rows[i].Cells[3].Value.ToString();
            txtMaK.Enabled = false;
        }
    }
}
