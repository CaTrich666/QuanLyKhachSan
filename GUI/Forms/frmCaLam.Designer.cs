namespace GUI.Forms
{
    partial class frmCaLam
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
            this.dtgvCaLam = new System.Windows.Forms.DataGridView();
            this.btnSearchCL = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSearchCLName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemCL = new System.Windows.Forms.Button();
            this.btnXoaCL = new System.Windows.Forms.Button();
            this.btnSuaCL = new System.Windows.Forms.Button();
            this.btnResetCL = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpGKT = new System.Windows.Forms.DateTimePicker();
            this.dtpGBD = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenCL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGCL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHSL = new System.Windows.Forms.TextBox();
            this.txtMaCL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCaLam)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvCaLam
            // 
            this.dtgvCaLam.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCaLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvCaLam.Location = new System.Drawing.Point(3, 23);
            this.dtgvCaLam.Name = "dtgvCaLam";
            this.dtgvCaLam.RowHeadersWidth = 51;
            this.dtgvCaLam.RowTemplate.Height = 24;
            this.dtgvCaLam.Size = new System.Drawing.Size(493, 625);
            this.dtgvCaLam.TabIndex = 0;
            this.dtgvCaLam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCL_CellClick);
            // 
            // btnSearchCL
            // 
            this.btnSearchCL.Location = new System.Drawing.Point(591, 16);
            this.btnSearchCL.Name = "btnSearchCL";
            this.btnSearchCL.Size = new System.Drawing.Size(107, 40);
            this.btnSearchCL.TabIndex = 0;
            this.btnSearchCL.Text = "Tìm kiếm";
            this.btnSearchCL.UseVisualStyleBackColor = true;
            this.btnSearchCL.Click += new System.EventHandler(this.btnSearchCL_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSearchCLName);
            this.groupBox4.Controls.Add(this.btnSearchCL);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(5, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(780, 66);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Kiếm";
            // 
            // txtSearchCLName
            // 
            this.txtSearchCLName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearchCLName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchCLName.Location = new System.Drawing.Point(135, 23);
            this.txtSearchCLName.Name = "txtSearchCLName";
            this.txtSearchCLName.Size = new System.Drawing.Size(395, 27);
            this.txtSearchCLName.TabIndex = 2;
            this.txtSearchCLName.Text = "Hãy nhập tên ca làm cần tìm";
            this.txtSearchCLName.TextChanged += new System.EventHandler(this.txtSearchCLName_TextChanged);
            this.txtSearchCLName.Enter += new System.EventHandler(this.txtSearchCLName_Enter);
            this.txtSearchCLName.Leave += new System.EventHandler(this.txtSearchCLName_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtgvCaLam);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(791, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 651);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Ca Làm";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnThemCL);
            this.groupBox1.Controls.Add(this.btnXoaCL);
            this.groupBox1.Controls.Add(this.btnSuaCL);
            this.groupBox1.Controls.Add(this.btnResetCL);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(5, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 148);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnThemCL
            // 
            this.btnThemCL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCL.Location = new System.Drawing.Point(56, 33);
            this.btnThemCL.Name = "btnThemCL";
            this.btnThemCL.Size = new System.Drawing.Size(185, 30);
            this.btnThemCL.TabIndex = 29;
            this.btnThemCL.Text = "Thêm ca làm";
            this.btnThemCL.UseVisualStyleBackColor = true;
            this.btnThemCL.Click += new System.EventHandler(this.btnThemCL_Click);
            // 
            // btnXoaCL
            // 
            this.btnXoaCL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCL.Location = new System.Drawing.Point(416, 33);
            this.btnXoaCL.Name = "btnXoaCL";
            this.btnXoaCL.Size = new System.Drawing.Size(185, 30);
            this.btnXoaCL.TabIndex = 31;
            this.btnXoaCL.Text = "Xóa ca làm";
            this.btnXoaCL.UseVisualStyleBackColor = true;
            this.btnXoaCL.Click += new System.EventHandler(this.btnXoaCL_Click);
            // 
            // btnSuaCL
            // 
            this.btnSuaCL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCL.Location = new System.Drawing.Point(56, 92);
            this.btnSuaCL.Name = "btnSuaCL";
            this.btnSuaCL.Size = new System.Drawing.Size(185, 30);
            this.btnSuaCL.TabIndex = 30;
            this.btnSuaCL.Text = "Sửa ca làm";
            this.btnSuaCL.UseVisualStyleBackColor = true;
            this.btnSuaCL.Click += new System.EventHandler(this.btnSuaCL_Click);
            // 
            // btnResetCL
            // 
            this.btnResetCL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetCL.Location = new System.Drawing.Point(416, 92);
            this.btnResetCL.Name = "btnResetCL";
            this.btnResetCL.Size = new System.Drawing.Size(185, 30);
            this.btnResetCL.TabIndex = 41;
            this.btnResetCL.Text = "Reset";
            this.btnResetCL.UseVisualStyleBackColor = true;
            this.btnResetCL.Click += new System.EventHandler(this.btnResetCL_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dtpGKT);
            this.groupBox2.Controls.Add(this.dtpGBD);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTenCL);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtGCL);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtHSL);
            this.groupBox2.Controls.Add(this.txtMaCL);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 416);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Ca Làm";
            // 
            // dtpGKT
            // 
            this.dtpGKT.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGKT.Location = new System.Drawing.Point(444, 184);
            this.dtpGKT.Name = "dtpGKT";
            this.dtpGKT.ShowUpDown = true;
            this.dtpGKT.Size = new System.Drawing.Size(254, 27);
            this.dtpGKT.TabIndex = 80;
            // 
            // dtpGBD
            // 
            this.dtpGBD.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGBD.Location = new System.Drawing.Point(56, 184);
            this.dtpGBD.Name = "dtpGBD";
            this.dtpGBD.ShowUpDown = true;
            this.dtpGBD.Size = new System.Drawing.Size(254, 27);
            this.dtpGBD.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(441, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Tên Ca Làm";
            // 
            // txtTenCL
            // 
            this.txtTenCL.Location = new System.Drawing.Point(444, 100);
            this.txtTenCL.Name = "txtTenCL";
            this.txtTenCL.Size = new System.Drawing.Size(254, 27);
            this.txtTenCL.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(441, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Giá Ca Làm";
            // 
            // txtGCL
            // 
            this.txtGCL.Location = new System.Drawing.Point(444, 294);
            this.txtGCL.Name = "txtGCL";
            this.txtGCL.Size = new System.Drawing.Size(254, 27);
            this.txtGCL.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(441, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Giờ Kết Thúc Ca Làm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(53, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "Hệ Số Lương";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(53, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "Mã Ca Làm";
            // 
            // txtHSL
            // 
            this.txtHSL.Location = new System.Drawing.Point(56, 294);
            this.txtHSL.Name = "txtHSL";
            this.txtHSL.Size = new System.Drawing.Size(254, 27);
            this.txtHSL.TabIndex = 69;
            // 
            // txtMaCL
            // 
            this.txtMaCL.Location = new System.Drawing.Point(56, 100);
            this.txtMaCL.Name = "txtMaCL";
            this.txtMaCL.ReadOnly = true;
            this.txtMaCL.Size = new System.Drawing.Size(254, 27);
            this.txtMaCL.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(53, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 17);
            this.label7.TabIndex = 67;
            this.label7.Text = "Giờ Bắt Đầu Ca Làm";
            // 
            // frmCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 667);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmCaLam";
            this.Text = "Ca Làm";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCaLam)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvCaLam;
        private System.Windows.Forms.Button btnSearchCL;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSearchCLName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemCL;
        private System.Windows.Forms.Button btnXoaCL;
        private System.Windows.Forms.Button btnSuaCL;
        private System.Windows.Forms.Button btnResetCL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGCL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHSL;
        private System.Windows.Forms.TextBox txtMaCL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenCL;
        private System.Windows.Forms.DateTimePicker dtpGKT;
        private System.Windows.Forms.DateTimePicker dtpGBD;
    }
}