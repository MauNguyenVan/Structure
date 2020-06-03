using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace EarthQuake
{
    public class Xuly
    {
        public struct NenDatA
        {
            const double S = 1;
            const double Tb = 0.15;
            const double Tc = 0.4;
            const double Td = 2;
            public double getS()
            {
                return S;
            }
            public double getTb()
            {
                return Tb;
            }
            public double getTc()
            {
                return Tc;
            }
            public double getTd()
            {
                return Td;
            }

        }
        public struct NenDatB
        {
            const double S = 1.2;
            const double Tb = 0.15;
            const double Tc = 0.5;
            const double Td = 2;
            public double getS()
            {
                return S;
            }
            public double getTb()
            {
                return Tb;
            }
            public double getTc()
            {
                return Tc;
            }
            public double getTd()
            {
                return Td;
            }
        }
        public struct NenDatC
        {
            const double S = 1.15;
            const double Tb = 0.2;
            const double Tc = 0.6;
            const double Td = 2;
            public double getS()
            {
                return S;
            }
            public double getTb()
            {
                return Tb;
            }
            public double getTc()
            {
                return Tc;
            }
            public double getTd()
            {
                return Td;
            }
        }
        public struct NenDatD
        {
            const double S = 1.35;
            const double Tb = 0.2;
            const double Tc = 0.8;
            const double Td = 2;
            public double getS()
            {
                return S;
            }
            public double getTb()
            {
                return Tb;
            }
            public double getTc()
            {
                return Tc;
            }
            public double getTd()
            {
                return Td;
            }
        }
        public struct NenDatE
        {
            const double S = 1.4;
            const double Tb = 0.15;
            const double Tc = 0.5;
            const double Td = 2;
            public double getS()
            {
                return S;
            }
            public double getTb()
            {
                return Tb;
            }
            public double getTc()
            {
                return Tc;
            }
            public double getTd()
            {
                return Td;
            }
        }



    }
    public class TinhHeSo
    {
        private double qo { get; set; }
        const double beta = 0.2;
        public double Sd { get; set; }
        public double q { get; set; }//he so ung xu
        public double giaTocNenTKag { get; set; }
        /// <summary>
        /// he so qo
        /// 
        /// (5) Khi hệ số au/a1 không được xác định rõ bằng tính toán đối với loại nhà có tính đều đặn trong mặt bằng, 
        /// có thể được sử dụng các giá trị xấp xỉ sau đây của au/a1.
        /// a) Hệ khung hoặc hệ kết cấu hỗn hợp tương đương khung:
        ///- nhà một tầng: au/a1 = 1,1;
        ///- khung nhiều tằng, một nhịp: au/a1 = 1,2;
        ///- khung nhiều tầng, nhiều nhịp hoặc kết cấu hỗn hợp tương đương khung: au/a1 = 1,3.
        ///b) Hệ tường hoặc hệ kết cấu hỗn hợp tương đương với tường:
        ///- hệ tường chỉ có hai tường không phải là tường kép theo từng phương ngang: au/a1 = 1,0;
        ///- các hệ tường không phải là tường kép: au/a1= 1,1;
        ///- hệ kết cấu hỗn hợp tương đương tường, hoặc hệ tường kép: au/a1 = 1,2.
        ///(6) Với loại nhà không có tính đều đặn trong mặt bằng(xem 4.2.3.2), khi không tính toán được giá trị của au/a1 có thể sử dụng giá trị xấp xỉ của nó bằng trị số trung bình của(a) bằng 1,0 và của(b) đã cho trong(5) của điều này.
        /// </summary>



        private double traqo(string capDeo, string loaKetCau)
        {
            const string TH1 = "Hệ khung, hoặc tương đương";
            const string TH2 = "Hệ tường ghép, hoặc tương đương";
            const string TH3 = "Hệ tường không ghép";
            const string TH4 = "Hệ dễ xoắn";
            const string TH5 = "Hệ con lắc ngược";
            // string TH1 = "Hệ khung, hoặc tương đương";
            double qo1 = 0;
            if (capDeo == "DCM")
            {

                switch (loaKetCau)
                {
                    case TH1:
                        {
                            //3*au/a1; 

                            qo1 = 3 * 1.3;
                            break;
                        }
                    case TH2:
                        {
                            //3*au/a1
                            qo1 = 3 * 1.2;
                            break;
                        }
                    case TH3:
                        {
                            qo1 = 3;//=3
                            break;
                        }


                    case TH4:
                        {
                            qo1 = 2;//=2
                            break;
                        }
                    case TH5:
                        {
                            qo1 = 1.5;//=1.5
                            break;

                        }
                    default:
                        {
                            qo1 = 0;
                            break;
                        }

                }

            }
            else if (capDeo == "DCH")
            {


                switch (loaKetCau)
                {
                    case TH1:
                        {
                            //4.5*au/a1; 

                            qo1 = 4.5 * 1.3;
                            break;
                        }
                    case TH2:
                        {
                            //4.5*au/a1
                            qo1 = 4.5 * 1.2;
                            break;
                        }
                    case TH3:
                        {
                            //4*au/a1
                            qo1 = 4 * 1.1;
                            break;
                        }


                    case TH4:
                        {
                            qo1 = 3;//=3
                            break;
                        }
                    case TH5:
                        {
                            qo1 = 2;//=2
                            break;

                        }
                    default:
                        {
                            qo1 = 0;
                            break;
                        }


                }

            }
            return qo1;
        }



        //q=qo*kw>=1.5
        //kw là hệ số phản ánh dạng phá hoại phổ biến trong hệ kết cấu có tường
        public double Calq(bool MDDD, string capDeo, string loaKetCau, double kw)

        {
            if (MDDD == true)
            {
                qo = traqo(capDeo, loaKetCau);
            }
            else
            {
                qo = traqo(capDeo, loaKetCau) * 0.8;
            }

            q = kw * qo >= 1.5 ? kw * qo : 1.5;
            return q;
        }
        public double TinhSd(double T, double S, double Tb, double Tc, double Td)
        {


            double betaag = beta * giaTocNenTKag;

         
            if (T <= Tb)
            {
                Sd = giaTocNenTKag * S * ((double)2 / 3 + T / Tb * (2.5 / q - (double)2 / 3));

            }
            else if (T <= Tc)
            {
                Sd = giaTocNenTKag * S * 2.5 / q;

            }
            else if (T <= Td)
            {
                Sd = Math.Max(giaTocNenTKag * S * 2.5 / q * Tc / T, betaag);

            }
            else //if (T > Td)
            {
                Sd = Math.Max(giaTocNenTKag * S * 2.5 / q * Tc * Td / T / T, betaag);

            }


            return Sd;



        }

    }

    internal static class Files
    {
    internal static void writeFile(string path, object data)
        {
                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, data);
                fs.Close();
            System.Windows.Forms.MessageBox.Show("Saved File");
        }
        internal static object readFile(string path)
        {
            
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
           Object data  = bf.Deserialize(fs);

            fs.Close();
            return data;
        }
    }
   

}
