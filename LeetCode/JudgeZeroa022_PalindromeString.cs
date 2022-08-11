using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode;

public static class JudgeZeroa022_PalindromeString
{
    public static void Run()
    {
        string input = Console.ReadLine();
        Console.WriteLine(IsPalindrome(input));
    }

    static string IsPalindrome(string x)
    {
        //Length本身為最後一個index+1，不考竒數個中間先取前一半
        string fronStr = x.Substring(0, x.Length / 2);
        string retFrontStr = "";
        for (int i = fronStr.Length - 1; i >= 0; i--)
        {
            //取好的前半str反轉，一個一個放入retFrontStr
            retFrontStr += fronStr[i];
        }
        //長度轉為index數要-1
        string backStr = x.Substring((x.Length - 1) / 2 + 1);

        if (retFrontStr == backStr)
        { return "yes"; }

        else
        { return "no"; }
    }

}
