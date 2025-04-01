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
using static System.Net.Mime.MediaTypeNames;

namespace GUI.Forms
{
    public partial class frmThietBi : Form
    {
        public frmThietBi()
        {
            InitializeComponent();
            Loads();
        }


        void Loads()
        {
            LoadListThietBi();
            LoadComboBoxThietBi();
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
                btnXoaTB.Enabled = false;

            }
        }





        void LoadListThietBi()
        {
            var list = ThietBiBLL.Instance.GetListThietBi();
            dtgvThietBi.DataSource = list;
        }


        
        private void dtgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvThietBi.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvThietBi.Rows[e.RowIndex];

                txtMaTB.Text = selectRow.Cells[0].Value?.ToString() ?? "";
                txtTenTB.Text = selectRow.Cells[1].Value?.ToString() ?? "";
                cbTTTB.Text = selectRow.Cells[2].Value?.ToString() ?? "";
                txtVTSD.Text = selectRow.Cells[4].Value?.ToString() ?? "";
                cbMaP.SelectedValue = selectRow.Cells[3].Value ?? 0;
            }
        }


        void LoadComboBoxThietBi()
        {
            cbTTTB.DataSource = new List<string> { "Bình thường", "Hỏng", "Đang sửa chữa" };

            List<Phong> danhSachThietBi = PhongBLL.Instance.GetListPhong();

            danhSachThietBi.Insert(0, new Phong(0, "Không thuộc phòng", "", 0));

            cbMaP.DataSource = danhSachThietBi;
            cbMaP.DisplayMember = "TenPhong";
            cbMaP.ValueMember = "MaPhong";

            cbMaP.SelectedValue = 0; // Mặc định là "Không thuộc phòng"
        }



        private void btnThemTB_Click(object sender, EventArgs e)
        {
            string tenTB = txtTenTB.Text.Trim();
            string tinhTrangTB = cbTTTB.SelectedItem?.ToString();
            string viTriSuDung = txtVTSD.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenTB))
            {
                MessageBox.Show("Tên thiết bị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tinhTrangTB))
            {
                MessageBox.Show("Vui lòng chọn tình trạng thiết bị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? maPhong = null;
            if (cbMaP.SelectedValue != null)
            {
                if (int.TryParse(cbMaP.SelectedValue.ToString(), out int parsedMaPhong))
                {
                    maPhong = (parsedMaPhong == 0) ? (int?)null : parsedMaPhong;
                }
                else
                {
                    MessageBox.Show("Mã phòng không hợp lệ! Vui lòng chọn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            ThietBi newThietBi = new ThietBi(0, tenTB, tinhTrangTB, maPhong, viTriSuDung);

            try
            {
                if (ThietBiBLL.Instance.InsertThietBi(newThietBi))
                {
                    MessageBox.Show("Thêm thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListThietBi();
                }
                else
                {
                    MessageBox.Show("Thêm thiết bị thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnXoaTB_Click(object sender, EventArgs e)
        {
            if (dtgvThietBi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTB = Convert.ToInt32(dtgvThietBi.CurrentRow.Cells["MaTB"].Value);
            string tenTB = dtgvThietBi.CurrentRow.Cells["TenTB"].Value.ToString();


            // Xác nhận xóa
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa thiết bị '{tenTB}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (ThietBiBLL.Instance.DeleteThietBi(maTB))
                {
                    MessageBox.Show("Xóa thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListThietBi();
                }
                else
                {
                    MessageBox.Show("Thiết bị không tồn tại hoặc không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnSuaTB_Click(object sender, EventArgs e)
        {
            if (dtgvThietBi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTB = Convert.ToInt32(dtgvThietBi.CurrentRow.Cells["MaTB"].Value);
            string tenTB = txtTenTB.Text.Trim();
            string tinhTrangTB = cbTTTB.SelectedItem?.ToString();
            string viTriSuDung = txtVTSD.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(tenTB))
            {
                MessageBox.Show("Tên thiết bị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tinhTrangTB))
            {
                MessageBox.Show("Vui lòng chọn tình trạng thiết bị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý Mã phòng (Có thể để trống)
            int? maPhong = null;
            if (cbMaP.SelectedValue != null && int.TryParse(cbMaP.SelectedValue.ToString(), out int parsedMaPhong))
            {
                maPhong = (parsedMaPhong == 0) ? (int?)null : parsedMaPhong;
            }
            else if (cbMaP.SelectedValue != null)
            {
                MessageBox.Show("Mã phòng phải là số nguyên hợp lệ hoặc để trống nếu không có phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng thiết bị với dữ liệu mới
            ThietBi updatedThietBi = new ThietBi(maTB, tenTB, tinhTrangTB, maPhong, viTriSuDung);

            try
            {
                if (ThietBiBLL.Instance.UpdateThietBi(updatedThietBi))  // Không cần truyền maTB riêng lẻ
                {
                    MessageBox.Show("Cập nhật thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListThietBi();
                }
                else
                {
                    MessageBox.Show("Cập nhật thiết bị thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnResetTB_Click(object sender, EventArgs e)
        {
            txtMaTB.Clear();
            txtTenTB.Clear();
            txtVTSD.Clear();
            cbTTTB.SelectedIndex = 0;
            cbMaP.SelectedIndex = 0;
        }







        private void btnSearchTB_Click(object sender, EventArgs e)
        {
            dtgvThietBi.DataSource = ThietBiBLL.Instance.SearchTBByName(txtSearchTBName.Text);
        }





        private void txtSearchTBName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchTBName.Text) || txtSearchTBName.Text == "Hãy nhập tên thiết bị cần tìm")
            {
                LoadListThietBi(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListThietBi(); // Gọi lại danh sách
            }
        }

        private void txtSearchTBName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchTBName.Text))
            {
                txtSearchTBName.Text = "Hãy nhập tên thiết bị cần tìm";
                txtSearchTBName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchTBName_Enter(object sender, EventArgs e)
        {
            if (txtSearchTBName.Text == "Hãy nhập tên thiết bị cần tìm")
            {
                txtSearchTBName.Text = "";
                txtSearchTBName.ForeColor = Color.Black;
            }
        }
    }
}
