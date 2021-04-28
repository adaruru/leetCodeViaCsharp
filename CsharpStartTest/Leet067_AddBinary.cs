using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpStartTest
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

            return a + b;
        }



    }

}
