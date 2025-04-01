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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace GUI.Forms
{
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
            Loads();
        }



        void Loads()
        {
            LoadListLoaiPhong();
            LoadTheme();
            PhanQuyen();
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



        //Phân quyền
        void PhanQuyen()
        {
            if (!CurrentUser.Instance.QuyenTaiKhoan) // Nếu là nhân viên
            {
                btnXoaLP.Enabled = false;

            }
        }





        void LoadListLoaiPhong()
        {
            var list = LoaiPhongBLL.Instance.GetListLoaiPhong();
            dtgvLoaiP.DataSource = list;
            dtgvLoaiP.Columns["HienThi"].Visible = false; // Ẩn cột HienThi
        }




        private void dtgvLoaiP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvLoaiP.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvLoaiP.Rows[e.RowIndex];

                txtMaLP.Text = selectRow.Cells[0].Value?.ToString() ?? "";
                txtTenLP.Text = selectRow.Cells[1].Value?.ToString() ?? "";
                txtGiaLP.Text = CurrencyFormatter.FormatToVND(selectRow.Cells[2].Value);
                txtSoNguoiTD.Text = selectRow.Cells[3].Value?.ToString() ?? "";
            }
        }

        private void btnThemLP_Click(object sender, EventArgs e)
        {
            string tenLoai = txtTenLP.Text.Trim();
            string giaTienStr = txtGiaLP.Text.Replace(" VND", "").Replace(",", "").Trim();
            string soNguoiToiDaStr = txtSoNguoiTD.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenLoai))
            {
                MessageBox.Show("Tên loại phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaLP;
            if (string.IsNullOrWhiteSpace(giaTienStr) || !decimal.TryParse(giaTienStr, out giaLP) || giaLP <= 0)
            {
                MessageBox.Show("Giá tiền phải là một số thực dương và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soNguoiTD;
            if (string.IsNullOrWhiteSpace(soNguoiToiDaStr) || !int.TryParse(soNguoiToiDaStr, out soNguoiTD) || soNguoiTD <= 0)
            {
                MessageBox.Show("Số người tối đa phải là một số nguyên dương và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoaiPhong newLoaiPhong = new LoaiPhong(0, tenLoai, giaLP, soNguoiTD);

            try
            {
                if (LoaiPhongBLL.Instance.InsertLoaiPhong(newLoaiPhong))
                {
                    MessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListLoaiPhong();
                }
                else
                {
                    MessageBox.Show("Thêm loại phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaLP_Click(object sender, EventArgs e)
        {
            if (dtgvLoaiP.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLoai = Convert.ToInt32(dtgvLoaiP.CurrentRow.Cells["MaLoai"].Value);
            string tenLoai = txtTenLP.Text.Trim();
            string giaTienStr = txtGiaLP.Text.Replace(" VND", "").Replace(",", "").Trim();
            string soNguoiToiDaStr = txtSoNguoiTD.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenLoai))
            {
                MessageBox.Show("Tên loại phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaLP;
            if (string.IsNullOrWhiteSpace(giaTienStr) || !decimal.TryParse(giaTienStr, out giaLP) || giaLP <= 0)
            {
                MessageBox.Show("Giá tiền phải là một số thực dương và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soNguoiToiDa;
            if (string.IsNullOrWhiteSpace(soNguoiToiDaStr) || !int.TryParse(soNguoiToiDaStr, out soNguoiToiDa) || soNguoiToiDa <= 0)
            {
                MessageBox.Show("Số người tối đa phải là một số nguyên dương và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoaiPhong updatedLoaiPhong = new LoaiPhong(maLoai, tenLoai, giaLP, soNguoiToiDa);

            try
            {
                if (LoaiPhongBLL.Instance.UpdateLoaiPhong(updatedLoaiPhong))
                {
                    MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListLoaiPhong();
                }
                else
                {
                    MessageBox.Show("Cập nhật loại phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLP_Click(object sender, EventArgs e)
        {
            if (dtgvLoaiP.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLoai = Convert.ToInt32(dtgvLoaiP.CurrentRow.Cells["MaLoai"].Value);
            string tenLoai = dtgvLoaiP.CurrentRow.Cells["TenLoai"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại phòng '{tenLoai}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                if (LoaiPhongBLL.Instance.DeleteLoaiPhong(maLoai))
                {
                    MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListLoaiPhong();
                }
                else
                {
                    MessageBox.Show("Xóa loại phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa loại phòng vì đang được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnResetLP_Click(object sender, EventArgs e)
        {
            txtMaLP.Clear();
            txtTenLP.Clear();
            txtGiaLP.Clear();
            txtSoNguoiTD.Clear();
        }






        private void btnSearchLP_Click(object sender, EventArgs e)
        {
            dtgvLoaiP.DataSource = LoaiPhongBLL.Instance.SearchLPByName(txtSearchLPName.Text);
        }

        private void txtSearchLPName_Enter(object sender, EventArgs e)
        {
            if (txtSearchLPName.Text == "Hãy nhập tên loại phòng cần tìm")
            {
                txtSearchLPName.Text = "";
                txtSearchLPName.ForeColor = Color.Black;
            }
        }

        private void txtSearchLPName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchLPName.Text))
            {
                txtSearchLPName.Text = "Hãy nhập tên loại phòng cần tìm";
                txtSearchLPName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchLPName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchLPName.Text) || txtSearchLPName.Text == "Hãy nhập tên loại phòng cần tìm")
            {
                LoadListLoaiPhong(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListLoaiPhong(); // Gọi lại danh sách vì hàm không có tham số
            }
        }
    }
}
