using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DichVuBLL
    {
        private static DichVuBLL instance;
        public static DichVuBLL Instance
        {
            get { if (instance == null) instance = new DichVuBLL(); return instance; }
            private set => instance = value;
        }

        private DichVuBLL() { }



        // Lấy danh sách dịch vụ
        public List<DichVu> GetListDichVu()
        {
            return DichVuDAL.Instance.GetListDichVu();
        }


        // Thêm dịch vụ
        public bool InsertDichVu(DichVu dichVu)
        {
            return DichVuDAL.Instance.InsertDichVu(dichVu);
        }

        // Cập nhật dịch vụ
        public bool UpdateDichVu(DichVu dichVu)
        {
            return DichVuDAL.Instance.UpdateDichVu(dichVu);
        }

        // Xóa dịch vụ
        public bool DeleteDichVu(int maDV)
        {
            return DichVuDAL.Instance.DeleteDichVu(maDV);
        }


        // Tìm kiếm
        public List<DichVu> SearchDVByName(string tenDV)
        {
            return DichVuDAL.Instance.SearchDVByName(tenDV);
        }

        // Lấy danh sách dịch vụ từ DAL
        public List<DichVu> GetAllDichVu()
        {
            return DichVuDAL.Instance.GetAllDichVu();
        }



    }
}
