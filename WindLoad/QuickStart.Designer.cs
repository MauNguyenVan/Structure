namespace WindLoad
{
    partial class frmQuickStart
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
            this.btnOPenFile = new System.Windows.Forms.Button();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOPenFile
            // 
            this.btnOPenFile.Location = new System.Drawing.Point(74, 65);
            this.btnOPenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOPenFile.Name = "btnOPenFile";
            this.btnOPenFile.Size = new System.Drawing.Size(273, 77);
            this.btnOPenFile.TabIndex = 0;
            this.btnOPenFile.Text = "Mở file ...";
            this.btnOPenFile.UseVisualStyleBackColor = true;
            this.btnOPenFile.Click += new System.EventHandler(this.BtnOPenFile_Click);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Location = new System.Drawing.Point(74, 156);
            this.btnNewProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(273, 77);
            this.btnNewProject.TabIndex = 0;
            this.btnNewProject.Text = "Tạo dự án mới ...";
            this.btnNewProject.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(74, 251);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(273, 77);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Để sau ...";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bạn muốn";
            // 
            // frmQuickStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 377);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.btnOPenFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQuickStart";
            this.Text = "QuickStart - WindLoad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOPenFile;
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
    }
}