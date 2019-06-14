using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Leet079_WordSearch2
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
            if (board.Length == 0) return false;
            /*
             [,,,]固定陣列Length會回傳所有i總數(i*i*i)，[][][]不固定陣列僅回傳一維i數
             GetLength回傳一維i數
             */

            //初始row/col一樣陣列數的bool Array
            bool[][] visited = new bool[board.Length][];

            for (int i = 0; i < board.Length; i++)
                visited[i] = new bool[board[0].Length];

            //Check個Array每一個開頭搜尋符合word的開頭
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Checker(board, word, 0, i, j, visited))
                        return true;
                }
            }
        return false;
        }
        static bool Checker(char[][] board, string word, int index, int i, int j, bool[][] visited)
        {
            if (index == word.Length) return true;
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[index] ||
                visited[i][j]) return false;

            visited[i][j] = true;

            var res = Checker(board, word, index + 1, i + 1, j, visited) ||
                      Checker(board, word, index + 1, i - 1, j, visited) ||
                      Checker(board, word, index + 1, i, j + 1, visited) ||
                      Checker(board, word, index + 1, i, j - 1, visited);

            visited[i][j] = false;

            return res;
        }

    }

}
