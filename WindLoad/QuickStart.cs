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
        public frmQuickStart()
        {
            InitializeComponent();
        }
       
       
        private void BtnOPenFile_Click(object sender, EventArgs e)
        {
            frmMain main= new frmMain();
            main.OpenToolStripMenuItem_Click(sender, e);
            this.Close();

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
