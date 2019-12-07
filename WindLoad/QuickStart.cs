using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindLoad
{
    public partial class frmQuickStart : Form
    {
        public event EventHandler EveOpen;
        public frmQuickStart()
        {
            InitializeComponent();
        }

     
      
        private void BtnOPenFile_Click(object sender, EventArgs e)
        {
           
          EveOpen.Invoke(sender, e);
            this.Close();
        }

       

       

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuickStart_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   Application.Exit();
        }
    }
}
