using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CaLam
    {
        public CaLam(int maCa, string tenCa, TimeSpan gioBD, TimeSpan gioKT, float heSoLuong, decimal giaCL)
        {
            this.MaCa = maCa;
            this.TenCa = tenCa;
            this.GioBD = gioBD;
            this.GioKT = gioKT;
            this.HeSoLuong = heSoLuong;
            this.GiaCL = giaCL;
        }

        public CaLam(DataRow row)
        {
            this.MaCa = Convert.ToInt32(row["MACA"]);
            this.TenCa = row["TENCA"].ToString();
            this.GioBD = (TimeSpan)row["GIO_BD"];
            this.GioKT = (TimeSpan)row["GIO_KT"];
            this.HeSoLuong = Convert.ToSingle(row["HESOLUONG"]);
            this.GiaCL = Convert.ToDecimal(row["GIA_CL"]);
        }

        public CaLam() { }


        private int maCa;
        public int MaCa { get => maCa; set => maCa = value; }

        private string tenCa;
        public string TenCa { get => tenCa; set => tenCa = value; }

        private TimeSpan gioBD;
        public TimeSpan GioBD { get => gioBD; set => gioBD = value; }

        private TimeSpan gioKT;
        public TimeSpan GioKT { get => gioKT; set => gioKT = value; }

        private float heSoLuong;
        public float HeSoLuong { get => heSoLuong; set => heSoLuong = value; }

        private decimal giaCL;
        public decimal GiaCL { get => giaCL; set => giaCL = value; }
        public string HienThi => $"{MaCa} - {TenCa}";
    }
}
