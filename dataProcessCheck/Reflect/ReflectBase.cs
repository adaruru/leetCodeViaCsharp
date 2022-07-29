using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace DataProcessCheck.Reflect
{
    public class BaseEnumConstructor
    {

        public static int EnumId { get; set; }
        public bool IsSet { get; set; } = false;
        public BaseEnumConstructor(int id)
        {
            IsSet = true;
            EnumId = id;
        }
        public Dictionary<int, string> GetInfos()
        {
            var result = new Dictionary<int, string>();
            var pros = GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < pros.Length; i++)
            {
                int num;
                if (int.TryParse(pros[i].GetValue(this, null).ToString(), out num)
                    && pros[i].Name != "Id"
                    && pros[i].Name != "IsSet")
                {
                    var key = num;
                    var att = pros[i].GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                    var description = (DescriptionAttribute)att;
                    var value = description.Description;
                    result.Add(key, value);
                }
            }
            return result;
        }
        public List<int> GetValues()
        {
            var pros = GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var result = pros.Select(p =>
            {
                int num;
                int.TryParse(p.GetValue(this, null).ToString(), out num);
                return num;
            }).ToList();
            return result;
        }

        public string GetName()
        {
            if (IsSet)
            {
                var pros = GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                int num;
                var pro = pros.FirstOrDefault(p => int.TryParse(p.GetValue(this, null).ToString(), out num) && num == EnumId);

                var proName = pro.Name;
                return proName;
            }
            return "EnumClass id 不正確";
        }

        public string GetDescription()
        {
            if (IsSet)
            {
                var pros = GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                int num;
                var att = pros.FirstOrDefault(p => int.TryParse(p.GetValue(this, null).ToString(), out num) && num == EnumId)
                              .GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                var description = (DescriptionAttribute)att;
                var value = description.Description;
                return value;
            }
            return "EnumClass id 不正確";
        }
    }
    public class BaseEnumMethodBase
    {
        /// <summary>
        /// 取得ITSEnum所有內容 
        /// key Enum 值 int
        /// value Enum 描述 string 中文
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetInfos()
        {
            var result = new Dictionary<int, string>();
            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var stackTrace = new System.Diagnostics.StackTrace();
            for (int i = 0; i < pros.Length; i++)
            {
                int num;
                if (int.TryParse(pros[i].GetValue(null).ToString(), out num))
                {
                    var key = num;
                    var att = pros[i].GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                    var description = (DescriptionAttribute)att;
                    var value = description.Description;
                    result.Add(key, value);
                }
            }
            return result;
        }

        /// <summary>
        /// 取得ITSEnum所有內容 
        /// key Enum 值 string
        /// value Enum 描述 string 中文
        /// </summary>
        /// <param name="isStringType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetInfos(bool isStringType)
        {
            if (isStringType)
            {
                var result = new Dictionary<string, string>();
                var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                for (int i = 0; i < pros.Length; i++)
                {

                    var key = pros[i].GetValue(null).ToString();
                    var att = pros[i].GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                    var description = (DescriptionAttribute)att;
                    var value = description.Description;
                    result.Add(key, value);
                }
                return result;
            }
            else
            {
                return GetInfos().ToDictionary(entry => entry.Key.ToString(),
                                               entry => entry.Value);
            }
        }

        /// <summary>
        /// 取得 ITSEnum 所有 value int 
        /// </summary>
        /// <returns></returns>
        public static List<int> GetValues()
        {
            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var result = pros.Select(p =>
            {
                int num;
                int.TryParse(p.GetValue(null).ToString(), out num);
                return num;
            }).ToList();
            return result;
        }

        /// <summary>
        /// 取得 ITSEnum 所有 value int 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetValues(bool isStringType)
        {
            if (isStringType)
            {
                var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                var result = pros.Select(p => p.GetValue(null).ToString()).ToList();
                return result;
            }
            else
            {
                return GetValues().ConvertAll<string>(x => x.ToString());
            }

        }

        /// <summary>
        /// 取得 ITSEnum 所有 value int 
        /// </summary>
        /// <returns></returns>
        public static bool IsValueExist(object value)
        {
            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var pro = pros.FirstOrDefault(p => p.GetValue(null) == value);
            return pro != null;
        }

        /// <summary>
        /// 取得 ITSEnum 屬性名稱 英文
        /// </summary>
        /// <returns></returns>
        public static string GetName(object value)
        {
            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var proName = pros.FirstOrDefault(p => p.GetValue(null) == value).Name;
            return proName;
        }

        /// <summary>
        /// 取得 ITSEnum 屬性描述 中文
        /// </summary>
        /// <returns></returns>
        public static string GetDescription(object value)
        {

            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            // var pros = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var att = pros.FirstOrDefault(p => p.GetValue(null) == value)
                          .GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
            var description = (DescriptionAttribute)att;
            var result = description.Description;
            return result;
        }
    }

    public class BaseEnumAssembly
    {
        public static Dictionary<int, string> GetInfos()
        {
            var result = new Dictionary<int, string>();
            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < pros.Length; i++)
            {
                int num;
                if (int.TryParse(pros[i].GetValue(null).ToString(), out num))
                {
                    var key = num;
                    var att = pros[i].GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                    var description = (DescriptionAttribute)att;
                    var value = description.Description;
                    result.Add(key, value);
                }
            }
            return result;
        }

        public static Dictionary<string, string> GetInfos(bool isStringType)
        {
            if (isStringType)
            {
                var result = new Dictionary<string, string>();
                var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                for (int i = 0; i < pros.Length; i++)
                {

                    var key = pros[i].GetValue(null).ToString();
                    var att = pros[i].GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
                    var description = (DescriptionAttribute)att;
                    var value = description.Description;
                    result.Add(key, value);
                }
                return result;
            }
            else
            {
                return GetInfos().ToDictionary(entry => entry.Key.ToString(),
                                               entry => entry.Value);
            }
        }

        public static List<int> GetValues()
        {
            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var result = pros.Select(p =>
            {
                int num;
                int.TryParse(p.GetValue(null).ToString(), out num);
                return num;
            }).ToList();
            return result;
        }

        public static List<string> GetValues(bool isStringType)
        {
            if (isStringType)
            {
                var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                var result = pros.Select(p => p.GetValue(null).ToString()).ToList();
                return result;
            }
            else
            {
                return GetValues().ConvertAll<string>(x => x.ToString());
            }

        }

        /// <summary>
        /// 取得 ITSEnum 所有 value int 
        /// </summary>
        /// <returns></returns>
        public static bool IsValueExist(object value)
        {
            var pros = MethodBase.GetCurrentMethod().DeclaringType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var pro = pros.FirstOrDefault(p => p.GetValue(null) == value);
            return pro != null;
        }

        /// <summary>
        /// 取得 ITSEnum 屬性名稱 英文
        /// </summary>
        /// <returns></returns>
        public static string GetName(object value)
        {
            var asb = Assembly.GetExecutingAssembly().GetTypes();//.GetExportedTypes();
            //mscrolib IsSubclassOf /System.Runtime IsAssignableTo
            var children = asb.Where(t => t.IsSubclassOf(typeof(BaseEnumAssembly)) && t != typeof(BaseEnumAssembly));
            var proName = children.Select(c => c.GetProperties(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(p => p.GetValue(null) == value))
                                  .Where(c => c != null)
                                  .FirstOrDefault()?.Name;
            return proName;
        }

        /// <summary>
        /// 取得 ITSEnum 屬性描述 中文
        /// </summary>
        /// <returns></returns>
        public static string GetDescription(object value)
        {
            //mscrolib IsSubclassOf /System.Runtime IsAssignableTo
            var children = Assembly.GetExecutingAssembly().GetExportedTypes().Where(t => t.IsSubclassOf(typeof(BaseEnumAssembly)) && t != typeof(BaseEnumAssembly));
            var pro = children.Select(c => c.GetProperties(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(p => p.GetValue(null) == value))
                                .Where(c => c != null)
                                .FirstOrDefault();
            var att = pro.GetCustomAttributes(typeof(DescriptionAttribute), true)[0];
            var description = (DescriptionAttribute)att;
            var result = description.Description;
            return result;
        }
    }

    public class BaseEnumGeneric<T>
    {
        public static Type EnumType = typeof(T);

        public static Dictionary<int, string> GetInfos()
        {
            var result = new Dictionary<int, string>();

            var pros = EnumType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < pros.Length; i++)
            {
                int num;
                var value = string.Empty;
                var key = string.Empty;
                if (int.TryParse(pros[i].GetValue(null).ToString(), out num))
                {
                    key = pros[i].GetValue(null).ToString();
                    try
                    {
                        var att = pros[i].GetCustomAttributes(typeof(DisplayAttribute), true)[0];
                        value = ((DisplayAttribute)att).Name;
                    }
                    catch (Exception ex)
                    {
                        value = $"{key} Enum 取 Display Name 錯誤";
                    }
                    result.Add(num, value);
                }
            }
            return result;
        }

        public static Dictionary<string, string> GetInfos(bool isEnumString)
        {
            if (isStringType)
            {
                var result = new Dictionary<string, string>();
                var pros = EnumType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                for (int i = 0; i < pros.Length; i++)
                {
                    var key = pros[i].GetValue(null).ToString();
                    var att = pros[i].GetCustomAttributes(typeof(DisplayAttribute), true)?[0];
                    var value = att == null ? $"{key} Enum 沒有 Display Name" : ((DisplayAttribute)att).Name;
                    result.Add(key, value);
                }
                return result;
            }
            else
            {
                return GetInfos().ToDictionary(entry => entry.Key.ToString(),
                                               entry => entry.Value);
            }
        }

        public static List<int> GetValues()
        {
            var pros = EnumType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var result = pros.Select(p =>
            {
                int num;
                int.TryParse(p.GetValue(null).ToString(), out num);
                return num;
            }).ToList();
            return result;
        }

        public static List<string> GetValues(bool isEnumString)
        {
            if (isEnumString)
            {
                var pros = EnumType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
                var result = pros.Select(p => p.GetValue(null).ToString()).ToList();
                return result;
            }
            else
            {
                return GetValues().ConvertAll<string>(x => x.ToString());
            }
        }

        /// <summary>
        /// 取得 ITSEnum 所有 value int 
        /// </summary>
        /// <returns></returns>
        public static bool IsValueExist(object value)
        {
            var pros = EnumType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var pro = pros.FirstOrDefault(p => p.GetValue(null) == value);
            return pro != null;
        }

        /// <summary>
        /// 取得 ITSEnum 屬性名稱 英文
        /// </summary>
        /// <returns></returns>
        public static string GetName(object value)
        {
            var pros = EnumType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var pro = pros?.Where(p => p.GetValue(null).ToString() == value.ToString());
            if (pro.Count() != 1 || pro == null)
            {
                return $"{value} Enum 值重複或不存在";
            }
            var result = pro.FirstOrDefault().Name;
            return result;
        }

        /// <summary>
        /// 取得 ITSEnum 屬性描述 中文
        /// </summary>
        /// <returns></returns>
        public static string GetDescription(object value)
        {
            var pros = EnumType?.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var att = new object();
            var pro = pros?.Where(p => p.GetValue(EnumType, null).ToString() == value.ToString());
            if (pro.Count() != 1 || pro == null)
            {
                return $"{value} Enum 值重複或不存在";
            }
            try
            {
                att = pro.FirstOrDefault().GetCustomAttributes(typeof(DisplayAttribute), true)[0];
            }
            catch (Exception ex)
            {

                return $"{value} Enum 取 Display Name 錯誤";
            }

            var description = (DisplayAttribute)att;
            var result = description.Name;
            return result;
        }
    }
}
