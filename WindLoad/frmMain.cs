using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;//namespace input and output
using System.Xml.Serialization;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Serialization;
using System.Drawing.Text;

namespace WindLoad
{
    public partial class frmMain : Form
    {
        Info info = new Info();
        XuLy xuly = new XuLy();
        public string fileName;
        public string softName;
        public double Wo,n;

        public frmMain()
        {
            //Gọi ham SplashScreen
            // Thread t = new Thread(new ThreadStart(SplashScreen));
            // t.Start();//khoi đong t
            //Thread.Sleep(4000);
       
            InitializeComponent();//Khoi tao
                                  // t.Abort();//hủy t
            frmQuickStart qStart = new frmQuickStart();

            qStart.EveOpen += new EventHandler(QStart_EveOpen);
            qStart.ShowDialog(); 

            softName = this.Text;
            dgvThongTin.RowHeadersVisible = dgvGioDong.RowHeadersVisible = false;
            dgvThongso.Rows.Add("Vùng gió");
            dgvThongso.Rows.Add("Dạng địa hình");
            dgvThongso.Rows.Add("Giá trị áp lực gió Wo(kN/m2)");
            dgvThongso.Rows.Add("Giá trị giới hạn của tần số fL");
            int rowNumber = 1;
            foreach (DataGridViewRow row in dgvThongso.Rows)
            {
                //if (row.IsNewRow) continue;
                row.HeaderCell.Value = rowNumber.ToString();

                rowNumber++;
            }
            //cbxTinh.Text = "Hà Nội";
            cbxAnToan.Text = "1.2";
            
            labNhoCao.Text = "Phần nhô lên so với tầng mái\ncủa công trình(m):";
            cbxUnit.Text = "KN-m";
            dgvGioTinh.AllowUserToResizeRows = false;//Khong cho phep sua chieu cao hang
            cbxQuyDoi.DropDownStyle = ComboBoxStyle.DropDownList;//tao kieu style so xuong cho cbx
            cbxDiaHinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTinh.Select();//Dat con tro o cbxTinh
            //string[] diaHinh = new string[] { "A", "B", "C" };
            //char[] diaHinh = new char[] {'A','B','C'};
            //cbxDiaHinh.Items.AddRange(diaHinh);
            cbxDiaHinh.Items.AddRange(new object[] { "A", "B", "C" });
            //
            //dgvGioDong.MaximumSize = tabControl.Width;
            cbxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxQuyDoi.SelectedIndex = 1;
            panel1.Visible =panel2.Visible= false;
            





        }



        //tao ham khoi đong goi frmStart
        private void SplashScreen()
        {
            Application.Run(new frmStart());
        }
        private void QStart_EveOpen(object sender, EventArgs e)
        {
            openFile();
        }
        private void btnNhapFilemdb_Click(object sender, EventArgs e)
        {

            try
            {
                

                frmFilemdb mdb = new frmFilemdb();
                mdb.ShowDialog();
                //frmFilemdb.tabl.ToString();
                tang = frmFilemdb.tabl1.Rows.Count - 1;
                if (tang > 0)
                {
                    dgvThongTin.Rows.Clear();
                    dgvThongTin.Rows.Add((int)tang);
                    txtH.Text = frmFilemdb.tabl3.Rows[0]["minn"].ToString();
                    //Add columns
                    for (int i = 0; i <= tang; i++)
                    {
                        dgvThongTin["STT", i].Value = i + 1;
                        dgvThongTin["Tang", i].Value = frmFilemdb.tabl1.Rows[i]["Name"].ToString();
                        dgvThongTin["Ht", i].Value = frmFilemdb.tabl1.Rows[i]["Height"].ToString();

                        dgvThongTin["Lx", i].Value = frmFilemdb.tabl2.Rows[0]["Maxx"].ToString();
                        dgvThongTin["Ly", i].Value = frmFilemdb.tabl2.Rows[1]["Maxx"].ToString();
                    }
                    frmFilemdb.tabl1 = null;
                    frmFilemdb.tabl3 = null;

                }
            }
            catch (Exception)
            {

            }
        }
        public double tang, cao;
        frmNhapTay ntay;
        // public delegate void truyen(object sender, EventArgs e);
        private void btnNhapThongSo_Click(object sender, EventArgs e)
        {

            ntay = new frmNhapTay(this);
            ntay.ShowDialog();

            //truyen tr = new truyen(ntay.btnOK_Click);
            themTang(tang, cao);
            // dgvThongTin.Rows.Add((int)tang);
            //frmNhapTay NhapTay = new frmNhapTay();
            ////NhapTay.Show();
            //NhapTay.ShowDialog();

            //Hien thi tren dgvThongTin
            try
            {
                //Kiem tra so tang nhap vao
                //byte tang = frmNhapTay.soTang;
                //double cao = frmNhapTay.caoTang;


                //else MessageBox.Show("Nhập quá nhiều Tầng / Sai du lieu  ", "WindLoad");

            }
            catch { MessageBox.Show("So Tang > 0 / Sai du lieu ", "WindLoad"); }

        }

