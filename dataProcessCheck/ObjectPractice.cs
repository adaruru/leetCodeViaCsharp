using dataProcessCheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataProcessCheck
{
    public class ObjectPractice
    {
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
            var value = new valuesFromMeModel()
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
        /// </summary>
        /// <returns></returns>
        private NameAlikeModel SetValues(List<string>  listStr)
        {
            var item = new NameAlikeModel();

            System.Reflection.PropertyInfo[] properties = item.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //遍歷物件 賦值1~物件數量數
                properties[i].SetValue(item, listStr[i]);
            }
            return item;
        }

    }
}
