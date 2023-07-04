
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.Model;
using Lib.Extension;

namespace Lib
{
    public class ListTypeDataPractice
    {
        public void ListUpdate()
        {
            var list = new List<ObjectWithDefaultValue>();

            for (int i = 0; i < 5; i++)
            {
                var a = new ObjectWithDefaultValue();
                list.Add(a);
            }
            list = list.Select(
                (v, i) =>
                {
                    v.Seq = (++i).ToString("D8");
                    return v;
                }
                ).ToList();
        }

        public string ListValidate2(List<ObjectWithDefaultValue> list)
        {
            var a = string.IsNullOrEmpty("");
            var validate = list.FirstOrDefault(x => x.ValuelikeString == "123").ValuelikeString;
            return validate;
        }

        public bool ListValidate(List<ObjectWithDefaultValue> list)
        {
            var validate = list.All(x => x.ValuelikeString.Length == 3 || x.ValuelikeString.Length == 4 || x.ValuelikeString.Length == 5 || x.ValuelikeString.Length == 6);
            return validate;
        }

        /// <summary>
        /// 每 n 筆一包
        /// </summary>
        /// <param name="length"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<string[]> ChuckdObject(int length, List<string> source)
        {
            var result = source.Chunk(length).ToList();
            return result;
        }

        public List<List<string>> ChuckdObjectByLoop(int length, List<string> source)
        {
            var result = Enumerable.Range(0, (source.Count + length - 1) / length)
                      .Select(n => source.Skip(n * length).Take(length).ToList())
                      .ToList();
            return result;
        }

        public void DictionaryPractice()
        {
            Dictionary<int, int> numsDictionary = new Dictionary<int, int>();
            int[] nums = { 1, 3, 4, 23, 55, 22, 45, 2 };
            for (int i = 0; i < nums.Length; i++)
            {
                //跟list一樣 加入用add
                numsDictionary.Add(nums[i], i);//array vlaue set dic key
            }
            Console.WriteLine("23存在，所以ContainsKey:" + numsDictionary.ContainsKey(23));//set dic key 更好找
            Console.WriteLine("23存在，numsDictionary[23] 看到設好的 array index value:" + numsDictionary[23]);//set dic key 更好找
        }

        public void ArrayPractice()
        {
            var failArray = new[] { "1", "2", "3", "5", "6", "7", "8", "9A", "BC", "DE", "G", "H" };
            var count = failArray.Count();
            string fialStr = string.Join("、", failArray.Where(s => !string.IsNullOrEmpty(s)));
            Console.WriteLine(count + " : " + fialStr);

            var checkIndex = Array.IndexOf(failArray, "9A");
            var checkNoIndex = Array.IndexOf(failArray, "9");
            var checkContain = failArray.Contains("9A");
            var checkNotContain = failArray.Contains("9");
            var checkAny = failArray.Any(o => o == "9A");
            var checkNoAny = failArray.Any(o => o == "9");

            Console.WriteLine("checkIndex" + checkIndex); //9A contain return index 7 （base 0）
            Console.WriteLine("checkNoIndex" + checkNoIndex); //Not contain return -1
            Console.WriteLine("checkContain" + checkContain); //contain return true
            Console.WriteLine("checkNotContain" + checkNotContain); //Not contain return false
            Console.WriteLine("checkAny" + checkAny); //9A any exist return true
            Console.WriteLine("checkNoAny" + checkNoAny); //9 any Not exist return false
        }
        public void ListIndexPractice()
        {
            var failList = new List<string>() { "10", "2", "3", "5", "6", "7", "8", "9A", "BC", "DE", "G", "H", "99" };

            var checkIndex = failList.IndexOf("9A");
            var checkNoIndex = failList.IndexOf("9");
            var checkContain = failList.Contains("9A");
            var checkNotContain = failList.Contains("10");
            var checkAny = failList.Any(o => o == "9A");
            var checkNoAny = failList.Any(o => o == "9");

            Console.WriteLine("checkContain" + checkIndex); //9A contain return index 7 （base 0）
            Console.WriteLine("checkNoIndex" + checkNoIndex); //Not contain return -1
            Console.WriteLine("checkContain" + checkContain); //9A contain return true
            Console.WriteLine("checkNotContain" + checkNotContain); //Not contain false -1
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

        public List<string> SemiNumericListOrderBy(List<string> listStr = null)
        {
            //listStr = new List<string> { "1", "A", "B", "11", "10", "2", "3", "1", "C", "D", "E" };
            listStr = listStr.ToArray().OrderBy(x => x, new SemiNumericComparer()).ToList();
            Console.Write(string.Join(",", listStr));
            return listStr;
        }

        /// #List拆分法 #GetRange練習 #List拆一半
        /// </summary>
        public void getRangePractice()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var devide1 = list.GetRange(0, list.Count / 2); //1234
            var devide2 = list.GetRange(list.Count / 2, list.Count - list.Count / 2);//56789

            var devide3 = list.GetRange(0, list.Count / 2 + 1); //12345
            var devide4 = list.GetRange(list.Count / 2 + 1, list.Count - (list.Count / 2 + 1));//6789

            Console.WriteLine("list : " + string.Join("", list));

            Console.WriteLine("");
            Console.WriteLine("devide1");
            Console.Write(string.Format("{0,-6}", string.Join("", devide1)));
            Console.WriteLine(string.Format("{0,-6}", string.Join("", devide2)));
            Console.WriteLine("");
            Console.WriteLine("devide2");
            Console.Write(string.Format("{0,-6}", string.Join("", devide3)));
            Console.WriteLine(string.Format("{0,-6}", string.Join("", devide4)));

            //foreach (var d in devide2)
            //{
            //    Console.Write(d);
            //}
        }

