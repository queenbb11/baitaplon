namespace baitaplon
{
    partial class QuanlyTacgia
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
            this.btntkiemtg = new System.Windows.Forms.Button();
            this.dtvtacgia = new System.Windows.Forms.DataGridView();
            this.btnxtg = new System.Windows.Forms.Button();
            this.btnxoatg = new System.Windows.Forms.Button();
            this.btnsuatg = new System.Windows.Forms.Button();
            this.btnluutg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdthoaitg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttentg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtmatg = new System.Windows.Forms.TextBox();
            this.txtdchitg = new System.Windows.Forms.TextBox();
            this.txttimkiemmtg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTacgia = new System.Windows.Forms.DateTimePicker();
            this.txtgioitinhtg = new System.Windows.Forms.ComboBox();
            this.btnreset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtvtacgia)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btntkiemtg
            // 
            this.btntkiemtg.Location = new System.Drawing.Point(906, 222);
            this.btntkiemtg.Name = "btntkiemtg";
            this.btntkiemtg.Size = new System.Drawing.Size(82, 46);
            this.btntkiemtg.TabIndex = 36;
            this.btntkiemtg.Text = "Tìm kiếm";
            this.btntkiemtg.UseVisualStyleBackColor = true;
            this.btntkiemtg.Click += new System.EventHandler(this.btntkiemtg_Click);
            // 
            // dtvtacgia
            // 
            this.dtvtacgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvtacgia.Location = new System.Drawing.Point(50, 451);
            this.dtvtacgia.Name = "dtvtacgia";
            this.dtvtacgia.RowHeadersWidth = 62;
            this.dtvtacgia.RowTemplate.Height = 28;
            this.dtvtacgia.Size = new System.Drawing.Size(1022, 239);
            this.dtvtacgia.TabIndex = 35;
            this.dtvtacgia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvtacgia_CellClick);
            this.dtvtacgia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnxtg
            // 
            this.btnxtg.Location = new System.Drawing.Point(816, 377);
            this.btnxtg.Name = "btnxtg";
            this.btnxtg.Size = new System.Drawing.Size(82, 46);
            this.btnxtg.TabIndex = 34;
            this.btnxtg.Text = "Xuất file";
            this.btnxtg.UseVisualStyleBackColor = true;
            this.btnxtg.Click += new System.EventHandler(this.btnxtg_Click);
            // 
            // btnxoatg
            // 
            this.btnxoatg.Location = new System.Drawing.Point(620, 377);
            this.btnxoatg.Name = "btnxoatg";
            this.btnxoatg.Size = new System.Drawing.Size(82, 46);
            this.btnxoatg.TabIndex = 33;
            this.btnxoatg.Text = "Xóa";
            this.btnxoatg.UseVisualStyleBackColor = true;
            this.btnxoatg.Click += new System.EventHandler(this.btnxoatg_Click);
            // 
            // btnsuatg
            // 
            this.btnsuatg.Location = new System.Drawing.Point(397, 377);
            this.btnsuatg.Name = "btnsuatg";
            this.btnsuatg.Size = new System.Drawing.Size(82, 46);
            this.btnsuatg.TabIndex = 32;
            this.btnsuatg.Text = "Sửa";
            this.btnsuatg.UseVisualStyleBackColor = true;
            this.btnsuatg.Click += new System.EventHandler(this.btnsuatg_Click);
            // 
            // btnluutg
            // 
            this.btnluutg.Location = new System.Drawing.Point(159, 377);
            this.btnluutg.Name = "btnluutg";
            this.btnluutg.Size = new System.Drawing.Size(82, 46);
            this.btnluutg.TabIndex = 31;
            this.btnluutg.Text = "Lưu";
            this.btnluutg.UseVisualStyleBackColor = true;
            this.btnluutg.Click += new System.EventHandler(this.btnluutg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtgioitinhtg);
            this.groupBox1.Controls.Add(this.dtTacgia);
            this.groupBox1.Controls.Add(this.txtdthoaitg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txttentg);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtmatg);
            this.groupBox1.Controls.Add(this.txtdchitg);
            this.groupBox1.Location = new System.Drawing.Point(50, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 264);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tác giả";
            // 
            // txtdthoaitg
            // 
            this.txtdthoaitg.Location = new System.Drawing.Point(468, 120);
            this.txtdthoaitg.Name = "txtdthoaitg";
            this.txtdthoaitg.Size = new System.Drawing.Size(184, 26);
            this.txtdthoaitg.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã tác giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tác giả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày sinh";
            // 
            // txttentg
            // 
            this.txttentg.Location = new System.Drawing.Point(128, 123);
            this.txttentg.Name = "txttentg";
            this.txttentg.Size = new System.Drawing.Size(189, 26);
            this.txttentg.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Giới tính";
            // 
            // txtmatg
            // 
            this.txtmatg.Location = new System.Drawing.Point(128, 49);
            this.txtmatg.Name = "txtmatg";
            this.txtmatg.Size = new System.Drawing.Size(189, 26);
            this.txtmatg.TabIndex = 9;
            this.txtmatg.TextChanged += new System.EventHandler(this.txtmatg_TextChanged);
            // 
            // txtdchitg
            // 
            this.txtdchitg.Location = new System.Drawing.Point(468, 195);
            this.txtdchitg.Name = "txtdchitg";
            this.txtdchitg.Size = new System.Drawing.Size(184, 26);
            this.txtdchitg.TabIndex = 10;
            // 
            // txttimkiemmtg
            // 
            this.txttimkiemmtg.Location = new System.Drawing.Point(849, 174);
            this.txttimkiemmtg.Name = "txttimkiemmtg";
            this.txttimkiemmtg.Size = new System.Drawing.Size(189, 26);
            this.txttimkiemmtg.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(845, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Tìm kiếm thông tin tác giả";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(514, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "QUẢN LÝ TÁC GIẢ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(795, 584);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(787, 576);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 25;
            // 
            // dtTacgia
            // 
            this.dtTacgia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTacgia.Location = new System.Drawing.Point(128, 193);
            this.dtTacgia.Name = "dtTacgia";
            this.dtTacgia.Size = new System.Drawing.Size(189, 26);
            this.dtTacgia.TabIndex = 15;
            // 
            // txtgioitinhtg
            // 
            this.txtgioitinhtg.FormattingEnabled = true;
            this.txtgioitinhtg.Location = new System.Drawing.Point(468, 45);
            this.txtgioitinhtg.Name = "txtgioitinhtg";
            this.txtgioitinhtg.Size = new System.Drawing.Size(184, 28);
            this.txtgioitinhtg.TabIndex = 16;
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(991, 377);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 46);
            this.btnreset.TabIndex = 37;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // QuanlyTacgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 719);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btntkiemtg);
            this.Controls.Add(this.dtvtacgia);
            this.Controls.Add(this.btnxtg);
            this.Controls.Add(this.btnxoatg);
            this.Controls.Add(this.btnsuatg);
            this.Controls.Add(this.btnluutg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txttimkiemmtg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "QuanlyTacgia";
            this.Text = "QuanlyTacgia";
            this.Load += new System.EventHandler(this.QuanlyTacgia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtvtacgia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntkiemtg;
        private System.Windows.Forms.DataGridView dtvtacgia;
        private System.Windows.Forms.Button btnxtg;
        private System.Windows.Forms.Button btnxoatg;
        private System.Windows.Forms.Button btnsuatg;
        private System.Windows.Forms.Button btnluutg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtdthoaitg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttentg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtmatg;
        private System.Windows.Forms.TextBox txtdchitg;
        private System.Windows.Forms.TextBox txttimkiemmtg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTacgia;
        private System.Windows.Forms.ComboBox txtgioitinhtg;
        private System.Windows.Forms.Button btnreset;
    }
}