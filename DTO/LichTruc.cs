using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichTruc
    {
        public LichTruc(int maLT, int? maNV, int? maCa, DateTime ngayTruc)
        {
            this.MaLT = maLT;
            this.MaNV = maNV;
            this.MaCa = maCa;
            this.NgayTruc = ngayTruc;
        }

        public LichTruc(DataRow row)
        {
            this.MaLT = Convert.ToInt32(row["MALT"]);
            this.MaNV = row["MANV"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MANV"]);
            this.MaCa = row["MACA"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MACA"]);
            this.NgayTruc = Convert.ToDateTime(row["NGAY_TRUC"]);
        }

        private int maLT;
        public int MaLT { get => maLT; set => maLT = value; }

        private int? maNV;
        public int? MaNV { get => maNV; set => maNV = value; }

        private int? maCa;
        public int? MaCa { get => maCa; set => maCa = value; }

        private DateTime ngayTruc;
        public DateTime NgayTruc { get => ngayTruc; set => ngayTruc = value; }

    }
}
