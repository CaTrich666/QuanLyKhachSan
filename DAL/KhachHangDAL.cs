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
    public class KhachHangDAL
    {
        private static KhachHangDAL instance;
        public static KhachHangDAL Instance
        {
            get { if (instance == null) instance = new KhachHangDAL(); return instance; }
            private set => instance = value;
        }

        private KhachHangDAL() { }



        //Load dữ liệu khách hàng
        public List<KhachHang> GetListKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = "SELECT * FROM KHACH_HANG ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KhachHang khachhang = new KhachHang(item);
                list.Add(khachhang);
            }
            return list;
        }



        // Thêm khách hàng
        public bool InsertKhachHang(KhachHang khachHang)
        {
            string query = "INSERT INTO KHACH_HANG (CCCD, TENKH, SDT_KH, GIOITINH_KH, DIACHI) VALUES (@cccd, @tenKH, @sdtKH, @gioiTinhKH, @diaChi)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cccd", SqlDbType.NVarChar) { Value = (object)khachHang.CCCD ?? DBNull.Value },
                new SqlParameter("@tenKH", SqlDbType.NVarChar) { Value = (object)khachHang.TenKH ?? DBNull.Value },
                new SqlParameter("@sdtKH", SqlDbType.NVarChar) { Value = (object)khachHang.SDT_KH ?? DBNull.Value },
                new SqlParameter("@gioiTinhKH", SqlDbType.Bit) { Value = khachHang.GioiTinh_KH },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = (object)khachHang.DiaChi ?? DBNull.Value }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Cập nhật khách hàng
        public bool UpdateKhachHang(string oldCCCD, KhachHang khachHang)
        {
            string query = "UPDATE KHACH_HANG SET CCCD = @newCCCD, TENKH = @tenKH, SDT_KH = @sdtKH, GIOITINH_KH = @gioiTinhKH, DIACHI = @diaChi WHERE CCCD = @oldCCCD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@newCCCD", SqlDbType.NVarChar) { Value = khachHang.CCCD },
                new SqlParameter("@tenKH", SqlDbType.NVarChar) { Value = khachHang.TenKH },
                new SqlParameter("@sdtKH", SqlDbType.NVarChar) { Value = khachHang.SDT_KH },
                new SqlParameter("@gioiTinhKH", SqlDbType.Bit) { Value = khachHang.GioiTinh_KH },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = khachHang.DiaChi },
                new SqlParameter("@oldCCCD", SqlDbType.NVarChar) { Value = oldCCCD }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Xóa khách hàng
        public bool DeleteKhachHang(string cccd)
        {
            string query = "DELETE FROM KHACH_HANG WHERE CCCD = @cccd";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cccd", SqlDbType.NVarChar) { Value = cccd }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }


        // Tìm kiếm
        public List<KhachHang> SearchKHByName(string tenKH)
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = "SELECT * FROM KHACH_HANG WHERE dbo.fuConvertToUnsign1(TENKH) LIKE dbo.fuConvertToUnsign1(N'%' + @tenKH + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenKH });

            foreach (DataRow item in data.Rows)
            {
                KhachHang khachhang = new KhachHang(item);
                list.Add(khachhang);
            }

            return list;
        }




        // Tìm kiếm bằng cccd trong đặt phòng
        public KhachHang SearchKHByCCCD(string cccd)
        {
            string query = "SELECT * FROM KHACH_HANG WHERE CCCD = @cccd";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { cccd });

            if (data.Rows.Count > 0)
            {
                return new KhachHang(data.Rows[0]); // Trả về một khách hàng duy nhất
            }

            return null; // Không tìm thấy khách hàng
        }












        //lấy thông tin khách hàng theo phiếu đặt
        public KhachHang GetKhachHangByPhieuDat(int maPD)
        {
            string query = @"SELECT KH.* FROM KHACH_HANG KH JOIN PHIEU_DAT PD ON KH.CCCD = PD.CCCD WHERE PD.MAPD = @maPD";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maPD });

            if (data.Rows.Count > 0)
            {
                return new KhachHang(data.Rows[0]); // Trả về khách hàng đầu tiên tìm thấy
            }

            return null;
        }






    }
}
