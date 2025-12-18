using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
// Đặt tên ngắn gọn cho Excel để dễ gọi
using Excel = Microsoft.Office.Interop.Excel;

namespace Quanlythuvien
{
    public partial class Quanly_Nhanvien : Form
    {
        // 1. CHUỖI KẾT NỐI (Đã sửa đúng cú pháp)
        // Lưu ý: Kiểm tra tên Database là 'bai_tap_lon' hay 'Quanly_nhanvien' để sửa vào đây nhé
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True;TrustServerCertificate=True");

        public Quanly_Nhanvien()
        {
            InitializeComponent();
        }

        // --- PHẦN 1: CÁC HÀM DÙNG CHUNG ---

        // Hàm mở kết nối an toàn
        private void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        // Hàm đóng kết nối an toàn
        private void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        // Hàm tải dữ liệu lên bảng
        public void LoadData()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b2: tạo đối tượng compand để thực hiện câu lệnh sql
            string sql = "Select * from Thongtin_nhanvien";
            SqlCommand cmd = new SqlCommand(sql, con);
            //b3 tạo đối tượng dataAdapter để lấy kq từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //b4 tạo đối tượng datatable  để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close(); // ngắt kết nối
            //b5 : đổ dl từ  datatable vào dgvDanhsach
            dgvDanhSach.DataSource = tb;
            dgvDanhSach.Refresh();
        }

        // Hàm xóa trắng các ô nhập liệu và Mở khóa nhập Mã
        private void ResetInput()
        {
            txtMnv2.Text = "";
            txtTnv2.Text = "";
            txtDt2.Text = "";
            txtEmail.Text = "";
            txtDc.Text = "";

            // Đặt lại ngày hiện tại
            dateNs.Value = DateTime.Now;

            // Đặt lại combobox
            cbGt2.SelectedIndex = -1;
            cbGt2.Text = "";

            // QUAN TRỌNG: Mở lại ô Mã nhân viên để nhập mới
            txtMnv2.Enabled = true;
            txtMnv2.Focus();
        }

        // --- PHẦN 2: CÁC SỰ KIỆN (EVENTS) ---

        private void Quanly_Nhanvien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Sự kiện: Click vào bảng để đổ dữ liệu lên trên
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Nếu click vào dòng tiêu đề (dòng -1) thì bỏ qua, không làm gì cả
            if (e.RowIndex < 0) return;

            try
            {
                // 2. Lấy dòng hiện tại đang chọn
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

                // 3. Đổ dữ liệu từ bảng lên các ô nhập (Dùng đúng TÊN CỘT trong SQL)
                txtMnv2.Text = row.Cells["Manhanvien"].Value.ToString();
                txtTnv2.Text = row.Cells["Tennhanvien"].Value.ToString();

                // Xử lý ComboBox Giới tính (Tránh lỗi nếu null)
                if (row.Cells["Gioitinh"].Value != null)
                    cbGt2.Text = row.Cells["Gioitinh"].Value.ToString();

                // Xử lý Ngày sinh (Quan trọng: Kiểm tra khác null mới convert)
                if (row.Cells["Ngaysinh"].Value != DBNull.Value)
                {
                    dateNs.Value = Convert.ToDateTime(row.Cells["Ngaysinh"].Value);
                }
                else
                {
                    dateNs.Value = DateTime.Now; // Nếu không có ngày sinh thì để mặc định hôm nay
                }

                // Xử lý Điện thoại
                if (row.Cells["Dienthoai"].Value != null)
                    txtDt2.Text = row.Cells["Dienthoai"].Value.ToString();

                // Xử lý Email (Lưu ý: Trong Database bạn đặt tên cột là Emai hay Email?)
                // Mình để theo code nút sửa của bạn là 'Emai'
                if (row.Cells["Emai"].Value != null)
                    txtEmail.Text = row.Cells["Emai"].Value.ToString();

                // Xử lý Địa chỉ
                if (row.Cells["Diachi"].Value != null)
                    txtDc.Text = row.Cells["Diachi"].Value.ToString();

                // 4. QUAN TRỌNG: Khóa ô Mã nhân viên lại
                // Khi sửa, tuyệt đối không cho sửa Mã (vì mã là khóa chính để tìm kiếm)
                txtMnv2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        
        }

