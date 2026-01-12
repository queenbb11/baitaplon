using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace baitaplon
{
    public partial class QL_PhieuTra : Form
    {
        SqlConnection con = new SqlConnection(
            "Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True"
        );

        public QL_PhieuTra()
        {
            InitializeComponent();
        }

        public void load_nhanvien()
        {
            if (con.State == ConnectionState.Closed) con.Open();

            string sql = "SELECT Manhanvien, Tennhanvien FROM Thongtin_nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            comboBoxNhanVienLapPhieu.DataSource = tb;
            comboBoxNhanVienLapPhieu.DisplayMember = "Tennhanvien";
            comboBoxNhanVienLapPhieu.ValueMember = "Manhanvien";
            comboBoxNhanVienLapPhieu.SelectedIndex = -1;
        }

        private void load_MaPhieuMuon()
        {
            if (con.State == ConnectionState.Closed) con.Open();

            string sql =
                "SELECT MaPM FROM PhieuMuon " +
                "WHERE MaPM NOT IN (SELECT MaPM FROM PhieuTra)";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            comboBoxMaPhieuMuon.DataSource = tb;
            comboBoxMaPhieuMuon.DisplayMember = "MaPM";
            comboBoxMaPhieuMuon.ValueMember = "MaPM";
            comboBoxMaPhieuMuon.SelectedIndex = -1;
        }

        private void load_phieutra()
        {
            if (con.State == ConnectionState.Closed) con.Open();

            string sql =
                "SELECT " +
                "pt.MaPT, " +
                "pt.MaPM, " +
                "dg.TenDG AS TenDocGia, " +
                "pt.NgayTra, " +
                "nv.Tennhanvien AS NguoiLapPhieu " +
                "FROM PhieuTra pt " +
                "JOIN PhieuMuon pm ON pt.MaPM = pm.MaPM " +
                "JOIN Docgia dg ON pm.MaDG = dg.MaDG " +
                "JOIN Thongtin_nhanvien nv ON pt.Manhanvien = nv.Manhanvien " +
                "ORDER BY pt.MaPT DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            dataGridViewPT.DataSource = tb;

            if (dataGridViewPT.Columns.Count > 0)
            {
                dataGridViewPT.Columns["MaPT"].HeaderText = "Mã phiếu trả";
                dataGridViewPT.Columns["MaPM"].HeaderText = "Mã phiếu mượn";
                dataGridViewPT.Columns["TenDocGia"].HeaderText = "Độc giả";
                dataGridViewPT.Columns["NgayTra"].HeaderText = "Ngày trả";
                dataGridViewPT.Columns["NguoiLapPhieu"].HeaderText = "Người lập phiếu";

                dataGridViewPT.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewPT.AllowUserToAddRows = false;
            }
        }

        private bool checkTrungMaPhieuTra(string maPT)
        {
            if (con.State == ConnectionState.Closed) con.Open();

            string sql = "SELECT COUNT(*) FROM PhieuTra WHERE MaPT = '" + maPT + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();

            con.Close();
            return kq > 0;
        }

        private void ResetForm()
        {
            textBoxMaPhieuTra.Clear();
            textBoxMaPhieuTra.Enabled = true;

            comboBoxMaPhieuMuon.SelectedIndex =-1;
            comboBoxNhanVienLapPhieu.SelectedIndex = -1;

            dateTimePickerNgayTra.Value = DateTime.Today;

            textBoxMaPhieuTra.Focus();

            dataGridViewPT.ClearSelection();
        }

        private void QL_PhieuTra_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_MaPhieuMuon();
            load_phieutra();
            ResetForm();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuTra.Text) ||
                comboBoxMaPhieuMuon.SelectedValue == null ||
                comboBoxNhanVienLapPhieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string maPT = textBoxMaPhieuTra.Text.Trim();
            string maPM = comboBoxMaPhieuMuon.SelectedValue.ToString();
            string maNV = comboBoxNhanVienLapPhieu.SelectedValue.ToString();
            DateTime ngayTra = dateTimePickerNgayTra.Value;

            if (checkTrungMaPhieuTra(maPT))
            {
                MessageBox.Show("Trùng mã phiếu trả!");
                textBoxMaPhieuTra.Focus();
                return;
            }

            if (con.State == ConnectionState.Closed) con.Open();
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                List<(string MaS, int SoLuong)> listSach = new List<(string, int)>();

                string sqlCT = "SELECT MaS, SoLuongMuon FROM ChiTietPhieuMuon WHERE MaPM = '" + maPM + "'";
                SqlCommand cmdCT = new SqlCommand(sqlCT, con, tran);
                SqlDataReader rd = cmdCT.ExecuteReader();

                while (rd.Read())
                {
                    listSach.Add((rd["MaS"].ToString(), Convert.ToInt32(rd["SoLuongMuon"])));
                }
                rd.Close();

                if (listSach.Count == 0)
                    throw new Exception("Phiếu mượn này không có chi tiết sách!");

                foreach (var item in listSach)
                {
                    string sqlCheckX = "SELECT SoluongX FROM Khosach WHERE MaS = '" + item.MaS + "'";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheckX, con, tran);
                    int dangMuon = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (item.SoLuong > dangMuon)
                        throw new Exception("Dữ liệu kho không hợp lệ: sách " + item.MaS + " đang mượn " + dangMuon);

                    string sqlHoanKho =
                        "UPDATE Khosach SET SoluongX = SoluongX - " + item.SoLuong +
                        " WHERE MaS = '" + item.MaS + "'";
                    SqlCommand cmdHoan = new SqlCommand(sqlHoanKho, con, tran);
                    cmdHoan.ExecuteNonQuery();
                }

                string sqlPT =
                    "INSERT INTO PhieuTra (MaPT, MaPM, Manhanvien, NgayTra) " +
                    "VALUES ('" + maPT + "', '" + maPM + "', '" + maNV + "', '" +
                    ngayTra.ToString("yyyy-MM-dd") + "')";
                SqlCommand cmdPT = new SqlCommand(sqlPT, con, tran);
                cmdPT.ExecuteNonQuery();

                tran.Commit();

                MessageBox.Show("Trả sách thành công!");
                load_phieutra();
                load_MaPhieuMuon(); 
                ResetForm();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi khi trả sách: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuTra.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu trả để sửa");
                return;
            }

            if (comboBoxNhanVienLapPhieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập phiếu");
                return;
            }

            string maPT = textBoxMaPhieuTra.Text.Trim();
            string maNV = comboBoxNhanVienLapPhieu.SelectedValue.ToString();

            if (con.State == ConnectionState.Closed) con.Open();

            try
            {
                string sql =
                    "UPDATE PhieuTra SET Manhanvien = @MaNV WHERE MaPT = @MaPT";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaPT", maPT);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa người lập phiếu thành công!");
                load_phieutra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phiếu trả: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maPT = textBoxMaPhieuTra.Text.Trim();
            if (string.IsNullOrWhiteSpace(maPT))
            {
                MessageBox.Show("Chọn phiếu trả để xóa");
                return;
            }

            DialogResult xoa = MessageBox.Show(
                "Bạn có chắc muốn xóa phiếu trả này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xoa == DialogResult.No) return;

            if (con.State == ConnectionState.Closed) con.Open();
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                string sqlGetPM = "SELECT MaPM FROM PhieuTra WHERE MaPT = '" + maPT + "'";
                SqlCommand cmdGetPM = new SqlCommand(sqlGetPM, con, tran);
                object o = cmdGetPM.ExecuteScalar();
                if (o == null) throw new Exception("Không tìm thấy phiếu trả!");

                string maPM = o.ToString();

                List<(string MaS, int SoLuong)> listSach = new List<(string, int)>();
                string sqlCT = "SELECT MaS, SoLuongMuon FROM ChiTietPhieuMuon WHERE MaPM = '" + maPM + "'";
                SqlCommand cmdCT = new SqlCommand(sqlCT, con, tran);
                SqlDataReader rd = cmdCT.ExecuteReader();

                while (rd.Read())
                {
                    listSach.Add((rd["MaS"].ToString(), Convert.ToInt32(rd["SoLuongMuon"])));
                }
                rd.Close();

                foreach (var item in listSach)
                {
                    string sqlUndoKho =
                        "UPDATE Khosach SET SoluongX = SoluongX + " + item.SoLuong +
                        " WHERE MaS = '" + item.MaS + "'";
                    SqlCommand cmdUndo = new SqlCommand(sqlUndoKho, con, tran);
                    cmdUndo.ExecuteNonQuery();
                }

                string sqlDel = "DELETE FROM PhieuTra WHERE MaPT = '" + maPT + "'";
                SqlCommand cmdDel = new SqlCommand(sqlDel, con, tran);
                cmdDel.ExecuteNonQuery();

                tran.Commit();

                MessageBox.Show("Xóa thành công!");
                load_phieutra();
                load_MaPhieuMuon(); 
                ResetForm();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi khi xóa phiếu trả: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxTimKiemPT.Clear();
            load_phieutra();
            load_MaPhieuMuon();
            ResetForm();
        }

        private void dataGridViewPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewPT.Rows[e.RowIndex];

            textBoxMaPhieuTra.Text = row.Cells["MaPT"].Value.ToString();
            textBoxMaPhieuTra.Enabled = false;

            comboBoxMaPhieuMuon.Text = row.Cells["MaPM"].Value.ToString();
            comboBoxMaPhieuMuon.Enabled = false; 

            dateTimePickerNgayTra.Value = Convert.ToDateTime(row.Cells["NgayTra"].Value);
            dateTimePickerNgayTra.Enabled = false; 

            comboBoxNhanVienLapPhieu.Text = row.Cells["NguoiLapPhieu"].Value.ToString();
            comboBoxNhanVienLapPhieu.Enabled = true; 
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = textBoxTimKiemPT.Text.Trim();

            if (con.State == ConnectionState.Closed) con.Open();

            string sql =
                "SELECT " +
                "pt.MaPT, " +
                "pt.MaPM, " +
                "dg.TenDG AS TenDocGia, " +
                "pt.NgayTra, " +
                "nv.Tennhanvien AS NguoiLapPhieu " +
                "FROM PhieuTra pt " +
                "JOIN PhieuMuon pm ON pt.MaPM = pm.MaPM " +
                "JOIN Docgia dg ON pm.MaDG = dg.MaDG " +
                "JOIN Thongtin_nhanvien nv ON pt.Manhanvien = nv.Manhanvien " +
                "WHERE " +
                "pt.MaPT LIKE N'%" + timkiem + "%' OR " +
                "pt.MaPM LIKE N'%" + timkiem + "%' OR " +
                "dg.TenDG LIKE N'%" + timkiem + "%' OR " +
                "nv.Tennhanvien LIKE N'%" + timkiem + "%' OR " +
                "CONVERT(NVARCHAR, pt.NgayTra, 103) LIKE N'%" + timkiem + "%' " +
                "ORDER BY pt.MaPT DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            dataGridViewPT.DataSource = tb;

            if (dataGridViewPT.Columns.Count > 0)
            {
                dataGridViewPT.Columns["MaPT"].HeaderText = "Mã phiếu trả";
                dataGridViewPT.Columns["MaPM"].HeaderText = "Mã phiếu mượn";
                dataGridViewPT.Columns["TenDocGia"].HeaderText = "Độc giả";
                dataGridViewPT.Columns["NgayTra"].HeaderText = "Ngày trả";
                dataGridViewPT.Columns["NguoiLapPhieu"].HeaderText = "Người lập phiếu";
                dataGridViewPT.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void ExportExcel(DataTable tb)
        {
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbook oBook;
            ex_cel.Worksheet oSheet;

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;

            oBook = oExcel.Workbooks.Add(Type.Missing);
            oSheet = (ex_cel.Worksheet)oBook.Worksheets[1];

            ex_cel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH PHIẾU TRẢ";
            head.Font.Bold = true;
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            string[] headers = {
                "Mã phiếu trả",
                "Mã phiếu mượn",
                "Độc giả",
                "Ngày trả",
                "Người lập phiếu"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                oSheet.Cells[3, i + 1] = headers[i];
                oSheet.Columns[i + 1].ColumnWidth = 22;
            }

            ex_cel.Range rowHead = oSheet.get_Range("A3", "E3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            int rowStart = 4;
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                oSheet.Cells[rowStart + r, 1] = tb.Rows[r]["MaPT"];
                oSheet.Cells[rowStart + r, 2] = tb.Rows[r]["MaPM"];
                oSheet.Cells[rowStart + r, 3] = tb.Rows[r]["TenDocGia"];

                if (tb.Rows[r]["NgayTra"] != DBNull.Value)
                    oSheet.Cells[rowStart + r, 4] = Convert.ToDateTime(tb.Rows[r]["NgayTra"]).ToString("dd/MM/yyyy");

                oSheet.Cells[rowStart + r, 5] = tb.Rows[r]["NguoiLapPhieu"];
            }

            int rowEnd = rowStart + tb.Rows.Count - 1;
            ex_cel.Range dataRange = oSheet.get_Range("A4", "E" + rowEnd);
            dataRange.Borders.LineStyle = ex_cel.Constants.xlSolid;
            dataRange.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignLeft;

            oSheet.get_Range("D4", "D" + rowEnd).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
        }

        private void buttonXuatFile_Click(object sender, EventArgs e)
        {
            DataTable tb = dataGridViewPT.DataSource as DataTable;
            if (tb == null || tb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }
            ExportExcel(tb);
        }

        private void buttonQuayLai_Click(object sender, EventArgs e)
        {
            Trangchu f = new Trangchu();
            f.Show();
            this.Close(); 
        }
    }
}
