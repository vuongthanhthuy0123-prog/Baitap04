using System.ComponentModel;
using System.Globalization;

namespace QuanLySinhVien
{
    public partial class FormProduct : Form
    {
        private readonly BindingList<Product> dsSanPham = new BindingList<Product>();
        private readonly BindingSource bsSanPham = new BindingSource();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        public FormProduct()
        {
            InitializeComponent();
        }

        private FormMain FormCha
        {
            get { return MdiParent as FormMain; }
        }

        private void GuiThongBao(string noiDung)
        {
            if (FormCha != null) FormCha.HienThongBao(noiDung);
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProducts.Font, FontStyle.Bold);

            dgvProducts.Columns.Add(TaoCot("Mã SP", "ProductId", 14, DataGridViewContentAlignment.MiddleCenter, null));
            dgvProducts.Columns.Add(TaoCot("Tên sản phẩm", "ProductName", 38, DataGridViewContentAlignment.MiddleLeft, null));
            dgvProducts.Columns.Add(TaoCot("Đơn giá", "Price", 16, DataGridViewContentAlignment.MiddleRight, "N0"));
            dgvProducts.Columns.Add(TaoCot("SL", "Quantity", 10, DataGridViewContentAlignment.MiddleCenter, "N0"));
            dgvProducts.Columns.Add(TaoCot("Thành tiền", "TotalValue", 18, DataGridViewContentAlignment.MiddleRight, "N0"));

            bsSanPham.DataSource = dsSanPham;
            bsSanPham.ListChanged += (s, ev) => CapNhatTongKet();
            dgvProducts.DataSource = bsSanPham;
            CapNhatTongKet();
        }

        private DataGridViewTextBoxColumn TaoCot(string tieuDe, string thuocTinh, float tyLe,
                                                 DataGridViewContentAlignment canLe, string dinhDang)
        {
            DataGridViewTextBoxColumn cot = new DataGridViewTextBoxColumn();
            cot.HeaderText = tieuDe;
            cot.DataPropertyName = thuocTinh;
            cot.FillWeight = tyLe;
            cot.SortMode = DataGridViewColumnSortMode.NotSortable;
            cot.DefaultCellStyle.Alignment = canLe;
            if (dinhDang != null)
            {
                cot.DefaultCellStyle.Format = dinhDang;
                cot.DefaultCellStyle.FormatProvider = vi;
            }
            return cot;
        }

        private void CapNhatTongKet()
        {
            lblTongKet.Text = "Số sản phẩm: " + dsSanPham.Count +
                              "     |     Tổng giá trị: " + dsSanPham.Sum(x => x.TotalValue).ToString("N0", vi) + " đ";
        }

        // ===================== THÊM =====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool hopLe = true;

            if (txtTenSP.Text.Trim() == "")
            {
                errorProvider.SetError(txtTenSP, "Tên sản phẩm không được để trống.");
                hopLe = false;
            }

