using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;
using xls = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
namespace baitaplon
{
    public partial class Ql_Sach : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");

        public Ql_Sach()
        {
            InitializeComponent();
        }

        private void load_Theloai()
        {
            string sql = "Select * from Theloai";
            Thuvien.hienthicbo(cboLoaisach, sql, "MaTL", "TenTL");
            Thuvien.hienthicbo(cboLoaisach_tk, sql, "MaTL", "TenTL");
        }
        private void load_Tacgia()
        {
            string sql = "Select * from Tacgia";
            Thuvien.hienthicbo(cboTacgia, sql, "MaTG", "TenTG");
            Thuvien.hienthicbo(cboTacgia_tk, sql, "MaTG", "TenTG");
        }
        private void load_Nhaxuatban()
        {
            string sql = "Select * from Nhaxuatban";
            Thuvien.hienthicbo(cboMaNXB, sql, "MaNXB", "TenNXB");
        }

        

        private void load_Sach()
        {
            string sql = "Select Sach. *,TenTL,TenTG,TenNXB from Sach,Tacgia,Nhaxuatban, Theloai where Sach.MaTL=Theloai.MaTL and Sach.MaTG=Tacgia.MaTG and Sach.MaNXB=Nhaxuatban.MaNXB;";
            Thuvien.hienthi_luoi(dgvSach, sql);
        }
        private void Ql_Sach_Load(object sender, EventArgs e)
        {
            load_Theloai();
            load_Tacgia();
            load_Nhaxuatban();
            load_Sach();
        }
        //----THÊM----
        //ktr để khi thêm trùng mã thì thông báo lỗi
        private bool checktrungMas(string ms)
        {
            
          
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "Select count (*) from Sach Where MaS= '" + ms + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            if (kq > 0) return true;
            else return false;

        }
        //FORMAT MAK " MK__"
        private bool CheckFormatMaS(string ms)
        {

            return Regex.IsMatch(ms, @"^S\d{2}$");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ms = txtMaS.Text.Trim();
            string ts = txtTenS.Text.Trim();
            string mt = txtMota.Text.Trim();

            // 1) kiểm tra rỗng trước
            if (string.IsNullOrWhiteSpace(ms))
            {
                MessageBox.Show("Mã sách không được để trống!");
                txtMaS.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(ts))
            {
                MessageBox.Show("Tên sách không được để trống!");
                txtTenS.Focus();
                return;
            }

            // 2) kiểm tra trùng mã sách (thông báo đúng)
            if (checktrungMas(ms))
            {
                txtMaS.Focus();
                MessageBox.Show("Trùng mã sách!");
                return;
            }

            // 3) kiểm tra năm
            if (!int.TryParse(txtNamxuatban.Text.Trim(), out int nam))
            {
                MessageBox.Show("Năm xuất bản phải là số!");
                txtNamxuatban.Focus();
                return;
            }

            // 4) kiểm tra combobox FK (tránh lỗi FK_NhaXuatBan)
            if (cboLoaisach.SelectedValue == null || string.IsNullOrWhiteSpace(cboLoaisach.SelectedValue.ToString()))
            {
                MessageBox.Show("Bạn chưa chọn loại sách!");
                cboLoaisach.Focus();
                return;
            }
            if (cboTacgia.SelectedValue == null || string.IsNullOrWhiteSpace(cboTacgia.SelectedValue.ToString()))
            {
                MessageBox.Show("Bạn chưa chọn tác giả!");
                cboTacgia.Focus();
                return;
            }
            if (cboMaNXB.SelectedValue == null || string.IsNullOrWhiteSpace(cboMaNXB.SelectedValue.ToString()))
            {
                MessageBox.Show("Bạn chưa chọn nhà xuất bản!");
                cboMaNXB.Focus();
                return;
            }

            // 5) kiểm tra tình trạng
            if (cboTinhtrang.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn tình trạng!");
                cboTinhtrang.Focus();
                return;
            }
            // kiểm tra format
            if (!CheckFormatMaS(ms))
            {
                MessageBox.Show("Mã thể loại phải có dạng S01, S02, ...");
                txtMaS.Focus();
                return;
            }

            // 6) lấy giá trị sau khi đã check
            string ml = cboLoaisach.SelectedValue.ToString();
            string mtg = cboTacgia.SelectedValue.ToString();
            string mnxb = cboMaNXB.SelectedValue.ToString();
            string tt = cboTinhtrang.SelectedItem.ToString();

            // 
            string sql =
                "INSERT INTO Sach VALUES (" +
                "'" + ms + "', " +
                "N'" + ts + "', " +
                "'" + ml + "', " +
                "'" + mnxb + "', " +   
                "'" + mtg + "', " +
                nam + ", " +
                "N'" + tt + "', " +
                "N'" + mt + "'" +
                ")";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Thêm mới thành công!");
            load_Sach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ms = txtMaS.Text.Trim();
            string ts = txtTenS.Text.Trim();
            string ml = cboLoaisach.SelectedValue?.ToString();
            string mtg = cboTacgia.SelectedValue?.ToString();
            string mnxb = cboMaNXB.SelectedValue?.ToString();
            string mt = txtMota.Text.Trim();
            string tt = cboTinhtrang.SelectedItem.ToString();
            // check cơ bản
            if (string.IsNullOrWhiteSpace(ms))
            {
                MessageBox.Show("Chưa có mã sách để sửa!");
                return;
            }
            if (!int.TryParse(txtNamxuatban.Text.Trim(), out int nam))
            {
                MessageBox.Show("Năm xuất bản phải là số!");
                return;
            }
            if (cboTinhtrang.SelectedItem == null)
            {
                MessageBox.Show("Chọn tình trạng!");
                return;
            }
            
            string sql =
                "UPDATE Sach SET " +
                "TenS = N'" + ts + "', " +
                "MaTL = '" + ml + "', " +
                "MaTG = '" + mtg + "', " +
                "MaNXB = '" + mnxb + "', " +
                "Namxuatban = " + nam + ", " +          
                "Tinhtrang = N'" + tt + "', " +
                "Mota = N'" + mt + "' " +
                "WHERE MaS = '" + ms + "'";

            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Sửa thành công!!!");
            load_Sach();
        }
        //-----XÓA--------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ms = txtMaS.Text;
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa không?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.No)
                return;
            string sql = "Delete from Sach Where MaS = '" + ms + "' ";
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Xóa thành công");
            load_Sach();
        }


        private void dgvTheloai_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvSach.Rows[e.RowIndex].IsNewRow)
                return;
            dgvSach.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;

        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // click header thì bỏ qua
            int i = e.RowIndex;
            txtMaS.Text = dgvSach.Rows[i].Cells["MaS"].Value.ToString();
            txtTenS.Text = dgvSach.Rows[i].Cells["TenS"].Value.ToString();
            cboLoaisach.SelectedValue = dgvSach.Rows[i].Cells["MaTL"].Value.ToString();
            cboTacgia.SelectedValue = dgvSach.Rows[i].Cells["MaTG"].Value.ToString();
            cboMaNXB.SelectedValue = dgvSach.Rows[i].Cells["MaNXB"].Value.ToString();
            txtNamxuatban.Text = dgvSach.Rows[i].Cells["Namxuatban"].Value.ToString();
            cboTinhtrang.Text = dgvSach.Rows[i].Cells["Tinhtrang"].Value.ToString();
            txtMota.Text = dgvSach.Rows[i].Cells["Mota"].Value.ToString();
            // không cho sửa mã sách
            txtMaS.Enabled = false;
        }

        

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


        //XUẤT FILE
        public void ExportExcel_Sach(DataTable tb, string sheetname)
        {
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbook oBook = oExcel.Workbooks.Add(Type.Missing);
            ex_cel.Worksheet oSheet = (ex_cel.Worksheet)oBook.Worksheets.get_Item(1);

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;

            oSheet.Name = sheetname;

            // ====== HEADER ======
            ex_cel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH SÁCH";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // ====== COLUMN TITLES ======
            oSheet.Cells[3, 1] = "STT";
            oSheet.Cells[3, 2] = "MÃ SÁCH";
            oSheet.Cells[3, 3] = "TÊN SÁCH";
            oSheet.Cells[3, 4] = "THỂ LOẠI";
            oSheet.Cells[3, 5] = "TÁC GIẢ";
            oSheet.Cells[3, 6] = "NXB";
            oSheet.Cells[3, 7] = "NĂM XB";
            oSheet.Cells[3, 8] = "TÌNH TRẠNG";

            // set width
            ((ex_cel.Range)oSheet.Columns[1]).ColumnWidth = 7.5;
            ((ex_cel.Range)oSheet.Columns[2]).ColumnWidth = 14;
            ((ex_cel.Range)oSheet.Columns[3]).ColumnWidth = 30;
            ((ex_cel.Range)oSheet.Columns[4]).ColumnWidth = 18;
            ((ex_cel.Range)oSheet.Columns[5]).ColumnWidth = 18;
            ((ex_cel.Range)oSheet.Columns[6]).ColumnWidth = 18;
            ((ex_cel.Range)oSheet.Columns[7]).ColumnWidth = 10;
            ((ex_cel.Range)oSheet.Columns[8]).ColumnWidth = 16;

            ex_cel.Range rowHead = oSheet.get_Range("A3", "H3");
            rowHead.Font.Bold = true;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            rowHead.Borders.LineStyle = ex_cel.XlLineStyle.xlContinuous;

            // ====== DATA ======
            int rowStart = 4;
            int colCount = 8; // STT + 7 cột
            object[,] arr = new object[tb.Rows.Count, colCount];

            for (int r = 0; r < tb.Rows.Count; r++)
            {
                arr[r, 0] = r + 1;                       // STT
                arr[r, 1] = tb.Rows[r]["MaS"]?.ToString();
                arr[r, 2] = tb.Rows[r]["TenS"]?.ToString();
                arr[r, 3] = tb.Rows[r]["TenTL"]?.ToString();
                arr[r, 4] = tb.Rows[r]["TenTG"]?.ToString();
                arr[r, 5] = tb.Rows[r]["TenNXB"]?.ToString();
                arr[r, 6] = tb.Rows[r]["Namxuatban"]?.ToString();
                arr[r, 7] = tb.Rows[r]["Tinhtrang"]?.ToString();
            }

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            int rowEnd = rowStart + tb.Rows.Count - 1;

            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, 1];       // A4
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, colCount];  // H...
            ex_cel.Range range = oSheet.get_Range(c1, c2);

            range.Value2 = arr;
            range.Borders.LineStyle = ex_cel.XlLineStyle.xlContinuous;

            // căn giữa STT + Năm XB
            oSheet.get_Range("A4", "A" + rowEnd).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range("G4", "G" + rowEnd).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
        }


        private void btnXuatfile_Click(object sender, EventArgs e)
        {
            string ms = txtMaS_tk.Text.Trim();
            string ts = txtTenS_tk.Text.Trim();
            string ml = cboLoaisach_tk.SelectedValue?.ToString() ?? "";
            string mtg = cboTacgia_tk.SelectedValue?.ToString() ?? "";

            string sql =
                "SELECT Sach.MaS, Sach.TenS, Theloai.TenTL, Tacgia.TenTG, Nhaxuatban.TenNXB, " +
                "       Sach.Namxuatban, Sach.Tinhtrang " +
                "FROM Sach " +
                "JOIN Theloai ON Sach.MaTL = Theloai.MaTL " +
                "JOIN Tacgia  ON Sach.MaTG = Tacgia.MaTG " +
                "JOIN Nhaxuatban ON Sach.MaNXB = Nhaxuatban.MaNXB " +
                "WHERE Sach.MaS LIKE N'%" + ms + "%' " +
                "AND Sach.TenS LIKE N'%" + ts + "%' " +
                "AND Sach.MaTL LIKE N'%" + ml + "%' " +
                "AND Sach.MaTG LIKE N'%" + mtg + "%'";

            DataTable tb = Thuvien.Getdatatable(sql);
            ExportExcel_Sach(tb, "DSSach");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaS.Clear();
            txtTenS.Clear();
           cboLoaisach.SelectedIndex = -1;
            cboTacgia.SelectedIndex = -1;
            cboMaNXB.SelectedIndex = -1;
            txtMota.Clear();
            cboTinhtrang.SelectedIndex = -1;

            txtMaS.Enabled = true;
            txtMaS.Focus();
            load_Sach();
        }


        private bool checkMaTLTonTai(string maTL)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = "SELECT COUNT(*) FROM Theloai WHERE MaTL = N'" + maTL + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private bool checkMaTGTonTai(string maTG)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = "SELECT COUNT(*) FROM Tacgia WHERE MaTG = N'" + maTG + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private bool checkMaNXBTonTai(string maNXB)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            string sql = "SELECT COUNT(*) FROM Nhaxuatban WHERE MaNXB = N'" + maNXB + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            return (int)cmd.ExecuteScalar() > 0;
        }
        private void ReadExcel_Sach(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Chưa chọn file");
                return;
            }

            xls.Application excel = new xls.Application();
            xls.Workbook wb = null;

            int them = 0, capnhat = 0, boqua = 0;

            try
            {
                wb = excel.Workbooks.Open(filePath);

                if (con.State == ConnectionState.Closed) con.Open();

                foreach (xls.Worksheet ws in wb.Worksheets)
                {
                    int i = 2; // dữ liệu bắt đầu từ dòng 2

                    while (true)
                    {
                        // B: MaS, C: TenS ...
                        var vMaS = ws.Cells[i, 2].Value2;
                        var vTenS = ws.Cells[i, 3].Value2;

                        // hết dữ liệu khi MaS trống
                        if (vMaS == null) break;

                        string maS = vMaS?.ToString().Trim();
                        string tenS = vTenS?.ToString().Trim();

                        string maTL = ws.Cells[i, 4].Value2?.ToString().Trim();
                        string maNXB = ws.Cells[i, 5].Value2?.ToString().Trim();
                        string maTG = ws.Cells[i, 6].Value2?.ToString().Trim();
                        string namStr = ws.Cells[i, 7].Value2?.ToString().Trim();
                        string tinhtrang = ws.Cells[i, 8].Value2?.ToString().Trim();
                        string mota = ws.Cells[i, 9].Value2?.ToString().Trim();

                        // check rỗng tối thiểu
                        if (string.IsNullOrWhiteSpace(maS) || string.IsNullOrWhiteSpace(tenS))
                        {
                            boqua++; i++; continue;
                        }

                        // check format mã sách
                        if (!CheckFormatMaS(maS))
                        {
                            boqua++; i++; continue;
                        }

                        // check năm
                        if (!int.TryParse(namStr, out int nam))
                        {
                            boqua++; i++; continue;
                        }

                        // check FK (nếu file có thể thiếu thì cũng bỏ qua)
                        if (string.IsNullOrWhiteSpace(maTL) || !checkMaTLTonTai(maTL))
                        { boqua++; i++; continue; }

                        if (string.IsNullOrWhiteSpace(maTG) || !checkMaTGTonTai(maTG))
                        { boqua++; i++; continue; }

                        if (string.IsNullOrWhiteSpace(maNXB) || !checkMaNXBTonTai(maNXB))
                        { boqua++; i++; continue; }

                        if (string.IsNullOrWhiteSpace(tinhtrang))
                        { boqua++; i++; continue; }

                        // INSERT / UPDATE
                        if (checktrungMas(maS))
                        {
                            string sqlUpd =
                                "UPDATE Sach SET " +
                                "TenS = N'" + tenS + "', " +
                                "MaTL = N'" + maTL + "', " +
                                "MaNXB = N'" + maNXB + "', " +
                                "MaTG = N'" + maTG + "', " +
                                "Namxuatban = " + nam + ", " +
                                "Tinhtrang = N'" + tinhtrang + "', " +
                                "Mota = N'" + (mota ?? "") + "' " +
                                "WHERE MaS = N'" + maS + "'";

                            Thuvien.ins_upd_del(sqlUpd);
                            capnhat++;
                        }
                        else
                        {
                            string sqlIns =
                                "INSERT INTO Sach(MaS, TenS, MaTL, MaNXB, MaTG, Namxuatban, Tinhtrang, Mota) VALUES(" +
                                "N'" + maS + "', " +
                                "N'" + tenS + "', " +
                                "N'" + maTL + "', " +
                                "N'" + maNXB + "', " +
                                "N'" + maTG + "', " +
                                nam + ", " +
                                "N'" + tinhtrang + "', " +
                                "N'" + (mota ?? "") + "'" +
                                ")";

                            Thuvien.ins_upd_del(sqlIns);
                            them++;
                        }

                        i++;
                    }
                }

                MessageBox.Show($"Nhập Excel Sách xong!\nThêm: {them}\nCập nhật: {capnhat}\nBỏ qua: {boqua}");
                load_Sach();
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
                ReadExcel_Sach(ofd.FileName);
            }
        }
    }
}
