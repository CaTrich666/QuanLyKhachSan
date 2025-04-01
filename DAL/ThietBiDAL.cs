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
    public class ThietBiDAL
    {
        private static ThietBiDAL instance;
        public static ThietBiDAL Instance
        {
            get { if (instance == null) instance = new ThietBiDAL(); return instance; }
            private set => instance = value;
        }

        private ThietBiDAL() { }




        //Load dữ liệu thiết bị
        public List<ThietBi> GetListThietBi()
        {
            List<ThietBi> list = new List<ThietBi>();
            string query = "SELECT * FROM THIET_BI ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThietBi thietbi = new ThietBi(item);
                list.Add(thietbi);
            }
            return list;
        }




        // Thêm thiết bị
        public bool InsertThietBi(ThietBi thietBi)
        {
            string query = "INSERT INTO THIET_BI (TENTB, TINHTRANG_TB, MAPHONG, VI_TRI_SU_DUNG) VALUES (@tenTB, @tinhTrangTB, @maPhong, @viTriSuDung)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenTB", SqlDbType.NVarChar) { Value = thietBi.TenTB },
                new SqlParameter("@tinhTrangTB", SqlDbType.NVarChar) { Value = thietBi.TinhTrangTB },
                new SqlParameter("@maPhong", SqlDbType.Int) { Value = (object)thietBi.MaPhong ?? DBNull.Value },
                new SqlParameter("@viTriSuDung", SqlDbType.NVarChar) { Value = thietBi.ViTriSuDung }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Cập nhật thiết bị
        public bool UpdateThietBi(ThietBi thietBi)
        {
            string query = "UPDATE THIET_BI SET TENTB = @tenTB, TINHTRANG_TB = @tinhTrangTB, MAPHONG = @maPhong, VI_TRI_SU_DUNG = @viTriSuDung WHERE MATB = @maTB";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenTB", SqlDbType.NVarChar) { Value = thietBi.TenTB },
                new SqlParameter("@tinhTrangTB", SqlDbType.NVarChar) { Value = thietBi.TinhTrangTB },
                new SqlParameter("@maPhong", SqlDbType.Int) { Value = (object)thietBi.MaPhong ?? DBNull.Value },
                new SqlParameter("@viTriSuDung", SqlDbType.NVarChar) { Value = thietBi.ViTriSuDung },
                new SqlParameter("@maTB", SqlDbType.Int) { Value = thietBi.MaTB } // Không thay đổi, chỉ dùng để xác định thiết bị cần cập nhật
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa thiết bị
        public bool DeleteThietBi(int maTB)
        {
            string query = "DELETE FROM THIET_BI WHERE MATB = @maTB";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@maTB", SqlDbType.Int) { Value = maTB }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Tìm kiếm
        public List<ThietBi> SearchTBByName(string tenTB)
        {
            List<ThietBi> list = new List<ThietBi>();
            string query = "SELECT * FROM THIET_BI WHERE dbo.fuConvertToUnsign1(TENTB) LIKE dbo.fuConvertToUnsign1(N'%' + @tenTB + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenTB });

            foreach (DataRow item in data.Rows)
            {
                ThietBi thietbi = new ThietBi(item);
                list.Add(thietbi);
            }

            return list;
        }



    }
}
