namespace EarthQuake
{
    partial class frmPPUDaoDong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPPUDD = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.massX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dangDDX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KLHuuHieuX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.massY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dangDDY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KLHuuHieuY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuongX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.phuongY = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cbx = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.picView = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMinKLHH = new System.Windows.Forms.TextBox();
            this.chkRemoveMinDDD = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPUDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPPUDD
            // 
            this.dgvPPUDD.AllowDrop = true;
            this.dgvPPUDD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPPUDD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.T,
            this.f,
            this.massX,
            this.dangDDX,
            this.KLHuuHieuX,
            this.massY,
            this.dangDDY,
            this.KLHuuHieuY,
            this.phuongX,
            this.phuongY});
            this.dgvPPUDD.Location = new System.Drawing.Point(6, 4);
            this.dgvPPUDD.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPPUDD.Name = "dgvPPUDD";
            this.dgvPPUDD.Size = new System.Drawing.Size(590, 353);
            this.dgvPPUDD.TabIndex = 0;
            this.dgvPPUDD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPPUDD_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID Mode";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // T
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.T.DefaultCellStyle = dataGridViewCellStyle1;
            this.T.HeaderText = "T (s)";
            this.T.Name = "T";
            this.T.ReadOnly = true;
            this.T.Width = 60;
            // 
            // f
            // 
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.f.DefaultCellStyle = dataGridViewCellStyle2;
            this.f.HeaderText = "f (Hz)";
            this.f.Name = "f";
            this.f.ReadOnly = true;
            this.f.Width = 50;
            // 
            // massX
            // 
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.massX.DefaultCellStyle = dataGridViewCellStyle3;
            this.massX.HeaderText = "Mass X";
            this.massX.Name = "massX";
            this.massX.ReadOnly = true;
            this.massX.Width = 50;
            // 
            // dangDDX
            // 
            this.dangDDX.HeaderText = "Dạng DD X";
            this.dangDDX.Name = "dangDDX";
            this.dangDDX.ReadOnly = true;
            this.dangDDX.Width = 40;
            // 
            // KLHuuHieuX
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.KLHuuHieuX.DefaultCellStyle = dataGridViewCellStyle4;
            this.KLHuuHieuX.HeaderText = "KL Hữu Hiệu X\n (%)";
            this.KLHuuHieuX.Name = "KLHuuHieuX";
            this.KLHuuHieuX.ReadOnly = true;
            this.KLHuuHieuX.Width = 50;
            // 
            // massY
            // 
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.massY.DefaultCellStyle = dataGridViewCellStyle5;
            this.massY.HeaderText = "Mass Y";
            this.massY.Name = "massY";
            this.massY.ReadOnly = true;
            this.massY.Width = 50;
            // 
            // dangDDY
            // 
            this.dangDDY.HeaderText = "Dạng DD Y";
            this.dangDDY.Name = "dangDDY";
            this.dangDDY.ReadOnly = true;
            this.dangDDY.Width = 40;
            // 
            // KLHuuHieuY
            // 
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.KLHuuHieuY.DefaultCellStyle = dataGridViewCellStyle6;
            this.KLHuuHieuY.HeaderText = "KL Hữu Hiệu Y \n(%)";
            this.KLHuuHieuY.Name = "KLHuuHieuY";
            this.KLHuuHieuY.ReadOnly = true;
            this.KLHuuHieuY.Width = 50;
            // 
            // phuongX
            // 
            this.phuongX.HeaderText = "Phương X";
            this.phuongX.Name = "phuongX";
            this.phuongX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.phuongX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.phuongX.Width = 45;
            // 
            // phuongY
            // 
            this.phuongY.HeaderText = "Phương Y";
            this.phuongY.Name = "phuongY";
            this.phuongY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.phuongY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.phuongY.Width = 45;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(521, 385);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(631, 3);
            this.dgvData.Margin = new System.Windows.Forms.Padding(4);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(607, 450);
            this.dgvData.TabIndex = 0;
            // 
            // cbx
            // 
            this.cbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx.FormattingEnabled = true;
            this.cbx.Location = new System.Drawing.Point(318, 429);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(142, 24);
            this.cbx.TabIndex = 3;
            this.cbx.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.comboBox1.Location = new System.Drawing.Point(63, 426);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "X";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.picView.BackgroundImage = global::EarthQuake.Properties.Resources.mt_2_chieu;
            this.picView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picView.Location = new System.Drawing.Point(601, 172);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(27, 36);
            this.picView.TabIndex = 5;
            this.picView.TabStop = false;
            this.picView.Click += new System.EventHandler(this.picView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(522, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 24);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMinKLHH
            // 
            this.txtMinKLHH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMinKLHH.Location = new System.Drawing.Point(360, 387);
            this.txtMinKLHH.Name = "txtMinKLHH";
            this.txtMinKLHH.Size = new System.Drawing.Size(100, 22);
            this.txtMinKLHH.TabIndex = 7;
            this.txtMinKLHH.Text = "5";
            this.txtMinKLHH.TextChanged += new System.EventHandler(this.txtMinKLHH_TextChanged);
            // 
            // chkRemoveMinDDD
            // 
            this.chkRemoveMinDDD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRemoveMinDDD.AutoSize = true;
            this.chkRemoveMinDDD.Checked = true;
            this.chkRemoveMinDDD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveMinDDD.Location = new System.Drawing.Point(6, 389);
            this.chkRemoveMinDDD.Name = "chkRemoveMinDDD";
            this.chkRemoveMinDDD.Size = new System.Drawing.Size(348, 20);
            this.chkRemoveMinDDD.TabIndex = 8;
            this.chkRemoveMinDDD.Text = "Loại bỏ dạng dao động có khối lượng hữu hiệu bé hơn ";
            this.chkRemoveMinDDD.UseVisualStyleBackColor = true;
            this.chkRemoveMinDDD.CheckedChanged += new System.EventHandler(this.chkRemoveMinDDD_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Phương";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mode";
            // 
            // frmPPUDaoDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 470);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkRemoveMinDDD);
            this.Controls.Add(this.txtMinKLHH);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.picView);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cbx);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.dgvPPUDD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 503);
            this.Name = "frmPPUDaoDong";
            this.ShowIcon = false;
            this.Text = "Phổ phản ứng dạng dao dộng";
            this.Load += new System.EventHandler(this.frmPPUDaoDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPUDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPPUDD;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cbx;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn f;
        private System.Windows.Forms.DataGridViewTextBoxColumn massX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dangDDX;
        private System.Windows.Forms.DataGridViewTextBoxColumn KLHuuHieuX;
        private System.Windows.Forms.DataGridViewTextBoxColumn massY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dangDDY;
        private System.Windows.Forms.DataGridViewTextBoxColumn KLHuuHieuY;
        private System.Windows.Forms.DataGridViewCheckBoxColumn phuongX;
        private System.Windows.Forms.DataGridViewCheckBoxColumn phuongY;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtMinKLHH;
        private System.Windows.Forms.CheckBox chkRemoveMinDDD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}