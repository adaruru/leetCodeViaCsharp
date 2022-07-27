using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Leet015_3Sum1
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
            for (int idxI = 0; idxI < result.Count; idxI++)
            {
                IList<int> i = result[idxI];
                string output = "";
                Console.Write("[");
                for (int idxJ = 0; idxJ < i.Count; idxJ++)
                {
                    int j = i[idxJ];
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

            //當i到第Length-3時，start= Length-2、end=Length-1，所以這兩個不用檢查
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //>0確認i-1存在,因為要往回看確認之前的i是否有重複 重複者跳過檢查
                if (i > 0 && nums[i - 1] == nums[i]) continue;

                //-nums[i] = start + end, 運用 2sum 解 3Sum
                var target = -nums[i];
                var start = i + 1;//i往下1個
                var end = nums.Length - 1;//最後一個

                while (start < end) //start永遠小於end
                {
                    if (nums[start] + nums[end] == target)
                    {
                        result.Add(new List<int>() { nums[i], nums[start], nums[end] });
                        //找下一個之前排除重複的
                        while (start < end && nums[start] == nums[start + 1]) start++;
                        //找下一個之前排除重複的
                        while (start < end && nums[end] == nums[end - 1]) end--;
                        //找下一個
                        start++;
                        end--;
                    }
                    else if (nums[start] + nums[end] < target) //start太小
                    {
                        start++;
                    }
                    else //end太大
                    {
                        end--;
                    }
                }
            }

            return result;
        }
    }
}


