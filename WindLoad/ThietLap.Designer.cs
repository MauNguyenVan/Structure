namespace WindLoad
{
    partial class frmThietLap
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCHut = new System.Windows.Forms.TextBox();
            this.txtCDay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hệ số c hút (Mặt khuất  gió):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ số c đẩy (Mặt đón gió):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCHut
            // 
            this.txtCHut.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindLoad.Properties.Settings.Default, "cHut", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCHut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCHut.Location = new System.Drawing.Point(182, 51);
            this.txtCHut.Name = "txtCHut";
            this.txtCHut.Size = new System.Drawing.Size(66, 22);
            this.txtCHut.TabIndex = 1;
            this.txtCHut.Text = global::WindLoad.Properties.Settings.Default.cHut;
            // 
            // txtCDay
            // 
            this.txtCDay.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindLoad.Properties.Settings.Default, "cDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCDay.Location = new System.Drawing.Point(182, 14);
            this.txtCDay.Name = "txtCDay";
            this.txtCDay.Size = new System.Drawing.Size(66, 22);
            this.txtCDay.TabIndex = 0;
            this.txtCDay.Text = global::WindLoad.Properties.Settings.Default.cDay;
            // 
            // frmThietLap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(258, 129);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCHut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCDay);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThietLap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết lập thông số";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCHut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}