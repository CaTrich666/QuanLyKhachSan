using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThietBiBLL
    {
        private static ThietBiBLL instance;
        public static ThietBiBLL Instance
        {
            get { if (instance == null) instance = new ThietBiBLL(); return instance; }
            private set => instance = value;
        }

        private ThietBiBLL() { }





        // Lấy danh sách tài khoản
        public List<ThietBi> GetListThietBi()
        {
            return ThietBiDAL.Instance.GetListThietBi();
        }


        // Thêm thiết bị
        public bool InsertThietBi(ThietBi thietBi)
        {
            return ThietBiDAL.Instance.InsertThietBi(thietBi);
        }


        // Cập nhật thiết bị
        public bool UpdateThietBi(ThietBi thietBi)
        {
            return ThietBiDAL.Instance.UpdateThietBi(thietBi);
        }


        // Xóa thiết bị
        public bool DeleteThietBi(int maTB)
        {
            return ThietBiDAL.Instance.DeleteThietBi(maTB);
        }


        // Tìm kiếm
        public List<ThietBi> SearchTBByName(string tenTB)
        {
            return ThietBiDAL.Instance.SearchTBByName(tenTB);
        }

    }
}
