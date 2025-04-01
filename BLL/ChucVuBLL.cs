using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChucVuBLL
    {
        private static ChucVuBLL instance;
        public static ChucVuBLL Instance
        {
            get { if (instance == null) instance = new ChucVuBLL(); return instance; }
            private set => instance = value;
        }

        private ChucVuBLL() { }


        // Lấy danh sách chức vụ
        public List<ChucVu> GetListChucVu()
        {
            return ChucVuDAL.Instance.GetListChucVu();
        }

        // Thêm chức vụ
        public bool InsertChucVu(ChucVu chucVu)
        {
            return ChucVuDAL.Instance.InsertChucVu(chucVu);
        }

        // Cập nhật chức vụ
        public bool UpdateChucVu(ChucVu chucVu)
        {
            return ChucVuDAL.Instance.UpdateChucVu(chucVu);
        }

        // Xóa chức vụ
        public bool DeleteChucVu(int maCV)
        {
            return ChucVuDAL.Instance.DeleteChucVu(maCV);
        }

        // Tìm kiếm
        public List<ChucVu> SearchCVByName(string tenCV)
        {
            return ChucVuDAL.Instance.SearchCVByName(tenCV);
        }

    }
}
