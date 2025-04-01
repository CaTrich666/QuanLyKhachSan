using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietDichVuBLL
    {
        private static ChiTietDichVuBLL instance;
        public static ChiTietDichVuBLL Instance
        {
            get { if (instance == null) instance = new ChiTietDichVuBLL(); return instance; }
            private set => instance = value;
        }

        private ChiTietDichVuBLL() { }




        // Thêm dịch vụ
        public bool InsertChiTietDichVu(ChiTietDichVu chiTietDV)
        {
            return ChiTietDichVuDAL.Instance.InsertChiTietDichVu(chiTietDV);
        }

        // Lấy thông tin dịch vụ của phiếu đặt
        public ChiTietDichVu GetChiTietDichVu(int maPD, int maDV)
        {
            return ChiTietDichVuDAL.Instance.GetChiTietDichVu(maPD, maDV);
        }

        // Cập nhật số lượng dịch vụ
        public bool UpdateChiTietDichVu(ChiTietDichVu chiTietDV)
        {
            return ChiTietDichVuDAL.Instance.UpdateChiTietDichVu(chiTietDV);
        }

        // Xóa dịch vụ
        public bool DeleteChiTietDichVu(int maPD, int maDV)
        {
            return ChiTietDichVuDAL.Instance.DeleteChiTietDichVu(maPD, maDV);
        }



    }
}
