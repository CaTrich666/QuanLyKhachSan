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
    public partial class frmTaiKhoan : Form
    {

        // Tạo sự kiện để thông báo khi tài khoản được cập nhật
        public event Action OnTaiKhoanUpdated;



        public frmTaiKhoan()
        {
            InitializeComponent();
            Loads();
        }

        void Loads()
        {
            LoadListTaiKhoan();
            LoadTheme();
            LoadComboBoxTaiKhoan();
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
            groupBox3.ForeColor = ThemeColor.PrimaryColor;
            groupBox4.ForeColor = ThemeColor.PrimaryColor;
        }
        




        void LoadListTaiKhoan()
        {
            // Lấy danh sách tài khoản
            var list = TaiKhoanBLL.Instance.GetListTaiKhoan();

            // Tạo danh sách mới với giá trị Role dưới dạng chuỗi
            var modifiedList = list.Select(item => new
            {
                item.UserName,
                item.PassWord,
                Role = item.Role ? "Quản lý" : "Nhân viên",  // Chuyển đổi Role thành chuỗi
                item.MaNV
            }).ToList();

            // Gán dữ liệu cho DataGridView
            dtgvTaiKhoan.DataSource = modifiedList;
        }



        void LoadComboBoxTaiKhoan()
        {
            // Thêm các mục quyền vào ComboBox
            cbQuyen.Items.Add("Quản lý");
            cbQuyen.Items.Add("Nhân viên");

            // Đặt mặc định cho ComboBox
            cbQuyen.SelectedIndex = 0; //mặc định chọn "Quản lý"
        }


        private void dtgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvTaiKhoan.Rows.Count) // Kiểm tra chỉ số hợp lệ
            {
                DataGridViewRow selectedRow = dtgvTaiKhoan.Rows[e.RowIndex];

                // Gán dữ liệu vào các điều khiển trên form
                txtTenTaiKhoan.Text = selectedRow.Cells["UserName"].Value?.ToString() ?? "";
                txtMatKhau.Text = selectedRow.Cells["PassWord"].Value?.ToString() ?? "";

                // Lấy giá trị quyền và gán vào ComboBox (chuyển từ chuỗi "Quản lý" hoặc "Nhân viên" sang chỉ mục)
                string roleValue = selectedRow.Cells["Role"].Value?.ToString() ?? "";
                if (roleValue == "Quản lý")
                {
                    cbQuyen.SelectedIndex = 0; // Chỉ mục 0 là "Quản lý"
                }
                else if (roleValue == "Nhân viên")
                {
                    cbQuyen.SelectedIndex = 1; // Chỉ mục 1 là "Nhân viên"
                }

                txtMaNhanVien.Text = selectedRow.Cells["MaNV"].Value?.ToString() ?? "";
            }
        }


        private void btnThemTK_Click(object sender, EventArgs e)
        {
            string userName = txtTenTaiKhoan.Text.Trim();
            string passWord = txtMatKhau.Text.Trim();
            string maNVText = txtMaNhanVien.Text.Trim();

            // Kiểm tra không để trống
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra Mã nhân viên có phải số không
            if (!int.TryParse(maNVText, out int maNV) || maNV <= 0)
            {
                MessageBox.Show("Mã nhân viên phải là số nguyên hợp lệ và không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool role = cbQuyen.SelectedIndex == 0; // "Quản lý" (true), "Nhân viên" (false)

            TaiKhoan newAccount = new TaiKhoan(userName, passWord, role, maNV);

            try
            {
                if (TaiKhoanBLL.Instance.InsertAccount(newAccount))
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính (Primary Key Violation)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại (Foreign Key Violation)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            // Lấy tên tài khoản cũ từ DataGridView hoặc nguồn dữ liệu gốc
            string oldUserName = dtgvTaiKhoan.CurrentRow.Cells["UserName"].Value.ToString();
            string newUserName = txtTenTaiKhoan.Text.Trim();
            string passWord = txtMatKhau.Text.Trim();
            string maNVText = txtMaNhanVien.Text.Trim();

            // Kiểm tra không để trống
            if (string.IsNullOrWhiteSpace(newUserName))
            {
                MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra Mã nhân viên có phải số không
            if (!int.TryParse(maNVText, out int maNV) || maNV <= 0)
            {
                MessageBox.Show("Mã nhân viên phải là số nguyên hợp lệ và không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool role = cbQuyen.SelectedIndex == 0; // "Quản lý" (true), "Nhân viên" (false)

            TaiKhoan updatedAccount = new TaiKhoan(newUserName, passWord, role, maNV);

            try
            {
                if (!TaiKhoanBLL.Instance.UpdateAccount(oldUserName, updatedAccount))
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại. Tên tài khoản đã tồn tại hoặc dữ liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật thông tin tài khoản hiện tại nếu người dùng đang đăng nhập sửa tài khoản của chính mình
                if (CurrentUser.Instance.TenTaiKhoan == oldUserName)
                {
                    CurrentUser.Instance.SetUser(newUserName, role, CurrentUser.Instance.MaNhanVien);
                }

                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadListTaiKhoan();

                // Gọi sự kiện cập nhật form cha
                OnTaiKhoanUpdated?.Invoke();

                // Đảm bảo giao diện được cập nhật ngay
                this.Refresh();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính (Primary Key Violation)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại (Foreign Key Violation)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            string userName = txtTenTaiKhoan.Text.Trim();

            // Kiểm tra nếu tài khoản trống
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu tài khoản đang đăng nhập
            if (userName == CurrentUser.Instance.TenTaiKhoan)  // CurrentUser là biến lưu tài khoản đang đăng nhập
            {
                MessageBox.Show("Bạn không thể xóa tài khoản đang đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hộp thoại xác nhận
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{userName}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (TaiKhoanBLL.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListTaiKhoan(); // Cập nhật danh sách
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại hoặc không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại
                {
                    MessageBox.Show("Không thể xóa tài khoản vì có dữ liệu liên quan trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa tài khoản. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetTK_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtMaNhanVien.Clear();
            cbQuyen.SelectedIndex = 0;
        }







        private void btnSearchTK_Click(object sender, EventArgs e)
        {
            dtgvTaiKhoan.DataSource = TaiKhoanBLL.Instance.SearchTKByName(txtSearchTKName.Text);
        }

        private void txtSearchTKName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchTKName.Text))
            {
                txtSearchTKName.Text = "Hãy nhập tên tài khoản cần tìm";
                txtSearchTKName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchTKName_Enter(object sender, EventArgs e)
        {
            if (txtSearchTKName.Text == "Hãy nhập tên tài khoản cần tìm")
            {
                txtSearchTKName.Text = "";
                txtSearchTKName.ForeColor = Color.Black;
            }
        }

        private void txtSearchTKName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchTKName.Text) || txtSearchTKName.Text == "Hãy nhập tên tài khoản cần tìm")
            {
                LoadListTaiKhoan(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListTaiKhoan(); // Gọi lại danh sách
            }
        }
    }
}
