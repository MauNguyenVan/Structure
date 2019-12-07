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
    public partial class SetMode : Form
    {
        public SetMode()
        {
            InitializeComponent();
        
            dgvSetMode.Columns.Add("mode", "Mode");
            dgvSetMode.Columns.Add("t", "T(s)");
            dgvSetMode.Columns.Add("f", "f(hz)");
            dgvSetMode.Columns.Add("massX", "Mass X(%)");
            dgvSetMode.Columns.Add("massY", "Mass Y(%)");
            

            DataGridViewCheckBoxColumn pX = new DataGridViewCheckBoxColumn();
            pX.HeaderText = "Phương X";
            pX.Width = 60;
            pX.Name = "phuongX";

            DataGridViewCheckBoxColumn pY = new DataGridViewCheckBoxColumn();
            pY.HeaderText = "Phương Y";
            pY.Width = 60;
            pY.Name = "phuongY";
            dgvSetMode.Columns.Add(pX);
            dgvSetMode.Columns.Add(pY);

           


            dgvSetMode.Columns["mode"].Width = 40;
            dgvSetMode.Columns["t"].Width = 60;
            dgvSetMode.Columns["f"].Width = 60;
            dgvSetMode.Columns["massX"].Width = 70;
            dgvSetMode.Columns["massY"].Width = 70;

            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
           // throw new NotImplementedException();
        }

        private void SetMode_Load(object sender, EventArgs e)
        {
            int i = 0;
            int modeCount =frmFilemdb.tabl4.Rows.Count;
            dgvSetMode.Rows.Add(modeCount);
            while (i < modeCount)
            {
              
                dgvSetMode["mode",i].Value = frmFilemdb.tabl4.Rows[i]["mode"].ToString();
               float chuKyT= float.Parse( frmFilemdb.tabl4.Rows[i]["Period"].ToString());
                float tanSoF = 1 / chuKyT;
                dgvSetMode["t", i].Value = Math.Round(chuKyT,3);
                dgvSetMode["f", i].Value = Math.Round(tanSoF, 3);
                phuongdd(i);
                i++;
            }
        }
        private void phuongdd(int i)
        {
            //Xac dinh phuong dao dong
            //kieen tra fL
            

            double massUX = double.Parse(frmFilemdb.tabl4.Rows[i]["UX"].ToString());
            double massUY = double.Parse(frmFilemdb.tabl4.Rows[i]["UY"].ToString());
            float XdivY = (float)(massUX / massUY);
            float YdivX = (float)(massUY / massUX);
            if (XdivY >= 3)
            {
                //Check phuong X
                dgvSetMode["massX", i].Value = XdivY;
                dgvSetMode.Rows[i].Cells["phuongX"].Value = true;

                //  chk.Value = chk.TrueValue;
            }
            else if (YdivX >= 3)
            {
                //Check phuong X
                dgvSetMode["phuongY", i].Value= true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
