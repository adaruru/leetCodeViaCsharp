using System;
using System.Collections.Generic;
using System.Text;

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
///You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.
/// </summary>
class Leet399_EvaluateDivision
{
    public static void run()
    {
        var coinChange = new Leet518_CoinChange();
        Console.Write("set coin denominations array split with space: ");
        int[] coins = Array.ConvertAll(Console.ReadLine().Split(" "), str => int.Parse(str));
        Console.Write("set amount: ");
        int amount = int.Parse(Console.In.ReadLine());
        var result = coinChange.CoinChange2(coins, amount);
        Console.WriteLine("result: " + result);
    }
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        return new double[] { };
    }
}

