using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using FastReport;
using FastReport.Export.Pdf;
using Microsoft.EntityFrameworkCore;
using CAU1.Models; // Sử dụng thư mục Models từ project CAU1

namespace CAU1
{
    public partial class Form1 : Form
    {
        // Khởi tạo DbContext (không new trực tiếp ở đây nữa)
        private readonly TiemTapHoaContext _context;
        private System.Windows.Forms.Timer _searchTimer = new System.Windows.Forms.Timer();
        private int _currentMaHang = 0;

        // Cờ chống đụng độ đa luồng của DbContext
        private bool _isFetching = false;

        public Form1()
        {
            InitializeComponent();

            // Cấu hình chuỗi kết nối trực tiếp vào DbContext
            var optionsBuilder = new DbContextOptionsBuilder<TiemTapHoaContext>();
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-D5101UJQ;Database=TiemTapHoa;Trusted_Connection=True;TrustServerCertificate=True;");
            _context = new TiemTapHoaContext(optionsBuilder.Options);

            _searchTimer.Interval = 350;
            _searchTimer.Tick += SearchTimer_Tick;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string[] loaiHangs = { "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" };
            cboLoaiHang.Items.AddRange(loaiHangs);

            cboLocLoaiHang.Items.Add("Tất cả loại");
            cboLocLoaiHang.Items.AddRange(loaiHangs);
            cboLocLoaiHang.SelectedIndex = 0;

            string[] donVis = { "Chai", "Gói", "Hộp", "Túi" };
            cboDonVi.Items.AddRange(donVis);

            await LoadDataAsync();
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvHangHoa.Columns.Count > 0)
            {
                if (dgvHangHoa.Columns["GiaBan"] != null)
                    dgvHangHoa.Columns["GiaBan"].DefaultCellStyle.Format = "N0";

                if (dgvHangHoa.Columns["NgayNhap"] != null)
                    dgvHangHoa.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private async Task LoadDataAsync(string keyword = "", string loaiHang = "Tất cả loại", bool chiHienKinhDoanh = false)
        {
            // Ngăn chặn chạy đồng thời nhiều luồng truy vấn
            if (_isFetching) return;

            _isFetching = true;
            try
            {
                var query = _context.HangHoas.AsQueryable();

                if (!string.IsNullOrWhiteSpace(keyword))
                    query = query.Where(h => h.TenHang.Contains(keyword));

                if (!string.IsNullOrEmpty(loaiHang) && loaiHang != "Tất cả loại")
                    query = query.Where(h => h.LoaiHang == loaiHang);

                if (chiHienKinhDoanh)
                    query = query.Where(h => h.ConKinhDoanh == true);

                var data = await query.ToListAsync();
                dgvHangHoa.DataSource = data;

                lblTrangThai.Text = $"Tìm thấy {data.Count} mặt hàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isFetching = false;
            }
        }

        // ========================== SỰ KIỆN TÌM KIẾM ==========================

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private async void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            string loaiHang = cboLocLoaiHang.SelectedItem != null ? cboLocLoaiHang.SelectedItem.ToString() : "Tất cả loại";
            await LoadDataAsync(txtTimKiem.Text, loaiHang, chkLocConKinhDoanh.Checked);
        }

        private async void cboLocLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiHang = cboLocLoaiHang.SelectedItem != null ? cboLocLoaiHang.SelectedItem.ToString() : "Tất cả loại";
            await LoadDataAsync(txtTimKiem.Text, loaiHang, chkLocConKinhDoanh.Checked);
        }

        private async void chkLocConKinhDoanh_CheckedChanged(object sender, EventArgs e)
        {
            string loaiHang = cboLocLoaiHang.SelectedItem != null ? cboLocLoaiHang.SelectedItem.ToString() : "Tất cả loại";
            await LoadDataAsync(txtTimKiem.Text, loaiHang, chkLocConKinhDoanh.Checked);
        }

