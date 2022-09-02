using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Its003_ShortestPath
    {
        public int[] ShortestPath(int[] nums, int target)
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
