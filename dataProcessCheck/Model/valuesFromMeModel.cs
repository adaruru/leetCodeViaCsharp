﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataProcessCheck.Model
{
    class ValuesFromMeModel:ICloneable
    {
        public string ValuelikeString { get; set; }
        public string ValueIsString { get; set; }
        public string ValueString { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
