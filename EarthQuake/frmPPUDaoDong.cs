using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;


namespace EarthQuake
{
  public  struct ModeXY
    {
        public int mode;
        public bool x, y;
        public double chuky;

       
       
    }


    public partial class frmPPUDaoDong : Form
    {
        OleDbConnection cnn;
        OleDbDataAdapter ada;
        DataTable tabl1;// = new DataTable();//chu ky
        DataTable tabl2;//= new DataTable();//khoi luong tham gia dao dong
        DataTable tabl3;//= new DataTable();// chuyen vi tang
        DataTable dtSummary = new DataTable();//soluocketqua
      ModeXY modeXY = new ModeXY();
        List<ModeXY> listModeXY = new List<ModeXY>();

      //  bool[,] dataXY = new bool[12, 2];// phuong dao dong theo X or Y
      
        public double S { get; set; }
        public double Tb { get; set; }
        public double Tc { get; set; }
        public double Td { get; set; }
        public double Sd { get; set; }
        const double beta = 0.2;

        public double giaTocNenTKag { get; set; }//=agr*g1
        public double hsUngXuq { get; set; }//=qo*kw>=1.5

        public delegate void Table (DataTable table,List<ModeXY> listModeXY);
        public event Table eventTable;

        public frmPPUDaoDong()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            dgvData.Visible = false;
            
            // cbxPhuong.Columns.Clear();

            //cbxPhuong.Columns.Add("phuong", "Phuong");
            //cbxPhuong.Columns.Add("dangDD", "DangDD");
            //cbxPhuong.Columns.Add("tang", "Tầng");
            //cbxPhuong.Columns.Add("mj", "mj");
            //cbxPhuong.Columns.Add("phanTramKLHuuHieu", "% KL HH");
            //cbxPhuong.Columns.Add("tongKLHuuHieu", "Tong KL HH");
            //cbxPhuong.Columns.Add("sj", "sj");
            //cbxPhuong.Columns.Add("mjSj", "mj*sjk");
            //cbxPhuong.Columns.Add("mjSjSj", "mj*(sjk)^2");



