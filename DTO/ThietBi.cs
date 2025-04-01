using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThietBi
    {
        public ThietBi(int maTB, string tenTB, string tinhTrangTB, int? maPhong, string viTriSuDung)
        {
            this.MaTB = maTB;
            this.TenTB = tenTB;
            this.TinhTrangTB = tinhTrangTB;
            this.MaPhong = maPhong;
            this.ViTriSuDung = viTriSuDung;
        }

        public ThietBi(DataRow row)
        {
            this.MaTB = Convert.ToInt32(row["MATB"]);
            this.TenTB = row["TENTB"].ToString();
            this.TinhTrangTB = row["TINHTRANG_TB"].ToString();
            this.MaPhong = row["MAPHONG"] != DBNull.Value ? Convert.ToInt32(row["MAPHONG"]) : (int?)null;
            this.ViTriSuDung = row["VI_TRI_SU_DUNG"].ToString();
        }

        private int maTB;
        public int MaTB { get => maTB; set => maTB = value; }

        private string tenTB;
        public string TenTB { get => tenTB; set => tenTB = value; }

        private string tinhTrangTB;
        public string TinhTrangTB { get => tinhTrangTB; set => tinhTrangTB = value; }

        private int? maPhong;
        public int? MaPhong { get => maPhong; set => maPhong = value; }

        private string viTriSuDung;
        public string ViTriSuDung { get => viTriSuDung; set => viTriSuDung = value; }
    }
}
