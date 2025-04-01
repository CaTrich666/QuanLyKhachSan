using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public NhanVien(int maNV, string tenNV, DateTime ngaySinh, bool gioiTinhNV, string sdtNV, int maCV)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.NgaySinh = ngaySinh;
            this.GioiTinhNV = gioiTinhNV;
            this.SdtNV = sdtNV;
            this.MaCV = maCV;
        }

        public NhanVien(DataRow row)
        {
            this.MaNV = Convert.ToInt32(row["MANV"]);
            this.TenNV = row["TENNV"].ToString();
            this.NgaySinh = Convert.ToDateTime(row["NGAYSINH"]);
            this.GioiTinhNV = Convert.ToBoolean(row["GIOITINH_NV"]);
            this.SdtNV = row["SDT_NV"].ToString();
            this.MaCV = Convert.ToInt32(row["MACV"]);
        }


        public NhanVien() { }



        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }

        private string tenNV;
        public string TenNV { get => tenNV; set => tenNV = value; }

        private DateTime ngaySinh;
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        private bool gioiTinhNV;
        public bool GioiTinhNV { get => gioiTinhNV; set => gioiTinhNV = value; }

        private string sdtNV;
        public string SdtNV { get => sdtNV; set => sdtNV = value; }

        private int maCV;
        public int MaCV { get => maCV; set => maCV = value; }
        public string HienThi => $"{MaNV} - {TenNV}";
    }
}
