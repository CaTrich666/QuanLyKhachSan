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
    public class NhanVienDAL
    {
        private static NhanVienDAL instance;
        public static NhanVienDAL Instance
        {
            get { if (instance == null) instance = new NhanVienDAL(); return instance; }
            private set => instance = value;
        }

        private NhanVienDAL() { }


        //Load dữ liệu nhân viên
        public List<NhanVien> GetListNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = "SELECT * FROM NHAN_VIEN ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanvien = new NhanVien(item);
                list.Add(nhanvien);
            }
            return list;
        }


        // Thêm nhân viên
        public bool InsertNhanVien(NhanVien nhanVien)
        {
            string query = "INSERT INTO NHAN_VIEN (TENNV, NGAYSINH, GIOITINH_NV, SDT_NV, MACV) VALUES (@tenNV, @ngaySinh, @gioiTinhNV, @sdtNV, @maCV)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenNV", SqlDbType.NVarChar) { Value = (object)nhanVien.TenNV ?? DBNull.Value },
                new SqlParameter("@ngaySinh", SqlDbType.Date) { Value = nhanVien.NgaySinh },
                new SqlParameter("@gioiTinhNV", SqlDbType.Bit) { Value = nhanVien.GioiTinhNV },
                new SqlParameter("@sdtNV", SqlDbType.NVarChar) { Value = (object)nhanVien.SdtNV ?? DBNull.Value },
                new SqlParameter("@maCV", SqlDbType.Int) { Value = nhanVien.MaCV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật nhân viên
        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            string query = "UPDATE NHAN_VIEN SET TENNV = @tenNV, NGAYSINH = @ngaySinh, GIOITINH_NV = @gioiTinhNV, SDT_NV = @sdtNV, MACV = @maCV WHERE MANV = @maNV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenNV", SqlDbType.NVarChar) { Value = nhanVien.TenNV },
                new SqlParameter("@ngaySinh", SqlDbType.Date) { Value = nhanVien.NgaySinh },
                new SqlParameter("@gioiTinhNV", SqlDbType.Bit) { Value = nhanVien.GioiTinhNV },
                new SqlParameter("@sdtNV", SqlDbType.NVarChar) { Value = nhanVien.SdtNV },
                new SqlParameter("@maCV", SqlDbType.Int) { Value = nhanVien.MaCV },
                new SqlParameter("@maNV", SqlDbType.Int) { Value = nhanVien.MaNV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa nhân viên
        public bool DeleteNhanVien(int maNV)
        {
            string query = "DELETE FROM NHAN_VIEN WHERE MANV = @maNV";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maNV", SqlDbType.Int) { Value = maNV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Tìm kiếm
        public List<NhanVien> SearchNVByName(string tenNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = "SELECT * FROM NHAN_VIEN WHERE dbo.fuConvertToUnsign1(TENNV) LIKE dbo.fuConvertToUnsign1(N'%' + @ttenNV + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenNV });

            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanvien = new NhanVien(item);
                list.Add(nhanvien);
            }

            return list;
        }



        // Lấy thông tin nhân viên theo mã nhân viên
        public NhanVien GetNhanVienByMaNV(int maNV)
        {
            string query = "SELECT * FROM NHAN_VIEN WHERE MANV = @MaNV";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maNV });

            return data.Rows.Count > 0 ? new NhanVien(data.Rows[0]) : null;
        }




    }
}
