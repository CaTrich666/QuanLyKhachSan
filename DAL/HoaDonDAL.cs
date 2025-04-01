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
    public class HoaDonDAL
    {
        private static HoaDonDAL instance;
        public static HoaDonDAL Instance
        {
            get { if (instance == null) instance = new HoaDonDAL(); return instance; }
            private set => instance = value;
        }

        private HoaDonDAL() { }



        //Load dữ liệu hóa đơn
        public List<HoaDon> GetListHoaDon()
        {
            List<HoaDon> list = new List<HoaDon>();
            string query = @"SELECT hd.*, pd.TIENCOC FROM HOA_DON hd JOIN PHIEU_DAT pd ON hd.MAPD = pd.MAPD";  // Lấy thêm TIENCOC từ PHIEU_DAT

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HoaDon hoadon = new HoaDon(item);
                hoadon.TienCoc = Convert.ToDecimal(item["TIENCOC"]); // Gán tiền cọc vào đối tượng HoaDon
                list.Add(hoadon);
            }
            return list;
        }




        // Thêm hóa đơn
        public bool InsertHoaDon(HoaDon hoaDon)
        {
            string query = "INSERT INTO HOA_DON (NGAYLAP, TONGTIENPHONG, TONGTIENDV, GIAM_GIA, PT_THANHTOAN, TRANGTHAI_HD, TONGTIENTHANHTOAN, MAPD, MANV) " +
                           "VALUES (@ngayLap, @tongTienPhong, @tongTienDV, @giamGia, @ptThanhToan, @trangThaiHD, @tongTienThanhToan, @maPD, @maNV)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ngayLap", SqlDbType.DateTime2) { Value = hoaDon.NgayLap },
                new SqlParameter("@tongTienPhong", SqlDbType.Decimal) { Value = hoaDon.TongTienPhong },
                new SqlParameter("@tongTienDV", SqlDbType.Decimal) { Value = hoaDon.TongTienDV },
                new SqlParameter("@giamGia", SqlDbType.Int) { Value = hoaDon.GiamGia },
                new SqlParameter("@ptThanhToan", SqlDbType.NVarChar) { Value = hoaDon.PtThanhToan },
                new SqlParameter("@trangThaiHD", SqlDbType.NVarChar) { Value = hoaDon.TrangThaiHD },
                new SqlParameter("@tongTienThanhToan", SqlDbType.Decimal) { Value = hoaDon.TongTienThanhToan },
                new SqlParameter("@maPD", SqlDbType.Int) { Value = hoaDon.MaPD },
                new SqlParameter("@maNV", SqlDbType.Int) { Value = hoaDon.MaNV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }





        // Tìm kiếm
        public List<HoaDon> SearchHoaDonByDate(DateTime fromDate, DateTime toDate)
        {
            List<HoaDon> list = new List<HoaDon>();
            string query = "SELECT * FROM HOA_DON WHERE NGAYLAP BETWEEN @FromDate AND @ToDate";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { fromDate, toDate });

            foreach (DataRow item in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(item);
                list.Add(hoaDon);
            }

            return list;
        }





        // Tổng tiền phòng
        public decimal GetTongTienPhong(int maPD)
        {
            string query = @"SELECT SUM(LP.GIA_LP) FROM CHI_TIET_PD CTPD JOIN PHONG P ON CTPD.MAPHONG = P.MAPHONG JOIN LOAI_PHONG LP ON P.MALOAI = LP.MALOAI WHERE CTPD.MAPD = @maPD";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maPD });
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        // Tổng tiền dịch vụ
        public decimal GetTongTienDichVu(int maPD)
        {
            string query = @"SELECT SUM(CTDV.SO_LUONG * DV.GIA_DV) FROM CHI_TIET_DV CTDV JOIN DICH_VU DV ON CTDV.MADV = DV.MADV WHERE CTDV.MAPD = @maPD";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maPD });
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }


        public int GetGiamGiaByPhieuDat(int maPD)
        {
            string query = "SELECT GIAM_GIA FROM HOA_DON WHERE MAPD = @MaPD";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maPD });

            if (result != null && int.TryParse(result.ToString(), out int giamGia))
                return giamGia;

            return 0; // Mặc định nếu không có giảm giá
        }





        //Lấy danh sách hóa đơn theo khoảng thời gian
        public List<HoaDon> GetHoaDonTrongKhoang(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            List<HoaDon> danhSach = new List<HoaDon>();
            string query = @"SELECT * FROM HOA_DON WHERE NGAYLAP BETWEEN @NgayBatDau AND @NgayKetThuc";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { ngayBatDau, ngayKetThuc });

            foreach (DataRow row in data.Rows)
            {
                HoaDon hd = new HoaDon(row);
                danhSach.Add(hd);
            }

            return danhSach;
        }




    }
}
