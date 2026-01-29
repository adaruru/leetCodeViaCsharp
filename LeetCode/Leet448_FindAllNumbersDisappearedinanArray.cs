namespace LeetCode;

public class Leet448_FindAllNumbersDisappearedinanArray
{
    /// <summary>
    /// CMoney 考題
    //   Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.
    // Example 1:

    // Input: nums = [4,3,2,7,8,2,3,1]
    // Output: [5,6]
    // Example 2:

    // Input: nums = [1,1]
    // Output: [2]
    /// </summary>
    /// <returns></returns>
    public IList<int> FindDisappearedNumbers(int[] nums) {
        IList<int> result = new List<int>();
        var dic = nums.Distinct().ToDictionary(x => x, x => true);

        for (int i = 1; i <= nums.Count(); i++)
        {
            if (!dic.ContainsKey(i))
            {
                result.Add(i);
            }
        }
        return result;
    }

    /// <summary>
    /// 合併重疊區間
    /// 任務：請根據您擅長的程式語言，實作以下函式，並分析時間和空間複雜度，儘可能優化且無 bug。
    /// 描述：給定一個列表 intervals，每個元素是一個區間 [start, end]，這些區間可能未排序。請合併所有重疊或相鄰的區間，並返回合併後的列表，結果列表需依 start 升序排列。
    /// 函式：
    /// merge_intervals(intervals: List[List[int]) -> List[List[int]]
    /// 輸入：列表 intervals，每個元素 [start, end]，整數 start <= end
    /// 輸出：合併後的列表，每個元素 [start, end]
    /// 範例：
    /// 1) Input: [[1,3],[2,6],[8,10],[15,18]] → Output: [[1,6],[8,10],[15,18]]
    /// 2) Input: [[1,4],[4,5]] → Output: [[1,5]]
    /// 3) Input: [[5,6],[1,3],[2,4]] → Output: [[1,4],[5,6]]
    /// </summary>
    public List<List<int>> merge_intervals(List<List<int>> intervals)
    {
        var result = new List<List<int>>();
        //可能沒有排序
        var inter = intervals.OrderBy(x => x[0]).ToList();

        //先第一個
        result.Add(new List<int> { inter[0][0], inter[0][1] });

        for (int i = 1; i < inter.Count; i++) // 第二個開始檢查
        {
            var check = inter[i]; 
            var last = result[result.Count - 1]; //找前一個

            if (check[0] <= last[1]) //有重疊
            {
                // 就合併，取大的
                last[1] = Math.Max(last[1], check[1]);
            }
            else
            {
                result.Add(new List<int> { check[0], check[1] });
            }
        }

        return result;
    }
    // 時間 排序+迴圈 (n log n) 
    // 空間 O(n) 
}
