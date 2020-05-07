using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Management;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
namespace EarthQuake
{

    public partial class frmMain : System.Windows.Forms.Form
    {

        private string softWareName = "EarthQuake - Phần mềm tính toán động đất";
        DataTable tablePPPhoPhanUng = new DataTable();
        Xuly.NenDatA nenDatA = new Xuly.NenDatA();
        Xuly.NenDatB nenDatB = new Xuly.NenDatB();
        Xuly.NenDatC nenDatC = new Xuly.NenDatC();
        Xuly.NenDatD nenDatD = new Xuly.NenDatD();
        Xuly.NenDatE nenDatE = new Xuly.NenDatE();
        TinhHeSo tinhHeSo = new TinhHeSo();

        public double S { get; set; }
        public double Tb { get; set; }
        public double Tc { get; set; }
        public double Td { get; set; }
        public double Sd { get; set; }
        const double beta = 0.2;
        private string fileName = null;
        /// frmSPT fSPT = new frmSPT();
        const double g = 9.81;
        double giaTocNenQuyDoiagr1;
        double giaTocNenThamChieuagr;//=agr1*g
        double hsQuanTrongg1;//g1
        public double giaTocNenTKag { get; set; }//=agr*g1
        public double hsUngXuq { get; set; }//=qo*kw>=1.5

        public frmMain()
        {
            InitializeComponent();
            this.Text = softWareName;
            txtChuKy.ReadOnly = true;

            setdgvThongSo();


        }
        string strlink = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.mdb";
        private void frmMain_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            createTablePPPhoPhanUng();
            // licenseToolStripMenuItem_Click(sender, e);//ktra key
            //Goi gia tri nguoi dung cai dat
            // Properties.Settings.Default.Reload();

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


            cbxNenDat.SelectedIndex = 2;
            cbxHsQuanTrong.SelectedIndex = 2;
            cbxCapDeo.SelectedIndex = 0;
            cbxKetCau.SelectedIndex = 0;

            cbxTinh.Select();

        }
        private void setdgvThongSo()
        {
            dgvThongSo.Rows.Add(10);
            dgvThongSo.RowHeadersWidth = 50;
            for (int i = 0; i < 10; i++)
            {
                dgvThongSo.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            dgvThongSo["thongSo", 0].Value = "Gia tôc nền quy đổi";
            dgvThongSo["thongSo", 1].Value = "Gia tôc nền agr(m/s2)";
            dgvThongSo["thongSo", 2].Value = "Hệ số tầm quan trọng (gama1)";
            dgvThongSo["thongSo", 3].Value = "Gia tôc nền thiết kế ag (m/s2)";
            dgvThongSo["thongSo", 4].Value = "Thông số Xác định phổ S";
            dgvThongSo["thongSo", 5].Value = "Thông số Xác định phổ Tb(s)";
            dgvThongSo["thongSo", 6].Value = "Thông số Xác định phổ Tc(s)";
            dgvThongSo["thongSo", 7].Value = "Thông số Xác định phổ Td(s)";
            dgvThongSo["thongSo", 8].Value = "Hệ số ứng xử,q";

        }

        private void cbxTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection cnn1 = new OleDbConnection(strlink);
            if (cnn1.State != ConnectionState.Open)
                cnn1.Open();
            string strQuery1 = "SELECT huyen FROM Data where Tinh like '" + cbxTinh.Text + "'";//  where ID = " + cbxTinh.SelectedValue;
            OleDbDataAdapter ada1 = new OleDbDataAdapter(strQuery1, cnn1);

            DataTable tabl1 = new DataTable();
            ada1.Fill(tabl1);
            cnn1.Dispose();
            cnn1.Close();

            cbxHuyen.DataSource = tabl1;
            cbxHuyen.DisplayMember = "Huyen";
            // cbxHuyen.ValueMember = "ID";

        }

