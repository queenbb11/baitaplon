namespace baitaplon
{
    partial class Nha_xuat_ban
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
            this.btnreset = new System.Windows.Forms.Button();
            this.btntkiemtg = new System.Windows.Forms.Button();
            this.dtvnxb = new System.Windows.Forms.DataGridView();
            this.btnxtg = new System.Windows.Forms.Button();
            this.btnxoatg = new System.Windows.Forms.Button();
            this.btnsuatg = new System.Windows.Forms.Button();
            this.btnluutg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdthoainxb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttennxb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmanxb = new System.Windows.Forms.TextBox();
            this.txtdchinxb = new System.Windows.Forms.TextBox();
            this.txttimkiemnxb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtemailnxb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtvnxb)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(981, 373);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 46);
            this.btnreset.TabIndex = 50;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btntkiemtg
            // 
            this.btntkiemtg.Location = new System.Drawing.Point(903, 218);
            this.btntkiemtg.Name = "btntkiemtg";
            this.btntkiemtg.Size = new System.Drawing.Size(82, 46);
            this.btntkiemtg.TabIndex = 49;
            this.btntkiemtg.Text = "Tìm kiếm";
            this.btntkiemtg.UseVisualStyleBackColor = true;
            this.btntkiemtg.Click += new System.EventHandler(this.btntkiemtg_Click);
            // 
            // dtvnxb
            // 
            this.dtvnxb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvnxb.Location = new System.Drawing.Point(47, 447);
            this.dtvnxb.Name = "dtvnxb";
            this.dtvnxb.RowHeadersWidth = 62;
            this.dtvnxb.RowTemplate.Height = 28;
            this.dtvnxb.Size = new System.Drawing.Size(1022, 239);
            this.dtvnxb.TabIndex = 48;
            this.dtvnxb.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvnxb_CellClick);
            this.dtvnxb.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvnxb_CellContentClick);
            // 
            // btnxtg
            // 
            this.btnxtg.Location = new System.Drawing.Point(788, 373);
            this.btnxtg.Name = "btnxtg";
            this.btnxtg.Size = new System.Drawing.Size(82, 46);
            this.btnxtg.TabIndex = 47;
            this.btnxtg.Text = "Xuất file";
            this.btnxtg.UseVisualStyleBackColor = true;
            this.btnxtg.Click += new System.EventHandler(this.btnxtg_Click);
            // 
            // btnxoatg
            // 
            this.btnxoatg.Location = new System.Drawing.Point(588, 373);
            this.btnxoatg.Name = "btnxoatg";
            this.btnxoatg.Size = new System.Drawing.Size(82, 46);
            this.btnxoatg.TabIndex = 46;
            this.btnxoatg.Text = "Xóa";
            this.btnxoatg.UseVisualStyleBackColor = true;
            this.btnxoatg.Click += new System.EventHandler(this.btnxoatg_Click);
            // 
            // btnsuatg
            // 
            this.btnsuatg.Location = new System.Drawing.Point(378, 373);
            this.btnsuatg.Name = "btnsuatg";
            this.btnsuatg.Size = new System.Drawing.Size(82, 46);
            this.btnsuatg.TabIndex = 45;
            this.btnsuatg.Text = "Sửa";
            this.btnsuatg.UseVisualStyleBackColor = true;
            this.btnsuatg.Click += new System.EventHandler(this.btnsuatg_Click_1);
            // 
            // btnluutg
            // 
            this.btnluutg.Location = new System.Drawing.Point(156, 373);
            this.btnluutg.Name = "btnluutg";
            this.btnluutg.Size = new System.Drawing.Size(82, 46);
            this.btnluutg.TabIndex = 44;
            this.btnluutg.Text = "Lưu";
            this.btnluutg.UseVisualStyleBackColor = true;
            this.btnluutg.Click += new System.EventHandler(this.btnluutg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtemailnxb);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtdthoainxb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txttennxb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtmanxb);
            this.groupBox1.Controls.Add(this.txtdchinxb);
            this.groupBox1.Location = new System.Drawing.Point(47, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 264);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhà xuất bản";
            // 
            // txtdthoainxb
            // 
            this.txtdthoainxb.Location = new System.Drawing.Point(128, 195);
            this.txtdthoainxb.Name = "txtdthoainxb";
            this.txtdthoainxb.Size = new System.Drawing.Size(189, 26);
            this.txtdthoainxb.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã NXB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên NXB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 2;
            // 
            // txttennxb
            // 
            this.txttennxb.Location = new System.Drawing.Point(128, 123);
            this.txttennxb.Name = "txttennxb";
            this.txttennxb.Size = new System.Drawing.Size(189, 26);
            this.txttennxb.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Điện thoại";
            // 
            // txtmanxb
            // 
            this.txtmanxb.Location = new System.Drawing.Point(128, 49);
            this.txtmanxb.Name = "txtmanxb";
            this.txtmanxb.Size = new System.Drawing.Size(189, 26);
            this.txtmanxb.TabIndex = 9;
            // 
            // txtdchinxb
            // 
            this.txtdchinxb.Location = new System.Drawing.Point(466, 123);
            this.txtdchinxb.Name = "txtdchinxb";
            this.txtdchinxb.Size = new System.Drawing.Size(184, 26);
            this.txtdchinxb.TabIndex = 10;
            // 
            // txttimkiemnxb
            // 
            this.txttimkiemnxb.Location = new System.Drawing.Point(846, 170);
            this.txttimkiemnxb.Name = "txttimkiemnxb";
            this.txttimkiemnxb.Size = new System.Drawing.Size(189, 26);
            this.txttimkiemnxb.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(852, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 20);
            this.label10.TabIndex = 41;
            this.label10.Text = "Tìm kiếm thông tin NXB";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(511, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 20);
            this.label9.TabIndex = 40;
            this.label9.Text = "QUẢN LÝ NHÀ XUẤT BẢN";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(792, 580);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(784, 572);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 38;
            // 
            // txtemailnxb
            // 
            this.txtemailnxb.Location = new System.Drawing.Point(466, 53);
            this.txtemailnxb.Name = "txtemailnxb";
            this.txtemailnxb.Size = new System.Drawing.Size(184, 26);
            this.txtemailnxb.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Email";
            // 
            // Nha_xuat_ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 720);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btntkiemtg);
            this.Controls.Add(this.dtvnxb);
            this.Controls.Add(this.btnxtg);
            this.Controls.Add(this.btnxoatg);
            this.Controls.Add(this.btnsuatg);
            this.Controls.Add(this.btnluutg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txttimkiemnxb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "Nha_xuat_ban";
            this.Text = "Nha_xuat_ban";
            this.Load += new System.EventHandler(this.Nha_xuat_ban_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dtvnxb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btntkiemtg;
        private System.Windows.Forms.DataGridView dtvnxb;
        private System.Windows.Forms.Button btnxtg;
        private System.Windows.Forms.Button btnxoatg;
        private System.Windows.Forms.Button btnsuatg;
        private System.Windows.Forms.Button btnluutg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtdthoainxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttennxb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtmanxb;
        private System.Windows.Forms.TextBox txtdchinxb;
        private System.Windows.Forms.TextBox txttimkiemnxb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtemailnxb;
        private System.Windows.Forms.Label label8;
    }
}