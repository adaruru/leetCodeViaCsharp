

namespace LeetCode;
public class ru001_CnQm
{
    public void Run2()
    {

        Dictionary<string, decimal> txns = new Dictionary<string, decimal>
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3,
            ["d"] = 4,
            ["e"] = 5,
        };
        var TxnMaps = new List<Dictionary<string, decimal>>();
        var tempKeys = txns.Keys.ToList();

        for (int i = 1; i < Math.Pow(2, txns.Count) - 1; i++)
        {
            var TempMaps = new List<Dictionary<string, decimal>>();
            var TempMap = new Dictionary<string, decimal>();
            for (int j = 0; j < txns.Count; j++)
            {
                TempMaps.Add(new Dictionary<string, decimal>());
                if ((i & (int)Math.Pow(2, j)) == Math.Pow(2, j))
                {
                    if (!TempMaps[j].ContainsKey(tempKeys[j]))
                    {
                        TempMaps[j].Add(tempKeys[j], txns[tempKeys[j]]);
                    }
                }
                TempMap = TempMaps[j];
            }
            TxnMaps.Add(TempMap);
        }
        var maps = TxnMaps;
        Console.Read();
    }
    public void Run()
    {
        string[] values = { "a", "b", "c", "d" };
        var res = new List<List<string>>();

        for (int i = 1; i < Math.Pow(2, values.Length) - 1; i++)//2的4次方 16
        {
            List<string> temp = new List<string>();
            for (int j = 0; j < values.Length; j++)
            {
                if ((i & (int)Math.Pow(2, j)) == Math.Pow(2, j))
                {
                    temp.Add(values[j]);
                }
            }
            res.Add(temp);
        }
        var r = res;
    }
}
