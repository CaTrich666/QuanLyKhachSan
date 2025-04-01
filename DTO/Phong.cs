using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Phong
    {
        public Phong(int maPhong, string tenPhong, string tinhTrangP, int maLoai)
        {
            this.MaPhong = maPhong;
            this.TenPhong = tenPhong;
            this.TinhTrangP = tinhTrangP;
            this.MaLoai = maLoai;
        }

        public Phong(DataRow row)
        {
            this.MaPhong = Convert.ToInt32(row["MAPHONG"]);
            this.TenPhong = row["TENPHONG"].ToString();
            this.TinhTrangP = row["TINHTRANG_P"].ToString();
            this.MaLoai = Convert.ToInt32(row["MALOAI"]);
        }

        private int maPhong;
        public int MaPhong { get => maPhong; set => maPhong = value; }

        private string tenPhong;
        public string TenPhong { get => tenPhong; set => tenPhong = value; }

        private string tinhTrangP;
        public string TinhTrangP { get => tinhTrangP; set => tinhTrangP = value; }

        private int maLoai;
        public int MaLoai { get => maLoai; set => maLoai = value; }
    }
}
