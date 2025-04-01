using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietDichVuDAL
    {
        private static ChiTietDichVuDAL instance;
        public static ChiTietDichVuDAL Instance
        {
            get { if (instance == null) instance = new ChiTietDichVuDAL(); return instance; }
            private set => instance = value;
        }

        private ChiTietDichVuDAL() { }




        // Thêm chi tiết dịch vụ
        //public bool InsertChiTietDichVu(ChiTietDichVu chiTietDV)
        //{
        //    string query = "INSERT INTO CHI_TIET_DV (MaPD, MaDV, SO_LUONG) VALUES (@MaPD, @MaDV, @SO_LUONG)";
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@MaPD", SqlDbType.Int) { Value = chiTietDV.MaPD },
        //        new SqlParameter("@MaDV", SqlDbType.Int) { Value = chiTietDV.MaDV },
        //        new SqlParameter("@SO_LUONG", SqlDbType.Int) { Value = chiTietDV.SoLuong }
        //    };
        //    return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        //}


        public bool InsertChiTietDichVu(ChiTietDichVu chiTietDV)
        {
            string query = "INSERT INTO CHI_TIET_DV (MaPD, MaDV, SO_LUONG) VALUES (@MaPD, @MaDV, @SO_LUONG)";
            object[] parameters = { chiTietDV.MaPD, chiTietDV.MaDV, chiTietDV.SoLuong };
            return DataProvider.Instance.ExecuteNonQuery2(query, parameters) > 0;
        }



        public ChiTietDichVu GetChiTietDichVu(int maPD, int maDV)
        {
            string query = "SELECT * FROM CHI_TIET_DV WHERE MaPD = @MaPD AND MaDV = @MaDV";
            object[] parameters = { maPD, maDV };

            DataTable data = DataProvider.Instance.ExecuteQuery2(query, parameters);
            return (data.Rows.Count > 0) ? new ChiTietDichVu(data.Rows[0]) : null;
        }




        public bool UpdateChiTietDichVu(ChiTietDichVu chiTietDV)
        {
            string query = "UPDATE CHI_TIET_DV SET SO_LUONG = @SO_LUONG WHERE MaPD = @MaPD AND MaDV = @MaDV";
            object[] parameters = { chiTietDV.SoLuong, chiTietDV.MaPD, chiTietDV.MaDV };
            return DataProvider.Instance.ExecuteNonQuery2(query, parameters) > 0;
        }





        public bool DeleteChiTietDichVu(int maPD, int maDV)
        {
            string query = "DELETE FROM CHI_TIET_DV WHERE MaPD = @MaPD AND MaDV = @MaDV";
            object[] parameters = { maPD, maDV };
            int rowsAffected = DataProvider.Instance.ExecuteNonQuery2(query, parameters);  // Kiểm tra số dòng bị ảnh hưởng
            return rowsAffected > 0; // Trả về true nếu có dòng bị xóa
        }









        //Lấy danh sách dịch vụ sử dụng
        public List<Tuple<DichVu, ChiTietDichVu>> GetDichVuByPhieuDat(int maPD)
        {
            string query = @"SELECT DV.MADV, DV.TENDV, DV.GIA_DV, DV.TRANGTHAI_DV, CTPDV.MAPD, CTPDV.SO_LUONG
                            FROM CHI_TIET_DV CTPDV
                            JOIN DICH_VU DV ON CTPDV.MADV = DV.MADV
                            WHERE CTPDV.MAPD = @maPD";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maPD });

            List<Tuple<DichVu, ChiTietDichVu>> danhSachDichVu = new List<Tuple<DichVu, ChiTietDichVu>>();
            foreach (DataRow row in data.Rows)
            {
                DichVu dichVu = new DichVu(row);
                ChiTietDichVu chiTiet = new ChiTietDichVu(
                    Convert.ToInt32(row["MAPD"]),
                    Convert.ToInt32(row["MADV"]),
                    Convert.ToInt32(row["SO_LUONG"])
                );

                danhSachDichVu.Add(new Tuple<DichVu, ChiTietDichVu>(dichVu, chiTiet));
            }

            return danhSachDichVu;
        }






    }
}
