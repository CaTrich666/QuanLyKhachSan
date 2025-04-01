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
    public class PhongDAL
    {
        private static PhongDAL instance;
        public static PhongDAL Instance
        {
            get { if (instance == null) instance = new PhongDAL(); return instance; }
            private set => instance = value;
        }

        private PhongDAL() { }






        //Load dữ liệu phòng
        public List<Phong> GetListPhong()
        {
            List<Phong> list = new List<Phong>();
            string query = "SELECT * FROM Phong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Phong phong = new Phong(item);
                list.Add(phong);
            }
            return list;
        }




        // Thêm phòng
        public bool InsertPhong(Phong phong)
        {
            string query = "INSERT INTO PHONG (TENPHONG, TINHTRANG_P, MALOAI) VALUES (@tenPhong, @tinhTrangP, @maLoai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenPhong", SqlDbType.NVarChar) { Value = phong.TenPhong },
                new SqlParameter("@tinhTrangP", SqlDbType.NVarChar) { Value = phong.TinhTrangP },
                new SqlParameter("@maLoai", SqlDbType.Int) { Value = phong.MaLoai }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Cập nhật phòng
        public bool UpdatePhong(Phong phong)
        {
            string query = "UPDATE PHONG SET TENPHONG = @tenPhong, TINHTRANG_P = @tinhTrangP, MALOAI = @maLoai WHERE MAPHONG = @maPhong";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenPhong", SqlDbType.NVarChar) { Value = phong.TenPhong },
                new SqlParameter("@tinhTrangP", SqlDbType.NVarChar) { Value = phong.TinhTrangP },
                new SqlParameter("@maLoai", SqlDbType.Int) { Value = phong.MaLoai },
                new SqlParameter("@maPhong", SqlDbType.Int) { Value = phong.MaPhong } // Xác định phòng cần cập nhật
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Xóa phòng
        public bool DeletePhong(int maPhong)
        {
            string query = "DELETE FROM PHONG WHERE MAPHONG = @maPhong";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maPhong", SqlDbType.Int) { Value = maPhong }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Tìm kiếm
        public List<Phong> SearchPhongByName(string tenPhong)
        {
            List<Phong> list = new List<Phong>();
            string query = "SELECT * FROM PHONG WHERE dbo.fuConvertToUnsign1(TENPHONG) LIKE dbo.fuConvertToUnsign1(N'%' + @tenPhong + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenPhong });

            foreach (DataRow item in data.Rows)
            {
                Phong phong = new Phong(item);
                list.Add(phong);
            }

            return list;
        }



        // Lấy danh sách phòng trống
        public List<Phong> GetPhongTrong(int? maLoai = null)
        {
            List<Phong> list = new List<Phong>();
            string query = "SELECT * FROM PHONG P WHERE P.TINHTRANG_P = N'Trống' AND NOT EXISTS (SELECT 1 FROM CHI_TIET_PD CT WHERE CT.MAPHONG = P.MAPHONG)" + (maLoai.HasValue ? " AND P.MALOAI = @maLoai" : "");
            DataTable data = DataProvider.Instance.ExecuteQuery(query, maLoai.HasValue ? new object[] { maLoai.Value } : null);

            foreach (DataRow item in data.Rows)
            {
                Phong phong = new Phong(item);
                list.Add(phong);
            }
            return list;
        }








        //Lấy thông tin phòng từ phiếu đặt
        public Phong GetPhongByPhieuDat(int maPD)
        {
            string query = @"SELECT P.* FROM PHONG P JOIN CHI_TIET_PD CTPD ON P.MAPHONG = CTPD.MAPHONG WHERE CTPD.MAPD = @maPD";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maPD });

            if (data.Rows.Count > 0)
            {
                return new Phong(data.Rows[0]); // Trả về phòng đầu tiên tìm thấy
            }

            return null; // Không có phòng nào được tìm thấy
        }
















    }
}
