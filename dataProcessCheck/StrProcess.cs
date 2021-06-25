using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace dataProcessCheck
{
    public class StrProcess
    {
        public void StrSubAll()
        {
            var s = "0123456789";
            // var s1 = s.Sub();          js才有
            // var s2 = s.Substr(3, 5);   js才有
            var s3 = s.Substring(3, 5); //34567 startIndex 位置 length 幾個數字
            Console.WriteLine(s3);
        }

        public void StrFuncTry()
        {
            string firstname;
            string lastname;

            firstname = "Steven Clark";
            lastname = "Clark";

            // Make String Clone
            Console.WriteLine(firstname.Clone());

            //Compare two string value and returns 0 for true and 1 for false
            Console.WriteLine(firstname.CompareTo(lastname));

            //Check whether specified value exists or not in string
            Console.WriteLine(firstname.Contains("ven"));
            //Check whether specified value is the last character of string
            Console.WriteLine(firstname.EndsWith("n"));

            //Compare two string and returns true and false
            Console.WriteLine(firstname.Equals(lastname));


            //Returns HashCode of String
            Console.WriteLine(firstname.GetHashCode());

            //Returns type of string
            Console.WriteLine(firstname.GetType());

            //Returns type of string
            Console.WriteLine(firstname.GetTypeCode());

            //Returns the first index position of specified value the first index position of specified value
            Console.WriteLine(firstname.IndexOf("e"));

            //Covert string into lower case
            Console.WriteLine(firstname.ToLower());

            //Convert string into Upper case
            Console.WriteLine(firstname.ToUpper());

            Console.WriteLine(firstname.Insert(0, "Hello")); //Insert substring into string

            //Check Whether string is in Unicode normalization from C
            Console.WriteLine(firstname.IsNormalized());


            //Returns the last index position of specified value
            Console.WriteLine(firstname.LastIndexOf("e"));

            //Returns the Length of String
            Console.WriteLine(firstname.Length);

            //Deletes all the characters from begining to specified index.
            Console.WriteLine(firstname.Remove(5));

            Console.WriteLine(firstname.Replace('e', 'i')); // Replace the character

            //Split the string based on specified value
            string[] split = firstname.Split(new char[] { 'e' });

            Console.WriteLine(split[0]);
            Console.WriteLine(split[1]);
            Console.WriteLine(split[2]);

            //Check wheter first character of string is same as specified value
            Console.WriteLine(firstname.StartsWith("S"));

            //firstname = "Steven Clark";
            //Returns substring
            Console.WriteLine("firstname.Substring(2, 5) : .." + firstname.Substring(2, 5) + "..");

            //Converts an string into char array.
            Console.WriteLine(firstname.ToCharArray());

            //It removes starting and ending white spaces from string.
            Console.WriteLine(firstname.Trim());
        }

        /// <summary>
        /// 轉全形的函數(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string ToSBC(string input)
        {
            //半形轉全形：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 補空 補0 補滿位
        /// </summary>
        public void StrFormat()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string strJoin = string.Join("", list);
            Console.WriteLine("list : " + strJoin);

            //字串左補空 字串滿12碼靠右
            string padLeft = strJoin.PadLeft(12, ' ');
            string formatToRight = string.Format("{0,12}", strJoin);
            Console.WriteLine("12碼靠右 : " + padLeft);
            Console.WriteLine("12碼靠右 : " + formatToRight);

            //字串右補空 字串滿12碼靠左
            string padRight = strJoin.PadRight(12, ' ');
            string formatToLeft = string.Format("{0,-12}", strJoin);
            Console.WriteLine("12碼靠左 : " + padRight);
            Console.WriteLine("12碼靠左 : " + formatToLeft);

            Console.WriteLine("去空: [" + formatToLeft.Trim() + "]");
        }

        public void IsNullCheck()
        {
            var a = "1234567890";
            var b = a == "1" ? "0" : null;
            var c = "";

            var check = string.IsNullOrEmpty(a);
            //安裝Castle.Core 且 using Castle.Core.Internal; 可以直接對物件判斷
            //效果等同 string.IsNullOrEmpty(a);
            var checka = a.IsNullOrEmpty();
            var checkb = b.IsNullOrEmpty();
            var checkc = c.IsNullOrEmpty();
            Console.WriteLine("check: " + check);
            Console.WriteLine("checka: " + checka);
            Console.WriteLine("checkb: " + checkb);
            Console.WriteLine("checkc: " + checkc);
        }

    }
}
