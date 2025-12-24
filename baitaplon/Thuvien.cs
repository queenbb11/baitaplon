using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    internal class Thuvien
    {
        public static
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bai_tap_lon;Integrated Security=True");
        public static void hienthi_luoi(DataGridView dgv, string sql)
        {
            //kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            // tạo đối tượng command để thực hiện truy vấn

            SqlCommand cmd = new SqlCommand(sql, con);
            //tạo đối tượng dataAdapter để lấy kq từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //tạo đối tượng datatable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            dgv.DataSource = tb;
            dgv.Refresh();
        }
        //đổ dl vào combobox
        public static void hienthicbo(ComboBox cbo, string sql, string ma, string ten)
        {
            //kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            // tạo đối tượng command để thực hiện truy vấn
            SqlCommand cmd = new SqlCommand(sql, con);
            //tạo đối tượng dataAdapter để lấy kq từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //tạo đối tượng datatable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            //thêm 1 dòng vào vị trí đầu tiwwn của bảng
            DataRow r = tb.NewRow();
            r[ma] = "";
            r[ten] = "---Chọn giá trị---";
            tb.Rows.InsertAt(r, 0);
            //đổ dữ liệu vào combobox
            cbo.DataSource = tb;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
        }
        //thêm, sửa xóa
        public static void ins_upd_del(string sql)
        {
            //kết nối db
            if (con.State == ConnectionState.Closed)
                con.Open();
            // tạo đối tượng command để thực hiện truy vấn
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        // hàm lấy dữ liêu từ bảng
        public static DataTable Getdatatable(string sql)
        {
            if (con.State == ConnectionState.Closed) con.Open();

            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable tb = new DataTable();
                da.Fill(tb);
                con.Close();
                return tb;
            }
        }

    }
}
