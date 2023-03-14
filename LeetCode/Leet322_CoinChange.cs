namespace LeetCode;

/// <summary>
/// Medium
/// You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
/// Return the fewest number of coins that you need to make up that amount.If that amount of money cannot be made up by any combination of the coins, return -1.
/// You may assume that you have an infinite number of each kind of coin.
/// </summary>
internal class Leet322_CoinChange
{
    public static void main()
    {
        var coinChange = new Leet322_CoinChange();
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
        return combination[amount];
    }

    public int CoinChange2(int[] coins, int amount)
    {
        var combination = new int[coins.Length + 1, amount + 1];
        combination[0, 1] = 1;
        combination[1, 0] = 1;
        return combination[coins.Length, amount];
    }
}