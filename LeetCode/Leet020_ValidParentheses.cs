using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Leet020_ValidParentheses
    {
        public static void main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(isParentheses(input));
        }
        static bool isParentheses(string s)
        {
            Stack<string> right = new Stack<string>();
            for (int i = 0; i < s.Length; i++)
            {
                string indexStr = s.Substring(i, 1);

                if (indexStr == "(" || indexStr == "{" || indexStr == "[")
                {
                    right.Push(indexStr);
                }
                else if (indexStr == ")" || indexStr == "}" || indexStr == "]")
                {
                    if (right.Count == 0)
                    { return false; }
                    else if (indexStr == ")")
                    {
                        string popStr = right.Pop();
                        if (popStr != "(") { return false; }
                    }
                    else if (indexStr == "}")
                    {
                        string popStr = right.Pop();
                        if (popStr != "{") { return false; }
                    }
                    else if (indexStr == "]")
                    {
                        string popStr = right.Pop();
                        if (popStr != "[") { return false; }
                    }
                }
            }
            if (right.Count == 0) { return true; }
            else { return false; }
        }
    }
}