        private void updateThongSo()
        {
            dgvThongSo["giaTri", 0].Value = giaTocNenQuyDoiagr1.ToString();
            dgvThongSo["giaTri", 1].Value = Math.Round(giaTocNenThamChieuagr, 4).ToString();
            dgvThongSo["giaTri", 2].Value = hsQuanTrongg1.ToString();
            dgvThongSo["giaTri", 3].Value = Math.Round(giaTocNenTKag, 4).ToString();
            dgvThongSo["giaTri", 4].Value = S.ToString();
            dgvThongSo["giaTri", 5].Value = Tb.ToString();
            dgvThongSo["giaTri", 6].Value = Tc.ToString();
            dgvThongSo["giaTri", 7].Value = Td.ToString();
            dgvThongSo["giaTri", 8].Value = hsUngXuq.ToString();
            KlDongDat();
        }
        frmSPT fSPT = new frmSPT();
        private void llab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fSPT.eventSPT += FSPT_eventSPT;
            fSPT.ShowDialog();
        }
        private double FSPT_eventSPT(double spt)
        {
            llab.Text = "SPT = " + spt.ToString();
            selectNenDat(spt);
            return spt;
        }

        private void selectNenDat(double spt)
        {
            if (spt > 15 && spt <= 50)
            {
                cbxNenDat.Text = "C";
            }
            else if (spt > 50)
            {
                cbxNenDat.Text = "B";
            }
            else
            {
                llab.Text = "SPT";
            }
        }

        private void cbxNenDat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxNenDat.Text)
            {
                case "A":
                    {
                        S = nenDatA.getS();
                        Tb = nenDatA.getTb();
                        Tc = nenDatA.getTc();
                        Td = nenDatA.getTd();

                        break;
                    }
                case "B":
                    {
                        S = nenDatB.getS();
                        Tb = nenDatB.getTb();
                        Tc = nenDatB.getTc();
                        Td = nenDatB.getTd();

                        break;
                    }
                case "C":
                    {
                        S = nenDatC.getS();
                        Tb = nenDatC.getTb();
                        Tc = nenDatC.getTc();
                        Td = nenDatC.getTd();

                        break;
                    }
                case "D":
                    {
                        S = nenDatD.getS();
                        Tb = nenDatD.getTb();
                        Tc = nenDatD.getTc();
                        Td = nenDatD.getTd();

                        break;
                    }
                case "E":
                    {
                        S = nenDatE.getS();
                        Tb = nenDatE.getTb();
                        Tc = nenDatE.getTc();
                        Td = nenDatE.getTd();

                        break;
                    }
                default:
                    break;
            }


            updateThongSo();

        }

        private void cbxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OleDbConnection cnn = new OleDbConnection())
            {
                cnn.ConnectionString = strlink;
                if (cnn.State != ConnectionState.Open)
                    cnn.Open();

                string strQuery = "SELECT Data.HUYEN, Data.[GIA TOC NEN] FROM Data WHERE((Data.HUYEN)= " + "\'" + cbxHuyen.Text + "\')";
                OleDbDataAdapter ada = new OleDbDataAdapter(strQuery, cnn);

                DataTable tabl = new DataTable();
                ada.Fill(tabl);
                cnn.Dispose();
                cnn.Close();
                giaTocNenQuyDoiagr1 = double.Parse(tabl.Rows[0]["gia toc nen"].ToString());
                giaTocNenThamChieuagr = giaTocNenQuyDoiagr1 * g;
                giaTocNenTK();
                updateThongSo();



            }
        }

        private void cbxHsQuanTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            double.TryParse(cbxHsQuanTrong.Text, out hsQuanTrongg1);

            giaTocNenTK();
            updateThongSo();
        }
        private double giaTocNenTK()
        {

            return giaTocNenTKag = giaTocNenThamChieuagr * hsQuanTrongg1;


        }

        private void KlDongDat()
        {
            string doDongDat;
            string KLTinhToan;
            if (giaTocNenTKag > 0.08 * g)
            {
                doDongDat = "Mạnh";
                KLTinhToan = "Phải tính toán + cấu tạo kháng chấn";
            }
            else if (giaTocNenTKag > 0.04 * g)
            {
                doDongDat = "Yếu";
                KLTinhToan = "Chỉ cần cấu tạo kháng chấn";
            }
            else if (giaTocNenTKag < 0.04 * g)
            {
                doDongDat = "Rất Yếu";
                KLTinhToan = "Không cần thiết kế kháng chấn";
            }
            else
            {
                doDongDat = "fdfd";
                KLTinhToan = null;
            }
            dgvThongSo["giaTri", 9].Value = doDongDat;
            dgvThongSo["thongSo", 9].Value = KLTinhToan;

        }
        private double hesoUngXu()
        {
            hsUngXuq = tinhHeSo.Calq(chkMatDungDD.Checked, cbxCapDeo.Text, cbxKetCau.Text, double.Parse(txtPhaHoaiKw.Text));
            updateThongSo();

            return hsUngXuq;

        }

        private void chkMatDungDD_CheckedChanged(object sender, EventArgs e)
        {
            hesoUngXu();
        }

        private void cbxKetCau_SelectedIndexChanged(object sender, EventArgs e)
        {

            hesoUngXu();
        }

        private void cbxCapDeo_SelectedIndexChanged(object sender, EventArgs e)
        {
            hesoUngXu();
        }

        private void txtPhaHoaiKw_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hesoUngXu();
            }
            catch (Exception)
            {


            }

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {


            
            PPPhoPhanUng();
            notSortDataGrid(dgvKQ);


        }
        private void createTablePPPhoPhanUng()
        {
            tablePPPhoPhanUng.Columns.Add("chuKy", typeof(double));
            tablePPPhoPhanUng.Columns.Add("Sd", typeof(double));
        }
        private void PPPhoPhanUng()
        {
            dgvKQ.DataSource = null;
            tablePPPhoPhanUng.Rows.Clear();
            double T = -0.1;
            // dgvKQ.Rows.Add(101);

            //   dgvKQ.RowHeadersWidth = 60;
            for (int i = 0; i < 101; i++)
            {


                T += 0.1;
                tinhHeSo.giaTocNenTKag = giaTocNenTK();

                Sd = tinhHeSo.TinhSd(T, S, Tb, Tc, Td);
                tablePPPhoPhanUng.Rows.Add(T.ToString("N1"), Sd.ToString("N4"));

            }
            // dgvKQ.Columns.Clear();
            
            dgvKQ.DataSource = tablePPPhoPhanUng;
        }

        private void radPPU_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dgvKQ.DataSource = null;
            dgvKQ.DataSource = tablePPPhoPhanUng;
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmLicense fLicense = new frmLicense();
            fLicense.eKey += FLicense_eKey;
            fLicense.ShowDialog();



        }

        private string FLicense_eKey(string key)
        {
            return key;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            data.Clear();
            tablePPPhoPhanUng.Clear();
            ModeXY.Clear();
            dgvKQ.DataSource = null;
            // dgvKQ.Refresh();
            cbxPhuong.Items.Clear();
            cbxDangDD.Items.Clear();
            fileName = null;
            this.Text = softWareName;


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public delegate void HeSo(double S, double tb, double tc, double td, double giatocnenTkag, double heSoungXuq);

        private void radPPUDaoDong_Click(object sender, EventArgs e)
        {

            frmPPUDaoDong fPPUDD = new frmPPUDaoDong();
            HeSo hso = new HeSo(fPPUDD.LayHeSo);
            hso(S, Tb, Tc, Td, giaTocNenTKag, hsUngXuq);
            fPPUDD.eventTable += FPPUDD_eventTable;


            fPPUDD.ShowDialog();
            panel1.Visible = true;



        }



        private void fillcbxMode(DataTable table)
        {
           
            cbxDangDD.Items.Clear();
            for (int i = 0; i < ModeXY.Count; i++)
            {
                //   cbxDangDD.Items.Add("Mode" + table.Rows[i]["Mode"].ToString());



                if (ModeXY[i].x == true && cbxPhuong.Text == "X")
                {
                    cbxDangDD.Items.Add("Mode" + ModeXY[i].mode.ToString());
                }
                else if (ModeXY[i].y == true && cbxPhuong.Text == "Y")
                {
                    cbxDangDD.Items.Add("Mode" + ModeXY[i].mode.ToString());
                }

            }
            cbxDangDD.SelectedIndex = 0;

            //cbxMode_SelectedIndexChanged( sender, e);
        }

        DataTable data = new DataTable();
        //DataTable dataTable1 = new DataTable();
        //DataTable dataTable2 = new DataTable();
        //DataTable dataTable3 = new DataTable();
        List<ModeXY> ModeXY = new List<ModeXY>();
       
        private void FPPUDD_eventTable(DataTable table, List<ModeXY> listModeXY)
        {
            dgvKQ.Columns.Clear();
            ModeXY = listModeXY;
            data = table;

            cbxPhuong.Items.Clear();
       
            cbxPhuong.Items.Add('X');
            cbxPhuong.Items.Add('Y');

            dgvKQ.DataSource = table;

            //  cbxPhuong_SelectedIndexChanged( sender, e);

            //cbxPhuong.SelectedIndex = cbxPhuong.SelectedIndex == 0 ? 1 : 0;
            cbxPhuong. ResetText();
           cbxDangDD.ResetText();
            txtChuKy.ResetText();
        }


        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout About = new frmAbout();
            About.ShowDialog();
        }

        private void mdbToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radPPU.Checked)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "All files *.txt| *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
              
                    FileStream fileStream = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    int i = 0;
                    while (i < tablePPPhoPhanUng.Rows.Count)
                    {
                        streamWriter.WriteLine(tablePPPhoPhanUng.Rows[i]["chuKy"].ToString() + "\t" + tablePPPhoPhanUng.Rows[i]["sd"].ToString());
                        i++;
                    }

                    streamWriter.Flush();
                    fileStream.Close();
                    MessageBox.Show("Đã xuất file text xong !");
                    Process.Start("explorer.exe", "/select," + save.FileName);
                }

            }
            else
            {
                MessageBox.Show($"-Phần mềm chỉ hỗ trợ xuất file text cho phương pháp tính giá trị phổ phản ứng \n-Click chọn phương pháp tính giá trị phổ phản ứng để xuất file text ", "Wind Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbxPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {


            fillcbxMode(data);

            //cbxDangDD.Items.Clear();
            //for (int i = 0; i < 12; i++)
            //{



            //    if (dataXY[i, 0] == true && cbxPhuong.Text == "X")
            //    {
            //        cbxDangDD.Items.Add("Mode" + tabl1.Rows[i]["Mode"].ToString());
            //    }
            //    else if (dataXY[i, 1] == true && cbxPhuong.Text == "Y")
            //    {
            //        cbxDangDD.Items.Add("Mode" + tabl1.Rows[i]["Mode"].ToString());
            //    }
        }

        private void cbxDangDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvKQ.Columns.Clear();


            char phuong = char.Parse(cbxPhuong.Text.ToString());
            int mode = int.Parse(cbxDangDD.Text.Substring(4, cbxDangDD.Text.Length - 4));
            var sds = from f in data.AsEnumerable()
                      where f.Field<sbyte>("mode") == mode && f.Field<char>("phuong") == phuong
                      select f;// new {  Tang = f.Field<string>("tang"), Fj = f.Field<double>("Fj") };


            dgvKQ.DataSource = sds.CopyToDataTable();
            HidenColumns();
            notSortDataGrid(dgvKQ);
            txtChuKy.Text = ModeXY[mode-1].chuky.ToString("N4");
        }

        private void HidenColumns()
        {
            dgvKQ.Columns["dangDD"].Visible = false;
            dgvKQ.Columns["MassU"].Visible = false;
            dgvKQ.Columns["KLHuuHieu"].Visible = false;
            dgvKQ.Columns["tongKLHuuHieu"].Visible = false;
            dgvKQ.Columns["mj"].Visible = false;
            dgvKQ.Columns["sj"].Visible = false;
            dgvKQ.Columns["mjsj"].Visible = false;
            dgvKQ.Columns["mjsjsj"].Visible = false;
            dgvKQ.Columns["dangDD"].Visible = false;
            dgvKQ.Columns["dangDD"].Visible = false;

            dgvKQ.Columns["summj"].Visible = false;
            dgvKQ.Columns["summjsj"].Visible = false;
            dgvKQ.Columns["summjsjsj"].Visible = false;
            dgvKQ.Columns["sd"].Visible = false;

            //fomat column Fj
            DataGridViewCellStyle fomatFj = new DataGridViewCellStyle();
            fomatFj.Format = "N4";
            dgvKQ.Columns["Fj"].DefaultCellStyle = fomatFj;
               





            //dt.Columns.Add("phuong", typeof(char));
            //dt.Columns.Add("dangDD", typeof(int));
            //dt.Columns.Add("mode", typeof(sbyte));
            //dt.Columns.Add("MassU", typeof(double));
            //dt.Columns.Add("KLHuuHieu", typeof(double));
            //dt.Columns.Add("tongKLHuuHieu", typeof(double));
            //dt.Columns.Add("tang", typeof(string));
            //dt.Columns.Add("mj", typeof(double));
            //dt.Columns.Add("sj", typeof(double));
            //dt.Columns.Add("mjsj", typeof(double));
            //dt.Columns.Add("mjsjsj", typeof(double));
            //dt.Columns.Add("Fj", typeof(double));

            //dt.Columns.Add("summj", typeof(double));
            //dt.Columns.Add("summjsj", typeof(double));
            //dt.Columns.Add("summjsjsj", typeof(double));
            //dt.Columns.Add("sd", typeof(double));
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All file(*.eql)|*.eql";
            if (save.ShowDialog() == DialogResult.OK)
            {
                fileName = save.FileName;
                this.Text = softWareName +"-[" +fileName +"]";
            }
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUnit unitSetting = new FormUnit();
            unitSetting.ShowDialog();
        }

        private void dgvKQ_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            notSortDataGrid( dgvKQ);
            
        }

        internal static void notSortDataGrid(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ngày phát hành: 10/2019\n\nTiêu chuẩn áp dụng TCVN 9386:2012\n\nVersion 0.9","About EarthQuake");
        }
    }
}
