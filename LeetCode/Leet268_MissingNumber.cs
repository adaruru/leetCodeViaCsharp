

namespace LeetCode;
public class Leet268_MissingNumber
{
    /// <summary>
    /// CMoney 有類似題目
    /// LeetCode 448 簡單版本
    /// 找出缺失數字
    /// Input: nums = [9,6,4,2,3,5,7,0,1]
    /// Output: 8

    /// </summary>
    /// <returns></returns>
    public int MissingNumber(int[] nums) {
        int result = 0;
        var dic = nums.Distinct().ToDictionary(x => x, x => true);

        for (int i = 1; i <= nums.Count(); i++)
        {
            if (!dic.ContainsKey(i))
            {
                result = i ;
                return result;
            }
        }
        return result;
    }
}
