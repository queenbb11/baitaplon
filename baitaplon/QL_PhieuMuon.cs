using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace baitaplon
{
    public partial class QL_PhieuMuon : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");

        public QL_PhieuMuon()
        {
            InitializeComponent();
        }

        public void load_madocgia()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT MaDG, TenDG FROM Docgia";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            con.Close();
            comboBoxMaDocGia.DataSource = tb;
            comboBoxMaDocGia.DisplayMember = "MaDG";
            comboBoxMaDocGia.ValueMember = "MaDG";
            comboBoxMaDocGia.SelectedIndex = -1;
        }

        private void comboBoxDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaDocGia.SelectedItem is DataRowView row)
            {
                textBoxTenDocGia.Text = row["TenDG"].ToString();
            }
        }

        public void load_nhanvien()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
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

        private void load_sachtrongkho(string timKiem = "")
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT k.MaS, s.TenS " +
                 "FROM Khosach k " +
                 "INNER JOIN Sach s ON k.MaS = s.MaS";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            dataGridViewMuonSach.Rows.Clear();
            while (reader.Read())
            {
                int i = dataGridViewMuonSach.Rows.Add();
                dataGridViewMuonSach.Rows[i].Cells["MaSach"].Value = reader["MaS"].ToString();
                dataGridViewMuonSach.Rows[i].Cells["TenSach"].Value = reader["TenS"].ToString();
                dataGridViewMuonSach.Rows[i].Cells["Chon"].Value = false;
                dataGridViewMuonSach.Rows[i].Cells["SoLuong"].Value = "";
            }

            reader.Close();
            con.Close();
        }

        private void QL_PhieuMuon_Load(object sender, EventArgs e)
        {
            load_madocgia();
            textBoxTenDocGia.Text = "";
            load_nhanvien();
            load_sachtrongkho();
            load_phieumuon();
        }

        private void dataGridViewMuonSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewMuonSach.Columns["Chon"].Index && e.RowIndex >= 0)
            {
                dataGridViewMuonSach.EndEdit();
                DataGridViewRow row = dataGridViewMuonSach.Rows[e.RowIndex];
                if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                {
                    row.Cells["SoLuong"].Value = "1";
                }
                else
                {
                    row.Cells["SoLuong"].Value = "";
                }
            }
        }

        private void dataGridViewPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow selectedRow = dataGridViewPhieuMuon.Rows[e.RowIndex];
            string mpm = selectedRow.Cells["MaPM"].Value?.ToString();
            if (string.IsNullOrEmpty(mpm)) return;

            textBoxMaPhieuMuon.Text = mpm;
            textBoxMaPhieuMuon.Enabled = false;

            string maDG = selectedRow.Cells["MaDG"].Value?.ToString() ?? "";
            comboBoxMaDocGia.Text = maDG;

            string tenNV = selectedRow.Cells["NguoiLapPhieu"].Value?.ToString() ?? "";
            comboBoxNhanVienLapPhieu.Text = tenNV;

            dateTimePickerNgayMuon.Value = Convert.ToDateTime(selectedRow.Cells["NgayMuon"].Value);
            dateTimePickerHanTra.Value = Convert.ToDateTime(selectedRow.Cells["HanTra"].Value);

            dataGridViewMuonSach.Rows.Clear();
            load_sachtrongkho();

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sqlChiTiet =
                "SELECT ct.MaS, ct.SoLuongMuon " +
                "FROM ChiTietPhieuMuon ct " +
                "WHERE ct.MaPM = '" + mpm + "'";

            SqlCommand cmd = new SqlCommand(sqlChiTiet, con);
            SqlDataReader reader = cmd.ExecuteReader();

            Dictionary<string, int> daMuon = new Dictionary<string, int>();
            while (reader.Read())
            {
                string maS = reader["MaS"].ToString();
                int sl = Convert.ToInt32(reader["SoLuongMuon"]);
                daMuon[maS] = sl;
            }

            reader.Close();
            con.Close();

            foreach (DataGridViewRow row in dataGridViewMuonSach.Rows)
            {
                if (row.IsNewRow) continue;

                string maS = row.Cells["MaSach"].Value?.ToString() ?? "";
                if (daMuon.ContainsKey(maS))
                {
                    row.Cells["Chon"].Value = true;
                    row.Cells["SoLuong"].Value = daMuon[maS].ToString();
                }
            }
        }

        private bool checktrungMaPhieuMuon(string mpm)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT COUNT(*) FROM PhieuMuon WHERE MaPM = '" + mpm + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            con.Close();

            return kq > 0;
        }

        private void buttonThemPM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuMuon.Text) ||
                comboBoxMaDocGia.SelectedValue == null ||
                comboBoxNhanVienLapPhieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            string mpm = textBoxMaPhieuMuon.Text.Trim();
            string mdg = comboBoxMaDocGia.SelectedValue.ToString();
            string manv = comboBoxNhanVienLapPhieu.SelectedValue.ToString();
            DateTime nm = dateTimePickerNgayMuon.Value;
            DateTime ht = dateTimePickerHanTra.Value;

            if (ht <= nm)
            {
                MessageBox.Show("Hạn trả phải lớn hơn hoặc bằng Ngày mượn");
                return;
            }

            if (checktrungMaPhieuMuon(mpm))
            {
                textBoxMaPhieuMuon.Focus();
                MessageBox.Show("Trùng mã phiếu mượn");
                return;
            }

            bool ChonSach = false;
            foreach (DataGridViewRow row in dataGridViewMuonSach.Rows)
            {
                if (row.IsNewRow) continue;

                if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                {
                    ChonSach = true;

                    string sls = row.Cells["SoLuong"].Value?.ToString() ?? "";
                    if (string.IsNullOrEmpty(sls) || !int.TryParse(sls, out int sl) || sl <= 0)
                    {
                        MessageBox.Show($"Số lượng mượn của sách {row.Cells["TenSach"].Value} không hợp lệ!");
                        return;
                    }
                }
            }

            if (!ChonSach)
            {
                MessageBox.Show("Chưa chọn sách nào để mượn!");
                return;
            }

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlTransaction tran = con.BeginTransaction();
            try
            {
                string sqlPhieu = "INSERT INTO PhieuMuon (MaPM, MaDG, Manhanvien, NgayMuon, HanTra) " +
                                  "VALUES ('" + mpm + "', N'" + mdg + "', '" + manv + "', N'" + nm.ToString("yyyy-MM-dd") + "', '" + ht.ToString("yyyy-MM-dd") + "')";
                SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, con, tran);
                cmdPhieu.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridViewMuonSach.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                    {
                        string maS = row.Cells["MaSach"].Value.ToString();
                        int slMuon = Convert.ToInt32(row.Cells["SoLuong"].Value);

                        string sqlCheckTon = "SELECT SoluongT FROM Khosach WHERE MaS = '" + maS + "'";
                        SqlCommand cmdTon = new SqlCommand(sqlCheckTon, con, tran);
                        int ton = Convert.ToInt32(cmdTon.ExecuteScalar());
                        if (slMuon > ton)
                            throw new Exception("Sách " + row.Cells["TenSach"].Value + " chỉ còn " + ton + " quyển.");

                        string sqlCT = "INSERT INTO ChiTietPhieuMuon (MaPM, MaS, SoLuongMuon) " +
                                       "VALUES ('" + mpm + "', '" + maS + "', " + slMuon + ")";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, con, tran);
                        cmdCT.ExecuteNonQuery();

                        string sqlKho = "UPDATE Khosach SET SoluongX = SoluongX + " + slMuon + " WHERE MaS = '" + maS + "'";
                        SqlCommand cmdKho = new SqlCommand(sqlKho, con, tran);
                        cmdKho.ExecuteNonQuery();
                    }
                }
                tran.Commit();
                MessageBox.Show("Thêm thành công!");
                load_phieumuon();
                dataGridViewMuonSach.Rows.Clear();
                load_sachtrongkho();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi khi thêm phiếu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void load_phieumuon()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql =
                 "SELECT " +
                 "pm.MaPM, " +
                 "pm.MaDG, " +
                 "pm.Manhanvien, " +
                 "nv.Tennhanvien AS NguoiLapPhieu, " +
                 "dg.TenDG AS TenDocGia, " +
                 "s.TenS AS TenSach, " +
                 "ct.SoLuongMuon AS SoLuong, " +
                 "pm.NgayMuon, " +
                 "pm.HanTra " +
                 "FROM PhieuMuon pm " +
                 "JOIN Docgia dg ON pm.MaDG = dg.MaDG " +
                 "JOIN Thongtin_nhanvien nv ON pm.Manhanvien = nv.Manhanvien " +
                 "JOIN ChiTietPhieuMuon ct ON pm.MaPM = ct.MaPM " +
                 "JOIN Sach s ON ct.MaS = s.MaS " +
                 "ORDER BY pm.MaPM DESC, ct.MaS";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            con.Close();

            dataGridViewPhieuMuon.DataSource = tb;

            if (dataGridViewPhieuMuon.Columns.Count > 0)
            {
                dataGridViewPhieuMuon.Columns["MaDG"].Visible = false;
                dataGridViewPhieuMuon.Columns["Manhanvien"].Visible = false;
                dataGridViewPhieuMuon.Columns["MaPM"].HeaderText = "Mã phiếu mượn";
                dataGridViewPhieuMuon.Columns["NguoiLapPhieu"].HeaderText = "Người lập phiếu";
                dataGridViewPhieuMuon.Columns["TenDocGia"].HeaderText = "Tên độc giả";
                dataGridViewPhieuMuon.Columns["TenSach"].HeaderText = "Tên sách";
                dataGridViewPhieuMuon.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridViewPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dataGridViewPhieuMuon.Columns["HanTra"].HeaderText = "Hạn trả";
                dataGridViewPhieuMuon.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewPhieuMuon.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuMuon.Text))
            {
                MessageBox.Show("Chọn phiếu mượn để sửa");
                return;
            }

            string mpm = textBoxMaPhieuMuon.Text.Trim();
            string mdg = comboBoxMaDocGia.SelectedValue.ToString();
            string manv = comboBoxNhanVienLapPhieu.SelectedValue.ToString();
            DateTime nm = dateTimePickerNgayMuon.Value;
            DateTime ht = dateTimePickerHanTra.Value;

            if (ht <= nm)
            {
                MessageBox.Show("Hạn trả phải lớn hơn hoặc bằng Ngày mượn");
                return;
            }

            bool chonSach = false;
            foreach (DataGridViewRow row in dataGridViewMuonSach.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                {
                    chonSach = true;
                    string sls = row.Cells["SoLuong"].Value?.ToString() ?? "";
                    if (string.IsNullOrEmpty(sls) || !int.TryParse(sls, out int sl) || sl <= 0)
                    {
                        MessageBox.Show($"Số lượng mượn của sách {row.Cells["TenSach"].Value} không hợp lệ!");
                        return;
                    }
                }
            }
            if (!chonSach)
            {
                MessageBox.Show("Chưa chọn sách nào để mượn!");
                return;
            }

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlTransaction tran = con.BeginTransaction();
            try
            {
                List<(string MaS, int SoLuong)> oldList = new List<(string, int)>();

                string sqlOld = "SELECT MaS, SoLuongMuon FROM ChiTietPhieuMuon WHERE MaPM = '" + mpm + "'";
                SqlCommand cmdOld = new SqlCommand(sqlOld, con, tran);
                SqlDataReader rd = cmdOld.ExecuteReader();
                while (rd.Read())
                {
                    oldList.Add((rd["MaS"].ToString(), Convert.ToInt32(rd["SoLuongMuon"])));
                }
                rd.Close();

                foreach (var item in oldList)
                {
                    string sqlHoanKho = "UPDATE Khosach SET SoluongX = SoluongX - " + item.SoLuong +
                                        " WHERE MaS = '" + item.MaS + "'";
                    SqlCommand cmdHoan = new SqlCommand(sqlHoanKho, con, tran);
                    cmdHoan.ExecuteNonQuery();
                }

                string sqlUpdate = "UPDATE PhieuMuon SET MaDG = N'" + mdg + "', Manhanvien = '" + manv + "', " +
                                   "NgayMuon = N'" + nm.ToString("yyyy-MM-dd") + "', HanTra = '" + ht.ToString("yyyy-MM-dd") + "' " +
                                   "WHERE MaPM = '" + mpm + "'";
                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con, tran);
                cmdUpdate.ExecuteNonQuery();

                string sqlXoa = "DELETE FROM ChiTietPhieuMuon WHERE MaPM = '" + mpm + "'";
                SqlCommand cmdXoa = new SqlCommand(sqlXoa, con, tran);
                cmdXoa.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridViewMuonSach.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                    {
                        string maS = row.Cells["MaSach"].Value.ToString();
                        int slMuon = Convert.ToInt32(row.Cells["SoLuong"].Value);

                        string sqlTon = "SELECT SoluongT FROM Khosach WHERE MaS = '" + maS + "'";
                        SqlCommand cmdTon = new SqlCommand(sqlTon, con, tran);
                        int ton = Convert.ToInt32(cmdTon.ExecuteScalar());
                        if (slMuon > ton)
                            throw new Exception("Sách " + row.Cells["TenSach"].Value + " chỉ còn " + ton + " quyển.");

                        string sqlCT = "INSERT INTO ChiTietPhieuMuon (MaPM, MaS, SoLuongMuon) " +
                                       "VALUES ('" + mpm + "', '" + maS + "', " + slMuon + ")";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, con, tran);
                        cmdCT.ExecuteNonQuery();

                        string sqlKho = "UPDATE Khosach SET SoluongX = SoluongX + " + slMuon +
                                        " WHERE MaS = '" + maS + "'";
                        SqlCommand cmdKho = new SqlCommand(sqlKho, con, tran);
                        cmdKho.ExecuteNonQuery();
                    }
                }
                tran.Commit();
                MessageBox.Show("Sửa thành công!");
                load_phieumuon();
                load_sachtrongkho();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string mpm = textBoxMaPhieuMuon.Text.Trim();
            if (string.IsNullOrWhiteSpace(mpm))
            {
                MessageBox.Show("Chọn phiếu mượn để xóa");
                return;
            }

            DialogResult xoa = MessageBox.Show(
                "Bạn có chắc muốn xóa phiếu mượn này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xoa == DialogResult.No)
                return;

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlTransaction tran = con.BeginTransaction();
            try
            {
                List<(string MaS, int SoLuong)> listHoanKho = new List<(string, int)>();

                string sqlGetChiTiet = "SELECT MaS, SoLuongMuon FROM ChiTietPhieuMuon WHERE MaPM = '" + mpm + "'";
                SqlCommand cmdGet = new SqlCommand(sqlGetChiTiet, con, tran);

                SqlDataReader reader = cmdGet.ExecuteReader();
                while (reader.Read())
                {
                    listHoanKho.Add((reader["MaS"].ToString(), Convert.ToInt32(reader["SoLuongMuon"])));
                }
                reader.Close(); 

                foreach (var item in listHoanKho)
                {
                    string sqlHoanKho = "UPDATE Khosach SET SoluongX = SoluongX - " + item.SoLuong +
                                        " WHERE MaS = '" + item.MaS + "'";
                    SqlCommand cmdHoan = new SqlCommand(sqlHoanKho, con, tran);
                    cmdHoan.ExecuteNonQuery();
                }

                string sqlXoaCT = "DELETE FROM ChiTietPhieuMuon WHERE MaPM = '" + mpm + "'";
                SqlCommand cmdXoaCT = new SqlCommand(sqlXoaCT, con, tran);
                cmdXoaCT.ExecuteNonQuery();

                string sqlXoaPM = "DELETE FROM PhieuMuon WHERE MaPM = '" + mpm + "'";
                SqlCommand cmdXoaPM = new SqlCommand(sqlXoaPM, con, tran);
                cmdXoaPM.ExecuteNonQuery();

                tran.Commit();
                MessageBox.Show("Xóa thành công!");
                load_phieumuon();

                textBoxMaPhieuMuon.Clear();
                textBoxMaPhieuMuon.Enabled = true;
                comboBoxMaDocGia.SelectedIndex = -1;
                textBoxTenDocGia.Clear();
                comboBoxNhanVienLapPhieu.SelectedIndex = -1;
                dateTimePickerNgayMuon.Value = DateTime.Today;
                dateTimePickerHanTra.Value = DateTime.Today.AddDays(7);
                dataGridViewMuonSach.Rows.Clear();
                load_sachtrongkho();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi khi xóa phiếu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxTimKiemPhieuMuon.Clear();
            textBoxMaPhieuMuon.Clear();
            comboBoxMaDocGia.SelectedIndex = -1;
            comboBoxNhanVienLapPhieu.SelectedIndex = -1;
            textBoxTenDocGia.Clear();
            dateTimePickerNgayMuon.Value = DateTime.Now;
            dateTimePickerHanTra.Value = DateTime.Now;
            textBoxMaPhieuMuon.Enabled = true;
            textBoxMaPhieuMuon.Focus();
            load_phieumuon();
            dataGridViewMuonSach.ClearSelection();
            dataGridViewPhieuMuon.ClearSelection();
            load_sachtrongkho();
            foreach (DataGridViewRow row in dataGridViewMuonSach.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells["Chon"].Value = false;
                row.Cells["SoLuong"].Value = "";
            }
            dataGridViewMuonSach.ClearSelection();
        }

        private void buttonTimKiemPM_Click(object sender, EventArgs e)
        {
            string timkiem = textBoxTimKiemPhieuMuon.Text.Trim();

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql =
                "SELECT " +
                "pm.MaPM, " +
                "pm.MaDG, " +
                "pm.Manhanvien, " +
                "nv.Tennhanvien AS NguoiLapPhieu, " +
                "dg.TenDG AS TenDocGia, " +
                "s.TenS AS TenSach, " +
                "ct.SoLuongMuon AS SoLuong, " +
                "pm.NgayMuon, " +
                "pm.HanTra " +
                "FROM PhieuMuon pm " +
                "JOIN Docgia dg ON pm.MaDG = dg.MaDG " +
                "JOIN Thongtin_nhanvien nv ON pm.Manhanvien = nv.Manhanvien " +
                "JOIN ChiTietPhieuMuon ct ON pm.MaPM = ct.MaPM " +
                "JOIN Sach s ON ct.MaS = s.MaS " +
                "WHERE " +
                "pm.MaPM LIKE N'%" + timkiem + "%' OR " +
                "dg.TenDG LIKE N'%" + timkiem + "%' OR " +
                "s.TenS LIKE N'%" + timkiem + "%' OR " +
                "nv.Tennhanvien LIKE N'%" + timkiem + "%' OR " +
                "CONVERT(NVARCHAR, pm.NgayMuon, 103) LIKE N'%" + timkiem + "%' OR " +
                "CONVERT(NVARCHAR, pm.HanTra, 103) LIKE N'%" + timkiem + "%' " +
                "ORDER BY pm.MaPM DESC, ct.MaS";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            con.Close();

            dataGridViewPhieuMuon.DataSource = tb;

            if (dataGridViewPhieuMuon.Columns.Count > 0)
            {
                dataGridViewPhieuMuon.Columns["MaDG"].Visible = false;
                dataGridViewPhieuMuon.Columns["Manhanvien"].Visible = false;
                dataGridViewPhieuMuon.Columns["MaPM"].HeaderText = "Mã phiếu mượn";
                dataGridViewPhieuMuon.Columns["NguoiLapPhieu"].HeaderText = "Người lập phiếu";
                dataGridViewPhieuMuon.Columns["TenDocGia"].HeaderText = "Tên độc giả";
                dataGridViewPhieuMuon.Columns["TenSach"].HeaderText = "Tên sách";
                dataGridViewPhieuMuon.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridViewPhieuMuon.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dataGridViewPhieuMuon.Columns["HanTra"].HeaderText = "Hạn trả";
                dataGridViewPhieuMuon.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewPhieuMuon.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

            ex_cel.Range head = oSheet.get_Range("A1", "G1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH PHIẾU MƯỢN";
            head.Font.Bold = true;
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            string[] headers = {
                "Mã phiếu mượn",
                "Người lập phiếu",
                "Tên độc giả",
                "Tên sách",
                "Số lượng",
                "Ngày mượn",
                "Hạn trả"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                oSheet.Cells[3, i + 1] = headers[i];
                oSheet.Columns[i + 1].ColumnWidth = 22;
            }

            ex_cel.Range rowHead = oSheet.get_Range("A3", "G3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            int rowStart = 4;
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                oSheet.Cells[rowStart + r, 1] = tb.Rows[r]["MaPM"];
                oSheet.Cells[rowStart + r, 2] = tb.Rows[r]["NguoiLapPhieu"];
                oSheet.Cells[rowStart + r, 3] = tb.Rows[r]["TenDocGia"];
                oSheet.Cells[rowStart + r, 4] = tb.Rows[r]["TenSach"];
                oSheet.Cells[rowStart + r, 5] = tb.Rows[r]["SoLuong"];

                if (tb.Rows[r]["NgayMuon"] != DBNull.Value)
                    oSheet.Cells[rowStart + r, 6] = Convert.ToDateTime(tb.Rows[r]["NgayMuon"]).ToString("dd/MM/yyyy");

                if (tb.Rows[r]["HanTra"] != DBNull.Value)
                    oSheet.Cells[rowStart + r, 7] = Convert.ToDateTime(tb.Rows[r]["HanTra"]).ToString("dd/MM/yyyy");
            }
            int rowEnd = rowStart + tb.Rows.Count - 1;
            ex_cel.Range dataRange = oSheet.get_Range("A4", "G" + rowEnd);
            dataRange.Borders.LineStyle = ex_cel.Constants.xlSolid;
            dataRange.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range("F4", "G" + rowEnd)
                  .HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
        }

        private void buttonXuatFilePM_Click(object sender, EventArgs e)
        {
            DataTable tb = dataGridViewPhieuMuon.DataSource as DataTable;
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
