using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuDatBLL
    {
        private static PhieuDatBLL instance;
        public static PhieuDatBLL Instance
        {
            get { if (instance == null) instance = new PhieuDatBLL(); return instance; }
            private set => instance = value;
        }

        private PhieuDatBLL() { }





        // Lấy danh sách phiếu đặt
        public List<PhieuDat> GetListPhieuDat()
        {
            return PhieuDatDAL.Instance.GetListPhieuDat();
        }


        //thêm phiếu đặt
        public bool InsertPhieuDat(PhieuDat phieu)
        {
            return PhieuDatDAL.Instance.InsertPhieuDat(phieu);
        }

        // Cập nhật phiếu đặt
        public bool UpdatePhieuDat(PhieuDat phieuDat)
        {
            return PhieuDatDAL.Instance.UpdatePhieuDat(phieuDat);
        }



        // Tìm kiếm
        public List<PhieuDat> SearchPhieuDat(string maPD)
        {
            return PhieuDatDAL.Instance.SearchPhieuDat(maPD);
        }





        // Kiểm tra trạng thái hợp lệ trước khi cập nhật
        public bool IsTrangThaiHopLe(string trangThaiHienTai, string trangThaiMoi)
        {
            Dictionary<string, List<string>> trangThaiHopLe = new Dictionary<string, List<string>>
            {
                { "Đang chờ", new List<string> { "Đang chờ", "Đã xác nhận", "Đã hủy" } },
                { "Đã xác nhận", new List<string> { "Đã xác nhận", "Đã nhận phòng", "Đã hủy" } },
                { "Đã nhận phòng", new List<string> { "Đã nhận phòng", "Hoàn thành" } },
                { "Hoàn thành", new List<string>() }, // Không thể chuyển tiếp
                { "Đã hủy", new List<string>() }      // Không thể chuyển tiếp
            };

            return trangThaiHopLe.ContainsKey(trangThaiHienTai) && trangThaiHopLe[trangThaiHienTai].Contains(trangThaiMoi);
        }





        // Thêm phương thức lấy MAPD mới nhất
        public int GetLatestPhieuDatId()
        {
            return PhieuDatDAL.Instance.GetLatestPhieuDatId(); // Đảm bảo phương thức này tồn tại trong DAL
        }


        // Lấy MAPD
        public PhieuDat GetPhieuDatByMaPD(int maPD)
        {
            return PhieuDatDAL.Instance.GetPhieuDatByMaPD(maPD);
        }




        // Phương thức tìm kiếm phiếu đặt theo mã phiếu đặt
        public PhieuDatWithAllDetails SearchPhieuDatByMaPD(int maPD)
        {
            // Gọi DAL để lấy dữ liệu
            DataTable data = PhieuDatDAL.Instance.SearchPhieuDatByMaPD(maPD);

            // Kiểm tra nếu không có dữ liệu trả về
            if (data == null || data.Rows.Count == 0) return null;

            // Lấy thông tin phiếu đặt từ dòng đầu tiên
            var firstRow = data.Rows[0];

            var phieuDat = new PhieuDatWithAllDetails()
            {
                MaPD = firstRow["MAPD"] != DBNull.Value ? Convert.ToInt32(firstRow["MAPD"]) : 0,
                SoNguoi = firstRow["SONGUOI"] != DBNull.Value ? Convert.ToInt32(firstRow["SONGUOI"]) : 0,
                TienCoc = firstRow["TIENCOC"] != DBNull.Value ? Convert.ToDecimal(firstRow["TIENCOC"]) : 0,
                NgayDat = firstRow["NGAYDAT"] != DBNull.Value ? Convert.ToDateTime(firstRow["NGAYDAT"]) : DateTime.MinValue,
                NgayNhanPhong = firstRow["NGAY_NHANPHONG"] != DBNull.Value ? Convert.ToDateTime(firstRow["NGAY_NHANPHONG"]) : DateTime.MinValue,
                NgayTraPhong = firstRow["NGAY_TRAPHONG"] != DBNull.Value ? Convert.ToDateTime(firstRow["NGAY_TRAPHONG"]) : DateTime.MinValue,
                CCCD = firstRow["CCCD"]?.ToString() ?? "",
                TenKH = firstRow["TENKH"]?.ToString() ?? "",
                SDT_KH = firstRow["SDT_KH"]?.ToString() ?? "",
                GioiTinhKH = firstRow["GIOITINH_KH"] != DBNull.Value && Convert.ToBoolean(firstRow["GIOITINH_KH"]),
                TenLoai = firstRow["TENLOAI"]?.ToString() ?? "",
                GiaLP = firstRow["GIA_LP"] != DBNull.Value ? Convert.ToDecimal(firstRow["GIA_LP"]) : 0,
                TenPhong = firstRow["TENPHONG"]?.ToString() ?? "",
                MaDV = new List<int>(),
                TenDV = new List<string>(),
                GiaDV = new List<decimal>(),
                SoLuong = new List<int>()
            };

            // Duyệt qua tất cả dòng để lấy danh sách dịch vụ
            foreach (DataRow row in data.Rows)
            {
                if (row["MADV"] != DBNull.Value) // Kiểm tra nếu có dịch vụ
                {
                    phieuDat.MaDV.Add(Convert.ToInt32(row["MADV"]));
                    phieuDat.TenDV.Add(row["TENDV"].ToString());
                    phieuDat.GiaDV.Add(Convert.ToDecimal(row["GIA_DV"]));
                    phieuDat.SoLuong.Add(Convert.ToInt32(row["SO_LUONG"]));
                }
            }

            return phieuDat;
        }



        //lấy thông tin phiếu đặt theo mã phòng
        public PhieuDat GetPhieuDatByPhong(int maPhong)
        {
            return PhieuDatDAL.Instance.GetPhieuDatByPhong(maPhong);
        }


        // Lấy khách hàng theo mã phiếu đặt
        public KhachHang GetKhachHangByPhieuDat(int maPD)
        {
            return KhachHangDAL.Instance.GetKhachHangByPhieuDat(maPD);
        }



        // Lấy thông tin phòng theo mã phiếu đặt
        public Phong GetPhongByPhieuDat(int maPD)
        {
            return PhongDAL.Instance.GetPhongByPhieuDat(maPD);
        }




        // Lấy danh sách dịch vụ theo mã phiếu đặt
        public List<Tuple<DichVu, ChiTietDichVu>> GetDichVuByPhieuDat(int maPD)
        {
            return ChiTietDichVuDAL.Instance.GetDichVuByPhieuDat(maPD);
        }



        // Tạo nội dung hóa đơn từ phiếu đặt
        public string GenerateInvoiceContent(int maPhong, int giamGia)
        {
            // Lấy thông tin phiếu đặt theo mã phòng
            PhieuDat phieuDat = GetPhieuDatByPhong(maPhong);
            if (phieuDat == null) return "Không tìm thấy phiếu đặt!";

            // Lấy thông tin khách hàng
            KhachHang khachHang = GetKhachHangByPhieuDat(phieuDat.MaPD);
            if (khachHang == null) return "Không tìm thấy thông tin khách hàng!";

            // Lấy thông tin phòng
            Phong phong = GetPhongByPhieuDat(phieuDat.MaPD);
            if (phong == null) return "Không tìm thấy thông tin phòng!";

            // Lấy thông tin loại phòng
            LoaiPhong loaiPhong = LoaiPhongBLL.Instance.GetLoaiPhongById(phong.MaLoai);
            string tenLoai = loaiPhong?.TenLoai ?? "Không xác định";
            decimal giaLoaiPhong = loaiPhong?.GiaLP ?? 0;

            // Tính số ngày thuê
            int soNgayThue = Math.Max((phieuDat.NgayTraPhong - phieuDat.NgayNhanPhong).Days, 1);
            decimal tongTienPhong = giaLoaiPhong * soNgayThue;

            // Lấy danh sách dịch vụ theo mã phiếu đặt
            var danhSachDichVu = GetDichVuByPhieuDat(phieuDat.MaPD); // Trả về List<Tuple<DichVu, ChiTietDichVu>>

            // Xây dựng danh sách dịch vụ
            StringBuilder danhSachDichVuText = new StringBuilder();
            decimal tongTienDichVu = 0;

            if (danhSachDichVu.Count > 0)
            {
                danhSachDichVuText.AppendLine("Dịch vụ đã sử dụng:");
                foreach (var dv in danhSachDichVu)
                {
                    string tenDichVu = dv.Item1.TenDV;
                    decimal giaDichVu = dv.Item1.GiaDV;
                    int soLuong = dv.Item2.SoLuong;
                    decimal thanhTienDV = giaDichVu * soLuong;

                    danhSachDichVuText.AppendLine($"- {tenDichVu}: {soLuong} x {giaDichVu:N0} VNĐ = {thanhTienDV:N0} VNĐ");
                    tongTienDichVu += thanhTienDV;
                }
            }
            else
            {
                danhSachDichVuText.AppendLine("Không sử dụng dịch vụ nào.");
            }

            // Tính tổng tiền trước giảm giá (TRỪ CỌC TRƯỚC)
            decimal tongTienSauTruCoc = (tongTienPhong + tongTienDichVu) - phieuDat.TienCoc;


            // Tính tiền giảm giá
            decimal tienGiam = tongTienSauTruCoc * giamGia / 100;

            // Tính tổng tiền thanh toán sau giảm giá
            decimal tongThanhToan = tongTienSauTruCoc - tienGiam;


            // Xây dựng nội dung hóa đơn
            return $@"
HÓA ĐƠN THANH TOÁN KHÁCH SẠN
--------------------------------------
Mã Phiếu Đặt: {phieuDat.MaPD}
Khách Hàng  : {khachHang.TenKH} ({(khachHang.GioiTinh_KH ? "Nam" : "Nữ")})
SĐT         : {khachHang.SDT_KH}
CCCD        : {khachHang.CCCD}
Ngày Đặt    : {phieuDat.NgayDat:dd/MM/yyyy HH:mm}
Ngày Nhận   : {phieuDat.NgayNhanPhong:dd/MM/yyyy HH:mm}
Ngày Trả    : {phieuDat.NgayTraPhong:dd/MM/yyyy HH:mm}

Thông tin phòng:
- Phòng: {phong.TenPhong}, Loại: {tenLoai}, Giá: {giaLoaiPhong:N0} VNĐ/ngày
Số ngày thuê: {soNgayThue} ngày

{danhSachDichVuText}

{"Tổng tiền phòng:",-25} {tongTienPhong:N0} VNĐ
{"Tổng tiền dịch vụ:",-25} {tongTienDichVu:N0} VNĐ
{"Tiền cọc:",-25} {phieuDat.TienCoc:N0} VNĐ
{"Tổng tiền sau trừ cọc:",-25} {tongTienSauTruCoc:N0} VNĐ
{"Giảm giá (" + giamGia + "%):",-25} {tienGiam:N0} VNĐ
{"Thành tiền:",-25} {tongThanhToan:N0} VNĐ

--------------------------------------
Cảm ơn quý khách đã sử dụng dịch vụ!";
        }























    }
}
