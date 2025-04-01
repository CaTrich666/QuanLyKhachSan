using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.ThongKeDAL;

namespace BLL
{
    public class ThongKeBLL
    {
        private static ThongKeBLL instance;
        public static ThongKeBLL Instance
        {
            get { if (instance == null) instance = new ThongKeBLL(); return instance; }
            private set => instance = value;
        }

        private ThongKeBLL() { }



        public List<ThongKeDichVu> ThongKeDichVu(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return ThongKeDAL.Instance.ThongKeDichVu(ngayBatDau, ngayKetThuc);
        }

    }
}
