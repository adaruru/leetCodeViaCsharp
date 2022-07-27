using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Leet058_LengthOfLastWord
    {
        public static void main()
        {
            string str = Console.ReadLine();
            Console.Write(LengthOfLastWord(str));
        }
        static int LengthOfLastWord(string s)
        {
            //移除多於空格，變成以空格輸入array, 最後一個, 的長度
            //return s.Trim().Split().LastOrDefault().Length;
            //return s.Trim().Split().Last().Length;
            string[] strArr = s.Split();
            string target = null;
            for (int i = strArr.Length - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(strArr[i]))
                {
                    target = strArr[i];
                    break;
                }
            }

            if (target != null) return target.Length;
            else return 0;
        }

    }
}
