using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace EarthQuake
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            
            string thongTin = "EarthQuake là phần mềm tính động đất theo\n" +
                "TCVN 9386:2012\n\nDesigned by: Nguyễn Văn Mậu-2014x7 HAU\n\nMọi thắc mắc, góp ý vui lòng liên hệ \nSDT: 0352233868\n";
            labInfo.Text = thongTin;
            
            labInfo.ForeColor = Color.Black ;
        }

        private void linkfb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/vanmaudhkt1996");
        }
    }
}
