using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /// <summary>
    ///Given two binary strings a and b, return their sum as a binary string.
    /// </summary>
    class Leet067_AddBinary
    {
        public static void main()
        {
            Console.Write("set two Binary : ");

            string[] str = Console.ReadLine().Split(" ");
            string a = str[0];
            string b = str[1];
            var result = AddBinary(a, b);
            Console.WriteLine(result);
        }

        ///重新解釋一次題目
        ///int digit總合為一個數字
        ///該數字加一後 在每一位轉成array
        static string AddBinary(string a, string b)
        {
            //int 1 tochar '1' 在convert int 會變 49 char要再轉string不然會數字會跑掉
            int[] aArray = Array.ConvertAll(a.ToCharArray(0, a.Length), ch => Convert.ToInt32(ch.ToString()));
            int[] bArray = Array.ConvertAll(b.ToCharArray(0, b.Length), ch => Convert.ToInt32(ch.ToString()));


            var lengthS = a.Length < b.Length ? a.Length : b.Length;
            var lengthB = a.Length > b.Length ? a.Length : b.Length;

            int[] digit = new int[] { 0 };
            int[] digitR = new int[lengthB];
            for (int i = 0; i < lengthS; i++)
            {
                if (aArray[a.Length - 1 - i] + b[a.Length - 1 - i] == 2)
                {
                    digit[0] = 0;
                    digit = new int[] { 1 }.Concat(digit).ToArray();
                }
            }
            if (digit.Length > lengthS)
            {
                //尾數相加有進位
            }
            else
            {

            }
            return a + b;
        }



    }

}
