namespace baitaplon
{
    partial class Ql_theloai
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaTL = new System.Windows.Forms.TextBox();
            this.txtTenTL = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTheloai = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXuatfile = new System.Windows.Forms.Button();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheloai)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(439, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THỂ LOẠI SÁCH";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenTL);
            this.groupBox1.Controls.Add(this.txtMaTL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(48, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 179);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thể loại sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã thể loại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên thể loại";
            // 
            // txtMaTL
            // 
            this.txtMaTL.Location = new System.Drawing.Point(227, 51);
            this.txtMaTL.Name = "txtMaTL";
            this.txtMaTL.Size = new System.Drawing.Size(230, 26);
            this.txtMaTL.TabIndex = 2;
            // 
            // txtTenTL
            // 
            this.txtTenTL.Location = new System.Drawing.Point(227, 119);
            this.txtTenTL.Name = "txtTenTL";
            this.txtTenTL.Size = new System.Drawing.Size(230, 26);
            this.txtTenTL.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(748, 166);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(229, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(759, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tìm kiếm thông tin thể loại";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dgvTheloai
            // 
            this.dgvTheloai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheloai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaTL,
            this.TenTL});
            this.dgvTheloai.Location = new System.Drawing.Point(49, 398);
            this.dgvTheloai.Name = "dgvTheloai";
            this.dgvTheloai.RowHeadersWidth = 62;
            this.dgvTheloai.RowTemplate.Height = 28;
            this.dgvTheloai.Size = new System.Drawing.Size(956, 225);
            this.dgvTheloai.TabIndex = 4;
            this.dgvTheloai.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTheloai_RowPostPaint);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(136, 338);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(97, 32);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(315, 338);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(97, 32);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(869, 338);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 32);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(814, 210);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(97, 32);
            this.btnTimkiem.TabIndex = 8;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(504, 338);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(97, 32);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXuatfile
            // 
            this.btnXuatfile.Location = new System.Drawing.Point(679, 338);
            this.btnXuatfile.Name = "btnXuatfile";
            this.btnXuatfile.Size = new System.Drawing.Size(97, 32);
            this.btnXuatfile.TabIndex = 10;
            this.btnXuatfile.Text = "Xuất file";
            this.btnXuatfile.UseVisualStyleBackColor = true;
            this.btnXuatfile.Click += new System.EventHandler(this.btnXuatfile_Click);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 8;
            this.STT.Name = "STT";
            this.STT.Width = 150;
            // 
            // MaTL
            // 
            this.MaTL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaTL.DataPropertyName = "MaTL";
            this.MaTL.HeaderText = "Mã thể loại";
            this.MaTL.MinimumWidth = 8;
            this.MaTL.Name = "MaTL";
            // 
            // TenTL
            // 
            this.TenTL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenTL.DataPropertyName = "TenTL";
            this.TenTL.HeaderText = "Tên thể loại";
            this.TenTL.MinimumWidth = 8;
            this.TenTL.Name = "TenTL";
            // 
            // Ql_theloai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 645);
            this.Controls.Add(this.btnXuatfile);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvTheloai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Ql_theloai";
            this.Text = "Qltheloai";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheloai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenTL;
        private System.Windows.Forms.TextBox txtMaTL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTheloai;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXuatfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTL;
    }
}