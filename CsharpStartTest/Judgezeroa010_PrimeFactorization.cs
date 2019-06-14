using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Judgezeroa010_PrimeFactorization
    {
        public static void main()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int inputNumber = number;
            SortedList<int, int> primaryList = new SortedList<int, int>();

            for (int i = 2; i <= number; i++)
            {
                while (number % i == 0)
                {
                    if (primaryList.ContainsKey(i))
                    {
                        primaryList[i] += 1;
                    }
                    else
                    {
                        primaryList.Add(i, 1);
                    }
                    number = number / i;
                }
            }
            Console.Write(inputNumber + "=");

            string output = ""; // string.Empty
            foreach (int primary in primaryList.Keys)
            {
                if (output != "")
                {
                    output += "*";
                }
                output += primary + "^" + primaryList[primary];
            }
            Console.Write(output);
        }

    }
}
