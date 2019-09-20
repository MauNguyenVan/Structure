using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace WindLoad
{
   public class Info
    {
       
        public string Tinh { get; set; }

        public string Huyen { get; set; }
        public string DiaHinh;
        public string HeSoAnToan;
        public int SoTang;
        public int[] STT ;
        public string[] TenTang;
        public double[] CaoTang;
        public double[] Lx;
        public double[] Ly;
        public string H;
        public string HtNho;
        public string LxNho;
        public string LyNho;
        public void Serializer(string path)//ghifile XML
        {
            //aa = "dfdfd";
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            XmlSerializer seri = new XmlSerializer(typeof(Info));
            seri.Serialize(fs, this);
            fs.Close();


        }
    }
}
