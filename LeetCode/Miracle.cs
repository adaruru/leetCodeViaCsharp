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
        public static bool ValidPalindrome(string s)
        {
            var r = false;
            var dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {

            }
            return true;
        }

        public static bool Miracle01(string word)
        {
            if (word.Length == 1)
            {
                return true;
            }
            var isAllCap = true;
            var isAllLower = true;
            var isAnyCap = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].ToString() == word[i].ToString().ToLower())
                {
                    isAllCap = false;
                }
                if (word[i].ToString() == word[i].ToString().ToUpper())
                {
                    isAllLower = false;
                }

                if (i != 0 && word[i].ToString() == word[i].ToString().ToUpper())
                {
                    isAnyCap = true;
                }
            }
            if (isAllLower)
            {
                return true;
            }
            if (isAnyCap && !isAllCap)
            {
                return false;
            }

            return true;

        }
    }
}