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

namespace GUI.Forms
{
    public partial class frmChucVu : Form
    {
        public frmChucVu()
        {
            InitializeComponent();
            Loads();
        }


        void Loads()
        {
            LoadListChucVu();
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
                btnXoaCV.Enabled = false;

            }
        }




        void LoadListChucVu()
        {
            var list = ChucVuBLL.Instance.GetListChucVu();
            dtgvChucVu.DataSource = list;
        }

        private void dtgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvChucVu.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvChucVu.Rows[e.RowIndex];
                txtMaCV.Text = selectRow.Cells[0].Value?.ToString() ?? "";
                txtTenCV.Text = selectRow.Cells[1].Value?.ToString() ?? "";
                //txtLCB.Text = selectRow.Cells[2].Value?.ToString() ?? "";
                txtLCB.Text = CurrencyFormatter.FormatToVND(selectRow.Cells[2].Value);

            }
        }



        private void btnThemCV_Click(object sender, EventArgs e)
        {
            string tenCV = txtTenCV.Text.Trim();
            string donGiaStr = txtLCB.Text.Replace(" VND", "").Replace(",", "").Trim();

            if (string.IsNullOrWhiteSpace(tenCV))
            {
                MessageBox.Show("Tên chức vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal donGia;
            if (string.IsNullOrWhiteSpace(donGiaStr) || !decimal.TryParse(donGiaStr, out donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là một số thực dương và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChucVu newChucVu = new ChucVu(0, tenCV, donGia);

            try
            {
                if (ChucVuBLL.Instance.InsertChucVu(newChucVu))
                {
                    MessageBox.Show("Thêm chức vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListChucVu();
                }
                else
                {
                    MessageBox.Show("Thêm chức vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            if (dtgvChucVu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCV = Convert.ToInt32(dtgvChucVu.CurrentRow.Cells["MaCV"].Value);
            string tenCV = txtTenCV.Text.Trim();
            string donGiaStr = txtLCB.Text.Replace(" VND", "").Replace(",", "").Trim();

            if (string.IsNullOrWhiteSpace(tenCV))
            {
                MessageBox.Show("Tên chức vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(donGiaStr, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là một số thực dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChucVu updatedChucVu = new ChucVu(maCV, tenCV, donGia);

            try
            {
                if (ChucVuBLL.Instance.UpdateChucVu(updatedChucVu))
                {
                    MessageBox.Show("Cập nhật chức vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListChucVu();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            if (dtgvChucVu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCV = Convert.ToInt32(dtgvChucVu.CurrentRow.Cells["MaCV"].Value);
            string tenCV = dtgvChucVu.CurrentRow.Cells["TenCV"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa chức vụ '{tenCV}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                if (ChucVuBLL.Instance.DeleteChucVu(maCV))
                {
                    MessageBox.Show("Xóa chức vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListChucVu();
                }
                else
                {
                    MessageBox.Show("Xóa chức vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa chức vụ vì đang được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetCV_Click(object sender, EventArgs e)
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
            txtLCB.Clear();
        }





        private void btnSearchCV_Click(object sender, EventArgs e)
        {
            dtgvChucVu.DataSource = ChucVuBLL.Instance.SearchCVByName(txtSearchCVName.Text);
        }

        private void txtSearchCVName_Enter(object sender, EventArgs e)
        {
            if (txtSearchCVName.Text == "Hãy nhập tên chức vụ cần tìm")
            {
                txtSearchCVName.Text = "";
                txtSearchCVName.ForeColor = Color.Black;
            }
        }

        private void txtSearchCVName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCVName.Text))
            {
                txtSearchCVName.Text = "Hãy nhập tên chức vụ cần tìm";
                txtSearchCVName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchCVName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCVName.Text) || txtSearchCVName.Text == "Hãy nhập tên chức vụ cần tìm")
            {
                LoadListChucVu(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListChucVu(); // Gọi lại danh sách (vì hàm không có tham số)
            }
        }
    }
}