        // ========================== GIAO DIỆN & CRUD ==========================

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];
                if (row.Cells["MaHang"].Value != null)
                {
                    _currentMaHang = Convert.ToInt32(row.Cells["MaHang"].Value);
                    txtTenHang.Text = row.Cells["TenHang"].Value?.ToString();
                    cboLoaiHang.Text = row.Cells["LoaiHang"].Value?.ToString();
                    cboDonVi.Text = row.Cells["DonVi"].Value?.ToString();
                    numGiaBan.Value = Convert.ToDecimal(row.Cells["GiaBan"].Value ?? 0);
                    numSoLuongTon.Value = Convert.ToDecimal(row.Cells["SoLuongTon"].Value ?? 0);

                    if (row.Cells["NgayNhap"].Value != null)
                        dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);

                    chkConKinhDoanh.Checked = Convert.ToBoolean(row.Cells["ConKinhDoanh"].Value ?? false);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Tên hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numGiaBan.Value <= 0)
            {
                MessageBox.Show("Giá bán phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _currentMaHang = 0;
            txtTenHang.Clear();
            cboLoaiHang.SelectedIndex = -1;
            cboDonVi.SelectedIndex = -1;
            numGiaBan.Value = 0;
            numSoLuongTon.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var hangHoa = new HangHoa
                {
                    TenHang = txtTenHang.Text,
                    LoaiHang = cboLoaiHang.Text,
                    DonVi = cboDonVi.Text,
                    GiaBan = numGiaBan.Value,
                    SoLuongTon = (int)numSoLuongTon.Value,
                    NgayNhap = dtpNgayNhap.Value,
                    ConKinhDoanh = chkConKinhDoanh.Checked
                };

                _context.HangHoas.Add(hangHoa);
                await _context.SaveChangesAsync();
                await LoadDataAsync();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_currentMaHang == 0 || !ValidateInput()) return;

            try
            {
                var hangHoa = await _context.HangHoas.FindAsync(_currentMaHang);
                if (hangHoa != null)
                {
                    hangHoa.TenHang = txtTenHang.Text;
                    hangHoa.LoaiHang = cboLoaiHang.Text;
                    hangHoa.DonVi = cboDonVi.Text;
                    hangHoa.GiaBan = numGiaBan.Value;
                    hangHoa.SoLuongTon = (int)numSoLuongTon.Value;
                    hangHoa.NgayNhap = dtpNgayNhap.Value;
                    hangHoa.ConKinhDoanh = chkConKinhDoanh.Checked;

                    await _context.SaveChangesAsync();
                    await LoadDataAsync();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_currentMaHang == 0) return;

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var hangHoa = await _context.HangHoas.FindAsync(_currentMaHang);
                    if (hangHoa != null)
                    {
                        _context.HangHoas.Remove(hangHoa);
                        await _context.SaveChangesAsync();
                        await LoadDataAsync();
                        btnLamMoi_Click(sender, e);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========================== BÁO CÁO FASTREPORT ==========================

        private DataTable GetReportData()
        {
            var data = _context.HangHoas.Where(h => h.ConKinhDoanh == true).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("DonVi", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));

            foreach (var item in data)
            {
                dt.Rows.Add(item.TenHang, item.DonVi, item.GiaBan);
            }
            return dt;
        }

        private void btnXemBangGia_Click(object sender, EventArgs e)
        {
            try
            {
                Report report = new Report();
                report.Load(Path.Combine(Application.StartupPath, "Reports", "BangGia.frx"));
                DataTable dt = GetReportData();
                report.RegisterData(dt, "HangHoa");
                report.GetDataSource("HangHoa").Enabled = true;
                report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
                report.Design();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem Report (Vui lòng chép file BangGia.frx vào thư mục bin/Debug/net.../Reports): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF Files|*.pdf", FileName = "BangGia.pdf" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Report report = new Report();
                    report.Load(Path.Combine(Application.StartupPath, "Reports", "BangGia.frx"));
                    DataTable dt = GetReportData();
                    report.RegisterData(dt, "HangHoa");
                    report.GetDataSource("HangHoa").Enabled = true;
                    report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));

                    report.Prepare();

                    PDFExport export = new PDFExport();
                    report.Export(export, sfd.FileName);

                    if (MessageBox.Show("Xuất thành công! Bạn có muốn mở file không?", "Mở file", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================== XUẤT EXCEL CLOSEDXML ==========================

        private void btnXuatExcelLuoi_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Files|*.xlsx", FileName = "ExcelTuLuoi.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("DuLieuLuoi");
                        for (int i = 0; i < dgvHangHoa.Columns.Count; i++)
                        {
                            ws.Cell(1, i + 1).Value = dgvHangHoa.Columns[i].HeaderText;
                        }
                        for (int i = 0; i < dgvHangHoa.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvHangHoa.Columns.Count; j++)
                            {
                                var cellValue = dgvHangHoa.Rows[i].Cells[j].Value;
                                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal numVal))
                                    ws.Cell(i + 2, j + 1).Value = numVal;
                                else
                                    ws.Cell(i + 2, j + 1).Value = cellValue?.ToString();
                            }
                        }
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất Excel từ lưới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Lỗi: Đóng file Excel đang mở rồi thử lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXuatExcelTonKho_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Files|*.xlsx", FileName = "TonKho.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var data = await _context.HangHoas.Where(h => h.ConKinhDoanh == true).ToListAsync();

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("TonKho");
                        string[] headers = { "Mã Hàng", "Tên Hàng", "Loại", "Đơn Vị", "Giá Bán", "Số Lượng", "Giá Trị Tồn" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            ws.Cell(1, i + 1).Value = headers[i];
                            ws.Cell(1, i + 1).Style.Font.Bold = true;
                        }

                        int row = 2;
                        foreach (var item in data)
                        {
                            ws.Cell(row, 1).Value = item.MaHang;
                            ws.Cell(row, 2).Value = item.TenHang;
                            ws.Cell(row, 3).Value = item.LoaiHang;
                            ws.Cell(row, 4).Value = item.DonVi;
                            ws.Cell(row, 5).Value = item.GiaBan;
                            ws.Cell(row, 6).Value = item.SoLuongTon;
                            ws.Cell(row, 7).FormulaA1 = $"E{row}*F{row}";
                            row++;
                        }

                        ws.Cell(row, 6).Value = "Tổng:";
                        ws.Cell(row, 6).Style.Font.Bold = true;
                        ws.Cell(row, 7).FormulaA1 = $"SUM(G2:G{row - 1})";
                        ws.Cell(row, 7).Style.Font.Bold = true;

                        ws.RangeUsed().SetAutoFilter();
                        ws.SheetView.FreezeRows(1);
                        ws.Columns().AdjustToContents();

                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất Excel tồn kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Lỗi: Đóng file Excel đang mở rồi thử lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}