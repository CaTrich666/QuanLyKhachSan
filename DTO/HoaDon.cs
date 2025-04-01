using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public HoaDon(int maHD, DateTime ngayLap, decimal tongTienPhong, decimal tongTienDV, int giamGia, string ptThanhToan, string trangThaiHD, decimal tongTienThanhToan, int maPD, int maNV)
        {
            this.MaHD = maHD;
            this.NgayLap = ngayLap;
            this.TongTienPhong = tongTienPhong;
            this.TongTienDV = tongTienDV;
            this.GiamGia = giamGia;
            this.PtThanhToan = ptThanhToan;
            this.TrangThaiHD = trangThaiHD;
            this.TongTienThanhToan = tongTienThanhToan;
            this.MaPD = maPD;
            this.MaNV = maNV;
        }

        public HoaDon(DataRow row)
        {
            this.MaHD = Convert.ToInt32(row["MAHD"]);
            this.NgayLap = Convert.ToDateTime(row["NGAYLAP"]);
            this.TongTienPhong = Convert.ToDecimal(row["TONGTIENPHONG"]);
            this.TongTienDV = Convert.ToDecimal(row["TONGTIENDV"]);
            this.GiamGia = row["GIAM_GIA"] != DBNull.Value ? Convert.ToInt32(row["GIAM_GIA"]) : 0;
            this.PtThanhToan = row["PT_THANHTOAN"].ToString();
            this.TrangThaiHD = row["TRANGTHAI_HD"].ToString();
            this.TongTienThanhToan = Convert.ToDecimal(row["TONGTIENTHANHTOAN"]);
            this.MaPD = Convert.ToInt32(row["MAPD"]);
            this.MaNV = Convert.ToInt32(row["MANV"]);
        }

        private int maHD;
        public int MaHD { get => maHD; set => maHD = value; }

        private DateTime ngayLap;
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }

        private decimal tongTienPhong;
        public decimal TongTienPhong { get => tongTienPhong; set => tongTienPhong = value; }

        private decimal tongTienDV;
        public decimal TongTienDV { get => tongTienDV; set => tongTienDV = value; }

        private decimal tienCoc;
        public decimal TienCoc { get => tienCoc; set => tienCoc = value; }

        private int giamGia;
        public int GiamGia { get => giamGia; set => giamGia = value; }

        private string ptThanhToan;
        public string PtThanhToan { get => ptThanhToan; set => ptThanhToan = value; }

        private string trangThaiHD;
        public string TrangThaiHD { get => trangThaiHD; set => trangThaiHD = value; }

        private decimal tongTienThanhToan;
        public decimal TongTienThanhToan { get => tongTienThanhToan; set => tongTienThanhToan = value; }

        private int maPD;
        public int MaPD { get => maPD; set => maPD = value; }

        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }
    }
}
