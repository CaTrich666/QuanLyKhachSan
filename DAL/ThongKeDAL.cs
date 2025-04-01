using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongKeDAL
    {
        private static ThongKeDAL instance;
        public static ThongKeDAL Instance
        {
            get { if (instance == null) instance = new ThongKeDAL(); return instance; }
            private set => instance = value;
        }

        private ThongKeDAL() { }



        public List<ThongKeDichVu> ThongKeDichVu(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            List<ThongKeDichVu> danhSachThongKe = new List<ThongKeDichVu>();

            string query = @"SELECT dv.MADV, dv.TENDV, 
                            SUM(ctdv.SO_LUONG * dv.GIA_DV) AS TONG_DOANH_THU, 
                            SUM(ctdv.SO_LUONG) AS SO_LAN_DAT
                            FROM CHI_TIET_DV ctdv
                            JOIN DICH_VU dv ON ctdv.MADV = dv.MADV
                            JOIN PHIEU_DAT pd ON ctdv.MAPD = pd.MAPD
                            WHERE pd.NGAYDAT >= @NgayBatDau AND pd.NGAYDAT <= @NgayKetThuc
                            GROUP BY dv.MADV, dv.TENDV
                            ORDER BY SO_LAN_DAT DESC";

            //Đảm bảo tham số đúng kiểu và không NULL
            object[] parameters = { ngayBatDau, ngayKetThuc };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                ThongKeDichVu tk = new ThongKeDichVu(
                    Convert.ToInt32(row["MADV"]),
                    row["TENDV"].ToString(),
                    row["TONG_DOANH_THU"] != DBNull.Value ? Convert.ToDecimal(row["TONG_DOANH_THU"]) : 0,
                    row["SO_LAN_DAT"] != DBNull.Value ? Convert.ToInt32(row["SO_LAN_DAT"]) : 0
                );
                danhSachThongKe.Add(tk);
            }

            return danhSachThongKe;
        }























    }
}
