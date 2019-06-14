using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
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
            Stack<String> right = new Stack<String>();
            for (int i = 0; i < s.Length; i++)
            {
                String indexStr = s.Substring(i, 1);

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
