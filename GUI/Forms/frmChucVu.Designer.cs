namespace GUI.Forms
{
    partial class frmChucVu
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
            this.dtgvChucVu = new System.Windows.Forms.DataGridView();
            this.btnSearchCV = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSearchCVName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemCV = new System.Windows.Forms.Button();
            this.btnXoaCV = new System.Windows.Forms.Button();
            this.btnSuaCV = new System.Windows.Forms.Button();
            this.btnResetCV = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLCB = new System.Windows.Forms.TextBox();
            this.txtMaCV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChucVu)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvChucVu
            // 
            this.dtgvChucVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvChucVu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvChucVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChucVu.Location = new System.Drawing.Point(3, 23);
            this.dtgvChucVu.Name = "dtgvChucVu";
            this.dtgvChucVu.RowHeadersWidth = 51;
            this.dtgvChucVu.RowTemplate.Height = 24;
            this.dtgvChucVu.Size = new System.Drawing.Size(493, 625);
            this.dtgvChucVu.TabIndex = 0;
            this.dtgvChucVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvChucVu_CellClick);
            // 
            // btnSearchCV
            // 
            this.btnSearchCV.Location = new System.Drawing.Point(591, 16);
            this.btnSearchCV.Name = "btnSearchCV";
            this.btnSearchCV.Size = new System.Drawing.Size(107, 40);
            this.btnSearchCV.TabIndex = 0;
            this.btnSearchCV.Text = "Tìm kiếm";
            this.btnSearchCV.UseVisualStyleBackColor = true;
            this.btnSearchCV.Click += new System.EventHandler(this.btnSearchCV_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSearchCVName);
            this.groupBox4.Controls.Add(this.btnSearchCV);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(5, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(780, 66);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm Kiếm";
            // 
            // txtSearchCVName
            // 
            this.txtSearchCVName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearchCVName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchCVName.Location = new System.Drawing.Point(113, 23);
            this.txtSearchCVName.Name = "txtSearchCVName";
            this.txtSearchCVName.Size = new System.Drawing.Size(395, 27);
            this.txtSearchCVName.TabIndex = 2;
            this.txtSearchCVName.Text = "Hãy nhập tên chức vụ cần tìm";
            this.txtSearchCVName.TextChanged += new System.EventHandler(this.txtSearchCVName_TextChanged);
            this.txtSearchCVName.Enter += new System.EventHandler(this.txtSearchCVName_Enter);
            this.txtSearchCVName.Leave += new System.EventHandler(this.txtSearchCVName_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtgvChucVu);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(791, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 651);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Chức Vụ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnThemCV);
            this.groupBox1.Controls.Add(this.btnXoaCV);
            this.groupBox1.Controls.Add(this.btnSuaCV);
            this.groupBox1.Controls.Add(this.btnResetCV);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(5, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 148);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnThemCV
            // 
            this.btnThemCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemCV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCV.Location = new System.Drawing.Point(56, 33);
            this.btnThemCV.Name = "btnThemCV";
            this.btnThemCV.Size = new System.Drawing.Size(185, 30);
            this.btnThemCV.TabIndex = 29;
            this.btnThemCV.Text = "Thêm chức vụ";
            this.btnThemCV.UseVisualStyleBackColor = true;
            this.btnThemCV.Click += new System.EventHandler(this.btnThemCV_Click);
            // 
            // btnXoaCV
            // 
            this.btnXoaCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaCV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCV.Location = new System.Drawing.Point(416, 33);
            this.btnXoaCV.Name = "btnXoaCV";
            this.btnXoaCV.Size = new System.Drawing.Size(185, 30);
            this.btnXoaCV.TabIndex = 31;
            this.btnXoaCV.Text = "Xóa chức vụ";
            this.btnXoaCV.UseVisualStyleBackColor = true;
            this.btnXoaCV.Click += new System.EventHandler(this.btnXoaCV_Click);
            // 
            // btnSuaCV
            // 
            this.btnSuaCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaCV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCV.Location = new System.Drawing.Point(56, 92);
            this.btnSuaCV.Name = "btnSuaCV";
            this.btnSuaCV.Size = new System.Drawing.Size(185, 30);
            this.btnSuaCV.TabIndex = 30;
            this.btnSuaCV.Text = "Sửa chức vụ";
            this.btnSuaCV.UseVisualStyleBackColor = true;
            this.btnSuaCV.Click += new System.EventHandler(this.btnSuaCV_Click);
            // 
            // btnResetCV
            // 
            this.btnResetCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetCV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetCV.Location = new System.Drawing.Point(416, 92);
            this.btnResetCV.Name = "btnResetCV";
            this.btnResetCV.Size = new System.Drawing.Size(185, 30);
            this.btnResetCV.TabIndex = 41;
            this.btnResetCV.Text = "Reset";
            this.btnResetCV.UseVisualStyleBackColor = true;
            this.btnResetCV.Click += new System.EventHandler(this.btnResetCV_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTenCV);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtLCB);
            this.groupBox2.Controls.Add(this.txtMaCV);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 416);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Chức Vụ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(413, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Tên Chức Vụ";
            // 
            // txtTenCV
            // 
            this.txtTenCV.Location = new System.Drawing.Point(416, 102);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(254, 27);
            this.txtTenCV.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(53, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 59;
            this.label5.Text = "Lương Cơ Bản";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(53, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 58;
            this.label6.Text = "Mã Chức Vụ";
            // 
            // txtLCB
            // 
            this.txtLCB.Location = new System.Drawing.Point(56, 222);
            this.txtLCB.Name = "txtLCB";
            this.txtLCB.Size = new System.Drawing.Size(254, 27);
            this.txtLCB.TabIndex = 57;
            // 
            // txtMaCV
            // 
            this.txtMaCV.Location = new System.Drawing.Point(56, 102);
            this.txtMaCV.Name = "txtMaCV";
            this.txtMaCV.ReadOnly = true;
            this.txtMaCV.Size = new System.Drawing.Size(254, 27);
            this.txtMaCV.TabIndex = 56;
            // 
            // frmChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 667);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmChucVu";
            this.Text = "Chức Vụ";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChucVu)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvChucVu;
        private System.Windows.Forms.Button btnSearchCV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSearchCVName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemCV;
        private System.Windows.Forms.Button btnXoaCV;
        private System.Windows.Forms.Button btnSuaCV;
        private System.Windows.Forms.Button btnResetCV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLCB;
        private System.Windows.Forms.TextBox txtMaCV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenCV;
    }
}