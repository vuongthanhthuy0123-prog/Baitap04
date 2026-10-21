namespace QuanLySinhVien
{
    partial class FormProduct
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
            grpNhapLieu = new GroupBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblGia = new Label();
            txtGia = new TextBox();
            lblSoLuong = new Label();
            numSoLuong = new NumericUpDown();
            btnThem = new Button();
            btnNapDuLieu = new Button();
            prgNapDuLieu = new ProgressBar();
            lblPhanTram = new Label();
            dgvProducts = new DataGridView();
            cmsGrid = new ContextMenuStrip(components);
            mnuXoaDong = new ToolStripMenuItem();
            mnuLamMoi = new ToolStripMenuItem();
            mnuSep1 = new ToolStripSeparator();
            mnuXemChiTiet = new ToolStripMenuItem();
            lblTongKet = new Label();
            errorProvider = new ErrorProvider(components);
            grpNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            cmsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            //
            // grpNhapLieu
            //
            grpNhapLieu.Controls.Add(lblTenSP);
            grpNhapLieu.Controls.Add(txtTenSP);
            grpNhapLieu.Controls.Add(lblGia);
            grpNhapLieu.Controls.Add(txtGia);
            grpNhapLieu.Controls.Add(lblSoLuong);
            grpNhapLieu.Controls.Add(numSoLuong);
            grpNhapLieu.Controls.Add(btnThem);
            grpNhapLieu.Controls.Add(btnNapDuLieu);
            grpNhapLieu.Controls.Add(prgNapDuLieu);
            grpNhapLieu.Controls.Add(lblPhanTram);
            grpNhapLieu.Dock = DockStyle.Top;
            grpNhapLieu.Location = new Point(8, 8);
            grpNhapLieu.Name = "grpNhapLieu";
            grpNhapLieu.Size = new Size(784, 110);
            grpNhapLieu.TabIndex = 0;
            grpNhapLieu.TabStop = false;
            grpNhapLieu.Text = "Thêm sản phẩm";
            //
            // lblTenSP
            //
            lblTenSP.Location = new Point(12, 28);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(90, 18);
            lblTenSP.TabIndex = 20;
            lblTenSP.Text = "Tên sản phẩm";
            //
            // txtTenSP
            //
            txtTenSP.Location = new Point(12, 48);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(230, 23);
            txtTenSP.TabIndex = 0;
            //
            // lblGia
            //
            lblGia.Location = new Point(255, 28);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(90, 18);
            lblGia.TabIndex = 21;
            lblGia.Text = "Đơn giá (đ)";
            //
            // txtGia
            //
            txtGia.Location = new Point(255, 48);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(130, 23);
            txtGia.TabIndex = 1;
            txtGia.TextAlign = HorizontalAlignment.Right;
            //
            // lblSoLuong
            //
            lblSoLuong.Location = new Point(398, 28);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(90, 18);
            lblSoLuong.TabIndex = 22;
            lblSoLuong.Text = "Số lượng";
            //
            // numSoLuong
            //
            numSoLuong.Location = new Point(398, 48);
            numSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(90, 23);
            numSoLuong.TabIndex = 2;
            numSoLuong.TextAlign = HorizontalAlignment.Right;
            //
            // btnThem
            //
            btnThem.Location = new Point(505, 44);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 30);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // btnNapDuLieu
            //
            btnNapDuLieu.Location = new Point(12, 78);
            btnNapDuLieu.Name = "btnNapDuLieu";
            btnNapDuLieu.Size = new Size(200, 26);
            btnNapDuLieu.TabIndex = 4;
            btnNapDuLieu.Text = "Nạp dữ liệu (Async)";
            btnNapDuLieu.UseVisualStyleBackColor = true;
            btnNapDuLieu.Click += btnNapDuLieu_Click;
            //
            // prgNapDuLieu
            //
            prgNapDuLieu.Location = new Point(222, 81);
            prgNapDuLieu.Name = "prgNapDuLieu";
            prgNapDuLieu.Size = new Size(300, 20);
            prgNapDuLieu.TabIndex = 5;
            //
            // lblPhanTram
            //
            lblPhanTram.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhanTram.Location = new Point(530, 81);
            lblPhanTram.Name = "lblPhanTram";
            lblPhanTram.Size = new Size(60, 20);
            lblPhanTram.TabIndex = 23;
            lblPhanTram.Text = "0%";
            lblPhanTram.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dgvProducts  (các cột được tạo bằng code)
            //
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.ContextMenuStrip = cmsGrid;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(8, 118);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(784, 302);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
            //
            // cmsGrid
            //
            cmsGrid.Items.AddRange(new ToolStripItem[] { mnuXoaDong, mnuLamMoi, mnuSep1, mnuXemChiTiet });
            cmsGrid.Name = "cmsGrid";
            cmsGrid.Size = new Size(180, 76);
            //
            // mnuXoaDong
            //
            mnuXoaDong.Name = "mnuXoaDong";
            mnuXoaDong.Size = new Size(179, 22);
            mnuXoaDong.Text = "Xóa dòng";
            mnuXoaDong.Click += mnuXoaDong_Click;
            //
            // mnuLamMoi
            //
            mnuLamMoi.Name = "mnuLamMoi";
            mnuLamMoi.Size = new Size(179, 22);
            mnuLamMoi.Text = "Làm mới dữ liệu";
            mnuLamMoi.Click += mnuLamMoi_Click;
            //
            // mnuXemChiTiet
            //
            mnuXemChiTiet.Name = "mnuXemChiTiet";
            mnuXemChiTiet.Size = new Size(179, 22);
            mnuXemChiTiet.Text = "Xem chi tiết";
            mnuXemChiTiet.Click += mnuXemChiTiet_Click;
            //
            // lblTongKet
            //
            lblTongKet.Dock = DockStyle.Bottom;
            lblTongKet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongKet.Location = new Point(8, 420);
            lblTongKet.Name = "lblTongKet";
            lblTongKet.Size = new Size(784, 24);
            lblTongKet.TabIndex = 2;
            lblTongKet.Text = "Số sản phẩm: 0";
            lblTongKet.TextAlign = ContentAlignment.MiddleRight;
            //
            // errorProvider
            //
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            //
            // FormProduct
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 452);
            Controls.Add(dgvProducts);
            Controls.Add(lblTongKet);
            Controls.Add(grpNhapLieu);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(700, 400);
            Name = "FormProduct";
            Padding = new Padding(8);
            Text = "Quản lý Sản phẩm";
            Load += FormProduct_Load;
            grpNhapLieu.ResumeLayout(false);
            grpNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            cmsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpNhapLieu;
        private Label lblTenSP;
        private TextBox txtTenSP;
        private Label lblGia;
        private TextBox txtGia;
        private Label lblSoLuong;
        private NumericUpDown numSoLuong;
        private Button btnThem;
        private Button btnNapDuLieu;
        private ProgressBar prgNapDuLieu;
        private Label lblPhanTram;
        private DataGridView dgvProducts;
        private ContextMenuStrip cmsGrid;
        private ToolStripMenuItem mnuXoaDong;
        private ToolStripMenuItem mnuLamMoi;
        private ToolStripSeparator mnuSep1;
        private ToolStripMenuItem mnuXemChiTiet;
        private Label lblTongKet;
        private ErrorProvider errorProvider;
    }
}