        //物件list練習 linq練習 重要
        public void ObjectListSetVaue()
        {

            var jsonStr = string.Empty;
            List<SampleObjectModel> ob = JsonConvert.DeserializeObject<List<SampleObjectModel>>("");

            //物件list某個幾格屬性另外賦值 此時select初的class也可以放別的
            //ob只是被篩選出來 需要另外賦值
            var updateBoxList = ob.Select(x => new SampleObjectModel
            {
                ValueIsString = x.ValueIsString,//不變的資料 new出來是空的要給來源值
                ValuelikeString = "3 空戶",//我想要賦予的新值,且大家都一樣
                Pro1 = "1",
                Pro2 = "2",
            }).ToList();

            //我想要賦予的新值,且大家都一樣
            //ob直接被改變 不需要賦值
            ob.ForEach(o =>
            {
                //o.ValueIsString = o.ValueIsString;//不變的資料 就可以不用寫
                o.ValuelikeString = "3 空戶";
                o.Pro1 = "1";
                o.Pro2 = "2";
            });
            ob.Add(ob[0]);
            updateBoxList = ob;

            //物件List某個屬性轉list
            List<string> a = ob.Select(x => x.ValueIsString).ToList();
            //物件List某個屬性過濾存在與a列表相符 且移除空相符
            List<SampleObjectModel> b = ob.Where(o => a.Contains(o.ValueIsString)).Where(o => o.ValueIsString != null).ToList();
            //物件List某個屬性過濾存在與 "目標資料"相符
            List<SampleObjectModel> c = ob.Where(o => o.ValueIsString == "123").ToList();
            //物件List某個屬性過濾存在與b物件的 "所有屬性"相符
            List<SampleObjectModel> d = ob.Where(o => b.Contains(o)).ToList();

            //先GroupBy 再order select 物件List 當我ValueIsString需要distinct成很多group  每group只取一筆ValuelikeString最小的資料一筆 
            List<SampleObjectModel> e = ob.GroupBy(o => o.ValueIsString).Select(x => x.OrderByDescending(o => o.ValuelikeString).FirstOrDefault()).ToList();
            //先order 再distinct 一樣意思 有distinct擴展 code就比較漂亮
            List<SampleObjectModel> f = ob.OrderByDescending(o => o.ValuelikeString).Distinct(o => o.ValuelikeString).ToList();
            //更多資訊:https://www.cnblogs.com/ldp615/archive/2011/08/01/distinct-entension.html
        }

        /// <summary>
        /// list資料產報表
        /// </summary>
        public void ListExportFile()
        {
            var mailList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            //結餘表有明細
            int pageId = 0; //頁次
            int pageItemNums = 3; //單頁筆數
            int usedCount = 0; //可扣小計

            for (int i = 0; i < mailList.Count; i++)
            {
                var itemId = i + 1;
                if (itemId % pageItemNums == 1)
                {
                    //表頭
                    Console.WriteLine("第: " + ++pageId + "頁");
                }

                //小計Count1
                if (itemId % 3 == 0)
                {
                    var count = itemId - usedCount;
                    usedCount += count;
                    Console.WriteLine("");
                    Console.WriteLine("小計: " + count + "筆");
                }

                //明細
                Console.Write("明細: " + mailList[i] + ",");

                //小計Count1
                if (itemId == mailList.Count)
                {
                    var count = itemId - usedCount;
                    usedCount += count;
                    Console.WriteLine("");
                    Console.WriteLine("最後小計: " + count + "筆");
                }

                if (itemId % pageItemNums == 0 || itemId == mailList.Count)
                {
                    var TOTALPAGE = mailList.Count % pageItemNums == 0 ?
                                            (mailList.Count / pageItemNums).ToString() :
                                            (mailList.Count / pageItemNums + 1).ToString();
                    Console.WriteLine("");
                    Console.WriteLine("總頁數: " + TOTALPAGE);


                    if (itemId % pageItemNums == 0)
                    {
                        Console.WriteLine("----------------換頁-----------------");
                    }
                }
            }
        }

    }
}

