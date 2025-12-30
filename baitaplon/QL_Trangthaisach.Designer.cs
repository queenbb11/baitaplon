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
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvQLTrangThaiSach = new System.Windows.Forms.DataGridView();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.grbQLTrangThaiSach = new System.Windows.Forms.GroupBox();
            this.btnNhapFile = new System.Windows.Forms.Button();
            this.MaS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tentrangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoaNhieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTrangThaiSach)).BeginInit();
            this.grbQLTrangThaiSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(64, 266);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(409, 22);
            this.txtTimKiem.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(489, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 20);
            this.label9.TabIndex = 53;
            this.label9.Text = "QUẢN LÝ TRẠNG THÁI SÁCH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(770, 530);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(762, 522);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sách";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(411, 349);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 44);
            this.btnXoa.TabIndex = 59;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(260, 349);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 44);
            this.btnSua.TabIndex = 58;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(100, 349);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(82, 44);
            this.btnLuu.TabIndex = 57;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên trạng thái";
            // 
            // txtTenTrangThai
            // 
            this.txtTenTrangThai.Location = new System.Drawing.Point(569, 43);
            this.txtTenTrangThai.Name = "txtTenTrangThai";
            this.txtTenTrangThai.Size = new System.Drawing.Size(189, 22);
            this.txtTenTrangThai.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mô tả";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(128, 47);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(189, 22);
            this.txtMaSach.TabIndex = 9;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(128, 97);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(524, 22);
            this.txtMoTa.TabIndex = 10;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(972, 349);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 44);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(509, 255);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(82, 44);
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
            this.dgvQLTrangThaiSach.Location = new System.Drawing.Point(25, 414);
            this.dgvQLTrangThaiSach.Name = "dgvQLTrangThaiSach";
            this.dgvQLTrangThaiSach.RowHeadersWidth = 62;
            this.dgvQLTrangThaiSach.RowTemplate.Height = 28;
            this.dgvQLTrangThaiSach.Size = new System.Drawing.Size(1022, 227);
            this.dgvQLTrangThaiSach.TabIndex = 61;
            this.dgvQLTrangThaiSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLTrangThaiSach_CellClick);
            this.dgvQLTrangThaiSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLTrangThaiSach_CellContentClick);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFile.Location = new System.Drawing.Point(835, 349);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(82, 44);
            this.btnXuatFile.TabIndex = 60;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // grbQLTrangThaiSach
            // 
            this.grbQLTrangThaiSach.Controls.Add(this.label1);
            this.grbQLTrangThaiSach.Controls.Add(this.label2);
            this.grbQLTrangThaiSach.Controls.Add(this.txtTenTrangThai);
            this.grbQLTrangThaiSach.Controls.Add(this.label6);
            this.grbQLTrangThaiSach.Controls.Add(this.txtMaSach);
            this.grbQLTrangThaiSach.Controls.Add(this.txtMoTa);
            this.grbQLTrangThaiSach.Location = new System.Drawing.Point(25, 59);
            this.grbQLTrangThaiSach.Name = "grbQLTrangThaiSach";
            this.grbQLTrangThaiSach.Size = new System.Drawing.Size(1058, 158);
            this.grbQLTrangThaiSach.TabIndex = 56;
            this.grbQLTrangThaiSach.TabStop = false;
            this.grbQLTrangThaiSach.Text = "Trạng thái sách";
            this.grbQLTrangThaiSach.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnNhapFile
            // 
            this.btnNhapFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapFile.Location = new System.Drawing.Point(701, 349);
            this.btnNhapFile.Name = "btnNhapFile";
            this.btnNhapFile.Size = new System.Drawing.Size(82, 44);
            this.btnNhapFile.TabIndex = 64;
            this.btnNhapFile.Text = "Nhập file";
            this.btnNhapFile.UseVisualStyleBackColor = true;
            this.btnNhapFile.Click += new System.EventHandler(this.btnNhapFile_Click);
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
            // btnXoaNhieu
            // 
            this.btnXoaNhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNhieu.Location = new System.Drawing.Point(563, 349);
            this.btnXoaNhieu.Name = "btnXoaNhieu";
            this.btnXoaNhieu.Size = new System.Drawing.Size(86, 44);
            this.btnXoaNhieu.TabIndex = 65;
            this.btnXoaNhieu.Text = "Xóa nhiều";
            this.btnXoaNhieu.UseVisualStyleBackColor = true;
            this.btnXoaNhieu.Click += new System.EventHandler(this.btnXoaNhieu_Click);
            // 
            // QL_Trangthaisach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 653);
            this.Controls.Add(this.btnXoaNhieu);
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
        private System.Windows.Forms.TextBox txtMaSach;
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
        private System.Windows.Forms.Button btnXoaNhieu;
    }
}