        private void themTang(double tang, double cao)
        {
            if (tang < 10000 && tang > 0 && cao > 0)
            {
                dgvThongTin.Rows.Clear();
                dgvThongTin.Rows.Add((int)tang);
                for (int i = 0; i < tang; i++)
                {
                    dgvThongTin[0, i].Value = i + 1;//STT
                    dgvThongTin[1, i].Value = "Tầng " + (tang - i);//Tang
                    dgvThongTin[2, i].Value = cao;//Ht
                    dgvThongTin[3, i].Value = 0;//Lx
                    dgvThongTin[4, i].Value = 0;//Ly
                }
            }
        }
        string strlink = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data\DataWindLoad.mdb";
        private void Main_Load(object sender, EventArgs e)
        {

            //Goi gia tri nguoi dung cai dat
            Properties.Settings.Default.Reload();

            //lay danh sach các tinh
            OleDbConnection cnn = new OleDbConnection(strlink);
            cnn.Open();
            string query = "SELECT DISTINCT tinh from data";
            OleDbDataAdapter ada = new OleDbDataAdapter(query, cnn);
            DataSet dtSet = new DataSet();

            ada.Fill(dtSet, "dsTinh");
            DataTable tabl = new DataTable();
            // //ada.Fill(tabl);
            // tabl = dtSet.Tables["dsTinh"];

            cnn.Dispose();
            cnn.Close();
            cbxTinh.DataSource = dtSet.Tables["dsTinh"];
            cbxTinh.DisplayMember = "Tinh";
            cbxTinh.Text = "Hà Nội";


            
        }

       


        //chon  huyen khi tinh thay doi
        private void cbxTinh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //tra huyen
            OleDbConnection cnn1 = new OleDbConnection(strlink);
            if (cnn1.State != ConnectionState.Open)
                cnn1.Open();
            string strQuery1 = "SELECT * FROM Data where Tinh like '" + cbxTinh.Text + "'";//  where ID = " + cbxTinh.SelectedValue;
            OleDbDataAdapter ada1 = new OleDbDataAdapter(strQuery1, cnn1);

            DataTable tabl1 = new DataTable();
            ada1.Fill(tabl1);
            cnn1.Dispose();
            cnn1.Close();

            cbxHuyen.DataSource = tabl1;
            cbxHuyen.DisplayMember = "Huyen";
           cbxHuyen.ValueMember = "ID";


        }

