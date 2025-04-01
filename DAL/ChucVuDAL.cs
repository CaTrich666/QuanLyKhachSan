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
    public class ChucVuDAL
    {
        private static ChucVuDAL instance;
        public static ChucVuDAL Instance
        {
            get { if (instance == null) instance = new ChucVuDAL(); return instance; }
            private set => instance = value;
        }

        private ChucVuDAL() { }



        //Load dữ liệu chức vụ
        public List<ChucVu> GetListChucVu()
        {
            List<ChucVu> list = new List<ChucVu>();
            string query = "SELECT * FROM CHUC_VU ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ChucVu chucvu = new ChucVu(item);
                list.Add(chucvu);
            }
            return list;
        }


        // Thêm chức vụ
        public bool InsertChucVu(ChucVu chucVu)
        {
            string query = "INSERT INTO CHUC_VU (TENCV, DONGIA) VALUES (@tenCV, @donGia)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenCV", SqlDbType.NVarChar) { Value = chucVu.TenCV },
                new SqlParameter("@donGia", SqlDbType.Decimal) { Value = chucVu.DonGia }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Cập nhật chức vụ
        public bool UpdateChucVu(ChucVu chucVu)
        {
            string query = "UPDATE CHUC_VU SET TENCV = @tenCV, DONGIA = @donGia WHERE MACV = @maCV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenCV", SqlDbType.NVarChar) { Value = chucVu.TenCV },
                new SqlParameter("@donGia", SqlDbType.Decimal) { Value = chucVu.DonGia },
                new SqlParameter("@maCV", SqlDbType.Int) { Value = chucVu.MaCV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Xóa chức vụ
        public bool DeleteChucVu(int maCV)
        {
            string query = "DELETE FROM CHUC_VU WHERE MACV = @maCV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maCV", SqlDbType.Int) { Value = maCV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Tìm kiếm
        public List<ChucVu> SearchCVByName(string tenCV)
        {
            List<ChucVu> list = new List<ChucVu>();
            string query = "SELECT * FROM CHUC_VU WHERE dbo.fuConvertToUnsign1(TENCV) LIKE dbo.fuConvertToUnsign1(N'%' + @tenCV + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenCV });

            foreach (DataRow item in data.Rows)
            {
                ChucVu chucvu = new ChucVu(item);
                list.Add(chucvu);
            }

            return list;
        }


    }
}
