﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    /// <summary>
    /// no one can be null
    /// </summary>
    public class ObjectWithDefaultValue
    {
        public string ValuelikeString { get; set; } = "";
        public string ValueIsString { get; set; } = "default";
        public int numberInt { get; set; } = 123;
        public string Seq { get; set; }
        //public ObjectWithDefaultValue()
        //{
        //    ValuelikeString = "";
        //    ValueIsString = "default";
        //    numberInt = 123;
        //}
    }
}
