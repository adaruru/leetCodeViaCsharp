using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataProcessCheck
{
    public class ListTypeDataPractice
    {
        public void DictionaryPravtice()
        {

        }
        /// <summary>
        /// 簡單list拆分法
        /// </summary>
        public void ListPractice()
        {
            var grid = new List<string>();
            var grid1 = new List<string>();
            var grid2 = new List<string>();
            for (int i = 0; i < grid.Count; i++)
            {
                if (i < grid.Count / 2)
                { grid1.Add(grid[i]); }
                else
                { grid2.Add(grid[i]); }
            }

            
        }

        /// <summary>
        /// List拆分法 GetRange練習
        /// </summary>
        public void getRangePractice()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var devide1 = list.GetRange(0, list.Count / 2); //1234
            var devide2 = list.GetRange(list.Count / 2, list.Count - (list.Count / 2));//56789

            var devide3 = list.GetRange(0, list.Count / 2 + 1); //12345
            var devide4 = list.GetRange(list.Count / 2 + 1, list.Count - (list.Count / 2 + 1));//6789

            Console.WriteLine("list");
            foreach (var d in list)
            {
                Console.Write(d);
            }
            Console.WriteLine("");
            Console.WriteLine("devide1");
            foreach (var d in devide1)
            {
                Console.Write(d);
            }
            Console.WriteLine("");
            Console.WriteLine("devide2");
            foreach (var d in devide2)
            {
                Console.Write(d);
            }
        }

        
    }
}
