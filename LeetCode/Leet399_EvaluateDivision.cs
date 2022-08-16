namespace LeetCode;

/// <summary>
/// #medium #Depth-First Search(#DFS，深度優先搜尋) #sortestPath
/// #Union-Find(Disjoint-set data structure)
/// #Graph #有向圖 #directedGraph #digraph
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
/// </summary>
public class Leet399_EvaluateDivision
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var routeMap = new Dictionary<List<string>, double>();
        var neighborsMap = new Dictionary<string, List<string>>();

        for (int i = 0; i < equations.Count; i++)
        {
            var equ1 = equations[i][0];
            var equ2 = equations[i][1];

            if (!routeMap.TryGetValue(equations[i].ToList(), out double v1))//加入正續
            {
                routeMap.Add(equations[i].ToList(), values[i]);
            }
            if (!routeMap.TryGetValue(new List<string> { equ2, equ1 }, out double v2))//加入倒續
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

            if (!neighborsMap.ContainsKey(query1) ||
                !neighborsMap.ContainsKey(query2))
            {
                ans[i] = -1;
            }
            else if (query1 == query2)
            {
                ans[i] = 1;
            }
            else if (routeMap.TryGetValue(queries[i].ToList(), out double v))
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
        if (source == target) return value; //找到 target 遞迴結束

        visiting.Add(source); // Mark it as visiting if a visits b , we do not want b to visit a 

        List<string> neighbors = neighborsMap[source];
        double result = -1.0; //預設 target 找不到
        foreach (string neighbor in neighbors) //所有 source 的 neighbor 都要找
        {
            if (!visiting.Contains(neighbor)) //往下找可能的路徑時 須排除經過的 source 避免遞迴有迴圈 (a->b b->a a->b)
            {
                // visiting each neighbor to find the final destination
                result = Dfs(neighbor, //neighbor 變 source 往下找可能的路徑 
                             target, //最終 target 不可變
                             value * routeMap.FirstOrDefault(r => r.Key[0] == source && r.Key[1] == neighbor).Value, //相乘抵銷中間路徑值
                             routeMap,
                             neighborsMap,
                             visiting);
                if (result != -1.0)
                {
                    break;//遞迴結束 找到 target, 迴圈結束
                }
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
            bool isFirst = valueMap.TryGetValue(equations[i][0], out double v1);
            bool isSecond = valueMap.TryGetValue(equations[i][1], out double v2);

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
            double first = 0;
            double second = 0;
            if (!valueMap.TryGetValue(queries[i][0], out double v1))
            {
                answer[i] = -1;
                continue;
            }
            else
            {
                first = v1;
            }
            if (!valueMap.TryGetValue(queries[i][1], out double v2))
            {
                answer[i] = -1;
                continue;
            }
            else
            {
                second = v2;
            }

            answer[i] = first / second;
        }
        return answer;
    }

}

