namespace baitaplon
{
    partial class QL_Trangthaisach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenTrangThai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvQLTrangThaiSach = new System.Windows.Forms.DataGridView();
            this.MaS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tentrangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.grbQLTrangThaiSach = new System.Windows.Forms.GroupBox();
            this.btnNhapFile = new System.Windows.Forms.Button();
            this.cbbMaSach = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTrangThaiSach)).BeginInit();
            this.grbQLTrangThaiSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(72, 332);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(460, 26);
            this.txtTimKiem.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(550, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(324, 25);
            this.label9.TabIndex = 53;
            this.label9.Text = "QUẢN LÝ TRẠNG THÁI SÁCH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(866, 662);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(857, 652);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sách";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(462, 436);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 55);
            this.btnXoa.TabIndex = 59;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(292, 436);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 55);
            this.btnSua.TabIndex = 58;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(112, 436);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(92, 55);
            this.btnLuu.TabIndex = 57;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên trạng thái";
            // 
            // txtTenTrangThai
            // 
            this.txtTenTrangThai.Location = new System.Drawing.Point(640, 54);
            this.txtTenTrangThai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenTrangThai.Name = "txtTenTrangThai";
            this.txtTenTrangThai.Size = new System.Drawing.Size(212, 26);
            this.txtTenTrangThai.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(144, 121);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(589, 26);
            this.txtMoTa.TabIndex = 10;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(887, 436);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 55);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(573, 319);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(92, 55);
            this.btnTimKiem.TabIndex = 62;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvQLTrangThaiSach
            // 
            this.dgvQLTrangThaiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLTrangThaiSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaS,
            this.Tentrangthai,
            this.Mota});
            this.dgvQLTrangThaiSach.Location = new System.Drawing.Point(54, 518);
            this.dgvQLTrangThaiSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvQLTrangThaiSach.Name = "dgvQLTrangThaiSach";
            this.dgvQLTrangThaiSach.RowHeadersWidth = 62;
            this.dgvQLTrangThaiSach.RowTemplate.Height = 28;
            this.dgvQLTrangThaiSach.Size = new System.Drawing.Size(937, 177);
            this.dgvQLTrangThaiSach.TabIndex = 61;
            this.dgvQLTrangThaiSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLTrangThaiSach_CellClick);
            this.dgvQLTrangThaiSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLTrangThaiSach_CellContentClick);
            // 
            // MaS
            // 
            this.MaS.DataPropertyName = "MaS";
            this.MaS.HeaderText = "Mã sách";
            this.MaS.MinimumWidth = 6;
            this.MaS.Name = "MaS";
            this.MaS.Width = 125;
            // 
            // Tentrangthai
            // 
            this.Tentrangthai.DataPropertyName = "Tentrangthai";
            this.Tentrangthai.HeaderText = "Tên trạng thái";
            this.Tentrangthai.MinimumWidth = 6;
            this.Tentrangthai.Name = "Tentrangthai";
            this.Tentrangthai.Width = 125;
            // 
            // Mota
            // 
            this.Mota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mota.DataPropertyName = "Mota";
            this.Mota.HeaderText = "Mô tả";
            this.Mota.MinimumWidth = 6;
            this.Mota.Name = "Mota";
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFile.Location = new System.Drawing.Point(750, 436);
            this.btnXuatFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(92, 55);
            this.btnXuatFile.TabIndex = 60;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            // 
            // grbQLTrangThaiSach
            // 
            this.grbQLTrangThaiSach.Controls.Add(this.cbbMaSach);
            this.grbQLTrangThaiSach.Controls.Add(this.label1);
            this.grbQLTrangThaiSach.Controls.Add(this.label2);
            this.grbQLTrangThaiSach.Controls.Add(this.txtTenTrangThai);
            this.grbQLTrangThaiSach.Controls.Add(this.label6);
            this.grbQLTrangThaiSach.Controls.Add(this.txtMoTa);
            this.grbQLTrangThaiSach.Location = new System.Drawing.Point(54, 73);
            this.grbQLTrangThaiSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbQLTrangThaiSach.Name = "grbQLTrangThaiSach";
            this.grbQLTrangThaiSach.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbQLTrangThaiSach.Size = new System.Drawing.Size(937, 198);
            this.grbQLTrangThaiSach.TabIndex = 56;
            this.grbQLTrangThaiSach.TabStop = false;
            this.grbQLTrangThaiSach.Text = "Trạng thái sách";
            // 
            // btnNhapFile
            // 
            this.btnNhapFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapFile.Location = new System.Drawing.Point(599, 436);
            this.btnNhapFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNhapFile.Name = "btnNhapFile";
            this.btnNhapFile.Size = new System.Drawing.Size(92, 55);
            this.btnNhapFile.TabIndex = 64;
            this.btnNhapFile.Text = "Nhập file";
            this.btnNhapFile.UseVisualStyleBackColor = true;
            this.btnNhapFile.Click += new System.EventHandler(this.btnNhapFile_Click);
            // 
            // cbbMaSach
            // 
            this.cbbMaSach.FormattingEnabled = true;
            this.cbbMaSach.Location = new System.Drawing.Point(145, 63);
            this.cbbMaSach.Name = "cbbMaSach";
            this.cbbMaSach.Size = new System.Drawing.Size(233, 28);
            this.cbbMaSach.TabIndex = 15;
            // 
            // QL_Trangthaisach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 718);
            this.Controls.Add(this.btnNhapFile);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvQLTrangThaiSach);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.grbQLTrangThaiSach);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QL_Trangthaisach";
            this.Text = "QL_Trangthaisach";
            this.Load += new System.EventHandler(this.QL_Trangthaisach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTrangThaiSach)).EndInit();
            this.grbQLTrangThaiSach.ResumeLayout(false);
            this.grbQLTrangThaiSach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenTrangThai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvQLTrangThaiSach;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.GroupBox grbQLTrangThaiSach;
        private System.Windows.Forms.Button btnNhapFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tentrangthai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mota;
        private System.Windows.Forms.ComboBox cbbMaSach;
    }
}