using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Castle.Core.Internal;
using Lib.Model.ParseJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;

namespace Lib;

public class JsonProcess
{
    public CustomParams ParseJson(string customParams)
    {
        CustomParams customParamsObj = JsonConvert.DeserializeObject<CustomParams>(customParams);
        return customParamsObj;
    }

    public bool JObjectGet(JObject rsbody2)
    {
        if (rsbody2 != null &&
            rsbody2["errorCode"] != null &&
            rsbody2["errorCode"].Value<string>() == "0")
        {
            return true;
        }

        return false;
    }
}
