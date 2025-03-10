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
using DataProcessCheck;

namespace Lib;

public class JsonProcess
{
    public CustomParams ModelParse(string customParams)
    {
        CustomParams customParamsObj = JsonConvert.DeserializeObject<CustomParams>(customParams);
        return customParamsObj;
    }

    public string JObjectParse(string responseContent)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(responseContent));
        using var reader = new StreamReader(memoryStream);
        var readTxt = reader.CustomReadToEnd();
        JObject contentObj = JObject.Parse(readTxt);
        //string errorCode = contentObj.GetValue("errorCode").ToString();
        string errorCode = contentObj.GetValue("errorCode").Value<string>();
        //string errorCode = contentObj["errorCode"].Value<string>();

        var data2 = contentObj.GetValue("data").Value<object>(); //.Value<string> 不是 string 強轉會出錯
        var data = contentObj.GetValue("data").ToString();
        dynamic responseData = JObject.Parse(data);
        return errorCode;
    }

    public string JObjectDynamicParse(string responseContent)
    {
        JObject contentObj = JObject.Parse(responseContent);
        var data2 = contentObj.GetValue("data").Value<object>(); //.Value<string> 不是 string 強轉會出錯

        dynamic responseData = JObject.Parse(contentObj.GetValue("data").ToString());
        object? plain = responseData.plain;

        var decryptText = plain == null ? "" : plain.ToString();
        //var decryptText = responseData.plain == null ? "" : responseData.plain.Value<object>();

        return decryptText;
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
