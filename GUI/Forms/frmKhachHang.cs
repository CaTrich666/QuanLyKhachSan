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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI.Forms
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            Loads();
        }



        void Loads()
        {
            LoadListKhachHang();
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
                btnXoaKH.Enabled = false;

            }
        }



        void LoadListKhachHang()
        {
            // Lấy danh sách nhân viên
            var list = KhachHangBLL.Instance.GetListKhachHang();

            // Tạo danh sách mới với giới tính dưới dạng chuỗi
            var modifiedList = list.Select(kh => new
            {
                kh.CCCD,
                kh.TenKH,
                kh.SDT_KH,
                GioiTinh_KH = kh.GioiTinh_KH ? "Nam" : "Nữ", // Chuyển đổi giới tính thành chuỗi
                kh.DiaChi,
            }).ToList();

            // Gán dữ liệu cho DataGridView
            dtgvKhachHang.DataSource = modifiedList;
        }




        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvKhachHang.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvKhachHang.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox
                txtCCCD.Text = selectRow.Cells["CCCD"].Value?.ToString() ?? "";
                txtTenKH.Text = selectRow.Cells["TenKH"].Value?.ToString() ?? "";
                txtSDT.Text = selectRow.Cells["SDT_KH"].Value?.ToString() ?? "";
                txtDiaChi.Text = selectRow.Cells["DiaChi"].Value?.ToString() ?? "";

                // Xử lý giới tính với RadioButton
                string gioiTinh = selectRow.Cells["GioiTinh_KH"].Value?.ToString();
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

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdtKH = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            bool gioiTinhKH = rdoNam.Checked; // Nam = true, Nữ = false

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cccd.All(char.IsDigit) || cccd.Length != 12)
            {
                MessageBox.Show("CCCD phải có đúng 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(sdtKH))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sdtKH = sdtKH.Replace(" ", "");
            if (!sdtKH.All(char.IsDigit) || sdtKH.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng khách hàng
            KhachHang newKhachHang = new KhachHang(cccd, tenKH, sdtKH, gioiTinhKH, diaChi);

            try
            {
                // Gọi BLL để thêm khách hàng
                if (KhachHangBLL.Instance.InsertKhachHang(newKhachHang))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListKhachHang(); // Cập nhật danh sách khách hàng
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính (Primary Key Violation)
                {
                    MessageBox.Show("CCCD đã tồn tại. Vui lòng nhập CCCD khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (dtgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Lấy CCCD cũ từ DataGridView hoặc nguồn dữ liệu gốc
            string oldCCCD = dtgvKhachHang.CurrentRow.Cells["CCCD"].Value.ToString();
            string newCCCD = txtCCCD.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdtKH = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            bool gioiTinhKH = rdoNam.Checked; // Nam (true), Nữ (false)

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(newCCCD))
            {
                MessageBox.Show("Vui lòng nhập CCCD!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!newCCCD.All(char.IsDigit) || newCCCD.Length != 12)
            {
                MessageBox.Show("CCCD phải có đúng 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(sdtKH))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sdtKH = sdtKH.Replace(" ", "");
            if (!sdtKH.All(char.IsDigit) || sdtKH.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng khách hàng mới
            KhachHang updatedCustomer = new KhachHang(newCCCD, tenKH, sdtKH, gioiTinhKH, diaChi);

            try
            {
                if (!KhachHangBLL.Instance.UpdateKhachHang(oldCCCD, updatedCustomer))
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại. CCCD đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListKhachHang();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính (Primary Key Violation)
                {
                    MessageBox.Show("CCCD đã tồn tại. Vui lòng nhập CCCD khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (dtgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cccd = dtgvKhachHang.CurrentRow.Cells["CCCD"].Value.ToString();
            string tenKH = dtgvKhachHang.CurrentRow.Cells["TENKH"].Value.ToString();


            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{cccd} - {tenKH}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            try
            {
                if (KhachHangBLL.Instance.DeleteKhachHang(cccd))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListKhachHang();
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa khách hàng vì đang lưu trữ thông tin trong phiếu đặt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }



        private void btnResetKH_Click(object sender, EventArgs e)
        {
            txtCCCD.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            rdoNam.Checked = false;
            rdoNu.Checked = false;
        }





        private void btnSearchKH_Click(object sender, EventArgs e)
        {
            var list = KhachHangBLL.Instance.SearchKHByName(txtSearchKHName.Text); // Lấy danh sách khách hàng từ BLL

            // Chuyển đổi giới tính trước khi gán vào DataGridView
            dtgvKhachHang.DataSource = list.Select(kh => new
            {
                kh.CCCD,
                kh.TenKH,
                kh.SDT_KH,
                GioiTinh_KH = kh.GioiTinh_KH ? "Nam" : "Nữ", // Chuyển đổi kiểu bool string
                kh.DiaChi,
            }).ToList();
        }

        private void txtSearchKHName_Enter(object sender, EventArgs e)
        {
            if (txtSearchKHName.Text == "Hãy nhập tên khách hàng cần tìm")
            {
                txtSearchKHName.Text = "";
                txtSearchKHName.ForeColor = Color.Black;
            }
        }

        private void txtSearchKHName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchKHName.Text))
            {
                txtSearchKHName.Text = "Hãy nhập tên khách hàng cần tìm";
                txtSearchKHName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchKHName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchKHName.Text) || txtSearchKHName.Text == "Hãy nhập tên khách hàng cần tìm")
            {
                LoadListKhachHang(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListKhachHang(); // Gọi lại danh sách vì hàm không có tham số
            }
        }
    }
}
