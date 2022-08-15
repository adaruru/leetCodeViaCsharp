namespace LeetCode;

/// <summary>
/// #medium #Depth-First Search(#DFS，深度優先搜尋) #sortestPath 
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
/// </summary>
public class Leet399_EvaluateDivision
{
    public void Run()
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

        var ans = new Leet399_EvaluateDivision().CalcEquation(Input, values, queries);
        Console.Write("  ans = [");
        for (int i = 0; i < ans.Count(); i++)
        {
            Console.Write($"{ ans[i]} ,");
        }
        Console.WriteLine("]");
    }


    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var routeMap = new Dictionary<List<string>, double>();
        var neighborsMap = new Dictionary<string, List<string>>();

        for (int i = 0; i < equations.Count; i++)
        {
            var equ1 = equations[i][0];
            var equ2 = equations[i][1];

            double ov = 0;
            if (!routeMap.TryGetValue(equations[i].ToList(), out ov))//加入正續
            {
                routeMap.Add(equations[i].ToList(), values[i]);
            }
            if (!routeMap.TryGetValue(new List<string> { equ2, equ1 }, out ov))//加入倒續
            {
                routeMap.Add(new List<string> { equ2, equ1 }, 1 / values[i]);
            }

            if (equ1 != equ2)
            {
                if (!neighborsMap.ContainsKey(equ1))
                    neighborsMap[equ1] = new List<string>();
                if (!neighborsMap.ContainsKey(equ2))
                    neighborsMap[equ2] = new List<string>();

                neighborsMap[equ1].Add(equ2);
                neighborsMap[equ2].Add(equ1);
            }
        }

        var ans = new double[queries.Count()];
        for (int i = 0; i < queries.Count(); i++)
        {
            var query1 = queries[i][0];
            var query2 = queries[i][1];

            double v;
            if (!neighborsMap.ContainsKey(query1) ||
                !neighborsMap.ContainsKey(query2))
            {
                ans[i] = -1;
            }
            else if (query1 == query2)
            {
                ans[i] = 1;
            }
            else if (routeMap.TryGetValue(queries[i].ToList(), out v))
            {
                ans[i] = v;
            }
            else
            {
                ans[i] = Dfs(query1, query2, 1, routeMap, neighborsMap, new HashSet<string>());
            }
        }
        return ans;
    }
    private double Dfs(string source,
                       string target,
                       double value,
                       Dictionary<List<string>, double> routeMap,
                       Dictionary<string, List<string>> neighborsMap,
                       HashSet<string> visiting)
    {
        if (source == target) return value;

        visiting.Add(source); // Mark it as visiting if a visits b , we do not want b to visit a 

        List<string> neighbors = neighborsMap[source];
        double result = -1.0;
        foreach (string neighbor in neighbors)
        {
            if (!visiting.Contains(neighbor))
            {
                // visiting each neighbor to find the final destination
                result = Dfs(neighbor,
                             target,
                             value * routeMap.FirstOrDefault(r => r.Key[0] == source && r.Key[1] == neighbor).Value,
                             routeMap,
                             neighborsMap,
                             visiting);
                if (result != -1.0)
                    break;
            }
        }
        visiting.Remove(source); // remove source from visiting so it can be visited again from a different path
        return result;
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

