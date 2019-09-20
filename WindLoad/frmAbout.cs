using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindLoad
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            
            string thongTin = "WindLoad là phần mềm tính gió theo\n" +
                "TCVN 2737:1995 và TCVN 299:1999\n\nDesigned by: Nguyễn Văn Mậu-2014X7 HAU\n\nMọi thắc mắc, góp ý vui lòng liên hệ \nSDT: 0352233868\n";
            labInfo.Text = thongTin;
            
            labInfo.ForeColor = Color.Red;
        }

        private void linkfb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/vanmaudhkt1996");
        }
    }
}
