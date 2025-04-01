using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVu
    {
        public ChucVu(int maCV, string tenCV, decimal donGia)
        {
            this.MaCV = maCV;
            this.TenCV = tenCV;
            this.DonGia = donGia;
        }

        public ChucVu(DataRow row)
        {
            this.MaCV = Convert.ToInt32(row["MACV"]);
            this.TenCV = row["TENCV"].ToString();
            this.DonGia = Convert.ToDecimal(row["DONGIA"]);
        }

        private int maCV;
        public int MaCV { get => maCV; set => maCV = value; }

        private string tenCV;
        public string TenCV { get => tenCV; set => tenCV = value; }

        private decimal donGia;
        public decimal DonGia { get => donGia; set => donGia = value; }
    }
}
