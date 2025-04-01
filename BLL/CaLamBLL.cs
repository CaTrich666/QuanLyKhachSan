using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CaLamBLL
    {
        private static CaLamBLL instance;
        public static CaLamBLL Instance
        {
            get { if (instance == null) instance = new CaLamBLL(); return instance; }
            private set => instance = value;
        }

        private CaLamBLL() { }


        // Lấy danh sách ca làm
        public List<CaLam> GetListCaLam()
        {
            return CaLamDAL.Instance.GetListCaLam();
        }

        // Thêm ca làm
        public bool InsertCaLam(CaLam caLam)
        {
            return CaLamDAL.Instance.InsertCaLam(caLam);
        }

        // Cập nhật ca làm
        public bool UpdateCaLam(CaLam caLam)
        {
            return CaLamDAL.Instance.UpdateCaLam(caLam);
        }

        // Xóa ca làm
        public bool DeleteCaLam(int maCa)
        {
            return CaLamDAL.Instance.DeleteCaLam(maCa);
        }

        // Tìm kiếm
        public List<CaLam> SearchCLByName(string tenCa)
        {
            return CaLamDAL.Instance.SearchCLByName(tenCa);
        }


    }
}
