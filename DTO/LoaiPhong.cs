using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiPhong
    {
        public LoaiPhong(int maLoai, string tenLoai, decimal giaLP, int soNguoiTD)
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
            this.GiaLP = giaLP;
            this.SoNguoiTD = soNguoiTD;
        }

        public LoaiPhong(DataRow row)
        {
            this.MaLoai = Convert.ToInt32(row["MALOAI"]);
            this.TenLoai = row["TENLOAI"].ToString();
            this.GiaLP = Convert.ToDecimal(row["GIA_LP"]);
            this.SoNguoiTD = Convert.ToInt32(row["SONGUOI_TD"]);
        }


        public LoaiPhong() { }



        

        private int maLoai;
        public int MaLoai { get => maLoai; set => maLoai = value; }

        private string tenLoai;
        public string TenLoai { get => tenLoai; set => tenLoai = value; }

        private decimal giaLP;
        public decimal GiaLP { get => giaLP; set => giaLP = value; }

        private int soNguoiTD;
        public int SoNguoiTD { get => soNguoiTD; set => soNguoiTD = value; }
        public string HienThi => $"{MaLoai} - {TenLoai}";
    }
}
