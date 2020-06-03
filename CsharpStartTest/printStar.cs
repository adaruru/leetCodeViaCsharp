using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class printStar
    {
        public static void main()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            printHourglass(x);
            //PrintLineNoBreak(x);
            //PrintLineWithBreak(x);
            //PrintTriangle(x);
            //PrintPyramid(x);
            //Console.WriteLine("----------------------------------------------");
            //PrintPyramidWithSapce(x);
            //Console.WriteLine("----------------------------------------------");
            //PrintDiamond(x);
            //Console.WriteLine("----------------------------------------------");
            //PrintHollowPyramid(x);
            //Console.WriteLine("----------------------------------------------");
            //if (x % 2 == 0)
            //{
            //    Console.Write("只能輸入奇數");
            //}
            //else { PrintOddHourglass(x); }
        }

        // 印沙漏
        public static void printHourglass(int n)
        {
            bool isRevers = true;
            int starts = n;
            int spaces = 0;

            for (int level = 0; level < n; level++)
            {
                //印空白
                if (spaces != 0)
                {
                    for (int i = 0; i < spaces; i++)
                    {
                        Console.Write(" ");
                    }
                }
                // 印星星
                for (int i = 0; i < starts; i++)
                {
                    Console.Write("*");
                }
                //判斷空白 & 星星數量
                if (isRevers)
                {
                    starts -= 2;
                    spaces += 1;
                }
                else
                {
                    starts += 2;
                    spaces -= 1;
                }
                // 判斷是否反轉
                if (starts == 1)
                {
                    isRevers = false;
                }
                // 換行
                Console.WriteLine("");
            }
        }











        private static void PrintOddHourglass(int n)
        {
            //正三角形
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < ((n - i) * 2) - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine(" ");
            }
            //倒三角形
            Console.Write("X");
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i * 2) - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine(" ");
            }
        }
        private static void PrintHollowPyramid(int n)
        {
            //輸入n 但是n+2階的解
            n = n - 2;

            //做中間是n-1 蓋子的的右上一格+1變n 要跟著右移再+1 變n+1
            for (int i = 0; i < n + 1; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("*");

            for (int i = 0; i < n; i++)
            {
                //所有右移一格給最底下的蓋子
                for (int j = i; j <= i; j++)
                {
                    Console.Write(" ");
                }
                //一個倒三角空白
                for (int j = i; j < n - 1; j++)
                {
                    Console.Write(" ");
                }
                //一個右邊的星星
                for (int j = i; j <= i; j++)
                {
                    Console.Write("*");
                }
                //i*2 不夠，+1是因為第一排是兩個空格
                for (int j = 0; j < (i * 2) + 1; j++)
                {
                    Console.Write(" ");
                }
                //一個左邊的星星
                for (int j = i; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            //原本是n*2-1 但因為是n+2的解 蓋子變((n+2)*2)-1 
            for (int i = 0; i < ((n + 2) * 2) - 1; i++)
            {
                Console.Write("*");
            }
            //給下一題換行
            Console.WriteLine("");
        }
        private static void PrintPyramidWithSapce(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                for (int j = i; j <= x; j++)
                {
                    Console.Write("  ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*" + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintDiamond(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = n - i; j >= 1; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= (i * 2) - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine(" ");
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = ((n - i) * 2) - 1; j >= 1; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine(" ");
            }
        }


        private static void PrintLineNoBreak(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine(" ");
        }
        private static void PrintLineWithBreak(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("*");
            }
            Console.WriteLine(" ");
        }

        private static void PrintTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }
        private static void PrintPyramid(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = n - i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= (i * 2) - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }

    }
}
