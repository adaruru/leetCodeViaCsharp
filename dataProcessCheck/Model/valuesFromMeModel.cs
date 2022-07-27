using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessCheck.Model
{
    class ValuesFromMeModel :ValueFather,ICloneable//使該物件可以被深複製
    {
        public string ValuelikeString { get; set; }
        public string ValueIsString { get; set; }
        public string ValueString { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    class ValueFather {
        public string ValueForFather { get; set; }
    }

    /// <summary>
    /// 和 ValuesFromMeModel一模一樣 單沒有繼承關係
    /// </summary>
    class LikeValuesFromMeModel
    {
        public string ValuelikeString { get; set; }
        public string ValueIsString { get; set; }
        public string ValueString { get; set; }
    }
}