        public string vungALGio;
        //chon dia hinh khi huyen thay doi
        private void cbxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tra dia hinh
            using (OleDbConnection cnn = new OleDbConnection())
            {
                cnn.ConnectionString = strlink;
                if (cnn.State != ConnectionState.Open)
                    cnn.Open();

                string strQuery = "SELECT* FROM Data where ID = " + cbxHuyen.SelectedValue;
                OleDbDataAdapter ada = new OleDbDataAdapter(strQuery, cnn);

                DataTable tabl = new DataTable();
                ada.Fill(tabl);
                cnn.Dispose();
                cnn.Close();

                cbxDiaHinh.SelectedItem = tabl.Rows[0]["Vung2"].ToString();// lua chon dang dia hinh tuong ung- phai add gia tri truoc



                //cbxDiaHinh.DataSource = tabl;//Cai nay khong cho sua du lieu
                //cbxDiaHinh.DisplayMember = "VUNG2";

                //tra vung gio

                dgvThongso.Rows[0].Cells[1].Value = tabl.Rows[0]["vung"].ToString();
                //Gan gia tri cho cell trong dgvThongso
                dgvThongso.Rows[1].Cells[1].Value = cbxDiaHinh.Text;// ToString();
                                                                    //Tra Gia tri gioi han dao dong cua tan so rieng fL
                vungALGio = tabl.Rows[0]["VUNG1"].ToString();//truyen tam cai string nay


                dgvThongso.Rows[3].Cells[1].Value = TanSofL.tanSofL(vungALGio, "fL");//antSofL(vungALGio);


                //Tinh trị so ap luc gio

                if (chkA.Checked == true)
                {
                    switch (dgvThongso.Rows[0].Cells[1].Value)
                    {
                        case "I-A":
                            {
                                dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG") - 0.1;
                                break;
                            }
                        case "II-A":
                            {
                                dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG") - 0.12;
                                break;
                            }
                        case "III-A":
                            {
                                dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG") - 0.15;
                                break;
                            }
                        default:
                            dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG");
                            break;
                    }

                }
                else dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG");
            }
        }


        //Giam gia trị gio khi dia hinh là dạng dia hinh A
        private void chkA_CheckedChanged(object sender, EventArgs e)
        {
            // cbxHuyen_SelectedIndexChanged(sender, e);
            //string vungALGio  ;

            if (chkA.Checked == true)
            {
                switch (dgvThongso.Rows[0].Cells[1].Value)
                {
                    case "I-A":
                        {
                            dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG") - 0.10;
                            break;
                        }
                    case "II-A":
                        {
                            dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG") - 0.12;
                            break;
                        }
                    case "III-A":
                        {
                            dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG") - 0.15;
                            break;
                        }
                    default:
                        dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG");
                        break;
                }

            }
            else dgvThongso.Rows[2].Cells[1].Value = TanSofL.tanSofL(vungALGio, "ALG");
        }



        //Thoat chuong trinh
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


        private void runF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

           









            int tang = dgvThongTin.Rows.Count - 1;
            // try
            {
                //gio tinh
                //XuLy xl = new XuLy();
                string unit;
                if (cbxQuyDoi.Text == "Tải trọng tập trung (gán vào Diagram)")
                {
                    unit = "(kN)";
                }
                else
                {
                    unit = "(kN /m)";
                }

                //double cao = frmNhapTay.caoTang;
                //frmNhapTay.soTang;
                dgvGioTinh.Rows.Clear();
                dgvGioTinh.Columns.Clear();
                dgvGioTinh.Columns.Add("stt", "STT");
                dgvGioTinh.Columns.Add("tang", "Tầng");
                dgvGioTinh.Columns.Add("ht", "Ht(m)");
                dgvGioTinh.Columns.Add("z", "Z(m)");
                dgvGioTinh.Columns.Add("k", "K");

                dgvGioTinh.Columns.Add("Wxd", "Wx+\n" + unit);
                dgvGioTinh.Columns.Add("Wxh", "Wx-\n" + unit);
                dgvGioTinh.Columns.Add("Wyd", "Wy+\n" + unit);
                dgvGioTinh.Columns.Add("Wyh", "Wy-\n" + unit);

                dgvGioTinh.Columns.Add("wx", "Wx\n" + unit);
                dgvGioTinh.Columns.Add("wy", "Wy\n" + unit);
                //Style Collumns
                DataGridViewCellStyle fomatCell = new DataGridViewCellStyle();
                fomatCell.Format = "N2";
                for (int i = dgvGioTinh.Columns["Wxd"].Index; i < dgvGioTinh.Columns.Count; i++)
                {
                    dgvGioTinh.Columns[i].DefaultCellStyle.Format = fomatCell.Format;
                }
                dgvGioTinh.Columns["wx"].DefaultCellStyle.ForeColor = dgvGioTinh.Columns["wy"].DefaultCellStyle.ForeColor = Color.Red;
                //Width of columns

                dgvGioTinh.Columns["stt"].Width = 50;
                dgvGioTinh.Columns["tang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//fill full
                dgvGioTinh.Columns["ht"].Width = 60;
                dgvGioTinh.Columns["z"].Width = 60;
                dgvGioTinh.Columns["k"].Width = 60;

                dgvGioTinh.Columns["Wxd"].Width = 65;
                dgvGioTinh.Columns["Wxh"].Width = 65;
                dgvGioTinh.Columns["Wyd"].Width = 65;
                dgvGioTinh.Columns["Wyh"].Width = 65;
                dgvGioTinh.Columns["Wx"].Width = 80;
                dgvGioTinh.Columns["Wy"].Width = 80;
               


                dgvGioTinh.Rows.Add(tang);

                //   int a = tang ;
                double zo = -1 * float.Parse(txtH.Text);
                dgvGioTinh["z", tang].Value = zo;
                //Cap nhat thong so tu  dgcThongTin->dgvGioTinh

                //Tinh toan z va k,Wx,Wy
                double zi = 0;

                double  k, H, H1, W,Wxd=0,Wxh=0,Wyd=0,Wyh=0,Wx=0,Wy=0,lx=0,ly=0;
                double ced = frmThietLap.cday;
                double ceh = Math.Abs(frmThietLap.chut);
                double ce = ced + ceh;
                Wo = (double)dgvThongso.Rows[2].Cells["GiaTri"].Value;
                n = double.Parse(cbxAnToan.Text);
                //Gan Htang truoc đe tinh theo rad1- 2 tang truyen ve







                double hti, hti1=0,httb; //httb= 0.5*(hti+hti1)
                double sumZi=0;
                for (int i =tang-1; i >=0;i--)
                {
                    dgvGioTinh["stt", i].Value = dgvThongTin["stt", i].Value;
                    dgvGioTinh["tang", i].Value = dgvThongTin["tang", i].Value;

                    hti =double.Parse( dgvThongTin["Ht", i].Value.ToString());//Ht
                    dgvGioTinh["ht", i].Value = hti;

                   //Tinhzi
                   sumZi += hti;
                    zi = sumZi + zo;
                   dgvGioTinh["z", i].Value = zi;
                    //tinh K
                    k = XuLy.Tinhk(zi, char.Parse(cbxDiaHinh.Text));
                    dgvGioTinh["k", i].Value = k;
                    W = n * Wo * k ;

                    if(rad2.Checked == true)// don toan bo len tang phia tren
                    {

                        Wxd = W * hti * ced;
                        Wxh = W * hti * ceh;
                        Wyd = W * hti * ced;
                        Wyh = W * hti * ceh;
                        Wx = Wxd + Wxh;
                        Wy = Wyd + Wyh;

                        if (cbxQuyDoi.SelectedIndex==1)// gan vao dam bien
                        {

                            dgvGioTinh["wxd", i].Value = Wxd;
                            dgvGioTinh["wxh", i].Value = Wxh;
                            dgvGioTinh["wyd", i].Value = Wyd;
                            dgvGioTinh["wyh", i].Value = Wyh;
                            dgvGioTinh["wx", i].Value = Wx;
                            dgvGioTinh["wy", i].Value = Wy;
                        }
                        else // gan vao tam hinh hoc
                        {
                            lx =double.Parse( dgvThongTin["Lx", i].Value.ToString());
                            ly = double.Parse(dgvThongTin["Ly", i].Value.ToString());
                            dgvGioTinh["wxd", i].Value = Wxd*ly;
                            dgvGioTinh["wxh", i].Value = Wxh*ly;
                            dgvGioTinh["wyd", i].Value = Wyd*lx;
                            dgvGioTinh["wyh", i].Value = Wyh*lx;
                            dgvGioTinh["wx", i].Value = Wx*ly;
                            dgvGioTinh["wy", i].Value = Wy*lx;
                        }
                       

                    }
                    else // tai chia deu sang 2 tang
                    {
                       
                        if (i - 1 >= 0)// tinh tu tang 1 den tang n-1
                        {
                            //chieu cao tang phia tren tang hi
                            hti1 = double.Parse(dgvThongTin["Ht", i - 1].Value.ToString());//Hti
                            dgvGioTinh["wxd", i].Value = hti;
                            dgvGioTinh["wxh", i - 1].Value = hti1;
                            httb = 0.5 * (hti + hti1);
                            Wxd = W * httb * ced;
                            Wxh = W * httb * ceh;
                            Wyd = W * httb * ced;
                            Wyh = W * httb * ceh;
                            Wx = Wxd + Wxh;
                            Wy = Wyd + Wyh;

                            if (cbxQuyDoi.SelectedIndex == 1)// gan vao dam bien
                            {

                                dgvGioTinh["wxd", i].Value = Wxd;
                                dgvGioTinh["wxh", i].Value = Wxh;
                                dgvGioTinh["wyd", i].Value = Wyd;
                                dgvGioTinh["wyh", i].Value = Wyh;
                                dgvGioTinh["wx", i].Value = Wx;
                                dgvGioTinh["wy", i].Value = Wy;
                            }
                            else // gan vao tam hinh hoc
                            {
                                lx = double.Parse(dgvThongTin["Lx", i].Value.ToString());
                                ly = double.Parse(dgvThongTin["Ly", i].Value.ToString());
                                dgvGioTinh["wxd", i].Value = Wxd * ly;
                                dgvGioTinh["wxh", i].Value = Wxh * ly;
                                dgvGioTinh["wyd", i].Value = Wyd * lx;
                                dgvGioTinh["wyh", i].Value = Wyh * lx;
                                dgvGioTinh["wx", i].Value = Wx * ly;
                                dgvGioTinh["wy", i].Value = Wy * lx;
                            }

                            //tinh trieng cho tang mai;


                            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
                            this.Text = installedFontCollection.Families.Length.ToString();
                            foreach (var item in installedFontCollection.Families)
                            {
                                cbxQuyDoi.Items.Add( item.Name);
                            }




                        }
                       

                    }

                    tabControl.SelectedTab = tabControl.TabPages["tabGioTinh"];
                  //  tabControl.SelectedIndex = 1;

                }
            }
            //    double zmax = z + double.Parse(dgvGioTinh["ht", 1].Value.ToString());
            //    dgvGioTinh["z", 0].Value = zmax;

            //    for (int i = a -1; i >= 1; i--)
            //    {

            //        //Cap nhat thong so tu  dgcThongTin->dgvGioTinh

            //        //dgvGioTinh["stt", i].Value = dgvThongTin[0, i].Value.ToString();//STT
            //        //dgvGioTinh["tang", i].Value = dgvThongTin[1, i].Value.ToString();//Tang
            //        //dgvGioTinh["ht", i].Value = dgvThongTin[2, i].Value.ToString();//Ht

            //        dgvGioTinh["stt", i].Value = i;//STT
            //        dgvGioTinh["tang", i].Value = dgvThongTin["tang", i - 1].Value;//Tang

            //        //Tinh z

            //        z = double.Parse(dgvGioTinh.Rows[i].Cells[2].Value.ToString()) + double.Parse(dgvGioTinh[3, i + 1].Value.ToString());
            //        //dgvGioTinh["z", i].Value = z;
            //        //Tinh k=1.884*(z/zt)^2m ,m va zt phu thuoc va dang dia hinh Công thức xác định các hệ số này được trình bày trong phụ lục A.2 và A.3 của TCXD 229:1999

            //        k = XuLy.Tinhk(z, char.Parse(cbxDiaHinh.Text));
            //        dgvGioTinh["k", i].Value = k;
            //        //Tinh Wx,Wy cho truong hop Tap phan bo tren dam bien: Wx =n*Wo*k*h
            //        
            //        Wo = double.Parse(dgvThongso["GiaTri", 2].Value.ToString());

            //        //Kiem tra chieu cao tang cuoi cung de tinh z vaf chieu cao don gio
            //        double zi1 = double.Parse(dgvGioTinh["z", i + 1].Value.ToString());
            //        zi1 = zi1 >= 0 ? zi1 : 0;
            //        //Chieu cao dong gio H;
            //        H = double.Parse(dgvGioTinh["z", i].Value.ToString()) - zi1;//double.Parse(dgvGioTinh["z", i+1].Value.ToString());//H tang duoi

            //        // dgvGioTinh["wx", i].Value = xl.tinhWx(n, Wo, k, H);



            //        //Tinh Wx,Wy cho truong hop tai don ve dm bien

            //        //frmThietLap thietLap = new frmThietLap();

            //        // kiem tra so do truyen gio
            //        double tinhWx = 0, tinhWy = 0, tinhWxd = 0, tinhWxh = 0, tinhWyd = 0, tinhWyh = 0;
            //        if (rad2.Checked == true)//Tinh theo phuong phap tang tu truyen ve
            //        {
            //            switch (cbxQuyDoi.Text)
            //            {

            //                case "Tải trọng phân bố (gán vào dầm biên)":
            //                    {
            //                        tinhWxd = n * Wo * k * H * ced;
            //                        tinhWxh = n * Wo * k * H * ceh;
            //                        tinhWyd = n * Wo * k * H * ced;
            //                        tinhWyh = n * Wo * k * H * ceh;
            //                        tinhWx = n * Wo * k * H * ce;
            //                        tinhWy = n * Wo * k * H * ce;

            //                        break;
            //                    }
            //                case "Tải trọng tập trung (gán vào Diagram)":
            //                    {
            //                        tinhWxd = n * Wo * k * H * ced * double.Parse(dgvThongTin["Ly", i - 1].Value.ToString());//Ly
            //                        tinhWxh = n * Wo * k * H * ceh * double.Parse(dgvThongTin["Ly", i - 1].Value.ToString());//
            //                        tinhWyd = n * Wo * k * H * ced * double.Parse(dgvThongTin["Lx", i - 1].Value.ToString());//Lx
            //                        tinhWyh = n * Wo * k * H * ceh * double.Parse(dgvThongTin["Lx", i - 1].Value.ToString());//



            //                        tinhWx = n * Wo * k * H * ce * double.Parse(dgvThongTin["Ly", i - 1].Value.ToString());//Ly
            //                        tinhWy = n * Wo * k * H * ce * double.Parse(dgvThongTin["Lx", i - 1].Value.ToString());//Lx;
            //                        break;
            //                    }

            //            }

            //        }
            //        else//rad1 duoc chon-Tinh thep so do 2 tang truyen ve
            //        {
            //            //double zi11 = double.Parse(dgvGioTinh["z", i - 1].Value.ToString());//tang tren
            //            double zi11 = double.Parse(dgvGioTinh["z", i - 1].Value.ToString()); ;//tang tren - khong can kiem tra truong hop <0 vi k=0;
            //            double zi12 = double.Parse(dgvGioTinh["z", i].Value.ToString());//tang dang xet
            //            zi12 = zi12 > 0 ? zi12 : 0;
            //            H1 = zi11 - zi12;//dgvGioTinh["ht", i - 1].Value != null ? double.Parse(dgvGioTinh["ht", i - 1].Value.ToString()) : 0;//H tang tren - Sd toan tu 3 ngoi

            //            switch (cbxQuyDoi.Text)
            //            {

            //                case "Tải trọng phân bố (gán vào dầm biên)":
            //                    {

            //                        tinhWxd = n * Wo * k * 0.5 * (H + H1) * ced;
            //                        tinhWxh = n * Wo * k * 0.5 * (H + H1) * ceh;
            //                        tinhWyd = n * Wo * k * 0.5 * (H + H1) * ced;
            //                        tinhWyh = n * Wo * k * 0.5 * (H + H1) * ceh;
            //                        MessageBox.Show(Convert.ToString(H + "--" + H1));
            //                        tinhWx = n * Wo * k * 0.5 * (H + H1) * ce;
            //                        tinhWy = n * Wo * k * 0.5 * (H + H1) * ce;

            //                        break;
            //                    }
            //                case "Tải trọng tập trung (gán vào Diagram)":
            //                    {
            //                        tinhWxd = n * Wo * k * 0.5 * (H + H1) * ced * double.Parse(dgvThongTin["Ly", i - 1].Value.ToString());//Ly
                                    
            //                        tinhWxh = n * Wo * k * 0.5 * (H + H1) * ceh * double.Parse(dgvThongTin["Ly", i - 1].Value.ToString());//
            //                        tinhWyd = n * Wo * k * 0.5 * (H + H1) * ced * double.Parse(dgvThongTin["Lx", i - 1].Value.ToString());//Lx
            //                        tinhWyh = n * Wo * k * 0.5 * (H + H1) * ceh * double.Parse(dgvThongTin["Lx", i - 1].Value.ToString());//


            //                        tinhWx = n * Wo * k * 0.5 * (H + H1) * ce * double.Parse(dgvThongTin["Ly", i - 1].Value.ToString());//Ly
            //                        tinhWy = n * Wo * k * 0.5 * (H + H1) * ce * double.Parse(dgvThongTin["Lx", i - 1].Value.ToString());//Lx;
            //                        break;
            //                    }

            //            }
            //        }
            //        dgvGioTinh["wxd", i].Value = Math.Round(tinhWxd, 2);
            //        dgvGioTinh["wxh", i].Value = Math.Round(tinhWxh, 2);
            //        dgvGioTinh["wyd", i].Value = Math.Round(tinhWyd, 2);
            //        dgvGioTinh["wyh", i].Value = Math.Round(tinhWyh, 2);

            //        dgvGioTinh["wx", i].Value = Math.Round(tinhWx, 2);
            //        dgvGioTinh["wy", i].Value = Math.Round(tinhWy, 2);


            //    }


            //    //Gan lại gia trị tang tren cung khi có phần nhô cao hơn tầng mái
            //    n = double.Parse(cbxAnToan.Text);
            //    double Wxnho, Wynho, Lxnho, Lynho, Wxdnho, Wxhnho, Wydnho, Wyhnho;
            //    Wo = double.Parse(dgvThongso["GiaTri", 2].Value.ToString());
            //    k = XuLy.Tinhk(z, char.Parse(cbxDiaHinh.Text));// z luc nay se nhan gia trị của vong lap cuoi cung~z cua tang tren cung => k la cua tang tren cung
            //    H = double.Parse(txtHtNho.Text.ToString());
            //    Lxnho = double.Parse(txtLxNho.Text);
            //    Lynho = double.Parse(txtLyNho.Text);
            //    if (cbxQuyDoi.Text == "Tải trọng phân bố (gán vào dầm biên)")
            //    {
            //        Wxdnho = n * Wo * k * H * ced;
            //        Wxhnho = n * Wo * k * H * ceh;
            //        Wydnho = n * Wo * k * H * ced;
            //        Wyhnho = n * Wo * k * H * ceh;
                    
            //        Wxnho = n * k * Wo * H * ce;
            //        Wynho = n * k * Wo * H * ce;
            //    }
            //    else//Tải trọng tập trung (gán vào Diagram)
            //    {
            //        Wxdnho = n * Wo * k * H * ced * Lynho;
            //        Wxhnho = n * Wo * k * H * ceh * Lynho;
            //        Wydnho = n * Wo * k * H * ced * Lxnho;
            //        Wyhnho = n * Wo * k * H * ceh * Lxnho;
                  
            //        Wxnho = n * k * Wo * H * ce * Lynho;
            //        Wynho = n * k * Wo * H * ce * Lxnho;
            //    }
            //    dgvGioTinh["wxd", 1].Value = Math.Round(double.Parse(dgvGioTinh["wxd", 1].Value.ToString()) + Wxdnho, 2);
               
            //    dgvGioTinh["wxh", 1].Value = Math.Round(double.Parse(dgvGioTinh["wxh", 1].Value.ToString()) + Wxhnho, 2);
            //    dgvGioTinh["wyd", 1].Value = Math.Round(double.Parse(dgvGioTinh["wyd", 1].Value.ToString()) + Wydnho, 2);
            //    dgvGioTinh["wyh", 1].Value = Math.Round(double.Parse(dgvGioTinh["wyh", 1].Value.ToString()) + Wyhnho, 2);

            //    dgvGioTinh["wx", 1].Value = Math.Round(double.Parse(dgvGioTinh["wx", 1].Value.ToString()) + Wxnho, 2);
            //    dgvGioTinh["wy", 1].Value = Math.Round(double.Parse(dgvGioTinh["wy", 1].Value.ToString()) + Wynho, 2);
            //    tabControl.SelectedIndex = 1;
            //    // huy doi tuong 
            //    dgvGioTinh["z", a].Value = null;
            //    dgvGioTinh.Rows.RemoveAt(0);//Remove(dgvGioTinh.Rows[0]);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Sai dữ liệu\nKiểm tra lại\n:" + ex, "WindLoad", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

            //dgvGioDong.Rows.Clear();
            //dgvGioDong.Columns.Clear();

            // gio dong
            /*
            if (40 < float.Parse(dgvGioTinh["z", 1].Value.ToString()))
            {
                try
                {
                    //Show form Setmode
                    SetMode fSet = new SetMode();
                    fSet.Show();
                    //Add data to cbxMode
                    cbxMode.DataSource = frmFilemdb.tabl4;
                    cbxMode.DisplayMember = "Mode";
                    cbxMode.SelectedIndex = 0;
                    cbxPhuong.Text = "X";

                    dgvGioDong.Columns.Add("stt", "STT");
                    dgvGioDong.Columns.Add("tang", "Tầng");
                    dgvGioDong.Columns.Add("ht", "Ht(m)");
                    dgvGioDong.Columns.Add("zj", "Zj(m)");
                    dgvGioDong.Columns.Add("sj", "Sj(kN)");
                    dgvGioDong.Columns.Add("mj", "Mj(kN.s2/m)");
                    dgvGioDong.Columns.Add("wfj", "WFj(kN)");
                    dgvGioDong.Columns.Add("yij", "Yij");
                    dgvGioDong.Columns.Add("yij.wfj", "Yij.WFj");
                    dgvGioDong.Columns.Add("yij2.wfj", "Yij2.WFj");
                    dgvGioDong.Columns.Add("wpij", "Wpij(kN)");
                    dgvGioDong.Columns.Add("xcm", "XCM");
                    dgvGioDong.Columns.Add("ycm", "YCM");

                    dgvGioDong.Columns["ht"].Width = dgvGioDong.Columns["stt"].Width = 40;
                    dgvGioDong.Columns["xcm"].Width = dgvGioDong.Columns["ycm"].Width = 50;
                    dgvGioDong.Columns["xcm"].DefaultCellStyle.ForeColor = dgvGioDong.Columns["ycm"].DefaultCellStyle.ForeColor = Color.Blue;
                    //Add Rows

                    dgvGioDong.Rows.Add(tang);



                    //Dien du lieu
                    for (int i = 0; i < tang; i++)
                    {
                        dgvGioDong["stt", i].Value = i + 1;//STT
                        dgvGioDong["tang", i].Value = dgvThongTin["tang", i].Value;//Tang
                        dgvGioDong["ht", i].Value = dgvThongTin["ht", i].Value.ToString();//Ht
                        dgvGioDong["zj", i].Value = dgvGioTinh["z", i].Value.ToString();//z
                        dgvGioDong["sj", i].Value = double.Parse(dgvThongTin["Ly", i].Value.ToString()) * double.Parse(dgvThongTin["Ht", i].Value.ToString());//z
                        dgvGioDong["xcm", i].Value = frmFilemdb.tabl5.Rows[i]["xcm"].ToString();
                        dgvGioDong["ycm", i].Value = frmFilemdb.tabl5.Rows[i]["ycm"].ToString();
                        mass(i, cbxPhuong.Text);
                        dgvGioDong["yij", i].Value = chuyenViTuongDoi(i, cbxMode.Text, cbxPhuong.Text).ToString();

                    }
                }
              

                catch
                {

                }
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();


            }
              */
        }


       
     
        private void TinhGioDong()
        {
            //Kiem trà f1 vs fL
            double fL = double.Parse(dgvThongso["Giatri", 3].Value.ToString());
            double f1 = Math.Round(double.Parse(frmFilemdb.tabl4.Rows[0]["Period"].ToString()), 3);
            //f1>fL=> TH1: Wpj= Wj*zetaj*v
            if (f1 > fL)
            {
                MessageBox.Show("f1>fL " + f1.ToString() + "\t" + fL.ToString());

                // tinh zetaj: He so ap luc dong ung voi phan thu j cua cong trinh // Noi suy trong tu bang excel



            }

            else MessageBox.Show("f1<fL" + f1.ToString() + "\t" + fL.ToString());

        }

        private void TinhZeta()
        {

        }


        private void thietLapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThietLap thlap = new frmThietLap();
            thlap.ShowDialog();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }




        //Cap nhat thong tin diahinh tu cbxDiahinh --> gdvThongso
        private void cbxDiaHinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvThongso["GiaTri", 1].Value = cbxDiaHinh.Text;


        }
        private void pic2_Click(object sender, EventArgs e)
        {
            rad2.Select();
        }
        private void pic1_Click_1(object sender, EventArgs e)
        {
            rad1.Select();
        }
        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                runF5ToolStripMenuItem_Click(sender, e);
        }

        //Tudong thay doi gia tri trong cell khi Enter
        private void dgvThongTin_KeyUp(object sender, KeyEventArgs e)
        {
            //Chi so hang va cot hien tai
            int hangIndex = dgvThongTin.CurrentCell.RowIndex;
            int cotIndex = dgvThongTin.CurrentCell.ColumnIndex;
            if (e.KeyData == Keys.Enter)
            {
                for (int i = hangIndex; i < dgvThongTin.RowCount - 1; i++)
                {
                    //Chi thay doi khi cot la cot lx,Ly
                    if (dgvThongTin.Columns[cotIndex].Name == "Lx" | dgvThongTin.Columns[cotIndex].Name == "Ly")
                    {
                        dgvThongTin[cotIndex, i].Value = dgvThongTin[cotIndex, hangIndex - 1].Value.ToString();
                    }
                }
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "|*.xlsx||*.xls";
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {


                    Excel.Application xlapp = new Excel.Application();
                    xlapp.Application.Workbooks.Add(Type.Missing);
                    //xlapp.Columns.ColumnWidth = 30;

                    xlapp.Range["A1"].Value = "Kết quả thành phần gió tĩnh- " + cbxQuyDoi.Text;
                    xlapp.Range["A1:K1"].Merge();
                    for (int i = 0; i < dgvGioTinh.ColumnCount; i++)
                    {
                        xlapp.Cells[2, i + 1] = dgvGioTinh.Columns[i].HeaderText;
                        for (int j = 0; j < dgvGioTinh.RowCount; j++)
                        {
                            xlapp.Cells[j + 3, i + 1] = dgvGioTinh[i, j].Value;

                        }
                    }

                    xlapp.ActiveWorkbook.SaveAs(save.FileName, Type.Missing);
                    xlapp.ActiveWorkbook.Saved = true;
                    save.Dispose();
                    xlapp.Application.Workbooks.Close();
                    xlapp.Quit();
                    MessageBox.Show("We Export to excel have done!", "Thông báo:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch (Exception)
            {
                MessageBox.Show("Loi " + e);
            }





        }


        //Import
        private void accessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNhapFilemdb_Click(sender, e);
        }
        //Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }


        //new
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Kiem tra to save file
            DialogResult a = MessageBox.Show("Bạn có muốn lưu file không ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (a == DialogResult.Yes)
            {
                //Goi save or save as
                saveToolStripMenuItem_Click(sender, e);
                //Refresh
                Clear();
            }

            else if(a== DialogResult.No)
            {
                Clear();
            }
            else if (a == DialogResult.Cancel)
            {

                
            }
            fileName = null;
            this.Text = softName;

        }
        private void Clear() 
            {
            dgvThongTin.Rows.Clear();
            dgvGioTinh.Rows.Clear();
            dgvGioDong.Rows.Clear();
            txtH.Text = "0";
            txtHtNho.Text = "0";
            txtLxNho.Text = "0";
            txtLyNho.Text = "0";
        } 
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void strpExcel_Click(object sender, EventArgs e)
        {
            excelToolStripMenuItem_Click(sender, e);
        }

        private void strpMdb_Click(object sender, EventArgs e)
        {
            btnNhapFilemdb_Click(sender, e);
        }

        private void strpRun_Click(object sender, EventArgs e)
        {
            runF5ToolStripMenuItem_Click(sender, e);
        }

        private void dgvThongso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvThongso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dgvGioTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           // dgvGioTinh.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
        }



        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ColorDialog cd = new ColorDialog();

            //if (cd.ShowDialog() == DialogResult.OK)
            //{
            //    dgvGioTinh.BackgroundColor = cd.Color;}


            //Clipboard.SetText(dgvGioTinh.SelectedCells[].Value.ToString());


        }

        private void bieuDoGioTinh_Click(object sender, EventArgs e)
        {
            Charts chart = new Charts();
            chart.Show();
        }

        private void hDSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Use use = new Use();
            use.ShowDialog();


        }

        private void tlsNhapTay_Click(object sender, EventArgs e)
        {
            btnNhapThongSo_Click(sender, e);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resul = MessageBox.Show("Ban co muon luu va thoat chuong trinh", "Thong bao:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resul == DialogResult.No)
            {

                Properties.Settings.Default.Save();
                // Application.Exit();
            }
            else
            {
                e.Cancel = true;

            }


        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn cài đặt chương trình về mặc dịnh không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.cDay = "0.8";
                Properties.Settings.Default.cHut = "-0.6";
                Properties.Settings.Default.CaoTang = "3.5";
                Properties.Settings.Default.SoTang = "10";
                frmThietLap thietLap = new frmThietLap();



            }
        }

        private void cbxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte rowMode = (byte)cbxMode.SelectedIndex;
            txtPeriod.Text = Math.Round(float.Parse(frmFilemdb.tabl4.Rows[rowMode]["Period"].ToString()), 3).ToString();
        }

        private void cbxPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (i < dgvGioDong.RowCount - 1)
            {
                mass(i, cbxPhuong.Text);
                i++;
            }

        }
        private double chuyenViTuongDoi(int i, string Mode, string direction)
        {

            double tangMai = double.Parse(frmFilemdb.tabl6.Rows[0]["U" + direction].ToString());
            double tangi = double.Parse(frmFilemdb.tabl6.Rows[i]["U" + direction].ToString());

            return Math.Round(tangi / tangMai, 4);
        }
        private void mass(int i, string direction)
        {

            dgvGioDong["mj", i].Value = Math.Round(double.Parse(frmFilemdb.tabl5.Rows[i]["mass" + direction].ToString()), 2);
        }

        private void btnNhapThongSo_MouseHover(object sender, EventArgs e)
        {
            // string objname = ((Button)sender).Name;
            string objname = (sender as Button).Name;
            if (objname == "btnNhapFilemdb")
            {
                btnNhapFilemdb.BackColor = Color.Red;
                btnNhapFilemdb.ForeColor = Color.White;
            }
            else
            {
                btnNhapThongSo.BackColor = Color.Red;
                btnNhapThongSo.ForeColor = Color.White;

            }


        }

        private void btnNhapThongSo_MouseLeave(object sender, EventArgs e)
        {
            string objname = ((Button)sender).Name;

            if (objname == "btnNhapFilemdb")
            {
                btnNhapFilemdb.BackColor = Color.LightGray;
                btnNhapFilemdb.ForeColor = Color.Black;

            }
            else
            {
                btnNhapThongSo.BackColor = Color.LightGray;
                btnNhapThongSo.ForeColor = Color.Black;

            }



            //btnNhapFilemdb.UseVisualStyleBackColor = btnNhapThongSo.UseVisualStyleBackColor = false;
        }



        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            //tabControl.Size= new Size(this.Width, this.Height);


        }

        private void StrpSave_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void StrpOpen_Click(object sender, EventArgs e)
        {

            openFile();
        }

        public void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFile()
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "All WindLoad File(*.wdl) |*.wdl|(All File)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);

                    XmlSerializer deseri = new XmlSerializer(typeof(Info));
                    //deseri.Deserialize(fs);

                    info = (Info)deseri.Deserialize(fs);//ep kieu ve obj
                    cbxTinh.Text = info.Tinh;
                    cbxHuyen.Text = info.Huyen;
                    cbxDiaHinh.Text = info.DiaHinh;
                    cbxAnToan.Text = info.HeSoAnToan;
                    txtH.Text = info.H;
                    txtHtNho.Text = info.HtNho;
                    txtLxNho.Text = info.LxNho;
                    txtLyNho.Text = info.LyNho;
                    //Add new project to dgvThong tin
                    dgvThongTin.Rows.Clear();
                    dgvThongTin.Rows.Add(info.SoTang);

                    for (int i = 0; i < info.SoTang; i++)
                    {
                        dgvThongTin["STT", i].Value = info.STT[i];
                        dgvThongTin["Tang", i].Value = info.TenTang[i];
                        dgvThongTin["Ht", i].Value = info.CaoTang[i];
                        dgvThongTin["Lx", i].Value = info.Lx[i];
                        dgvThongTin["Ly", i].Value = info.Ly[i];
                    }
                    fs.Close();
                    fileName = open.FileName;
                    this.Text = softName + " [" + fileName + " ]";
                }

                else
                {
                    // MessageBox.Show("Đã xảy ra lỗi khi mở file \n Hãy kiểm tra lại ", "WindLoad");
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show("Không mở được file" + exception);
            }
           

        }


        private void saveFile()
        {
            if (fileName==null)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                //saveFile.Title = "Chọn nơi lưu file";
                saveFile.Filter = "All WindLoad File(*.wdl)|*.wdl|All File(*.*)|*.*";
                saveFile.FileName = "WindLoad";
                saveFile.DefaultExt = ".wdl";
                DialogResult d = saveFile.ShowDialog();
                if (d == DialogResult.OK)
                {

                    fileName = saveFile.FileName;


                    nenThongtin();
                    info.Serializer(saveFile.FileName);
                    this.Text = softName + " [" + fileName + " ]";
                }
                else
                {
                    MessageBox.Show("Bạn chưa lưu file !");
                }

            }
            else
            {
               
                nenThongtin();
                info.Serializer(fileName);
                this.Text = softName + " [" + fileName + " ]";
            }

           

        }

        private void nenThongtin()
        {
            info.Tinh = cbxTinh.Text;
            info.Huyen = cbxHuyen.Text;
            info.DiaHinh = cbxDiaHinh.Text;
            info.HeSoAnToan = cbxAnToan.Text;
            info.H = txtH.Text;
            info.HtNho = txtHtNho.Text;
            info.LxNho = txtLxNho.Text;
            info.LyNho = txtLyNho.Text;
            // lays thong tin dau vao
            int soTang = dgvThongTin.RowCount - 1;
            info.SoTang = soTang;
            info.STT = new int[soTang];
            info.TenTang = new string[soTang];
            info.CaoTang = new double[soTang];
            info.Lx = new double[soTang];
            info.Ly = new double[soTang];

            try
            {
                for (int i = 0; i < soTang; i++)
                {
                    info.STT[i] = (int)dgvThongTin["STT", i].Value;
                    info.TenTang[i] = dgvThongTin["Tang", i].Value.ToString();
                    info.CaoTang[i] = double.Parse(dgvThongTin["Ht", i].Value.ToString());
                    info.Lx[i] = double.Parse(dgvThongTin["Lx", i].Value.ToString());
                    info.Ly[i] = double.Parse(dgvThongTin["Ly", i].Value.ToString());
                }

            }
            catch
            {
                MessageBox.Show("Sai dữ liệu \n Kiểm tra lại các thông số của dự án ", " WindLoad");
            }

        }

        private void StrpNew_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void CbxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeUnit();
        }
        private void changeUnit()
        {
            switch (cbxUnit.Text)
            {

                case ("KN-m"):
                    {
                        
                        break;
                    }
                
            }
        }

        private void strpSaveAs_Click(object sender, EventArgs e)
        {
            fileName = null;
            saveFile();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = tabControl.SelectedTab == tabControl.TabPages[2] ? true : false;
            panel2.Visible = tabControl.SelectedIndex == 0 ? false : true;
            // tabControl.SelectedTab= tabControl.TabPages["tabGioDong"];
            //tabControl.TabPages["tabGioDong"] == true;

        }


    }




}

