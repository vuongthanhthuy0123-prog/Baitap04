using System.Drawing.Drawing2D;

namespace QuanLySinhVien
{
    public partial class FormMain : Form
    {
        private string nguoiDung;   // null = chưa đăng nhập

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            GanIcon();
            tmrDongHo_Tick(null, EventArgs.Empty);

            // Gắn menu chuột phải vào vùng nền MDI (MdiClient) của Form cha
            foreach (Control c in Controls)
                if (c is MdiClient) c.ContextMenuStrip = cmsMain;

            CapNhatTrangThaiDangNhap();
            BeginInvoke(new Action(DangNhap));   // hiện hộp đăng nhập sau khi Form chính đã hiện
        }

        // =====================================================================
        // QUẢN LÝ FORM CON: chưa mở -> tạo mới; đã mở -> chỉ Activate (không mở lặp lại)
        // =====================================================================
        private void MoFormCon<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    if (f.WindowState == FormWindowState.Minimized) f.WindowState = FormWindowState.Normal;
                    f.Activate();
                    HienThongBao("Cửa sổ \"" + f.Text + "\" đã mở, đưa lên trên cùng");
                    return;
                }
            }

            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
            HienThongBao("Đã mở cửa sổ \"" + frm.Text + "\"");
        }

        private void mnuQuanLySinhVien_Click(object sender, EventArgs e)
        {
            MoFormCon<FormStudent>();
        }

        private void mnuQuanLySanPham_Click(object sender, EventArgs e)
        {
            MoFormCon<FormProduct>();
        }

        private void Cascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TileVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void cmsDongTatCa_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren) f.Close();
            HienThongBao("Đã đóng tất cả cửa sổ");
        }

        // =====================================================================
        // GIAO TIẾP CHA - CON: các hàm public để Form con gọi lên (qua MdiParent)
        // =====================================================================
        public void HienThongBao(string noiDung)
        {
            lblThongBao.Text = DateTime.Now.ToString("HH:mm:ss") + "  " + noiDung;
        }

        public void BatDauTienTrinh(string noiDung)
        {
            HienThongBao(noiDung);
            prgTienTrinh.Value = 0;
            lblPhanTram.Text = "0%";
            prgTienTrinh.Visible = true;
            lblPhanTram.Visible = true;
        }

        public void CapNhatTienTrinh(int phanTram)
        {
            prgTienTrinh.Value = Math.Max(0, Math.Min(100, phanTram));
            lblPhanTram.Text = phanTram + "%";
        }

        public void KetThucTienTrinh()
        {
            prgTienTrinh.Visible = false;
            lblPhanTram.Visible = false;
        }

        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
        }

        // =====================================================================
        // ĐĂNG NHẬP / ĐĂNG XUẤT / THOÁT
        // =====================================================================
        private void DangNhap()
        {
            string ten = HoiTenDangNhap();
            if (ten == null)
            {
                HienThongBao("Chưa đăng nhập. Vào Hệ thống > Đăng nhập để tiếp tục.");
                return;
            }
            nguoiDung = ten;
            CapNhatTrangThaiDangNhap();
            HienThongBao("Đăng nhập thành công. Xin chào " + ten + "!");
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (nguoiDung == null)   // đang đăng xuất -> nút này thành "Đăng nhập"
            {
                DangNhap();
                return;
            }

            if (MessageBox.Show("Đăng xuất sẽ đóng tất cả cửa sổ đang mở. Tiếp tục?", "Đăng xuất",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            foreach (Form f in MdiChildren) f.Close();
            if (MdiChildren.Length > 0) return;

            nguoiDung = null;
            CapNhatTrangThaiDangNhap();
            HienThongBao("Đã đăng xuất");
            DangNhap();
        }

        private void CapNhatTrangThaiDangNhap()
        {
            bool daDangNhap = nguoiDung != null;
            lblNguoiDung.Text = daDangNhap ? "Người dùng: " + nguoiDung : "Chưa đăng nhập";
            mnuDangXuat.Text = daDangNhap ? "Đăng xuất" : "Đăng nhập";
            tsbDangXuat.Text = mnuDangXuat.Text;
            mnuDanhMuc.Enabled = daDangNhap;
            tsbSinhVien.Enabled = daDangNhap;
            tsbSanPham.Enabled = daDangNhap;
            Text = daDangNhap ? "Hệ thống Quản lý - " + nguoiDung : "Hệ thống Quản lý";
        }

        // Hộp thoại đăng nhập tạo bằng code: người dùng tự nhập tên
        private string HoiTenDangNhap()
        {
            using (Form dlg = new Form())
            using (ErrorProvider loi = new ErrorProvider())
            {
                dlg.Text = "Đăng nhập";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ShowInTaskbar = false;
                dlg.ClientSize = new Size(380, 130);
                dlg.AutoScaleMode = AutoScaleMode.Font;
                dlg.Font = Font;
                loi.BlinkStyle = ErrorBlinkStyle.NeverBlink;

                Label lbl = new Label { Text = "Tên đăng nhập:", Location = new Point(15, 24), AutoSize = true };
                TextBox txt = new TextBox { Location = new Point(125, 20), Width = 235 };
                Button btnOk = new Button { Text = "Đăng nhập", Location = new Point(125, 72), Size = new Size(120, 36), AutoSize = true };
                Button btnHuy = new Button { Text = "Hủy", Location = new Point(255, 72), Size = new Size(105, 36), DialogResult = DialogResult.Cancel };

                btnOk.Click += (s, e) =>
                {
                    if (txt.Text.Trim() == "")
                    {
                        loi.SetError(txt, "Vui lòng nhập tên đăng nhập.");
                        txt.Focus();
                        return;
                    }
                    dlg.DialogResult = DialogResult.OK;
                };
                txt.TextChanged += (s, e) => loi.SetError(txt, "");

                dlg.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnHuy });
                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnHuy;

                return dlg.ShowDialog(this) == DialogResult.OK ? txt.Text.Trim() : null;
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        // =====================================================================
        // ICON CHO TOOLSTRIP (vẽ bằng code, không cần file ảnh)
        // =====================================================================
        private void GanIcon()
        {
            tsbSinhVien.Image = IconChu("SV", Color.FromArgb(0, 102, 204));
            tsbSanPham.Image = IconChu("SP", Color.FromArgb(230, 126, 34));
            tsbCascade.Image = IconCuaSo(0);
            tsbTileHorizontal.Image = IconCuaSo(1);
            tsbTileVertical.Image = IconCuaSo(2);
            tsbDangXuat.Image = IconChu("↩", Color.SeaGreen);
            tsbThoat.Image = IconChu("X", Color.FromArgb(200, 40, 40));

            mnuQuanLySinhVien.Image = tsbSinhVien.Image;
            mnuQuanLySanPham.Image = tsbSanPham.Image;
            mnuCascade.Image = tsbCascade.Image;
            mnuTileHorizontal.Image = tsbTileHorizontal.Image;
            mnuTileVertical.Image = tsbTileVertical.Image;
            mnuDangXuat.Image = tsbDangXuat.Image;
            mnuThoat.Image = tsbThoat.Image;
        }

        private static Bitmap IconChu(string chu, Color mau)
        {
            Bitmap bmp = new Bitmap(20, 20);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush nen = new SolidBrush(mau))
            using (Font f = new Font("Segoe UI", chu.Length > 1 ? 7f : 9f, FontStyle.Bold))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(nen, 1, 1, 18, 18);
                g.DrawString(chu, f, Brushes.White, new RectangleF(0, 0, 20, 20), sf);
            }
            return bmp;
        }

        // kieu: 0 = Cascade, 1 = Tile ngang, 2 = Tile dọc
        private static Bitmap IconCuaSo(int kieu)
        {
            Bitmap bmp = new Bitmap(20, 20);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen p = new Pen(Color.FromArgb(60, 60, 60)))
            using (Brush nen = new SolidBrush(Color.FromArgb(200, 225, 250)))
            {
                Rectangle[] o;
                if (kieu == 0) o = new[] { new Rectangle(1, 1, 12, 10), new Rectangle(4, 5, 12, 10), new Rectangle(7, 9, 12, 10) };
                else if (kieu == 1) o = new[] { new Rectangle(1, 2, 18, 7), new Rectangle(1, 11, 18, 7) };
                else o = new[] { new Rectangle(1, 2, 8, 16), new Rectangle(11, 2, 8, 16) };

                foreach (Rectangle r in o)
                {
                    g.FillRectangle(nen, r);
                    g.DrawRectangle(p, r);
                }
            }
            return bmp;
        }
    }
}
