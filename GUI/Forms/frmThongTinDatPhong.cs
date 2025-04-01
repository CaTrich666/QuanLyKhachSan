using BLL;
using DTO;
using GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace GUI.Forms
{
    public partial class frmThongTinDatPhong : Form
    {
        public frmThongTinDatPhong()
        {
            InitializeComponent();
            Loads();
        }





        void Loads()
        {
            LoadTheme();
            LoadListPhieuDat();
            LoadComboBoxPieuDat();

            // Cấu hình cho tất cả DateTimePicker
            SetupDateTimePicker(dtpNgayDat);
            SetupDateTimePicker(dtpNNP);
            SetupDateTimePicker(dtpNTP);
        }



        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            groupBox1.ForeColor = ThemeColor.SecondaryColor;
            groupBox2.ForeColor = ThemeColor.PrimaryColor;
            groupBox3.ForeColor = ThemeColor.SecondaryColor;
            groupBox4.ForeColor = ThemeColor.PrimaryColor;
        }



        void LoadListPhieuDat()
        {
            var list = PhieuDatBLL.Instance.GetListPhieuDat();
            dtgvPhieuDat.DataSource = list;
        }




        void SetupDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy HH:mm";
            dtp.ShowUpDown = true;
        }




        void LoadComboBoxPieuDat()
        {
            cbTTPD.DataSource = new List<string> { "Đang chờ", "Đã xác nhận", "Đã nhận phòng", "Hoàn thành", "Đã hủy" };
        }




        private DateTime ConvertToDateTime(object value)
        {
            return (value != null && DateTime.TryParse(value.ToString(), out DateTime date)) ? date : DateTime.Now;
        }


        private void dtgvPhieuDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dtgvPhieuDat.Rows.Count) return;
            { 
                DataGridViewRow row = dtgvPhieuDat.Rows[e.RowIndex];

                txtMaPD.Text = row.Cells["MAPD"].Value?.ToString() ?? "";
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
                cbTTPD.Text = row.Cells["TRANGTHAIPD"].Value?.ToString() ?? "";
                txtSoNguoi.Text = row.Cells["SONGUOI"].Value?.ToString() ?? "0";
                txtTienCoc.Text = CurrencyFormatter.FormatToVND(row.Cells["TIENCOC"].Value);
                txtMaNV.Text = row.Cells["MANV"].Value?.ToString() ?? "0";
                dtpNgayDat.Value = ConvertToDateTime(row.Cells["NGAYDAT"].Value);
                dtpNNP.Value = ConvertToDateTime(row.Cells["NGAYNHANPHONG"].Value);
                dtpNTP.Value = ConvertToDateTime(row.Cells["NGAYTRAPHONG"].Value);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtgvPhieuDat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu đặt cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maPD = Convert.ToInt32(dtgvPhieuDat.CurrentRow.Cells["MAPD"].Value);
                string trangThaiHienTai = dtgvPhieuDat.CurrentRow.Cells["TRANGTHAIPD"].Value?.ToString() ?? "Đang chờ";
                string trangThaiMoi = cbTTPD.SelectedItem as string ?? "Đang chờ";

                // Kiểm tra trạng thái hợp lệ
                if (!PhieuDatBLL.Instance.IsTrangThaiHopLe(trangThaiHienTai, trangThaiMoi))
                {
                    MessageBox.Show($"Không thể cập nhật trạng thái từ '{trangThaiHienTai}' lên '{trangThaiMoi}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soNguoi = int.TryParse(txtSoNguoi.Text, out int tempSoNguoi) ? tempSoNguoi : 0;
                string tienCocText = txtTienCoc.Text.Replace(" VND", "").Replace(",", "").Trim();
                decimal tienCoc = decimal.TryParse(tienCocText, out decimal tempTienCoc) ? tempTienCoc : 0;
                DateTime ngayDat = dtpNgayDat.Value;
                DateTime ngayNhanPhong = dtpNNP.Value;
                DateTime ngayTraPhong = dtpNTP.Value;
                string cccd = txtCCCD.Text.Trim();
                int maNV = int.TryParse(txtMaNV.Text, out int tempMaNV) ? tempMaNV : 0;

                if (soNguoi <= 0 || tienCoc < 0 || string.IsNullOrEmpty(cccd) || maNV <= 0)
                {
                    MessageBox.Show("Vui lòng kiểm tra các trường dữ liệu đầu vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PhieuDat updatedPhieuDat = new PhieuDat(maPD, soNguoi, trangThaiMoi, tienCoc, ngayDat, ngayNhanPhong, ngayTraPhong, cccd, maNV);

                bool isUpdateSuccess = PhieuDatBLL.Instance.UpdatePhieuDat(updatedPhieuDat);

                if (isUpdateSuccess)
                {
                    MessageBox.Show("Cập nhật phiếu đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListPhieuDat();
                }
                else
                {
                    MessageBox.Show("Cập nhật phiếu đặt thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            
        }



        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dtgvPhieuDat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu đặt cần xác nhận.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbTTPD.SelectedItem = "Đã xác nhận";

            btnCapNhat_Click(sender, e);


        }





        private void btnSearchPD_Click(object sender, EventArgs e)
        {
            dtgvPhieuDat.DataSource = PhieuDatBLL.Instance.SearchPhieuDat(txtSearchPD.Text);
        }

        private void txtSearchPD_Enter(object sender, EventArgs e)
        {
            if (txtSearchPD.Text == "Hãy nhập mã phiếu đặt cần tìm")
            {
                txtSearchPD.Text = "";
                txtSearchPD.ForeColor = Color.Black;
            }
        }

        private void txtSearchPD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPD.Text))
            {
                txtSearchPD.Text = "Hãy nhập mã phiếu đặt cần tìm";
                txtSearchPD.ForeColor = Color.Gray;
            }
        }

        private void txtSearchPD_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPD.Text) || txtSearchPD.Text == "Hãy nhập mã phiếu đặt cần tìm")
            {
                LoadListPhieuDat();
            }
            else
            {
                LoadListPhieuDat();
            }
        }


    }
}
