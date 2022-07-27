using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Leet007_ReverseInteger_1
    {
        public static void main()
        {
            int inputNum = Convert.ToInt32(Console.ReadLine());
            Console.Write(reverse(inputNum));
        }
        static int reverse(int intNum)
        {
            long retNum = 0;
            long longNum = intNum;
            while (longNum != 0)
            {
                retNum = retNum * 10 + longNum % 10;
                longNum /= 10;
            }
            if (retNum < -Math.Pow(2, 31) || retNum > Math.Pow(2, 31) - 1)
            { return 0; }
            int result = (int)retNum;
            return result;
        }
    }
}
