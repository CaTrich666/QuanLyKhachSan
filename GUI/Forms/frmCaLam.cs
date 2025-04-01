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
    public partial class frmCaLam : Form
    {
        public frmCaLam()
        {
            InitializeComponent();
            Loads();
        }


        void Loads()
        {
            LoadListCaLam();
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
                btnXoaCL.Enabled = false;

            }
        }







        void LoadListCaLam()
        {
            var list = CaLamBLL.Instance.GetListCaLam();
            dtgvCaLam.DataSource = list;
            dtgvCaLam.Columns["HienThi"].Visible = false; // Ẩn cột HienThi
        }

        private void dtgvCL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvCaLam.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvCaLam.Rows[e.RowIndex];
                txtMaCL.Text = selectRow.Cells[0].Value?.ToString() ?? "";
                txtTenCL.Text = selectRow.Cells[1].Value?.ToString() ?? "";
                dtpGBD.Value = DateTime.Today.Add((TimeSpan)selectRow.Cells[2].Value);
                dtpGKT.Value = DateTime.Today.Add((TimeSpan)selectRow.Cells[3].Value);
                txtHSL.Text = selectRow.Cells[4].Value?.ToString() ?? ""; 
                txtGCL.Text = CurrencyFormatter.FormatToVND(selectRow.Cells[5].Value);
            }
        }

        private void btnThemCL_Click(object sender, EventArgs e)
        {
            string tenCa = txtTenCL.Text.Trim();
            string heSoLuongStr = txtHSL.Text.Trim();
            //string giaCLStr = txtGCL.Text.Trim();
            string giaCLStr = txtGCL.Text.Replace(" VND", "").Replace(",", "").Trim();


            TimeSpan gioBD = dtpGBD.Value.TimeOfDay;
            TimeSpan gioKT = dtpGKT.Value.TimeOfDay;

            if (string.IsNullOrWhiteSpace(tenCa))
            {
                MessageBox.Show("Tên ca không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gioBD >= gioKT)
            {
                MessageBox.Show("Giờ bắt đầu phải nhỏ hơn giờ kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(heSoLuongStr, out float heSoLuong) || heSoLuong <= 0)
            {
                MessageBox.Show("Hệ số lương phải là một số thực dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaCLStr, out decimal giaCL) || giaCL <= 0)
            {
                MessageBox.Show("Giá ca làm phải là một số thực dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CaLam newCaLam = new CaLam(0, tenCa, gioBD, gioKT, heSoLuong, giaCL);

            try
            {
                if (CaLamBLL.Instance.InsertCaLam(newCaLam))
                {
                    MessageBox.Show("Thêm ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListCaLam();
                }
                else
                {
                    MessageBox.Show("Thêm ca làm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void btnSuaCL_Click(object sender, EventArgs e)
        {
            if (dtgvCaLam.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCa = Convert.ToInt32(dtgvCaLam.CurrentRow.Cells["MaCa"].Value);
            string tenCa = txtTenCL.Text.Trim();
            string heSoLuongStr = txtHSL.Text.Trim();
            string giaCLStr = txtGCL.Text.Replace(" VND", "").Replace(",", "").Trim();

            TimeSpan gioBD = dtpGBD.Value.TimeOfDay;
            TimeSpan gioKT = dtpGKT.Value.TimeOfDay;

            if (string.IsNullOrWhiteSpace(tenCa))
            {
                MessageBox.Show("Tên ca không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gioBD >= gioKT)
            {
                MessageBox.Show("Giờ bắt đầu phải nhỏ hơn giờ kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(heSoLuongStr, out float heSoLuong) || heSoLuong <= 0)
            {
                MessageBox.Show("Hệ số lương phải là một số thực dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaCLStr, out decimal giaCL) || giaCL <= 0)
            {
                MessageBox.Show("Giá ca làm phải là một số thực dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CaLam updatedCaLam = new CaLam(maCa, tenCa, gioBD, gioKT, heSoLuong, giaCL);

            try
            {
                if (CaLamBLL.Instance.UpdateCaLam(updatedCaLam))
                {
                    MessageBox.Show("Cập nhật ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListCaLam();
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

        private void btnXoaCL_Click(object sender, EventArgs e)
        {
            if (dtgvCaLam.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCa = Convert.ToInt32(dtgvCaLam.CurrentRow.Cells["MaCa"].Value);
            string tenCa = dtgvCaLam.CurrentRow.Cells["TenCa"].Value.ToString();

            // Xác nhận xóa
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa ca làm '{tenCa}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (CaLamBLL.Instance.DeleteCaLam(maCa))
                {
                    MessageBox.Show("Xóa ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListCaLam();
                }
                else
                {
                    MessageBox.Show("Ca làm không tồn tại hoặc không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetCL_Click(object sender, EventArgs e)
        {
            txtMaCL.Clear();
            txtTenCL.Clear();
            dtpGBD.Value = DateTime.Today;
            dtpGKT.Value = DateTime.Today;
            txtHSL.Clear();
            txtGCL.Clear();
        }






        private void btnSearchCL_Click(object sender, EventArgs e)
        {
            dtgvCaLam.DataSource = CaLamBLL.Instance.SearchCLByName(txtSearchCLName.Text);
        }

        private void txtSearchCLName_Enter(object sender, EventArgs e)
        {
            if (txtSearchCLName.Text == "Hãy nhập tên ca làm cần tìm")
            {
                txtSearchCLName.Text = "";
                txtSearchCLName.ForeColor = Color.Black;
            }
        }

        private void txtSearchCLName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCLName.Text))
            {
                txtSearchCLName.Text = "Hãy nhập tên ca làm cần tìm";
                txtSearchCLName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchCLName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCLName.Text) || txtSearchCLName.Text == "Hãy nhập tên ca làm cần tìm")
            {
                LoadListCaLam(); // Hiển thị toàn bộ danh sách
            }
            else
            {
                LoadListCaLam(); // Gọi lại danh sách (vì hàm không có tham số)
            }
        }
    }
}
