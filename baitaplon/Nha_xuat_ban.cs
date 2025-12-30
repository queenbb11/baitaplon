using Microsoft.Office.Interop.Excel;
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
using DataTable = System.Data.DataTable;
using ex_cel = Microsoft.Office.Interop.Excel;


namespace baitaplon
{
    public partial class Nha_xuat_ban : Form
    {
        // BƯỚC ĐẦU TIÊN VÀO LÀ KẾT NỐI VỚI CSDL
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bai_tap_lon;Integrated Security=True");
        public Nha_xuat_ban()
        {
            InitializeComponent();
        }

        // BƯỚC 2: TẠO HÀM LOAD NHÀ XUẤT BẢN
        private void load_nxb()
        {
            try
            {
                //b1:kết nối DB
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //b2:tạo đối tượng commad để thực hiện câu lệnh sql
                String sql = "Select * from Nhaxuatban";
                SqlCommand cmd = new SqlCommand(sql, con);
                //b3:tạo đối tượng dataAdapter để lấy kq từ cmd
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                //b4:tạo đối tượng dataTable để lấy dl từ da
                DataTable tb = new DataTable();
                da.Fill(tb);
                cmd.Dispose();
                //b5:đổ dl từ datatable vào dataGridview
                dtvnxb.DataSource = tb;
                dtvnxb.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà xuất bản: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        // BƯỚC NÀY LÀM LÚC NÀO CŨNG ĐƯỢC, NÓ CHECK KHÔNG ĐƯỢC TRÙNG MÃ NÀO ĐÓ
        private bool checktrungManxb(string mnxb)
        {
            //kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            //tạo đối tượng command để thực thi câu lệnh sql
            string sql = "select count(*) from Nhaxuatban Where MaNXB=@mnxb";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mnxb", mnxb);
            int kq = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            if (kq > 0) return true;//trùng mã tác giả
            else return false;//không trùng mã tác giả
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        // BƯỚC 4: TẠO SỰ KIỆN CHO NÚT LƯU
        private void btnluutg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl trên các đk đưa trên
            string mnxb = txtmanxb.Text.Trim();
            string ht = txttennxb.Text.Trim();
            string dt = txtdthoainxb.Text.Trim();
            string email = txtemailnxb.Text.Trim();
            string dc = txtdchinxb.Text.Trim();


            // không được bỏ trông mã và tên tác giả
            if (string.IsNullOrWhiteSpace(mnxb))
            {
                MessageBox.Show("Vui lòng nhập mã nhà xuất bản!");
                txtmanxb.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ht))
            {
                MessageBox.Show("Vui lòng nhập tên nhà xuất bản!");
                txtmanxb.Focus();
                return;
            }
            //kiểm tra trùng mã tác giả
            if (checktrungManxb(mnxb))
            {
                txtmanxb.Focus();
                MessageBox.Show("Trùng mã nhà xuất bản");
                return;
            }
            //b2:kết nối db

            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:tạo đối tượng commad để thực thi câu lệnh sql
            string sql = "Insert Nhaxuatban values(@mtg, @ht, @email, @dt, @dc)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mtg", mnxb);
            cmd.Parameters.AddWithValue("@ht", ht);
            cmd.Parameters.AddWithValue("@dt", dt);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@dc", dc);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (con.State == ConnectionState.Open) con.Close();
            MessageBox.Show("Thêm mới thành công!");
            load_nxb();
        }

        // BƯỚC 5: TẠO SỰ KIỆN CHO NÚT SỬA
        private void btnsuatg_Click_1(object sender, EventArgs e)
        {
            //b1:lấy dl trên các đk đưa trên
            string mnxb = txtmanxb.Text.Trim();
            string ht = txttennxb.Text.Trim();
            string dt = txtdthoainxb.Text.Trim();
            string email = txtemailnxb.Text.Trim();
            string dc = txtdchinxb.Text.Trim();
            //b2:kết nối db

            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:tạo đối tượng commad để thực thi câu lệnh sql
            string sql = "Update Nhaxuatban set TenNXB=@ht,DiachiNXB=@dc,EmailNXB =@email, DienthoaiNXB=@dt where MaNXB=@mnxb";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ht", ht);
            cmd.Parameters.AddWithValue("@dc", dc);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@dt", dt);
            cmd.Parameters.AddWithValue("@mnxb", mnxb);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Sửa thành công!");
            load_nxb();
        }


