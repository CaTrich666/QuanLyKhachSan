using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public KhachHang(string cccd, string tenKH, string sdtKH, bool gioiTinhKH, string diaChi)
        {
            this.CCCD = cccd;
            this.TenKH = tenKH;
            this.SDT_KH = sdtKH;
            this.GioiTinh_KH = gioiTinhKH;
            this.DiaChi = diaChi;
        }

        public KhachHang(DataRow row)
        {
            this.CCCD = row["CCCD"].ToString();
            this.TenKH = row["TENKH"].ToString();
            this.SDT_KH = row["SDT_KH"].ToString();
            this.GioiTinh_KH = Convert.ToBoolean(row["GIOITINH_KH"]);
            this.DiaChi = row["DIACHI"].ToString();
        }

        private string cccd;
        public string CCCD { get => cccd; set => cccd = value; }

        private string tenKH;
        public string TenKH { get => tenKH; set => tenKH = value; }

        private string sdtKH;
        public string SDT_KH { get => sdtKH; set => sdtKH = value; }

        private bool gioiTinhKH;
        public bool GioiTinh_KH { get => gioiTinhKH; set => gioiTinhKH = value; }

        private string diaChi;
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }

}
