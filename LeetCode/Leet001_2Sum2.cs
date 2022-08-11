using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Leet001_2Sum2
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
            //O(N)
            //sort之後取值找回原本的index，如果一樣將會重複取值，此題不適用
            int[] beforsort = (int[])nums.Clone();

            Array.Sort(nums);

            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                if (nums[start] + nums[end] == target)
                {
                    int numstart = Array.IndexOf(beforsort, nums[start]);
                    int numsend = Array.IndexOf(beforsort, nums[end]);
                    int[] result = { numstart, numsend };
                    return result;
                }
                else if (nums[start] + nums[end] > target)
                {
                    end--;
                }
                else if (nums[start] + nums[end] < target)
                {
                    start++;
                }
            }
            return null;
        }
    }
}
