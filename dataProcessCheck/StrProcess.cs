using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace dataProcessCheck
{
    public class StrProcess
    {
        public void playGround()
        {
            var EFFDATE = "20210728";
            var pasResult = DateTime.TryParseExact(EFFDATE, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);

            Console.WriteLine("EFFDATE pasResult: "+ EFFDATE+" :"+ pasResult);
        }

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
        /// 注意 pad 完必須重新賦值 不然是不回覆蓋到原本的值(a)
        /// </summary>
        public void StrPadPractice()
        {
            var a = "123 223";
            a = "";
            //a = null; //null ex 
            string padLeftHalf = a.PadLeft(12, ' ');
            string padLeftFull = a.PadLeft(12, '　');
            Console.WriteLine("12碼靠右半形 : " + padLeftHalf + " 長度：" + padLeftHalf.Length);
            Console.WriteLine("12碼靠右全形 : " + padLeftFull + " 長度：" + padLeftFull.Length);
            string padRightHale = a.PadRight(12, ' ');
            string padRightFull = a.PadRight(12, '　');
            Console.WriteLine("12碼靠左半形 : " + padRightHale + " 長度：" + padRightHale.Length);
            Console.WriteLine("12碼靠右全形 : " + padRightFull + " 長度：" + padRightFull.Length);
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

        public void StringConcat()
        {

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] strArr = { "A", "B", "C", "D", "E" };


            string intStrJoin = string.Join("$", list); //TODO：查明why 加 0, 2) 會有錯 
            string strJoin = string.Join("$", strArr, 0, 3);//A$B$C start index, count
            Console.WriteLine("intStrJoin : " + intStrJoin);
            Console.WriteLine("strJoin : " + strJoin);

            //變成物件的字串表現 System.Collections.Generic.List`1[System.Int32]System.String[]
            Console.WriteLine("intStrConcat : " + string.Concat(list, strArr));
            //value type 可以很多
            Console.WriteLine("intStrConcat : " + string.Concat(' ', 12, 0.2, 'b', "C"));
            //IEnumerable 只能放一個 且沒辦法像 join 指定位置與數量
            Console.WriteLine("intStrConcat : " + string.Concat(list));
            Console.WriteLine("StrConcat : " + string.Concat(strArr));

            Console.WriteLine("intStrAdd : " + list[0] + list[1]);
            Console.WriteLine("strAdd : " + strArr[0] + list[0]);

            var intSb = new StringBuilder(list[0]);
            intSb.Append(list[1]).Append(list[2]).Append(list[3]);
            var strSb = new StringBuilder(strArr[0]);
            strSb.Append(strArr[1]).Append(strArr[2]).Append(strArr[3]);

            var apend = "01234567890";

            Console.WriteLine("intStringBuilder : " + intSb);
            Console.WriteLine("strStringBuilder : " + strSb);

            Console.WriteLine("intStringBuilder : " + intSb.Append(apend, 0, 4).ToString());
            Console.WriteLine("strStringBuilder : " + strSb.Append(apend, 0, 4).ToString());
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
