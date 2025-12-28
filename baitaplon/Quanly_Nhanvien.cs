using baitaplon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace Quanlythuvien
{
    public partial class Quanly_Nhanvien : Form
    {
        string strCon = "Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True";

        public Quanly_Nhanvien()
        {
            InitializeComponent();
        }

        /* ================= LOAD DATA ================= */
        void LoadData()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Manhanvien, Tennhanvien, Gioitinh, Dienthoai, Ngaysinh, Emai, Diachi FROM Thongtin_nhanvien",
                    con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDanhSach.DataSource = dt;

                dgvDanhSach.AllowUserToAddRows = false;
                dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDanhSach.MultiSelect = false;
                dgvDanhSach.RowHeadersVisible = false;
            }
        }

        /* ================= RESET FORM ================= */
        void ResetInput()
        {
            txtMnv2.Clear();
            txtTnv2.Clear();
            txtDt2.Clear();
            txtEmail.Clear();
            txtDc.Clear();
            cbGt2.SelectedIndex = -1;
            dateNs.Value = DateTime.Now;
            txtMnv2.Enabled = true;
        }

        private void Quanly_Nhanvien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /* ================= CLICK GRID ================= */
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // tránh click header

            DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

            txtMnv2.Text = row.Cells["Manhanvien"].Value?.ToString();
            txtTnv2.Text = row.Cells["Tennhanvien"].Value?.ToString();
            cbGt2.Text = row.Cells["Gioitinh"].Value?.ToString();
            txtDt2.Text = row.Cells["Dienthoai"].Value?.ToString();
            txtEmail.Text = row.Cells["Emai"].Value?.ToString();
            txtDc.Text = row.Cells["Diachi"].Value?.ToString();

            if (row.Cells["Ngaysinh"].Value != DBNull.Value)
                dateNs.Value = Convert.ToDateTime(row.Cells["Ngaysinh"].Value);

            txtMnv2.Enabled = false;

        }

        /* ================= THÊM ================= */
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMnv2.Text == "" || txtTnv2.Text == "")
            {
                MessageBox.Show("Nhập mã & tên nhân viên");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    string sql =
                        "INSERT INTO Thongtin_nhanvien VALUES " +
                        "(@Ma,@Ten,@GT,@DT,@NS,@Email,@DC)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ma", txtMnv2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ten", txtTnv2.Text.Trim());
                    cmd.Parameters.AddWithValue("@GT", cbGt2.Text);

                    if (txtDt2.Text == "")
                        cmd.Parameters.AddWithValue("@DT", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DT", int.Parse(txtDt2.Text));

                    cmd.Parameters.AddWithValue("@NS", dateNs.Value);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@DC", txtDc.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công!");
                LoadData();
                ResetInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }
        private void btnTk_Click(object sender, EventArgs e)
        {

            string ma = txtMnv1.Text.Trim();
            string ten = txtTnv1.Text.Trim();
            string gt = cbGt1.Text.Trim();
            string dt = txtDt1.Text.Trim();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();

                string sql =
                    "SELECT * FROM Thongtin_nhanvien WHERE 1=1 ";

                if (ma != "")
                    sql += "AND Manhanvien LIKE @Ma ";

                if (ten != "")
                    sql += "AND Tennhanvien LIKE @Ten ";

                if (gt != "")
                    sql += "AND Gioitinh = @GT ";

                if (dt != "")
                    sql += "AND Dienthoai LIKE @DT ";

                SqlCommand cmd = new SqlCommand(sql, con);

                if (ma != "")
                    cmd.Parameters.AddWithValue("@Ma", "%" + ma + "%");

                if (ten != "")
                    cmd.Parameters.AddWithValue("@Ten", "%" + ten + "%");

                if (gt != "")
                    cmd.Parameters.AddWithValue("@GT", gt);

                if (dt != "")
                    cmd.Parameters.AddWithValue("@DT", "%" + dt + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtb = new DataTable();
                da.Fill(dtb);

                dgvDanhSach.DataSource = dtb;
            }
        }


        /* ================= SỬA ================= */
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMnv2.Text.Trim();
            string ten = txtTnv2.Text.Trim();
            DateTime ns = dateNs.Value;
            string gt = cbGt2.Text;
            string dt = txtDt2.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dc = txtDc.Text.Trim();

            if (ma == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            SqlConnection con = new SqlConnection(strCon);

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql =
                "UPDATE Thongtin_nhanvien SET " +
                "Tennhanvien = N'" + ten + "', " +
                "Ngaysinh = '" + ns.ToString("yyyy-MM-dd") + "', " +
                "Gioitinh = N'" + gt + "', " +
                "Dienthoai = '" + dt + "', " +
                "Emai = '" + email + "', " +
                "Diachi = N'" + dc + "' " +
                "WHERE Manhanvien = '" + ma + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Sửa thành công!");
            LoadData();
            ResetInput();
        }


        /* ================= XÓA ================= */
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMnv2.Text == "") return;

            if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No) return;

            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    string sql = "DELETE FROM Thongtin_nhanvien WHERE Manhanvien=@Ma";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ma", txtMnv2.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã xóa!");
                LoadData();
                ResetInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }
        /* ================= THOÁT ================= */
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Trangchu f = new Trangchu();
            f.Show();
            this.Close(); // đóng form nhân viên
        }

        private DataTable GetNhanVienData()
        {
            DataTable tb = new DataTable();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                string sql = "SELECT Manhanvien, Tennhanvien, Ngaysinh, Gioitinh, Dienthoai, Emai, Diachi FROM Thongtin_nhanvien";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(tb);
            }
            return tb;
        }
        /* ================= xuất file ================= */

        private void btnXf_Click(object sender, EventArgs e)
        {
            DataTable tb = GetNhanVienData();

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            ExportExcel_NhanVien(tb);
        }



        private void ExportExcel_NhanVien(DataTable tb)
        {
            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook oBook = oExcel.Workbooks.Add(Type.Missing);
            Excel.Worksheet oSheet = (Excel.Worksheet)oBook.Worksheets[1];

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oSheet.Name = "NhanVien";

            /* ===== TIÊU ĐỀ ===== */
            Excel.Range head = oSheet.Range["A1", "G1"];
            head.Merge();
            head.Value = "DANH SÁCH NHÂN VIÊN";
            head.Font.Bold = true;
            head.Font.Size = 16;
            head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            /* ===== HEADER ===== */
            string[] headers =
            {
        "MÃ NV",
        "TÊN NHÂN VIÊN",
        "NGÀY SINH",
        "GIỚI TÍNH",
        "ĐIỆN THOẠI",
        "EMAIL",
        "ĐỊA CHỈ"
    };

            for (int i = 0; i < headers.Length; i++)
            {
                oSheet.Cells[3, i + 1] = headers[i];
                oSheet.Columns[i + 1].ColumnWidth = 25;
            }

            Excel.Range headerRow = oSheet.Range["A3", "G3"];
            headerRow.Font.Bold = true;
            headerRow.Borders.LineStyle = Excel.Constants.xlSolid;
            headerRow.Interior.ColorIndex = 15;
            headerRow.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            /* ===== DATA (ĐỔ TỪNG Ô → KHÔNG MẤT GIỚI TÍNH) ===== */
            int row = 4;
            foreach (DataRow r in tb.Rows)
            {
                oSheet.Cells[row, 1] = r["Manhanvien"];
                oSheet.Cells[row, 2] = r["Tennhanvien"];
                oSheet.Cells[row, 3] = Convert.ToDateTime(r["Ngaysinh"]).ToString("dd/MM/yyyy");
                oSheet.Cells[row, 4] = r["Gioitinh"];   
                oSheet.Cells[row, 5] = r["Dienthoai"];
                oSheet.Cells[row, 6] = r["Emai"];
                oSheet.Cells[row, 7] = r["Diachi"];
                row++;
            }

            Excel.Range dataRange = oSheet.Range["A4", "G" + (row - 1)];
            dataRange.Borders.LineStyle = Excel.Constants.xlSolid;

            oSheet.Range["C4", "D" + (row - 1)]
                  .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            MessageBox.Show("Xuất Excel thành công!");
        }



    }
}
