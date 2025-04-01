using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DichVu
    {
        public DichVu(int maDV, string tenDV, decimal giaDV, bool trangThaiDV)
        {
            this.MaDV = maDV;
            this.TenDV = tenDV;
            this.GiaDV = giaDV;
            this.TrangThaiDV = trangThaiDV;
        }

        public DichVu(DataRow row)
        {
            this.MaDV = Convert.ToInt32(row["MADV"]);
            this.TenDV = row["TENDV"].ToString();
            this.GiaDV = Convert.ToDecimal(row["GIA_DV"]);
            this.TrangThaiDV = Convert.ToBoolean(row["TRANGTHAI_DV"]);
        }

        private int maDV;
        public int MaDV { get => maDV; set => maDV = value; }

        private string tenDV;
        public string TenDV { get => tenDV; set => tenDV = value; }

        private decimal giaDV;
        public decimal GiaDV { get => giaDV; set => giaDV = value; }

        private bool trangThaiDV;
        public bool TrangThaiDV { get => trangThaiDV; set => trangThaiDV = value; }
    }
}
