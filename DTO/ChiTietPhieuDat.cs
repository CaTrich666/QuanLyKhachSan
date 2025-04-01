using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuDat
    {
        public ChiTietPhieuDat(int maPD, int maPhong)
        {
            this.MaPD = maPD;
            this.MaPhong = maPhong;
        }

        public ChiTietPhieuDat(DataRow row)
        {
            this.MaPD = Convert.ToInt32(row["MAPD"]);
            this.MaPhong = Convert.ToInt32(row["MAPHONG"]);
        }

        private int maPD;
        public int MaPD { get => maPD; set => maPD = value; }

        private int maPhong;
        public int MaPhong { get => maPhong; set => maPhong = value; }
    }

}
