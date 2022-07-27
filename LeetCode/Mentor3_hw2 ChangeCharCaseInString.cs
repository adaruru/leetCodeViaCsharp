using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Mentor3_hw2_ChangeCharCaseInString
    {
        public static void main()
        {
            string Str = Console.ReadLine();
            string StrChange = ChangeCase(Str);
            Console.WriteLine(StrChange);
        }
        static string ChangeCase(string s)
        {
            string ChangedS = "";
            for (int i = 0; i < s.Length; i++)
            {

                if (char.IsLower(s[i]))
                {
                    ChangedS += s[i].ToString().ToUpper();
                }
                else
                {
                    ChangedS += s[i].ToString().ToLower();
                }
            }
            return ChangedS;
        }

    }
}