        // Nút LƯU (THÊM MỚI)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMnv2.Text) || string.IsNullOrWhiteSpace(txtTnv2.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên nhân viên!");
                return;
            }

            // Nếu ô Mã đang bị khóa (tức là đang chọn chế độ Sửa), bấm Lưu sẽ nhắc nhở
            if (txtMnv2.Enabled == false)
            {
                MessageBox.Show("Bạn đang chọn một nhân viên cũ. Hãy bấm nút 'Reset' hoặc xóa trắng ô Mã để thêm người mới!");
                ResetInput();
                return;
            }

            try
            {
                OpenConnection();

                // 2. Câu lệnh SQL chuẩn (Dùng @ThamSo)
                string sql = "INSERT INTO Thongtin_nhanvien (Manhanvien, Tennhanvien, Ngaysinh, Gioitinh, Dienthoai, Emai, Diachi) " +
                             "VALUES (@Ma, @Ten, @NgaySinh, @GioiTinh, @DienThoai, @Email, @DiaChi)";

                SqlCommand cmd = new SqlCommand(sql, con);

                // 3. Truyền tham số (An toàn, không lỗi ngày tháng)
                cmd.Parameters.AddWithValue("@Ma", txtMnv2.Text.Trim());
                cmd.Parameters.AddWithValue("@Ten", txtTnv2.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dateNs.Value);

                // Xử lý Combobox
                if (cbGt2.SelectedItem == null)
                    cmd.Parameters.AddWithValue("@GioiTinh", cbGt2.Text);
                else
                    cmd.Parameters.AddWithValue("@GioiTinh", cbGt2.SelectedItem.ToString());

                // Xử lý số điện thoại (Nếu để trống thì lưu NULL)
                if (string.IsNullOrEmpty(txtDt2.Text))
                    cmd.Parameters.AddWithValue("@DienThoai", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DienThoai", txtDt2.Text.Trim());

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txtDc.Text.Trim());

                // 4. Thực thi
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công!");
                LoadData(); // Load lại bảng
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính
                    MessageBox.Show("Mã nhân viên này đã tồn tại!");
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Nút SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            //b1 Lấy dữ liệu trên các điều kiển đưa vào biến
            string mnv = txtMnv2.Text.Trim();
            string ht = txtTnv2.Text.Trim();
            string ns = dateNs.Value.ToString("yyyy-MM-dd");

            string gt = cbGt2.Text;
            string dt = txtDt2.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDc.Text.Trim();
            //b2: kết nối db

            if (con.State == ConnectionState.Closed)
                con.Open();

            //b3 tạo đối tượng comand để thực thi câu lệnh sql
            //3.1

            string sql = "Update Thongtin_nhanvien set Tennhanvien = N'" + ht + "',Ngaysinh= '" + ns + "', Gioitinh = N'" + gt + "', Dienthoai = '" + dt + "',Emai='" + mail + "',Diachi = N'" + dc + "' Where Manhanvien = '" + mnv + "' ";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            //giai phong cm, ngat ket noi
            cmd.Dispose();
            con.Close();
            MessageBox.Show("Sua thanh cong");

            //gọi 
            LoadData();
            
        }

        // Nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mnv = txtMnv2.Text;

            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa không?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.No)
                return;
            // b2 ket noi db
            if (con.State == ConnectionState.Closed)
                con.Open();
            //b3: tao doi tuong command de thuc hien xoa theo ma tac gia
            string sql = "Delete from Thongtin_nhanvien Where Manhanvien = '" + mnv + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            //giai phong
            cmd.Dispose();
            // ngat ket noi
            con.Close();

            MessageBox.Show("Xóa thành công");
            LoadData();
        }

        // Nút TÌM KIẾM
        private void btnTk_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();

                // Tìm kiếm gần đúng theo nhiều điều kiện
                string sql = "SELECT * FROM Thongtin_nhanvien WHERE " +
                             "Manhanvien LIKE @Ma AND " +
                             "Tennhanvien LIKE @Ten AND " +
                             "Dienthoai LIKE @DT";

                // Nếu có chọn giới tính thì thêm điều kiện
                if (!string.IsNullOrEmpty(cbGt1.Text))
                {
                    sql += " AND Gioitinh LIKE @GT";
                }

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", "%" + txtMnv1.Text.Trim() + "%");
                cmd.Parameters.AddWithValue("@Ten", "%" + txtTnv1.Text.Trim() + "%");
                cmd.Parameters.AddWithValue("@DT", "%" + txtDt1.Text.Trim() + "%");

                if (!string.IsNullOrEmpty(cbGt1.Text))
                    cmd.Parameters.AddWithValue("@GT", "%" + cbGt1.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDanhSach.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Nút XUẤT EXCEL
        private void btnXf_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu đang hiển thị trên lưới (kể cả khi đang tìm kiếm)
            DataTable dt = (DataTable)dgvDanhSach.DataSource;

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            ExportExcel(dt, "DS_NhanVien");
        }

        // Hàm xử lý Excel
        public void ExportExcel(DataTable tb, string sheetname)
        {
            Excel.Application oExcel = null;
            Excel.Workbook oBook = null;
            Excel.Worksheet oSheet = null;

            try
            {
                oExcel = new Excel.Application();
                oExcel.Visible = false;
                oExcel.DisplayAlerts = false;

                oBook = oExcel.Workbooks.Add(Type.Missing);
                oSheet = (Excel.Worksheet)oBook.ActiveSheet;
                oSheet.Name = sheetname;

                // 1. Tạo Tiêu Đề
                Excel.Range head = oSheet.get_Range("A1", "H1");
                head.MergeCells = true;
                head.Value2 = "DANH SÁCH NHÂN VIÊN";
                head.Font.Bold = true;
                head.Font.Size = 16;
                head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // 2. Tạo Header Cột
                string[] headers = { "STT", "Mã NV", "Họ Tên", "Ngày Sinh", "Giới Tính", "Điện Thoại", "Email", "Địa Chỉ" };
                for (int i = 0; i < headers.Length; i++)
                {
                    oSheet.Cells[3, i + 1] = headers[i];
                }

                // 3. Đổ dữ liệu
                object[,] arr = new object[tb.Rows.Count, 8];

                for (int r = 0; r < tb.Rows.Count; r++)
                {
                    DataRow dr = tb.Rows[r];
                    arr[r, 0] = r + 1; // STT
                    arr[r, 1] = dr["Manhanvien"];
                    arr[r, 2] = dr["Tennhanvien"];

                    if (dr["Ngaysinh"] != DBNull.Value)
                        arr[r, 3] = Convert.ToDateTime(dr["Ngaysinh"]).ToString("dd/MM/yyyy");

                    arr[r, 4] = dr["Gioitinh"];
                    arr[r, 5] = "'" + dr["Dienthoai"]; // Thêm dấu ' để giữ số 0 đầu
                    arr[r, 6] = dr["Emai"]; // Lấy đúng tên cột Emai trong DB
                    arr[r, 7] = dr["Diachi"];
                }

                // Ghi mảng vào Excel (Nhanh hơn ghi từng ô)
                int rowStart = 4;
                int rowEnd = rowStart + tb.Rows.Count - 1;
                Excel.Range c1 = (Excel.Range)oSheet.Cells[rowStart, 1];
                Excel.Range c2 = (Excel.Range)oSheet.Cells[rowEnd, 8];
                Excel.Range range = oSheet.get_Range(c1, c2);
                range.Value2 = arr;

                // Kẻ khung
                range.Borders.LineStyle = Excel.Constants.xlSolid;
                oSheet.Columns.AutoFit();

                oExcel.Visible = true; // Hiện Excel lên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
            }
            finally
            {
                // Giải phóng bộ nhớ để không treo Excel
                if (oBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                if (oExcel != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        // Các sự kiện rác (để trống để tránh lỗi Designer)
        private void label11_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvDanhSach_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Quanly_Nhanvien
        //    // 
        //    this.ClientSize = new System.Drawing.Size(1083, 528);
        //    this.Name = "Quanly_Nhanvien";
        //    this.Load += new System.EventHandler(this.Quanly_Nhanvien_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void Quanly_Nhanvien_Load_1(object sender, EventArgs e)
        {

        }
    }
}

