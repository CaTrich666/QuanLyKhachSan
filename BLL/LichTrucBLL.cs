using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LichTrucBLL
    {
        private static LichTrucBLL instance;
        public static LichTrucBLL Instance
        {
            get { if (instance == null) instance = new LichTrucBLL(); return instance; }
            private set => instance = value;
        }

        private LichTrucBLL() { }


        // Lấy danh sách lịch trực
        public List<LichTruc> GetListLichTruc()
        {
            return LichTrucDAL.Instance.GetListLichTruc();
        }

        // Thêm lịch trực
        public bool InsertLichTruc(LichTruc lichTruc)
        {
            return LichTrucDAL.Instance.InsertLichTruc(lichTruc);
        }

        // Cập nhật lịch trực
        public bool UpdateLichTruc(LichTruc lichTruc)
        {
            return LichTrucDAL.Instance.UpdateLichTruc(lichTruc);
        }

        // Xóa lịch trực
        public bool DeleteLichTruc(int maLT)
        {
            return LichTrucDAL.Instance.DeleteLichTruc(maLT);
        }


        // Tìm kiếm
        public List<LichTruc> SearchLT(string maLT)
        {
            return LichTrucDAL.Instance.SearchLT(maLT);
        }


    }
}
