using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EarthQuake
{
    public partial class frmSPT : Form
    {
        public delegate double SPT(double spt);
        public event SPT eventSPT;
        double[,] listSPT;
        int rowtxtSPT;


        public frmSPT()
        {
            InitializeComponent();
            txtSPT.AcceptsTab = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSPT.Text != "")
            {

                eventSPT(getSPT());
                this.Hide();
            }

            else
            {
                MessageBox.Show("Bạn chưa nhập giá trị SPT");

            }


        }

        private double getSPT()
        {
            
            double sumSPT = 0,sumx1=0;
            double x1=0, x2=0;
            int n;
            rowtxtSPT = txtSPT.Lines.Count();//==0?txtSPT.Lines.Count() : txtSPT.Lines.Count()-1;
            listSPT = new double[rowtxtSPT, 2];

            int i = 0;
            do
            {
                string x = txtSPT.Lines[i].ToString();
                n = x.IndexOf("\t");
                //MessageBox.Show(n.ToString() );
                double.TryParse(x.Substring(0, n ),out x1);
               
                double.TryParse (x.Substring(n+1, x.Length-x1.ToString().Length-1),out x2);
                //MessageBox.Show(x1.ToString()+"dxff"+ x2.ToString());
                double.TryParse(x1.ToString(), out listSPT[i,0]);
                    double.TryParse(x2.ToString(), out listSPT[i, 1]);

                sumSPT+=x1*x2;
                sumx1 += x1;
  
                i++;
            } while (i < rowtxtSPT);
            return Math.Round(sumSPT/sumx1,2);

        }
        private void frmSPT_Load(object sender, EventArgs e)
        {

            //for (int i = 0; i < rowtxtSPT - 1; i++)
            //{
            //    txtSPT.AppendText(listSPT[i].ToString() + "\r\n");
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(listSPT.Length.ToString());
            this.Close();

        }

    
     
    }
}
