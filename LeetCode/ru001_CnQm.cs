namespace LeetCode;
/// <summary>
/// C n 取 m 的所有組合
/// </summary>
public class ru001_CnQm
{
    /// <summary>
    /// 一個 Collection(Dictionary) n 個元素 (n > 1) 取 m 個( m <= n ) 的所有組合 
    /// </summary>
    /// <param name="txns"></param>
    /// <returns></returns>
    public List<Dictionary<string, decimal>> DictionaryCmQn(Dictionary<string, decimal> txns)
    {
        var result = new List<Dictionary<string, decimal>>();
        var tempKeys = txns.Keys.ToList();

        for (int i = 1; i < Math.Pow(2, txns.Count) - 1; i++)
        {
            var tempTxn = new Dictionary<string, decimal>();
            for (int j = 0; j < txns.Count; j++)
            {
                if ((i & (int)Math.Pow(2, j)) == Math.Pow(2, j))
                {
                    tempTxn.Add(tempKeys[j], txns[tempKeys[j]]);
                }
            }
            result.Add(tempTxn);
        }
        return result;
    }

    /// <summary>
    /// 一個 Collection(string[]) n 個元素 (n > 1) 取 m 個( m <= n ) 的所有組合 
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public List<List<string>> StringCmQn(string[] values)
    {
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
        return res;
    }
}
