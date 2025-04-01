namespace GUI.Forms
{
    partial class frmThietBi
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
            this.dtgvThietBi = new System.Windows.Forms.DataGridView();
            this.btnSearchTB = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSearchTBName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemTB = new System.Windows.Forms.Button();
            this.btnXoaTB = new System.Windows.Forms.Button();
            this.btnSuaTB = new System.Windows.Forms.Button();
            this.btnResetTB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVTSD = new System.Windows.Forms.TextBox();
            this.cbMaP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTTTB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThietBi)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvThietBi
            // 
            this.dtgvThietBi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThietBi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvThietBi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvThietBi.GridColor = System.Drawing.SystemColors.Control;
            this.dtgvThietBi.Location = new System.Drawing.Point(3, 23);
            this.dtgvThietBi.Name = "dtgvThietBi";
            this.dtgvThietBi.RowHeadersWidth = 51;
            this.dtgvThietBi.RowTemplate.Height = 24;
            this.dtgvThietBi.Size = new System.Drawing.Size(493, 625);
            this.dtgvThietBi.TabIndex = 0;
            this.dtgvThietBi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThietBi_CellClick);
            // 
            // btnSearchTB
            // 
            this.btnSearchTB.Location = new System.Drawing.Point(591, 16);
            this.btnSearchTB.Name = "btnSearchTB";
            this.btnSearchTB.Size = new System.Drawing.Size(107, 40);
            this.btnSearchTB.TabIndex = 0;
            this.btnSearchTB.Text = "Tìm kiếm";
            this.btnSearchTB.UseVisualStyleBackColor = true;
            this.btnSearchTB.Click += new System.EventHandler(this.btnSearchTB_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSearchTBName);
            this.groupBox4.Controls.Add(this.btnSearchTB);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(5, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(780, 66);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Kiếm";
            // 
            // txtSearchTBName
            // 
            this.txtSearchTBName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearchTBName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchTBName.Location = new System.Drawing.Point(114, 24);
            this.txtSearchTBName.Name = "txtSearchTBName";
            this.txtSearchTBName.Size = new System.Drawing.Size(395, 27);
            this.txtSearchTBName.TabIndex = 2;
            this.txtSearchTBName.Text = "Hãy nhập tên thiết bị cần tìm";
            this.txtSearchTBName.TextChanged += new System.EventHandler(this.txtSearchTBName_TextChanged);
            this.txtSearchTBName.Enter += new System.EventHandler(this.txtSearchTBName_Enter);
            this.txtSearchTBName.Leave += new System.EventHandler(this.txtSearchTBName_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtgvThietBi);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(791, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 651);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Thiết Bị";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnThemTB);
            this.groupBox1.Controls.Add(this.btnXoaTB);
            this.groupBox1.Controls.Add(this.btnSuaTB);
            this.groupBox1.Controls.Add(this.btnResetTB);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(5, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 148);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnThemTB
            // 
            this.btnThemTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTB.Location = new System.Drawing.Point(56, 33);
            this.btnThemTB.Name = "btnThemTB";
            this.btnThemTB.Size = new System.Drawing.Size(185, 30);
            this.btnThemTB.TabIndex = 29;
            this.btnThemTB.Text = "Thêm thiết bị";
            this.btnThemTB.UseVisualStyleBackColor = true;
            this.btnThemTB.Click += new System.EventHandler(this.btnThemTB_Click);
            // 
            // btnXoaTB
            // 
            this.btnXoaTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTB.Location = new System.Drawing.Point(416, 33);
            this.btnXoaTB.Name = "btnXoaTB";
            this.btnXoaTB.Size = new System.Drawing.Size(185, 30);
            this.btnXoaTB.TabIndex = 31;
            this.btnXoaTB.Text = "Xóa thiết bị";
            this.btnXoaTB.UseVisualStyleBackColor = true;
            this.btnXoaTB.Click += new System.EventHandler(this.btnXoaTB_Click);
            // 
            // btnSuaTB
            // 
            this.btnSuaTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTB.Location = new System.Drawing.Point(56, 92);
            this.btnSuaTB.Name = "btnSuaTB";
            this.btnSuaTB.Size = new System.Drawing.Size(185, 30);
            this.btnSuaTB.TabIndex = 30;
            this.btnSuaTB.Text = "Sửa thiết bị";
            this.btnSuaTB.UseVisualStyleBackColor = true;
            this.btnSuaTB.Click += new System.EventHandler(this.btnSuaTB_Click);
            // 
            // btnResetTB
            // 
            this.btnResetTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetTB.Location = new System.Drawing.Point(416, 92);
            this.btnResetTB.Name = "btnResetTB";
            this.btnResetTB.Size = new System.Drawing.Size(185, 30);
            this.btnResetTB.TabIndex = 41;
            this.btnResetTB.Text = "Reset";
            this.btnResetTB.UseVisualStyleBackColor = true;
            this.btnResetTB.Click += new System.EventHandler(this.btnResetTB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMaTB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtVTSD);
            this.groupBox2.Controls.Add(this.cbMaP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbTTTB);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTenTB);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 416);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Thiết Bị";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(53, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 73;
            this.label1.Text = "Mã Thiết Bị";
            // 
            // txtMaTB
            // 
            this.txtMaTB.Location = new System.Drawing.Point(56, 102);
            this.txtMaTB.Name = "txtMaTB";
            this.txtMaTB.ReadOnly = true;
            this.txtMaTB.Size = new System.Drawing.Size(254, 27);
            this.txtMaTB.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(441, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 71;
            this.label5.Text = "Vị Trí Sử Dụng";
            // 
            // txtVTSD
            // 
            this.txtVTSD.Location = new System.Drawing.Point(444, 185);
            this.txtVTSD.Name = "txtVTSD";
            this.txtVTSD.Size = new System.Drawing.Size(254, 27);
            this.txtVTSD.TabIndex = 70;
            // 
            // cbMaP
            // 
            this.cbMaP.FormattingEnabled = true;
            this.cbMaP.Location = new System.Drawing.Point(56, 265);
            this.cbMaP.Name = "cbMaP";
            this.cbMaP.Size = new System.Drawing.Size(254, 27);
            this.cbMaP.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(53, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 68;
            this.label6.Text = "Địa Chỉ Phòng";
            // 
            // cbTTTB
            // 
            this.cbTTTB.FormattingEnabled = true;
            this.cbTTTB.Location = new System.Drawing.Point(444, 102);
            this.cbTTTB.Name = "cbTTTB";
            this.cbTTTB.Size = new System.Drawing.Size(254, 27);
            this.cbTTTB.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(441, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 17);
            this.label7.TabIndex = 66;
            this.label7.Text = "Tình Trạng Thiết Bị";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(53, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 65;
            this.label8.Text = "Tên Thiết Bị";
            // 
            // txtTenTB
            // 
            this.txtTenTB.Location = new System.Drawing.Point(56, 182);
            this.txtTenTB.Name = "txtTenTB";
            this.txtTenTB.Size = new System.Drawing.Size(254, 27);
            this.txtTenTB.TabIndex = 64;
            // 
            // frmThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 667);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmThietBi";
            this.Text = "Thiết Bị";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThietBi)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvThietBi;
        private System.Windows.Forms.Button btnSearchTB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSearchTBName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemTB;
        private System.Windows.Forms.Button btnXoaTB;
        private System.Windows.Forms.Button btnSuaTB;
        private System.Windows.Forms.Button btnResetTB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVTSD;
        private System.Windows.Forms.ComboBox cbMaP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTTTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTenTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaTB;
    }
}