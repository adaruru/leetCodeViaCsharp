using dataProcessCheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.ComponentModel.Design;
using System.Data;
using Dapper;
using System.Data.SqlServerCe;

namespace dataProcessCheck
{

    public class ObjectPractice
    {
        //private System.Timers.Timer Mytimer;
        private Stopwatch StopWatch;

        /// <summary>
        /// 遍歷物件屬性、值
        /// </summary>
        public void ObjectGetValues()
        {

            var value = new ValuesFromMeModel()
            {
                ValueIsString = "111",
                ValuelikeString = "222",
                ValueString = "333"
            };

            var properties = value.GetType().GetProperties();

            //Type myType = typeof(ValuesFromMeModel);
            //FieldInfo[] fieldInfos = myType.GetFields();
            //for (int i = 0; i < fieldInfos.Length; i++)
            //{
            //    var v = (ValuesFromMeModel)fieldInfos[i].GetValue(value);
            //    Console.WriteLine("Name: " + v);
            //}

            foreach (var item in properties)
            {
                Console.WriteLine(
                    "Name: " + item.Name
                    + ",  value: " + item.GetValue(value, null)
                    + ",  dbType:" + (DbType?)Enum.GetNames(typeof(DbType)).ToList().IndexOf(item.PropertyType.Name)
                    + "  , dbEnum value:  " + Enum.GetNames(typeof(DbType)).ToList().IndexOf(item.PropertyType.Name)
                    );
            }
        }

        /// <summary>
        /// 遍歷屬性 只讓"部分"符合條件者賦值
        /// 當我物件長得有夠像，且賦值來源又都差不多的時候
        /// </summary>
        public void ObjectFiltSetValue()
        {
            //資料參考
            //google 關鍵字 C#遍歷物件屬性
            //如果我要賦值 https://www.itread01.com/content/1546423213.html
            //如果我只是要讀取 https://tedliou.com/archives/csharp-read-all-class-field-by-loop/
            var item = new NameAlikeModel();
            var value = new ValuesFromMeModel()
            {
                ValueIsString = "111",
                ValuelikeString = "222",
                ValueString = "333"
            };
            System.Reflection.PropertyInfo[] properties = item.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var properity = item.GetType().GetProperty($"weAreAlike{i + 1}");
                //SetValue 是 PropertyInfo[]原生語法
                properity.SetValue(item, value.ValuelikeString);
            }
            var result = item;
        }

        /// <summary>
        /// 遍歷屬性 "全部"賦值
        /// </summary>
        public void ObjectAllSetValues()
        {
            //必須要目標物件屬性數量一致
            var listStr = new List<string>();
            listStr.Add("我示1");
            listStr.Add("我要遍歷\"全部\"");
            listStr.Add("我來自");
            listStr.Add("外部");
            listStr.Add("資料");
            listStr.Add("可能不會像");
            listStr.Add("樓上");
            listStr.Add("那麼整齊");
            listStr.Add("可是又想");
            listStr.Add("做一次加");
            SetValues(listStr);
        }

        /// <summary>
        /// 通過遍歷屬性賦值
        /// 練習計時器使用
        /// </summary>
        /// <returns></returns>
        private NameAlikeModel SetValues(List<string> listStr)
        {
            StopWatch = new Stopwatch();
            //Mytimer.Enabled = true;  //啟動計時器 MyTimer.Interval = 1000; //設定計時器時間間隔，單位為ms

            //Mytimer.Start(); //重新計時
            Console.WriteLine("重新計時");
            StopWatch.Start();//重新計時
            var item = new NameAlikeModel();
            // Thread.Sleep(10000); //等個10秒看有沒有跑10秒
            Thread.Sleep(100); //等個0.1秒看有沒有跑0.1秒


            System.Reflection.PropertyInfo[] properties = item.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //遍歷物件 賦值1~物件數量數
                properties[i].SetValue(item, listStr[i]);
            }



            Console.WriteLine("停止計時");
            //Mytimer.Stop(); //停止計時
            StopWatch.Stop(); //停止計時
                              // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = StopWatch.Elapsed;

            //Format and display the TimeSpan value. 可以格式化初耗時毫秒、微秒
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            return item;
        }

        /// <summary>
        /// C# 也需要deep copy 噁心 跟js一樣噁心
        /// </summary>
        public void CheckCopy()
        {
            var value = new ValuesFromMeModel()
            {
                ValueIsString = "111",
                ValuelikeString = "222",
                ValueString = "333"
            };

            var v2 = (ValuesFromMeModel)value.Clone();
            v2.ValueIsString = "我改變了";
            var v3 = value;
        }

        /// <summary>
        /// 我要update set所有資料，可是如果資料為null我就不要update他
        /// </summary>
        public void SetAll()
        {
            var parameters = new DynamicParameters();
            var viewModel= new ValuesFromMeModel()
            {
                ValueIsString = "111",
                ValuelikeString = "222",
                ValueString = "333"
            };

            string updateSql = @"
--更新設定檔
UPDATE T_Set_POInfo
";
            string strSet = @" SET BRPOST = @BRPOST \r\n";
            //取得我viewModel所有資料
            var properties = viewModel.GetType().GetProperties();
            foreach (var item in properties)
            {
                //當我確定model有值才更新資料，GetValue return object 還要再回傳string
                if (!string.IsNullOrEmpty(item.GetValue(viewModel).ToString()))
                {
                    //set column 後 sql cmd 換行
                    strSet += " ," + item.Name + " = @" + item.Name + "\r\n";
                    parameters.Add("@" + item.Name, item.GetValue(viewModel), DbType.String);
                }
            }

            string strPk = @"WHERE BRPOST = @BRPOST";
            string strSql = updateSql + strSet + strPk;

            var result = new SqlCeConnection("my sql connection str").Execute(strSql, parameters);
        }

    }
}
