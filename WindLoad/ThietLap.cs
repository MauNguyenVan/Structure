using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


namespace WindLoad
{
    public partial class frmThietLap : Form
    {
        public static double cday = 0.8, chut = -0.6;

        public frmThietLap()
        {
            InitializeComponent();

            double.TryParse(txtCDay.Text.ToString(), out cday);
            double.TryParse(txtCHut.Text.ToString(), out chut);

            txtCDay.Select();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCDay.Text = cday.ToString();
            txtCHut.Text = chut.ToString();

            this.Dispose();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //truyen he so c -> class xuly
            cday = double.Parse(txtCDay.Text.ToString());
            chut = double.Parse(txtCHut.Text.ToString());

            this.Close();
        }
        
    }
}
