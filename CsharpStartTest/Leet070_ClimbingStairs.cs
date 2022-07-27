using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// You are climbing a staircase. It takes n steps to reach the top.
    /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    /// 
    /// Constraints: Stairs number n
    /// 1 <= n <= 45
    /// </summary>
    class Leet070_ClimbingStairs
    {
        public static void main()
        {
            Console.Write("Stairs to get : ");
            int n = int.Parse(Console.ReadLine());
            var result = ClimbStairs(n);
            Console.Write(result);
        }

        ///重新解釋一次題目
        ///只能用1與2加總 求所有可能解有幾個
        ///規律f(n)= f(n-1)+f(n-2)
        ///如果題目改成 1 3 5 則 f(n)= f(n-1)+f(n-3)+f(n-5)
        static int ClimbStairs(int n)
        {
            int[] resultArray = new int[n + 1];
            if (n <= 2)
            {
                return n;//直接回傳的也要考慮
            }
            else
            {
                resultArray[0] = 0;
                resultArray[1] = 1;
                resultArray[2] = 2;
            }
            for (int i = 3; i < n + 1; i++)
            {
                resultArray[i] = resultArray[i - 1] + resultArray[i - 2];
            }
            return resultArray[n];
        }

        //每次都這樣跑太慢了
        //static int ClimbStairs(int n)
        //{
        //    var result = 0;
        //    //排除沒有-1 -2 的值 起碼大於3
        //    if (n <= 2)
        //    {
        //        return n;
        //    }
        //    else
        //    {
        //        result = ClimbStairs(n - 1) + ClimbStairs(n - 2);//每次都這樣跑太慢了
        //    }
        //    return result;
        //}

    }

}
