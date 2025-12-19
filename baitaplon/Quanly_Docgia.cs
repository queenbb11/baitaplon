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
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace baitaplon
{
    public partial class Quanly_Docgia : Form
    {

        SqlConnection con = new SqlConnection(
           "Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True"
       );

        public Quanly_Docgia()
        {
            InitializeComponent();
        }

        private void load_docgia()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT * FROM Docgia";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);

            cmd.Dispose();
            con.Close();

            dtvdocgia.DataSource = tb;
            dtvdocgia.Refresh();
        }


        private bool checktrungMadg(string madg)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "SELECT COUNT(*) FROM Docgia WHERE MaDG='" + madg + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            con.Close();

            return kq > 0;
        }

        private void Quanly_Docgia_Load(object sender, EventArgs e)
        {
            cbgtdg.Items.Clear();
            cbgtdg.Items.Add("Nam");
            cbgtdg.Items.Add("Nữ");
            cbgtdg.SelectedIndex = -1;

            load_docgia();
        }

        private void btnluutg_Click(object sender, EventArgs e)
        {
            string madg = txtmadg.Text.Trim();
            string tendg = txttendg.Text.Trim();
            DateTime ngs = ngsdg.Value;
            string gt = cbgtdg.Text;
            string dt = txtdthoaidg.Text.Trim();
            string email = txtemaildg.Text.Trim();
            string dc = txtdchidg.Text.Trim();

            if (madg == "" || tendg == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên độc giả");
                return;
            }

            if (checktrungMadg(madg))
            {
                MessageBox.Show("Trùng mã độc giả");
                return;
            }

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql =
                "INSERT Docgia VALUES('" + madg + "',N'" + tendg + "','" +
                ngs + "',N'" + gt + "','" + dt + "','" + email + "',N'" + dc + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Thêm mới thành công!");
            load_docgia();
        }

        private void btnsuatg_Click(object sender, EventArgs e)
        {
            string madg = txtmadg.Text.Trim();
            string tendg = txttendg.Text.Trim();
            DateTime ngs = ngsdg.Value;
            string gt = cbgtdg.Text;
            string dt = txtdthoaidg.Text.Trim();
            string email = txtemaildg.Text.Trim();
            string dc = txtdchidg.Text.Trim();

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql =
                "UPDATE Docgia SET TenDG=N'" + tendg +
                "',NgaysinhDG='" + ngs +
                "',GioitinhDG=N'" + gt +
                "',DienthoaiDG='" + dt +
                "',EmailDG='" + email +
                "',DiachiDG=N'" + dc +
                "' WHERE MaDG='" + madg + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sửa thành công!");
            load_docgia();
        }

        private void btnxoatg_Click(object sender, EventArgs e)
        {
            string madg = txtmadg.Text;

            if (MessageBox.Show("Bạn chắc chắn muốn xóa?",
                "Xóa", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql = "DELETE FROM Docgia WHERE MaDG='" + madg + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Xóa thành công!");
            load_docgia();
        }

        private void dtvdocgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtmadg.Text = dtvdocgia.Rows[i].Cells[0].Value.ToString();
            txttendg.Text = dtvdocgia.Rows[i].Cells[1].Value.ToString();
            ngsdg.Value = DateTime.Parse(dtvdocgia.Rows[i].Cells[2].Value.ToString());
            cbgtdg.Text = dtvdocgia.Rows[i].Cells[3].Value.ToString();
            txtdthoaidg.Text = dtvdocgia.Rows[i].Cells[4].Value.ToString();
            txtemaildg.Text = dtvdocgia.Rows[i].Cells[5].Value.ToString();
            txtdchidg.Text = dtvdocgia.Rows[i].Cells[6].Value.ToString();

            txtmadg.Enabled = false;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtmadg.Clear();
            txttendg.Clear();
            txtdthoaidg.Clear();
            txtemaildg.Clear();
            txtdchidg.Clear();
            cbgtdg.SelectedIndex = -1;
            ngsdg.Value = DateTime.Now;

            txtmadg.Enabled = true;
            txtmadg.Focus();
            load_docgia();
        }

        private void btntkiemtg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl từ các đk đưa vào biến
            string madg = txttimkiemmtg.Text.Trim();

            //b2:kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();

            //b3:Tạo đối tượng command để tiến hành tìm kiếm
            string sql = "select * From Docgia Where MaDG like @madg";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@madg", "%" + madg + "%");

            //b4:tạo đối tượng dataAdapter để lấy kết quả từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            //b5:tạo đối tượng dataTable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);

            cmd.Dispose();
            con.Close();

            //b6:đổ dl từ tb vào datagridview
            dtvdocgia.DataSource = tb;
            dtvdocgia.Refresh();

        }

        private void btnxtg_Click(object sender, EventArgs e)
        {
            string madg = txttimkiemmtg.Text.Trim();
            string tendg = txttimkiemmtg.Text.Trim();
            string gt = txttimkiemmtg.Text.Trim();
            string dt = txttimkiemmtg.Text.Trim();

            if (con.State == ConnectionState.Closed)
                con.Open();

            string sql =
                "SELECT * FROM Docgia WHERE " +
                "MaDG LIKE '%" + madg + "%' AND " +
                "TenDG LIKE N'%" + tendg + "%' AND " +
                "GioitinhDG LIKE N'%" + gt + "%' AND " +
                "DienthoaiDG LIKE '%" + dt + "%'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);

            con.Close();

            ExportExcel(tb, "DSDocgia");
        }

        private void ExportExcel(DataTable tb, string v)
        {
            // ===== Tạo các đối tượng Excel =====
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks;
            ex_cel.Sheets oSheets;
            ex_cel.Workbook oBook;
            ex_cel.Worksheet oSheet;

            // ===== Tạo mới một Excel Workbook =====
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;
            oBook = (ex_cel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (ex_cel.Worksheet)oSheets.get_Item(1);

            // ===== Tên sheet =====
            oSheet.Name = v;

            // ===== Tiêu đề =====
            ex_cel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH ĐỘC GIẢ";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // ===== Tiêu đề cột =====
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "MÃ ĐỘC GIẢ";
            cl1.ColumnWidth = 25.0;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "TÊN ĐỘC GIẢ";
            cl2.ColumnWidth = 35.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "NGÀY SINH";
            cl3.ColumnWidth = 20.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "GIỚI TÍNH";
            cl4.ColumnWidth = 15.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "ĐIỆN THOẠI";
            cl5.ColumnWidth = 20.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "EMAIL";
            cl6.ColumnWidth = 35.0;

            ex_cel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "ĐỊA CHỈ";
            cl7.ColumnWidth = 45.0;

            // ===== Header format =====
            ex_cel.Range rowHead = oSheet.get_Range("A3", "G3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // ===== Chuyển DataTable sang mảng =====
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];

            for (int r = 0; r < tb.Rows.Count; r++)
            {
                for (int c = 0; c < tb.Columns.Count; c++)
                {
                    if (tb.Rows[r][c] == DBNull.Value)
                        arr[r, c] = "";
                    else
                        arr[r, c] = tb.Rows[r][c];
                }
            }

            // ===== Đổ dữ liệu =====
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;

            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, columnStart];
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, columnEnd];
            ex_cel.Range range = oSheet.get_Range(c1, c2);

            range.Value2 = arr;

            // ===== Kẻ viền =====
            range.Borders.LineStyle = ex_cel.Constants.xlSolid;

            // ===== Căn giữa cột ngày sinh + giới tính =====
            oSheet.get_Range("C4", "D" + rowEnd)
                  .HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // ===== Định dạng ngày sinh =====
            ex_cel.Range cl_ngs = oSheet.get_Range("C" + rowStart, "C" + rowEnd);
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";
        }
    }
}
