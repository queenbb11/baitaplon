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
using ex_cel = Microsoft.Office.Interop.Excel;


namespace baitaplon
{
    public partial class Ql_theloai : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");
        public Ql_theloai()
        {
            InitializeComponent();
        }

        public void load_theloai()
        {
            
            string sql = "Select * from Theloai";
            Thuvien.hienthi_luoi(dgvTheloai, sql);
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ql_theloai_Load(object sender, EventArgs e)
        {
            //khi chyaj form sẽ chạy ra dữ liệu đã có
            load_theloai();

        }
        // chon tren luoi, nos day xuong phan nhap
        private void dgvDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaTL.Text = dgvTheloai.Rows[i].Cells[0].Value.ToString();
            txtTenTL.Text = dgvTheloai.Rows[i].Cells[1].Value.ToString();
            
            //thuoc tinh nao khong ddc sua, thì cho mờ đi
            txtMaTL.Enabled = false;
        }






        //ktr để khi thêm trùng mã tg thì thông báo lỗi
        private bool checktrungMatg(string mtl)
        {
            // kết nối db

            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3 tạo đối tượng comand để thực thi câu lệnh sql
            string sql = "Select count (*) from Theloai Where MaTL = '" + mtl + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar(); //ép kiểu
            //kiểm tra
            if (kq > 0) return true; // trùng mã
            else return false; //không trùng
        }


        //Lưu
        private void button1_Click(object sender, EventArgs e)
        {
            //b1 Lấy dữ liệu trên các điều kiển đưa vào biến
            string mtl = txtMaTL.Text.Trim();
            string tentl = txtTenTL.Text.Trim();
            // Kiểm tra không được để trống
            if (string.IsNullOrWhiteSpace(mtl))
            {
                MessageBox.Show("Mã thể loại không được để trống");
                txtMaTL.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tentl))
            {
                MessageBox.Show("Tên thể loại không được để trống");
                txtTenTL.Focus();
                return;
            }
            //kiểm tra trùng mã
            if (checktrungMatg(mtl))
            {
                txtMaTL.Focus();
                MessageBox.Show("Trùng mã thể loại");
                return; // thoát, không thực hiện các lệnh sau
            }
           
            string sql = "Insert into Theloai values('" + mtl + "',N'" + tentl + "' )";
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Thêm mới thành công");
            //gọi 
            load_theloai();
        }
        //Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
          
            string mtl = txtMaTL.Text.Trim();
            string tentl = txtTenTL.Text.Trim(); 
            
            string sql = "Update Theloai set TenTL = '" + mtl + "',N'" + tentl + "' Where MaTL = '" + mtl + "' ";
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Sửa thành công!!!");
            //gọi 
            load_theloai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
          
            string mtl = txtMaTL.Text;

            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa không?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.No)
                return;
           
            string sql = "Delete from Theloai Where MaTL = '" + mtl + "' ";
            Thuvien.ins_upd_del(sql);
            MessageBox.Show("Xóa thành công");
            load_theloai();
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mtl = txtMaTL.Text.Trim();
            string tentl = txtTenTL.Text.Trim();

            string sql = "SELECT * FROM Theloai " +
                         "WHERE MaTL LIKE N'%" + mtl + "%' " +
                         "or TenTL LIKE N'%" + tentl + "%'";
            //or là tìm 1 trong 2. and tìm theo 2 đk
            DataTable tb = Thuvien.Getdatatable(sql);
            // đổ dl vào lưới
            dgvTheloai.DataSource = tb;
            dgvTheloai.Refresh();
           
        }

        public void ExportExcel(DataTable tb, string sheetname)
        {
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbook oBook = oExcel.Workbooks.Add(Type.Missing);
            ex_cel.Worksheet oSheet = (ex_cel.Worksheet)oBook.Worksheets.get_Item(1);

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;

            oSheet.Name = sheetname;

            // ====== HEADER ======
            ex_cel.Range head = oSheet.get_Range("A1", "C1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH THỂ LOẠI";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = 16;
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

            // ====== COLUMN TITLES ======
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ THỂ LOẠI";
            cl2.ColumnWidth = 20;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN THỂ LOẠI";
            cl3.ColumnWidth = 35;

            ex_cel.Range rowHead = oSheet.get_Range("A3", "C3");
            rowHead.Font.Bold = true;
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            rowHead.Borders.LineStyle = ex_cel.XlLineStyle.xlContinuous;

            // ====== DATA ======
            int rowStart = 4;
            int colCount = 3; // STT + 2 cột dữ liệu

            object[,] arr = new object[tb.Rows.Count, colCount];

            for (int r = 0; r < tb.Rows.Count; r++)
            {
                // STT
                arr[r, 0] = r + 1;

                // MaTL, TenTL (2 cột đầu tiên của tb)
                arr[r, 1] = tb.Rows[r][0]?.ToString();
                arr[r, 2] = tb.Rows[r][1]?.ToString();
            }

            int rowEnd = rowStart + tb.Rows.Count - 1;

            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, 1]; // A4
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, colCount]; // C...
            ex_cel.Range range = oSheet.get_Range(c1, c2);

            range.Value2 = arr;
            range.Borders.LineStyle = ex_cel.XlLineStyle.xlContinuous;

            // căn giữa cột STT
            ex_cel.Range sttRange = oSheet.get_Range("A4", "A" + rowEnd);
            sttRange.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;

        }
        private void btnXuatfile_Click(object sender, EventArgs e)
        {
            string mtl = txtMaTL.Text.Trim();
            string tentl = txtTenTL.Text.Trim();

            string sql =
                "SELECT ROW_NUMBER() OVER (ORDER BY MaTL) AS STT, MaTL, TenTL " +
                "FROM Theloai " +
                "WHERE MaTL LIKE N'%" + mtl + "%' " +
                "AND TenTL LIKE N'%" + tentl + "%'";

            DataTable tb = Thuvien.Getdatatable(sql);
            ExportExcel(tb, "DSTheloai");
        }

        private void dgvTheloai_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTheloai.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }
    }
}
