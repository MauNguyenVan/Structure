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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOPenFile
            // 
            this.btnOPenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOPenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPenFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnOPenFile.Location = new System.Drawing.Point(71, 50);
            this.btnOPenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOPenFile.Name = "btnOPenFile";
            this.btnOPenFile.Size = new System.Drawing.Size(286, 115);
            this.btnOPenFile.TabIndex = 0;
            this.btnOPenFile.Text = "Mở file ...";
            this.btnOPenFile.UseVisualStyleBackColor = false;
            this.btnOPenFile.Click += new System.EventHandler(this.BtnOPenFile_Click);
            // 
            // btnNewProject
            // 
            this.btnNewProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNewProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProject.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnNewProject.Location = new System.Drawing.Point(71, 189);
            this.btnNewProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(286, 115);
            this.btnNewProject.TabIndex = 0;
            this.btnNewProject.Text = "Tạo dự án mới ...";
            this.btnNewProject.UseVisualStyleBackColor = false;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bạn muốn";
            // 
            // frmQuickStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 346);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.btnOPenFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQuickStart";
            this.ShowIcon = false;
            this.Text = "QuickStart - WindLoad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuickStart_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOPenFile;
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.Label label1;
    }
}