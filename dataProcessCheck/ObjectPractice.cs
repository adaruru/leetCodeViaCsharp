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
    }
}