            //cbxPhuong.Columns.Add("fj", "FX");
            //cbxPhuong.Columns.Add("summj", "summj");
            //cbxPhuong.Columns.Add("summjsj", "summjsj");
            //cbxPhuong.Columns.Add("summjsjsj", "summjsjsj");
            //cbxPhuong.Columns.Add("sd", "sd");
            //cbxPhuong.Columns.Add("fy", "FY");
        }
        public DataTable dt = new DataTable();
        private void frmPPUDaoDong_Load(object sender, EventArgs e)
        {
           
            try
            {

                dt.TableName = "dataPUDD";
                dt.Columns.Add("phuong", typeof(char));
                dt.Columns.Add("dangDD", typeof(int));
                dt.Columns.Add("mode", typeof(sbyte));
                dt.Columns.Add("MassU", typeof(double));
                dt.Columns.Add("KLHuuHieu", typeof(double));
                dt.Columns.Add("tongKLHuuHieu", typeof(double));
                dt.Columns.Add("tang", typeof(string));
                dt.Columns.Add("mj", typeof(double));
                dt.Columns.Add("sj", typeof(double));
                dt.Columns.Add("mjsj", typeof(double));
                dt.Columns.Add("mjsjsj", typeof(double));
                dt.Columns.Add("Fj", typeof(double));
                
                dt.Columns.Add("summj", typeof(double));
                dt.Columns.Add("summjsj", typeof(double));
                dt.Columns.Add("summjsjsj", typeof(double));
                dt.Columns.Add("sd", typeof(double));

                dgvPPUDD.Rows.Clear();

                TruyVan();
                GetDangDD('X');
                GetDangDD('Y');
                dgvData.DataSource = dt;

            }
             catch (Exception)
            {
                 MessageBox.Show(" Không tìm thấy dữ liệu ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);

                 this.Dispose();
            }
            this.Width = picView.Location.X+ picView.Width + 20;
        }
       
        public void LayHeSo(double s, double tb, double tc, double td, double giatocnenTk, double hesoungXuq)
        {
            S = s;
            Tb = tb;
            Tc = tc;
            Td = td;
            giaTocNenTKag = giatocnenTk;
            hsUngXuq = hesoungXuq;
        }

        private void TruyVan()
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All file(*.mdb,*.accdb)|*.mdb;*.accdb";
            if (open.ShowDialog() == DialogResult.OK)
            {


                string strlink = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + open.FileName;



                //lay danh sach các tinh
                cnn = new OleDbConnection(strlink);
                cnn.Open();
                string query1 = "SELECT *  from [Modal Participating Mass Ratios]";
                ada = new OleDbDataAdapter(query1, cnn);
                tabl1 = new DataTable();
                ada.Fill(tabl1);


                //tinh mj
                string query2 = "SELECT *  from [Centers of Mass and Rigidity]";
                ada = new OleDbDataAdapter(query2, cnn);
                tabl2 = new DataTable();
                ada.Fill(tabl2);

                // tabl = dtSet.Tables["dsTinh"];
                string query3 = "SELECT *  from [Diaphragm Center of Mass Displacements]";
                ada = new OleDbDataAdapter(query3, cnn);
                tabl3 = new DataTable();
                ada.Fill(tabl3);
                cnn.Dispose();
                cnn.Close();

                FillData();
                TinhPPUDDD();
            }
            else
            {
                this.FormClose();
            }
        }
        private void FillData()
        {
            for (int i = 0; i < tabl1.Rows.Count; i++)
            {
                dgvPPUDD.Rows.Add();
                dgvPPUDD.Rows[i].HeaderCell.Value =Convert.ToString( i+1);
                dgvPPUDD["id", i].Value = tabl1.Rows[i]["Mode"].ToString();
                dgvPPUDD["T", i].Value = tabl1.Rows[i]["Period"].ToString();
                dgvPPUDD["f", i].Value =1/ double.Parse(tabl1.Rows[i]["Period"].ToString());
                double massx = double.Parse(tabl1.Rows[i]["UX"].ToString())*100;
                double massy = double.Parse(tabl1.Rows[i]["UY"].ToString())*100;
                dgvPPUDD["massX", i].Value = massx;
                dgvPPUDD["massy", i].Value = massy;
             //   AuToCheck(massx, massy, i);
            }
        }


        
        private void btnOK_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;//
            addlistMode();
     eventTable(dt, listModeXY);
          


