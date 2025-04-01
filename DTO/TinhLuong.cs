using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhLuong
    {
        public TinhLuong(int maNV, string tenNV, int maCa, string tenCa, int soLanLam, double heSoLuong, decimal giaCaLam,
                 decimal tongTienCaSang, decimal tongTienCaChieu, decimal tongTienCaDem, decimal tongTienCaLam,
                 decimal donGiaChucVu, decimal luongNhanVien)
        {
            MaNV = maNV;
            TenNV = tenNV;
            MaCa = maCa;
            TenCa = tenCa;
            SoLanLam = soLanLam;
            HeSoLuong = heSoLuong;
            GiaCaLam = giaCaLam;
            TongTienCaSang = tongTienCaSang;
            TongTienCaChieu = tongTienCaChieu;
            TongTienCaDem = tongTienCaDem;
            TongTienCaLam = tongTienCaLam;
            DonGiaChucVu = donGiaChucVu;
            LuongNhanVien = luongNhanVien;
        }

        public TinhLuong(DataRow row)
        {
            MaNV = Convert.ToInt32(row["MANV"]);
            TenNV = row["TENNV"].ToString();
            MaCa = Convert.ToInt32(row["MACA"]);
            TenCa = row["TENCA"].ToString();
            SoLanLam = row.Table.Columns.Contains("SOLAN_LAM") ? Convert.ToInt32(row["SOLAN_LAM"]) : 0;
            HeSoLuong = row.Table.Columns.Contains("HESOLUONG") ? Convert.ToDouble(row["HESOLUONG"]) : 0.0;
            GiaCaLam = row.Table.Columns.Contains("GIA_CL") ? Convert.ToDecimal(row["GIA_CL"]) : 0;

            // Tính toán tổng tiền cho các ca (nếu dữ liệu không có sẵn)
            TongTienCaSang = row.Table.Columns.Contains("TongTienCaSang") ? Convert.ToDecimal(row["TongTienCaSang"]) : SoLanLam * (decimal)(HeSoLuong * (double)GiaCaLam);
            TongTienCaChieu = row.Table.Columns.Contains("TongTienCaChieu") ? Convert.ToDecimal(row["TongTienCaChieu"]) : SoLanLam * (decimal)(HeSoLuong * (double)GiaCaLam);
            TongTienCaDem = row.Table.Columns.Contains("TongTienCaDem") ? Convert.ToDecimal(row["TongTienCaDem"]) : SoLanLam * (decimal)(HeSoLuong * (double)GiaCaLam);

            TongTienCaLam = TongTienCaSang + TongTienCaChieu + TongTienCaDem;

            DonGiaChucVu = row.Table.Columns.Contains("DonGiaChucVu") ? Convert.ToDecimal(row["DonGiaChucVu"]) : 0;
            LuongNhanVien = TongTienCaLam + DonGiaChucVu;
        }

        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }

        private string tenNV;
        public string TenNV { get => tenNV; set => tenNV = value; }

        private int maCa;
        public int MaCa { get => maCa; set => maCa = value; }

        private string tenCa;
        public string TenCa { get => tenCa; set => tenCa = value; }

        private int soLanLam;
        public int SoLanLam { get => soLanLam; set => soLanLam = value; }

        private double heSoLuong;
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }

        private decimal giaCaLam;
        public decimal GiaCaLam { get => giaCaLam; set => giaCaLam = value; }

        private decimal tongTienCaSang;
        public decimal TongTienCaSang { get => tongTienCaSang; set => tongTienCaSang = value; }

        private decimal tongTienCaChieu;
        public decimal TongTienCaChieu { get => tongTienCaChieu; set => tongTienCaChieu = value; }

        private decimal tongTienCaDem;
        public decimal TongTienCaDem { get => tongTienCaDem; set => tongTienCaDem = value; }

        private decimal tongTienCaLam;
        public decimal TongTienCaLam { get => tongTienCaLam; set => tongTienCaLam = value; }

        private decimal donGiaChucVu;
        public decimal DonGiaChucVu { get => donGiaChucVu; set => donGiaChucVu = value; }

        private decimal luongNhanVien;
        public decimal LuongNhanVien { get => luongNhanVien; set => luongNhanVien = value; }

    }
}
