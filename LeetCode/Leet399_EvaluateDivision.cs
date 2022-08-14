namespace LeetCode;

/// <summary>
/// #medium Depth-First Search(DFS，深度優先搜尋)
/// 
/// You are given an array of variable pairs equations and an array of real numbers values,
/// where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. 
/// Each Ai or Bi is a string that represents a single variable.
///
/// You are also given some queries, where queries[j] = [Cj, Dj] 
/// represents the jth query where you must find the answer for Cj / Dj = ?.
///
/// Return the answers to all queries.
/// If a single answer cannot be determined, return -1.0.
/// 返回 所有問題的答案 。如果存在某個無法確定的答案，則用 -1.0 替代這個答案。
///
/// Note: The input is always valid. 
/// 注意：輸入總是有效的。
/// You may assume that evaluating the queries will not result in division by zero
/// 你可以假設除法運算中不會出現除數為 0 的情況
/// and that there is no contradiction.
/// 且不存在任何矛盾的結果。
///
/// Input: 
///     equations = [["a","b"],["b","c"]]
///     values    = [2.0,3.0]
///     queries   = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
/// Output:         [6.00000,0.50000,-1.00000,1.00000,-1.00000]
/// 
/// Input: equations = [["a","b"],["b","c"],["e","f"]]
/// values = [1.5,2.5,5.0]
/// queries = [["a","c"],["c","b"],["e","f"],["f","e"]]
/// Output: [3.75000,0.40000,5.00000,0.20000]
/// 
/// Input: equations = [["a","b"]]
/// values = [0.5]
/// queries = [["a","b"],["b","a"],["a","c"],["x","y"]]
/// Output: [0.50000,2.00000,-1.00000,-1.00000]
/// 
/// 
/// </summary>
public class Leet399_EvaluateDivision
{
    public static void Run()
    {
        Console.Write("Leet399_EvaluateDivision");

        IList<IList<string>> Input = new List<IList<string>> { new List<string> { "a", "b" }, new List<string> { "b", "c" } };
        double[] values = { 2.0, 3.0 };
        IList<IList<string>> queries = new List<IList<string>> {
             new List<string> {"a", "c"},
             new List<string> {"b", "a"},
             new List<string> {"a", "e"},
             new List<string> {"a", "a"},
             new List<string> {"x", "x"},
         };

        var ans = CalcEquation(Input, values, queries);
        Console.Write("  ans = [");
        for (int i = 0; i < ans.Count(); i++)
        {
            Console.Write($"{ ans[i]} ,");
        }
        Console.WriteLine("]");
    }

    public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var allKey = new List<string>();
        var routeMap = new Dictionary<List<string>, double>();
        for (int i = 0; i < equations.Count; i++)
        {
            double ov = 0;
            if (!routeMap.TryGetValue(equations[i].ToList(), out ov))//加入正續
            {
                routeMap.Add(equations[i].ToList(), values[i]);
            }
            if (!routeMap.TryGetValue(new List<string> { equations[i][1], equations[i][0] }, out ov))//加入倒續
            {
                routeMap.Add(equations[i].ToList(), 1 / values[i]);
            }

            if (!allKey.Contains(equations[i][0]))
            {
                allKey.Add(equations[i][0]);
            }
            if (!allKey.Contains(equations[i][1]))
            {
                allKey.Add(equations[i][1]);
            }
        }

        var equMap = new Dictionary<string, string>();

        var ans = new double[queries.Count()];
        for (int i = 0; i < queries.Count(); i++)
        {
            double v;
            if (!allKey.Contains(queries[i][0]) ||
                !allKey.Contains(queries[i][1]))
            {
                ans[i] = -1;
            }
            else if (queries[i][0] == queries[i][1])
            {
                ans[i] = 1;
            }
            else if (routeMap.TryGetValue(queries[i].ToList(), out v))
            {
                ans[i] = v;
            }
            else
            {
                if (GotNext(routeMap, queries[i][0], out v))
                {

                }
                ans[i] = v;
            }
        }

        return ans;
    }
    static bool GotNext(Dictionary<List<string>, double> routeMap, string first, out double v)
    {
        var tempList = new Dictionary<List<string>, double>();
        var result = false;
        var allKey = routeMap.Select(r => r.Key).ToList();
        foreach (var route in routeMap)
        {
            double vin;
            if (route.Key[0] == first)
            {   
                result = GotNext(routeMap, first, out vin);
            }
        }

        bool isFirst = allKey.TryGetValue(query[0], out v);
        bool isSecond = routeMap.TryGetValue(query[1], out v);
        if (true)
        {

        }
        v = 0;
        return true;
    }

    static List<string> FindRoute(IList<IList<string>> equations, string key)
    {
        var result = new List<string>();

        foreach (var equ in equations)
        {
            if (equ[0] == key)
            {
                result.Add(equ[0]);
            }
            if (equ[1] == key)
            {
                result.Add(equ[1]);
                if (true)
                {

                }
            }
        }
        return new List<string>();
    }


    /// <summary>
    /// 設第一個 base 1 但是要判斷的例外太多了
    /// </summary>
    /// <param name="equations"></param>
    /// <param name="values"></param>
    /// <param name="queries"></param>
    /// <returns></returns>
    public static double[] CalcEquation2(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var valueMap = new Dictionary<string, double>();
        for (int i = 0; i < equations.Count; i++)
        {
            double v = 0;
            bool isFirst = valueMap.TryGetValue(equations[i][0], out v);
            bool isSecond = valueMap.TryGetValue(equations[i][1], out v);

            if (!isFirst && !isSecond)
            {
                valueMap.Add(equations[i][0], 1);
                valueMap.Add(equations[i][1], 1 / values[i]);
            }

            if (!isFirst && isSecond)
            {
                valueMap.Add(equations[i][0], valueMap[equations[i][1]] * values[i]);
            }

            if (isFirst && !isSecond)
            {
                valueMap.Add(equations[i][1], valueMap[equations[i][0]] / values[i]);
            }
        }

        double[] answer = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            double v = 0;
            double first = 0;
            double second = 0;
            if (!valueMap.TryGetValue(queries[i][0], out v))
            {
                answer[i] = -1;
                continue;
            }
            else
            {
                first = v;
            }
            if (!valueMap.TryGetValue(queries[i][1], out v))
            {
                answer[i] = -1;
                continue;
            }
            else
            {
                second = v;
            }

            answer[i] = first / second;
        }
        return answer;
    }

}

