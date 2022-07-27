using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
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
    class Leet518_CoinChange
    {
        public static void main()
        {
            var coinChange = new Leet518_CoinChange();
            Console.Write("set coin denominations array split with space: ");
            int[] coins = Array.ConvertAll(Console.ReadLine().Split(" "), str => int.Parse(str));
            Console.Write("set amount: ");
            int amount = int.Parse(Console.In.ReadLine());
            var result = coinChange.CoinChange2(coins, amount);
            Console.WriteLine("result: " + result);
        }

        public int CoinChange(int[] coins, int amount)
        {
            //combination[1] 總數1的組合個數 總和amount 1~amount個 +1 個 （base0） 
            var combination = new int[amount + 1];
            //為了配合後續公式的存在
            combination[0] = 1;

            //以為觀察值產生的公式
            foreach (int coin in coins)
            {
                for (int i = 1; i < amount + 1; i++)
                {
                    if (i - coin >= 0)
                    {
                        combination[i] += combination[i - coin];
                    }
                    Console.Write(combination[i] + " ");
                }
                Console.WriteLine("");
            }
            return combination[amount];
        }

        public int CoinChange2(int[] coins, int amount)
        {
            var combination = new int[coins.Length + 1, amount + 1];
            combination[0, 1] = 1;
            combination[1, 0] = 1;
            for (int i = 1; i <= coins.Length; ++i)
            {
                for (int j = 1; j <= amount; ++j)
                {
                    if (j < coins[i - 1])
                    {
                        combination[i, j] = combination[i - 1, j];
                    }
                    else
                    {
                        combination[i, j] = combination[i - 1, j] + combination[i, j - coins[i - 1]];
                        Console.WriteLine("i=" + i + ",j=" + j + ",[i - 1, j]=" + combination[i - 1, j]);
                        Console.WriteLine("i=" + i + ",j=" + j + "[i, j - coins[i - 1]]=" + combination[i, j - coins[i - 1]]);
                    }

                    Console.WriteLine("i=" + i + "j=" + j + "[i,j]=" + combination[i, j]);
                }
                Console.WriteLine("i" + i);
            }
            return combination[coins.Length, amount];
        }

    }

}
