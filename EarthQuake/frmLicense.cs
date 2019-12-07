using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace EarthQuake
{
    public partial class frmLicense : Form
    {
        public delegate string Key(string key);
        public event Key eKey;

        private string key;
        public frmLicense()
        {
            InitializeComponent();
        }
        private string getMachineName()
        {
            string xx = String.Empty;
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                xx = getserial["SerialNumber"].ToString();
            }
            return xx;
        }

        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            string v = getMachineName().Substring(3,4);


            key = getMachineName() + v;
            //txtKey.Text = key;
            if (txtKey.Text== key)
            {
                Properties.Settings.Default.serialKey = key;
                Properties.Settings.Default.Save();
                btnKichHoat.Enabled = false;
                MessageBox.Show("Phần mềm đã được kích hoạt !\nXin cảm ơn !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã sai !");
                Application.Exit();
            }

        }

        private void frmLicense_Load(object sender, EventArgs e)
        {

           

            txtKey.Text = Properties.Settings.Default.serialKey;
            eKey(txtKey.Text);
            // if (true)
            /// {
            // this.Close();
            // }
            txtMachineName.Text= getMachineName();
            

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
            if (txtKey.Text != key)
            {
                Application.Exit();
            }
        }
    }
}
