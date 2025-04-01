using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeDichVu
    {
        public ThongKeDichVu(int maDV, string tenDV, decimal tongDoanhThu, int soLanDat)
        {
            this.MaDV = maDV;
            this.TenDV = tenDV;
            this.TongDoanhThu = tongDoanhThu;
            this.SoLanDat = soLanDat;
        }

        public ThongKeDichVu() { }
        public ThongKeDichVu(DataRow row)
        {
            this.MaDV = Convert.ToInt32(row["MADV"]);
            this.TenDV = row["TENDV"].ToString();
            this.TongDoanhThu = Convert.ToDecimal(row["TONG_DOANH_THU"]);
            this.SoLanDat = Convert.ToInt32(row["SO_LAN_DAT"]);
        }

        private int maDV;
        public int MaDV { get => maDV; set => maDV = value; }

        private string tenDV;
        public string TenDV { get => tenDV; set => tenDV = value; }

        private decimal tongDoanhThu;
        public decimal TongDoanhThu { get => tongDoanhThu; set => tongDoanhThu = value; }

        private int soLanDat;
        public int SoLanDat { get => soLanDat; set => soLanDat = value; }
    }

}
