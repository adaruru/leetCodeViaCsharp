using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessCheck
{
    public class OtherTest
    {

        public static void LotteryGame()
        {
            Console.WriteLine("請輸入兩個數字做為選號範圍，並以,區隔");
            string[] strArr = Console.ReadLine().Split(',');
            var lotteryNumber = new List<int>();

            var a = int.Parse(strArr[0]);
            var b = int.Parse(strArr[1]);
            if (Math.Abs(a - b) < 5)
            {
                Console.WriteLine("範圍最少有六個數字");
            }
            else if (a < b)
            {
                lotteryNumber = RandomNoRepeat(a, b);
            }
            else
            {
                lotteryNumber = RandomNoRepeat(b, a);
            }
            Console.Write("[");
            string output = "";
            foreach (int i in lotteryNumber)
            {
                if (output != "")
                {
                    output += ",";
                }
                output += i;
            }
            Console.Write(output + "]");
            Console.ReadLine();
        }

        /// <summary>
        /// 3.試用迴圈與副程式寫出一樂透程式(數字可變更, 例1~10 or 4~20)
        /// </summary
        public static List<int> RandomNoRepeat(int a, int b)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            List<int> listNumbers = new List<int>(Enumerable.Range(a, b));
            listNumbers = listNumbers.OrderBy(num => rand.Next()).ToList<int>();
            List<int> list = new List<int>();
            list.AddRange(listNumbers.Take(6));

            //有地方錯 有時候會超出範圍
            //Random rand = new Random(Guid.NewGuid().GetHashCode());
            //List<int> listNumbers = new List<int>();
            //listNumbers.AddRange(Enumerable.Range(a, b)
            //                   .OrderBy(i => rand.Next())
            //                   .Take(6));
            return list;
        }

        /// <summary>
        /// 遞迴 n 加到 1
        /// </summary>
        public static void plusToTarget()
        {
            Console.WriteLine("請輸入要遞迴加總的目標數字");
            int x = Convert.ToInt32(Console.ReadLine());
            var result = RecursivePlus(x);
            Console.WriteLine(result);
        }

        public static int RecursivePlus(int n)
        {
            if (n == 1)
            { return 1; }
            else
            { return RecursivePlus(n - 1) + n; }
        }

    }
}
