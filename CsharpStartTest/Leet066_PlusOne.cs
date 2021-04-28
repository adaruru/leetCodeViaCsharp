using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpStartTest
{
    /// <summary>
    /// Share
    /// Given a non-empty array of decimal digits representing a non-negative integer, //increment /one to the integer.
    /// The digits are stored such that the most significant digit is at the head of the list, //and/ each element in the array contains a single digit.
    /// You may assume the integer does not contain any leading zero, except the number 0 itself.
    /// </summary>
    class Leet066_PlusOne
    {
        public static void main()
        {
            Console.Write("Plus one array : ");

            int[] digits = Array.ConvertAll(Console.ReadLine().Split(" "), str => int.Parse(str));
            var digitsResult = PlusOne(digits);
            string resultStr = string.Join(',', digitsResult);
            var result = "[" + resultStr + "]";

            Console.WriteLine(result);
        }

        ///重新解釋一次題目
        ///int digit總合為一個數字
        ///該數字加一後 在每一位轉成array
        static int[] PlusOne(int[] digits)
        {
            var digitsStr = string.Join("", digits);
            int number = 0;
            if (Int32.TryParse(digitsStr, out number))
            {
                var numberString = (number + 1).ToString();
                var resultArray = numberString.ToCharArray(0, numberString.Length).Select(c => c.ToString()).ToArray();
                digits = Array.ConvertAll(resultArray, ch => Convert.ToInt32(ch));
            }
            else
            {
               
            }

            return digits;
        }



    }

}
