using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataProcessCheck
{
    public class DataConvert
    {
        public void ConvertDirect()
        {
            int a = 34;
            double b = 34.123;
            double c = 34.623;
            int convertInt1 = (int)b; //無條件捨去
            int convertInt2 = (int)c; //無條件捨去

            string sNull = null;
            string stringEmpty = "";


            string s1 = "234";
            string s2 = "00234";
            string s3 = "  00234";
            string s4 = "  00234  ";
            string s5 = "  023400";
            string s6= "  0234000";


            int i1 = Convert.ToInt32(s1);
            int i2 = Convert.ToInt32(s2);
            int i3 = Convert.ToInt32(s3);
            int i4 = Convert.ToInt32(s4);
            int i5 = Convert.ToInt32(s5);
            int i6 = Convert.ToInt32(s6);

            int iNull = Convert.ToInt32(sNull);
            
            // RUN TIME不會過
            //int iEmpty = Convert.ToInt32(stringEmpty);

            Console.WriteLine(convertInt1);
            Console.WriteLine(convertInt2);

            Console.WriteLine(iNull);
            //Console.WriteLine(iEmpty);
            Console.WriteLine(i1);
            Console.WriteLine(i2);
            Console.WriteLine(i3);
            Console.WriteLine(i4);
            Console.WriteLine(i5);
            Console.WriteLine(i6);

        }

        public void ConvertTool()
        {
            //正數 四捨五入 超過5才會進位
            int aa3 = Convert.ToInt32(6.4);//輸出6
            int aa4 = Convert.ToInt32(6.5);//輸出6<--沒有進位
            int aa5 = Convert.ToInt32(6.9);//輸出7
            int aa7 = Convert.ToInt32(7.4);//輸出7
            int aa8 = Convert.ToInt32(7.5);//輸出8<--有進位
            int aa9 = Convert.ToInt32(7.9);//輸出8
                                           //負數
            int bb3 = Convert.ToInt32(-6.4);//輸出-6
            int bb4 = Convert.ToInt32(-6.5);//輸出-6<--沒有進位
            int bb5 = Convert.ToInt32(-6.9);//輸出-7
            int bb7 = Convert.ToInt32(-7.4);//輸出-7
            int bb8 = Convert.ToInt32(-7.5);//輸出-8<--有進位
            int bb9 = Convert.ToInt32(-7.9);//輸出-8
        }
    }
}
