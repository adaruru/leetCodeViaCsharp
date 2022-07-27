using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Leet007_ReverseInteger_2
    {
        public static void main()
        {
            int nums = int.Parse(Console.ReadLine());
            Console.Write(Reverse(nums));
        }
        static int Reverse(int x)
        {
            //避免負數干擾反轉，轉正後反轉另外寫
            long y = Math.Abs((long)x);
            if (x < 0)
            {
                return -reverseX(y);
            }
            return reverseX(y);
        }
        static int reverseX(long y)
        {
            //先轉string
            string z = Convert.ToString(y);
            //string 變 Char[]
            char[] reverseZ = z.ToCharArray();
            //反轉
            Array.Reverse(reverseZ);
            //轉好的 Char[] 強轉成 string
            string longReversed = new string(reverseZ);
            int result = int.Parse(longReversed);

            //if (!int.TryParse(longReversed, out result))
            //{
            //    return 0;
            //}
            return result;
        }
    }
}
