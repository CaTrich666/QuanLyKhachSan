using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiPhongBLL
    {
        private static LoaiPhongBLL instance;
        public static LoaiPhongBLL Instance
        {
            get { if (instance == null) instance = new LoaiPhongBLL(); return instance; }
            private set => instance = value;
        }

        private LoaiPhongBLL() { }


        // Lấy danh sách loại phòng
        public List<LoaiPhong> GetListLoaiPhong()
        {
            return LoaiPhongDAL.Instance.GetListLoaiPhong();
        }



        // Thêm loại phòng
        public bool InsertLoaiPhong(LoaiPhong loaiPhong)
        {
            return LoaiPhongDAL.Instance.InsertLoaiPhong(loaiPhong);
        }

        // Cập nhật loại phòng
        public bool UpdateLoaiPhong(LoaiPhong loaiPhong)
        {
            return LoaiPhongDAL.Instance.UpdateLoaiPhong(loaiPhong);
        }

        // Xóa loại phòng
        public bool DeleteLoaiPhong(int maLoai)
        {
            return LoaiPhongDAL.Instance.DeleteLoaiPhong(maLoai);
        }

        // Tìm kiếm
        public List<LoaiPhong> SearchLPByName(string tenLoai)
        {
            return LoaiPhongDAL.Instance.SearchLPByName(tenLoai);
        }


        // Lấy thông tin loại phòng dựa vào MaLoai
        public LoaiPhong GetLoaiPhongById(int maLoai)
        {
            return LoaiPhongDAL.Instance.GetLoaiPhongById(maLoai);
        }


    }
}
