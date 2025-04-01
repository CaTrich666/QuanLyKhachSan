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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            Loads();
        }



        void Loads()
        {
            LoadListNhanVien();
            LoadComboBoxChucVu();
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
                btnXoaNV.Enabled = false;

            }
        }




        void LoadListNhanVien()
        {
            // Lấy danh sách nhân viên
            var list = NhanVienBLL.Instance.GetListNhanVien();

            // Tạo danh sách mới với giới tính dưới dạng chuỗi
            var modifiedList = list.Select(nv => new
            {
                nv.MaNV,
                nv.TenNV,
                nv.NgaySinh,
                GioiTinh = nv.GioiTinhNV ? "Nam" : "Nữ", // Chuyển đổi giới tính thành chuỗi
                nv.SdtNV,
                nv.MaCV,
                nv.HienThi
            }).ToList();

            // Gán dữ liệu cho DataGridView
            dtgvNhanVien.DataSource = modifiedList;
            dtgvNhanVien.Columns["HienThi"].Visible = false; // Ẩn cột HienThi

        }


        void LoadComboBoxChucVu()
        {
            List<ChucVu> danhSachChucVu = ChucVuBLL.Instance.GetListChucVu();
            cbChucVu.DataSource = danhSachChucVu;
            cbChucVu.DisplayMember = "TenCV";
            cbChucVu.ValueMember = "MaCV";
        }



        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvNhanVien.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = selectRow.Cells["MaNV"].Value?.ToString() ?? "";
                txtTenNV.Text = selectRow.Cells["TenNV"].Value?.ToString() ?? "";
                txtSDT.Text = selectRow.Cells["SdtNV"].Value?.ToString() ?? "";
                dtpNgaySinh.Value = Convert.ToDateTime(selectRow.Cells["NgaySinh"].Value);
                cbChucVu.SelectedValue = selectRow.Cells["MaCV"].Value;

                string gioiTinh = selectRow.Cells["GioiTinh"].Value?.ToString();
                if (gioiTinh == "Nam")
                {
                    rdoNam.Checked = true;
                    rdoNu.Checked = false;
                }
                else
                {
                    rdoNam.Checked = false;
                    rdoNu.Checked = true;
                }
            }
        }



        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string tenNV = txtTenNV.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value.Date; // Không cần phải dùng DateTime.TryParse ở đây vì dtpNgaySinh đã có giá trị hợp lệ
            string sdtNV = txtSDT.Text.Trim();
            bool gioiTinhNV = rdoNam.Checked;
            int maCV;

            if (string.IsNullOrWhiteSpace(tenNV))
            {
                MessageBox.Show("Tên nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem ngày sinh có hợp lệ hay không
            if (ngaySinh > DateTime.Now) // Ngày sinh không thể lớn hơn ngày hiện tại
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(sdtNV))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sdtNV = sdtNV.Replace(" ", "");
            if (!sdtNV.All(char.IsDigit) || sdtNV.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã chức vụ từ ComboBox
            if (cbChucVu.SelectedValue == null || !int.TryParse(cbChucVu.SelectedValue.ToString(), out maCV))
            {
                MessageBox.Show("Vui lòng chọn một chức vụ hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVien newNhanVien = new NhanVien(0, tenNV, ngaySinh, gioiTinhNV, sdtNV, maCV);

            try
            {
                if (NhanVienBLL.Instance.InsertNhanVien(newNhanVien))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (dtgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(dtgvNhanVien.CurrentRow.Cells["MaNV"].Value);
            string tenNV = txtTenNV.Text.Trim();
            string sdtNV = txtSDT.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value.Date; // Ngày sinh lấy từ DateTimePicker
            bool gioiTinhNV = rdoNam.Checked;
            int maCV;

            if (string.IsNullOrWhiteSpace(tenNV))
            {
                MessageBox.Show("Tên nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem ngày sinh có hợp lệ hay không
            if (ngaySinh > DateTime.Now) // Ngày sinh không thể lớn hơn ngày hiện tại
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(sdtNV))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sdtNV = sdtNV.Replace(" ", "");
            if (!sdtNV.All(char.IsDigit) || sdtNV.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã chức vụ từ ComboBox
            if (cbChucVu.SelectedValue == null || !int.TryParse(cbChucVu.SelectedValue.ToString(), out maCV))
            {
                MessageBox.Show("Vui lòng chọn một chức vụ hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVien updatedNhanVien = new NhanVien(maNV, tenNV, ngaySinh, gioiTinhNV, sdtNV, maCV);

            try
            {
                if (NhanVienBLL.Instance.UpdateNhanVien(updatedNhanVien))
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (dtgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(dtgvNhanVien.CurrentRow.Cells["MaNV"].Value);
            string tenNV = dtgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{maNV} - {tenNV}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                if (NhanVienBLL.Instance.DeleteNhanVien(maNV))
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đang được sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnResetNV_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            cbChucVu.SelectedIndex = 0;
        }




        private void btnSearchNV_Click(object sender, EventArgs e)
        {
            var list = NhanVienBLL.Instance.SearchNVByName(txtSearchNVName.Text); // Lấy danh sách nhân viên từ BLL

            // Chuyển đổi giới tính trước khi gán vào DataGridView
            dtgvNhanVien.DataSource = list.Select(nv => new
            {
                nv.MaNV,
                nv.TenNV,
                nv.NgaySinh,
                GioiTinh = nv.GioiTinhNV ? "Nam" : "Nữ", // Chuyển đổi kiểu bool string
                nv.SdtNV,
                nv.MaCV,
                nv.HienThi
            }).ToList();

            dtgvNhanVien.Columns["HienThi"].Visible = false; // Ẩn cột HienThi
        }

        private void txtSearchNVName_Enter(object sender, EventArgs e)
        {
            if (txtSearchNVName.Text == "Hãy nhập tên nhân viên cần tìm")
            {
                txtSearchNVName.Text = "";
                txtSearchNVName.ForeColor = Color.Black;
            }
        }

        private void txtSearchNVName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchNVName.Text))
            {
                txtSearchNVName.Text = "Hãy nhập tên nhân viên cần tìm";
                txtSearchNVName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchNVName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchNVName.Text) || txtSearchNVName.Text == "Hãy nhập tên nhân viên cần tìm")
            {
                LoadListNhanVien(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListNhanVien(); // Gọi lại danh sách vì hàm không có tham số
            }
        }
    }
}
