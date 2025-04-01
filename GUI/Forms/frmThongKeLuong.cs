using BLL;
using DTO;
using GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class frmThongKeLuong : Form
    {
        public frmThongKeLuong()
        {
            InitializeComponent();
            LoadTheme();

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
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            panel2.ForeColor = ThemeColor.SecondaryColor;
        }



        //Hiển thị chi tiết lương
        private void HienThiChiTietLuong(List<TinhLuong> danhSachLuong)
        {
            if (danhSachLuong == null || danhSachLuong.Count == 0)
            {
                dgvChiTietLuong.DataSource = null;
                return;
            }

            foreach (var luong in danhSachLuong)
            {
                //Chuyển đổi sang decimal để đảm bảo độ chính xác
                decimal heSoLuong = (decimal?)luong.HeSoLuong ?? 1m;
                decimal giaCaLam = (decimal?)luong.GiaCaLam ?? 0m;
                int soLanLam = luong.SoLanLam;

                //Làm tròn giá trị về 1 chữ số thập phân
                luong.HeSoLuong = (double)Math.Round(heSoLuong, 1);
                luong.GiaCaLam = Math.Round(giaCaLam, 0);
                luong.TongTienCaLam = Math.Round(soLanLam * (heSoLuong * giaCaLam), 0);
            }

            dgvChiTietLuong.DataSource = danhSachLuong;
            FormatDataGridView(dgvChiTietLuong);

            //Ẩn các cột không cần thiết
            string[] cotAn = { "DonGiaChucVu", "LuongNhanVien", "TongTienCaSang", "TongTienCaChieu", "TongTienCaDem" };
            foreach (var cot in cotAn)
            {
                if (dgvChiTietLuong.Columns[cot] != null)
                    dgvChiTietLuong.Columns[cot].Visible = false;
            }

            //Hiển thị các cột cần thiết
            string[] cotHien = { "MaNV", "TenNV", "MaCa", "TenCa", "SoLanLam", "HeSoLuong", "GiaCaLam", "TongTienCaLam" };
            foreach (var cot in cotHien)
            {
                if (dgvChiTietLuong.Columns[cot] != null)
                    dgvChiTietLuong.Columns[cot].Visible = true;
            }

            dgvChiTietLuong.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        //Hiển thị tổng hợp lương
        private void HienThiTongLuong(List<TinhLuong> danhSachLuong)
        {
            if (danhSachLuong == null || danhSachLuong.Count == 0)
            {
                dgvTongHopLuong.DataSource = null;
                return;
            }

            string tenNhanVien = danhSachLuong.FirstOrDefault()?.TenNV ?? "Không xác định";
            decimal tongTienCaLam = danhSachLuong.Sum(x => x.SoLanLam * ((decimal?)x.HeSoLuong ?? 1m) * ((decimal?)x.GiaCaLam ?? 0m));
            int tongSoCaLam = danhSachLuong.Sum(x => x.SoLanLam);
            decimal donGiaChucVu = (decimal?)danhSachLuong.FirstOrDefault()?.DonGiaChucVu ?? 0m;
            decimal luongChucVu = donGiaChucVu * tongSoCaLam;
            decimal tongLuong = tongTienCaLam + luongChucVu;

            var tongHop = new List<dynamic>
            {
                new {
                    TenNV = tenNhanVien,
                    TongSoCaLam = tongSoCaLam,
                    TongTienCaLam = tongTienCaLam,
                    DonGiaChucVu = donGiaChucVu,
                    LuongChucVu = luongChucVu,
                    TongLuong = tongLuong
                }
            };

            dgvTongHopLuong.DataSource = tongHop;
            FormatDataGridView(dgvTongHopLuong);
        }

        //Định dạng DataGridView
        private void FormatDataGridView(DataGridView dgv)
        {
            if (dgv.DataSource == null) return;

            string[] cotDinhDang = { "TongTienCaLam", "DonGiaChucVu", "LuongChucVu", "TongLuong", "HeSoLuong" };
            foreach (var cot in cotDinhDang)
            {
                if (dgv.Columns.Contains(cot))
                    dgv.Columns[cot].DefaultCellStyle.Format = "N0"; // Định dạng có 1 chữ số sau dấu phẩy
            }
        }













        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaNV.Text, out int maNV))
            {
                MessageBox.Show("Mã nhân viên phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (denNgay < tuNgay)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dữ liệu chi tiết lương
            List<TinhLuong> danhSachLuong = TinhLuongBLL.Instance.GetTinhLuong(maNV, tuNgay, denNgay);

            if (danhSachLuong.Count > 0)
            {
                HienThiChiTietLuong(danhSachLuong);
                HienThiTongLuong(danhSachLuong);
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu lương cho nhân viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private DataGridView dgvDangChon = null;
        private void btnXuatBangLuong_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvDangChon;

            // Nếu không có bảng nào được chọn, kiểm tra bảng nào có dữ liệu
            if (dgv == null)
            {
                if (dgvChiTietLuong.Visible && dgvChiTietLuong.Rows.Count > 0)
                {
                    dgv = dgvChiTietLuong;
                }
                else if (dgvTongHopLuong.Visible && dgvTongHopLuong.Rows.Count > 0)
                {
                    dgv = dgvTongHopLuong;
                }
            }


            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           

            // Chuyển toàn bộ dữ liệu của bảng đang hiển thị thành DataTable
            DataTable dt = new DataTable();

            // Lấy danh sách cột
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible) // Bỏ qua cột ẩn
                    dt.Columns.Add(column.HeaderText);
            }

            // Lấy dữ liệu từ tất cả các dòng trong bảng
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua dòng trống
                {
                    DataRow dr = dt.NewRow();
                    int colIndex = 0;
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible)
                        {
                            dr[colIndex] = row.Cells[column.Index].Value ?? DBNull.Value;
                            colIndex++;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Xuất file Excel
            BangLuongExporter exporter = new BangLuongExporter(dt, "Bảng lương", DateTime.Now);
            if (exporter.SaveToExcel(out string savedFilePath, out string errorMessage))
            {
                MessageBox.Show($"Xuất file thành công!\nĐường dẫn: {savedFilePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dgvChiTietLuong_Enter(object sender, EventArgs e)
        {
            dgvDangChon = dgvChiTietLuong;
        }

        private void dgvTongHopLuong_Enter(object sender, EventArgs e)
        {
            dgvDangChon = dgvTongHopLuong;
        }


    }
}