            decimal gia;
            string s = txtGia.Text.Trim().Replace(".", "").Replace(",", "");
            if (!decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out gia) || gia < 0)
            {
                errorProvider.SetError(txtGia, "Đơn giá phải là số và không âm.");
                hopLe = false;
            }
            if (!hopLe) return;

            Product sp = new Product();
            sp.ProductId = TaoMaMoi();
            sp.ProductName = txtTenSP.Text.Trim();
            sp.Price = gia;
            sp.Quantity = (int)numSoLuong.Value;
            dsSanPham.Add(sp);

            txtTenSP.Clear();
            txtGia.Clear();
            numSoLuong.Value = 0;
            txtTenSP.Focus();
            GuiThongBao("Thêm thành công sản phẩm " + sp.ProductId + " - " + sp.ProductName);
        }

        private string TaoMaMoi()
        {
            int max = 0;
            foreach (Product sp in dsSanPham)
            {
                int so;
                if (sp.ProductId.StartsWith("SP") && int.TryParse(sp.ProductId.Substring(2), out so) && so > max) max = so;
            }
            return "SP" + (max + 1).ToString("000");
        }

        // ===================== CONTEXT MENU =====================
        private void dgvProducts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[Math.Max(0, e.ColumnIndex)];
        }

        private void mnuXoaDong_Click(object sender, EventArgs e)
        {
            Product sp = bsSanPham.Current as Product;
            if (sp == null) return;
            if (MessageBox.Show("Xóa sản phẩm " + sp.ProductId + " - " + sp.ProductName + "?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            bsSanPham.RemoveCurrent();
            GuiThongBao("Xóa thành công sản phẩm " + sp.ProductId);
        }

        private void mnuLamMoi_Click(object sender, EventArgs e)
        {
            bsSanPham.ResetBindings(false);
            GuiThongBao("Đã làm mới danh sách sản phẩm (" + dsSanPham.Count + " sản phẩm)");
        }

        private void mnuXemChiTiet_Click(object sender, EventArgs e)
        {
            Product sp = bsSanPham.Current as Product;
            if (sp == null) return;
            MessageBox.Show(
                "Mã SP: " + sp.ProductId + "\n" +
                "Tên: " + sp.ProductName + "\n" +
                "Đơn giá: " + sp.Price.ToString("N0", vi) + " đ\n" +
                "Số lượng: " + sp.Quantity + "\n" +
                "Thành tiền: " + sp.TotalValue.ToString("N0", vi) + " đ",
                "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===================== BÀI 4.8: NẠP DỮ LIỆU BẤT ĐỒNG BỘ =====================
        private async void btnNapDuLieu_Click(object sender, EventArgs e)
        {
            if (dsSanPham.Count > 0 &&
                MessageBox.Show("Nạp dữ liệu sẽ thay thế danh sách hiện tại. Tiếp tục?", "Nạp dữ liệu",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            FormMain cha = FormCha;
            btnNapDuLieu.Enabled = false;
            prgNapDuLieu.Value = 0;
            lblPhanTram.Text = "0%";
            if (cha != null) cha.BatDauTienTrinh("Đang nạp danh sách sản phẩm...");

            Progress<int> tienTrinh = new Progress<int>(phanTram =>
            {
                if (IsDisposed) return;
                prgNapDuLieu.Value = phanTram;
                lblPhanTram.Text = phanTram + "%";
                if (cha != null) cha.CapNhatTienTrinh(phanTram);
            });

            try
            {
                List<Product> ketQua = await NapDanhSachSanPhamAsync(tienTrinh);
                if (IsDisposed) return;

                dsSanPham.RaiseListChangedEvents = false;
                dsSanPham.Clear();
                foreach (Product sp in ketQua) dsSanPham.Add(sp);
                dsSanPham.RaiseListChangedEvents = true;
                bsSanPham.ResetBindings(false);

                if (cha != null) cha.HienThongBao("Nạp xong " + ketQua.Count + " sản phẩm");
                MessageBox.Show("Đã nạp xong " + ketQua.Count + " sản phẩm.", "Hoàn tất",
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
                if (!IsDisposed) btnNapDuLieu.Enabled = true;
                if (cha != null && !cha.IsDisposed) cha.KetThucTienTrinh();
            }
        }

        // Giả lập nạp dữ liệu lớn: chạy trên Thread phụ
        private async Task<List<Product>> NapDanhSachSanPhamAsync(IProgress<int> tienTrinh)
        {
            return await Task.Run(() =>
            {
                string[] ten = { "Bút bi Thiên Long", "Vở ô ly 96 trang", "Thước kẻ 30cm", "Balo sinh viên", "Máy tính Casio FX-580",
                                 "Bình nước 500ml", "Sổ tay A5", "Bút dạ quang", "USB 32GB", "Tai nghe có dây",
                                 "Chuột không dây", "Giấy A4 Double A", "Bìa hồ sơ", "Kẹp giấy", "Đèn bàn LED" };
                Random rnd = new Random();
                List<Product> ds = new List<Product>();

                for (int i = 0; i < ten.Length; i++)
                {
                    Thread.Sleep(200);   // 15 x 200ms = 3 giây

                    Product sp = new Product();
                    sp.ProductId = "SP" + (i + 1).ToString("000");
                    sp.ProductName = ten[i];
                    sp.Price = rnd.Next(5, 500) * 1000m;
                    sp.Quantity = rnd.Next(1, 200);
                    ds.Add(sp);

                    tienTrinh.Report((i + 1) * 100 / ten.Length);
                }
                return ds;
            });
        }
    }
}
