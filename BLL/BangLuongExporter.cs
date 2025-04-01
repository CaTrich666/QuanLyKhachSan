using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace BLL
{
    public class BangLuongExporter
    {
        private string filePath;
        private DataTable dataTable;

        public BangLuongExporter(DataTable dt, string tenNhanVien, DateTime ngayXuat)
        {
            dataTable = dt;

            // Lấy đường dẫn Desktop của người dùng
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Tạo đường dẫn tới thư mục "Lưu bảng lương" trên Desktop
            string thuMucLuu = Path.Combine(desktopPath, "Lưu bảng lương");

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(thuMucLuu))
            {
                Directory.CreateDirectory(thuMucLuu);
            }

            // Loại bỏ ký tự không hợp lệ trong tên file
            string tenNhanVienHopLe = LoaiBoKyTuKhongHopLe(tenNhanVien);

            // Tạo đường dẫn file (Tên nhân viên + Ngày giờ xuất)
            string fileName = $"{tenNhanVienHopLe}_Luong_{ngayXuat:yyyy-MM-dd_HH-mm-ss}.xlsx";
            filePath = Path.Combine(thuMucLuu, fileName);
        }

        // Hàm loại bỏ ký tự không hợp lệ
        private string LoaiBoKyTuKhongHopLe(string ten)
        {
            return string.IsNullOrWhiteSpace(ten) ? "NhanVien"
                : new string(ten.Where(c => !Path.GetInvalidFileNameChars().Contains(c)).ToArray());
        }

        public bool SaveToExcel(out string savedFilePath, out string errorMessage)
        {
            savedFilePath = null;
            errorMessage = null;

            try
            {
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    errorMessage = "Không có dữ liệu để xuất!";
                    return false;
                }

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    workbook.Worksheets.Add(dataTable, "BangLuong");
                    workbook.SaveAs(filePath);
                }

                savedFilePath = filePath;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xuất Excel: " + ex.Message;
                return false;
            }
        }



    }
}
