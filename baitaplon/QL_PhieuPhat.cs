using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace baitaplon
{
    public partial class QL_PhieuPhat : Form
    {
        SqlConnection con = new SqlConnection(
            "Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True"
        );

        private const int DON_GIA_PHAT_1_NGAY = 5000;

        private bool _isLoading = false;

        public QL_PhieuPhat()
        {
            InitializeComponent();
        }

        private void load_nhanvien()
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

        private void load_MaPhieuMuonTre(string keepMaPM = null)
        {
            _isLoading = true;
            comboBoxMaPhieuMuon.BeginUpdate();

            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sql =
                    "SELECT pm.MaPM " +
                    "FROM PhieuMuon pm " +
                    "JOIN PhieuTra pt ON pm.MaPM = pt.MaPM " +
                    "WHERE pt.NgayTra > pm.HanTra " +
                    "AND pm.MaPM NOT IN (SELECT MaPM FROM PhieuPhat) " +
                    "ORDER BY pm.MaPM DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable tb = new DataTable();
                da.Fill(tb);

                if (!string.IsNullOrWhiteSpace(keepMaPM))
                {
                    bool exists = false;
                    foreach (DataRow r in tb.Rows)
                    {
                        if (r["MaPM"].ToString() == keepMaPM) { exists = true; break; }
                    }
                    if (!exists)
                    {
                        DataRow nr = tb.NewRow();
                        nr["MaPM"] = keepMaPM;
                        tb.Rows.InsertAt(nr, 0);
                    }
                }

                con.Close();

                comboBoxMaPhieuMuon.DataSource = null;
                comboBoxMaPhieuMuon.DisplayMember = "MaPM";
                comboBoxMaPhieuMuon.ValueMember = "MaPM";
                comboBoxMaPhieuMuon.DataSource = tb;

                comboBoxMaPhieuMuon.SelectedIndex = -1;
                comboBoxMaPhieuMuon.Text = "";
            }
            finally
            {
                comboBoxMaPhieuMuon.EndUpdate();
                _isLoading = false;
            }
        }

        private void HienThiThongTinTre(string maPM)
        {
            if (string.IsNullOrWhiteSpace(maPM)) return;

            if (con.State == ConnectionState.Closed) con.Open();

            string sql =
                "SELECT pm.HanTra, pt.NgayTra " +
                "FROM PhieuMuon pm " +
                "JOIN PhieuTra pt ON pm.MaPM = pt.MaPM " +
                "WHERE pm.MaPM = @MaPM";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaPM", maPM);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                DateTime hanTra = Convert.ToDateTime(rd["HanTra"]);
                DateTime ngayTra = Convert.ToDateTime(rd["NgayTra"]);

                int soNgayTre = (ngayTra.Date - hanTra.Date).Days;
                if (soNgayTre < 0) soNgayTre = 0;

                int tienPhat = soNgayTre * DON_GIA_PHAT_1_NGAY;

                textBoxHanTra.Text = hanTra.ToString("dd/MM/yyyy");
                textBoxNgayTra.Text = ngayTra.ToString("dd/MM/yyyy");
                textBoxSoNgayTre.Text = soNgayTre.ToString();
                textBoxTienPhat.Text = tienPhat.ToString();
            }
            rd.Close();
            con.Close();
        }

        private void load_phieuphat()
        {
            if (con.State == ConnectionState.Closed) con.Open();

            string sql =
                "SELECT " +
                "pp.MaPP, " +
                "pp.MaPM, " +
                "dg.TenDG AS TenDocGia, " +
                "pm.HanTra, " +
                "pt.NgayTra, " +
                "DATEDIFF(DAY, pm.HanTra, pt.NgayTra) AS SoNgayTre, " +
                "pp.TongTienPhat, " +
                "nv.Tennhanvien AS NguoiLapPhieu " +
                "FROM PhieuPhat pp " +
                "JOIN PhieuMuon pm ON pp.MaPM = pm.MaPM " +
                "JOIN PhieuTra pt ON pm.MaPM = pt.MaPM " +
                "JOIN Docgia dg ON pm.MaDG = dg.MaDG " +
                "JOIN Thongtin_nhanvien nv ON pp.Manhanvien = nv.Manhanvien " +
                "ORDER BY pp.MaPP DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            dataGridViewPP.DataSource = tb;

            if (dataGridViewPP.Columns.Count > 0)
            {
                dataGridViewPP.Columns["MaPP"].HeaderText = "Mã phiếu phạt";
                dataGridViewPP.Columns["MaPM"].HeaderText = "Mã phiếu mượn";
                dataGridViewPP.Columns["TenDocGia"].HeaderText = "Độc giả";
                dataGridViewPP.Columns["HanTra"].HeaderText = "Hạn trả";
                dataGridViewPP.Columns["NgayTra"].HeaderText = "Ngày trả";
                dataGridViewPP.Columns["SoNgayTre"].HeaderText = "Số ngày trễ";
                dataGridViewPP.Columns["TongTienPhat"].HeaderText = "Tiền phạt";
                dataGridViewPP.Columns["NguoiLapPhieu"].HeaderText = "Người lập phiếu";

                dataGridViewPP.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewPP.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewPP.AllowUserToAddRows = false;
            }
        }

        private bool checkTrungMaPhieuPhat(string maPP)
        {
            if (con.State == ConnectionState.Closed) con.Open();

            string sql = "SELECT COUNT(*) FROM PhieuPhat WHERE MaPP = @MaPP";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaPP", maPP);
            int kq = (int)cmd.ExecuteScalar();

            con.Close();
            return kq > 0;
        }

        private void ResetForm()
        {
            textBoxMaPhieuPhat.Clear();
            textBoxMaPhieuPhat.Enabled = true;

            comboBoxMaPhieuMuon.Enabled = true;
            comboBoxMaPhieuMuon.SelectedIndex = -1;
            comboBoxMaPhieuMuon.Text = "";

            comboBoxNhanVienLapPhieu.SelectedIndex = -1;

            textBoxHanTra.Clear();
            textBoxNgayTra.Clear();
            textBoxSoNgayTre.Clear();
            textBoxTienPhat.Clear();

            textBoxHanTra.ReadOnly = true;
            textBoxNgayTra.ReadOnly = true;
            textBoxSoNgayTre.ReadOnly = true;
            textBoxTienPhat.ReadOnly = true;

            dataGridViewPP.ClearSelection();
            textBoxMaPhieuPhat.Focus();
        }

        private void QL_PhieuPhat_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_MaPhieuMuonTre();
            load_phieuphat();
            ResetForm();
        }

        private void comboBoxMaPhieuMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            if (comboBoxMaPhieuMuon.SelectedValue == null) return;

            string maPM = comboBoxMaPhieuMuon.SelectedValue.ToString();
            HienThiThongTinTre(maPM);
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuPhat.Text) ||
                comboBoxMaPhieuMuon.SelectedValue == null ||
                comboBoxNhanVienLapPhieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string maPP = textBoxMaPhieuPhat.Text.Trim();
            string maPM = comboBoxMaPhieuMuon.SelectedValue.ToString();
            string maNV = comboBoxNhanVienLapPhieu.SelectedValue.ToString();

            if (!int.TryParse(textBoxTienPhat.Text.Trim(), out int tienPhat))
                tienPhat = 0;

            if (checkTrungMaPhieuPhat(maPP))
            {
                MessageBox.Show("Trùng mã phiếu phạt!");
                textBoxMaPhieuPhat.Focus();
                return;
            }

            if (con.State == ConnectionState.Closed) con.Open();

            try
            {
                string sql =
                    "INSERT INTO PhieuPhat (MaPP, MaPM, Manhanvien, TongTienPhat) " +
                    "VALUES (@MaPP, @MaPM, @MaNV, @TienPhat)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaPP", maPP);
                cmd.Parameters.AddWithValue("@MaPM", maPM);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@TienPhat", tienPhat);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm phiếu phạt thành công!");

                load_phieuphat();
                load_MaPhieuMuonTre();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu phạt: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaPhieuPhat.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt để sửa");
                return;
            }

            if (comboBoxNhanVienLapPhieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập phiếu");
                return;
            }

            string maPP = textBoxMaPhieuPhat.Text.Trim();
            string maNV = comboBoxNhanVienLapPhieu.SelectedValue.ToString();

            if (!int.TryParse(textBoxTienPhat.Text.Trim(), out int tienPhat))
                tienPhat = 0;

            if (con.State == ConnectionState.Closed) con.Open();

            try
            {
                string sql =
                    "UPDATE PhieuPhat SET " +
                    "Manhanvien = @MaNV, " +
                    "TongTienPhat = @TienPhat " +
                    "WHERE MaPP = @MaPP";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@TienPhat", tienPhat);
                cmd.Parameters.AddWithValue("@MaPP", maPP);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa phiếu phạt thành công!");
                load_phieuphat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phiếu phạt: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maPP = textBoxMaPhieuPhat.Text.Trim();
            if (string.IsNullOrWhiteSpace(maPP))
            {
                MessageBox.Show("Chọn phiếu phạt để xóa");
                return;
            }

            DialogResult xoa = MessageBox.Show(
                "Bạn có chắc muốn xóa phiếu phạt này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xoa == DialogResult.No) return;

            if (con.State == ConnectionState.Closed) con.Open();

            try
            {
                string sql = "DELETE FROM PhieuPhat WHERE MaPP = @MaPP";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaPP", maPP);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa phiếu phạt thành công!");

                load_phieuphat();
                load_MaPhieuMuonTre(); 
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu phạt: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxTimKiem.Clear();
            load_phieuphat();
            load_MaPhieuMuonTre();
            ResetForm();
        }

        private void dataGridViewPP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewPP.Rows[e.RowIndex];

            string maPP = row.Cells["MaPP"].Value.ToString();
            string maPM = row.Cells["MaPM"].Value.ToString();

            textBoxMaPhieuPhat.Text = maPP;
            textBoxMaPhieuPhat.Enabled = false;

            load_MaPhieuMuonTre(maPM);
            comboBoxMaPhieuMuon.SelectedValue = maPM;

            comboBoxMaPhieuMuon.Enabled = false;

            comboBoxNhanVienLapPhieu.Text = row.Cells["NguoiLapPhieu"].Value.ToString();

            textBoxHanTra.Text = Convert.ToDateTime(row.Cells["HanTra"].Value).ToString("dd/MM/yyyy");
            textBoxNgayTra.Text = Convert.ToDateTime(row.Cells["NgayTra"].Value).ToString("dd/MM/yyyy");
            textBoxSoNgayTre.Text = row.Cells["SoNgayTre"].Value.ToString();
            textBoxTienPhat.Text = row.Cells["TongTienPhat"].Value.ToString();
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = textBoxTimKiem.Text.Trim();

            if (con.State == ConnectionState.Closed) con.Open();

            string sql =
                "SELECT " +
                "pp.MaPP, " +
                "pp.MaPM, " +
                "dg.TenDG AS TenDocGia, " +
                "pm.HanTra, " +
                "pt.NgayTra, " +
                "DATEDIFF(DAY, pm.HanTra, pt.NgayTra) AS SoNgayTre, " +
                "pp.TongTienPhat, " +
                "nv.Tennhanvien AS NguoiLapPhieu " +
                "FROM PhieuPhat pp " +
                "JOIN PhieuMuon pm ON pp.MaPM = pm.MaPM " +
                "JOIN PhieuTra pt ON pm.MaPM = pt.MaPM " +
                "JOIN Docgia dg ON pm.MaDG = dg.MaDG " +
                "JOIN Thongtin_nhanvien nv ON pp.Manhanvien = nv.Manhanvien " +
                "WHERE " +
                "pp.MaPP LIKE N'%" + timkiem + "%' OR " +
                "pp.MaPM LIKE N'%" + timkiem + "%' OR " +
                "dg.TenDG LIKE N'%" + timkiem + "%' OR " +
                "nv.Tennhanvien LIKE N'%" + timkiem + "%' " +
                "ORDER BY pp.MaPP DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            con.Close();

            dataGridViewPP.DataSource = tb;
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

            ex_cel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH PHIẾU PHẠT";
            head.Font.Bold = true;
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            string[] headers = {
                "Mã phiếu phạt",
                "Mã phiếu mượn",
                "Độc giả",
                "Hạn trả",
                "Ngày trả",
                "Số ngày trễ",
                "Tiền phạt",
                "Người lập phiếu"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                oSheet.Cells[3, i + 1] = headers[i];
                oSheet.Columns[i + 1].ColumnWidth = 20;
            }

            ex_cel.Range rowHead = oSheet.get_Range("A3", "H3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            int rowStart = 4;
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                oSheet.Cells[rowStart + r, 1] = tb.Rows[r]["MaPP"];
                oSheet.Cells[rowStart + r, 2] = tb.Rows[r]["MaPM"];
                oSheet.Cells[rowStart + r, 3] = tb.Rows[r]["TenDocGia"];

                if (tb.Rows[r]["HanTra"] != DBNull.Value)
                    oSheet.Cells[rowStart + r, 4] = Convert.ToDateTime(tb.Rows[r]["HanTra"]).ToString("dd/MM/yyyy");

                if (tb.Rows[r]["NgayTra"] != DBNull.Value)
                    oSheet.Cells[rowStart + r, 5] = Convert.ToDateTime(tb.Rows[r]["NgayTra"]).ToString("dd/MM/yyyy");

                oSheet.Cells[rowStart + r, 6] = tb.Rows[r]["SoNgayTre"];
                oSheet.Cells[rowStart + r, 7] = tb.Rows[r]["TongTienPhat"];
                oSheet.Cells[rowStart + r, 8] = tb.Rows[r]["NguoiLapPhieu"];
            }

            int rowEnd = rowStart + tb.Rows.Count - 1;
            ex_cel.Range dataRange = oSheet.get_Range("A4", "H" + rowEnd);
            dataRange.Borders.LineStyle = ex_cel.Constants.xlSolid;
            dataRange.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignLeft;

            oSheet.get_Range("D4", "E" + rowEnd).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range("F4", "G" + rowEnd).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
        }

        private void buttonXuatFile_Click(object sender, EventArgs e)
        {
            DataTable tb = dataGridViewPP.DataSource as DataTable;
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
