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
    public class PhieuDatDAL
    {
        private static PhieuDatDAL instance;
        public static PhieuDatDAL Instance
        {
            get { if (instance == null) instance = new PhieuDatDAL(); return instance; }
            private set => instance = value;
        }

        private PhieuDatDAL() { }



        //Load dữ liệu phiếu đặt
        public List<PhieuDat> GetListPhieuDat()
        {
            List<PhieuDat> list = new List<PhieuDat>();
            string query = "SELECT * FROM PHIEU_DAT ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PhieuDat phieudat = new PhieuDat(item);
                list.Add(phieudat);
            }
            return list;
        }





        // thêm phiếu đặt
        public bool InsertPhieuDat(PhieuDat phieu)
        {
            string query = "INSERT INTO PHIEU_DAT (SONGUOI, TRANGTHAI_PD, TIENCOC, NGAYDAT, NGAY_NHANPHONG, NGAY_TRAPHONG, CCCD, MANV) " +
                           "VALUES (@soNguoi, @trangThai, @tienCoc, @ngayDat, @ngayNhanPhong, @ngayTraPhong, @cccd, @maNV)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@soNguoi", SqlDbType.Int) { Value = phieu.SoNguoi },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = phieu.TrangThaiPD },
                new SqlParameter("@tienCoc", SqlDbType.Decimal) { Value = phieu.TienCoc },
                new SqlParameter("@ngayDat", SqlDbType.DateTime2) { Value = phieu.NgayDat },
                new SqlParameter("@ngayNhanPhong", SqlDbType.DateTime2) { Value = phieu.NgayNhanPhong },
                new SqlParameter("@ngayTraPhong", SqlDbType.DateTime2) { Value = phieu.NgayTraPhong },
                new SqlParameter("@cccd", SqlDbType.NVarChar) { Value = phieu.CCCD },
                new SqlParameter("@maNV", SqlDbType.Int) { Value = phieu.MaNV }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }




        // Cập nhật phiếu đặt
        public bool UpdatePhieuDat(PhieuDat phieuDat)
        {
            string query = "UPDATE PHIEU_DAT SET TRANGTHAI_PD = @trangThaiPD, SONGUOI = @soNguoi, TIENCOC = @tienCoc, NGAY_NHANPHONG = @ngayNhanPhong, NGAY_TRAPHONG = @ngayTraPhong WHERE MAPD = @maPD";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trangThaiPD", SqlDbType.NVarChar) { Value = phieuDat.TrangThaiPD },
                new SqlParameter("@soNguoi", SqlDbType.Int) { Value = phieuDat.SoNguoi },
                new SqlParameter("@tienCoc", SqlDbType.Decimal) { Value = phieuDat.TienCoc },
                new SqlParameter("@ngayNhanPhong", SqlDbType.DateTime2) { Value = phieuDat.NgayNhanPhong },
                new SqlParameter("@ngayTraPhong", SqlDbType.DateTime2) { Value = phieuDat.NgayTraPhong },
                new SqlParameter("@maPD", SqlDbType.Int) { Value = phieuDat.MaPD }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }






        // Tìm kiếm
        public List<PhieuDat> SearchPhieuDat(string maPD)
        {
            List<PhieuDat> list = new List<PhieuDat>();
            string query = "SELECT * FROM PHIEU_DAT WHERE dbo.fuConvertToUnsign1(MAPD) LIKE dbo.fuConvertToUnsign1(N'%' + @maPD + '%')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maPD });

            foreach (DataRow item in data.Rows)
            {
                PhieuDat phieudat = new PhieuDat(item);
                list.Add(phieudat);
            }

            return list;
        }










        // Lấy MAPD
        public PhieuDat GetPhieuDatByMaPD(int maPD)
        {
            string query = "SELECT * FROM PHIEU_DAT WHERE MAPD = @maPD";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maPD });

            if (data.Rows.Count > 0)
            {
                return new PhieuDat(data.Rows[0]); // Tạo đối tượng từ DataRow
            }

            return null; // Không tìm thấy phiếu đặt
        }





        // Lấy MAPD mới nhất
        public int GetLatestPhieuDatId()
        {
            string query = "SELECT TOP 1 MAPD FROM PHIEU_DAT ORDER BY MAPD DESC"; // Sử dụng ORDER BY để lấy MAPD mới nhất
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1; // Trả về -1 nếu không tìm thấy
        }





        // Phương thức tìm kiếm phiếu đặt theo mã phiếu đặt
        public DataTable SearchPhieuDatByMaPD(int maPD)
        {
            string query = @"
                            SELECT p.MAPD, p.SONGUOI, p.TIENCOC, p.NGAYDAT, p.NGAY_NHANPHONG, p.NGAY_TRAPHONG, p.CCCD, k.TENKH, k.SDT_KH, k.GIOITINH_KH, lp.TENLOAI, lp.GIA_LP, ph.TENPHONG, dv2.MADV, dv2.TENDV, dv2.GIA_DV, ctdv.SO_LUONG
                            FROM PHIEU_DAT p
                            JOIN KHACH_HANG k ON p.CCCD = k.CCCD
                            JOIN CHI_TIET_PD ctpd ON p.MAPD = ctpd.MAPD
                            JOIN PHONG ph ON ctpd.MAPHONG = ph.MAPHONG
                            JOIN LOAI_PHONG lp ON ph.MALOAI = lp.MALOAI
                            LEFT JOIN CHI_TIET_DV ctdv ON p.MAPD = ctdv.MAPD
                            LEFT JOIN DICH_VU dv2 ON ctdv.MADV = dv2.MADV
                            WHERE p.MAPD = @MAPD"
            ;
            return DataProvider.Instance.ExecuteQuery2(query, new object[] { maPD });
        }






        //lấy thông tin phiếu đặt theo mã phòng
        public PhieuDat GetPhieuDatByPhong(int maPhong)
        {
            string query = @"SELECT PD.* FROM PHIEU_DAT PD JOIN CHI_TIET_PD CTPD ON PD.MAPD = CTPD.MAPD
                            WHERE CTPD.MAPHONG = @maPhong AND PD.TRANGTHAI_PD NOT IN ('Hoàn thành')";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maPhong });

            if (data.Rows.Count > 0)
            {
                return new PhieuDat(data.Rows[0]); // Trả về phiếu đặt đầu tiên tìm thấy
            }

            return null; // Không có phiếu đặt nào
        }





    


























    }
}
