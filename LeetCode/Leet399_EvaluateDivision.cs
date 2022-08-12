namespace LeetCode;

/// <summary>
///You are given an array of variable pairs equations and an array of real numbers values,
///where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. 
///Each Ai or Bi is a string that represents a single variable.
///
///You are also given some queries, where queries[j] = [Cj, Dj] 
///represents the jth query where you must find the answer for Cj / Dj = ?.
///
///Return the answers to all queries.
///If a single answer cannot be determined, return -1.0.
///
///Note: The input is always valid. 
///You may assume that evaluating the queries will not result in division by zero 
///and that there is no contradiction.
///
/// Input: equations = [["a","b"],["b","c"]]
/// values = [2.0,3.0]
/// queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
/// Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
/// 
/// Input: equations = [["a","b"],["b","c"],["bc","cd"]]
/// values = [1.5,2.5,5.0]
/// queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
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
        double[] values = [2.0, 3.0];
        IList<IList<string>> queries = new List<IList<string>> {
             new List<string> {"a", "c"},
             new List<string> {"b", "a"},
             new List<string> {"a", "e"},
             new List<string> {"a", "a"},
             new List<string> {"x", "x"},
         };

        var a = CalcEquation(Input, values, queries);
    }
    public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        return new double[] { };
    }
}

