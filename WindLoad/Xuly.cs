using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;//namespace input and output
using System.Text;
using System.Xml.Serialization;
namespace WindLoad
{
   
    class XuLy
    {//Tinh k=1.884*(z/zt)^2m ,m va zt phu thuoc va dang dia hinh 
     //Công thức xác định các hệ số này được trình bày trong phụ lục A.2 và A.3 của TCXD 229:1999
        Info info = new Info();
        private static double zt, m, k, result;
        public static double Tinhk(double z, char DH)
        {
            if (z >= 0)
            {
                switch (DH)
                {
                    case 'A':
                        {
                            zt = 250;
                            m = 0.07;

                            break;
                        }
                    case 'B':
                        {
                            zt = 300;
                            m = 0.09;

                            break;
                        }
                    case 'C':
                        {
                            zt = 400;
                            m = 0.14;

                            break;
                        }
                }
                k = 1.844 * Math.Pow(z / zt, 2 * m);
                result = (k <= 1.84 && z <= 400) ? k : 1.840;//toan tu 3 ngoi kien tra k<= 1.84-> k | -> 1.84

            }
            else result = 0;
            return Math.Round(result, 3);
        }

        
            public  void DeSerializer()
            {
                FileStream fs = new FileStream("Setting.MauDepChoai", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                XmlSerializer deseri = new XmlSerializer(typeof(Info));
                //deseri.Deserialize(fs);

                info = (Info)deseri.Deserialize(fs);//ep kieu ve obj

                fs.Close();

            


        }


    }



    //Tinh Gia tri gioi han dao dong cua tan so rieng fL(pthuoc vung gio, loai cong trinh- o day la BTCT denta=0.3
    class TanSofL
    {
        //float[] fL_ALGio;
        private static double fL, ALG;
        public static double tanSofL(string vGio, string dk)
        {
            switch (vGio)
            {
                case "I":
                    {
                        fL = 1.1;
                        ALG = 0.65;
                        break;
                    }
                case "II":
                    {
                        fL = 1.3;
                        ALG = 0.95;
                        break;
                    }
                case "III":
                    {
                        fL = 1.6;
                        ALG = 1.25;
                        break;
                    }
                case "IV":
                    {
                        fL = 1.7;
                        ALG = 1.55;
                        break;
                    }
                case "V":
                    {
                        fL = 1.9;
                        ALG = 1.85;
                        break;
                    }
            }
            return dk == "fL" ? fL : ALG;



        }

    }


}



