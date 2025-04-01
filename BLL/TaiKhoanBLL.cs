using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class TaiKhoanBLL
    {
        private static TaiKhoanBLL instance;
        public static TaiKhoanBLL Instance
        {
            get { if (instance == null) instance = new TaiKhoanBLL(); return instance; }
            private set => instance = value;
        }

        private TaiKhoanBLL() { }



        // Đăng nhập
        public bool DangNhap(string tenTK, string matKhau)
        {
            TaiKhoan taiKhoan = TaiKhoanDAL.Instance.GetTaiKhoan(tenTK, matKhau);
            if (taiKhoan != null)
            {
                // Lưu thông tin đăng nhập
                CurrentUser.Instance.SetUser(taiKhoan.UserName, taiKhoan.Role, taiKhoan.MaNV);
                return true;
            }
            return false;
        }


        // Lấy danh sách tài khoản
        public List<TaiKhoan> GetListTaiKhoan()
        {
            return TaiKhoanDAL.Instance.GetListTaiKhoan();
        }


        // Thêm tài khoản
        public bool InsertAccount(TaiKhoan account)
        {
            return TaiKhoanDAL.Instance.InsertAccount(account);
        }

        // Xóa tài khoản
        public bool DeleteAccount(string userName)
        {
            return TaiKhoanDAL.Instance.DeleteAccount(userName);
        }

        // Cập nhật tài khoản
        public bool UpdateAccount(string oldUserName, TaiKhoan account)
        {
            return TaiKhoanDAL.Instance.UpdateAccount(oldUserName, account);
        }

        // Tìm kiếm
        public List<TaiKhoan> SearchTKByName(string userName)
        {
            return TaiKhoanDAL.Instance.SearchTKByName(userName);
        }

        // Lấy thông tin tài khoản
        public TaiKhoan GetTaiKhoanByUserName(string tenTaiKhoan)
        {
            return TaiKhoanDAL.Instance.GetTaiKhoanByUserName(tenTaiKhoan);
        }

        // Cập nhật mật khẩu
        public bool UpdateTaiKhoan(string tenTaiKhoanCu, string tenTaiKhoanMoi, string matKhauMoi)
        {
            return TaiKhoanDAL.Instance.UpdateTaiKhoan(tenTaiKhoanCu, tenTaiKhoanMoi, matKhauMoi);
        }





    }
}
