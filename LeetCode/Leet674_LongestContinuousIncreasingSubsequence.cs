namespace LeetCode
{
    public class Leet674_LongestContinuousIncreasingSubsequence
    {
        // Longest Continuous Increasing Subsequence
        // A continuous increasing subsequence is defined by two indices l and r (l < r) such that it is [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] and for each l <= i < r, nums[i] < nums[i + 1].
        // Input: nums = [1,3,5,4,7]
        // Output: 3

        //  Input: nums = [2,2,2,2,2]
        // Output: 1 (nums not valid)
        // [1,3,5,4,2,3,4,5]
        // Output: 4 (135=>3, 2345=>4, max=4)
        public int FindLengthOfLCIS(int[] nums) 
        {
            if (nums == null || nums.Length == 0)
                return 1;

            int max = 1;
            int compare = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    compare++;
                    max = Math.Max(max, compare);
                }
                else
                {
                    compare = 1;
                }
            }
            return max;
        }
        // Complexity O(1)
    }
}