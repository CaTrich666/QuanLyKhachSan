using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        private static NhanVienBLL instance;
        public static NhanVienBLL Instance
        {
            get { if (instance == null) instance = new NhanVienBLL(); return instance; }
            private set => instance = value;
        }

        private NhanVienBLL() { }

        // Lấy danh sách nhân viên
        public List<NhanVien> GetListNhanVien()
        {
            return NhanVienDAL.Instance.GetListNhanVien();
        }


        // Thêm nhân viên
        public bool InsertNhanVien(NhanVien nhanVien)
        {
            return NhanVienDAL.Instance.InsertNhanVien(nhanVien);
        }

        // Cập nhật nhân viên
        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            return NhanVienDAL.Instance.UpdateNhanVien(nhanVien);
        }

        // Xóa nhân viên
        public bool DeleteNhanVien(int maNV)
        {
            return NhanVienDAL.Instance.DeleteNhanVien(maNV);
        }



        // Tìm kiếm
        public List<NhanVien> SearchNVByName(string tenNV)
        {
            return NhanVienDAL.Instance.SearchNVByName(tenNV);
        }



        //lấy thông tin nhân viên theo mã nhân viên
        public NhanVien GetNhanVienByMaNV(int maNV)
        {
            return NhanVienDAL.Instance.GetNhanVienByMaNV(maNV);
        }



    }
}
