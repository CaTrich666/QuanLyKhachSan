using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CurrentUser
    {
        private static CurrentUser instance;
        public static CurrentUser Instance
        {
            get { if (instance == null) instance = new CurrentUser(); return instance; }
            private set => instance = value;
        }

        private CurrentUser() { }

        public string TenTaiKhoan { get; private set; } = string.Empty;
        public bool QuyenTaiKhoan { get; private set; } = false; //true: Quản lý, false: Nhân viên
        public int MaNhanVien { get; private set; } = 0;

        public void SetUser(string tenTaiKhoan, bool quyenTaiKhoan, int maNhanVien)
        {
            TenTaiKhoan = tenTaiKhoan;
            QuyenTaiKhoan = quyenTaiKhoan;
            MaNhanVien = maNhanVien;
        }

        public void Logout()
        {
            TenTaiKhoan = string.Empty;
            QuyenTaiKhoan = false;
            MaNhanVien = 0;
        }
    }
}
