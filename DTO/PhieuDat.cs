using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDat
    {
        public PhieuDat(int maPD, int soNguoi, string trangThaiPD, decimal tienCoc, DateTime ngayDat, DateTime ngayNhanPhong, DateTime ngayTraPhong, string cccd, int maNV)
        {
            this.MaPD = maPD;
            this.SoNguoi = soNguoi;
            this.TrangThaiPD = trangThaiPD;
            this.TienCoc = tienCoc;
            this.NgayDat = ngayDat;
            this.NgayNhanPhong = ngayNhanPhong;
            this.NgayTraPhong = ngayTraPhong;
            this.CCCD = cccd;
            this.MaNV = maNV;
        }

        public PhieuDat(DataRow row)
        {
            this.MaPD = Convert.ToInt32(row["MAPD"]);
            this.SoNguoi = Convert.ToInt32(row["SONGUOI"]);
            this.TrangThaiPD = row["TRANGTHAI_PD"].ToString();
            this.TienCoc = Convert.ToDecimal(row["TIENCOC"]);
            this.NgayDat = Convert.ToDateTime(row["NGAYDAT"]);
            this.NgayNhanPhong = Convert.ToDateTime(row["NGAY_NHANPHONG"]);
            this.NgayTraPhong = Convert.ToDateTime(row["NGAY_TRAPHONG"]);
            this.CCCD = row["CCCD"].ToString();
            this.MaNV = Convert.ToInt32(row["MANV"]);
        }

        private int maPD;
        public int MaPD { get => maPD; set => maPD = value; }

        private int soNguoi;
        public int SoNguoi { get => soNguoi; set => soNguoi = value; }

        private string trangThaiPD;
        public string TrangThaiPD { get => trangThaiPD; set => trangThaiPD = value; }

        private decimal tienCoc;
        public decimal TienCoc { get => tienCoc; set => tienCoc = value; }

        private DateTime ngayDat;
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }

        private DateTime ngayNhanPhong;
        public DateTime NgayNhanPhong { get => ngayNhanPhong; set => ngayNhanPhong = value; }

        private DateTime ngayTraPhong;
        public DateTime NgayTraPhong { get => ngayTraPhong; set => ngayTraPhong = value; }

        private string cccd;
        public string CCCD { get => cccd; set => cccd = value; }

        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }
    }

}
