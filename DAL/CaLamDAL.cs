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
    public class CaLamDAL
    {
        private static CaLamDAL instance;
        public static CaLamDAL Instance
        {
            get { if (instance == null) instance = new CaLamDAL(); return instance; }
            private set => instance = value;
        }

        private CaLamDAL() { }



        //Load dữ liệu ca làm
        public List<CaLam> GetListCaLam()
        {
            List<CaLam> list = new List<CaLam>();
            string query = "SELECT * FROM CA_LAM ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CaLam calam = new CaLam(item);
                list.Add(calam);
            }
            return list;
        }



        // Thêm ca làm
        public bool InsertCaLam(CaLam caLam)
        {
            string query = "INSERT INTO CA_LAM (TENCA, GIO_BD, GIO_KT, HESOLUONG, GIA_CL) VALUES (@tenCa, @gioBD, @gioKT, @heSoLuong, @giaCL)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenCa", SqlDbType.NVarChar) { Value = caLam.TenCa },
                new SqlParameter("@gioBD", SqlDbType.Time) { Value = caLam.GioBD },
                new SqlParameter("@gioKT", SqlDbType.Time) { Value = caLam.GioKT },
                new SqlParameter("@heSoLuong", SqlDbType.Float) { Value = caLam.HeSoLuong },
                new SqlParameter("@giaCL", SqlDbType.Decimal) { Value = caLam.GiaCL }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Cập nhật ca làm
        public bool UpdateCaLam(CaLam caLam)
        {
            string query = "UPDATE CA_LAM SET TENCA = @tenCa, GIO_BD = @gioBD, GIO_KT = @gioKT, HESOLUONG = @heSoLuong, GIA_CL = @giaCL WHERE MACA = @maCa";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenCa", SqlDbType.NVarChar) { Value = caLam.TenCa },
                new SqlParameter("@gioBD", SqlDbType.Time) { Value = caLam.GioBD },
                new SqlParameter("@gioKT", SqlDbType.Time) { Value = caLam.GioKT },
                new SqlParameter("@heSoLuong", SqlDbType.Float) { Value = caLam.HeSoLuong },
                new SqlParameter("@giaCL", SqlDbType.Decimal) { Value = caLam.GiaCL },
                new SqlParameter("@maCa", SqlDbType.Int) { Value = caLam.MaCa } // Dùng để xác định ca làm cần sửa
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Xóa ca làm
        public bool DeleteCaLam(int maCa)
        {
            string query = "DELETE FROM CA_LAM WHERE MACA = @maCa";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maCa", SqlDbType.Int) { Value = maCa }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Tìm kiếm
        public List<CaLam> SearchCLByName(string tenCa)
        {
            List<CaLam> list = new List<CaLam>();
            string query = "SELECT * FROM CA_LAM WHERE dbo.fuConvertToUnsign1(TENCA) LIKE dbo.fuConvertToUnsign1(N'%' + @tenCa + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenCa });

            foreach (DataRow item in data.Rows)
            {
                CaLam calam = new CaLam(item);
                list.Add(calam);
            }

            return list;
        }



    }
}
