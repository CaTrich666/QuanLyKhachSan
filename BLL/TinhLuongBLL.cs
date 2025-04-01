using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TinhLuongBLL
    {
        private static TinhLuongBLL instance;
        public static TinhLuongBLL Instance
        {
            get { if (instance == null) instance = new TinhLuongBLL(); return instance; }
            private set => instance = value;
        }

        private TinhLuongBLL() { }


        public List<TinhLuong> GetTinhLuong(int maNV, DateTime tuNgay, DateTime denNgay)
        {
            return TinhLuongDAL.Instance.TinhLuong(maNV, tuNgay, denNgay);
        }



    }
}
