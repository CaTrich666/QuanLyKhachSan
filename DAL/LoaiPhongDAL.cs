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
    public class LoaiPhongDAL
    {
        private static LoaiPhongDAL instance;
        public static LoaiPhongDAL Instance
        {
            get { if (instance == null) instance = new LoaiPhongDAL(); return instance; }
            private set => instance = value;
        }

        private LoaiPhongDAL() { }




        //Load dữ liệu loại phòng
        public List<LoaiPhong> GetListLoaiPhong()
        {
            List<LoaiPhong> list = new List<LoaiPhong>();
            string query = "SELECT * FROM LOAI_PHONG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiPhong loaiphong = new LoaiPhong(item);
                list.Add(loaiphong);
            }
            return list;
        }



        // Thêm loại phòng
        public bool InsertLoaiPhong(LoaiPhong loaiPhong)
        {
            string query = "INSERT INTO LOAI_PHONG (TENLOAI, GIA_LP, SONGUOI_TD) VALUES (@tenLoai, @giaLP, @soNguoiTD)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenLoai", SqlDbType.NVarChar) { Value = loaiPhong.TenLoai },
                new SqlParameter("@giaLP", SqlDbType.Decimal) { Value = loaiPhong.GiaLP },
                new SqlParameter("@soNguoiTD", SqlDbType.Int) { Value = loaiPhong.SoNguoiTD }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Cập nhật loại phòng
        public bool UpdateLoaiPhong(LoaiPhong loaiPhong)
        {
            string query = "UPDATE LOAI_PHONG SET TENLOAI = @tenLoai, GIA_LP = @giaLP, SONGUOI_TD = @soNguoiTD WHERE MALOAI = @maLoai";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenLoai", SqlDbType.NVarChar) { Value = loaiPhong.TenLoai },
                new SqlParameter("@giaLP", SqlDbType.Decimal) { Value = loaiPhong.GiaLP },
                new SqlParameter("@soNguoiTD", SqlDbType.Int) { Value = loaiPhong.SoNguoiTD },
                new SqlParameter("@maLoai", SqlDbType.Int) { Value = loaiPhong.MaLoai } // Chỉ dùng để xác định dòng cần cập nhật
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }






        // Xóa loại phòng
        public bool DeleteLoaiPhong(int maLoai)
        {
            string query = "DELETE FROM LOAI_PHONG WHERE MALOAI = @maLoai";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maLoai", SqlDbType.Int) { Value = maLoai }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }




        // Tìm kiếm
        public List<LoaiPhong> SearchLPByName(string tenLoai)
        {
            List<LoaiPhong> list = new List<LoaiPhong>();
            string query = "SELECT * FROM LOAI_PHONG WHERE dbo.fuConvertToUnsign1(TENLOAI) LIKE dbo.fuConvertToUnsign1(N'%' + @tenLoai + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenLoai });

            foreach (DataRow item in data.Rows)
            {
                LoaiPhong loaiphong = new LoaiPhong(item);
                list.Add(loaiphong);
            }

            return list;
        }






        // Lấy thông tin loại phòng dựa vào MaLoai
        public LoaiPhong GetLoaiPhongById(int maLoai)
        {
            string query = "SELECT * FROM LOAI_PHONG WHERE MALOAI = @maLoai";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLoai });

            if (data.Rows.Count > 0)
            {
                return new LoaiPhong(data.Rows[0]);
            }
            return null;
        }







    }
}
