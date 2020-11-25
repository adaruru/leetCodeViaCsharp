﻿using dataProcessCheck.Model;

using Newtonsoft.Json;
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

        //物件list練習 linq練習
        public void ObjectListSetVaue()
        {

            var jsonStr = string.Empty;
            List<SampleObjectModel> ob = JsonConvert.DeserializeObject<List<SampleObjectModel>>("");

            //物件list某個幾格屬性另外賦值 此時select初的class也可以放別的
            var updateBoxList = ob.Select(x => new SampleObjectModel
            {
                ValueIsString = x.ValueIsString,//不變的來源資料
                ValuelikeString = "3 空戶" //我想要賦予的新值,且大家都一樣
            }).ToList();

            //物件List某個屬性轉list
            List<string> a = ob.Select(x => x.ValueIsString).ToList();
            //物件List某個屬性過濾存在與a列表相符 且移除空相符
            List<SampleObjectModel> b = ob.Where(o => a.Contains(o.ValueIsString)).Where(o => o.ValueIsString != null).ToList();
            //物件List某個屬性過濾存在與 "目標資料"相符
            List<SampleObjectModel> c = ob.Where(o => o.ValueIsString == "123").ToList();          
            //物件List某個屬性過濾存在與b物件的 "所有屬性"相符
            List<SampleObjectModel> d = ob.Where(o => b.Contains(o)).ToList();
            //物件List 當我ValueIsString需要distinct成很多group  每group只取一筆ValuelikeString最小的資料一筆 
            List<SampleObjectModel> e = ob.GroupBy(o => o.ValueIsString).Select(x => x.OrderByDescending(o => o.ValuelikeString).FirstOrDefault()).ToList();
       
        }


    }
}
