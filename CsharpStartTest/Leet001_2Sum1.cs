using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Leet001_2Sum1
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
            //O(N^2)
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        int[] result = { i, j };
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
