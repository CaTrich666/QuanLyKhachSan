namespace GUI.Forms
{
    partial class frmPhong
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
            this.dtgvPhong = new System.Windows.Forms.DataGridView();
            this.btnSearchPhong = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSearchPhongName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemP = new System.Windows.Forms.Button();
            this.btnXoaP = new System.Windows.Forms.Button();
            this.btnSuaP = new System.Windows.Forms.Button();
            this.btnResetP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenP = new System.Windows.Forms.TextBox();
            this.cbLoaiP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTTP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhong)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvPhong
            // 
            this.dtgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPhong.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvPhong.Location = new System.Drawing.Point(3, 23);
            this.dtgvPhong.Name = "dtgvPhong";
            this.dtgvPhong.RowHeadersWidth = 51;
            this.dtgvPhong.RowTemplate.Height = 24;
            this.dtgvPhong.Size = new System.Drawing.Size(493, 625);
            this.dtgvPhong.TabIndex = 0;
            this.dtgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhong_CellClick);
            // 
            // btnSearchPhong
            // 
            this.btnSearchPhong.Location = new System.Drawing.Point(591, 16);
            this.btnSearchPhong.Name = "btnSearchPhong";
            this.btnSearchPhong.Size = new System.Drawing.Size(107, 40);
            this.btnSearchPhong.TabIndex = 0;
            this.btnSearchPhong.Text = "Tìm kiếm";
            this.btnSearchPhong.UseVisualStyleBackColor = true;
            this.btnSearchPhong.Click += new System.EventHandler(this.btnSearchPhong_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSearchPhongName);
            this.groupBox4.Controls.Add(this.btnSearchPhong);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(5, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(780, 66);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Kiếm";
            // 
            // txtSearchPhongName
            // 
            this.txtSearchPhongName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearchPhongName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchPhongName.Location = new System.Drawing.Point(109, 23);
            this.txtSearchPhongName.Name = "txtSearchPhongName";
            this.txtSearchPhongName.Size = new System.Drawing.Size(395, 27);
            this.txtSearchPhongName.TabIndex = 2;
            this.txtSearchPhongName.Text = "Hãy nhập tên phòng cần tìm";
            this.txtSearchPhongName.TextChanged += new System.EventHandler(this.txtSearchPhongName_TextChanged);
            this.txtSearchPhongName.Enter += new System.EventHandler(this.txtSearchPhongName_Enter);
            this.txtSearchPhongName.Leave += new System.EventHandler(this.txtSearchPhongName_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtgvPhong);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(791, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 651);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Phòng";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnThemP);
            this.groupBox1.Controls.Add(this.btnXoaP);
            this.groupBox1.Controls.Add(this.btnSuaP);
            this.groupBox1.Controls.Add(this.btnResetP);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(5, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 148);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnThemP
            // 
            this.btnThemP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemP.Location = new System.Drawing.Point(56, 33);
            this.btnThemP.Name = "btnThemP";
            this.btnThemP.Size = new System.Drawing.Size(185, 30);
            this.btnThemP.TabIndex = 29;
            this.btnThemP.Text = "Thêm phòng";
            this.btnThemP.UseVisualStyleBackColor = true;
            this.btnThemP.Click += new System.EventHandler(this.btnThemP_Click);
            // 
            // btnXoaP
            // 
            this.btnXoaP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaP.Location = new System.Drawing.Point(416, 33);
            this.btnXoaP.Name = "btnXoaP";
            this.btnXoaP.Size = new System.Drawing.Size(185, 30);
            this.btnXoaP.TabIndex = 31;
            this.btnXoaP.Text = "Xóa phòng";
            this.btnXoaP.UseVisualStyleBackColor = true;
            this.btnXoaP.Click += new System.EventHandler(this.btnXoaP_Click);
            // 
            // btnSuaP
            // 
            this.btnSuaP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaP.Location = new System.Drawing.Point(56, 92);
            this.btnSuaP.Name = "btnSuaP";
            this.btnSuaP.Size = new System.Drawing.Size(185, 30);
            this.btnSuaP.TabIndex = 30;
            this.btnSuaP.Text = "Sửa phòng";
            this.btnSuaP.UseVisualStyleBackColor = true;
            this.btnSuaP.Click += new System.EventHandler(this.btnSuaP_Click);
            // 
            // btnResetP
            // 
            this.btnResetP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetP.Location = new System.Drawing.Point(416, 92);
            this.btnResetP.Name = "btnResetP";
            this.btnResetP.Size = new System.Drawing.Size(185, 30);
            this.btnResetP.TabIndex = 41;
            this.btnResetP.Text = "Reset";
            this.btnResetP.UseVisualStyleBackColor = true;
            this.btnResetP.Click += new System.EventHandler(this.btnResetP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTenP);
            this.groupBox2.Controls.Add(this.cbLoaiP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbTTP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMaP);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 416);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(441, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 86;
            this.label1.Text = "Tên Phòng";
            // 
            // txtTenP
            // 
            this.txtTenP.Location = new System.Drawing.Point(444, 108);
            this.txtTenP.Name = "txtTenP";
            this.txtTenP.Size = new System.Drawing.Size(254, 27);
            this.txtTenP.TabIndex = 85;
            // 
            // cbLoaiP
            // 
            this.cbLoaiP.FormattingEnabled = true;
            this.cbLoaiP.Location = new System.Drawing.Point(444, 212);
            this.cbLoaiP.Name = "cbLoaiP";
            this.cbLoaiP.Size = new System.Drawing.Size(254, 27);
            this.cbLoaiP.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(441, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 17);
            this.label5.TabIndex = 83;
            this.label5.Text = "Loại Và Tên Loại Phòng";
            // 
            // cbTTP
            // 
            this.cbTTP.FormattingEnabled = true;
            this.cbTTP.Location = new System.Drawing.Point(56, 212);
            this.cbTTP.Name = "cbTTP";
            this.cbTTP.Size = new System.Drawing.Size(254, 27);
            this.cbTTP.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(53, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 81;
            this.label6.Text = "Tình Trạng Phòng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(53, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 80;
            this.label7.Text = "Mã Phòng";
            // 
            // txtMaP
            // 
            this.txtMaP.Location = new System.Drawing.Point(56, 108);
            this.txtMaP.Name = "txtMaP";
            this.txtMaP.ReadOnly = true;
            this.txtMaP.Size = new System.Drawing.Size(254, 27);
            this.txtMaP.TabIndex = 79;
            // 
            // frmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 667);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPhong";
            this.Text = "Phòng";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPhong)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvPhong;
        private System.Windows.Forms.Button btnSearchPhong;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSearchPhongName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemP;
        private System.Windows.Forms.Button btnXoaP;
        private System.Windows.Forms.Button btnSuaP;
        private System.Windows.Forms.Button btnResetP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbLoaiP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenP;
    }
}