using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TinhLuongDAL
    {
        private static TinhLuongDAL instance;
        public static TinhLuongDAL Instance
        {
            get { if (instance == null) instance = new TinhLuongDAL(); return instance; }
            private set => instance = value;
        }

        private TinhLuongDAL() { }




        public List<TinhLuong> TinhLuong(int maNV, DateTime tuNgay, DateTime denNgay)
        {
            List<TinhLuong> danhSachLuong = new List<TinhLuong>();

            string query = "EXEC sp_TinhLuongNhanVien @MaNV, @TuNgay, @DenNgay";

            DataTable dataTable = DataProvider.Instance.ExecuteQuery2(query, new object[] { maNV, tuNgay, denNgay });

            foreach (DataRow row in dataTable.Rows)
            {
                danhSachLuong.Add(new TinhLuong(row));
            }

            return danhSachLuong;
        }









    }
}
