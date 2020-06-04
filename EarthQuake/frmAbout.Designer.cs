namespace EarthQuake
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.picMe = new System.Windows.Forms.PictureBox();
            this.labInfo = new System.Windows.Forms.Label();
            this.linkfb = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picMe)).BeginInit();
            this.SuspendLayout();
            // 
            // picMe
            // 
            this.picMe.Image = ((System.Drawing.Image)(resources.GetObject("picMe.Image")));
            this.picMe.Location = new System.Drawing.Point(0, 4);
            this.picMe.Name = "picMe";
            this.picMe.Size = new System.Drawing.Size(187, 104);
            this.picMe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMe.TabIndex = 0;
            this.picMe.TabStop = false;
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(187, 18);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(0, 18);
            this.labInfo.TabIndex = 1;
            // 
            // linkfb
            // 
            this.linkfb.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkfb.AutoSize = true;
            this.linkfb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkfb.LinkColor = System.Drawing.Color.MediumBlue;
            this.linkfb.Location = new System.Drawing.Point(188, 144);
            this.linkfb.Name = "linkfb";
            this.linkfb.Size = new System.Drawing.Size(185, 18);
            this.linkfb.TabIndex = 2;
            this.linkfb.TabStop = true;
            this.linkfb.Text = "https://www.facebook.com";
            this.linkfb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkfb_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(530, 186);
            this.Controls.Add(this.linkfb);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.picMe);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About : Author";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMe;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.LinkLabel linkfb;
    }
}