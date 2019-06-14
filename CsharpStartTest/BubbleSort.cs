using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class BubbleSort
    {
        public static void main()
        {
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
                int count=0;
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


