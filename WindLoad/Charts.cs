using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WindLoad
{
    public partial class Charts : Form
    {
        Graphics g;
        public Charts()
        {
            InitializeComponent();
            

        }

        private void Charts_Load(object sender, EventArgs e)
        {
            MessageBox.Show("123");
            drawTable();
        }
        private void drawTable()
        {
           g= this.CreateGraphics();
            Pen p = new Pen(Color.Red,5);
            Point p1 = new Point(30, 30);
            Point p2 = new Point(30, 300);
            g.DrawLine(p, p1, p2);
            p.Dispose();
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawTable();
        }
    }
    
}
