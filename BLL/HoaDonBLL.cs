using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL instance;
        public static HoaDonBLL Instance
        {
            get { if (instance == null) instance = new HoaDonBLL(); return instance; }
            private set => instance = value;
        }

        private HoaDonBLL() { }




        // Lấy danh sách hóa đơn
        public List<HoaDon> GetListHoaDon()
        {
            return HoaDonDAL.Instance.GetListHoaDon();
        }



        // Tìm kiếm
        public List<HoaDon> SearchHoaDonByDate(DateTime fromDate, DateTime toDate)
        {
            return HoaDonDAL.Instance.SearchHoaDonByDate(fromDate, toDate);
        }






        //thêm hóa đơn
        public bool InsertHoaDon(HoaDon hoadon)
        {
            return HoaDonDAL.Instance.InsertHoaDon(hoadon);
        }


        //Tổng tiền phòng
        public decimal TinhTongTienPhong(int maPD)
        {
            return HoaDonDAL.Instance.GetTongTienPhong(maPD);
        }


        //Tổng tiền dịch vụ
        public decimal TinhTongTienDichVu(int maPD)
        {
            return HoaDonDAL.Instance.GetTongTienDichVu(maPD);
        }






        //Lấy danh sách hóa đơn theo khoảng thời gian
        public List<HoaDon> LayHoaDonTheoKhoang(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return HoaDonDAL.Instance.GetHoaDonTrongKhoang(ngayBatDau, ngayKetThuc);
        }






    }
}
