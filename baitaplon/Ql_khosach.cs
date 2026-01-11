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
using xls = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
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
            if (kq > 0) return true;
            else return false;

        }

        // ===== THÊM =====
        //FORMAT MAK " MK__"
        private bool CheckFormatMaK(string mk)
        {
         
            return Regex.IsMatch(mk, @"^MK\d{2}$");
        }
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
            if (slx > sln)
            {
                MessageBox.Show("Số lượng xuất không được lớn hơn số lượng nhập!");
                txtSLX.Focus();
                return;
            }

            // kiểm tra trùng mã
            if (checktrungMaK(mk))
            {
                txtMaK.Focus();
                MessageBox.Show("Trùng mã kho");
                return;
            }
            // kiểm tra format
            if (!CheckFormatMaK(mk))
            {
                MessageBox.Show("Mã thể loại phải có dạng MK01, MK02, ...");
                txtMaK.Focus();
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
        //Xóa theo Mã kho (MaK) ⇒ xóa tất cả sách trong kho đó (xóa hàng loạt)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mk = txtMaK.Text.Trim();

            if (string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show("Vui lòng chọn / nhập mã kho cần xóa!");
                txtMaK.Focus();
                return;
            }

            DialogResult xoa = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (xoa == DialogResult.No) return;

            string sql = "DELETE FROM Khosach WHERE MaK = N'" + mk + "'";
            Thuvien.ins_upd_del(sql);

            MessageBox.Show("Xóa thành công!");
            load_Khosach();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaK.Clear();
            cboMaS.SelectedIndex = -1;
            txtSLN.Clear();
            txtSLX.Clear();
            txtMaK_tk.Clear();
            cboMaS_tk.SelectedIndex = -1;
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

        private void dgvKhosach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvKhosach.Rows[e.RowIndex].IsNewRow) return;

            if (dgvKhosach.Columns.Contains("STT"))
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
        //NHẬP FILE
        private bool checkTrungKhoSach(string maK, string maS)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT COUNT(*) FROM Khosach WHERE MaK = N'" + maK + "' AND MaS = N'" + maS + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            return kq > 0;
        }
        private bool checkMaSachTonTai(string maS)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT COUNT(*) FROM Sach WHERE MaS = N'" + maS + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            return kq > 0;
        }

        private void ReadExcel_KhoSach(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Chưa chọn file");
                return;
            }

            xls.Application excel = new xls.Application();
            xls.Workbook wb = null;

            int them = 0;
            int capnhat = 0;
            int boqua = 0;

            try
            {
                wb = excel.Workbooks.Open(filePath);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                foreach (xls.Worksheet ws in wb.Worksheets)
                {
                    int i = 2; // dữ liệu bắt đầu từ dòng 2

                    while (true)
                    {
                        // B: MaK, C: MaS, D: SLN, E: SLX
                        var vMaK = ws.Cells[i, 2].Value2;
                        var vMaS = ws.Cells[i, 3].Value2;

                        // hết dữ liệu khi cả MaK và MaS đều trống
                        if (vMaK == null && vMaS == null) break;

                        string maK = vMaK?.ToString().Trim();
                        string maS = vMaS?.ToString().Trim();

                        // bỏ qua dòng thiếu mã
                        if (string.IsNullOrWhiteSpace(maK) || string.IsNullOrWhiteSpace(maS))
                        {
                            boqua++;
                            i++;
                            continue;
                        }

                        // check FK mã sách
                        if (!checkMaSachTonTai(maS))
                        {
                            boqua++;
                            i++;
                            continue;
                        }

                        // đọc số lượng (null => 0)
                        int sln = 0, slx = 0;

                        var vSLN = ws.Cells[i, 4].Value2;
                        var vSLX = ws.Cells[i, 5].Value2;

                        if (vSLN != null && !int.TryParse(vSLN.ToString(), out sln))
                        {
                            boqua++;
                            i++;
                            continue;
                        }
                        if (vSLX != null && !int.TryParse(vSLX.ToString(), out slx))
                        {
                            boqua++;
                            i++;
                            continue;
                        }

                        // validate nghiệp vụ
                        if (sln < 0 || slx < 0 || slx > sln)
                        {
                            boqua++;
                            i++;
                            continue;
                        }

                        //  check trùng cặp (MaK, MaS)
                        if (checkTrungKhoSach(maK, maS))
                        {
                            // trùng -> UPDATE
                            string sqlUpd =
                                "UPDATE Khosach SET " +
                                "SoluongN = " + sln + ", " +
                                "SoluongX = " + slx + " " +
                                "WHERE MaK = N'" + maK + "' AND MaS = N'" + maS + "'";

                            Thuvien.ins_upd_del(sqlUpd);
                            capnhat++;
                        }
                        else
                        {
                            // chưa có -> INSERT (không insert SoluongT vì computed)
                            string sqlIns =
                                "INSERT INTO Khosach(MaK, MaS, SoluongN, SoluongX) VALUES(" +
                                "N'" + maK + "', " +
                                "N'" + maS + "', " +
                                sln + ", " +
                                slx + ")";

                            Thuvien.ins_upd_del(sqlIns);
                            them++;
                        }

                        i++;
                    }
                }

                MessageBox.Show($"Nhập Excel xong!\nThêm: {them}\nCập nhật: {capnhat}\nBỏ qua: {boqua}");

                
                load_Khosach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập Excel: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
                if (wb != null) wb.Close(false);
                excel.Quit();
            }
        }

        private void btnNhapfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ReadExcel_KhoSach(ofd.FileName);
            }
        }
    }
}
