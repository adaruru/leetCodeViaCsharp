using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm
    {

        //1.請設計一支程式，可以輸入N個數字(如: 11, 7, 23, 18, 22, 90)，輸入完後顯示其排序結果(如: 7, 11, 18, 22, 23, 90)
        //請勿用 List(Of T).Sort 的方法
        //泡泡排序
        public static void BubbleSort()
        {
            Console.WriteLine("請輸入要排序的數字已空格區隔");
            string[] strArr = Console.ReadLine().Split(" ");
            List<int> intLst = new List<int>();
            foreach (string i in strArr)
            {
                intLst.Add(int.Parse(i));
            }
            int[] intArr = intLst.ToArray();
            int[] sortArr = bubbleSort(intArr);
            Console.Write("[");
            string output = "";
            foreach (int i in sortArr)
            {
                if (output != "")
                {
                    output += ",";
                }
                output += i;
            }
            Console.Write(output + "]");
        }
        static int[] bubbleSort(int[] intArr)
        {
            while (true)
            {
                int count = 0;
                for (int i = 1; i < intArr.Length; i++)
                {
                    if (intArr[i - 1] > intArr[i])
                    {
                        int temp = intArr[i];
                        intArr[i] = intArr[i - 1];
                        intArr[i - 1] = temp;
                        count += 1;
                    }
                }
                if (count == 0) break;
            }
            return intArr;
        }
    }
}


