using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Leet069_Sqrt
    {
        public static void main()
        {
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(MySqrt(x));
        }
        static int MySqrt(int x)
        {
            //一行解法 return (int)Math.Sqrt(x);

            //Binary search log(n)
            long start = 0;
            long end = x;

            //如果end是1或0的話
            if (end * end == x) {
                return (int)end;
            }

            //+1保留小數點的位置
            while (start+1<end)
            {
                //隨start+1,mid不斷往前以找出
                long mid = start + (end - start) / 2;
                //如果找到了
                if (mid * mid == x)
                {
                    //mid是long,透過強轉成int(無條件捨去)
                    return (int)mid;
                }
                //找出的mid太小了 start移到mid為起點，來縮小找的範圍
                else if (mid * mid < x)
                {
                    start = mid;
                }
                //找出的mid太大 end移到mid來縮小找的範圍
                else
                {
                    end = mid;
                }
            }
            //當start+1逼近end、x^2，仍找不到剛好等於的
            return (int)start;
        }
    }
}
