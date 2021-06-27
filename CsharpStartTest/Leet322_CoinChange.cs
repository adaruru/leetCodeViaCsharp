using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    /// <summary>
    /// You are given an integer array coins 
    /// representing coins of different denominations 
    /// 
    /// and an integer amount 
    /// representing a total amount of money.
    /// 
    /// Return the fewest number of coins 
    /// that you need to make up that amount.
    /// 
    /// If that amount of money cannot be made up by any combination of the coins, return -1.
    /// 
    /// You may assume that you have an infinite number of each kind of coin.(coin counts no maxium)
    /// 
    /// </summary>
    class Leet322_CoinChange
    {
        public static void main()
        {
            var coinChange = new Leet322_CoinChange();
            Console.Write("set coin denominations array split with space: ");
            int[] coins = Array.ConvertAll(Console.ReadLine().Split(" "), str => int.Parse(str));
            Console.Write("set amount: ");
            int amount = int.Parse(Console.In.ReadLine());
            var result = coinChange.CoinChange(coins, amount);
            Console.Write("result: " + result);
        }

        public int CoinChange(int[] coins, int amount)
        {
            return 1;
        }

    }

}
