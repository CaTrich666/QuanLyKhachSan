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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
            Loads();
        }





        void Loads()
        {
            LoadListHoaDon();
            LoadTheme();

            SetupDateTimePicker(dtpNgayLap);
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
            groupBox2.ForeColor = ThemeColor.PrimaryColor;
            groupBox3.ForeColor = ThemeColor.SecondaryColor;
            groupBox4.ForeColor = ThemeColor.PrimaryColor;
        }


        void LoadListHoaDon()
        {
            var list = HoaDonBLL.Instance.GetListHoaDon();
            dtgvHoaDon.DataSource = list;
        }



        void SetupDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy HH:mm";
            dtp.ShowUpDown = true;
        }

        private void dtgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvHoaDon.Rows.Count)
            {
                DataGridViewRow selectRow = dtgvHoaDon.Rows[e.RowIndex];

                txtMaHD.Text = selectRow.Cells[0].Value?.ToString() ?? "";
                dtpNgayLap.Value = Convert.ToDateTime(selectRow.Cells[1].Value);
                txtTTP.Text = CurrencyFormatter.FormatToVND(selectRow.Cells[2].Value);

                txtTTDV.Text = CurrencyFormatter.FormatToVND(selectRow.Cells[3].Value);
                txtTienCoc.Text = CurrencyFormatter.FormatToVND(selectRow.Cells[4].Value);
                //txtGiamGia.Text = selectRow.Cells[5].Value?.ToString() ?? "";
                txtGiamGia.Text = CurrencyFormatter.FormatToPercentage(selectRow.Cells[5].Value);
                txtTTTT.Text = CurrencyFormatter.FormatToVND(selectRow.Cells[8].Value);
                txtTTHD.Text = selectRow.Cells[7].Value?.ToString() ?? "";
                txtPTTT.Text = selectRow.Cells[6].Value?.ToString() ?? "";
                txtMaPD.Text = selectRow.Cells[9].Value?.ToString() ?? "";
                txtMaNV.Text = selectRow.Cells[10].Value?.ToString() ?? "";
            }
        }

        private void btnSearchPD_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpBatDau.Value.Date;
            DateTime toDate = dtpKetThuc.Value.Date.AddDays(1).AddTicks(-1); // Chọn hết ngày

            List<HoaDon> listHoaDon = HoaDonBLL.Instance.SearchHoaDonByDate(fromDate, toDate);

            dtgvHoaDon.DataSource = listHoaDon;
        }
    }
}