            this.FormClose();
     
        }
        private void TinhPPUDDD()
        {
            int soTang = tabl2.Rows.Count;
            int k = 0, sodong=soTang;
            int l=0, sodong1 = soTang;

            for (int i = 0; i < tabl1.Rows.Count; i++)//Mode
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Modeli(i + 1, soTang, 'X');
                        for ( ; l < sodong1; l ++)
                        {
                            dt.Rows[l]["massU"] = double.Parse(tabl1.Rows[i]["UX"].ToString());
                        }
                        sodong1 += soTang;
                    }
                    else
                    {
                        Modeli(i + 1, soTang, 'Y');

                        for (; l < sodong1; l ++)
                        {
                            dt.Rows[l]["massU"] = double.Parse(tabl1.Rows[i]["UY"].ToString());
                        }
                        sodong1 += soTang;
                    }
                        for (; k <= sodong; k++)
                    {

                        if (k == sodong)

                        {
                            // k ++;
                            sodong += soTang;
                            break;  
                        }
                        else if (k < sodong)
                        {
                            dt.Rows[k]["dangDD"] = DangDD(fj);
                          
                        }

                        
                    }

                }
               


            }

           

        }
       
        private double TinhPhanTramLKHH(double sumMjSj, double sumMjSjSj, double sumMj)
        {
            return sumMjSj * sumMjSj / sumMjSjSj / sumMj * 100;
        }
        private double TongPhanTramKLDD()
        {
            int tongdangdd=0;
            int tang=10;
            double TongPhanTramKL = 0;
            for (int dangdd = 0; dangdd < tongdangdd; dangdd++)
            {
                TongPhanTramKL = TinhPhanTramLKHH(sumMjSj, sumMjSjSj, sumMj);//
                TongPhanTramKL += TongPhanTramKL;
                for (int i = 0; i < tang; i++)
                {
                    //return TongPhanTramKL;
                }
                
            }
            return 0;
           
        }
        private int DangDD(double[] Fjk)
        {
         int dangDD = 1;

            for (int i = 1; i < Fjk.Length; i++)
            {
                if (Fjk[i - 1] > 0 && Fjk[i] < 0 || Fjk[i - 1] < 0 && Fjk[i] > 0)
                {
                    dangDD++;
                }
            }
            return dangDD;
        }

        private void GetDangDD(char phuong)
        {

          
          var sds = from f in dt.AsEnumerable()
                      where f.Field<char>("phuong") == phuong
                  
                      group f by   f.Field<sbyte>("mode")  into s
                    
                      select new { mode = s.Key,dangDD= s.First().Field<int>("dangDD"),KLHuuHieu = s.First().Field<double>("KLHuuHieu"),massU = s.First().Field<double>("massU") };
            // select f;
          //  dgvData.DataSource = sds.ToList();
            double sodangDD = sds.Distinct().Max(x => x.dangDD);
           
            int n = 1;
            //Duyet tung mode
            for (int i = 0; i < tabl1.Rows.Count; i++ )
            {
                dgvPPUDD["dangDD" + phuong, i].Value = sds.ToList()[i].dangDD;
                dgvPPUDD["KLHuuHieu" + phuong, i].Value = sds.ToList()[i].KLHuuHieu;
               
                for (int j = 0; j < tabl1.Rows.Count; j++)
                {
                    
                    double massx = double.Parse(tabl1.Rows[j]["UX"].ToString()) * 100;
                    double massy = double.Parse(tabl1.Rows[j]["UY"].ToString()) * 100;
                   
                    double mass = sds.Where(a => a.dangDD == n).Max(x => x.massU);//lãy max massU thep tung dang DĐ
                   

                    //dgvPPUDD["dangDD" + phuong, i].Value = xx;
                    //ktra dk 
                    if (mass == sds.ToList()[j].massU && n <= sodangDD && sds.ToList()[j].KLHuuHieu>Convert.ToDouble(txtMinKLHH.Text))//KLHH>5%+
                    {
                       
                        AuToCheck(massx, massy, j);
                       


                        n = n < sodangDD ? ++n : n;
                       
                    }

                    // dgvPPUDD["phuong"+phuong, i].Value = true;

                    //  dgvPPUDD["phuong"+ phuong, i].Value = false;



                }


            }
        }

        private void AuToCheck(double massUX, double massUY, int i)
        {
            byte value = 1;
            if (massUX > value * massUY)
            {
                dgvPPUDD["phuongX", i].Value = true;
                dgvPPUDD["phuongY", i].Value = false;
            }
            else if (massUY > value * massUX)
            {
                dgvPPUDD["phuongY", i].Value = true;
                dgvPPUDD["phuongX", i].Value = false;
            }
            else
            {
                dgvPPUDD["phuongX", i].Value = false;
                dgvPPUDD["phuongY", i].Value = false;
            }
          // MessageBox.Show(massUX.ToString() + "--" + massUY.ToString() + "\n" + i.ToString() +"\n" + dgvPPUDD["phuongX", i].Value.ToString()+"---"+ dgvPPUDD["phuongY", i].Value);
        }

        double sumMj = 0;// Kl cac tang theo phuong X
        double sumMjSj = 0;
        double sumMjSjSj = 0;
        // frmMain ff = new frmMain();
        
        TinhHeSo hso = new TinhHeSo();
        double[] fj;//dung de tinh Dang DD
        private void Modeli(int i, int soTang, Char Phuong)//i la modal
        {
            fj = new double[soTang];
           // Array.Clear(fj, 0, soTang);
            double chuKy = double.Parse(tabl1.Rows[i - 1]["Period"].ToString());
            hso.giaTocNenTKag = giaTocNenTKag;
            hso.q = hsUngXuq;
            Sd = hso.TinhSd(chuKy, S, Tb, Tc, Td);

            //  MessageBox.Show("chuly ="+ chuKy + ";s =" + S+ ";Tb =" + Tb+ ";Tc =" + Tc+ ";Td =" + Td+" i="+i + " q=" + hsUngXuq + " ag=" + giaTocNenTKag);
            string tang;
            double mj;//khoi luong tang thep phuong 
            double chuyenViTangj;
            double Sj;//chuyen vi tang
            double mjSj;
            double mjSjSj;
            double Fj;
            double phanTramKLDaoDong;
            double massU=1;
            dataModali(i);
            double chuyenViMai = double.Parse(dataTable.Rows[0]["U" + Phuong.ToString()].ToString());//gia tri chuyen vi tang mai
                                                                                                     //Tong khoi luong

            TongLK(i, soTang, Phuong);
            phanTramKLDaoDong = TinhPhanTramLKHH(sumMjSj, sumMjSjSj, sumMj);
          //  cbxPhuong.Rows.Add(soTang);
            for (int j = 0; j < soTang; j++)//tang j
            {
                tang = dataTable .Rows[j]["Story"].ToString();
                // tang = tabl2.Rows[j]["Story"].ToString();
                //khoi luong tang theo phuong 

          mj  = tabl2.AsEnumerable().Where(c => c.Field<string>("Story") == tang).First().Field<double>("Mass" + Phuong.ToString());


           
               // mj = double.Parse(tabl2.Rows[j]["Mass" + Phuong.ToString()].ToString());//dang sai =>linq = mAss + phuowng where 

                //tinh ChuyenVi tuong doi cac tang 
                chuyenViTangj = double.Parse(dataTable.Rows[j]["U" + Phuong.ToString()].ToString());
          //  massU = double.Parse(tabl1.Rows[j]["U" + Phuong.ToString()].ToString());////////
                Sj = chuyenViTangj / chuyenViMai;
                //tinh  mj*Sj
                mjSj = mj * Sj;
                //tinh  mj*Sj*Sj
                mjSjSj = mjSj * Sj;

                Fj = mj * Sd * Sj * sumMjSj / sumMjSjSj;
                fj[j] = Fj;//
                           //luu gia tri vao bang
              
                dt.Rows.Add(Phuong, 0, i,massU, phanTramKLDaoDong, 1, tang, mj, Sj, mjSj, mjSjSj, Fj, sumMj, sumMjSj, sumMjSjSj, Sd);
               

            }
            dgvData.DataSource = dt;
        }
        DataTable dataTable = new DataTable();
        private DataTable dataModali(int i)
        {//lay Gia tri du lieu cac tang  theo tung Modal
            dataTable.Clear();
            dataTable = (from u in tabl3.AsEnumerable()
                         where u.Field<string>("CaseCombo") == "Modal " + i.ToString()
                         select u).CopyToDataTable();
            return dataTable;
        }
        private void TongLK(int i, int soTang, Char Phuong)
        {
            sumMj = 0;
            sumMjSj = 0;
            sumMjSjSj = 0;
            double mj;//khoi luong tang thep phuong 
            double chuyenViTangj;
            double Sj;//chuyen vi tang
            double mjSj;
            double mjSjSj;
            string tang;
            double chuyenViMai = double.Parse(dataTable.Rows[0]["U" + Phuong.ToString()].ToString());//gia tri chuyen vi tang mai
            for (int j = 0; j < soTang; j++)//tang j
            {
                tang = dataTable.Rows[j]["Story"].ToString();
              //  mj = double.Parse(tabl2.Rows[j]["Mass" + Phuong.ToString()].ToString());
               mj = tabl2.AsEnumerable().Where(c => c.Field<string>("Story") == tang).First().Field<double>("Mass" + Phuong.ToString());
                chuyenViTangj = double.Parse(dataTable.Rows[j]["U" + Phuong.ToString()].ToString());
                Sj = chuyenViTangj / chuyenViMai;
                mjSj = mj * Sj;
                mjSjSj = mjSj * Sj;
                mjSj = mj * Sj;
                mjSjSj = mjSj * Sj;
                sumMj += mj;
                sumMjSj += mjSj;
                sumMjSjSj += mjSjSj;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
        
          
           

        }

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  cbxPhuong.Rows.Clear();
            dgvData.Columns.Clear();
            char phuong = char.Parse(comboBox1.Text);
           
          
            int mode = int.Parse(cbx.Text.Substring(4, cbx.Text.Length - 4));
            var sds = from f in dt.AsEnumerable()
                      where f.Field<sbyte>("mode") == mode && f.Field<char>("phuong") == phuong// &&f.Field<double>("KLHuuHieu")>=5
                      select f;


            dgvData.DataSource = sds.CopyToDataTable();
         

        }

        //DataTable x = new DataTable();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            addlistMode();
            cbx_SelectedIndexChanged(sender, e);

        }
        private void addlistMode()
        { 
            // dataXY = new bool[tabl1.Rows.Count, 2];
           listModeXY.Clear();
            cbx.Items.Clear();
            for (int i = 0; i < dgvPPUDD.Rows.Count; i++)
            {
                  modeXY.x= Convert.ToBoolean(dgvPPUDD["phuongX", i].Value);
                   modeXY.y= Convert.ToBoolean(dgvPPUDD["phuongY", i].Value);
                modeXY.mode = Convert.ToUInt16( dgvPPUDD["id", i].Value.ToString());
                modeXY.chuky = Convert.ToDouble(dgvPPUDD["t", i].Value.ToString());
                listModeXY.Add(modeXY);

                if (listModeXY[i].x == true && comboBox1.Text == "X")
                {
                    cbx.Items.Add("Mode" +listModeXY[i].mode.ToString());
                }
                else if (listModeXY[i].y == true && comboBox1.Text == "Y")
                {
                    cbx.Items.Add("Mode" + listModeXY[i].mode.ToString());
                }

            }
          
            //for (int i = 0; i < tabl1.Rows.Count; i++)
            //{
            //    cbx.Items.Add("Mode" + tabl1.Rows[i]["Mode"].ToString());

            //}
            cbx.SelectedIndex = 0;

         
        }
       
        byte click = 1;
        private void picView_Click(object sender, EventArgs e)
        {
            if (click % 2 == 0)
            {
                dgvData.Visible = false;
                this.Width = picView.Location.X + picView.Width + 20;
            }
            else
            { 
                dgvData.Visible = true;
                this.Width = picView.Location.X + dgvPPUDD.Width + 100;

            }
            click++;
        }

        private void FormClose()
        {
            cnn = null;

    ada = null;
            tabl1
                = tabl2
                = tabl3 = null;
          dtSummary = null;
           
            GC.Collect();
            this.Dispose();
           
    }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkRemoveMinDDD_CheckedChanged(object sender, EventArgs e)
        {
            
      
            if(chkRemoveMinDDD.Checked == true)
            {

                for (int i = 0; i < 12; i++)
                {
                    dgvPPUDD["phuongX", i].Value = false;
                    dgvPPUDD["phuongY", i].Value = false;
                }
                GetDangDD('X');
                GetDangDD('Y');

            }

        }

        private void txtMinKLHH_TextChanged(object sender, EventArgs e)
        {
            if(txtMinKLHH.Text != "" )
            {
              //   comboBox1.Items.Clear(); //nhasp
             chkRemoveMinDDD_CheckedChanged(sender, e);
            }
          
           
        }

       
    }
}
