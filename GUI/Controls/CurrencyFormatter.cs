using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controls
{
    public static class CurrencyFormatter
    {
        // Phương thức để định dạng tiền tệ Việt Nam với " VND"
        public static string FormatToVND(decimal amount)
        {
            return amount.ToString("#,0") + " VND";  // Sử dụng định dạng số và thêm " VND"
        }

        // Phương thức để định dạng tiền tệ Việt Nam từ null hoặc DBNull
        public static string FormatToVND(object amount)
        {
            if (amount == null || amount == DBNull.Value)
            {
                return "0 VND";
            }

            decimal amountDecimal = Convert.ToDecimal(amount);
            return amountDecimal.ToString("#,0") + " VND";  // Sử dụng định dạng số và thêm " VND"
        }

        // Phương thức để thêm dấu % vào tỷ lệ giảm giá
        public static string FormatToPercentage(object amount)
        {
            if (amount == null || amount == DBNull.Value)
            {
                return "0 %";
            }

            decimal amountDecimal = Convert.ToDecimal(amount);
            return amountDecimal.ToString("0") + " %"; // Định dạng không có thập phân, chỉ có số nguyên và dấu %
        }
    }
}
