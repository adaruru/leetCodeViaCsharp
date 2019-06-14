using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Leet008_StringToIntegerATOI_1
    {
        public static void main()
        {
            string str = Console.ReadLine();
            Console.Write(MyAtoi(str));
        }
        static int MyAtoi(string str)
        {
            //long也可以
            double res = 0;
            var sign = 1;

            str = str.Trim();
            if (string.IsNullOrEmpty(str)) return 0;
            var index = 0;
            if (str[0] == '+' || str[0] == '-')
            {
                sign = str[0] == '-' ? -1 : 1;
                index++;
            }
            while (index < str.Length)
            {
                if (!char.IsNumber(str[index]))
                {
                    break;
                }
                //前一次取得的值會進位，每次執行進位*10，再減去造成空隙的
                //char才能放入加減

                res = res * 10 + str[index] - '0';

                res = res * 10;
                res = res + str[index];
                res = res - '0';

                if (res * sign > Math.Pow(2, 31) - 1) return (int)Math.Pow(2, 31) - 1;
                //直接加負號
                if (res * sign < -(Math.Pow(2, 31))) return (int)-(Math.Pow(2, 31));
                //乘-1變負
                //if (res * sign < Math.Pow(2, 31) * -1) return (int)(Math.Pow(2, 31) * -1);
                //零減變負
                //if (res * sign < (0 - Math.Pow(2, 31))) return (int)(0 - Math.Pow(2, 31));

                index++;
            }

            return (int)res * sign;
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
