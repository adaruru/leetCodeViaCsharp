using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Leet079_WordSearch1
    {
        public static void main()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            Char[][] checkArr = new char[row][];

            for (int i = 0; i < row; i++)
            {
                //隨各個row的i宣告，宣告各Col
                checkArr[i] = new char[col];
                //i每跑一次，Readline一次
                string[] str = Console.ReadLine().Split(" ");
                for (int j = 0; j < col; j++)
                {
                    Char x = Convert.ToChar(str[j]);
                    checkArr[i][j] = x;
                }
            }
            string CheckWord = Console.ReadLine();
            bool result = Exist(checkArr, CheckWord);
            Console.Write(result);
        }
        static bool Exist(char[][] board, string word)
        {

            /*
             [,,,]固定陣列Length會回傳所有i總數(i*i*i)，[][][]不固定陣列僅回傳一維i數
             GetLength回傳一維i數
             */

            return true;
           
        }
        

    }

}
