using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;



namespace WindLoad
{
    public partial class frmFilemdb : Form
    {
        public frmFilemdb()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            Close();
            //frmFilemdb.ActiveForm.Close();
            //Application.Exit();//Thoát toàn bộ chương trình

        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog fmdb = new OpenFileDialog();
            fmdb.Title = "Chọn file (*.mdb,*.accdb)";
            fmdb.Filter = "Chọn file|*.mdb;*.accdb";
            
            // fmdb.ShowDialog() == DialogResult.OK;
            //Xu ly-
            if (fmdb.ShowDialog()== DialogResult.OK)
            {
                txtPath.Text = fmdb.FileName;
                
            }
            else
                MessageBox.Show("Chưa chọn file *.mdb");

        }
       public static DataTable tabl1;
        public static DataTable tabl2;
        public static DataTable tabl3,tabl4,tabl5,tabl6;

        private void frmFilemdb_Load(object sender, EventArgs e)
        {

        }

       // frmMain fMain = new frmMain();
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != "")
            {
                


                try
                {
                
                    //OleDbCommand cmd = new OleDbCommand();
                    //cmd.CommandText = "SELECT  Height FROM Story Data ";//Name &
                    string query1 = "SELECT [Story Data].Name, [Story Data].Height FROM [Story Data];";

                    OleDbConnection cnn = new OleDbConnection();
                    cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + txtPath.Text;
                    
                    OleDbDataAdapter adt1 = new OleDbDataAdapter(query1, cnn);//cmd.CommandText
                    cnn.Open();
                    tabl1 = new DataTable();
                    adt1.Fill(tabl1);

                    string query2 = "SELECT  MAX([Grid Lines].Ordinate) AS Maxx FROM[Grid Lines] GROUP BY[Grid Lines].Axis;";

                    OleDbDataAdapter adt2 = new OleDbDataAdapter(query2, cnn);//cmd.CommandText
                    tabl2 = new DataTable();
                    adt2.Fill(tabl2);


                    string query3 = "SELECT  -1*MIN(Elevation) AS Minn FROM [Story Data];";

                    OleDbDataAdapter adt3 = new OleDbDataAdapter(query3, cnn);//cmd.CommandText
                    tabl3 = new DataTable();
                    adt3.Fill(tabl3);
                    
                    //get value Mode, Period,Ux,Uy
                    string query4 = "SELECT  [Modal Participating Mass Ratios].mode as mode, [Modal Participating Mass Ratios].period as Period, [Modal Participating Mass Ratios].Ux as ux,[Modal Participating Mass Ratios].Uy as uy FROM  [Modal Participating Mass Ratios];";
                    OleDbDataAdapter adt4 = new OleDbDataAdapter(query4, cnn);//cmd.CommandText
                    tabl4 = new DataTable();
                    adt4.Fill(tabl4);

                    //get value Mode, Period,Massx, massY
                    string query5 = "SELECT xcm,ycm,massX,massy FROM [Centers of Mass and Rigidity];";
                    OleDbDataAdapter adt5 = new OleDbDataAdapter(query5, cnn);//cmd.CommandText
                    tabl5 = new DataTable();
                    adt5.Fill(tabl5);
                    //get value chuyen vij,Ux,Uy
                   
                    int i = 0;
                   // while (i<tabl4.Rows.Count)
                  //  {
                       // string adt6 = "adt6" + i.ToString();
                        string query6 = "SELECT UX, UY FROM[Diaphragm Center of Mass Displacements]WHERE CaseCombo = 'Modal " + "1" + "';";// + fMain.cbxMode.Text + "';" ;
                        OleDbDataAdapter adt6= new OleDbDataAdapter(query6, cnn);//cmd.CommandText
                        tabl6 = new DataTable();
                        adt6.Fill(tabl6);
                        i++;
                 //   }
                    

                    cnn.Dispose();
                    this.Close();
                    //for (int i = tabl.Rows.Count-1; i >= 0; i--)
                    //{
                    //    string tang = tabl.Rows[i]["Name"].ToString();
                    //    string cao = tabl.Rows[i]["Height"].ToString();
                    //    MessageBox.Show(tang +"=" + cao) ;
                    //}
                }
               catch (Exception)
               {
                    MessageBox.Show("Sai dữ liệu | Kiểm tra lại dữ liệu\n" + e, "Thông báo:",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn file");
        }


    }
}
