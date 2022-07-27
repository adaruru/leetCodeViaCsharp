using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// using ReadLine to set all problem input
    /// </summary>
    class ProblemPreprocess
    {
        public static void main()
        {
            Console.Write("set a string: ");
            string input = Console.ReadLine();

            Console.Write("set a string array split with space: ");
            string[] numberStr1 = Console.ReadLine().Split();

            Console.Write("set a string list split with space: ");
            List<string> numberStr2 = Console.ReadLine().Split().ToList();

            Console.Write("set an int: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = int.Parse(Console.In.ReadLine());

            //1 bad one
            Console.Write("set int array split with space : ");
            string[] numberStrings = Console.ReadLine().Split();
            List<int> numList = new List<int>();
            for (int i = 0; i < numberStrings.Length; i++)
            {
                numList.Add(Convert.ToInt32(numberStrings[i]));
            }
            int[] nums = numList.ToArray();

            //2 better one
            Console.Write("set int array split with space : ");
            int[] digits = Array.ConvertAll(Console.ReadLine().Split(), str => int.Parse(str));
        }
    }
}
