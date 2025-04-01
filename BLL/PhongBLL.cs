using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhongBLL
    {
        private static PhongBLL instance;
        public static PhongBLL Instance
        {
            get { if (instance == null) instance = new PhongBLL(); return instance; }
            private set => instance = value;
        }

        private PhongBLL() { }



        // Lấy danh sách phòng
        public List<Phong> GetListPhong()
        {
            return PhongDAL.Instance.GetListPhong();
        }



        // Thêm phòng
        public bool InsertPhong(Phong phong)
        {
            return PhongDAL.Instance.InsertPhong(phong);
        }

        // Cập nhật phòng
        public bool UpdatePhong(Phong phong)
        {
            return PhongDAL.Instance.UpdatePhong(phong);
        }

        // Cập nhật trạng thái phòng hợp lệ
        public bool IsTrangThaiPhongHopLe(string trangThaiHienTai, string trangThaiMoi)
        {
            Dictionary<string, List<string>> trangThaiHopLe = new Dictionary<string, List<string>>
            {
                { "Trống", new List<string> { "Đã đặt", "Trống" } },
                { "Đã đặt", new List<string> { "Đang sử dụng", "Đã đặt" } },
                { "Đang sử dụng", new List<string> { "Trống", "Đang sử dụng" } } // Chỉ có thể quay về "Trống" khi kết thúc
            };

            return trangThaiHopLe.ContainsKey(trangThaiHienTai) && trangThaiHopLe[trangThaiHienTai].Contains(trangThaiMoi);
        }






        // Xóa phòng
        public bool DeletePhong(int maPhong)
        {
            return PhongDAL.Instance.DeletePhong(maPhong);
        }

        // Tìm kiếm
        public List<Phong> SearchPhongByName(string tenPhong)
        {
            return PhongDAL.Instance.SearchPhongByName(tenPhong);
        }



        //Lấy danh sách phòng trống
        public List<Phong> GetPhongTrong(int? maLoai = null)
        {
            return PhongDAL.Instance.GetPhongTrong(maLoai);
        }

        //Lấy thông tin loại phòng theo mã loại
        public LoaiPhong GetLoaiPhong(int maLoai)
        {
            return LoaiPhongDAL.Instance.GetLoaiPhongById(maLoai);
        }







    }
}
