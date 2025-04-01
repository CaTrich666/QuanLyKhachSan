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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI.Forms
{
    public partial class frmNhanPhong : Form
    {
        public frmNhanPhong()
        {
            InitializeComponent();
            Loads();
        }



        void Loads()
        {
            LoadTheme();

            // Cấu hình cho tất cả DateTimePicker
            SetupDateTimePicker(dtpNgayNhanPhong);
            SetupDateTimePicker(dtpNgayTraPhong);

            LoadComboBoxDichVu();
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
        }








        void SetupDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy HH:mm";
            dtp.ShowUpDown = true;
        }






        private void btnSearchPD_Click(object sender, EventArgs e)
        {
            // Lấy mã phiếu đặt từ TextBox
            int maPD;
            if (int.TryParse(txtTimKiemMPD.Text, out maPD)) // txtTimKiemMPD là tên TextBox nhập mã phiếu đặt
            {
                // Gọi phương thức tìm kiếm phiếu đặt từ BLL
                PhieuDatWithAllDetails phieuDat = PhieuDatBLL.Instance.SearchPhieuDatByMaPD(maPD);

                if (phieuDat != null)
                {
                    // Hiển thị thông tin phiếu đặt lên GUI (các Label, TextBox...)
                    txtTenKH.Text = phieuDat.TenKH; // Tên khách hàng
                    txtCCCD.Text = phieuDat.CCCD; // cccd
                    txtSDT.Text = phieuDat.SDT_KH; // Số điện thoại
                    txtTienCoc.Text = CurrencyFormatter.FormatToVND(phieuDat.TienCoc);


                    txtTenPhong.Text = phieuDat.TenPhong; // Tên phòng
                    txtTenLoai.Text = phieuDat.TenLoai; // Tên loại phòng
                    txtGiaLP.Text = CurrencyFormatter.FormatToVND(phieuDat.GiaLP);

                    // Hiển thị số người sử dụng NumericUpDown
                    nudSoNguoi.Value = phieuDat.SoNguoi;

                    // Hiển thị giới tính với RadioButton
                    if (phieuDat.GioiTinhKH)
                    {
                        rdoNam.Checked = true; // Giới tính Nam
                    }
                    else
                    {
                        rdoNu.Checked = true; // Giới tính Nữ
                    }

                    // Hiển thị ngày đặt, ngày nhận phòng, ngày trả phòng với DateTimePicker
                    dtpNgayDat.Value = phieuDat.NgayDat;
                    dtpNgayNhanPhong.Value = phieuDat.NgayNhanPhong;
                    dtpNgayTraPhong.Value = phieuDat.NgayTraPhong;

                    // Kiểm tra nếu DataGridView chưa có cột thì thêm cột trước
                    if (dgvDichVu.Columns.Count == 0)
                    {
                        dgvDichVu.Columns.Add("MaDV", "Mã DV");
                        dgvDichVu.Columns.Add("TenDV", "Tên DV");
                        dgvDichVu.Columns.Add("GiaDV", "Giá");
                        dgvDichVu.Columns.Add("SoLuong", "Số lượng");
                        dgvDichVu.Columns.Add("TongTien", "Tổng tiền");
                    }

                    // Hiển thị thông tin dịch vụ
                    dgvDichVu.Rows.Clear(); // Làm sạch DataGridView trước khi thêm dữ liệu mới
                    for (int i = 0; i < phieuDat.MaDV.Count; i++)
                    {
                        // Thêm các dịch vụ vào DataGridView
                        dgvDichVu.Rows.Add(
                            phieuDat.MaDV[i],
                            phieuDat.TenDV[i],
                            phieuDat.GiaDV[i].ToString(),
                            phieuDat.SoLuong[i],
                            (phieuDat.GiaDV[i] * phieuDat.SoLuong[i]).ToString() // Tính tổng tiền cho dịch vụ
                        );
                    }
                }
                else
                {
                    // Thông báo nếu không tìm thấy phiếu đặt
                    MessageBox.Show("Không tìm thấy phiếu đặt với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Thông báo nếu mã phiếu đặt không hợp lệ
                MessageBox.Show("Vui lòng nhập mã phiếu đặt hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void txtTimKiemMPD_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemMPD.Text == "Hãy nhập mã phiếu đặt cần tìm")
            {
                txtTimKiemMPD.Text = "";
                txtTimKiemMPD.ForeColor = Color.Black;
            }
        }





        private void txtTimKiemMPD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiemMPD.Text))
            {
                txtTimKiemMPD.Text = "Hãy nhập mã phiếu đặt cần tìm";
                txtTimKiemMPD.ForeColor = Color.Gray;
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

            // Kiểm tra mã phiếu đặt hợp lệ từ ô tìm kiếm
            if (!int.TryParse(txtTimKiemMPD.Text, out int maPD))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu đặt hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu không có dịch vụ nào được chọn
            if (dgvDichVu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý xóa dịch vụ khỏi CSDL và DataGridView
            foreach (DataGridViewRow row in dgvDichVu.SelectedRows)
            {
                if (!row.IsNewRow) // Đảm bảo không xóa dòng trống mới
                {
                    try
                    {
                        // Lấy mã dịch vụ từ DataGridView
                        int maDV = Convert.ToInt32(row.Cells["MaDV"].Value);

                        // Gọi hàm xóa dịch vụ từ CSDL
                        bool result = ChiTietDichVuBLL.Instance.DeleteChiTietDichVu(maPD, maDV);

                            // Nếu xóa thành công trong CSDL, xóa dòng khỏi DataGridView
                            dgvDichVu.Rows.Remove(row);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đầu vào hợp lệ
                if (!int.TryParse(txtTimKiemMPD.Text, out int maPD))
                {
                    MessageBox.Show("Vui lòng nhập mã phiếu đặt hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin phiếu đặt
                PhieuDat phieuDat = PhieuDatBLL.Instance.GetPhieuDatByMaPD(maPD);
                if (phieuDat == null)
                {
                    MessageBox.Show("Không thể xác định trạng thái phiếu đặt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string trangThaiPD = phieuDat.TrangThaiPD;

                // Kiểm tra trạng thái phiếu đặt theo quy trình
                if (trangThaiPD == "Đang chờ")
                {
                    MessageBox.Show("Phiếu đặt phải được xác nhận trước khi nhận phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (trangThaiPD == "Đã nhận phòng")
                {
                    MessageBox.Show("Phòng đã được nhận. Không thể nhận lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (trangThaiPD == "Đã xác nhận")
                {
                    // Cập nhật trạng thái phiếu đặt thành "Đã nhận phòng"
                    phieuDat.TrangThaiPD = "Đã nhận phòng";
                    if (!PhieuDatBLL.Instance.UpdatePhieuDat(phieuDat))
                    {
                        MessageBox.Show("Cập nhật trạng thái phiếu đặt thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật danh sách dịch vụ cho phiếu đặt
                    foreach (DataGridViewRow row in dgvDichVu.Rows)
                    {
                        try
                        {
                            if (row.Cells["MaDV"].Value == null || row.Cells["SoLuong"].Value == null)
                            {
                                Console.WriteLine("Bỏ qua dịch vụ do dữ liệu null.");
                                continue;
                            }

                            int maDV = Convert.ToInt32(row.Cells["MaDV"].Value);
                            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                            // Kiểm tra dịch vụ đã tồn tại hay chưa
                            ChiTietDichVu existingService = ChiTietDichVuBLL.Instance.GetChiTietDichVu(maPD, maDV);

                            if (soLuong == 0)
                            {
                                // Nếu số lượng bằng 0, xóa dịch vụ nếu nó đã tồn tại
                                if (existingService != null)
                                {
                                    ChiTietDichVuBLL.Instance.DeleteChiTietDichVu(maPD, maDV);
                                }
                            }
                            else
                            {
                                if (existingService != null)
                                {
                                    // Nếu đã tồn tại, cập nhật số lượng
                                    existingService.SoLuong = soLuong;
                                    ChiTietDichVuBLL.Instance.UpdateChiTietDichVu(existingService);
                                }
                                else
                                {
                                    // Nếu chưa tồn tại, thêm mới
                                    ChiTietDichVuBLL.Instance.InsertChiTietDichVu(new ChiTietDichVu(maPD, maDV, soLuong));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi xử lý dịch vụ: {ex.Message}");
                            MessageBox.Show($"Lỗi khi cập nhật dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show("Nhận phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Trạng thái phiếu đặt không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCapNhatDichVu_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã phiếu đặt hợp lệ
            if (!int.TryParse(txtTimKiemMPD.Text, out int maPD))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu đặt hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật danh sách dịch vụ cho phiếu đặt
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                try
                {
                    if (row.Cells["MaDV"].Value == null || row.Cells["SoLuong"].Value == null)
                    {
                        Console.WriteLine("Bỏ qua dịch vụ do dữ liệu null.");
                        continue;
                    }

                    int maDV = Convert.ToInt32(row.Cells["MaDV"].Value);
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                    // Kiểm tra dịch vụ đã tồn tại hay chưa
                    ChiTietDichVu existingService = ChiTietDichVuBLL.Instance.GetChiTietDichVu(maPD, maDV);

                    if (soLuong == 0)
                    {
                        // Nếu số lượng bằng 0, xóa dịch vụ nếu nó đã tồn tại
                        if (existingService != null)
                        {
                            ChiTietDichVuBLL.Instance.DeleteChiTietDichVu(maPD, maDV);
                            Console.WriteLine($"Đã xóa dịch vụ mã {maDV} khỏi CSDL.");
                        }
                    }
                    else
                    {
                        if (existingService != null)
                        {
                            // Nếu đã tồn tại, cập nhật số lượng
                            existingService.SoLuong = soLuong;
                            ChiTietDichVuBLL.Instance.UpdateChiTietDichVu(existingService);
                        }
                        else
                        {
                            // Nếu chưa tồn tại, thêm mới
                            ChiTietDichVuBLL.Instance.InsertChiTietDichVu(new ChiTietDichVu(maPD, maDV, soLuong));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi xử lý dịch vụ: {ex.Message}");
                    MessageBox.Show($"Lỗi khi cập nhật dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }



    }
}
