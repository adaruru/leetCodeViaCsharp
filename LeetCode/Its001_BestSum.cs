

namespace LeetCode;
public class Its001_BestSum
{
    /// <summary>
    /// 已餘額判斷扣款項，取可扣款最多金額解
    /// </summary>
    /// <param name="txns"></param>
    /// <param name="deposits"></param>
    /// <returns></returns>
    public (Dictionary<string, decimal>, Dictionary<string, decimal>) BestSumUnderMax(Dictionary<string, decimal> txns, decimal deposits)
    {
        //餘額全足 全扣
        if (txns.Values.Sum() <= deposits)
        {
            return (txns, null);
        }

        //全不足 全不扣
        if (txns.Values.Min() > deposits)
        {
            return (null, txns);
        }

        //一筆足夠 扣該筆
        if (txns.Values.Any(v => v == deposits))
        {
            var kv = txns.FirstOrDefault(t => t.Value == deposits);
            var debit1 = new Dictionary<string, decimal>
            {
                [kv.Key] = kv.Value,
            };
            txns.Remove(kv.Key);
            return (debit1, txns);
        }

        //取得所有可扣金額解
        var routeMap = new Dictionary<decimal, Dictionary<string, decimal>>();
        decimal maxSum = 0;
        var exceptKeys = new List<string>();

        var tempKeys = txns.Keys.ToList();
        for (int j = 0; j < txns.Count(); j++)
        {
            exceptKeys.Add(tempKeys[j]);
            var temptxns = txns.Where(t => !exceptKeys.Any(e => e == t.Key)).ToDictionary(x => x.Key, x => x.Value);

            var pair = BestSum(temptxns, deposits);
            if (!routeMap.ContainsKey(pair.Key) && pair.Key > maxSum)
            {
                maxSum = pair.Key;
                routeMap.Add(maxSum, pair.Value);
            }
        }
        //取可扣金額最大解
        var debit = routeMap.MaxBy(r => r.Key).Value;
        foreach (var d in debit)
        {
            txns.Remove(d.Key);
        }
        return (debit, txns);
    }

    public KeyValuePair<decimal, Dictionary<string, decimal>> BestSum(
           Dictionary<string, decimal> txns,
           decimal deposits)
    {
        var routeMap = new Dictionary<decimal, Dictionary<string, decimal>>();
        decimal maxSum = 0;
        var tempKeys = txns.Keys.ToList();
        var tempDebit = new Dictionary<string, decimal>();
        decimal tempSum = 0;
        for (int j = 0; j < txns.Count(); j++)
        {
            if (txns[tempKeys[j]] + tempSum < deposits &&
                txns[tempKeys[j]] + tempSum > maxSum)
            {
                tempSum += txns[tempKeys[j]];
                tempDebit.Add(tempKeys[j], txns[tempKeys[j]]);
            }

            if (!routeMap.ContainsKey(tempSum) && tempSum != 0)
            {
                maxSum = tempSum;
                routeMap.Add(maxSum, tempDebit);
            }
        }
        return routeMap.MaxBy(r => r.Key);
    }

    /// <summary>
    ///  已餘額判斷扣款項，取可扣款最多筆數解
    /// </summary>
    /// <param name="bills"></param>
    /// <param name="givenCount"></param>
    /// <returns></returns>
    public (Dictionary<string, decimal>, Dictionary<string, decimal>) BestSumUnderCount(Dictionary<string, decimal> bills, int givenCount)
    {
        return (null, null);
    }
}
