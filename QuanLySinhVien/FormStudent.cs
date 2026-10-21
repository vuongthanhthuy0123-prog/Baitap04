using System.ComponentModel;
using System.Text;

namespace QuanLySinhVien
{
    public partial class FormStudent : Form
    {
        // BindingList<Student>  --->  BindingSource (trung gian)  --->  DataGridView + các ô nhập
        private readonly BindingList<Student> dsSinhVien = new BindingList<Student>();
        private readonly BindingSource bsSinhVien = new BindingSource();

        private Student dangThemMoi;   // sinh viên vừa bấm "Thêm", chưa bấm Lưu
        private Student svTruoc;       // dòng được chọn trước đó (để dọn dòng trống)

        public FormStudent()
        {
            InitializeComponent();
        }

        // Form cha MDI (null nếu Form chạy độc lập)
        private FormMain FormCha
        {
            get { return MdiParent as FormMain; }
        }

        // Gửi thông điệp lên StatusStrip của Form cha
        private void GuiThongBao(string noiDung)
        {
            if (FormCha != null) FormCha.HienThongBao(noiDung);
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();

            bsSinhVien.DataSource = dsSinhVien;
            bsSinhVien.CurrentChanged += bsSinhVien_CurrentChanged;
            bsSinhVien.ListChanged += (s, ev) => CapNhatTrangThaiONhap();
            dgvStudents.DataSource = bsSinhVien;

            RangBuocDuLieu();
            CapNhatTrangThaiONhap();
        }

        // ===================== CẤU HÌNH LƯỚI =====================
        private void CauHinhLuoi()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AllowUserToResizeRows = false;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font(dgvStudents.Font, FontStyle.Bold);
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);

