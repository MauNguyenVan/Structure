using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


namespace WindLoad
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
            timer2.Start();
           
        }

       
        
        private void timer2_Tick(object sender, EventArgs e)
        {
           
            timer2.Interval = 30;//5*1000/250=5000ms
            progressBar1.Increment(1);
            label1.Text = "Đang khởi động..." + progressBar1.Value + "%";
           // this.Opacity -= 0.05*timer2.Interval/ timer2.Interval;
            this.Opacity = 1 - 0.01 * progressBar1.Value;
            if (progressBar1.Value == 100)
            {
                timer2.Stop();
                //this.Dispose();
            }
           
        }

        private void frmStart_Load(object sender, EventArgs e)
        {

        }
    }
}
