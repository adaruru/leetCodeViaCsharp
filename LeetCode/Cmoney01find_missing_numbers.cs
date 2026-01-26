

namespace LeetCode;
public class Cmoney01find_missing_numbers
{
    /// <summary>
    /// 找出缺失數字
    /// 任務：請根據您擅長的程式語言，實作以下函式，並分析時間和空間複雜度，儘可能優化且無 bug。
    /// 描述：給定長度為 n 的整數陣列，元素範圍 1 到 n，其中部分數字可能重複或缺失。請回傳所有缺失的數字。輸入陣列可能未排序，可能包含重複。
    /// 函式：find_missing_numbers(nums: List[int]) -> List[int]
    /// 輸入：整數陣列 nums，長度 n
    /// 輸出：整數陣列，包含所有缺失數字
    /// 範例：
    /// 1) Input: [4,3,2,7,8,2,3,1] → Output: [5,6]
    /// 2) Input: [1,1] → Output: [2]

    /// </summary>
    /// <returns></returns>
    public List<int> find_missing_numbers(List<int> nums)
    {
        var result = new List<int>();
        var dic = nums.Distinct().ToDictionary(x => x, x => true);

        for (int i = 1; i <= nums.Count; i++)
        {
            if (!dic.ContainsKey(i))
            {
                result.Add(i);
            }
        }
        return result;
        //一個迴圈 時間、空間 O(n)
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
