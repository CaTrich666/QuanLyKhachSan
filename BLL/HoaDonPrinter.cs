using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BLL
{
    public class HoaDonPrinter
    {
        private string noiDungHoaDon;
        private string filePath;

        public HoaDonPrinter(string noiDung, PhieuDat phieuDat, KhachHang khachHang, DateTime ngayGioThanhToan)
        {
            noiDungHoaDon = noiDung;

            // Lấy đường dẫn Desktop của người dùng
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Tạo đường dẫn tới thư mục "Lưu hóa đơn" trên Desktop
            string thuMucLuu = Path.Combine(desktopPath, "Lưu hóa đơn");

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(thuMucLuu))
            {
                Directory.CreateDirectory(thuMucLuu);
            }

            // Lấy tên khách hàng hợp lệ
            string tenKhachHangHopLe = LoaiBoKyTuKhongHopLe(khachHang.TenKH);

            // Tạo đường dẫn file với dấu ":" trong giờ & phút
            string fileName = $"{tenKhachHangHopLe}_Ngày_{ngayGioThanhToan:yyyy-MM-dd}_Giờ_{ngayGioThanhToan:HH-mm-ss}.pdf";
            filePath = Path.Combine(thuMucLuu, fileName);
        }

        // Hàm loại bỏ ký tự không hợp lệ trong tên file
        private string LoaiBoKyTuKhongHopLe(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten)) return "KhachHang"; // Nếu tên rỗng, đặt tên mặc định

            string invalidChars = new string(Path.GetInvalidFileNameChars());
            foreach (char c in invalidChars)
            {
                ten = ten.Replace(c.ToString(), ""); // Xóa ký tự không hợp lệ
            }
            return ten.Trim(); // Xóa khoảng trắng thừa
        }

        public bool SaveHoaDonToPDF(out string savedFilePath)
        {
            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Tải font hỗ trợ Unicode
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(bf, 12, Font.NORMAL);

                Paragraph paragraph = new Paragraph(noiDungHoaDon, font);
                doc.Add(paragraph);

                doc.Close();
                savedFilePath = filePath;
                return true;
            }
            catch
            {
                savedFilePath = null;
                return false;
            }
        }

    }
}
