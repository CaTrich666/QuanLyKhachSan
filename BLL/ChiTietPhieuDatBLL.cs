using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPhieuDatBLL
    {
        private static ChiTietPhieuDatBLL instance;
        public static ChiTietPhieuDatBLL Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuDatBLL(); return instance; }
            private set => instance = value;
        }

        private ChiTietPhieuDatBLL() { }




        // Lấy danh phiếu đạt
        public List<ChiTietPhieuDat> GetListChiTietPhieuDat()
        {
            return ChiTietPhieuDatDAL.Instance.GetListChiTietPhieuDat();
        }




        //thêm chi tiết phiếu đặt
        public bool InsertChiTietPhieuDat(ChiTietPhieuDat chiTiet)
        {
            return ChiTietPhieuDatDAL.Instance.InsertChiTietPhieuDat(chiTiet);
        }




    }
}
