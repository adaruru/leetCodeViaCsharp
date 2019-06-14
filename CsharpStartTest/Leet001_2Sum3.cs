using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpStartTest
{
    class Leet001_2Sum3
    {
        public static void main()
        {
            string[] numberStrings = Console.ReadLine().Split(' ');
            List<int> numList = new List<int>();
            for (int i = 0; i < numberStrings.Length; i++)
            {
                numList.Add(Convert.ToInt32(numberStrings[i]));
            }
            int[] nums = numList.ToArray();
            int target = Convert.ToInt32(Console.ReadLine());
            int[] result = TwoSum(nums, target);
            Console.Write("return indices is ");
            foreach (int item in result)
            {
                Console.Write(item + " ");
            }
        }
        static int[] TwoSum(int[] nums, int target)
        {
            //var numsDictionary = new Dictionary <int, int>();
            Dictionary<int, int> numsDictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Count(); i++)
            {
                //暫存相加數
                int complement = target - nums[i];
                //有宣告讓if可以跑就夠了，不用賦值，
                if (numsDictionary.ContainsKey(complement))
                {
                    int[] result = { numsDictionary[complement], i };
                    return result;
                }
                //為了方便上方好找到index所以key/Value顛倒
                if (!numsDictionary.ContainsKey(nums[i]))
                {
                    numsDictionary.Add(nums[i], i);
                }
            }
            return null;
        }
    }
}