        // BƯỚC 6: TẠO SỰ KIỆN CHO NÚT XÓA
        private void btnxoatg_Click(object sender, EventArgs e)
        {
            //b1:lấy mã tác giả đưa vào biến
            string mnxb = txtmanxb.Text;
            DialogResult kq = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            //b2:kết nối DB
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:tạo đối tượng command để thực hiện xóa theo mã tác giả
            string sql = "Delete from Nhaxuatban where MaNXB=@mnxb";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mnxb", mnxb);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Xóa thành công!");
            load_nxb();
        }


        //BƯỚC 7: TẠO SỰ KIỆN CHO NÚT TÌM KIẾM
        private void btntkiemtg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl từ các đk đưa vào biến
            string mnxb= txttimkiemnxb.Text.Trim();

            //b2:kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:Tạo đối tượng command để tiến hành tìm kiếm
            string sql = "select * From Nhaxuatban Where MaNXB like @mnxb";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mnxb", "%" + mnxb + "%");
            //b4:tạo đối tượng dataAdapter để lấy kết quả từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //b5:tạo đối tượng dataTable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            //b6:đổ dl từ tb vào datagridview
            dtvnxb.DataSource = tb;
            dtvnxb.Refresh();
        }



        // BƯỚC 8: TẠO SỰ KIỆN CHO NÚT XUẤT FILE EXCEL
        private void btnxtg_Click(object sender, EventArgs e)
        {
            //b1:lấy dl từ các đk đưa vào biến
            string mnxb= txttimkiemnxb.Text.Trim();

            //b2:kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3:Tạo đối tượng command để tiến hành tìm kiếm
            string sql = "select ROW_NUMBER() OVER(ORDER BY MaNXB) STT,* From Nhaxuatban Where MaNXB like @mnxb ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mnxb", "%" + mnxb + "%");
            //b4:tạo đối tượng dataAdapter để lấy kết quả từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //b5:tạo đối tượng dataTable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "DSNhaXuatBan");
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
            ex_cel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH NHÀ XUẤT BẢN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ NHÀ XUẤT BẢN";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "HỌ VÀ TÊN";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "ĐIỆN THOẠI";
            cl4.ColumnWidth = 25.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "EMAIL";
            cl5.ColumnWidth = 15.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "ĐỊA CHỈ";
            cl6.ColumnWidth = 20.0;
            //ex_cel.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";


            ex_cel.Range rowHead = oSheet.get_Range("A3", "F3");
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
            //ex_cel.Range cl_ngs = oSheet.get_Range("D" + rowStart, "D" + rowEnd);
            //cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";
        }

        //BƯỚC 9: TẠO SỰ KIỆN CHO CELL CLICK TRONG DATAGRIDVIEW
        private void dtvnxb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            var row = dtvnxb.Rows[i];
            txtmanxb.Text = row.Cells.Count > 0 ? row.Cells[0].Value?.ToString() ?? "" : "";
            txttennxb.Text = row.Cells.Count > 1 ? row.Cells[1].Value?.ToString() ?? "" : "";
            txtdthoainxb.Text = row.Cells.Count > 2 ? row.Cells[2].Value?.ToString() ?? "" : "";
            txtemailnxb.Text = row.Cells.Count > 3 ? row.Cells[3].Value?.ToString() ?? "" : "";
            txtdchinxb.Text = row.Cells.Count > 4 ? row.Cells[4].Value?.ToString() ?? "" : "";
            txtmanxb.Enabled = false;
        }


        // BƯỚC 10: TẠO SỰ KIỆN CHO NÚT RESET
        private void btnreset_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu nhập
            txtmanxb.Clear();
            txttennxb.Clear();
            txtdthoainxb.Clear();
            txtemailnxb.Clear();
            txtdchinxb.Clear();

            // Xóa ô tìm kiếm (nếu có)
            txttimkiemnxb.Clear();

            // Load lại danh sách tác giả
            load_nxb();

            // Đưa con trỏ về ô Mã tác giả
            txtmanxb.Focus();
            txtmanxb.Enabled = true;
        }

        private void dtvnxb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Nha_xuat_ban_Load_1(object sender, EventArgs e)
        {
            load_nxb();
        }
    }
}
