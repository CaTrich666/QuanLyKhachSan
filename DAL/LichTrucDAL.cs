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
    public class LichTrucDAL
    {
        private static LichTrucDAL instance;
        public static LichTrucDAL Instance
        {
            get { if (instance == null) instance = new LichTrucDAL(); return instance; }
            private set => instance = value;
        }

        private LichTrucDAL() { }


        //Load dữ liệu lịch trực
        public List<LichTruc> GetListLichTruc()
        {
            List<LichTruc> list = new List<LichTruc>();
            string query = "SELECT * FROM LICH_TRUC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LichTruc lichtruc = new LichTruc(item);
                list.Add(lichtruc);
            }
            return list;
        }


        // Thêm lịch trực
        public bool InsertLichTruc(LichTruc lichTruc)
        {
            string query = "INSERT INTO LICH_TRUC (MANV, MACA, NGAY_TRUC) VALUES (@maNV, @maCa, @ngayTruc)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maNV", SqlDbType.Int) { Value = (object)lichTruc.MaNV ?? DBNull.Value },
                new SqlParameter("@maCa", SqlDbType.Int) { Value = (object)lichTruc.MaCa ?? DBNull.Value },
                new SqlParameter("@ngayTruc", SqlDbType.Date) { Value = lichTruc.NgayTruc }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật lịch trực
        public bool UpdateLichTruc(LichTruc lichTruc)
        {
            string query = "UPDATE LICH_TRUC SET MANV = @maNV, MACA = @maCa, NGAY_TRUC = @ngayTruc WHERE MALT = @maLT";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maNV", SqlDbType.Int) { Value = (object)lichTruc.MaNV ?? DBNull.Value },
                new SqlParameter("@maCa", SqlDbType.Int) { Value = (object)lichTruc.MaCa ?? DBNull.Value },
                new SqlParameter("@ngayTruc", SqlDbType.Date) { Value = lichTruc.NgayTruc },
                new SqlParameter("@maLT", SqlDbType.Int) { Value = lichTruc.MaLT }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa lịch trực
        public bool DeleteLichTruc(int maLT)
        {
            string query = "DELETE FROM LICH_TRUC WHERE MALT = @maLT";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maLT", SqlDbType.Int) { Value = maLT }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Tìm kiếm
        public List<LichTruc> SearchLT(string maLT)
        {
            List<LichTruc> list = new List<LichTruc>();
            string query = "SELECT * FROM LICH_TRUC WHERE dbo.fuConvertToUnsign1(MALT) LIKE dbo.fuConvertToUnsign1(N'%' + @maLT + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLT });

            foreach (DataRow item in data.Rows)
            {
                LichTruc lichtruc = new LichTruc(item);
                list.Add(lichtruc);
            }

            return list;
        }



    }
}
