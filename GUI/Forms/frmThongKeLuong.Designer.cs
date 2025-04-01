namespace GUI.Forms
{
    partial class frmThongKeLuong
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
            this.dgvChiTietLuong = new System.Windows.Forms.DataGridView();
            this.dgvTongHopLuong = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXuatBangLuong = new System.Windows.Forms.Button();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHopLuong)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChiTietLuong
            // 
            this.dgvChiTietLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietLuong.Location = new System.Drawing.Point(6, 59);
            this.dgvChiTietLuong.Name = "dgvChiTietLuong";
            this.dgvChiTietLuong.RowHeadersWidth = 51;
            this.dgvChiTietLuong.RowTemplate.Height = 24;
            this.dgvChiTietLuong.Size = new System.Drawing.Size(1264, 200);
            this.dgvChiTietLuong.TabIndex = 0;
            this.dgvChiTietLuong.Enter += new System.EventHandler(this.dgvChiTietLuong_Enter);
            // 
            // dgvTongHopLuong
            // 
            this.dgvTongHopLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongHopLuong.Location = new System.Drawing.Point(6, 323);
            this.dgvTongHopLuong.Name = "dgvTongHopLuong";
            this.dgvTongHopLuong.RowHeadersWidth = 51;
            this.dgvTongHopLuong.RowTemplate.Height = 24;
            this.dgvTongHopLuong.Size = new System.Drawing.Size(1261, 200);
            this.dgvTongHopLuong.TabIndex = 1;
            this.dgvTongHopLuong.Enter += new System.EventHandler(this.dgvTongHopLuong_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvChiTietLuong);
            this.panel1.Controls.Add(this.dgvTongHopLuong);
            this.panel1.Location = new System.Drawing.Point(12, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1270, 526);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(29, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lương Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thông Tin Chi Tiết Tổng Tiền Từng Ca Làm";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXuatBangLuong);
            this.panel2.Controls.Add(this.btnTinhLuong);
            this.panel2.Controls.Add(this.txtMaNV);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpTuNgay);
            this.panel2.Controls.Add(this.dtpDenNgay);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1270, 111);
            this.panel2.TabIndex = 3;
            // 
            // btnXuatBangLuong
            // 
            this.btnXuatBangLuong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnXuatBangLuong.Location = new System.Drawing.Point(1032, 30);
            this.btnXuatBangLuong.Name = "btnXuatBangLuong";
            this.btnXuatBangLuong.Size = new System.Drawing.Size(235, 46);
            this.btnXuatBangLuong.TabIndex = 89;
            this.btnXuatBangLuong.Text = "Xuất bảng lương";
            this.btnXuatBangLuong.UseVisualStyleBackColor = true;
            this.btnXuatBangLuong.Click += new System.EventHandler(this.btnXuatBangLuong_Click);
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnTinhLuong.Location = new System.Drawing.Point(874, 30);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(137, 46);
            this.btnTinhLuong.TabIndex = 88;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtMaNV.Location = new System.Drawing.Point(215, 46);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 30);
            this.txtMaNV.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(37, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 24);
            this.label5.TabIndex = 86;
            this.label5.Text = "Mã Nhân Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(608, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 24);
            this.label4.TabIndex = 85;
            this.label4.Text = "Đến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(327, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 24);
            this.label3.TabIndex = 84;
            this.label3.Text = "Từ:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(403, 45);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(175, 30);
            this.dtpTuNgay.TabIndex = 83;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(668, 44);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(175, 30);
            this.dtpDenNgay.TabIndex = 82;
            // 
            // frmThongKeLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 667);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmThongKeLuong";
            this.Text = "Thống Kê Lương";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHopLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTietLuong;
        private System.Windows.Forms.DataGridView dgvTongHopLuong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXuatBangLuong;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
    }
}