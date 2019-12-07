namespace EarthQuake
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cbxTinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxHuyen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNenDat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.llab = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkMatDungDD = new System.Windows.Forms.CheckBox();
            this.cbxHsQuanTrong = new System.Windows.Forms.ComboBox();
            this.cbxCapDeo = new System.Windows.Forms.ComboBox();
            this.cbxKetCau = new System.Windows.Forms.ComboBox();
            this.txtPhaHoaiKw = new System.Windows.Forms.TextBox();
            this.dgvThongSo = new System.Windows.Forms.DataGridView();
            this.thongSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radPPU = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChuKy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxDangDD = new System.Windows.Forms.ComboBox();
            this.cbxPhuong = new System.Windows.Forms.ComboBox();
            this.radPPUDaoDong = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mdbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tínhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tácGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKQ = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongSo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxTinh
            // 
            this.cbxTinh.FormattingEnabled = true;
            this.cbxTinh.Location = new System.Drawing.Point(192, 39);
            this.cbxTinh.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTinh.Name = "cbxTinh";
            this.cbxTinh.Size = new System.Drawing.Size(180, 26);
            this.cbxTinh.TabIndex = 0;
            this.cbxTinh.SelectedIndexChanged += new System.EventHandler(this.cbxTinh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tỉnh / Thành phố";
            // 
            // cbxHuyen
            // 
            this.cbxHuyen.FormattingEnabled = true;
            this.cbxHuyen.Location = new System.Drawing.Point(192, 79);
            this.cbxHuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cbxHuyen.Name = "cbxHuyen";
            this.cbxHuyen.Size = new System.Drawing.Size(180, 26);
            this.cbxHuyen.TabIndex = 0;
            this.cbxHuyen.SelectedIndexChanged += new System.EventHandler(this.cbxHuyen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quận /Huyện";
            // 
            // cbxNenDat
            // 
            this.cbxNenDat.FormattingEnabled = true;
            this.cbxNenDat.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.cbxNenDat.Location = new System.Drawing.Point(285, 116);
            this.cbxNenDat.Margin = new System.Windows.Forms.Padding(4);
            this.cbxNenDat.Name = "cbxNenDat";
            this.cbxNenDat.Size = new System.Drawing.Size(87, 26);
            this.cbxNenDat.TabIndex = 0;
            this.cbxNenDat.SelectedIndexChanged += new System.EventHandler(this.cbxNenDat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại nền đất";
            // 
            // llab
            // 
            this.llab.AutoSize = true;
            this.llab.Location = new System.Drawing.Point(137, 120);
            this.llab.Name = "llab";
            this.llab.Size = new System.Drawing.Size(37, 18);
            this.llab.TabIndex = 2;
            this.llab.TabStop = true;
            this.llab.Text = "SPT";
            this.llab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llab_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hệ số tầm quan trọng (gama1)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cấp dẻo của công trình";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 248);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Đặc điểm kết cấu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 286);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Hệ số phản ánh dạng phá hoại, kw";
            // 
            // chkMatDungDD
            // 
            this.chkMatDungDD.AutoSize = true;
            this.chkMatDungDD.Checked = true;
            this.chkMatDungDD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMatDungDD.Location = new System.Drawing.Point(12, 314);
            this.chkMatDungDD.Name = "chkMatDungDD";
            this.chkMatDungDD.Size = new System.Drawing.Size(249, 22);
            this.chkMatDungDD.TabIndex = 3;
            this.chkMatDungDD.Text = "Công trình đều đặn theo mặt đứng";
            this.chkMatDungDD.UseVisualStyleBackColor = true;
            this.chkMatDungDD.CheckedChanged += new System.EventHandler(this.chkMatDungDD_CheckedChanged);
            // 
            // cbxHsQuanTrong
            // 
            this.cbxHsQuanTrong.FormattingEnabled = true;
            this.cbxHsQuanTrong.Items.AddRange(new object[] {
            "0.75",
            "1",
            "1.25"});
            this.cbxHsQuanTrong.Location = new System.Drawing.Point(286, 163);
            this.cbxHsQuanTrong.Margin = new System.Windows.Forms.Padding(4);
            this.cbxHsQuanTrong.Name = "cbxHsQuanTrong";
            this.cbxHsQuanTrong.Size = new System.Drawing.Size(87, 26);
            this.cbxHsQuanTrong.TabIndex = 0;
            this.cbxHsQuanTrong.SelectedIndexChanged += new System.EventHandler(this.cbxHsQuanTrong_SelectedIndexChanged);
            // 
            // cbxCapDeo
            // 
            this.cbxCapDeo.FormattingEnabled = true;
            this.cbxCapDeo.Items.AddRange(new object[] {
            "DCM",
            "DCH"});
            this.cbxCapDeo.Location = new System.Drawing.Point(286, 205);
            this.cbxCapDeo.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCapDeo.Name = "cbxCapDeo";
            this.cbxCapDeo.Size = new System.Drawing.Size(87, 26);
            this.cbxCapDeo.TabIndex = 0;
            this.cbxCapDeo.SelectedIndexChanged += new System.EventHandler(this.cbxCapDeo_SelectedIndexChanged);
            // 
            // cbxKetCau
            // 
            this.cbxKetCau.FormattingEnabled = true;
            this.cbxKetCau.Items.AddRange(new object[] {
            "Hệ khung, hoặc tương đương",
            "Hệ tường ghép, hoặc tương đương",
            "Hệ tường không ghép",
            "Hệ dễ xoắn",
            "Hệ con lắc ngược"});
            this.cbxKetCau.Location = new System.Drawing.Point(140, 245);
            this.cbxKetCau.Margin = new System.Windows.Forms.Padding(4);
            this.cbxKetCau.Name = "cbxKetCau";
            this.cbxKetCau.Size = new System.Drawing.Size(233, 26);
            this.cbxKetCau.TabIndex = 0;
            this.cbxKetCau.SelectedIndexChanged += new System.EventHandler(this.cbxKetCau_SelectedIndexChanged);
            // 
            // txtPhaHoaiKw
            // 
            this.txtPhaHoaiKw.Location = new System.Drawing.Point(285, 283);
            this.txtPhaHoaiKw.Name = "txtPhaHoaiKw";
            this.txtPhaHoaiKw.Size = new System.Drawing.Size(87, 24);
            this.txtPhaHoaiKw.TabIndex = 4;
            this.txtPhaHoaiKw.Text = "1";
            this.txtPhaHoaiKw.TextChanged += new System.EventHandler(this.txtPhaHoaiKw_TextChanged);
            // 
            // dgvThongSo
            // 
            this.dgvThongSo.AllowUserToAddRows = false;
            this.dgvThongSo.AllowUserToDeleteRows = false;
            this.dgvThongSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongSo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thongSo,
            this.giaTri});
            this.dgvThongSo.Location = new System.Drawing.Point(12, 350);
            this.dgvThongSo.Name = "dgvThongSo";
            this.dgvThongSo.ReadOnly = true;
            this.dgvThongSo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongSo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvThongSo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongSo.Size = new System.Drawing.Size(359, 249);
            this.dgvThongSo.TabIndex = 5;
            // 
            // thongSo
            // 
            this.thongSo.Frozen = true;
            this.thongSo.HeaderText = "Thông Số";
            this.thongSo.Name = "thongSo";
            this.thongSo.ReadOnly = true;
            this.thongSo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.thongSo.Width = 230;
            // 
            // giaTri
            // 
            this.giaTri.Frozen = true;
            this.giaTri.HeaderText = "Giá Trị";
            this.giaTri.Name = "giaTri";
            this.giaTri.ReadOnly = true;
            this.giaTri.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.giaTri.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // radPPU
            // 
            this.radPPU.AutoSize = true;
            this.radPPU.Checked = true;
            this.radPPU.Location = new System.Drawing.Point(9, 34);
            this.radPPU.Name = "radPPU";
            this.radPPU.Size = new System.Drawing.Size(186, 22);
            this.radPPU.TabIndex = 6;
            this.radPPU.TabStop = true;
            this.radPPU.Text = "Tính giá trị phổ phản ứng";
            this.radPPU.UseVisualStyleBackColor = true;
            this.radPPU.Click += new System.EventHandler(this.radPPU_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.radPPUDaoDong);
            this.groupBox1.Controls.Add(this.radPPU);
            this.groupBox1.Location = new System.Drawing.Point(394, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 110);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phương pháp tính toán";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtChuKy);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbxDangDD);
            this.panel1.Controls.Add(this.cbxPhuong);
            this.panel1.Location = new System.Drawing.Point(346, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 99);
            this.panel1.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 72);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "Chu kỳ (s)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "Dạng DD";
            // 
            // txtChuKy
            // 
            this.txtChuKy.Location = new System.Drawing.Point(92, 69);
            this.txtChuKy.Name = "txtChuKy";
            this.txtChuKy.Size = new System.Drawing.Size(88, 24);
            this.txtChuKy.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Phương";
            // 
            // cbxDangDD
            // 
            this.cbxDangDD.FormattingEnabled = true;
            this.cbxDangDD.Location = new System.Drawing.Point(92, 36);
            this.cbxDangDD.Name = "cbxDangDD";
            this.cbxDangDD.Size = new System.Drawing.Size(88, 26);
            this.cbxDangDD.TabIndex = 9;
            this.cbxDangDD.SelectedIndexChanged += new System.EventHandler(this.cbxDangDD_SelectedIndexChanged);
            // 
            // cbxPhuong
            // 
            this.cbxPhuong.FormattingEnabled = true;
            this.cbxPhuong.Location = new System.Drawing.Point(92, 4);
            this.cbxPhuong.Name = "cbxPhuong";
            this.cbxPhuong.Size = new System.Drawing.Size(88, 26);
            this.cbxPhuong.TabIndex = 9;
            this.cbxPhuong.SelectedIndexChanged += new System.EventHandler(this.cbxPhuong_SelectedIndexChanged);
            // 
            // radPPUDaoDong
            // 
            this.radPPUDaoDong.AutoSize = true;
            this.radPPUDaoDong.Location = new System.Drawing.Point(9, 72);
            this.radPPUDaoDong.Name = "radPPUDaoDong";
            this.radPPUDaoDong.Size = new System.Drawing.Size(282, 22);
            this.radPPUDaoDong.TabIndex = 6;
            this.radPPUDaoDong.Text = "Phân tích phổ phản ứng dạng dao động";
            this.radPPUDaoDong.UseVisualStyleBackColor = true;
            this.radPPUDaoDong.Click += new System.EventHandler(this.radPPUDaoDong_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nFileToolStripMenuItem,
            this.tínhToánToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(941, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nFileToolStripMenuItem
            // 
            this.nFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.nFileToolStripMenuItem.Name = "nFileToolStripMenuItem";
            this.nFileToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.nFileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mdbToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // mdbToolStripMenuItem
            // 
            this.mdbToolStripMenuItem.Name = "mdbToolStripMenuItem";
            this.mdbToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.mdbToolStripMenuItem.Text = "*mdb";
            this.mdbToolStripMenuItem.Click += new System.EventHandler(this.mdbToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.textFileToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            // 
            // textFileToolStripMenuItem
            // 
            this.textFileToolStripMenuItem.Name = "textFileToolStripMenuItem";
            this.textFileToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.textFileToolStripMenuItem.Text = "Text File";
            this.textFileToolStripMenuItem.Click += new System.EventHandler(this.textFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tínhToánToolStripMenuItem
            // 
            this.tínhToánToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem});
            this.tínhToánToolStripMenuItem.Name = "tínhToánToolStripMenuItem";
            this.tínhToánToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.tínhToánToolStripMenuItem.Text = "Tính Toán";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.tácGiảToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.licenseToolStripMenuItem.Text = "License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tácGiảToolStripMenuItem
            // 
            this.tácGiảToolStripMenuItem.Name = "tácGiảToolStripMenuItem";
            this.tácGiảToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.tácGiảToolStripMenuItem.Text = "Tác giả";
            this.tácGiảToolStripMenuItem.Click += new System.EventHandler(this.tácGiảToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvKQ);
            this.groupBox2.Location = new System.Drawing.Point(394, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 468);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả Tính Toán";
            // 
            // dgvKQ
            // 
            this.dgvKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKQ.Location = new System.Drawing.Point(3, 20);
            this.dgvKQ.Name = "dgvKQ";
            this.dgvKQ.Size = new System.Drawing.Size(530, 445);
            this.dgvKQ.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 611);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvThongSo);
            this.Controls.Add(this.txtPhaHoaiKw);
            this.Controls.Add(this.chkMatDungDD);
            this.Controls.Add(this.llab);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxKetCau);
            this.Controls.Add(this.cbxCapDeo);
            this.Controls.Add(this.cbxHsQuanTrong);
            this.Controls.Add(this.cbxNenDat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxHuyen);
            this.Controls.Add(this.cbxTinh);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongSo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxHuyen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNenDat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkMatDungDD;
        private System.Windows.Forms.ComboBox cbxHsQuanTrong;
        private System.Windows.Forms.ComboBox cbxCapDeo;
        private System.Windows.Forms.ComboBox cbxKetCau;
        private System.Windows.Forms.TextBox txtPhaHoaiKw;
        private System.Windows.Forms.DataGridView dgvThongSo;
        private System.Windows.Forms.RadioButton radPPU;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radPPUDaoDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn thongSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaTri;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tínhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mdbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tácGiảToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxPhuong;
        private System.Windows.Forms.TextBox txtChuKy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxDangDD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKQ;
    }
}

