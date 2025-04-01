using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDichVu
    {
        public ChiTietDichVu(int maPD, int maDV, int soLuong)
        {
            this.MaPD = maPD;
            this.MaDV = maDV;
            this.SoLuong = soLuong;
        }

        public ChiTietDichVu(DataRow row)
        {
            this.MaPD = Convert.ToInt32(row["MAPD"]);
            this.MaDV = Convert.ToInt32(row["MADV"]);
            this.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
        }

        private int maPD;
        public int MaPD { get => maPD; set => maPD = value; }

        private int maDV;
        public int MaDV { get => maDV; set => maDV = value; }

        private int soLuong;
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
