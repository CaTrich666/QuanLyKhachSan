using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPhieuDatDAL
    {
        private static ChiTietPhieuDatDAL instance;
        public static ChiTietPhieuDatDAL Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuDatDAL(); return instance; }
            private set => instance = value;
        }

        private ChiTietPhieuDatDAL() { }




        //Load dữ phiếu đặt
        public List<ChiTietPhieuDat> GetListChiTietPhieuDat()
        {
            List<ChiTietPhieuDat> list = new List<ChiTietPhieuDat>();
            string query = "SELECT * FROM CHI_TIET_PD ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ChiTietPhieuDat phieudat = new ChiTietPhieuDat(item);
                list.Add(phieudat);
            }
            return list;
        }



        // thêm chi tiết phiếu đặt
        public bool InsertChiTietPhieuDat(ChiTietPhieuDat chiTiet)
        {
            string query = "INSERT INTO CHI_TIET_PD (MAPD, MAPHONG) VALUES (@maPD, @maPhong)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maPD", SqlDbType.Int) { Value = chiTiet.MaPD },
                new SqlParameter("@maPhong", SqlDbType.Int) { Value = chiTiet.MaPhong }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }





    }
}
