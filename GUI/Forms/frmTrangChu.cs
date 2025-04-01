using BLL;
using DTO;
using GUI.Controls;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI
{
    public partial class frmTrangChu : Form
    {
        private bool sidebarExpand = false;
        private readonly int sidebarMinWidth = 62;
        private readonly int sidebarMaxWidth = 188;



        private PanelExpander quanLyExpander;
        private PanelExpander datPhongExpander;
        private PanelExpander thongKeExpander;
        private PanelExpander taiKhoanDangNhapExpander;


        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public frmTrangChu()
        {
            InitializeComponent();

            AdjustSidebarHeight(); // Cập nhật chiều cao khi khởi động
            sidebarExpand = (sidebar.Width >= sidebarMaxWidth);

            // Tạo PanelExpander cho từng panel riêng biệt
            quanLyExpander = new PanelExpander(quanLyContainer, quanLyTimer, true);
            datPhongExpander = new PanelExpander(datPhongContainer, datPhongTimer, true);
            thongKeExpander = new PanelExpander(thongKeContainer, thongKeTimer, true);
            taiKhoanDangNhapExpander = new PanelExpander(taiKhoanContainer, taiKhoanDangNhapTimer, true);

            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;


            ChangeTaiKhoan();

            LoadPhong();
            Loads();
        }


        void Loads()
        {
            LoadComboBoxPTTT();
        }




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);




        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= sidebarMinWidth)
                {
                    sidebar.Width = sidebarMinWidth;
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= sidebarMaxWidth)
                {
                    sidebar.Width = sidebarMaxWidth;
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        //Đảm bảo sidebar tự thay đổi chiều cao khi form thay đổi kích thước
        private void frmTrangChu_Resize(object sender, EventArgs e)
        {
            AdjustSidebarHeight();
        }

        private void AdjustSidebarHeight()
        {
            sidebar.Height = this.ClientSize.Height; // Cập nhật chiều cao theo form
        }












        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    panelTitleBar.BackColor = color;
                    panelMenu.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control panel in sidebar.Controls) // Duyệt qua các panel con trong sidebar
            {
                if (panel is Panel) // Nếu control là Panel
                {
                    foreach (Control ctrl in panel.Controls) // Duyệt qua control trong panel
                    {
                        if (ctrl is Button previousBtn) // Nếu control là Button
                        {
                            previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                            previousBtn.ForeColor = Color.Gainsboro;
                            previousBtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(163)));
                        }
                    }
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        //Phân quyền tài khoản
        void PhanQuyen()
        {
            if (!CurrentUser.Instance.QuyenTaiKhoan) // Nếu là nhân viên
            {
                btnThongKe.Enabled = false;
                btnTaiKhoan.Enabled = false;
                btnHoaDon.Enabled = false;

            }
        }


        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            PhanQuyen();

        }




        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            quanLyExpander.Start();
            ActivateButton(sender);
        }

        private void btnDatPhongMenu_Click(object sender, EventArgs e)
        {
            datPhongExpander.Start();
            ActivateButton(sender);
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmDatPhong(), sender);
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmNhanPhong(), sender);
        }

        private void btnThongTinDat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmThongTinDatPhong(), sender);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            thongKeExpander.Start();
            ActivateButton(sender);
        }

        private void btnDoanhThuPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmThongKeHoaDon(), sender);
        }

        private void btnDoanhThuDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmDoanhThuDichVu(), sender);
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmThongKeLuong(), sender);
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmNhanVien(), sender);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmKhachHang(), sender);
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmChucVu(), sender);
        }

        private void btnCaLam_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmCaLam(), sender);
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmDichVu(), sender);
        }

        private void btnThietBi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmThietBi(), sender);
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmPhong(), sender);
        }

        private void btnLoaiPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmLoaiPhong(), sender);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.frmTaiKhoan(), sender);
            frmTaiKhoan formTaiKhoan = new frmTaiKhoan();

            //Đăng ký sự kiện
            formTaiKhoan.OnTaiKhoanUpdated += ChangeTaiKhoan;

            OpenChildForm(formTaiKhoan, sender);
        }

        private void btnLichTruc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmLichTruc(), sender);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmHoaDon(), sender);
        }

        private void btnTKDangNhap_Click(object sender, EventArgs e)
        {
            taiKhoanDangNhapExpander.Start();
            ActivateButton(sender);
        }

        private void btnThongTinTKDN_Click(object sender, EventArgs e)
        {
            frmThongTinDangNhap formTaiKhoan = new frmThongTinDangNhap();

            //Đăng ký sự kiện
            formTaiKhoan.OnTaiKhoanUpdated += ChangeTaiKhoan;

            OpenChildForm(formTaiKhoan, sender);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form hiện tại

                frmDangNhap loginForm = new frmDangNhap();
                loginForm.ShowDialog();

                this.Close(); // Đóng form sau khi form đăng nhập bị đóng
            }
        }

        //Reset về trang chủ
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            // Tải lại danh sách bàn để hiển thị ghi chú mới
            LoadPhong();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Trang Chủ";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelMenu.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        //Thoát
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Phong to
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        //Thu nhỏ
        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Kéo trang bằng thanh panelTitleBar
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }




        void ChangeTaiKhoan()
        {

            // Cập nhật dữ liệu trên giao diện
            lblTenTaiKhoan.Text = CurrentUser.Instance.TenTaiKhoan;
            lblQuyen.Text = CurrentUser.Instance.QuyenTaiKhoan ? "Quản lý" : "Nhân viên";

            lblTenTaiKhoan.Refresh();
            lblQuyen.Refresh();
        }







        void LoadComboBoxPTTT()
        {
            cbPTTT.DataSource = new List<string> { "Tiền mặt", "Chuyển khoản" };
        }













        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn && btn.Tag is Phong phong)
                {
                    int maPhong = phong.MaPhong;
                    flpPhong.Tag = phong;

                    // Lấy phiếu đặt theo mã phòng
                    PhieuDat phieuDat = PhieuDatBLL.Instance.GetPhieuDatByPhong(maPhong);
                    if (phieuDat == null)
                    {
                        txtTongTienPhong.Text = "0";
                        txtTongTienDichVu.Text = "0";
                        return;
                    }

                    // Lấy thông tin phòng theo phiếu đặt
                    Phong phongDat = PhieuDatBLL.Instance.GetPhongByPhieuDat(phieuDat.MaPD);
                    if (phongDat == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin phòng!");
                        return;
                    }

                    // Lấy thông tin loại phòng
                    LoaiPhong loaiPhong = LoaiPhongBLL.Instance.GetLoaiPhongById(phongDat.MaLoai);
                    if (loaiPhong == null)
                    {
                        MessageBox.Show("Không tìm thấy loại phòng!");
                        return;
                    }

                    // Tính tổng tiền phòng
                    int soNgayThue = Math.Max((phieuDat.NgayTraPhong - phieuDat.NgayNhanPhong).Days, 1);
                    decimal tongTienPhong = loaiPhong.GiaLP * soNgayThue;

                    // Lấy danh sách dịch vụ từ phiếu đặt
                    List<Tuple<DichVu, ChiTietDichVu>> danhSachDichVu = PhieuDatBLL.Instance.GetDichVuByPhieuDat(phieuDat.MaPD) ?? new List<Tuple<DichVu, ChiTietDichVu>>();
                    decimal tongTienDichVu = danhSachDichVu.Sum(dv => dv.Item1.GiaDV * dv.Item2.SoLuong);

                    // Hiển thị tổng tiền lên giao diện
                    txtTongTienPhong.Text = CurrencyFormatter.FormatToVND(tongTienPhong);
                    txtTongTienDichVu.Text = CurrencyFormatter.FormatToVND(tongTienDichVu);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể xác định phòng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        void LoadPhong()
        {
            flpPhong.Controls.Clear();
            List<Phong> phongList = PhongBLL.Instance.GetListPhong();
            List<LoaiPhong> loaiPhongList = LoaiPhongBLL.Instance.GetListLoaiPhong();
            List<ChiTietPhieuDat> ctpdList = ChiTietPhieuDatBLL.Instance.GetListChiTietPhieuDat();

            foreach (Phong item in phongList)
            {
                // Tìm tên loại phòng từ danh sách loại phòng
                string tenLoaiPhong = loaiPhongList.FirstOrDefault(lp => lp.MaLoai == item.MaLoai)?.TenLoai ?? "N/A";
                string maPhieuDat = ctpdList.FirstOrDefault(pd => pd.MaPhong == item.MaPhong)?.MaPD.ToString() ?? "";

                Button btn = new Button();
                btn.Width = 171;
                btn.Height = 120;
                btn.Text = item.TenPhong + Environment.NewLine + Environment.NewLine + tenLoaiPhong + Environment.NewLine + Environment.NewLine + item.TinhTrangP + " (" + maPhieuDat + ")";
                //btn.Text = item.TenPhong + "\n" + tenLoaiPhong + "\n" + item.TinhTrangP;
                btn.TextAlign = ContentAlignment.TopCenter; // Đưa văn bản lên trên và căn giữa
                //btn.Text = item.TenPhong.ToUpper(); // Chỉ thay đổi chữ cho tên phòng
                btn.Font = new Font(btn.Font.FontFamily, 9); // Tăng kích thước chữ cho cả button


                btn.Click += btn_Click;
                btn.Tag = item;


                if (item.TinhTrangP == "Trống")
                {
                    btn.BackColor = ColorTranslator.FromHtml("#06D7A0");
                }
                else if (item.TinhTrangP == "Đã đặt")
                {
                    btn.BackColor = ColorTranslator.FromHtml("#AEC3B0");
                }
                else
                {
                    btn.BackColor = ColorTranslator.FromHtml("#F04770");
                }



                // Thêm biểu tượng dấu cộng (+) ở góc trên bên phải button
                Label lblPlus = new Label();
                lblPlus.Text = "+";
                lblPlus.Font = new Font(lblPlus.Font.FontFamily, 12);
                lblPlus.ForeColor = Color.White;
                lblPlus.Location = new Point(btn.Width - 20, 0); // Vị trí góc trên bên phải
                lblPlus.Cursor = Cursors.Hand;
                lblPlus.BackColor = ColorTranslator.FromHtml("#FFD167");

                lblPlus.Click += (sender, e) =>
                {
                    ShowNoteMenu(item); // Mở menu ghi chú khi click vào dấu cộng
                };
                btn.Controls.Add(lblPlus);

                // Thêm ghi chú vào button bàn (nếu có)
                if (phongNotes.ContainsKey(item.MaPhong) && !string.IsNullOrEmpty(phongNotes[item.MaPhong]))
                {
                    Label lblNote = new Label();
                    lblNote.Text = phongNotes[item.MaPhong];  // Lấy ghi chú từ bộ nhớ tạm thời
                    lblNote.Font = new Font(lblNote.Font.FontFamily, 8);
                    lblNote.ForeColor = Color.FromArgb(0, 123, 255);

                    // Tính toán chiều rộng của ghi chú dựa trên văn bản thực tế
                    Size textSize = TextRenderer.MeasureText(lblNote.Text, lblNote.Font);

                    // Đặt chiều rộng của Label bằng với chiều rộng của văn bản
                    lblNote.Width = textSize.Width;

                    // Căn giữa ghi chú theo chiều ngang
                    lblNote.Location = new Point((btn.Width - lblNote.Width) / 2, btn.Height - 20); // Căn giữa theo chiều ngang

                    // Bỏ nền của ghi chú (nền trong suốt)
                    lblNote.BackColor = Color.Transparent;

                    // Không có viền cho ghi chú
                    lblNote.BorderStyle = BorderStyle.None;

                    btn.Controls.Add(lblNote);
                }

                // Thêm button vào FlowLayoutPanel
                flpPhong.Controls.Add(btn);
            }
        }


        // Lưu ghi chú tạm thời trong bộ nhớ
        private Dictionary<int, string> phongNotes = new Dictionary<int, string>();


        private void ShowNoteMenu(Phong phong)
        {
            // Tạo ContextMenuStrip
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Các lựa chọn ghi chú mặc định
            contextMenu.Items.Add("Cần dọn dẹp", null, (sender, e) => SetNote(phong, "Cần dọn dẹp"));

            // Thêm lựa chọn "Tạo ghi chú mới"
            contextMenu.Items.Add("Tạo ghi chú mới", null, (sender, e) =>
            {
                // Mở hộp thoại nhập ghi chú
                string inputNote = ShowInputDialog("Nhập ghi chú mới:");

                if (!string.IsNullOrEmpty(inputNote))
                {
                    // Lưu ghi chú vào tableNotes
                    SetNote(phong, inputNote);
                }
            });

            // Thêm lựa chọn để xóa ghi chú
            contextMenu.Items.Add("Xóa ghi chú", null, (sender, e) => SetNote(phong, null));

            // Hiển thị menu tại vị trí hiện tại
            contextMenu.Show(Cursor.Position);
        }





        private void SetNote(Phong phong, string note)
        {
            // Cập nhật ghi chú cho đối tượng table
            if (note == null)
            {
                // Xóa ghi chú nếu note là null
                if (phongNotes.ContainsKey(phong.MaPhong))
                {
                    phongNotes.Remove(phong.MaPhong); // Xóa ghi chú khỏi bộ nhớ tạm thời
                }
            }
            else
            {
                // Thêm hoặc thay đổi ghi chú cho đối tượng table
                phongNotes[phong.MaPhong] = note;
            }

            // Tải lại danh sách bàn để hiển thị ghi chú mới
            LoadPhong();
        }





        // Hàm hiển thị hộp thoại nhập ghi chú
        private string ShowInputDialog(string prompt)
        {
            Form inputForm = new Form
            {
                Width = 300,
                Height = 150,
                Text = prompt,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label lblPrompt = new Label { Left = 10, Top = 10, Text = prompt, Width = 250 };
            TextBox txtInput = new TextBox { Left = 10, Top = 40, Width = 250 };
            Button btnOk = new Button { Text = "OK", Left = 180, Width = 80, Top = 70, DialogResult = DialogResult.OK };

            inputForm.Controls.Add(lblPrompt);
            inputForm.Controls.Add(txtInput);
            inputForm.Controls.Add(btnOk);

            inputForm.AcceptButton = btnOk;

            return inputForm.ShowDialog() == DialogResult.OK ? txtInput.Text : string.Empty;
        }






        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin phòng từ flpPhong.Tag (được gán khi nhấn vào Button phòng)
                if (flpPhong.Tag == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng trước khi thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin phòng từ flpPhong.Tag
                Phong phong = flpPhong.Tag as Phong;

                if (phong == null)
                {
                    MessageBox.Show("Không thể xác định phòng. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tinhTrangP = phong.TinhTrangP;

                // Kiểm tra tình trạng phòng
                if (tinhTrangP == "Trống")
                {
                    MessageBox.Show("Phòng đang trống. Không thể thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (tinhTrangP == "Đã đặt")
                {
                    MessageBox.Show("Phòng vẫn đang được đặt. Vui lòng chờ nhận phòng trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (tinhTrangP == "Đang sử dụng")
                {
                    // Lấy thông tin phiếu đặt
                    PhieuDat phieuDat = PhieuDatBLL.Instance.GetPhieuDatByPhong(phong.MaPhong);
                    if (phieuDat == null)
                    {
                        MessageBox.Show("Không tìm thấy phiếu đặt cho phòng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Tính tổng tiền
                    // Lấy thông tin loại phòng của phòng này
                    LoaiPhong loaiPhong = LoaiPhongBLL.Instance.GetListLoaiPhong()
                        .FirstOrDefault(lp => lp.MaLoai == phong.MaLoai);

                    // Kiểm tra xem loại phòng có tồn tại không
                    decimal giaLoaiPhong = loaiPhong?.GiaLP ?? 0;

                    // Tính số ngày thuê
                    int soNgayThue = Math.Max((phieuDat.NgayTraPhong - phieuDat.NgayNhanPhong).Days, 1);

                    // Tính tổng tiền phòng
                    decimal tongTienPhong = giaLoaiPhong * soNgayThue;

                    decimal tongTienDV = HoaDonBLL.Instance.TinhTongTienDichVu(phieuDat.MaPD);

                    // Lấy giá trị giảm giá

                    if (!int.TryParse(nmGiamGia.Text, out int giamGia) || giamGia < 0 || giamGia > 100)
                    {
                        MessageBox.Show("Giảm giá phải là số nguyên từ 0 đến 100!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }



                    // Tính tổng tiền sau giảm giá
                    decimal tongTienTruocGiam = (tongTienPhong + tongTienDV) - phieuDat.TienCoc;
                    decimal tienGiam = tongTienTruocGiam * giamGia / 100;
                    decimal tongTienThanhToan = tongTienTruocGiam - tienGiam;

                    // Tạo đối tượng hóa đơn (đảm bảo không có giá trị null)
                    HoaDon hoaDon = new HoaDon
                    (
                        maHD: 0,
                        ngayLap: DateTime.Now,
                        tongTienPhong: tongTienPhong,
                        tongTienDV: tongTienDV,
                        giamGia: giamGia,
                        ptThanhToan: cbPTTT.SelectedItem.ToString(),
                        trangThaiHD: "Đã thanh toán",
                        tongTienThanhToan: tongTienThanhToan,
                        maPD: phieuDat.MaPD,
                        maNV: CurrentUser.Instance.MaNhanVien
                    );

                    // Lưu hóa đơn vào database
                    if (!HoaDonBLL.Instance.InsertHoaDon(hoaDon))
                    {
                        MessageBox.Show("Lỗi khi tạo hóa đơn. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }




                    // Tạo nội dung hóa đơn với giảm giá
                    string noiDungHoaDon = PhieuDatBLL.Instance.GenerateInvoiceContent(phong.MaPhong, giamGia);

                    // Hiển thị hóa đơn trong MessageBox
                    MessageBox.Show(noiDungHoaDon, "Hóa đơn thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);




                    //Lưu háo đơn

                    // Lấy thông tin khách hàng từ phiếu đặt
                    KhachHang khachHang = PhieuDatBLL.Instance.GetKhachHangByPhieuDat(phieuDat.MaPD);
                    if (khachHang == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin khách hàng!");
                        return;
                    }

                    HoaDonPrinter printer = new HoaDonPrinter(noiDungHoaDon, phieuDat, khachHang, DateTime.Now);
                    printer.SaveHoaDonToPDF(out string filePath);





                    // Cập nhật trạng thái phiếu đặt thành "Đã nhận phòng"
                    phong.TinhTrangP = "Trống";
                    if (!PhongBLL.Instance.UpdatePhong(phong))
                    {
                        MessageBox.Show("Cập nhật trạng thái phiếu đặt thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhong();
                }
                else
                {
                    MessageBox.Show("Trạng thái phiếu đặt không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
