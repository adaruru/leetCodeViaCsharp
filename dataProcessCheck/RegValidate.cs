using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;//注意這個要using
using System.Threading.Tasks;

namespace dataProcessCheck
{
    //正則驗證資料
    public class RegValidate
    {
        /// <summary>
        /// 驗證email
        /// </summary>
        public void regValidEmail()
        {
            /*
             * 
             */

            string email = "123asd@asd.sdf.com";
            string email2 = "123asasdad@asddd.sdf.comdddd";//false comdddd大於3碼
            string[] testPlan = { email, email2 };
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            ///正則由斜線區分 /^([A-Za-z0-9_\-\.\u4e00-\u9fa5])+\@([A-Za-z0-9_\-\.]) +\.([A-Za-z]{2,8})$/
            ///const emailRule = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/;
            Regex regex2 = new Regex(@"^([A-Za-z0-9_\-\.\u4e00-\u9fa5])+\@([A-Za-z0-9_\-\.]) +\.([A-Za-z]{2,8})$");
            Match match = regex.Match(email);

            //Console.WriteLine("regTest:" + email + "=>" + match.Success);
            //Console.WriteLine("regTest:" + email2 + "=>" + match.Success);
            foreach (var mail in testPlan)
            {
                Match mach = regex.Match(mail);
                Console.WriteLine("regTest:" + mail + "=>" + mach.Success);
            }


        }

        /// <summary>
        /// 驗證
        /// </summary>
        public void sample()
        {
            // Define a regular expression for repeated words.
            Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.
            string text = "The the quick brown fox  fox jumps over the lazy dog dog.";

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report the number of matches found.
            Console.WriteLine("{0} matches found in:\n   {1}",
                              matches.Count,
                              text);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at positions {1} and {2}",
                                      groups["word"].Value,
                                      groups[0].Index,
                                      groups[1].Index);
            }

        }

        public void boolPractice()
        {
            var a = true;
            var b = true;
            var c = a && b;

            var d = !a && !b;


            var e = !(a && b);
            var f = (a || b);
            var g = !a || !b;
            var h = !(a || b);
            var i = !(!a && !b);
            var j = !(!a || !b);
            Console.WriteLine("   a && b    :" + c);
            Console.WriteLine("!(!a || !b)  :" + j);
            Console.WriteLine("----------------------");
            Console.WriteLine(" !a || !b    :" + g);
            Console.WriteLine("!(a && b)    :" + e);     
            Console.WriteLine("----------------------");
            Console.WriteLine(" !a && !b    :" + d);
            Console.WriteLine("!(a || b)    :" + h);
            Console.WriteLine("----------------------");
            Console.WriteLine(" (a || b)    :" + f);
            Console.WriteLine(" !(!a && !b) :" + i);
        }
    }
}
