
namespace LeetCode
{
    /// <summary>
    /// CMoney 題目
    /// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
    /// Example 1:
    /// Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
    /// Output: [[1,6],[8,10],[15,18]]
    /// Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
    /// </summary>
    public class Leet056_MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            var result = new int[][] { };
            //可能沒有排序
            var inter = intervals.OrderBy(x => x[0]).ToList();

            //先第一個
            result[0] = new int[] { inter[0][0], inter[0][1] };

            for (int i = 1; i < inter.Count; i++) // 第二個開始檢查
            {
                var check = inter[i];
                var last = result[result.Length - 1]; //找前一個

                if (check[0] <= last[1]) //有重疊
                {
                    // 就合併，取大的
                    last[1] = Math.Max(last[1], check[1]);
                }
                else
                {
                    result[result.Length + 1] = new int[] { check[0], check[1] };
                }
            }

            return result;
        }

    }
}
