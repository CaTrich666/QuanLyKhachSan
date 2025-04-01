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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.Forms
{
    public partial class frmThongKeHoaDon : Form
    {
        public frmThongKeHoaDon()
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
            panel1.ForeColor = ThemeColor.SecondaryColor;
        }




        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtpTuNgay.Value;
            DateTime ngayKetThuc = dtpDenNgay.Value;

            //Lấy danh sách hóa đơn trong khoảng thời gian
            List<HoaDon> danhSachHoaDon = HoaDonBLL.Instance.LayHoaDonTheoKhoang(ngayBatDau, ngayKetThuc);
            dgvHoaDon.DataSource = danhSachHoaDon;

            dgvHoaDon.Columns["TienCoc"].Visible = false;

            //Tính tổng doanh thu phòng & dịch vụ bằng cách cộng dồn
            decimal tongDoanhThuPhong = 0;
            decimal tongDoanhThuDichVu = 0;

            foreach (var hd in danhSachHoaDon)
            {
                tongDoanhThuPhong += hd.TongTienPhong;
                tongDoanhThuDichVu += hd.TongTienDV;
            }

            //Kiểm tra dữ liệu có hợp lệ không
            if (tongDoanhThuPhong == 0 && tongDoanhThuDichVu == 0)
            {
                MessageBox.Show("Không có doanh thu trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Xóa dữ liệu cũ trên biểu đồ
            chartThongKe.Series.Clear();
            chartThongKe.Titles.Clear();
            chartThongKe.Titles.Add("Thống kê doanh thu");

            //Kiểm tra & tạo ChartArea nếu chưa có
            if (chartThongKe.ChartAreas.Count == 0)
            {
                chartThongKe.ChartAreas.Add(new ChartArea("MainArea"));
            }

            // Cấu hình trục Y
            chartThongKe.ChartAreas[0].AxisY.Minimum = 0; // Đảm bảo cột không bị ẩn
            chartThongKe.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";

            // Tạo Series mới cho biểu đồ cột
            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu vào biểu đồ
            series.Points.AddXY("Doanh thu phòng", tongDoanhThuPhong);
            series.Points.AddXY("Doanh thu dịch vụ", tongDoanhThuDichVu);

            // Hiển thị giá trị trên cột
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0"; // Hiển thị số nguyên, không có dấu phẩy thập phân

            // Thêm series vào chart
            chartThongKe.Series.Add(series);
        }
    
    }
}
