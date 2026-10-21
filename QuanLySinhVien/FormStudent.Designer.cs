namespace QuanLySinhVien
{
    partial class FormStudent
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
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblAvatar = new Label();
            picAvatar = new PictureBox();
            btnChonAnh = new Button();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            btnXuatCsv = new Button();
            lblGoiY = new Label();
            grpDanhSach = new GroupBox();
            dgvStudents = new DataGridView();
            cmsGrid = new ContextMenuStrip(components);
            mnuXoaDong = new ToolStripMenuItem();
            mnuLamMoi = new ToolStripMenuItem();
            mnuSep1 = new ToolStripSeparator();
            mnuXemChiTiet = new ToolStripMenuItem();
            pnlNapDuLieu = new Panel();
            btnNapDuLieu = new Button();
            prgNapDuLieu = new ProgressBar();
            lblPhanTram = new Label();
            errorProvider = new ErrorProvider(components);
            grpNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            cmsGrid.SuspendLayout();
            pnlNapDuLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            //
            // grpNhapLieu
            //
            grpNhapLieu.Controls.Add(lblStudentId);
            grpNhapLieu.Controls.Add(txtStudentId);
            grpNhapLieu.Controls.Add(lblFullName);
            grpNhapLieu.Controls.Add(txtFullName);
            grpNhapLieu.Controls.Add(lblAge);
            grpNhapLieu.Controls.Add(txtAge);
            grpNhapLieu.Controls.Add(lblGender);
            grpNhapLieu.Controls.Add(cboGender);
            grpNhapLieu.Controls.Add(lblAvatar);
            grpNhapLieu.Controls.Add(picAvatar);
            grpNhapLieu.Controls.Add(btnChonAnh);
            grpNhapLieu.Controls.Add(btnThem);
            grpNhapLieu.Controls.Add(btnCapNhat);
            grpNhapLieu.Controls.Add(btnXoa);
            grpNhapLieu.Controls.Add(btnXuatCsv);
            grpNhapLieu.Controls.Add(lblGoiY);
            grpNhapLieu.Dock = DockStyle.Left;
            grpNhapLieu.Location = new Point(8, 8);
            grpNhapLieu.Name = "grpNhapLieu";
            grpNhapLieu.Size = new Size(330, 554);
            grpNhapLieu.TabIndex = 0;
            grpNhapLieu.TabStop = false;
            grpNhapLieu.Text = "Thông tin sinh viên";
            //
            // lblStudentId
            //
            lblStudentId.Location = new Point(15, 30);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(90, 23);
            lblStudentId.TabIndex = 20;
            lblStudentId.Text = "Mã SV:";
            lblStudentId.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtStudentId
            //
            txtStudentId.CharacterCasing = CharacterCasing.Upper;
            txtStudentId.Location = new Point(110, 30);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(200, 23);
            txtStudentId.TabIndex = 0;
            //
            // lblFullName
            //
            lblFullName.Location = new Point(15, 65);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(90, 23);
            lblFullName.TabIndex = 21;
            lblFullName.Text = "Họ tên:";
            lblFullName.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtFullName
            //
            txtFullName.Location = new Point(110, 65);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 23);
            txtFullName.TabIndex = 1;
            //
            // lblAge
            //
            lblAge.Location = new Point(15, 100);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(90, 23);
            lblAge.TabIndex = 22;
            lblAge.Text = "Tuổi:";
            lblAge.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtAge
            //
            txtAge.Location = new Point(110, 100);
            txtAge.MaxLength = 3;
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(200, 23);
            txtAge.TabIndex = 2;
            //
            // lblGender
            //
            lblGender.Location = new Point(15, 135);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(90, 23);
            lblGender.TabIndex = 23;
            lblGender.Text = "Giới tính:";
            lblGender.TextAlign = ContentAlignment.MiddleLeft;
            //
            // cboGender
            //
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(110, 135);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(200, 23);
            cboGender.TabIndex = 3;
            //
            // lblAvatar
            //
            lblAvatar.Location = new Point(15, 170);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(90, 23);
            lblAvatar.TabIndex = 24;
            lblAvatar.Text = "Ảnh đại diện:";
            lblAvatar.TextAlign = ContentAlignment.MiddleLeft;
            //
            // picAvatar
            //
            picAvatar.BackColor = Color.WhiteSmoke;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(110, 170);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(200, 170);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 25;
            picAvatar.TabStop = false;
            //
            // btnChonAnh
            //
            btnChonAnh.Location = new Point(110, 346);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(200, 28);
            btnChonAnh.TabIndex = 4;
            btnChonAnh.Text = "Chọn ảnh...";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            //
            // btnThem
            //
            btnThem.Location = new Point(15, 392);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(145, 36);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // btnCapNhat
            //
            btnCapNhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCapNhat.Location = new Point(165, 392);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(145, 36);
            btnCapNhat.TabIndex = 6;
            btnCapNhat.Text = "Cập nhật (Lưu)";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            //
            // btnXoa
            //
            btnXoa.ForeColor = Color.FromArgb(192, 0, 0);
            btnXoa.Location = new Point(15, 434);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(145, 36);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            //
            // btnXuatCsv
            //
            btnXuatCsv.Location = new Point(165, 434);
            btnXuatCsv.Name = "btnXuatCsv";
            btnXuatCsv.Size = new Size(145, 36);
            btnXuatCsv.TabIndex = 8;
            btnXuatCsv.Text = "Xuất file CSV";
            btnXuatCsv.UseVisualStyleBackColor = true;
            btnXuatCsv.Click += btnXuatCsv_Click;
            //
            // lblGoiY
            //
            lblGoiY.ForeColor = Color.DimGray;
            lblGoiY.Location = new Point(15, 482);
            lblGoiY.Name = "lblGoiY";
            lblGoiY.Size = new Size(300, 60);
            lblGoiY.TabIndex = 26;
            lblGoiY.Text = "Bấm \"Thêm\" để tạo dòng mới, nhập thông tin (bảng đổi theo ngay), rồi bấm \"Cập nhật (Lưu)\". Chuột phải vào bảng để Xóa / Làm mới / Xem chi tiết.";
            //
            // grpDanhSach
            //
            grpDanhSach.Controls.Add(dgvStudents);
            grpDanhSach.Controls.Add(pnlNapDuLieu);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Location = new Point(338, 8);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Padding = new Padding(8);
            grpDanhSach.Size = new Size(694, 554);
            grpDanhSach.TabIndex = 1;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách sinh viên";
            //
            // pnlNapDuLieu
            //
            pnlNapDuLieu.Controls.Add(btnNapDuLieu);
            pnlNapDuLieu.Controls.Add(prgNapDuLieu);
            pnlNapDuLieu.Controls.Add(lblPhanTram);
            pnlNapDuLieu.Dock = DockStyle.Top;
            pnlNapDuLieu.Location = new Point(8, 24);
            pnlNapDuLieu.Name = "pnlNapDuLieu";
            pnlNapDuLieu.Size = new Size(678, 44);
            pnlNapDuLieu.TabIndex = 0;
            //
            // btnNapDuLieu
            //
            btnNapDuLieu.Location = new Point(0, 6);
            btnNapDuLieu.Name = "btnNapDuLieu";
            btnNapDuLieu.Size = new Size(200, 32);
            btnNapDuLieu.TabIndex = 0;
            btnNapDuLieu.Text = "Nạp dữ liệu (Async)";
            btnNapDuLieu.UseVisualStyleBackColor = true;
            btnNapDuLieu.Click += btnNapDuLieu_Click;
            //
            // prgNapDuLieu
            //
            prgNapDuLieu.Location = new Point(212, 11);
            prgNapDuLieu.Name = "prgNapDuLieu";
            prgNapDuLieu.Size = new Size(300, 22);
            prgNapDuLieu.TabIndex = 1;
            //
            // lblPhanTram
            //
            lblPhanTram.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhanTram.Location = new Point(520, 11);
            lblPhanTram.Name = "lblPhanTram";
            lblPhanTram.Size = new Size(60, 22);
            lblPhanTram.TabIndex = 2;
            lblPhanTram.Text = "0%";
            lblPhanTram.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dgvStudents  (các cột được tạo bằng code)
            //
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.ContextMenuStrip = cmsGrid;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(8, 68);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(678, 478);
            dgvStudents.TabIndex = 1;
            dgvStudents.CellMouseDown += dgvStudents_CellMouseDown;
            //
            // cmsGrid  (menu chuột phải trên bảng)
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
            mnuXoaDong.Click += btnXoa_Click;
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
            // errorProvider
            //
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            //
            // FormStudent
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1040, 570);
            Controls.Add(grpDanhSach);
            Controls.Add(grpNhapLieu);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 600);
            Name = "FormStudent";
            Padding = new Padding(8);
            Text = "Quản lý Sinh viên";
            FormClosing += FormStudent_FormClosing;
            Load += FormStudent_Load;
            grpNhapLieu.ResumeLayout(false);
            grpNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            cmsGrid.ResumeLayout(false);
            pnlNapDuLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpNhapLieu;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblAge;
        private TextBox txtAge;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblAvatar;
        private PictureBox picAvatar;
        private Button btnChonAnh;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnXuatCsv;
        private Label lblGoiY;
        private GroupBox grpDanhSach;
        private DataGridView dgvStudents;
        private ContextMenuStrip cmsGrid;
        private ToolStripMenuItem mnuXoaDong;
        private ToolStripMenuItem mnuLamMoi;
        private ToolStripSeparator mnuSep1;
        private ToolStripMenuItem mnuXemChiTiet;
        private Panel pnlNapDuLieu;
        private Button btnNapDuLieu;
        private ProgressBar prgNapDuLieu;
        private Label lblPhanTram;
        private ErrorProvider errorProvider;
    }
}
