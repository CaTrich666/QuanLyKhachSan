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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI.Forms
{
    public partial class frmThongTinDangNhap: Form
    {
        // Tạo sự kiện để thông báo khi tài khoản được cập nhật
        public event Action OnTaiKhoanUpdated;


        public frmThongTinDangNhap()
        {
            InitializeComponent();
            Loads();
        }


        void Loads()
        {
            LoadTheme();
            LoadThongTinTaiKhoan();
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
        }







        private void LoadThongTinTaiKhoan()
        {
            TaiKhoan tk = TaiKhoanBLL.Instance.GetTaiKhoanByUserName(CurrentUser.Instance.TenTaiKhoan);
            if (tk != null)
            {
                txtTenTaiKhoan.Text = tk.UserName;
                txtTTK.Text = tk.UserName;
                txtQuyenTaiKhoan.Text = tk.Role ? "Quản lý" : "Nhân viên";
                txtMaNV.Text = tk.MaNV.ToString();

                // Lấy thông tin nhân viên từ mã nhân viên
                NhanVien nv = NhanVienBLL.Instance.GetNhanVienByMaNV(tk.MaNV);
                if (nv != null)
                {
                    txtTenNhanVien.Text = nv.TenNV;

                    dtpNgaySinh.Format = DateTimePickerFormat.Custom;
                    dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
                    dtpNgaySinh.ShowUpDown = true;
                    dtpNgaySinh.Value = nv.NgaySinh;

                    rdoNam.Checked = nv.GioiTinhNV;
                    rdoNu.Checked = !nv.GioiTinhNV;

                    txtSoDienThoai.Text = nv.SdtNV;
                    txtChucVu.Text = nv.MaCV.ToString(); // Nếu cần lấy tên chức vụ, có thể truy vấn thêm bảng chức vụ
                }
            }
        }








        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenTaiKhoanCu = CurrentUser.Instance.TenTaiKhoan;
            string tenTaiKhoanMoi = txtTenTaiKhoanMoi.Text;
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            TaiKhoan tk = TaiKhoanBLL.Instance.GetTaiKhoanByUserName(tenTaiKhoanCu);
            if (tk == null || tk.PassWord != matKhauCu)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = TaiKhoanBLL.Instance.UpdateTaiKhoan(tenTaiKhoanCu, tenTaiKhoanMoi, matKhauMoi);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CurrentUser.Instance.SetUser(tenTaiKhoanMoi, tk.Role, tk.MaNV);
                LoadThongTinTaiKhoan(); // Cập nhật lại thông tin hiển thị

                // Gọi sự kiện cập nhật form cha
                OnTaiKhoanUpdated?.Invoke();

                // Đảm bảo giao diện được cập nhật ngay
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
