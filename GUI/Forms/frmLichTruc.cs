using BLL;
using DTO;
using GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class frmLichTruc : Form
    {
        public frmLichTruc()
        {
            InitializeComponent();
            Loads();
        }


        void Loads()
        {
            LoadListLichTruc();
            LoadComboBoxLichTruc();
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
                btnXoaLT.Enabled = false;

            }
        }





        void LoadListLichTruc()
        {
            var list = LichTrucBLL.Instance.GetListLichTruc();
            dtgvLichTruc.DataSource = list;
        }


        void LoadComboBoxLichTruc()
        {
            // Lấy danh sách từ BLL
            List<CaLam> danhSachCaLam = CaLamBLL.Instance.GetListCaLam();
            List<NhanVien> danhSachNhanVien = NhanVienBLL.Instance.GetListNhanVien();

            // Chỉ cần load mã ca làm và mã nhân viên, không cần thông tin khác
            danhSachCaLam.Insert(0, new CaLam { MaCa = 0, TenCa = "Chọn ca làm" });
            danhSachNhanVien.Insert(0, new NhanVien { MaNV = 0, TenNV = "Chọn nhân viên" });

            // Gán dữ liệu cho ComboBox Ca làm chỉ hiển thị mã ca làm
            cbMCL.DataSource = danhSachCaLam;
            cbMCL.DisplayMember = "HienThi";  // Chỉ cần đổi DisplayMember
            cbMCL.ValueMember = "MaCa";    // Lưu giá trị Mã Ca

            // Gán dữ liệu cho ComboBox Nhân viên (Chỉ hiển thị mã nhân viên)
            cbMNV.DataSource = danhSachNhanVien;
            cbMNV.DisplayMember = "HienThi";  // Chỉ cần đổi DisplayMember
            cbMNV.ValueMember = "MaNV";    // Lưu giá trị Mã Nhân Viên

            // Chọn phần tử đầu tiên làm mặc định
            cbMCL.SelectedIndex = 0;
            cbMNV.SelectedIndex = 0;
        }


        private void dtgvLichTruc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvLichTruc.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvLichTruc.Rows[e.RowIndex];

                txtMaLT.Text = selectRow.Cells[0].Value?.ToString() ?? "";
                cbMNV.SelectedValue = selectRow.Cells[1].Value ?? 0;
                cbMCL.SelectedValue = selectRow.Cells[2].Value ?? 0;
                dtpNgayTruc.Value = Convert.ToDateTime(selectRow.Cells[3].Value);
            }
        }

        private void btnThemLT_Click(object sender, EventArgs e)
        {
            int? maNV = cbMNV.SelectedValue as int?;
            int? maCa = cbMCL.SelectedValue as int?;
            DateTime ngayTruc = dtpNgayTruc.Value.Date;

            // Kiểm tra ngày trực không để trống
            if (ngayTruc == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng chọn ngày trực hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LichTruc newLichTruc = new LichTruc(0, maNV, maCa, ngayTruc); // Mã LT tự động tạo

            try
            {
                if (LichTrucBLL.Instance.InsertLichTruc(newLichTruc))
                {
                    MessageBox.Show("Thêm lịch trực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListLichTruc(); // Tải lại danh sách
                }
                else
                {
                    MessageBox.Show("Thêm lịch trực thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnSuaLT_Click(object sender, EventArgs e)
        {
            if (dtgvLichTruc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn lịch trực cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLT = Convert.ToInt32(dtgvLichTruc.CurrentRow.Cells["MaLT"].Value);
            int? maNV = cbMNV.SelectedValue as int?;
            int? maCa = cbMCL.SelectedValue as int?;
            DateTime ngayTruc = dtpNgayTruc.Value.Date;


            // Tạo đối tượng lịch trực với dữ liệu mới
            LichTruc updatedLichTruc = new LichTruc(maLT, maNV, maCa, ngayTruc);

            try
            {
                if (LichTrucBLL.Instance.UpdateLichTruc(updatedLichTruc))
                {
                    MessageBox.Show("Cập nhật lịch trực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListLichTruc(); // Tải lại danh sách lịch trực
                }
                else
                {
                    MessageBox.Show("Cập nhật lịch trực thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnXoaLT_Click(object sender, EventArgs e)
        {
            if (dtgvLichTruc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn lịch trực cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLT = Convert.ToInt32(dtgvLichTruc.CurrentRow.Cells["MaLT"].Value);
            int maNV = Convert.ToInt32(dtgvLichTruc.CurrentRow.Cells["MaNV"].Value);
            DateTime ngayTruc = Convert.ToDateTime(dtgvLichTruc.CurrentRow.Cells["NgayTruc"].Value);


            // Xác nhận xóa
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch trực vào ngày {ngayTruc.ToShortDateString()} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (LichTrucBLL.Instance.DeleteLichTruc(maLT))
                {
                    MessageBox.Show("Xóa lịch trực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListLichTruc();
                }
                else
                {
                    MessageBox.Show("Lịch trực không tồn tại hoặc không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void btnResetLT_Click(object sender, EventArgs e)
        {
            txtMaLT.Clear();
            cbMNV.SelectedIndex = 0;
            cbMCL.SelectedIndex = 0;
            dtpNgayTruc.Value = DateTime.Today;
        }






        private void btnSearchLT_Click(object sender, EventArgs e)
        {
            dtgvLichTruc.DataSource = LichTrucBLL.Instance.SearchLT(txtSearchLT.Text);
        }

        private void txtSearchLT_Enter(object sender, EventArgs e)
        {
            if (txtSearchLT.Text == "Hãy nhập mã lịch trực cần tìm")
            {
                txtSearchLT.Text = "";
                txtSearchLT.ForeColor = Color.Black;
            }
        }

        private void txtSearchLT_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchLT.Text))
            {
                txtSearchLT.Text = "Hãy nhập mã lịch trực cần tìm";
                txtSearchLT.ForeColor = Color.Gray;
            }
        }

        private void txtSearchLT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchLT.Text) || txtSearchLT.Text == "Hãy nhập mã lịch trực cần tìm")
            {
                LoadListLichTruc(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListLichTruc(); // Gọi lại danh sách vì hàm không có tham số
            }
        }
    }
}