            dgvStudents.Columns.Add(TaoCot("Mã SV", "StudentId", 15, DataGridViewContentAlignment.MiddleCenter));
            dgvStudents.Columns.Add(TaoCot("Họ tên", "FullName", 35, DataGridViewContentAlignment.MiddleLeft));
            dgvStudents.Columns.Add(TaoCot("Tuổi", "Age", 10, DataGridViewContentAlignment.MiddleCenter));
            dgvStudents.Columns.Add(TaoCot("Giới tính", "Gender", 13, DataGridViewContentAlignment.MiddleCenter));
            dgvStudents.Columns.Add(TaoCot("Ảnh đại diện", "AvatarName", 27, DataGridViewContentAlignment.MiddleLeft));
        }

        private static DataGridViewTextBoxColumn TaoCot(string tieuDe, string thuocTinh, float tyLe, DataGridViewContentAlignment canLe)
        {
            DataGridViewTextBoxColumn cot = new DataGridViewTextBoxColumn();
            cot.HeaderText = tieuDe;
            cot.DataPropertyName = thuocTinh;
            cot.FillWeight = tyLe;
            cot.SortMode = DataGridViewColumnSortMode.NotSortable;
            cot.DefaultCellStyle.Alignment = canLe;
            return cot;
        }

        // ===================== DATA BINDING 2 CHIỀU (DataBindings.Add) =====================
        // OnPropertyChanged: gõ tới đâu, dòng đang chọn trên lưới đổi tới đó (Control -> Dữ liệu)
        // Chọn dòng khác trên lưới: các ô nhập tự đổi theo (Dữ liệu -> Control)
        private void RangBuocDuLieu()
        {
            txtStudentId.DataBindings.Add("Text", bsSinhVien, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bsSinhVien, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);

            // Tuổi: chỉ ghi xuống khi rời ô (tránh lỗi khi đang gõ dở); tuổi = 0 thì hiện ô trống
            Binding bTuoi = new Binding("Text", bsSinhVien, "Age", true, DataSourceUpdateMode.OnValidation);
            bTuoi.Format += (s, e) => { if (e.Value is int && (int)e.Value == 0) e.Value = ""; };
            bTuoi.Parse += (s, e) =>
            {
                int tuoi;
                string chu = (e.Value ?? "").ToString().Trim();
                if (int.TryParse(chu, out tuoi))
                {
                    e.Value = tuoi;
                    errorProvider.SetError(txtAge, "");
                }
                else
                {
                    // Gõ sai thì giữ nguyên tuổi cũ, không ghi đè thành 0
                    Student hienTai = bsSinhVien.Current as Student;
                    e.Value = hienTai != null ? hienTai.Age : 0;
                    if (chu != "") errorProvider.SetError(txtAge, "Tuổi phải là số.");
                }
            };
            txtAge.DataBindings.Add(bTuoi);

            // Giới tính: giá trị không phải Nam/Nữ (sinh viên mới) thì để ComboBox trống
            Binding bGioiTinh = new Binding("SelectedItem", bsSinhVien, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            bGioiTinh.Format += (s, e) =>
            {
                string g = e.Value as string;
                if (g == null || !cboGender.Items.Contains(g)) e.Value = null;
            };
            bGioiTinh.Parse += (s, e) => { e.Value = e.Value == null ? "" : e.Value.ToString(); };
            cboGender.DataBindings.Add(bGioiTinh);

            // ComboBox không có sự kiện SelectedItemChanged -> chọn xong là tự ghi xuống luôn
            cboGender.SelectionChangeCommitted += (s, e) => bGioiTinh.WriteValue();
        }

        // Đổi dòng đang chọn -> nạp ảnh của sinh viên đó lên PictureBox
        private void bsSinhVien_CurrentChanged(object sender, EventArgs e)
        {
            Student sv = bsSinhVien.Current as Student;

            // Bỏ dòng mới thêm nhưng chưa nhập gì
            if (svTruoc != null && svTruoc != sv && LaDongTrong(svTruoc) && dsSinhVien.Contains(svTruoc))
            {
                Student dongTrong = svTruoc;
                svTruoc = sv;
                if (dangThemMoi == dongTrong) dangThemMoi = null;
                BeginInvoke(new Action(() => dsSinhVien.Remove(dongTrong)));
            }
            svTruoc = sv;

            errorProvider.Clear();
            HienAnh(sv == null ? "" : sv.AvatarPath);
        }

        private static bool LaDongTrong(Student sv)
        {
            return string.IsNullOrWhiteSpace(sv.StudentId) && string.IsNullOrWhiteSpace(sv.FullName);
        }

        // Khi chưa có sinh viên nào thì khóa ô nhập (phải bấm Thêm trước)
        private void CapNhatTrangThaiONhap()
        {
            bool coDong = bsSinhVien.Current != null;
            foreach (Control c in new Control[] { txtStudentId, txtFullName, txtAge, cboGender, btnChonAnh, btnCapNhat, btnXoa })
                c.Enabled = coDong;
            btnXuatCsv.Enabled = dsSinhVien.Count > 0;

            if (!coDong)
            {
                txtStudentId.Text = "";
                txtFullName.Text = "";
                txtAge.Text = "";
                cboGender.SelectedIndex = -1;
                HienAnh("");
            }
        }

        // ===================== ẢNH ĐẠI DIỆN (OpenFileDialog) =====================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            Student sv = bsSinhVien.Current as Student;
            if (sv == null) return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Hình ảnh (*.jpg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                sv.AvatarPath = ofd.FileName;     // gán đường dẫn vào sinh viên đang chọn
                HienAnh(sv.AvatarPath);
                GuiThongBao("Đã chọn ảnh cho sinh viên " + sv.StudentId);
            }
        }

        private void HienAnh(string duongDan)
        {
            Image anhCu = picAvatar.Image;
            picAvatar.Image = null;
            if (anhCu != null) anhCu.Dispose();

            if (string.IsNullOrEmpty(duongDan) || !File.Exists(duongDan)) return;
            try
            {
                // Đọc qua MemoryStream để không khóa file ảnh gốc
                picAvatar.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(duongDan)));
            }
            catch (Exception)
            {
                picAvatar.Image = null;
            }
        }

        // ===================== THÊM / CẬP NHẬT / XÓA =====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dangThemMoi != null && dsSinhVien.Contains(dangThemMoi))
            {
                MessageBox.Show("Bạn đang thêm 1 sinh viên, hãy nhập xong và bấm \"Cập nhật (Lưu)\" trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStudentId.Focus();
                return;
            }

            bsSinhVien.EndEdit();
            dangThemMoi = (Student)bsSinhVien.AddNew();   // tạo 1 dòng trống mới trên lưới
            bsSinhVien.EndEdit();
            bsSinhVien.Position = bsSinhVien.IndexOf(dangThemMoi);   // chọn đúng dòng mới
            CapNhatTrangThaiONhap();
            errorProvider.Clear();
            txtStudentId.Focus();
            GuiThongBao("Đang thêm sinh viên mới...");
        }

        // Kiểm tra dữ liệu trên các ô nhập của dòng đang chọn
        private bool KiemTraHopLe(Student sv)
        {
            errorProvider.Clear();
            bool hopLe = true;

            string ma = txtStudentId.Text.Trim();
            if (ma == "")
            {
                errorProvider.SetError(txtStudentId, "Mã SV không được để trống.");
                hopLe = false;
            }
            else if (dsSinhVien.Any(x => x != sv && string.Equals(x.StudentId.Trim(), ma, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(txtStudentId, "Mã SV \"" + ma + "\" đã tồn tại.");
                hopLe = false;
            }

            if (txtFullName.Text.Trim() == "")
            {
                errorProvider.SetError(txtFullName, "Họ tên không được để trống.");
                hopLe = false;
            }

            int tuoi;
            if (!int.TryParse(txtAge.Text.Trim(), out tuoi) || tuoi < 15 || tuoi > 100)
            {
                errorProvider.SetError(txtAge, "Tuổi phải là số từ 15 đến 100.");
                hopLe = false;
            }

            if (cboGender.SelectedIndex < 0)
            {
                errorProvider.SetError(cboGender, "Vui lòng chọn giới tính.");
                hopLe = false;
            }
            return hopLe;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Student sv = bsSinhVien.Current as Student;
            if (sv == null) return;
            if (!KiemTraHopLe(sv)) return;

            // Đảm bảo mọi giá trị trên ô nhập đã được ghi xuống đối tượng
            foreach (Control c in new Control[] { txtStudentId, txtFullName, txtAge, cboGender })
                foreach (Binding b in c.DataBindings) b.WriteValue();
            sv.StudentId = sv.StudentId.Trim();
            sv.FullName = sv.FullName.Trim();
            bsSinhVien.EndEdit();
            bsSinhVien.ResetCurrentItem();

            if (sv == dangThemMoi)
            {
                dangThemMoi = null;
                GuiThongBao("Thêm thành công sinh viên " + sv.StudentId + " - " + sv.FullName);
                MessageBox.Show("Đã thêm sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GuiThongBao("Cập nhật thành công sinh viên " + sv.StudentId);
                MessageBox.Show("Đã cập nhật thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Student sv = bsSinhVien.Current as Student;
            if (sv == null)
            {
                MessageBox.Show("Chưa có sinh viên nào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ten = LaDongTrong(sv) ? "(dòng mới chưa nhập)" : sv.StudentId + " - " + sv.FullName;
            if (MessageBox.Show("Xóa sinh viên " + ten + "?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (sv == dangThemMoi) dangThemMoi = null;
            svTruoc = null;
            bsSinhVien.RemoveCurrent();
            GuiThongBao("Xóa thành công sinh viên " + ten);
        }

        // ===================== XUẤT CSV (SaveFileDialog) =====================
        private void btnXuatCsv_Click(object sender, EventArgs e)
        {
            bsSinhVien.EndEdit();
            List<Student> ds = dsSinhVien.Where(x => !LaDongTrong(x)).ToList();
            if (ds.Count == 0)
            {
                MessageBox.Show("Chưa có sinh viên nào để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách sinh viên";
                sfd.Filter = "File CSV (*.csv)|*.csv";
                sfd.FileName = "DanhSachSinhVien_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
                if (sfd.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("MaSV;HoTen;Tuoi;GioiTinh;DuongDanAnh");
                    foreach (Student sv in ds)
                        sb.AppendLine(string.Join(";", BocCsv(sv.StudentId), BocCsv(sv.FullName), sv.Age.ToString(),
                                                       BocCsv(sv.Gender), BocCsv(sv.AvatarPath)));

                    // UTF-8 có BOM để Excel đọc đúng tiếng Việt
                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                    GuiThongBao("Đã xuất " + ds.Count + " sinh viên ra file " + Path.GetFileName(sfd.FileName));
                    MessageBox.Show("Đã xuất " + ds.Count + " sinh viên ra file:\n" + sfd.FileName, "Xuất CSV",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không ghi được file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Dữ liệu có chứa dấu ; , hoặc " thì bọc trong ngoặc kép (chuẩn CSV)
        private static string BocCsv(string s)
        {
            s = s ?? "";
            if (s.IndexOfAny(new[] { ';', ',', '"', '\n', '\r' }) >= 0)
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        // ===================== CONTEXT MENU (chuột phải trên lưới) =====================
        // Chuột phải vào dòng nào thì chọn dòng đó trước khi hiện menu
        private void dgvStudents_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                dgvStudents.CurrentCell = dgvStudents.Rows[e.RowIndex].Cells[Math.Max(0, e.ColumnIndex)];
        }

        private void mnuLamMoi_Click(object sender, EventArgs e)
        {
            bsSinhVien.EndEdit();
            foreach (Student sv in dsSinhVien.Where(LaDongTrong).ToList()) dsSinhVien.Remove(sv);
            dangThemMoi = null;
            bsSinhVien.ResetBindings(false);
            errorProvider.Clear();
            GuiThongBao("Đã làm mới danh sách sinh viên (" + dsSinhVien.Count + " sinh viên)");
        }

        private void mnuXemChiTiet_Click(object sender, EventArgs e)
        {
            Student sv = bsSinhVien.Current as Student;
            if (sv == null) return;

            MessageBox.Show(
                "Mã SV: " + sv.StudentId + "\n" +
                "Họ tên: " + sv.FullName + "\n" +
                "Tuổi: " + (sv.Age > 0 ? sv.Age.ToString() : "") + "\n" +
                "Giới tính: " + sv.Gender + "\n" +
                "Ảnh: " + (sv.AvatarPath == "" ? "(chưa có)" : sv.AvatarPath),
                "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===================== BÀI 4.8: NẠP DỮ LIỆU BẤT ĐỒNG BỘ =====================
        private async void btnNapDuLieu_Click(object sender, EventArgs e)
        {
            if (dsSinhVien.Count > 0 &&
                MessageBox.Show("Nạp dữ liệu sẽ thay thế danh sách hiện tại. Tiếp tục?", "Nạp dữ liệu",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            FormMain cha = FormCha;          // giữ tham chiếu (Form con có thể bị đóng trong lúc chờ)
            btnNapDuLieu.Enabled = false;    // khóa nút, tránh bấm trùng
            prgNapDuLieu.Value = 0;
            lblPhanTram.Text = "0%";
            if (cha != null) cha.BatDauTienTrinh("Đang nạp danh sách sinh viên...");

            // Progress<int>: báo % từ tiến trình ngầm về UI Thread
            Progress<int> tienTrinh = new Progress<int>(phanTram =>
            {
                if (IsDisposed) return;
                prgNapDuLieu.Value = phanTram;
                lblPhanTram.Text = phanTram + "%";
                if (cha != null) cha.CapNhatTienTrinh(phanTram);
            });

            try
            {
                List<Student> ketQua = await NapDanhSachSinhVienAsync(tienTrinh);
                if (IsDisposed) return;

                dsSinhVien.RaiseListChangedEvents = false;
                dsSinhVien.Clear();
                foreach (Student sv in ketQua) dsSinhVien.Add(sv);
                dsSinhVien.RaiseListChangedEvents = true;
                dangThemMoi = null;
                svTruoc = null;
                bsSinhVien.ResetBindings(false);

                if (cha != null) cha.HienThongBao("Nạp xong " + ketQua.Count + " sinh viên");
                MessageBox.Show("Đã nạp xong " + ketQua.Count + " sinh viên.", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (cha != null && !cha.IsDisposed) cha.HienThongBao("Nạp dữ liệu thất bại");
                if (!IsDisposed)
                    MessageBox.Show("Lỗi khi nạp dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) btnNapDuLieu.Enabled = true;   // mở lại nút
                if (cha != null && !cha.IsDisposed) cha.KetThucTienTrinh();
            }
        }

        // Giả lập nạp danh sách lớn từ CSDL: chạy trên Thread phụ, KHÔNG đụng vào Control
        private async Task<List<Student>> NapDanhSachSinhVienAsync(IProgress<int> tienTrinh)
        {
            return await Task.Run(() =>
            {
                string[] ho = { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Vũ", "Đặng", "Bùi", "Đỗ", "Ngô" };
                string[] dem = { "Văn", "Thị", "Minh", "Thanh", "Quốc", "Ngọc", "Gia", "Hoài" };
                string[] ten = { "An", "Bình", "Châu", "Dũng", "Giang", "Hà", "Khánh", "Linh", "Nam", "Phương", "Quân", "Trang" };
                Random rnd = new Random();
                List<Student> ds = new List<Student>();
                const int TONG = 40;

                for (int i = 1; i <= TONG; i++)
                {
                    Thread.Sleep(75);   // giả lập đọc 1 bản ghi mất thời gian (40 x 75ms = 3 giây)

                    Student sv = new Student();
                    sv.StudentId = "SV" + i.ToString("000");
                    string d = dem[rnd.Next(dem.Length)];
                    sv.FullName = ho[rnd.Next(ho.Length)] + " " + d + " " + ten[rnd.Next(ten.Length)];
                    sv.Age = rnd.Next(18, 26);
                    sv.Gender = d == "Thị" || d == "Ngọc" ? "Nữ" : (d == "Văn" || d == "Quốc" ? "Nam" : (rnd.Next(2) == 0 ? "Nam" : "Nữ"));
                    ds.Add(sv);

                    tienTrinh.Report(i * 100 / TONG);
                }
                return ds;
            });
        }

        private void FormStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            bsSinhVien.CurrentChanged -= bsSinhVien_CurrentChanged;
        }
    }
}
