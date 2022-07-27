using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Leet009_PalindromeNumber
    {
        public static void main()
        {
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(IsPalindrome(a));
        }
        static bool IsPalindrome(int x)
        {
            if (x <= 0 || x % 10 == 0 && x != 0)
            {
                return false;
            }
            int reverseNum = 0;
            while (x > reverseNum)
            {
                reverseNum = reverseNum * 10 + x % 10;
                x /= 10;
            }
            return x == reverseNum || x == reverseNum / 10;
        }
    }
}
