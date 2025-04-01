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
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {
            InitializeComponent();
            Loads();
        }


        void Loads()
        {
            LoadTheme();
            LoadListDichVu();
            LoadComboBoxDichVu();
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
                btnXoaDV.Enabled = false;

            }
        }






        void LoadListDichVu()
        {
            // Lấy danh sách dịch vụ
            var list = DichVuBLL.Instance.GetListDichVu();

            // Tạo danh sách mới với trạng thái dưới dạng chuỗi
            var modifiedList = list.Select(item => new
            {
                item.MaDV,
                item.TenDV,
                item.GiaDV,
                TRANGTHAI = item.TrangThaiDV ? "Đang hoạt động" : "Ngừng hoạt động" // Chuyển đổi trạng thái thành chuỗi
            }).ToList();

            // Gán dữ liệu cho DataGridView
            dtgvDichVu.DataSource = modifiedList;
        }




        void LoadComboBoxDichVu()
        {
            // Thêm các mục trạng thái vào ComboBox
            cbTTDV.Items.Add("Đang hoạt động");
            cbTTDV.Items.Add("Ngừng hoạt động");

            // Đặt mặc định cho ComboBox
            cbTTDV.SelectedIndex = 0; //mặc định chọn "Đang hoạt động"
        }


        private void dtgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvDichVu.Rows.Count) // Kiểm tra chỉ số hợp lệ
            {
                DataGridViewRow selectedRow = dtgvDichVu.Rows[e.RowIndex];

                // Gán dữ liệu vào các điều khiển trên form
                txtMaDV.Text = selectedRow.Cells["MADV"].Value?.ToString() ?? "";
                txtTenDV.Text = selectedRow.Cells["TenDV"].Value?.ToString() ?? "";
                txtGiaDV.Text = CurrencyFormatter.FormatToVND(selectedRow.Cells["GiaDV"].Value);

                // Lấy giá trị trạng thái và gán vào ComboBox (chuyển từ chuỗi "Đang hoạt động" hoặc "Ngừng hoạt động" sang chỉ mục)
                string trangThaiValue = selectedRow.Cells["TRANGTHAI"].Value?.ToString() ?? "";
                if (trangThaiValue == "Đang hoạt động")
                {
                    cbTTDV.SelectedIndex = 0; // Chỉ mục 0 là "Đang hoạt động"
                }
                else if (trangThaiValue == "Ngừng hoạt động")
                {
                    cbTTDV.SelectedIndex = 1; // Chỉ mục 1 là "Ngừng hoạt động"
                }

                
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string tenDichVu = txtTenDV.Text.Trim();
            string giaDichVuText = txtGiaDV.Text.Replace(" VND", "").Replace(",", "").Trim();

            // Kiểm tra không để trống
            if (string.IsNullOrWhiteSpace(tenDichVu))
            {
                MessageBox.Show("Tên dịch vụ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(giaDichVuText))
            {
                MessageBox.Show("Giá dịch vụ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá dịch vụ có phải số không
            if (!decimal.TryParse(giaDichVuText, out decimal giaDichVu) || giaDichVu <= 0)
            {
                MessageBox.Show("Giá dịch vụ phải là số hợp lệ và lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool trangThaiDV = cbTTDV.SelectedIndex == 0; // "Kích hoạt" (true), "Không kích hoạt" (false)

            DichVu newDichVu = new DichVu(0, tenDichVu, giaDichVu, trangThaiDV); // MaDV được tự động tạo

            try
            {
                if (DichVuBLL.Instance.InsertDichVu(newDichVu))
                {
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListDichVu(); // Tải lại danh sách dịch vụ
                }
                else
                {
                    MessageBox.Show("Thêm dịch vụ thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            if (dtgvDichVu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDV = Convert.ToInt32(dtgvDichVu.CurrentRow.Cells["MaDV"].Value);
            string tenDichVu = txtTenDV.Text.Trim();
            string giaDichVuText = txtGiaDV.Text.Replace(" VND", "").Replace(",", "").Trim();
            bool trangThaiDV = cbTTDV.SelectedIndex == 0; // "Kích hoạt" (true), "Không kích hoạt" (false)

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(tenDichVu))
            {
                MessageBox.Show("Tên dịch vụ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(giaDichVuText))
            {
                MessageBox.Show("Giá dịch vụ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá dịch vụ có phải số không
            if (!decimal.TryParse(giaDichVuText, out decimal giaDichVu) || giaDichVu <= 0)
            {
                MessageBox.Show("Giá dịch vụ phải là số hợp lệ và lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng dịch vụ với dữ liệu mới
            DichVu updatedDichVu = new DichVu(maDV, tenDichVu, giaDichVu, trangThaiDV);

            try
            {
                if (DichVuBLL.Instance.UpdateDichVu(updatedDichVu))
                {
                    MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListDichVu(); // Tải lại danh sách dịch vụ
                }
                else
                {
                    MessageBox.Show("Cập nhật dịch vụ thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (dtgvDichVu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDV = Convert.ToInt32(dtgvDichVu.CurrentRow.Cells["MaDV"].Value);
            string tenDichVu = dtgvDichVu.CurrentRow.Cells["TENDV"].Value.ToString();

            // Xác nhận xóa
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa dịch vụ '{tenDichVu}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (DichVuBLL.Instance.DeleteDichVu(maDV))
                {
                    MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListDichVu(); // Tải lại danh sách dịch vụ
                }
                else
                {
                    MessageBox.Show("Dịch vụ không tồn tại hoặc không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetDV_Click(object sender, EventArgs e)
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtGiaDV.Clear();
            cbTTDV.SelectedIndex = 0;
        }






        private void btnSearchDV_Click(object sender, EventArgs e)
        {
            // Lấy danh sách dịch vụ theo tên tìm kiếm
            var list = DichVuBLL.Instance.SearchDVByName(txtSearchDVName.Text);

            // Chuyển đổi trạng thái từ bool -> string trước khi gán vào DataGridView
            var modifiedList = list.Select(item => new
            {
                item.MaDV,
                item.TenDV,
                item.GiaDV,
                TRANGTHAI = item.TrangThaiDV ? "Đang hoạt động" : "Ngừng hoạt động" // Chuyển đổi kiểu bit chuỗi
            }).ToList();

            dtgvDichVu.DataSource = modifiedList;
        }

        private void txtSearchDVName_Enter(object sender, EventArgs e)
        {
            if (txtSearchDVName.Text == "Hãy nhập tên dịch vụ cần tìm")
            {
                txtSearchDVName.Text = "";
                txtSearchDVName.ForeColor = Color.Black;
            }
        }

        private void txtSearchDVName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchDVName.Text))
            {
                txtSearchDVName.Text = "Hãy nhập tên dịch vụ cần tìm";
                txtSearchDVName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchDVName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchDVName.Text) || txtSearchDVName.Text == "Hãy nhập tên dịch vụ cần tìm")
            {
                LoadListDichVu(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListDichVu(); // Gọi lại danh sách vì hàm không có tham số
            }
        }
    }
}
