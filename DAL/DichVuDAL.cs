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
    public class DichVuDAL
    {
        private static DichVuDAL instance;
        public static DichVuDAL Instance
        {
            get { if (instance == null) instance = new DichVuDAL(); return instance; }
            private set => instance = value;
        }

        private DichVuDAL() { }



        //Load dữ liệu dịch vụ
        public List<DichVu> GetListDichVu()
        {
            List<DichVu> list = new List<DichVu>();
            string query = "SELECT * FROM DICH_VU ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DichVu dichvu = new DichVu(item);
                list.Add(dichvu);
            }
            return list;
        }


        // Thêm dịch vụ
        public bool InsertDichVu(DichVu dichVu)
        {
            string query = "INSERT INTO DICH_VU (TENDV, GIA_DV, TRANGTHAI_DV) VALUES (@tenDV, @giaDV, @trangThaiDV)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenDV", SqlDbType.NVarChar) { Value = dichVu.TenDV },
                new SqlParameter("@giaDV", SqlDbType.Decimal) { Value = dichVu.GiaDV },
                new SqlParameter("@trangThaiDV", SqlDbType.Bit) { Value = dichVu.TrangThaiDV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật dịch vụ
        public bool UpdateDichVu(DichVu dichVu)
        {
            string query = "UPDATE DICH_VU SET TENDV = @tenDV, GIA_DV = @giaDV, TRANGTHAI_DV = @trangThaiDV WHERE MADV = @maDV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenDV", SqlDbType.NVarChar) { Value = dichVu.TenDV },
                new SqlParameter("@giaDV", SqlDbType.Decimal) { Value = dichVu.GiaDV },
                new SqlParameter("@trangThaiDV", SqlDbType.Bit) { Value = dichVu.TrangThaiDV },
                new SqlParameter("@maDV", SqlDbType.Int) { Value = dichVu.MaDV } // Không thay đổi, chỉ dùng để xác định dịch vụ cần cập nhật
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Xóa dịch vụ
        public bool DeleteDichVu(int maDV)
        {
            string query = "DELETE FROM DICH_VU WHERE MADV = @maDV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maDV", SqlDbType.Int) { Value = maDV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Tìm kiếm
        public List<DichVu> SearchDVByName(string tenDV)
        {
            List<DichVu> list = new List<DichVu>();
            string query = "SELECT * FROM DICH_VU WHERE dbo.fuConvertToUnsign1(TENDV) LIKE dbo.fuConvertToUnsign1(N'%' + @tenDV + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDV });

            foreach (DataRow item in data.Rows)
            {
                DichVu dichvu = new DichVu(item);
                list.Add(dichvu);
            }

            return list;
        }




        // Truy vấn danh sách dịch vụ có TRANGTHAI_DV = 1 (đang hoạt động)
        public List<DichVu> GetAllDichVu()
        {
            List<DichVu> list = new List<DichVu>();
            string query = "SELECT * FROM DICH_VU WHERE TRANGTHAI_DV = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                DichVu dichvu = new DichVu(row);
                list.Add(dichvu);
            }

            return list;
        }























    }
}
