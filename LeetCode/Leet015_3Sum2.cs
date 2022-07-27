using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Leet015_3Sum2
    {
        public static void main()
        {
            string[] numStr = Console.ReadLine().Split();
            List<int> strList = new List<int>();
            for (int i = 0; i < numStr.Length; i++)
            {
                strList.Add(int.Parse(numStr[i]));
            }
            int[] num = strList.ToArray();
            IList<IList<int>> result = ThreeSum(num);
            //實作測資
            Console.WriteLine("[");
            foreach (IList<int> i in result)
            {
                Console.Write("[");
                string output = "";
                foreach (int j in i)
                {
                    if (output != "")
                    {
                        output += ",";
                    }
                    output += Convert.ToString(j);
                }
                Console.Write(output);
                Console.WriteLine("]");
            }
            Console.WriteLine("]");
        }

        static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            var result = new List<IList<int>>();

            var n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i]) continue;

                var left = i + 1;
                var right = n - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }
    }
}
