namespace GUI.Forms
{
    partial class frmLoaiPhong
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
            this.dtgvLoaiP = new System.Windows.Forms.DataGridView();
            this.btnSearchLP = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSearchLPName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemLP = new System.Windows.Forms.Button();
            this.btnXoaLP = new System.Windows.Forms.Button();
            this.btnSuaLP = new System.Windows.Forms.Button();
            this.btnResetLP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenLP = new System.Windows.Forms.TextBox();
            this.txtSoNguoiTD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiaLP = new System.Windows.Forms.TextBox();
            this.txtMaLP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLoaiP)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvLoaiP
            // 
            this.dtgvLoaiP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvLoaiP.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvLoaiP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLoaiP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvLoaiP.Location = new System.Drawing.Point(3, 23);
            this.dtgvLoaiP.Name = "dtgvLoaiP";
            this.dtgvLoaiP.RowHeadersWidth = 51;
            this.dtgvLoaiP.RowTemplate.Height = 24;
            this.dtgvLoaiP.Size = new System.Drawing.Size(493, 625);
            this.dtgvLoaiP.TabIndex = 0;
            this.dtgvLoaiP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvLoaiP_CellClick);
            // 
            // btnSearchLP
            // 
            this.btnSearchLP.Location = new System.Drawing.Point(591, 16);
            this.btnSearchLP.Name = "btnSearchLP";
            this.btnSearchLP.Size = new System.Drawing.Size(107, 40);
            this.btnSearchLP.TabIndex = 0;
            this.btnSearchLP.Text = "Tìm kiếm";
            this.btnSearchLP.UseVisualStyleBackColor = true;
            this.btnSearchLP.Click += new System.EventHandler(this.btnSearchLP_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSearchLPName);
            this.groupBox4.Controls.Add(this.btnSearchLP);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(5, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(780, 66);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Kiếm";
            // 
            // txtSearchLPName
            // 
            this.txtSearchLPName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearchLPName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchLPName.Location = new System.Drawing.Point(120, 24);
            this.txtSearchLPName.Name = "txtSearchLPName";
            this.txtSearchLPName.Size = new System.Drawing.Size(395, 27);
            this.txtSearchLPName.TabIndex = 2;
            this.txtSearchLPName.Text = "Hãy nhập tên loại phòng cần tìm";
            this.txtSearchLPName.TextChanged += new System.EventHandler(this.txtSearchLPName_TextChanged);
            this.txtSearchLPName.Enter += new System.EventHandler(this.txtSearchLPName_Enter);
            this.txtSearchLPName.Leave += new System.EventHandler(this.txtSearchLPName_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtgvLoaiP);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(791, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 651);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Loại Phòng";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnThemLP);
            this.groupBox1.Controls.Add(this.btnXoaLP);
            this.groupBox1.Controls.Add(this.btnSuaLP);
            this.groupBox1.Controls.Add(this.btnResetLP);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(5, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 148);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnThemLP
            // 
            this.btnThemLP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemLP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemLP.Location = new System.Drawing.Point(56, 33);
            this.btnThemLP.Name = "btnThemLP";
            this.btnThemLP.Size = new System.Drawing.Size(185, 30);
            this.btnThemLP.TabIndex = 29;
            this.btnThemLP.Text = "Thêm loại phòng";
            this.btnThemLP.UseVisualStyleBackColor = true;
            this.btnThemLP.Click += new System.EventHandler(this.btnThemLP_Click);
            // 
            // btnXoaLP
            // 
            this.btnXoaLP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaLP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLP.Location = new System.Drawing.Point(416, 33);
            this.btnXoaLP.Name = "btnXoaLP";
            this.btnXoaLP.Size = new System.Drawing.Size(185, 30);
            this.btnXoaLP.TabIndex = 31;
            this.btnXoaLP.Text = "Xóa loại phòng";
            this.btnXoaLP.UseVisualStyleBackColor = true;
            this.btnXoaLP.Click += new System.EventHandler(this.btnXoaLP_Click);
            // 
            // btnSuaLP
            // 
            this.btnSuaLP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaLP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaLP.Location = new System.Drawing.Point(56, 92);
            this.btnSuaLP.Name = "btnSuaLP";
            this.btnSuaLP.Size = new System.Drawing.Size(185, 30);
            this.btnSuaLP.TabIndex = 30;
            this.btnSuaLP.Text = "Sửa loại phòng";
            this.btnSuaLP.UseVisualStyleBackColor = true;
            this.btnSuaLP.Click += new System.EventHandler(this.btnSuaLP_Click);
            // 
            // btnResetLP
            // 
            this.btnResetLP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetLP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetLP.Location = new System.Drawing.Point(416, 92);
            this.btnResetLP.Name = "btnResetLP";
            this.btnResetLP.Size = new System.Drawing.Size(185, 30);
            this.btnResetLP.TabIndex = 41;
            this.btnResetLP.Text = "Reset";
            this.btnResetLP.UseVisualStyleBackColor = true;
            this.btnResetLP.Click += new System.EventHandler(this.btnResetLP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTenLP);
            this.groupBox2.Controls.Add(this.txtSoNguoiTD);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtGiaLP);
            this.groupBox2.Controls.Add(this.txtMaLP);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 416);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Loại Phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(441, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Tên Loại Phòng";
            // 
            // txtTenLP
            // 
            this.txtTenLP.Location = new System.Drawing.Point(444, 105);
            this.txtTenLP.Name = "txtTenLP";
            this.txtTenLP.Size = new System.Drawing.Size(254, 27);
            this.txtTenLP.TabIndex = 60;
            // 
            // txtSoNguoiTD
            // 
            this.txtSoNguoiTD.Location = new System.Drawing.Point(444, 223);
            this.txtSoNguoiTD.Name = "txtSoNguoiTD";
            this.txtSoNguoiTD.Size = new System.Drawing.Size(254, 27);
            this.txtSoNguoiTD.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(53, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Giá Loại Phòng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(53, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 57;
            this.label6.Text = "Mã Loại Phòng";
            // 
            // txtGiaLP
            // 
            this.txtGiaLP.Location = new System.Drawing.Point(56, 226);
            this.txtGiaLP.Name = "txtGiaLP";
            this.txtGiaLP.Size = new System.Drawing.Size(254, 27);
            this.txtGiaLP.TabIndex = 56;
            // 
            // txtMaLP
            // 
            this.txtMaLP.Location = new System.Drawing.Point(56, 105);
            this.txtMaLP.Name = "txtMaLP";
            this.txtMaLP.ReadOnly = true;
            this.txtMaLP.Size = new System.Drawing.Size(254, 27);
            this.txtMaLP.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(441, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 54;
            this.label7.Text = "Số Người Tối Đa";
            // 
            // frmLoaiPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 667);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmLoaiPhong";
            this.Text = "Loại Phòng";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLoaiP)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvLoaiP;
        private System.Windows.Forms.Button btnSearchLP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSearchLPName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemLP;
        private System.Windows.Forms.Button btnXoaLP;
        private System.Windows.Forms.Button btnSuaLP;
        private System.Windows.Forms.Button btnResetLP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoNguoiTD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGiaLP;
        private System.Windows.Forms.TextBox txtMaLP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenLP;
    }
}