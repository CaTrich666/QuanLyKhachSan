using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDatWithAllDetails
    {
        //Constructor không tham số
        public PhieuDatWithAllDetails() { }

        //Constructor với các tham số
        public PhieuDatWithAllDetails(int maPD, int soNguoi, decimal tienCoc, DateTime ngayDat, DateTime ngayNhanPhong,
                                DateTime ngayTraPhong, string cccd, string tenKH, string sdtKH, bool gioiTinhKH,
                                string tenLoai, decimal giaLP, string tenPhong, List<int> maDV, List<string> tenDV,
                                List<decimal> giaDV, List<int> soLuong)
        {
            this.MaPD = maPD;
            this.SoNguoi = soNguoi;
            this.TienCoc = tienCoc;
            this.NgayDat = ngayDat;
            this.NgayNhanPhong = ngayNhanPhong;
            this.NgayTraPhong = ngayTraPhong;
            this.CCCD = cccd;
            this.TenKH = tenKH;
            this.SDT_KH = sdtKH;
            this.GioiTinhKH = gioiTinhKH;
            this.TenLoai = tenLoai;
            this.GiaLP = giaLP;
            this.TenPhong = tenPhong;
            this.MaDV = maDV;
            this.TenDV = tenDV;
            this.GiaDV = giaDV;
            this.SoLuong = soLuong;
        }

        //Constructor từ DataRow (để chuyển đổi từ dữ liệu lấy từ database)
        public PhieuDatWithAllDetails(DataRow row)
        {
            this.MaPD = Convert.ToInt32(row["MAPD"]);
            this.SoNguoi = Convert.ToInt32(row["SONGUOI"]);
            this.TienCoc = Convert.ToDecimal(row["TIENCOC"]);
            this.NgayDat = Convert.ToDateTime(row["NGAYDAT"]);
            this.NgayNhanPhong = Convert.ToDateTime(row["NGAY_NHANPHONG"]);
            this.NgayTraPhong = Convert.ToDateTime(row["NGAY_TRAPHONG"]);
            this.CCCD = row["CCCD"].ToString();
            this.TenKH = row["TENKH"].ToString();
            this.SDT_KH = row["SDT_KH"].ToString();
            this.GioiTinhKH = Convert.ToBoolean(row["GIOITINH_KH"]);
            this.TenLoai = row["TENLOAI"].ToString();
            this.GiaLP = Convert.ToDecimal(row["GIA_LP"]);
            this.TenPhong = row["TENPHONG"].ToString();

            //Xử lý dịch vụ
            this.MaDV = row["MADV"] != DBNull.Value ? row["MADV"].ToString().Split(',').Select(int.Parse).ToList() : new List<int>();
            this.TenDV = row["TENDV"] != DBNull.Value ? row["TENDV"].ToString().Split(',').ToList() : new List<string>();
            this.GiaDV = row["GIA_DV"] != DBNull.Value ? row["GIA_DV"].ToString().Split(',').Select(decimal.Parse).ToList() : new List<decimal>();
            this.SoLuong = row["SO_LUONG"] != DBNull.Value ? row["SO_LUONG"].ToString().Split(',').Select(int.Parse).ToList() : new List<int>();
        }

        //Thuộc tính của PhieuDat
        public int MaPD { get; set; }
        public int SoNguoi { get; set; }
        public decimal TienCoc { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayNhanPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public string CCCD { get; set; }

        //Thuộc tính của KhachHang
        public string TenKH { get; set; }
        public string SDT_KH { get; set; }
        public bool GioiTinhKH { get; set; }

        //Thuộc tính của LoaiPhong
        public string TenLoai { get; set; }
        public decimal GiaLP { get; set; }

        //Thuộc tính của Phong
        public string TenPhong { get; set; }

        //Danh sách chi tiết dịch vụ
        public List<int> MaDV { get; set; }
        public List<string> TenDV { get; set; }
        public List<decimal> GiaDV { get; set; }
        public List<int> SoLuong { get; set; }

    }
}