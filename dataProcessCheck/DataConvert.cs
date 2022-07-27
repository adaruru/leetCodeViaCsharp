using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataProcessCheck
{
    public class DataConvert
    {
        public void StringDecimalPoint()
        {
            decimal a = 400;
            decimal b = 150.22345M;
            decimal c = 0;
            var aKeepPoint = a.ToString("0.00");
            var bKeepPoint = b.ToString("0.00");
            var cKeepPoint = c.ToString("0.00");
            var aNoKeepPoint = a.ToString("0.##");
            var bNoKeepPoint = b.ToString("0.##");
            var cNoKeepPoint = c.ToString("0.##");

            var aNoKeep = a.ToString("#.##");
            var bNoKeep = b.ToString("#.##");
            var cNoKeep = c.ToString("#.##");

            //Ideal for displaying currency fixed to Second decimal place
            var aCurrency = a.ToString("F");
            var bCurrency = b.ToString("F");
            var cCurrency = c.ToString("F");

            Console.WriteLine("aKeepPoint: " + aKeepPoint + " ,bKeepPoint:" + bKeepPoint + " ,cKeepPoint" + cKeepPoint);
            Console.WriteLine("aNoKeepPoint: " + aNoKeepPoint + " ,bNoKeepPoint:" + bNoKeepPoint + " cNoKeepPoint:" + cNoKeepPoint);
            Console.WriteLine("aNoKeep: " + aNoKeep + " ,bNoKeep:" + bNoKeep + " ,cNoKeep:" + cNoKeep);
            Console.WriteLine("aCurrency: " + aCurrency + " ,bCurrency:" + bCurrency + " ,cCurrency:" + cCurrency);

        }

        public void ConvertTry()
        {
            string s1 = "234"; //我最正常
            string s2 = "00234"; //我有前0
            string s3 = "  00234"; //我有前空白
            string s4 = "  00234  "; //我有前後空白
            string s5 = "  0234我有英文00"; //我有英文
            string s6 = "  023400我有中文0"; //我有中文
            string s7 = ""; //我就空空的
            string s8 = "  "; //我就空空白白的
            var intResult = 0;
            var r1 = int.TryParse(s1, out intResult);
            Console.WriteLine("r1: " + r1 + " ,intResult : " + intResult); //ture 234
            var r2 = int.TryParse(s2, out intResult);
            Console.WriteLine("r2: " + r2 + " ,intResult : " + intResult); //ture 234
            var r3 = int.TryParse(s3, out intResult);
            Console.WriteLine("r3: " + r3 + " ,intResult : " + intResult); //ture 234 有前空白沒關係
            var r4 = int.TryParse(s4, out intResult);
            Console.WriteLine("r4: " + r4 + " ,intResult : " + intResult); //ture 234 有前後白沒關係
            var r5 = int.TryParse(s5, out intResult);
            Console.WriteLine("r5: " + r5 + " ,intResult : " + intResult); //false 0 不能有字
            var r6 = int.TryParse(s6, out intResult);
            Console.WriteLine("r6: " + r6 + " ,intResult : " + intResult); //false 0 阿就不能有字
            var r7 = int.TryParse(s7, out intResult);
            Console.WriteLine("r7: " + r7 + " ,intResult : " + intResult); //false 0 阿就空空的
            var r8 = int.TryParse(s8, out intResult);
            Console.WriteLine("r8: " + r8 + " ,intResult : " + intResult); //false 0 阿就空空白白的


            Regex digitsOnly = new Regex(@"[^\d]");//#移掉字 #移掉空白 #移除字 #移除空白 #純數字
            s5 = digitsOnly.Replace(s5, "");
            s6 = digitsOnly.Replace(s6, "");

            s5 = Regex.Replace(s5, "[^0-9]", ""); //比較直觀的用regex
            s6 = Regex.Replace(s6, "[^0-9]", ""); //比較直觀的用regex

            r5 = int.TryParse(s5, out intResult);
            Console.WriteLine("s5: " + s5 + " ,r5: " + r5 + " ,intResult : " + intResult); //ture 23400
            r6 = int.TryParse(s6, out intResult);
            Console.WriteLine("s6: " + s6 + " ,r6: " + r6 + " ,intResult : " + intResult); //ture 234000
        }
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
            string s6 = "  0234000";


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

            int? t3 = 3;
            double dd3 = Convert.ToDouble(t3);
        }
    }
}
