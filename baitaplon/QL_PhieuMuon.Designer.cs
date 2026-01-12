namespace baitaplon
{
    partial class QL_PhieuMuon
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
            this.textBoxTimKiemPhieuMuon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewMuonSach = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxMaDocGia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxNhanVienLapPhieu = new System.Windows.Forms.ComboBox();
            this.textBoxMaPhieuMuon = new System.Windows.Forms.TextBox();
            this.dateTimePickerNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHanTra = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTenDocGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewPhieuMuon = new System.Windows.Forms.DataGridView();
            this.buttonTimKiemPM = new System.Windows.Forms.Button();
            this.buttonThemPM = new System.Windows.Forms.Button();
            this.buttonSuaPM = new System.Windows.Forms.Button();
            this.buttonXoaPM = new System.Windows.Forms.Button();
            this.buttonXuatFilePM = new System.Windows.Forms.Button();
            this.buttonNhapFilePM = new System.Windows.Forms.Button();
            this.buttonQuayLai = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMuonSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTimKiemPhieuMuon
            // 
            this.textBoxTimKiemPhieuMuon.Location = new System.Drawing.Point(294, 491);
            this.textBoxTimKiemPhieuMuon.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTimKiemPhieuMuon.Name = "textBoxTimKiemPhieuMuon";
            this.textBoxTimKiemPhieuMuon.Size = new System.Drawing.Size(678, 31);
            this.textBoxTimKiemPhieuMuon.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 464);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm phiếu mượn:";
            // 
            // dataGridViewMuonSach
            // 
            this.dataGridViewMuonSach.AllowUserToAddRows = false;
            this.dataGridViewMuonSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMuonSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.MaSach,
            this.TenSach,
            this.SoLuong});
            this.dataGridViewMuonSach.Location = new System.Drawing.Point(294, 220);
            this.dataGridViewMuonSach.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewMuonSach.Name = "dataGridViewMuonSach";
            this.dataGridViewMuonSach.RowHeadersWidth = 51;
            this.dataGridViewMuonSach.RowTemplate.Height = 24;
            this.dataGridViewMuonSach.Size = new System.Drawing.Size(678, 216);
            this.dataGridViewMuonSach.TabIndex = 2;
            this.dataGridViewMuonSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMuonSach_CellContentClick);
            // 
            // Chon
            // 
            this.Chon.HeaderText = "Chọn";
            this.Chon.MinimumWidth = 6;
            this.Chon.Name = "Chon";
            this.Chon.Width = 125;
            // 
            // MaSach
            // 
            this.MaSach.HeaderText = "Mã sách";
            this.MaSach.MinimumWidth = 6;
            this.MaSach.Name = "MaSach";
            this.MaSach.ReadOnly = true;
            this.MaSach.Width = 125;
            // 
            // TenSach
            // 
            this.TenSach.HeaderText = "Tên sách";
            this.TenSach.MinimumWidth = 6;
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            this.TenSach.Width = 250;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 125;
            // 
            // comboBoxMaDocGia
            // 
            this.comboBoxMaDocGia.FormattingEnabled = true;
            this.comboBoxMaDocGia.Location = new System.Drawing.Point(254, 101);
            this.comboBoxMaDocGia.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMaDocGia.Name = "comboBoxMaDocGia";
            this.comboBoxMaDocGia.Size = new System.Drawing.Size(299, 31);
            this.comboBoxMaDocGia.TabIndex = 4;
            this.comboBoxMaDocGia.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocGia_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã phiếu mượn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã độc giả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên độc giả:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(638, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày mượn:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(638, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Hạn trả:";
            // 
            // comboBoxNhanVienLapPhieu
            // 
            this.comboBoxNhanVienLapPhieu.FormattingEnabled = true;
            this.comboBoxNhanVienLapPhieu.Location = new System.Drawing.Point(840, 151);
            this.comboBoxNhanVienLapPhieu.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNhanVienLapPhieu.Name = "comboBoxNhanVienLapPhieu";
            this.comboBoxNhanVienLapPhieu.Size = new System.Drawing.Size(274, 31);
            this.comboBoxNhanVienLapPhieu.TabIndex = 10;
            // 
            // textBoxMaPhieuMuon
            // 
            this.textBoxMaPhieuMuon.Location = new System.Drawing.Point(254, 49);
            this.textBoxMaPhieuMuon.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMaPhieuMuon.Name = "textBoxMaPhieuMuon";
            this.textBoxMaPhieuMuon.Size = new System.Drawing.Size(299, 31);
            this.textBoxMaPhieuMuon.TabIndex = 11;
            // 
            // dateTimePickerNgayMuon
            // 
            this.dateTimePickerNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayMuon.Location = new System.Drawing.Point(840, 49);
            this.dateTimePickerNgayMuon.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerNgayMuon.Name = "dateTimePickerNgayMuon";
            this.dateTimePickerNgayMuon.Size = new System.Drawing.Size(274, 31);
            this.dateTimePickerNgayMuon.TabIndex = 12;
            // 
            // dateTimePickerHanTra
            // 
            this.dateTimePickerHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHanTra.Location = new System.Drawing.Point(840, 98);
            this.dateTimePickerHanTra.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerHanTra.Name = "dateTimePickerHanTra";
            this.dateTimePickerHanTra.Size = new System.Drawing.Size(274, 31);
            this.dateTimePickerHanTra.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTenDocGia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxMaPhieuMuon);
            this.groupBox1.Controls.Add(this.dateTimePickerHanTra);
            this.groupBox1.Controls.Add(this.comboBoxMaDocGia);
            this.groupBox1.Controls.Add(this.dateTimePickerNgayMuon);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxNhanVienLapPhieu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(40, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1163, 199);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo phiếu mượn sách";
            // 
            // textBoxTenDocGia
            // 
            this.textBoxTenDocGia.Location = new System.Drawing.Point(254, 151);
            this.textBoxTenDocGia.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTenDocGia.Name = "textBoxTenDocGia";
            this.textBoxTenDocGia.ReadOnly = true;
            this.textBoxTenDocGia.Size = new System.Drawing.Size(299, 31);
            this.textBoxTenDocGia.TabIndex = 15;
            this.textBoxTenDocGia.TextChanged += new System.EventHandler(this.comboBoxDocGia_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(638, 154);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nhân viên lập phiếu:";
            // 
            // dataGridViewPhieuMuon
            // 
            this.dataGridViewPhieuMuon.AllowUserToAddRows = false;
            this.dataGridViewPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhieuMuon.Location = new System.Drawing.Point(294, 529);
            this.dataGridViewPhieuMuon.Name = "dataGridViewPhieuMuon";
            this.dataGridViewPhieuMuon.RowHeadersWidth = 51;
            this.dataGridViewPhieuMuon.RowTemplate.Height = 24;
            this.dataGridViewPhieuMuon.Size = new System.Drawing.Size(678, 206);
            this.dataGridViewPhieuMuon.TabIndex = 15;
            this.dataGridViewPhieuMuon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPhieuMuon_CellClick);
            // 
            // buttonTimKiemPM
            // 
            this.buttonTimKiemPM.Location = new System.Drawing.Point(979, 487);
            this.buttonTimKiemPM.Name = "buttonTimKiemPM";
            this.buttonTimKiemPM.Size = new System.Drawing.Size(108, 36);
            this.buttonTimKiemPM.TabIndex = 18;
            this.buttonTimKiemPM.Text = "Tìm kiếm";
            this.buttonTimKiemPM.UseVisualStyleBackColor = true;
            this.buttonTimKiemPM.Click += new System.EventHandler(this.buttonTimKiemPM_Click);
            // 
            // buttonThemPM
            // 
            this.buttonThemPM.Location = new System.Drawing.Point(979, 220);
            this.buttonThemPM.Name = "buttonThemPM";
            this.buttonThemPM.Size = new System.Drawing.Size(108, 36);
            this.buttonThemPM.TabIndex = 19;
            this.buttonThemPM.Text = "Thêm";
            this.buttonThemPM.UseVisualStyleBackColor = true;
            this.buttonThemPM.Click += new System.EventHandler(this.buttonThemPM_Click);
            // 
            // buttonSuaPM
            // 
            this.buttonSuaPM.Location = new System.Drawing.Point(979, 262);
            this.buttonSuaPM.Name = "buttonSuaPM";
            this.buttonSuaPM.Size = new System.Drawing.Size(108, 36);
            this.buttonSuaPM.TabIndex = 20;
            this.buttonSuaPM.Text = "Sửa";
            this.buttonSuaPM.UseVisualStyleBackColor = true;
            this.buttonSuaPM.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonXoaPM
            // 
            this.buttonXoaPM.Location = new System.Drawing.Point(979, 304);
            this.buttonXoaPM.Name = "buttonXoaPM";
            this.buttonXoaPM.Size = new System.Drawing.Size(108, 36);
            this.buttonXoaPM.TabIndex = 21;
            this.buttonXoaPM.Text = "Xóa";
            this.buttonXoaPM.UseVisualStyleBackColor = true;
            this.buttonXoaPM.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonXuatFilePM
            // 
            this.buttonXuatFilePM.Location = new System.Drawing.Point(979, 547);
            this.buttonXuatFilePM.Name = "buttonXuatFilePM";
            this.buttonXuatFilePM.Size = new System.Drawing.Size(108, 36);
            this.buttonXuatFilePM.TabIndex = 20;
            this.buttonXuatFilePM.Text = "Xuất file";
            this.buttonXuatFilePM.UseVisualStyleBackColor = true;
            this.buttonXuatFilePM.Click += new System.EventHandler(this.buttonXuatFilePM_Click);
            // 
            // buttonNhapFilePM
            // 
            this.buttonNhapFilePM.Location = new System.Drawing.Point(979, 600);
            this.buttonNhapFilePM.Name = "buttonNhapFilePM";
            this.buttonNhapFilePM.Size = new System.Drawing.Size(108, 36);
            this.buttonNhapFilePM.TabIndex = 22;
            this.buttonNhapFilePM.Text = "Nhập file";
            this.buttonNhapFilePM.UseVisualStyleBackColor = true;
            // 
            // buttonQuayLai
            // 
            this.buttonQuayLai.Location = new System.Drawing.Point(979, 652);
            this.buttonQuayLai.Name = "buttonQuayLai";
            this.buttonQuayLai.Size = new System.Drawing.Size(108, 36);
            this.buttonQuayLai.TabIndex = 23;
            this.buttonQuayLai.Text = "Quay lại";
            this.buttonQuayLai.UseVisualStyleBackColor = true;
            this.buttonQuayLai.Click += new System.EventHandler(this.buttonQuayLai_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(979, 346);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(108, 36);
            this.buttonReset.TabIndex = 24;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // QL_PhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 764);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonQuayLai);
            this.Controls.Add(this.buttonNhapFilePM);
            this.Controls.Add(this.buttonXuatFilePM);
            this.Controls.Add(this.buttonXoaPM);
            this.Controls.Add(this.buttonSuaPM);
            this.Controls.Add(this.buttonThemPM);
            this.Controls.Add(this.buttonTimKiemPM);
            this.Controls.Add(this.dataGridViewPhieuMuon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewMuonSach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTimKiemPhieuMuon);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QL_PhieuMuon";
            this.Text = "QL_PhieuMuon";
            this.Load += new System.EventHandler(this.QL_PhieuMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMuonSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTimKiemPhieuMuon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewMuonSach;
        private System.Windows.Forms.ComboBox comboBoxMaDocGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxNhanVienLapPhieu;
        private System.Windows.Forms.TextBox textBoxMaPhieuMuon;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayMuon;
        private System.Windows.Forms.DateTimePicker dateTimePickerHanTra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewPhieuMuon;
        private System.Windows.Forms.Button buttonTimKiemPM;
        private System.Windows.Forms.Button buttonThemPM;
        private System.Windows.Forms.Button buttonSuaPM;
        private System.Windows.Forms.Button buttonXoaPM;
        private System.Windows.Forms.Button buttonXuatFilePM;
        private System.Windows.Forms.Button buttonNhapFilePM;
        private System.Windows.Forms.TextBox textBoxTenDocGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonQuayLai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.Button buttonReset;
    }
}