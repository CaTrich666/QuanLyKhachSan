using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        public TaiKhoan(string userName, string passWord, bool role, int maNV)
        {
            this.UserName = userName;
            this.PassWord = passWord;
            this.Role = role;
            this.MaNV = maNV;
        }


        public TaiKhoan(DataRow row)
        {
            this.UserName = row["TENTK"].ToString();
            this.PassWord = row["MATKHAU"].ToString();
            this.Role = Convert.ToBoolean(row["QUYEN"]);
            this.MaNV = Convert.ToInt32(row["MANV"]);
        }


        private string userName;
        public string UserName { get => userName; set => userName = value; }

        private string passWord;
        public string PassWord { get => passWord; set => passWord = value; }

        private bool role;
        public bool Role { get => role; set => role = value; }

        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }
    }
}
