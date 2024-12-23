﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Castle.Core.Internal;
using Lib.Model.ParseJson;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Lib
{
    public class StrProcess
    {
        public string ValidId(string ID)
        {
            if (ID[1] == '8' ||
                ID[1] == '9')
            {
                //2位英文字母+8位數字 居留證/基資表統一證號 
                return "12";
            }
            if (ID.Substring(1, 1) == "8" ||
                ID.Substring(1, 1) == "9")
            {
                //2位英文字母+8位數字 居留證/基資表統一證號 
                return "12";
            }
            return "11";
        }
        public void Random()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 5; i++)
            {
                var next = rnd.Next();
                Console.WriteLine(next);
            }
            Console.WriteLine("_______________");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(SecureRandom(10));
            }
            Console.WriteLine("_______________");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(SecureRandom2(10));
            }
            Console.WriteLine("_______________");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(SecureRandom3(9));
            }
        }


        public int SecureRandom(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException(nameof(minValue), "minValue 必須小於或等於 maxValue");
            if (minValue == maxValue)
                return minValue;

            // 計算範圍
            long diff = (long)maxValue - minValue + 1;
            byte[] uint32Buffer = new byte[4];

            using (var rng = RandomNumberGenerator.Create())
            {
                while (true)
                {
                    rng.GetBytes(uint32Buffer);
                    uint rand = BitConverter.ToUInt32(uint32Buffer, 0);

                    // 避免偏差
                    long max = (1 + (long)UInt32.MaxValue);
                    long remainder = max % diff;
                    if (rand < max - remainder)
                    {
                        return (int)(minValue + (rand % diff));
                    }
                }
            }
        }

        public static string SecureRandom(int length)
        {
            var randomNumber = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            var stringBuilder = new StringBuilder();
            foreach (byte b in randomNumber)
            {
                stringBuilder.Append(b % 10);
            }
            return stringBuilder.ToString();
        }
        public static string SecureRandom2(int length)
        {
            var randomNumber = new byte[length];
            RandomNumberGenerator.Fill(randomNumber);
            return string.Concat(randomNumber.Select(b => (b % 10).ToString()));
        }

        public static int SecureRandom3(int length)
        {
            if (length < 1 || length > 9)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be between 1 and 9.");//int長度限制

            var randomNumber = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            var result = string.Concat(randomNumber.Select(b => (b % 10).ToString()));
            return int.Parse(result);
        }

        public string XMLString(string xmlString)
        {
            XmlNodeList xnlstData;
            XmlNode xnBody, xnOccur;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            int num = 0;

            xnlstData = xmlDocument.GetElementsByTagName("OCCUR");
            xnOccur = xnlstData[0];
            num += Convert.ToInt16(xnOccur?.InnerText?.Trim() ?? "0");
            xnlstData = xmlDocument.GetElementsByTagName("TxBody");
            XmlNode xmlNode2 = xnlstData[xnlstData.Count - 1];


            XmlDocument xmlDocument2 = new XmlDocument();
            xmlDocument2.LoadXml(xmlString);

            xnlstData = xmlDocument2.GetElementsByTagName("OCCUR");
            num += Convert.ToInt16(xnlstData[0]?.InnerText?.Trim() ?? "0");
            xnlstData = xmlDocument2.GetElementsByTagName("TxRepeat");
            for (int j = 0; j < xnlstData.Count; j++)
            {
                XmlElement xmlElement = xmlDocument.CreateElement(xnlstData[j].Name);
                xmlElement.InnerXml = xnlstData[j].InnerXml;
                xmlNode2.AppendChild(xmlElement);
            }
            if (xnOccur != null)
            {
                xnOccur.InnerText = num.ToString("000");
            }
            var b = xmlDocument.ToString();
            var c = xmlDocument.InnerXml;
            return c;
        }

        public string SecureStringToString2(SecureString input)
        {
            if (input == null) return "";
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(input);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public string SecureStringToString1(SecureString input)
        {
            if (input == null) return "";
            IntPtr valuePtr = Marshal.SecureStringToGlobalAllocUnicode(input);
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    char ch = (char)Marshal.ReadInt16(valuePtr, i * 2);
                    stringBuilder.Append(ch);
                }
                return stringBuilder.ToString();
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public string GetCheckCode(string accountNo)
        {
            int sum = 0;
            for (int i = 0; i < accountNo.Length - 1; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        sum += int.Parse(accountNo.Substring(i, 1)) * 3;
                        break;
                    case 1:
                        sum += int.Parse(accountNo.Substring(i, 1)) * 7;
                        break;
                    case 2:
                        sum += int.Parse(accountNo.Substring(i, 1)) * 9;
                        break;
                }
            }
            int remainder = sum % 10;
            int checkCode = (10 - remainder) % 10;
            return checkCode.ToString();
        }

        public string GetApplyCode(string VACCIDNO)
        {
            VACCIDNO = VACCIDNO.Trim().TrimStart('0');
            var applyCode = string.Empty;
            switch (VACCIDNO.Length)
            {
                case 13:
                    applyCode = VACCIDNO.Substring(0, 6);
                    break;
                case 14:
                    if (VACCIDNO.Substring(0, 5).Substring(3, 2) == "00")
                    {
                        applyCode = VACCIDNO.Substring(0, 3);
                    }
                    else
                    {
                        applyCode = VACCIDNO.Substring(0, 5);
                    }
                    break;
                case 16:
                    applyCode = VACCIDNO.Substring(0, 4);
                    break;
                default:
                    break;
            }
            return applyCode;
        }


        public void StrSubAll()
        {
            var s = "0123456789";
            var id = "PTL274O3";

            string n = null; //null 不能Substring也不能Pad 會ex
            var c = n ?? "";
            c.PadLeft(20, ' ');

            // var s1 = s.Sub();          js才有
            // var s2 = s.Substr(3, 5);   js才有
            var s3 = s.Substring(3, 5); //34567 startIndex 位置 length 幾個數字
            var a = id.Substring(6, 1);
            Console.WriteLine(s3);
            Console.WriteLine(a);
            Console.WriteLine($"___{n}____");
        }

        public void StrFuncTry()
        {
            string firstname;
            string lastname;

            firstname = "Steven Clark";
            lastname = "Clark";

            // Make String Clone ex:Steven Clark
            Console.WriteLine(firstname.Clone());

            //Compare two string value and returns 0 for true and 1 for false
            Console.WriteLine(firstname.CompareTo(lastname)); //equal then 1

            //Check whether specified value exists or not in string //contain then truue
            Console.WriteLine(firstname.Contains("ven"));

            //Check whether specified value is the last character of string // not end with then false
            Console.WriteLine(firstname.EndsWith("n"));
            //Check wheter first character of string is same as specified value
            Console.WriteLine(firstname.StartsWith("S"));

            //Compare two string and returns true and false //not equal then false
            Console.WriteLine(firstname.Equals(lastname));


            //Returns HashCode of String 1935778300
            Console.WriteLine(firstname.GetHashCode());

            //Returns type of string : System.String
            Console.WriteLine(firstname.GetType());

            //Returns type of string : String
            Console.WriteLine(firstname.GetTypeCode());

            //Returns the first index position of specified value the first index position of specified value
            Console.WriteLine(firstname.IndexOf("e"));

            //Covert string into lower case
            Console.WriteLine(firstname.ToLower());

            //Convert string into Upper case
            Console.WriteLine(firstname.ToUpper());

            //Insert substring into string
            Console.WriteLine(firstname.Insert(0, "Hello"));

            //Check Whether string is in Unicode normalization from C
            Console.WriteLine(firstname.IsNormalized());

            //Returns the last index position of specified value
            Console.WriteLine(firstname.LastIndexOf("e"));

            //Returns the Length of String
            Console.WriteLine(firstname.Length);

            //Deletes all the characters from begining to specified index.
            Console.WriteLine(firstname.Remove(5));

            // Replace the character :Stivin Clark
            Console.WriteLine(firstname.Replace('e', 'i'));

            //Split the string based on specified value
            string[] split = firstname.Split(new char[] { 'e' });

            Console.WriteLine(split[0]);
            Console.WriteLine(split[1]);
            Console.WriteLine(split[2]);



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
            Console.WriteLine("check: " + check);

            //安裝Castle.Core 且 using Castle.Core.Internal; 可以直接對物件判斷
            //效果等同 string.IsNullOrEmpty(a);
            //framework 4.7有效 net 6 無效 
            //var checka = a.IsNullOrEmpty();
            //var checkb = b.IsNullOrEmpty();
            //var checkc = c.IsNullOrEmpty();
            //Console.WriteLine("checka: " + checka);
            //Console.WriteLine("checkb: " + checkb);
            //Console.WriteLine("checkc: " + checkc);
        }

    }
}
