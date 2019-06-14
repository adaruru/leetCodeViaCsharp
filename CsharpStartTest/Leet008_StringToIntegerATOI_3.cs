using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Leet008_StringToIntegerATOI_3
    {
        public static void main()
        {
            //string str = Console.ReadLine();
            double i = 0;
            i = i + 'b';
                Console.Write(i);
        }
        static int MyAtoi(string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str)) return 0;

            int sign = 1;

            if (str[0] == '-')
            {
                sign = -1;
            }
            else if (!Char.IsDigit(str[0])) return 0;

            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    newStr += str[i];
                }
            }
            if (string.IsNullOrEmpty(newStr)) return 0;
            double x = double.Parse(newStr) * sign;


            if (x > Math.Pow(2, 32))
            {
                return (int)Math.Pow(2, 32);
            }
            else if (x < -1 * Math.Pow(2, 32))
            {
                return -1 * (int)Math.Pow(2, 32);
            }
            else
                return (int)x;
        }
    }
}


/*
 取得數字會跳過+、-、小數點，以下作法無解

            str=str.Trim();
            if (string.IsNullOrEmpty(str)) return 0;

            int sign = 1;

            if (str[0] == '-')
            {
                sign = -1;
            }
            else if (!Char.IsDigit(str[0])) return 0;

            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    newStr += str[i];
                }
            }
            if (string.IsNullOrEmpty(newStr)) return 0;
            double x = double.Parse(newStr)*sign;


            if (x > Math.Pow(2, 32))
            {
                return (int)Math.Pow(2, 32);
            }
            else if (x < -1 * Math.Pow(2, 32))
            {
                return -1 * (int)Math.Pow(2, 32);
            }
            else
                return (int)x ;


*/
