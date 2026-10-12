namespace CAU1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkConKinhDoanh = new System.Windows.Forms.CheckBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.numGiaBan = new System.Windows.Forms.NumericUpDown();
            this.cboDonVi = new System.Windows.Forms.ComboBox();
            this.cboLoaiHang = new System.Windows.Forms.ComboBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLocConKinhDoanh = new System.Windows.Forms.CheckBox();
            this.cboLocLoaiHang = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemBangGia = new System.Windows.Forms.Button();
            this.btnXuatPDF = new System.Windows.Forms.Button();
            this.btnXuatExcelLuoi = new System.Windows.Forms.Button();
            this.btnXuatExcelTonKho = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkConKinhDoanh);
            this.groupBox1.Controls.Add(this.dtpNgayNhap);
            this.groupBox1.Controls.Add(this.numSoLuongTon);
            this.groupBox1.Controls.Add(this.numGiaBan);
            this.groupBox1.Controls.Add(this.cboDonVi);
            this.groupBox1.Controls.Add(this.cboLoaiHang);
            this.groupBox1.Controls.Add(this.txtTenHang);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hàng hóa";
            // 
            // chkConKinhDoanh
            // 
            this.chkConKinhDoanh.AutoSize = true;
            this.chkConKinhDoanh.Checked = true;
            this.chkConKinhDoanh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConKinhDoanh.Location = new System.Drawing.Point(350, 112);
            this.chkConKinhDoanh.Name = "chkConKinhDoanh";
            this.chkConKinhDoanh.Size = new System.Drawing.Size(126, 20);
            this.chkConKinhDoanh.TabIndex = 12;
            this.chkConKinhDoanh.Text = "Còn kinh doanh";
            this.chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(350, 82);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(180, 22);
            this.dtpNgayNhap.TabIndex = 11;
            // 
            // numSoLuongTon
            // 
            this.numSoLuongTon.Location = new System.Drawing.Point(350, 52);
            this.numSoLuongTon.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numSoLuongTon.Name = "numSoLuongTon";
            this.numSoLuongTon.Size = new System.Drawing.Size(180, 22);
            this.numSoLuongTon.TabIndex = 10;
            // 
            // numGiaBan
            // 
            this.numGiaBan.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            this.numGiaBan.Location = new System.Drawing.Point(85, 112);
            this.numGiaBan.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiaBan.Name = "numGiaBan";
            this.numGiaBan.Size = new System.Drawing.Size(150, 22);
            this.numGiaBan.TabIndex = 9;
            // 
            // cboDonVi
            // 
            this.cboDonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonVi.FormattingEnabled = true;
            this.cboDonVi.Location = new System.Drawing.Point(85, 82);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Size = new System.Drawing.Size(150, 24);
            this.cboDonVi.TabIndex = 8;
            // 
            // cboLoaiHang
            // 
            this.cboLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHang.FormattingEnabled = true;
            this.cboLoaiHang.Location = new System.Drawing.Point(85, 52);
            this.cboLoaiHang.Name = "cboLoaiHang";
            this.cboLoaiHang.Size = new System.Drawing.Size(150, 24);
            this.cboLoaiHang.TabIndex = 7;
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(85, 22);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(445, 22);
            this.txtTenHang.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày nhập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng tồn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá bán:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn vị:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên hàng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLocConKinhDoanh);
            this.groupBox2.Controls.Add(this.cboLocLoaiHang);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Location = new System.Drawing.Point(580, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // chkLocConKinhDoanh
            // 
            this.chkLocConKinhDoanh.AutoSize = true;
            this.chkLocConKinhDoanh.Location = new System.Drawing.Point(15, 95);
            this.chkLocConKinhDoanh.Name = "chkLocConKinhDoanh";
            this.chkLocConKinhDoanh.Size = new System.Drawing.Size(193, 20);
            this.chkLocConKinhDoanh.TabIndex = 2;
            this.chkLocConKinhDoanh.Text = "Chỉ hiện hàng còn kinh doanh";
            this.chkLocConKinhDoanh.UseVisualStyleBackColor = true;
            this.chkLocConKinhDoanh.CheckedChanged += new System.EventHandler(this.chkLocConKinhDoanh_CheckedChanged);
            // 
            // cboLocLoaiHang
            // 
            this.cboLocLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiHang.FormattingEnabled = true;
            this.cboLocLoaiHang.Location = new System.Drawing.Point(15, 55);
            this.cboLocLoaiHang.Name = "cboLocLoaiHang";
            this.cboLocLoaiHang.Size = new System.Drawing.Size(360, 24);
            this.cboLocLoaiHang.TabIndex = 1;
            this.cboLocLoaiHang.SelectedIndexChanged += new System.EventHandler(this.cboLocLoaiHang_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(15, 25);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(360, 22);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AllowUserToAddRows = false;
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Location = new System.Drawing.Point(12, 160);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.RowHeadersWidth = 51;
            this.dgvHangHoa.RowTemplate.Height = 24;
            this.dgvHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangHoa.Size = new System.Drawing.Size(958, 300);
            this.dgvHangHoa.TabIndex = 2;
            this.dgvHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 470);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(98, 470);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(184, 470);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(270, 470);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(80, 30);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXemBangGia
            // 
            this.btnXemBangGia.Location = new System.Drawing.Point(420, 470);
            this.btnXemBangGia.Name = "btnXemBangGia";
            this.btnXemBangGia.Size = new System.Drawing.Size(120, 30);
            this.btnXemBangGia.TabIndex = 7;
            this.btnXemBangGia.Text = "Xem bảng giá";
            this.btnXemBangGia.UseVisualStyleBackColor = true;
            this.btnXemBangGia.Click += new System.EventHandler(this.btnXemBangGia_Click);
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.Location = new System.Drawing.Point(546, 470);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(100, 30);
            this.btnXuatPDF.TabIndex = 8;
            this.btnXuatPDF.Text = "Xuất PDF";
            this.btnXuatPDF.UseVisualStyleBackColor = true;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // btnXuatExcelLuoi
            // 
            this.btnXuatExcelLuoi.Location = new System.Drawing.Point(652, 470);
            this.btnXuatExcelLuoi.Name = "btnXuatExcelLuoi";
            this.btnXuatExcelLuoi.Size = new System.Drawing.Size(150, 30);
            this.btnXuatExcelLuoi.TabIndex = 9;
            this.btnXuatExcelLuoi.Text = "Xuất Excel (lưới)";
            this.btnXuatExcelLuoi.UseVisualStyleBackColor = true;
            this.btnXuatExcelLuoi.Click += new System.EventHandler(this.btnXuatExcelLuoi_Click);
            // 
            // btnXuatExcelTonKho
            // 
            this.btnXuatExcelTonKho.Location = new System.Drawing.Point(808, 470);
            this.btnXuatExcelTonKho.Name = "btnXuatExcelTonKho";
            this.btnXuatExcelTonKho.Size = new System.Drawing.Size(162, 30);
            this.btnXuatExcelTonKho.TabIndex = 10;
            this.btnXuatExcelTonKho.Text = "Xuất Excel tồn kho";
            this.btnXuatExcelTonKho.UseVisualStyleBackColor = true;
            this.btnXuatExcelTonKho.Click += new System.EventHandler(this.btnXuatExcelTonKho_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(12, 510);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(130, 16);
            this.lblTrangThai.TabIndex = 11;
            this.lblTrangThai.Text = "Tìm thấy 0 mặt hàng";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 535);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnXuatExcelTonKho);
            this.Controls.Add(this.btnXuatExcelLuoi);
            this.Controls.Add(this.btnXuatPDF);
            this.Controls.Add(this.btnXemBangGia);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHangHoa);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hàng hóa - Tạp hóa UTC2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.NumericUpDown numSoLuongTon;
        private System.Windows.Forms.NumericUpDown numGiaBan;
        private System.Windows.Forms.ComboBox cboDonVi;
        private System.Windows.Forms.ComboBox cboLoaiHang;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkLocConKinhDoanh;
        private System.Windows.Forms.ComboBox cboLocLoaiHang;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemBangGia;
        private System.Windows.Forms.Button btnXuatPDF;
        private System.Windows.Forms.Button btnXuatExcelLuoi;
        private System.Windows.Forms.Button btnXuatExcelTonKho;
        private System.Windows.Forms.Label lblTrangThai;
    }
}