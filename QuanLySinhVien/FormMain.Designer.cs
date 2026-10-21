namespace QuanLySinhVien
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuSep1 = new ToolStripSeparator();
            mnuThoat = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuQuanLySinhVien = new ToolStripMenuItem();
            mnuQuanLySanPham = new ToolStripMenuItem();
            mnuCuaSo = new ToolStripMenuItem();
            mnuCascade = new ToolStripMenuItem();
            mnuTileHorizontal = new ToolStripMenuItem();
            mnuTileVertical = new ToolStripMenuItem();
            mnuSep2 = new ToolStripSeparator();
            toolStrip = new ToolStrip();
            tsbSinhVien = new ToolStripButton();
            tsbSanPham = new ToolStripButton();
            tsSep1 = new ToolStripSeparator();
            tsbCascade = new ToolStripButton();
            tsbTileHorizontal = new ToolStripButton();
            tsbTileVertical = new ToolStripButton();
            tsSep2 = new ToolStripSeparator();
            tsbDangXuat = new ToolStripButton();
            tsbThoat = new ToolStripButton();
            statusStrip = new StatusStrip();
            lblNguoiDung = new ToolStripStatusLabel();
            lblThongBao = new ToolStripStatusLabel();
            lblPhanTram = new ToolStripStatusLabel();
            prgTienTrinh = new ToolStripProgressBar();
            lblThoiGian = new ToolStripStatusLabel();
            cmsMain = new ContextMenuStrip(components);
            cmsCascade = new ToolStripMenuItem();
            cmsTileHorizontal = new ToolStripMenuItem();
            cmsTileVertical = new ToolStripMenuItem();
            cmsSep1 = new ToolStripSeparator();
            cmsDongTatCa = new ToolStripMenuItem();
            tmrDongHo = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            cmsMain.SuspendLayout();
            SuspendLayout();
            //
            // menuStrip
            //
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuDanhMuc, mnuCuaSo });
            menuStrip.Location = new Point(0, 0);
            menuStrip.MdiWindowListItem = mnuCuaSo;
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1200, 24);
            menuStrip.TabIndex = 0;
            //
            // mnuHeThong
            //
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuSep1, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Text = "&Hệ thống";
            //
            // mnuDangXuat
            //
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            //
            // mnuThoat
            //
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            //
            // mnuDanhMuc
            //
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuQuanLySinhVien, mnuQuanLySanPham });
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Text = "&Danh mục";
            //
            // mnuQuanLySinhVien
            //
            mnuQuanLySinhVien.Name = "mnuQuanLySinhVien";
            mnuQuanLySinhVien.ShortcutKeys = Keys.Control | Keys.D1;
            mnuQuanLySinhVien.Text = "Quản lý Sinh viên";
            mnuQuanLySinhVien.Click += mnuQuanLySinhVien_Click;
            //
            // mnuQuanLySanPham
            //
            mnuQuanLySanPham.Name = "mnuQuanLySanPham";
            mnuQuanLySanPham.ShortcutKeys = Keys.Control | Keys.D2;
            mnuQuanLySanPham.Text = "Quản lý Sản phẩm";
            mnuQuanLySanPham.Click += mnuQuanLySanPham_Click;
            //
            // mnuCuaSo
            //
            mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[] { mnuCascade, mnuTileHorizontal, mnuTileVertical, mnuSep2 });
            mnuCuaSo.Name = "mnuCuaSo";
            mnuCuaSo.Text = "&Cửa sổ";
            //
            // mnuCascade
            //
            mnuCascade.Name = "mnuCascade";
            mnuCascade.Text = "Cascade";
            mnuCascade.Click += Cascade_Click;
            //
            // mnuTileHorizontal
            //
            mnuTileHorizontal.Name = "mnuTileHorizontal";
            mnuTileHorizontal.Text = "Tile Horizontal";
            mnuTileHorizontal.Click += TileHorizontal_Click;
            //
            // mnuTileVertical
            //
            mnuTileVertical.Name = "mnuTileVertical";
            mnuTileVertical.Text = "Tile Vertical";
            mnuTileVertical.Click += TileVertical_Click;
            //
            // toolStrip
            //
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbSinhVien, tsbSanPham, tsSep1, tsbCascade, tsbTileHorizontal, tsbTileVertical, tsSep2, tsbDangXuat, tsbThoat });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1200, 27);
            toolStrip.TabIndex = 1;
            //
            // tsbSinhVien
            //
            tsbSinhVien.Name = "tsbSinhVien";
            tsbSinhVien.Text = "Sinh viên";
            tsbSinhVien.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbSinhVien.ToolTipText = "Quản lý Sinh viên (Ctrl+1)";
            tsbSinhVien.Click += mnuQuanLySinhVien_Click;
            //
            // tsbSanPham
            //
            tsbSanPham.Name = "tsbSanPham";
            tsbSanPham.Text = "Sản phẩm";
            tsbSanPham.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbSanPham.ToolTipText = "Quản lý Sản phẩm (Ctrl+2)";
            tsbSanPham.Click += mnuQuanLySanPham_Click;
            //
            // tsbCascade
            //
            tsbCascade.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbCascade.Name = "tsbCascade";
            tsbCascade.Text = "Cascade";
            tsbCascade.ToolTipText = "Xếp chồng (Cascade)";
            tsbCascade.Click += Cascade_Click;
            //
            // tsbTileHorizontal
            //
            tsbTileHorizontal.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbTileHorizontal.Name = "tsbTileHorizontal";
            tsbTileHorizontal.Text = "Tile Horizontal";
            tsbTileHorizontal.ToolTipText = "Xếp ngang (Tile Horizontal)";
            tsbTileHorizontal.Click += TileHorizontal_Click;
            //
            // tsbTileVertical
            //
            tsbTileVertical.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbTileVertical.Name = "tsbTileVertical";
            tsbTileVertical.Text = "Tile Vertical";
            tsbTileVertical.ToolTipText = "Xếp dọc (Tile Vertical)";
            tsbTileVertical.Click += TileVertical_Click;
            //
            // tsbDangXuat
            //
            tsbDangXuat.Name = "tsbDangXuat";
            tsbDangXuat.Text = "Đăng xuất";
            tsbDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbDangXuat.Click += mnuDangXuat_Click;
            //
            // tsbThoat
            //
            tsbThoat.Name = "tsbThoat";
            tsbThoat.Text = "Thoát";
            tsbThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbThoat.Click += mnuThoat_Click;
            //
            // statusStrip
            //
            statusStrip.Items.AddRange(new ToolStripItem[] { lblNguoiDung, lblThongBao, lblPhanTram, prgTienTrinh, lblThoiGian });
            statusStrip.Location = new Point(0, 728);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1200, 22);
            statusStrip.TabIndex = 2;
            //
            // lblNguoiDung
            //
            lblNguoiDung.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNguoiDung.ForeColor = Color.FromArgb(0, 84, 166);
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Text = "Chưa đăng nhập";
            //
            // lblThongBao
            //
            lblThongBao.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Spring = true;
            lblThongBao.Text = "Sẵn sàng";
            lblThongBao.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblPhanTram
            //
            lblPhanTram.Name = "lblPhanTram";
            lblPhanTram.Text = "0%";
            lblPhanTram.Visible = false;
            //
            // prgTienTrinh
            //
            prgTienTrinh.Name = "prgTienTrinh";
            prgTienTrinh.Size = new Size(180, 16);
            prgTienTrinh.Visible = false;
            //
            // lblThoiGian
            //
            lblThoiGian.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Text = "--:--:--";
            //
            // cmsMain  (chuột phải vào nền Form cha)
            //
            cmsMain.Items.AddRange(new ToolStripItem[] { cmsCascade, cmsTileHorizontal, cmsTileVertical, cmsSep1, cmsDongTatCa });
            cmsMain.Name = "cmsMain";
            //
            // cmsCascade
            //
            cmsCascade.Name = "cmsCascade";
            cmsCascade.Text = "Cascade";
            cmsCascade.Click += Cascade_Click;
            //
            // cmsTileHorizontal
            //
            cmsTileHorizontal.Name = "cmsTileHorizontal";
            cmsTileHorizontal.Text = "Tile Horizontal";
            cmsTileHorizontal.Click += TileHorizontal_Click;
            //
            // cmsTileVertical
            //
            cmsTileVertical.Name = "cmsTileVertical";
            cmsTileVertical.Text = "Tile Vertical";
            cmsTileVertical.Click += TileVertical_Click;
            //
            // cmsDongTatCa
            //
            cmsDongTatCa.Name = "cmsDongTatCa";
            cmsDongTatCa.Text = "Đóng tất cả cửa sổ";
            cmsDongTatCa.Click += cmsDongTatCa_Click;
            //
            // tmrDongHo
            //
            tmrDongHo.Enabled = true;
            tmrDongHo.Interval = 1000;
            tmrDongHo.Tick += tmrDongHo_Tick;
            //
            // FormMain
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 750);
            ContextMenuStrip = cmsMain;
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 9F);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            cmsMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripSeparator mnuSep1;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuQuanLySinhVien;
        private ToolStripMenuItem mnuQuanLySanPham;
        private ToolStripMenuItem mnuCuaSo;
        private ToolStripMenuItem mnuCascade;
        private ToolStripMenuItem mnuTileHorizontal;
        private ToolStripMenuItem mnuTileVertical;
        private ToolStripSeparator mnuSep2;
        private ToolStrip toolStrip;
        private ToolStripButton tsbSinhVien;
        private ToolStripButton tsbSanPham;
        private ToolStripSeparator tsSep1;
        private ToolStripButton tsbCascade;
        private ToolStripButton tsbTileHorizontal;
        private ToolStripButton tsbTileVertical;
        private ToolStripSeparator tsSep2;
        private ToolStripButton tsbDangXuat;
        private ToolStripButton tsbThoat;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblNguoiDung;
        private ToolStripStatusLabel lblThongBao;
        private ToolStripStatusLabel lblPhanTram;
        private ToolStripProgressBar prgTienTrinh;
        private ToolStripStatusLabel lblThoiGian;
        private ContextMenuStrip cmsMain;
        private ToolStripMenuItem cmsCascade;
        private ToolStripMenuItem cmsTileHorizontal;
        private ToolStripMenuItem cmsTileVertical;
        private ToolStripSeparator cmsSep1;
        private ToolStripMenuItem cmsDongTatCa;
        private System.Windows.Forms.Timer tmrDongHo;
    }
}
