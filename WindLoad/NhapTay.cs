using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindLoad
{


   


    public partial class frmNhapTay : Form
    {
        frmMain fMain;
        public frmNhapTay(frmMain f_Main)
        {
            InitializeComponent();
            fMain = f_Main;
            txtSoTang.Text = "10";
            txtCaoTang.Text = "3.5";
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            fMain.tang =fMain.cao = 0;

            this.Close();
        }

        
        //public static byte soTang;
       // public static double caoTang;
        public void btnOK_Click(object sender, EventArgs e)
        {



            fMain.tang =double.Parse( txtSoTang.Text);
            fMain.cao =double.Parse(txtCaoTang.Text);
            // soTang = byte.Parse(txtSoTang.Text);
            // caoTang = double.Parse(txtCaoTang.Text);


            this.Close();
        }

        private void txtCaoTang_TextChanged(object sender, EventArgs e)
        {
            
            if (txtCaoTang.Text == "-") MessageBox.Show("Chiều cao tâng > 0", "Thông báo:");
        }

        private void txtSoTang_TextChanged(object sender, EventArgs e)
        {
            if (txtSoTang.Text == "-") MessageBox.Show("Số tâng > 0", "Thông báo:");
        }
    }
}
