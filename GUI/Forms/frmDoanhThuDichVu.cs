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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.Forms
{
    public partial class frmDoanhThuDichVu : Form
    {
        public frmDoanhThuDichVu()
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
            // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime ngayBatDau = dtpTuNgay.Value;
            DateTime ngayKetThuc = dtpDenNgay.Value;

            // Lấy dữ liệu từ BLL
            List<ThongKeDichVu> danhSachThongKe = ThongKeBLL.Instance.ThongKeDichVu(ngayBatDau, ngayKetThuc);

            // Hiển thị dữ liệu trên DataGridView
            dgvDichVu.DataSource = danhSachThongKe;

            // Xóa dữ liệu cũ trên biểu đồ
            chartDichVu.Series.Clear();
            chartDichVu.Titles.Clear();
            chartDichVu.Titles.Add("Thống kê doanh thu dịch vụ");

            // Tính tổng doanh thu để tính phần trăm
            decimal tongDoanhThu = danhSachThongKe.Sum(dv => dv.TongDoanhThu);

            // Tạo Series mới
            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Pie;

            // Cấu hình hiển thị của biểu đồ
            series.IsValueShownAsLabel = true; // Hiển thị nhãn trên biểu đồ
            series.LabelFormat = "#,##0.##'%'"; // Định dạng số phần trăm
            series.LegendText = "#AXISLABEL"; // Chú thích bên ngoài sẽ là tên dịch vụ

            // Thêm dữ liệu vào biểu đồ
            foreach (var item in danhSachThongKe)
            {
                if (tongDoanhThu > 0) // Tránh lỗi chia 0
                {
                    double phanTram = Math.Round((double)(item.TongDoanhThu / tongDoanhThu * 100), 2);
                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(item.TenDV, item.TongDoanhThu); // Gán giá trị
                    dp.Label = $"{phanTram}%"; // Hiển thị phần trăm trong biểu đồ
                    dp.LegendText = item.TenDV; // Chú thích bên ngoài là tên dịch vụ
                    series.Points.Add(dp);
                }
            }

            // Thêm series vào chart
            chartDichVu.Series.Add(series);

            // Hiển thị phần chú thích
            chartDichVu.Legends.Clear();
            Legend legend = new Legend();
            legend.Title = "Dịch vụ";
            chartDichVu.Legends.Add(legend);

        }

    }
}
