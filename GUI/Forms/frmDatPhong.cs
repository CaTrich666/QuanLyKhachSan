using BLL;
using DocumentFormat.OpenXml.Office2010.Drawing;
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
    public partial class frmDatPhong : Form
    {
        public frmDatPhong()
        {
            InitializeComponent();
            Loads();
        }




        void Loads()
        {
            LoadTheme();
            LoadComboBoxPhongTrong();
            LoadComboBoxDichVu();
            cbPhong.SelectedIndexChanged += cbPhong_SelectedIndexChanged;

            // Ngày nhận phòng mặc định là ngày mai
            dtpNgayNhanPhong.Value = DateTime.Now.AddDays(1);

            // Ngày trả phòng mặc định sau ngày nhận 1 ngày
            dtpNgayTraPhong.Value = dtpNgayNhanPhong.Value.AddDays(1);

            // Giới hạn ngày nhỏ nhất cho DateTimePicker
            dtpNgayNhanPhong.MinDate = DateTime.Now;
            dtpNgayTraPhong.MinDate = dtpNgayNhanPhong.Value.AddDays(1);


            // Cấu hình cho tất cả DateTimePicker
            SetupDateTimePicker(dtpNgayNhanPhong);
            SetupDateTimePicker(dtpNgayTraPhong);
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
            groupBox5.ForeColor = ThemeColor.SecondaryColor;
            groupBox6.ForeColor = ThemeColor.PrimaryColor;
            groupBox7.ForeColor = ThemeColor.SecondaryColor;
        }





        //Xóa thông tin khi chưa chọn phòng
        private void ClearRoomInfo()
        {
            txtMaLP.Text = "";
            txtTenLoaiPhong.Text = "";
            txtGia.Text = "";
            txtSoNguoiToiDa.Text = "";
        }


        void SetupDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy HH:mm";
            dtp.ShowUpDown = true;
        }



        // Khi thay đổi ngày nhận phòng, cập nhật ngày trả phòng hợp lệ
        private void dtpNgayNhanPhong_ValueChanged(object sender, EventArgs e)
        {
            // Cập nhật MinDate cho ngày trả phòng
            dtpNgayTraPhong.MinDate = dtpNgayNhanPhong.Value.AddDays(1);

            // Nếu ngày trả phòng nhỏ hơn ngày nhận phòng => tự động đẩy lên ít nhất 1 ngày
            if (dtpNgayTraPhong.Value <= dtpNgayNhanPhong.Value)
            {
                dtpNgayTraPhong.Value = dtpNgayNhanPhong.Value.AddDays(1);
            }
        }


        //Load danh sách phòng trống
        private void LoadComboBoxPhongTrong()
        {
            List<Phong> listPhong = PhongBLL.Instance.GetPhongTrong();

            cbPhong.DataSource = null;// Đặt về null trước để tránh lỗi binding
            cbPhong.DataSource = listPhong;
            cbPhong.DisplayMember = "TenPhong";// Hiển thị tên phòng
            cbPhong.ValueMember = "MaPhong";// Giá trị thực tế là Mã phòng
            cbPhong.SelectedIndex = -1;// Không chọn phòng nào ban đầu

            // Đảm bảo các ô nhập thông tin phòng trống khi form mở
            ClearRoomInfo();
        }



        //sự kiện SelectedIndexChanged hiển thị thông tin của phòng được chọn
        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhong.SelectedItem is Phong selectedPhong)
            {
                // Lấy thông tin loại phòng
                LoaiPhong loaiPhong = PhongBLL.Instance.GetLoaiPhong(selectedPhong.MaLoai);

                if (loaiPhong != null)
                {
                    txtMaLP.Text = loaiPhong.MaLoai.ToString();
                    txtTenLoaiPhong.Text = loaiPhong.TenLoai;
                    txtGia.Text = loaiPhong.GiaLP.ToString("N0"); // Hiển thị giá có định dạng
                    txtSoNguoiToiDa.Text = loaiPhong.SoNguoiTD.ToString();
                }
            }
            else
            {
                // Khi chưa chọn phòng, xóa thông tin
                ClearRoomInfo();
            }
        }







        private void btnTimKiemCCCD_Click(object sender, EventArgs e)
        {
            string cccd = txtTimKiemCCCD.Text.Trim();

            if (string.IsNullOrWhiteSpace(cccd) || !cccd.All(char.IsDigit) || cccd.Length != 12)
            {
                MessageBox.Show("Vui lòng nhập đúng CCCD gồm 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang khachHang = KhachHangBLL.Instance.SearchKHByCCCD(cccd);

            if (khachHang != null)
            {
                // Nếu tìm thấy khách hàng, điền thông tin vào giao diện
                txtCCCD.Text = khachHang.CCCD; // Hiển thị CCCD của khách hàng tìm thấy
                txtTenKH.Text = khachHang.TenKH;
                txtSDT.Text = khachHang.SDT_KH;
                txtDiaChi.Text = khachHang.DiaChi;
                rdoNam.Checked = khachHang.GioiTinh_KH;
                rdoNu.Checked = !khachHang.GioiTinh_KH;
            }
            else
            {
                // Nếu không tìm thấy khách hàng, thông báo và xóa thông tin cũ để nhập mới
                MessageBox.Show("Không tìm thấy khách hàng, vui lòng nhập thông tin mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCCD.Clear();
                txtTenKH.Clear();
                txtSDT.Clear();
                txtDiaChi.Clear();
                rdoNam.Checked = false;
                rdoNu.Checked = false;
                txtTenKH.Focus();
            }
        }




        //Khi người dùng nhập
        private void txtTimKiemCCCD_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemCCCD.Text == "Hãy nhập cccd của khách hàng cần tìm")
            {
                txtTimKiemCCCD.Text = "";// Xóa nội dung placeholder
                txtTimKiemCCCD.ForeColor = Color.Black;// Đổi màu chữ về đen
            }
        }
        //Khi người rời khỏi phần tìm kiếm
        private void txtTimKiemCCCD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiemCCCD.Text))
            {
                txtTimKiemCCCD.Text = "Hãy nhập cccd của khách hàng cần tìm";// Đặt lại placeholder
                txtTimKiemCCCD.ForeColor = Color.Gray;// Đổi màu chữ về xám
            }
        }



        private void LoadComboBoxDichVu()
        {
            List<DichVu> danhSachDichVu = DichVuBLL.Instance.GetAllDichVu();
            cbDichVu.DataSource = danhSachDichVu;
            cbDichVu.DisplayMember = "TenDV";
            cbDichVu.ValueMember = "MaDV";
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            if (cbDichVu.SelectedItem == null || nudSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ và nhập số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu DataGridView chưa có cột thì thêm cột trước
            if (dgvDichVu.Columns.Count == 0)
            {
                dgvDichVu.Columns.Add("MaDV", "Mã DV");
                dgvDichVu.Columns.Add("TenDV", "Tên DV");
                dgvDichVu.Columns.Add("GiaDV", "Giá");
                dgvDichVu.Columns.Add("SoLuong", "Số lượng");
                dgvDichVu.Columns.Add("TongTien", "Tổng tiền");
            }

            // Lấy dịch vụ được chọn từ ComboBox
            DichVu selectedDichVu = (DichVu)cbDichVu.SelectedItem;
            int maDV = selectedDichVu.MaDV;
            string tenDV = selectedDichVu.TenDV;
            decimal giaDV = selectedDichVu.GiaDV;
            int soLuong = (int)nudSoLuong.Value;
            decimal tongTien = giaDV * soLuong; // Tính tổng tiền

            // Kiểm tra nếu dịch vụ đã có trong DataGridView thì chỉ cập nhật số lượng
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.Cells["MaDV"].Value != null && (int)row.Cells["MaDV"].Value == maDV)
                {
                    int soLuongHienTai = (int)row.Cells["SoLuong"].Value;
                    row.Cells["SoLuong"].Value = soLuongHienTai + soLuong;
                    row.Cells["TongTien"].Value = giaDV * (soLuongHienTai + soLuong);
                    return;
                }
            }

            // Thêm dịch vụ mới vào DataGridView
            dgvDichVu.Rows.Add(maDV, tenDV, giaDV, soLuong, tongTien);
        }




        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvDichVu.SelectedRows)
            {
                if (!row.IsNewRow) // Đảm bảo không xóa dòng trống mới
                {
                    dgvDichVu.Rows.Remove(row);
                }
            }
        }



        //1.Kiểm tra thông tin khách hàng
        private bool KiemTraThongTinKhachHang(string cccd, string tenKH, string sdtKH, string diaChi)
        {
            if (string.IsNullOrWhiteSpace(cccd) || !cccd.All(char.IsDigit) || cccd.Length != 12)
            {
                MessageBox.Show("CCCD phải có đúng 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(sdtKH) || sdtKH.Length != 10 || !sdtKH.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }




        //2.Kiểm tra ngày nhận và ngày trả phòng
        private bool KiemTraNgayNhanTraPhong(DateTime ngayNhan, DateTime ngayTra)
        {
            if (ngayNhan < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày nhận phòng phải từ hôm nay trở đi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ngayTra <= ngayNhan)
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày nhận phòng ít nhất 1 ngày!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }



        // 3. Kiểm tra hoặc thêm mới khách hàng
        private KhachHang LayHoacThemKhachHang(string cccd, string tenKH, string sdtKH, bool gioiTinh, string diaChi)
        {
            // Kiểm tra khách hàng có tồn tại không
            KhachHang khachHang = KhachHangBLL.Instance.SearchKHByCCCD(cccd);
            if (khachHang == null)
            {
                // Nếu chưa tồn tại, thêm khách hàng vào hệ thống
                KhachHang newKhachHang = new KhachHang(cccd, tenKH, sdtKH, gioiTinh, diaChi);
                if (!KhachHangBLL.Instance.InsertKhachHang(newKhachHang))
                {
                    MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Lấy lại thông tin khách hàng sau khi thêm
                khachHang = KhachHangBLL.Instance.SearchKHByCCCD(cccd);
                if (khachHang == null)
                {
                    MessageBox.Show("Khách hàng không được tìm thấy sau khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            return khachHang;
        }





        // 4. Tạo phiếu đặt phòng
        private int TaoPhieuDat(string cccd)
        {
            if (!decimal.TryParse(txtTienCoc.Text, out decimal tienCoc) || tienCoc < 0)
            {
                MessageBox.Show("Vui lòng nhập tiền cọc hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }


            PhieuDat phieu = new PhieuDat(
                0, // MAPD tự tăng
                Convert.ToInt32(nudSoNguoi.Value),
                "Đang chờ",
                tienCoc,
                DateTime.Now,
                dtpNgayNhanPhong.Value,
                dtpNgayTraPhong.Value,
                cccd, // Truyền CCCD vào đây
                CurrentUser.Instance.MaNhanVien // Lấy mã nhân viên từ thông tin đăng nhập
            );

            // Gọi phương thức để chèn phiếu đặt
            bool isInserted = PhieuDatBLL.Instance.InsertPhieuDat(phieu);
            if (!isInserted) // Kiểm tra kết quả
            {
                MessageBox.Show("Lỗi khi đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            // Lấy MAPD mới nhất
            int maPhieuDat = PhieuDatBLL.Instance.GetLatestPhieuDatId();
            if (maPhieuDat <= 0) // Kiểm tra kết quả
            {
                MessageBox.Show("Lỗi khi lấy mã phiếu đặt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            return maPhieuDat; // Trả về giá trị MAPD
        }







        // 5. Thêm dịch vụ vào phiếu đặt phòng
        private void ThemDichVuVaoPhieuDat(int maPhieuDat)
        {
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.Cells["MaDV"].Value == null || row.Cells["SoLuong"].Value == null)
                    continue; // Bỏ qua nếu không có thông tin dịch vụ

                int maDV = (int)row.Cells["MaDV"].Value;
                int soLuong = (int)row.Cells["SoLuong"].Value;

                // Tạo chi tiết dịch vụ
                ChiTietDichVu chiTietDV = new ChiTietDichVu(maPhieuDat, maDV, soLuong);

                // Chèn chi tiết dịch vụ vào CSDL
                if (!ChiTietDichVuBLL.Instance.InsertChiTietDichVu(chiTietDV))
                {
                    MessageBox.Show($"Lỗi khi thêm dịch vụ mã {maDV} vào phiếu đặt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // 6. Thêm chi tiết phiếu đặt vào CSDL
        private void ThemChiTietPhieuDat(int maPhieuDat)
        {
            if (cbPhong.SelectedValue == null) return; // Không có phòng được chọn

            int maPhong = (int)cbPhong.SelectedValue;

            if (!ChiTietPhieuDatBLL.Instance.InsertChiTietPhieuDat(new ChiTietPhieuDat(maPhieuDat, maPhong)))
            {
                MessageBox.Show($"Lỗi khi thêm phòng {maPhong}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }










        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ form
            string cccd = txtCCCD.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdtKH = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            bool gioiTinhKH = rdoNam.Checked; // Nam = true, Nữ = false

            // 2. Kiểm tra dữ liệu đầu vào
            if (!KiemTraThongTinKhachHang(cccd, tenKH, sdtKH, diaChi)) return;
            if (!KiemTraNgayNhanTraPhong(dtpNgayNhanPhong.Value, dtpNgayTraPhong.Value)) return;

            // 3. Kiểm tra khách hàng trong hệ thống
            KhachHang selectedKhachHang = LayHoacThemKhachHang(cccd, tenKH, sdtKH, gioiTinhKH, diaChi);
            if (selectedKhachHang == null) return;

            // 4. Kiểm tra số lượng người
            if (!int.TryParse(txtSoNguoiToiDa.Text, out int soNguoiToiDa))
            {
                MessageBox.Show("Số người tối đa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soNguoi = (int)nudSoNguoi.Value; // Giả sử bạn có NumericUpDown để nhập số người
            if (soNguoi > soNguoiToiDa)
            {
                MessageBox.Show($"Số lượng người không thể vượt quá số người tối đa ({soNguoiToiDa}) của loại phòng đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu số lượng vượt quá
            }

            // 5. Tạo phiếu đặt phòng
            try
            {
                int maPhieuDat = TaoPhieuDat(cccd); //Truyền CCCD để tạo phiếu đặt
                if (maPhieuDat == -1) return;

                // 6. Thêm phòng vào phiếu đặt
                ThemChiTietPhieuDat(maPhieuDat); //Gọi phương thức này để lưu phòng vào phiếu đặt

                // 7. Thêm dịch vụ vào phiếu đặt phòng
                ThemDichVuVaoPhieuDat(maPhieuDat);

                MessageBox.Show("Đặt phòng và dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 8. Cập nhật lại danh sách phòng trống
                LoadComboBoxPhongTrong();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi khi tạo phiếu đặt phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbPhong.SelectedIndex = 0;
            txtTienCoc.Clear();
            txtTimKiemCCCD.Clear();
            txtCCCD.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            rdoNam.Checked = false;
            rdoNu.Checked = false;
        }
    }
}
