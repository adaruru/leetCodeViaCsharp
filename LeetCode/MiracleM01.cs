namespace LeetCode
{
    public class Miracle
    {
        // Longest Continuous Increasing Subsequence
        // A continuous increasing subsequence is defined by two indices l and r (l < r) such that it is [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] and for each l <= i < r, nums[i] < nums[i + 1].
        // Input: nums = [1,3,5,4,7]
        // Output: 3

        //  Input: nums = [2,2,2,2,2]
        // Output: 1 (nums not valid)

       public int FindLengthOfLCIS(int[] nums)
       {
            int maxLength = 1;
            int currentLength = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    
                    return currentLength;
                }
            }

        }
    }
}