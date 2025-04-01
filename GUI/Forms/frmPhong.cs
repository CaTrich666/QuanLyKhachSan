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
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
            Loads();
        }


        void Loads()
        {
            LoadTheme();
            LoadListPhong();
            LoadComboBoxPhong();
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
                btnXoaP.Enabled = false;

            }
        }






        void LoadListPhong()
        {
            var list = PhongBLL.Instance.GetListPhong();
            dtgvPhong.DataSource = list;
        }


        private void dtgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvPhong.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvPhong.Rows[e.RowIndex];

                txtMaP.Text = selectRow.Cells[0].Value?.ToString() ?? "";
                txtTenP.Text = selectRow.Cells[1].Value?.ToString() ?? "";
                cbTTP.Text = selectRow.Cells[2].Value?.ToString() ?? "";
                cbLoaiP.SelectedValue = selectRow.Cells[3].Value;
            }
        }


        void LoadComboBoxPhong()
        {
            cbTTP.DataSource = new List<string> { "Trống", "Đã đặt", "Đang sử dụng" };

            List<LoaiPhong> danhSachLoaiPhong = LoaiPhongBLL.Instance.GetListLoaiPhong();

            cbLoaiP.DataSource = danhSachLoaiPhong;
            cbLoaiP.DisplayMember = "HienThi";
            cbLoaiP.ValueMember = "MaLoai";
        }



        private void btnThemP_Click(object sender, EventArgs e)
        {
            string tenPhong = txtTenP.Text.Trim();
            string tinhTrang = cbTTP.SelectedItem?.ToString();
            int? maLoai = cbLoaiP.SelectedValue != null ? (int?)Convert.ToInt32(cbLoaiP.SelectedValue) : null;

            // Kiểm tra tên phòng
            if (string.IsNullOrWhiteSpace(tenPhong))
            {
                MessageBox.Show("Tên phòng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Phong newPhong = new Phong(0, tenPhong, tinhTrang, maLoai.Value);

            try
            {
                if (PhongBLL.Instance.InsertPhong(newPhong))
                {
                    MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListPhong();
                }
                else
                {
                    MessageBox.Show("Thêm phòng thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaP_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn phòng nào để sửa chưa
            if (dtgvPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin phòng từ dòng hiện tại
            int maPhong = Convert.ToInt32(dtgvPhong.CurrentRow.Cells["MaPhong"].Value);
            string tenPhong = txtTenP.Text.Trim();
            string tinhTrangHienTai = dtgvPhong.CurrentRow.Cells["TinhTrangP"].Value?.ToString() ?? "Trống";
            string tinhTrangMoi = cbTTP.SelectedItem?.ToString();
            int? maLoai = cbLoaiP.SelectedValue != null ? (int?)Convert.ToInt32(cbLoaiP.SelectedValue) : null;

            // Kiểm tra tên phòng
            if (string.IsNullOrWhiteSpace(tenPhong))
            {
                MessageBox.Show("Tên phòng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trạng thái phòng hợp lệ
            if (!PhongBLL.Instance.IsTrangThaiPhongHopLe(tinhTrangHienTai, tinhTrangMoi))
            {
                MessageBox.Show($"Không thể cập nhật trạng thái từ '{tinhTrangHienTai}' lên '{tinhTrangMoi}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng phòng với dữ liệu mới
            Phong updatedPhong = new Phong(maPhong, tenPhong, tinhTrangMoi, maLoai.Value);

            try
            {
                if (PhongBLL.Instance.UpdatePhong(updatedPhong))
                {
                    MessageBox.Show("Cập nhật phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListPhong(); // Tải lại danh sách phòng
                }
                else
                {
                    MessageBox.Show("Cập nhật phòng thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaP_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn phòng nào để xóa chưa
            if (dtgvPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phòng từ dòng hiện tại
            int maPhong = Convert.ToInt32(dtgvPhong.CurrentRow.Cells["MaPhong"].Value);
            string tenPhong = dtgvPhong.CurrentRow.Cells["TenPhong"].Value.ToString();

            // Xác nhận xóa
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng '{tenPhong}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (PhongBLL.Instance.DeletePhong(maPhong))
                {
                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListPhong(); // Tải lại danh sách phòng
                }
                else
                {
                    MessageBox.Show("Phòng không tồn tại hoặc không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnResetP_Click(object sender, EventArgs e)
        {
            txtMaP.Clear();
            txtTenP.Clear();
            cbTTP.SelectedIndex = 0;
            cbLoaiP.SelectedIndex = 0;
        }







        private void btnSearchPhong_Click(object sender, EventArgs e)
        {
            dtgvPhong.DataSource = PhongBLL.Instance.SearchPhongByName(txtSearchPhongName.Text);
        }

        private void txtSearchPhongName_Enter(object sender, EventArgs e)
        {
            if (txtSearchPhongName.Text == "Hãy nhập tên phòng cần tìm")
            {
                txtSearchPhongName.Text = "";
                txtSearchPhongName.ForeColor = Color.Black;
            }
        }

        private void txtSearchPhongName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPhongName.Text))
            {
                txtSearchPhongName.Text = "Hãy nhập tên phòng cần tìm";
                txtSearchPhongName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchPhongName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchPhongName.Text) || txtSearchPhongName.Text == "Hãy nhập tên phòng cần tìm")
            {
                LoadListPhong(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListPhong(); // Gọi lại danh sách
            }
        }







        





    }
}
