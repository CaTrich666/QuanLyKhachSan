namespace GUI.Forms
{
    partial class frmLichTruc
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaLT = new System.Windows.Forms.TextBox();
            this.btnThemLT = new System.Windows.Forms.Button();
            this.btnXoaLT = new System.Windows.Forms.Button();
            this.btnSuaLT = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgvLichTruc = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetLT = new System.Windows.Forms.Button();
            this.txtSearchLT = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSearchLT = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpNgayTruc = new System.Windows.Forms.DateTimePicker();
            this.cbMNV = new System.Windows.Forms.ComboBox();
            this.cbMCL = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichTruc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(441, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Mã Và Tên Ca Làm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(444, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Ngày Trực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(53, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "Mã Và Tên Nhân Viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(53, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "Mã Lịch Trực";
            // 
            // txtMaLT
            // 
            this.txtMaLT.Location = new System.Drawing.Point(56, 100);
            this.txtMaLT.Name = "txtMaLT";
            this.txtMaLT.ReadOnly = true;
            this.txtMaLT.Size = new System.Drawing.Size(254, 27);
            this.txtMaLT.TabIndex = 68;
            // 
            // btnThemLT
            // 
            this.btnThemLT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemLT.Location = new System.Drawing.Point(56, 33);
            this.btnThemLT.Name = "btnThemLT";
            this.btnThemLT.Size = new System.Drawing.Size(185, 30);
            this.btnThemLT.TabIndex = 29;
            this.btnThemLT.Text = "Thêm lịch trực";
            this.btnThemLT.UseVisualStyleBackColor = true;
            this.btnThemLT.Click += new System.EventHandler(this.btnThemLT_Click);
            // 
            // btnXoaLT
            // 
            this.btnXoaLT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLT.Location = new System.Drawing.Point(416, 33);
            this.btnXoaLT.Name = "btnXoaLT";
            this.btnXoaLT.Size = new System.Drawing.Size(185, 30);
            this.btnXoaLT.TabIndex = 31;
            this.btnXoaLT.Text = "Xóa lịch trực";
            this.btnXoaLT.UseVisualStyleBackColor = true;
            this.btnXoaLT.Click += new System.EventHandler(this.btnXoaLT_Click);
            // 
            // btnSuaLT
            // 
            this.btnSuaLT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaLT.Location = new System.Drawing.Point(56, 92);
            this.btnSuaLT.Name = "btnSuaLT";
            this.btnSuaLT.Size = new System.Drawing.Size(185, 30);
            this.btnSuaLT.TabIndex = 30;
            this.btnSuaLT.Text = "Sửa lịch trực";
            this.btnSuaLT.UseVisualStyleBackColor = true;
            this.btnSuaLT.Click += new System.EventHandler(this.btnSuaLT_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtgvLichTruc);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(791, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 651);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Lịch Trực";
            // 
            // dtgvLichTruc
            // 
            this.dtgvLichTruc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvLichTruc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvLichTruc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLichTruc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvLichTruc.Location = new System.Drawing.Point(3, 23);
            this.dtgvLichTruc.Name = "dtgvLichTruc";
            this.dtgvLichTruc.RowHeadersWidth = 51;
            this.dtgvLichTruc.RowTemplate.Height = 24;
            this.dtgvLichTruc.Size = new System.Drawing.Size(493, 625);
            this.dtgvLichTruc.TabIndex = 0;
            this.dtgvLichTruc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvLichTruc_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnThemLT);
            this.groupBox1.Controls.Add(this.btnXoaLT);
            this.groupBox1.Controls.Add(this.btnSuaLT);
            this.groupBox1.Controls.Add(this.btnResetLT);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(5, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 148);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnResetLT
            // 
            this.btnResetLT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetLT.Location = new System.Drawing.Point(416, 92);
            this.btnResetLT.Name = "btnResetLT";
            this.btnResetLT.Size = new System.Drawing.Size(185, 30);
            this.btnResetLT.TabIndex = 41;
            this.btnResetLT.Text = "Reset";
            this.btnResetLT.UseVisualStyleBackColor = true;
            this.btnResetLT.Click += new System.EventHandler(this.btnResetLT_Click);
            // 
            // txtSearchLT
            // 
            this.txtSearchLT.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearchLT.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchLT.Location = new System.Drawing.Point(125, 24);
            this.txtSearchLT.Name = "txtSearchLT";
            this.txtSearchLT.Size = new System.Drawing.Size(395, 27);
            this.txtSearchLT.TabIndex = 2;
            this.txtSearchLT.Text = "Hãy nhập mã lịch trực cần tìm";
            this.txtSearchLT.TextChanged += new System.EventHandler(this.txtSearchLT_TextChanged);
            this.txtSearchLT.Enter += new System.EventHandler(this.txtSearchLT_Enter);
            this.txtSearchLT.Leave += new System.EventHandler(this.txtSearchLT_Leave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSearchLT);
            this.groupBox4.Controls.Add(this.btnSearchLT);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(5, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(780, 66);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Kiếm";
            // 
            // btnSearchLT
            // 
            this.btnSearchLT.Location = new System.Drawing.Point(591, 16);
            this.btnSearchLT.Name = "btnSearchLT";
            this.btnSearchLT.Size = new System.Drawing.Size(107, 40);
            this.btnSearchLT.TabIndex = 0;
            this.btnSearchLT.Text = "Tìm kiếm";
            this.btnSearchLT.UseVisualStyleBackColor = true;
            this.btnSearchLT.Click += new System.EventHandler(this.btnSearchLT_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dtpNgayTruc);
            this.groupBox2.Controls.Add(this.cbMNV);
            this.groupBox2.Controls.Add(this.cbMCL);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMaLT);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 416);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Lịch Trực";
            // 
            // dtpNgayTruc
            // 
            this.dtpNgayTruc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTruc.Location = new System.Drawing.Point(444, 218);
            this.dtpNgayTruc.Name = "dtpNgayTruc";
            this.dtpNgayTruc.Size = new System.Drawing.Size(257, 27);
            this.dtpNgayTruc.TabIndex = 81;
            // 
            // cbMNV
            // 
            this.cbMNV.FormattingEnabled = true;
            this.cbMNV.Location = new System.Drawing.Point(56, 218);
            this.cbMNV.Name = "cbMNV";
            this.cbMNV.Size = new System.Drawing.Size(254, 27);
            this.cbMNV.TabIndex = 80;
            // 
            // cbMCL
            // 
            this.cbMCL.FormattingEnabled = true;
            this.cbMCL.Location = new System.Drawing.Point(444, 100);
            this.cbMCL.Name = "cbMCL";
            this.cbMCL.Size = new System.Drawing.Size(257, 27);
            this.cbMCL.TabIndex = 79;
            // 
            // frmLichTruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 667);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmLichTruc";
            this.Text = "Lịch trực";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichTruc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaLT;
        private System.Windows.Forms.Button btnThemLT;
        private System.Windows.Forms.Button btnXoaLT;
        private System.Windows.Forms.Button btnSuaLT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgvLichTruc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResetLT;
        private System.Windows.Forms.TextBox txtSearchLT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSearchLT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbMNV;
        private System.Windows.Forms.ComboBox cbMCL;
        private System.Windows.Forms.DateTimePicker dtpNgayTruc;
    }
}