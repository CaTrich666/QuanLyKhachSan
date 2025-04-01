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
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL instance;
        public static TaiKhoanDAL Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAL(); return instance; }
            private set => instance = value;
        }

        private TaiKhoanDAL() { }

        public TaiKhoan GetTaiKhoan(string tenTK, string matKhau)
        {
            string query = "EXEC USP_GetTaiKhoan @tenTK";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenTK });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                string dbUserName = row["TENTK"].ToString();
                string dbPassword = row["MATKHAU"].ToString();

                // So sánh phân biệt hoa-thường
                if (string.Equals(dbUserName, tenTK, StringComparison.Ordinal) &&
                    string.Equals(dbPassword, matKhau, StringComparison.Ordinal))
                {
                    // Chuyển đổi QUYEN từ kiểu BIT (0 hoặc 1) sang kiểu bool
                    bool dbRole = Convert.ToBoolean(row["QUYEN"]);

                    return new TaiKhoan(
                        dbUserName,
                        dbPassword,
                        dbRole,  // Truyền dbRole với kiểu bool
                        Convert.ToInt32(row["MANV"])
                    );
                }
            }

            return null;
        }


        //Load dữ liệu tài khoản
        public List<TaiKhoan> GetListTaiKhoan()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            string query = "SELECT * FROM TAI_KHOAN ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TaiKhoan taikhoan = new TaiKhoan(item);
                list.Add(taikhoan);
            }
            return list;
        }





        // Thêm tài khoản
        public bool InsertAccount(TaiKhoan account)
        {
            string query = "INSERT INTO TAI_KHOAN (TENTK, MATKHAU, QUYEN, MANV) VALUES (@tenTK, @matKhau, @quyen, @maNV)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenTK", SqlDbType.NVarChar) { Value = account.UserName },
                new SqlParameter("@matKhau", SqlDbType.NVarChar) { Value = account.PassWord },
                new SqlParameter("@quyen", SqlDbType.Bit) { Value = account.Role ? 1 : 0 },
                new SqlParameter("@maNV", SqlDbType.Int) { Value = account.MaNV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Cập nhật tài khoản
        public bool UpdateAccount(string oldUserName, TaiKhoan account)
        {
            string query = "UPDATE TAI_KHOAN SET TENTK = @newUserName, MATKHAU = @matKhau, QUYEN = @quyen, MANV = @maNV WHERE TENTK = @oldUserName";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@newUserName", SqlDbType.NVarChar) { Value = account.UserName },
                new SqlParameter("@matKhau", SqlDbType.NVarChar) { Value = account.PassWord },
                new SqlParameter("@quyen", SqlDbType.Bit) { Value = account.Role ? 1 : 0 },
                new SqlParameter("@maNV", SqlDbType.Int) { Value = account.MaNV },
                new SqlParameter("@oldUserName", SqlDbType.NVarChar) { Value = oldUserName }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }




        // Xóa tài khoản
        public bool DeleteAccount(string userName)
        {
            string query = "DELETE FROM TAI_KHOAN WHERE TENTK = @userName";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userName", SqlDbType.NVarChar) { Value = userName }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Tìm kiếm
        public List<TaiKhoan> SearchTKByName(string userName)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            string query = "SELECT * FROM TAI_KHOAN WHERE dbo.fuConvertToUnsign1(TENTK) LIKE dbo.fuConvertToUnsign1(N'%' + @userName + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

            foreach (DataRow item in data.Rows)
            {
                TaiKhoan taikhoan = new TaiKhoan(item);
                list.Add(taikhoan);
            }

            return list;
        }


        // Lấy thông tin tài khoản theo tên đăng nhập
        public TaiKhoan GetTaiKhoanByUserName(string tenTaiKhoan)
        {
            string query = "SELECT * FROM TAI_KHOAN WHERE TENTK = @TenTK";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenTaiKhoan });

            return data.Rows.Count > 0 ? new TaiKhoan(data.Rows[0]) : null;
        }




        // Cập nhật tài khoản của nhân viên
        public bool UpdateTaiKhoan(string tenTaiKhoanCu, string tenTaiKhoanMoi, string matKhauMoi)
        {
            string query = "UPDATE TAI_KHOAN SET TENTK = @TenTKMoi, MATKHAU = @MatKhauMoi WHERE TENTK = @TenTKCu";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenTKMoi", SqlDbType.NVarChar) { Value = tenTaiKhoanMoi },
                new SqlParameter("@MatKhauMoi", SqlDbType.NVarChar) { Value = matKhauMoi },
                new SqlParameter("@TenTKCu", SqlDbType.NVarChar) { Value = tenTaiKhoanCu }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }








    }
}
