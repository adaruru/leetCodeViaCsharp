

namespace LeetCode;
public class Its001_BestSum
{
    public (Dictionary<string, decimal>, Dictionary<string, decimal>) BestSumUnderMax(Dictionary<string, decimal> txns, decimal deposits)
    {
        //餘額全足
        if (txns.Values.Sum() <= deposits)
        {
            return (txns, null);
        }

        //全不足
        if (txns.Values.Min() > deposits)
        {
            return (null, txns);
        }

        //一筆足夠
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

        //找
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

    public (Dictionary<string, decimal>, Dictionary<string, decimal>) BestSumUnderCount(Dictionary<string, decimal> bills, int givenCount)
    {
        return (null, null);
    }
}
