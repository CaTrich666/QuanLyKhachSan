using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBLL
    {
        private static KhachHangBLL instance;
        public static KhachHangBLL Instance
        {
            get { if (instance == null) instance = new KhachHangBLL(); return instance; }
            private set => instance = value;
        }

        private KhachHangBLL() { }


        // Lấy danh sách nhân viên
        public List<KhachHang> GetListKhachHang()
        {
            return KhachHangDAL.Instance.GetListKhachHang();
        }



        // Thêm khách hàng
        public bool InsertKhachHang(KhachHang khachHang)
        {
            return KhachHangDAL.Instance.InsertKhachHang(khachHang);
        }

        // Cập nhật khách hàng
        public bool UpdateKhachHang(string oldCCCD, KhachHang khachHang)
        {
            return KhachHangDAL.Instance.UpdateKhachHang(oldCCCD, khachHang);
        }

        // Xóa khách hàng
        public bool DeleteKhachHang(string cccd)
        {
            return KhachHangDAL.Instance.DeleteKhachHang(cccd);
        }


        // Tìm kiếm
        public List<KhachHang> SearchKHByName(string tenKH)
        {
            return KhachHangDAL.Instance.SearchKHByName(tenKH);
        }


        // Tìm kiếm khách hàng theo CCCD
        public KhachHang SearchKHByCCCD(string cccd)
        {
            return KhachHangDAL.Instance.SearchKHByCCCD(cccd);
        }

    }
}
