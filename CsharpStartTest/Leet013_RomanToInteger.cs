using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Leet013_RomanToInteger
    {
        public static void main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(RomanToInt(input));
            /*
            static Dictionary<char, int> dict = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            */
        }
        static int RomanToInt(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int indexValue = dict[s[i]];
                if (i == s.Length - 1 || dict[s[i + 1]] <= indexValue)
                    //只有一個數或下一個數相等||較小 
                    //S0>=S1>=S2>=S3的情形
                    result += indexValue;
                //sum可以單純找出value值相加
                else
                    //無法單純相加的時候
                    result -= indexValue;
            }
            return result;
        }
    }
}
