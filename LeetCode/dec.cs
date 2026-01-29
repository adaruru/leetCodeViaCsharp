using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode;

/// <summary>


// Csharp Logs Parse (C# 日誌解析)
// 任務說明
// 請在 C# 檔案中撰寫一個程式，對以下路由執行 GET 請求： https://coderbyte.com/api/challenges/logs/web-logs-raw

// 該路由包含一部分的 Web 伺服器日誌（Logs）。每一行日誌都以日期開頭，例如：Apr 10 11:17:35。您的程式應執行以下操作：

// 解析 ID：部分日誌條目中包含字串 ?shareLinkId=[ID]。

// 統計次數：您需要收集該字串中所有不重複的 ID。

// 格式化輸出：

// 以字串格式回傳所有 ID，每個 ID 佔用一行。

// 如果某個 ID 出現超過一次，請在該 ID 後方附加 :N，其中 N 是該 ID 出現的次數。

// 範例輸出
// 您的輸出結果應該類似於以下格式：

// Plaintext
// 69dff0hb32a0nv
// tosrvsdse4v8q8q:3
// 4esiramcsayu0:2


public class dec
{
    /// <summary>
    //    

    //    Largest Four
    //Have the function LargestFour(arr) take the array of integers stored in arr, and find the four largest elements and return their sum.For example: if arr is [4, 5, -2, 3, 1, 2, 6, 6] then the four largest elements in this array are 6, 6, 4, and 5 and the total sum of these numbers is 21, so your program should return 21. If there are less than four numbers in the array your program should return the sum of all the numbers in the array.

    //Examples
    //Input: [1, 1, 1, -5]

    //Output: -2

    //Input: [0, 0, 2, 3, 7, 1]

    //Output: 13
    /// </summary>
    /// <param name="args"></param>

    public static int LargestFour(int[] arr)
    {
        Array.Reverse(arr);
        var s =0;
        for (int i = 0; i < 4; i++)
        {
            s += arr[i];
        }
        // code goes here  
        return s;

    }

    public static void Solve()
    {
        var s = @"Apr 10 11:17:35 coderbyte app/web.3: IP_MASKED - - [10/Apr/2020:18:17:35 +0000] ""GET /backend/requests/editor/placeholder?shareLinkId=69dff0hba0nv HTTP/1.1"" 200 148 ""https://coderbyte.com"" ""Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:74.0) Gecko/20100101 Firefox/74.0
Apr 10 11:17:35 coderbyte heroku/router: at=info method=GET path=""/backend/requests/editor/placeholder?key=s2fwad2Es2"" host=coderbyte.com request_id=b19a87a1-1bbb-4e67-b207-bd9f23d46afa fwd=""108.31.000.000"" dyno=web.3 connect=0ms service=92ms status=200 bytes=3194 protocol=https

Apr 10 11:17:35 coderbyte heroku/router: at=info method=GET path=""/backend/requests/editor/placeholder?shareLinkId=tosrve4v8q8q"" host=coderbyte.com request_id=910b07d1-3f71-4347-a1a7-bfa20384ef65 fwd=""108.31.000.000"" dyno=web.2 connect=1ms service=17ms status=200 bytes=4435 protocol=https

Apr 10 11:17:35 coderbyte heroku/router: at=info method=GET path=""/backend/requests/editor/placeholder?shareLinkId=tosrve4v8q8q"" host=coderbyte.com request_id=097bf65e-e189-4f9f-9dfb-4758cff411b2 fwd=""108.31.000.000"" dyno=web.3 connect=1ms service=10ms status=200 bytes=4435 protocol=https

Apr 10 11:17:35 coderbyte app/web.2: IP_MASKED - - [10/Apr/2020:18:17:35 +0000] ""GET /backend/requests/editor/placeholder?key=s2fwad2Es2 HTTP/1.1"" 200 4263 ""https://coderbyte.com"" ""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36

Apr 10 11:17:35 coderbyte heroku/router: at=info method=GET path=""/backend/requests/editor/placeholder?shareLinkId=4eiramcmayu0"" host=coderbyte.com request_id=d48278c2-5731-464e-be38-ab9ad84ac4a8 fwd=""108.31.000.000"" dyno=web.4 connect=1ms service=7ms status=200 bytes=3194 protocol=https

Apr 10 11:17:35 coderbyte app/web.3: IP_MASKED - - [10/Apr/2020:18:17:35 +0000] ""GET /backend/requests/editor/placeholder?shareLinkId=tosrve4v8q8q HTTP/1.1"" 200 4263 ""https://coderbyte.com"" ""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36

Apr 10 11:17:35 coderbyte app/web.3: IP_MASKED - - [10/Apr/2020:18:17:35 +0000] ""GET /backend/requests/editor/placeholder?shareLinkId=tosrve4v8q8q HTTP/1.1"" 200 4263 ""https://coderbyte.com"" ""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36

Apr 10 11:17:36 coderbyte app/web.4: IP_MASKED - - [10/Apr/2020:18:17:35 +0000] ""GET /backend/requests/editor/placeholder?shareLinkId=4eiramcmayu0 HTTP/1.1"" 200 3023 ""https://coderbyte.com"" ""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36

Apr 10 11:17:36 coderbyte heroku/router: at=info method=GET path=""/backend/requests/editor/placeholder?shareLinkId=tosrve4v8q8q"" host=coderbyte.com request_id=8bb2413c-3c67-4180-8091-000313b8d9ca fwd=""MASKED"" dyno=web.3 connect=1ms service=32ms status=200 bytes=4435 protocol=https

Apr 10 11:17:36 coderbyte heroku/router: at=info method=GET path=""/backend/requests/editor/placeholder?shareLinkId=tosrve4v8q8q"" host=coderbyte.com request_id=10f93da3-2753-48a3-9485-857a93d8a88a fwd=""MASKED"" dyno=web.3 connect=1ms service=37ms status=200 bytes=4435 protocol=https
";
        var parts = s.Split("shareLinkId=");
        var dic = new Dictionary<string, int>();
        for (var i = 0; i < parts.Length; i++)
        {
            if (i == 0) continue;
            var id = parts[i].Split(new char[] { ' ', '\n', '\r', '"' })[0];
            if (dic.ContainsKey(id))
            {
                dic[id]++;
            }
            else
            {
                dic[id] = 1;
            }
        }
        foreach (var d in dic)
        {
            if (d.Value > 1)
            {
                Console.WriteLine($"{d.Key}:{d.Value}");
            }
            else
            {
                Console.WriteLine($"{d.Key}");
            }
        }

    }
}
