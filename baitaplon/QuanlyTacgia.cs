using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using ex_cel = Microsoft.Office.Interop.Excel;



namespace baitaplon
{
    public partial class QuanlyTacgia : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bai_tap_lon;Integrated Security=True");
        public QuanlyTacgia()
        {
            InitializeComponent();
        }

        private void load_tacgia()
        {
            try
            {
                //b1:kết nối DB
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //b2:tạo đối tượng commad để thực hiện câu lệnh sql
                String sql = "Select * from Tacgia";
                SqlCommand cmd = new SqlCommand(sql, con);
                //b3:tạo đối tượng dataAdapter để lấy kq từ cmd
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                //b4:tạo đối tượng dataTable để lấy dl từ da
                DataTable tb = new DataTable();
                da.Fill(tb);
                cmd.Dispose();
                //b5:đổ dl từ datatable vào dataGridview
                dtvtacgia.DataSource = tb;
                dtvtacgia.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tác giả: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private bool checktrungMatg(string mtg)
        {
            //kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            //tạo đối tượng command để thực thi câu lệnh sql
            string sql = "select count(*) from Tacgia Where MaTG=@mtg";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mtg", mtg);
            int kq = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            if (kq > 0) return true;//trùng mã tác giả
            else return false;//không trùng mã tác giả
        }

        private void btnluutg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl trên các đk đưa trên
            string mtg = txtmatg.Text.Trim();
            string ht = txttentg.Text.Trim();
            DateTime ngs = dtTacgia.Value;
            string gt = txtgioitinhtg.Text;
            string dt = txtdthoaitg.Text.Trim();
            string dc = txtdchitg.Text.Trim();


            // không được bỏ trông mã và tên tác giả
            if (string.IsNullOrWhiteSpace(mtg))
            {
                MessageBox.Show("Vui lòng nhập mã tác giả!");
                txtmatg.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ht))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả!");
                txttentg.Focus();
                return;
            }
            //kiểm tra trùng mã tác giả
            if (checktrungMatg(mtg))
            {
                txtmatg.Focus();
                MessageBox.Show("Trùng mã tác giả");
                return;
            }
            //b2:kết nối db

            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:tạo đối tượng commad để thực thi câu lệnh sql
            string sql = "Insert Tacgia values(@mtg, @ht, @ngs, @gt, @dt, @dc)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mtg", mtg);
            cmd.Parameters.AddWithValue("@ht", ht);
            cmd.Parameters.AddWithValue("@ngs", ngs);
            cmd.Parameters.AddWithValue("@gt", gt);
            cmd.Parameters.AddWithValue("@dt", dt);
            cmd.Parameters.AddWithValue("@dc", dc);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (con.State == ConnectionState.Open) con.Close();
            MessageBox.Show("Thêm mới thành công!");
            load_tacgia();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsuatg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl trên các đk đưa trên
            string mtg = txtmatg.Text.Trim();
            string ht = txttentg.Text.Trim();
            DateTime ngs = dtTacgia.Value;
            string gt = txtgioitinhtg.Text;
            string dt = txtdthoaitg.Text.Trim();
            string dc = txtdchitg.Text.Trim();
            //b2:kết nối db

            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:tạo đối tượng commad để thực thi câu lệnh sql
            string sql = "Update Tacgia set TenTG=@ht,NgaysinhTG=@ngs,DiachiTG=@dc,GioitinhTG=@gt, DienthoaiTG=@dt where MaTG=@mtg";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ht", ht);
            cmd.Parameters.AddWithValue("@ngs", ngs);
            cmd.Parameters.AddWithValue("@dc", dc);
            cmd.Parameters.AddWithValue("@gt", gt);
            cmd.Parameters.AddWithValue("@dt", dt);
            cmd.Parameters.AddWithValue("@mtg", mtg);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Sửa thành công!");
            load_tacgia();
        }

        private void btnxoatg_Click(object sender, EventArgs e)
        {
            //b1:lấy mã tác giả đưa vào biến
            string mtg = txtmatg.Text;
            DialogResult kq = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            //b2:kết nối DB
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:tạo đối tượng command để thực hiện xóa theo mã tác giả
            string sql = "Delete from Tacgia where MaTG=@mtg";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mtg", mtg);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Xóa thành công!");
            load_tacgia();
        }

        private void btntkiemtg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl từ các đk đưa vào biến
            string mtg = txttimkiemmtg.Text.Trim();

            //b2:kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:Tạo đối tượng command để tiến hành tìm kiếm
            string sql = "select * From Tacgia Where MaTG like @mtg";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mtg", "%" + mtg + "%");
            //b4:tạo đối tượng dataAdapter để lấy kết quả từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //b5:tạo đối tượng dataTable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            //b6:đổ dl từ tb vào datagridview
            dtvtacgia.DataSource = tb;
            dtvtacgia.Refresh();
        }

        private void btnxtg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl từ các đk đưa vào biến
            string mtg = txttimkiemmtg.Text.Trim();

            //b2:kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:Tạo đối tượng command để tiến hành tìm kiếm
            string sql = "select ROW_NUMBER() OVER(ORDER BY MaTG) STT,* From Tacgia Where MaTG like @mtg ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mtg", "%" + mtg + "%");
            //b4:tạo đối tượng dataAdapter để lấy kết quả từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //b5:tạo đối tượng dataTable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "DSTacgia");
        }

        private void ExportExcel(DataTable tb, string v)
        {
            //Tạo các đối tượng Excel

            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks;
            ex_cel.Sheets oSheets;
            ex_cel.Workbook oBook;
            ex_cel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (ex_cel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (ex_cel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = v;
            // Tạo phần đầu nếu muốn
            ex_cel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH TÁC GIẢ";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ TÁC GIẢ";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "HỌ VÀ TÊN";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "NGÀY SINH";
            cl4.ColumnWidth = 25.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "GIỚI TÍNH";
            cl5.ColumnWidth = 15.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "ĐIỆN THOẠI";
            cl6.ColumnWidth = 20.0;
            //ex_cel.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";


            ex_cel.Range cl8 = oSheet.get_Range("G3", "G3");
            cl8.Value2 = "ĐỊA CHỈ";
            cl8.ColumnWidth = 45.0;

            ex_cel.Range rowHead = oSheet.get_Range("A3", "G3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    if (dr[c] == DBNull.Value)
                        arr[r, c] = "";
                    
                    else
                        arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            ex_cel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền
            range.Borders.LineStyle = ex_cel.Constants.xlSolid;
            // Căn giữa cột STT
            ex_cel.Range c3 = (ex_cel.Range)oSheet.Cells[rowEnd, columnStart];
            ex_cel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            //Định dạng ngày sinh
            ex_cel.Range cl_ngs = oSheet.get_Range("D" + rowStart, "D" + rowEnd);
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";

        }

        private void dtvtacgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            var row = dtvtacgia.Rows[i];
            txtmatg.Text = row.Cells.Count > 0 ? row.Cells[0].Value?.ToString() ?? "" : "";
            txttentg.Text = row.Cells.Count > 1 ? row.Cells[1].Value?.ToString() ?? "" : "";

            if (row.Cells.Count > 2 && row.Cells[2].Value != null && DateTime.TryParse(row.Cells[2].Value.ToString(), out DateTime dtVal))
                dtTacgia.Value = dtVal;

            txtgioitinhtg.Text = row.Cells.Count > 3 ? row.Cells[3].Value?.ToString() ?? "" : "";
            txtdthoaitg.Text = row.Cells.Count > 4 ? row.Cells[4].Value?.ToString() ?? "" : "";
            txtdchitg.Text = row.Cells.Count > 5 ? row.Cells[5].Value?.ToString() ?? "" : "";
            txtmatg.Enabled = false;
        }

        private void QuanlyTacgia_Load(object sender, EventArgs e)
        {
            try
            {
                // Nạp dữ liệu cho combobox giới tính
                txtgioitinhtg.Items.Clear();
                txtgioitinhtg.Items.Add("Nam");
                txtgioitinhtg.Items.Add("Nữ");

                txtgioitinhtg.SelectedIndex = -1; // không chọn sẵn

                load_tacgia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load form: " + ex.Message);
            }
        }

        private void txtmatg_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu nhập
            txtmatg.Clear();
            txttentg.Clear();
            txtgioitinhtg.Text = "";
            txtdthoaitg.Clear();
            txtdchitg.Clear();

            // Reset ngày sinh về hôm nay
            dtTacgia.Value = DateTime.Now;

            // Xóa ô tìm kiếm (nếu có)
            txttimkiemmtg.Clear();

            // Load lại danh sách tác giả
            load_tacgia();

            // Đưa con trỏ về ô Mã tác giả
            txtmatg.Focus();
            txtmatg.Enabled = true;
        }
    }

}