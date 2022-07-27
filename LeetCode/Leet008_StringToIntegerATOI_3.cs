using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
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
            int index = 0;

            if (str[0] == '+' || str[0] == '-')
            {
                sign = str[0] == '-' ? -1 : 1;
                index++;
            }

            else if (!char.IsDigit(str[0])) return 0;

            string newStr = "";

            for (int i = index; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    break;
                }
                newStr += str[i];
            }
            if (string.IsNullOrEmpty(newStr)) return 0;
            double res = double.Parse(newStr) * sign;

            /*
            if (res>Math.Pow(2, 31) - 1) return(int)Math.Pow(2, 31) - 1;
            else if (res< -(Math.Pow(2, 31))) return (int)-(Math.Pow(2, 31));
            else
                return (int)res;
            */
            int result;
            double douresult;
            if (int.TryParse(newStr, out result))
            {
                return result * sign;
            }
            else if (double.TryParse(newStr, out douresult))
            {
                if (douresult * sign > 0) return int.MaxValue;
                else return int.MinValue;
            }
            //不會到這行 只是要確認有回傳值
            return 0;

        }
    }
}




