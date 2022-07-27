using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
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
            int[] digits = Array.ConvertAll(Console.ReadLine().Split(), str => int.Parse(str));
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
            var length = digits.Length;
            digits[length - 1]++;//last index value plus 1
            for (int i = 0; i < length; i++)//遍歷array
            {
                //is not final one (last index > current index)
                if (length - 1 - i > 0)
                {
                    if (digits[length - 1 - i] > 9)//需要進位的時候 2位數
                    {
                        digits[length - 1 - i] = 0;//current 設0
                        digits[length - 2 - i]++; //next 進位
                    }
                }
                else //is final one (last index = current index)
                {
                    //即使到了最大位數仍需進位
                    if (digits[length - 1 - i] > 9)//需要進位的時候
                    {
                        digits[length - 1 - i] = 0;//current 設0
                        //digit length 多一位 ==> [1],digits[]相連
                        digits = new[] { 1 }.Concat(digits).ToArray();
                    }
                }
            }

            //此解無法 10位以上的數字無法轉32位元int
            //ToCharArray在select to string 還是值得參考
            //新知:int 1 tochar '1' 在convert int 會變 49 char要再轉string不然會數字會跑掉
            var digitsStr = string.Join("", digits);
            int number = 0;
            if (int.TryParse(digitsStr, out number))
            {
                var numberString = (number + 1).ToString();
                var resultArray = numberString.ToCharArray(0, numberString.Length).Select(c => c.ToString()).ToArray();
                digits = Array.ConvertAll(resultArray, ch => Convert.ToInt32(ch));
            }

            return digits;
        }



    }

}
