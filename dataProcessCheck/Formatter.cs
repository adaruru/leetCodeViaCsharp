using System.Text.RegularExpressions;
using System;
using System.Text;


namespace dataProcessCheck
{
    /// <summary>
    ///  RegEx Pattern 中，若有明確的樣式，可以直接替換
    ///  如 "(\d{6})(\d)"， 符合的話，會有 $1 $2 結果，則可以用
    ///  oRegEx.Replace("1234567", "$1-$2")  得到 123456-7
    ///  若沒有明確樣式
    ///  如 "(\d|\d{3})(?=(\d{2})$)"，則就不能依上述的方式替換
    ///  例如 D2、D4 中的例子
    /// </summary>
    partial class Formatter
    {
        private const string constDateMark = " /-.";

        /// <summary>
        /// 若字串長度未達報表定義檔指定的長度，則將字串後補空白
        /// </summary>
        /// <param name="colLength"></param>
        /// <param name="colData"></param>
        /// <returns></returns>
        public static string CheckColumnLength(int colLength, string colData)
        {
            string paddingString = "";

            return colData + paddingString;
        }

        public static string GetRowString(string data, int colLength)
        {
            //  Unicode + extA
            Regex regSP = new Regex(@"[\u2000-\u9FFF]");
            //  造字 + 全形ASCII
            Regex _regSP = new Regex(@"[\uE000-\uFFEF]");
            string rtString = string.Empty;
            foreach (var item in data.ToCharArray())
            {
                var match = _regSP.IsMatch(item.ToString()) || regSP.IsMatch(item.ToString());
                if (match)
                {
                    colLength = colLength - 2;
                }
                else
                {
                    colLength = colLength - Encoding.GetEncoding("Big5").GetByteCount(item.ToString());
                }
                if (colLength >= 0)
                {
                    rtString = rtString + item;
                }
            }
            return rtString;
        }

        public class Clforptd
        {
            public string DataLen { get; set; }
            public string EditMask { get; set; }
            public string DataType { get; set; }
            public string Fraction { get; set; }
            public string PreCode { get; set; }
        }

        public static string Process(Clforptd dbDetailInfo, string strReportData)
        {
            int len = string.IsNullOrEmpty(dbDetailInfo.DataLen) ? 0 : int.Parse(dbDetailInfo.DataLen);
            if (string.IsNullOrEmpty(strReportData))
            {
                strReportData = "".PadLeft(len, ' ');
            }

            if (string.IsNullOrEmpty(dbDetailInfo.EditMask))
            {
                if (dbDetailInfo.DataType == "C")
                {
                    strReportData = GetRowString(strReportData, len);
                }
            }
            else
            {
                if (dbDetailInfo.EditMask.StartsWith("A"))
                {
                    if (dbDetailInfo.DataType == "C")
                    {
                        strReportData = GetRowString(strReportData, len);
                    }
                    strReportData = DataEditMaskA1(dbDetailInfo.EditMask, strReportData);
                    strReportData = DataEditMaskA2(dbDetailInfo.EditMask, strReportData);
                }
                else if (dbDetailInfo.EditMask.StartsWith("D"))
                {
                    //  D Series 碰到輸入字串長度超過欄位限制，則原字串後取固定長度
                    int nDataLen = string.IsNullOrEmpty(dbDetailInfo.DataLen) ? 0 : Convert.ToInt32(dbDetailInfo.DataLen);
                    int nFraction = string.IsNullOrEmpty(dbDetailInfo.Fraction) ? 0 : Convert.ToInt32(dbDetailInfo.Fraction);

                    //strReportData = AlingLenght(nDataLen, nFraction, strReportData);                
                    if (strReportData.Length > nDataLen)
                    {
                        int exLength = 0;
                        //  小數點與正負號額外計算
                        if (strReportData.Contains(".")) { exLength = exLength + 1; }
                        if (strReportData.Contains("+") || strReportData.Contains("-")) { exLength = exLength + 1; }
                        if (strReportData.Length > nDataLen + exLength)
                        {
                            strReportData = strReportData.Substring(strReportData.Length - nDataLen - exLength, nDataLen + exLength);
                        }
                    }

                    strReportData = DataEditMaskD1_4(dbDetailInfo.EditMask, strReportData);
                    strReportData = DataEditMaskD5_8(dbDetailInfo.EditMask, strReportData);
                    strReportData = DataEditMaskD9(dbDetailInfo.EditMask, strReportData);
                    strReportData = DataEditMaskDA_D(dbDetailInfo.EditMask, strReportData);
                    strReportData = DataEditMaskDE_F(dbDetailInfo.EditMask, strReportData);
                }
                else if (dbDetailInfo.EditMask.StartsWith("N") && (!string.IsNullOrEmpty(strReportData.Trim())))
                {
                    //  N Series 碰到輸入字串長度超過欄位限制，則原字串後取固定長度
                    int nDataLen = string.IsNullOrEmpty(dbDetailInfo.DataLen) ? 0 : Convert.ToInt32(dbDetailInfo.DataLen);
                    int nFraction = string.IsNullOrEmpty(dbDetailInfo.Fraction) ? 0 : Convert.ToInt32(dbDetailInfo.Fraction);

                    //strReportData = AlingLenght(nDataLen, nFraction, strReportData);
                    if (strReportData.Length > nDataLen)
                    {
                        int exLength = 0;
                        //  小數點與正負號額外計算
                        if (strReportData.Contains(".")) { exLength = exLength + 1; }
                        if (strReportData.Contains("+") || strReportData.Contains("-")) { exLength = exLength + 1; }
                        if (strReportData.Length > nDataLen + exLength)
                        {
                            strReportData = strReportData.Substring(strReportData.Length - nDataLen - exLength, nDataLen + exLength);
                        }
                    }
                    strReportData = DataEditMaskN1_4(dbDetailInfo.EditMask, nDataLen, nFraction, strReportData);
                    strReportData = DataEditMaskN5_8(dbDetailInfo.EditMask, nDataLen, nFraction, strReportData);
                }
                else if (dbDetailInfo.EditMask.StartsWith("T"))
                {
                    if (dbDetailInfo.DataType == "C")
                    {
                        strReportData = GetRowString(strReportData, len);
                    }
                    //2012.01.31 增加電話格式 XXXX-XXXXXXXX-XXXXXX
                    strReportData = DataEditMaskT1_3(dbDetailInfo.EditMask, strReportData);
                }
                else if (dbDetailInfo.EditMask.StartsWith("H"))
                {
                    if (dbDetailInfo.DataType == "C")
                    {
                        strReportData = GetRowString(strReportData, len);
                    }
                    strReportData = DataEditMaskH(dbDetailInfo.EditMask, strReportData);
                }
                else if (dbDetailInfo.EditMask.StartsWith("E", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    if (dbDetailInfo.DataType == "C")
                    {
                        strReportData = GetRowString(strReportData, len);
                    }
                    strReportData = DataEditMaskE1_4(dbDetailInfo.EditMask, strReportData);
                    strReportData = DataEditMaskE5_8(dbDetailInfo.EditMask, strReportData);
                }
                else
                {
                    if (dbDetailInfo.DataType == "C")
                    {
                        strReportData = GetRowString(strReportData, len);
                    }
                }
            }

            #region 處理前置符號
            string sPreCode = dbDetailInfo.PreCode?.Trim();
            if (!string.IsNullOrEmpty(sPreCode))
            {
                Regex oRegEx = new Regex(@"^(\s[-+]?)");

                if (oRegEx.IsMatch(strReportData))
                {
                    if (strReportData.Contains("-") || strReportData.Contains("+"))
                    {
                        strReportData = strReportData.Replace("-", "-" + sPreCode);
                        strReportData = strReportData.Replace("+", "+" + sPreCode);
                    }
                    else
                    {
                        var lenght = strReportData.Length + 1;
                        strReportData = string.Format("{0}{1}", sPreCode, strReportData.TrimStart(' '));
                        strReportData = strReportData.PadLeft(lenght, ' ');
                    }
                }
                else
                {
                    strReportData = string.Format("{0}{1}", sPreCode, strReportData);
                }
            }

            strReportData = CheckColumnLength(len, strReportData);
            #endregion
            return strReportData;
        }

    }



    /// <summary>
    /// EditMask A Series
    /// </summary>
    public partial class Formatter
    {
        /// <summary>
        /// 局號輸出格式
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskA1(string strEditMask, string strReportData)
        {
            if (strEditMask == "A1" && strReportData.Length == 7)
            {
                Regex oRegEx = new Regex(@"(\d{6})(\d)", RegexOptions.None);
                strReportData = oRegEx.Replace(strReportData, "$1-$2");
            }
            return strReportData;
        }
        private static string DataEditMaskA2(string strEditMask, string strReportData)
        {
            if (strEditMask == "A2" && strReportData.Length == 14)
            {
                Regex oRegEx = new Regex(@"(\d{6})(\d{8})", RegexOptions.None);
                strReportData = oRegEx.Replace(strReportData, "$1-$2");
            }
            return strReportData;
        }
    }

    /// <summary>
    /// EditMask D Series
    /// </summary>
    public partial class Formatter
    {
        /// <summary>
        /// YYYYMMDD
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskD1_4(string strEditMask, string strReportData)
        {
            Regex oRegEx = new Regex("D[2-4]");
            if (oRegEx.IsMatch(strEditMask))
            {
                int nPos = strEditMask[1] - '1';
                string splitChar = constDateMark[nPos].ToString();
                string strReplaceFormat = string.Format("$1{0}$2{0}$3", splitChar);
                if (strReportData == "0".PadRight(strReportData.Length, '0'))
                {
                    strReportData = " ".PadRight(strReportData.Length, ' ');
                }
                else
                if (strReportData.Length == 6)
                {
                    oRegEx = new Regex(@"(\d{2})(\d{2})(\d{2})", RegexOptions.None);
                    strReportData = oRegEx.Replace(strReportData, strReplaceFormat);
                }
                else if (strReportData.Length == 8)
                {
                    oRegEx = new Regex(@"(\d{4})(\d{2})(\d{2})", RegexOptions.None);
                    strReportData = oRegEx.Replace(strReportData, strReplaceFormat);
                }
                else
                {
                    //後匹配必須為 99,99 然後再往前比對
                    oRegEx = new Regex(@"(\d|\d{3})(?=(\d{2})(\d{2})$)", RegexOptions.None);
                    if (oRegEx.IsMatch(strReportData))
                    {
                        Match oMatch = oRegEx.Match(strReportData);
                        strReportData = string.Format("{1}{0}{2}{0}{3}",
                                splitChar, oMatch.Groups[1], oMatch.Groups[2], oMatch.Groups[3]);
                        if (strReportData.StartsWith("0"))
                        {
                            strReportData = " " + strReportData.Substring(1);
                        }
                    }
                }
            }
            return strReportData;
        }
        /// <summary>
        /// YYYYMM
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskD5_8(string strEditMask, string strReportData)
        {
            Regex oRegEx = new Regex("D[6-8]");
            if (oRegEx.IsMatch(strEditMask))
            {
                int nPos = strEditMask[1] - '5';
                string splitChar = constDateMark[nPos].ToString();
                string strReplaceFormat = string.Format("$1{0}$2", splitChar);
                if (strReportData == "0".PadRight(strReportData.Length, '0'))
                {
                    strReportData = " ".PadRight(strReportData.Length, ' ');
                }
                else if (strReportData.Length == 4)
                {
                    oRegEx = new Regex(@"(\d{2})(\d{2})", RegexOptions.None);
                    strReportData = oRegEx.Replace(strReportData, strReplaceFormat);
                }
                else if (strReportData.Length == 6)
                {
                    oRegEx = new Regex(@"(\d{4})(\d{2})", RegexOptions.None);
                    strReportData = oRegEx.Replace(strReportData, strReplaceFormat);
                }
                else
                {
                    //後匹配必須為 99,99 然後再往前比對
                    oRegEx = new Regex(@"(\d|\d{3})(?=(\d{2})$)", RegexOptions.None);
                    if (oRegEx.IsMatch(strReportData))
                    {
                        Match oMatch = oRegEx.Match(strReportData);
                        strReportData = string.Format("{1}{0}{2}",
                                splitChar, oMatch.Groups[1], oMatch.Groups[2]);
                        if (strReportData.StartsWith("0"))
                        {
                            strReportData = " " + strReportData.Substring(1);
                        }
                    }
                }
            }
            return strReportData;
        }
        /// <summary>
        /// HH:MM:SS
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskD9(string strEditMask, string strReportData)
        {
            if (strEditMask == "D9" && strReportData.Length == 6)
            {
                Regex oRegEx = new Regex(@"(\d{2})(\d{2})(\d{2})", RegexOptions.None);
                strReportData = oRegEx.Replace(strReportData, "$1:$2:$3");
            }
            return strReportData;
        }
        /// <summary>
        /// MMDD
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskDA_D(string strEditMask, string strReportData)
        {
            Regex oRegEx = new Regex("D[B-D]");
            if (oRegEx.IsMatch(strEditMask))
            {
                int nPos = strEditMask[1] - 'A';
                string splitChar = constDateMark[nPos].ToString();
                string strReplaceFormat = string.Format("$1{0}$2", splitChar);
                if (strReportData.Length == 4)
                {

                    oRegEx = new Regex(@"(\d{2})(\d{2})", RegexOptions.None);
                    strReportData = oRegEx.Replace(strReportData, strReplaceFormat);
                }
            }
            return strReportData;
        }
        /// <summary>
        /// HH:MM
        /// MM:SS
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskDE_F(string strEditMask, string strReportData)
        {
            Regex oRegEx = new Regex("D[E-F]");
            if (oRegEx.IsMatch(strEditMask) && strReportData.Length == 4)
            {
                oRegEx = new Regex(@"(\d{2})(\d{2})", RegexOptions.None);
                strReportData = oRegEx.Replace(strReportData, "$1:$2");
            }
            return strReportData;
        }
    }

    /// <summary>
    /// EditMask T Series
    /// </summary>
    public partial class Formatter
    {
        /// <summary>
        /// 電話格式
        /// 電話 T1 18碼 4-8-6: 9999-99999999-999999 
        /// 郵件號碼 T2
        ///     14碼數字切成6 6 2: 999999 99 99999 9
        ///     20碼數字切成6 6 2 5 1: 999999 999999 99 99999 9
        /// 電話 T3 16碼 2-8-6: 99-99999999-999999
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskT1_3(string strEditMask, string strReportData)
        {
            if ("T1".Equals(strEditMask, System.StringComparison.CurrentCultureIgnoreCase)
                && strReportData.Length == 18)
            {
                strReportData = string.Format("{0}-{1}-{2}"
                    , strReportData.Substring(0, 4)
                    , strReportData.Substring(4, 8)
                    , strReportData.Substring(12, 6));
            }
            else if (strEditMask == "T2" && strReportData.Length == 14)
            {
                strReportData = string.Format("{0} {1} {2}"
                    , strReportData.Substring(0, 6)
                    , strReportData.Substring(6, 6)
                    , strReportData.Substring(12, 2));
            }
            else if (strEditMask == "T2" && strReportData.Length == 20)
            {
                strReportData = string.Format("{0} {1} {2} {3} {4}"
                    , strReportData.Substring(0, 6)
                    , strReportData.Substring(6, 6)
                    , strReportData.Substring(12, 2)
                    , strReportData.Substring(14, 5)
                    , strReportData.Substring(19, 1));
            }
            else if (strEditMask == "T3" && strReportData.Length == 16)
            {
                strReportData = string.Format("{0}-{1}-{2}"
                   , strReportData.Substring(0, 2)
                   , strReportData.Substring(2, 8)
                   , strReportData.Substring(10, 6));
            }

            return strReportData;
        }
    }

    /// <summary>
    /// EditMask N Series
    /// </summary>
    public partial class Formatter
    {
        /// <summary>
        /// 需右靠，假設長度為 8
        /// N1:00001234
        /// N2:(+-)1234 (若為正，秀+號。若為負，秀-號)
        /// N3:(-)1234  (若為負，秀-號。正號不處理)
        /// N4:    1234
        /// N5:00,001,234
        /// N6:(+-)1,234
        /// N7:(-)1,234
        /// N8:    1,234
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskN1_4(string strEditMask, int strDataLen, int nFrac, string strReportData)
        {
            //接收資料時，是包含小數位數的
            Regex oRegEx = new Regex("N[1-4]");
            if (oRegEx.IsMatch(strEditMask))
            {
                string strNumData = strReportData;  //整數
                string strFracData = "";            //小數位      
                #region 區分整數、小位數
                if (nFrac > 0)
                {
                    strNumData = strReportData.Split('.')[0];
                    strFracData = "." + (strReportData.Split('.').Length > 1 ? strReportData.Split('.')[1].PadRight(nFrac, '0') : string.Empty.PadLeft(nFrac, '0'));
                    //strNumData = strReportData.Substring(0, strReportData.Length - nFrac);
                    //strFracData = string.Format(".{0}",
                    //    strReportData.Substring(strReportData.Length - nFrac, nFrac));
                }
                else
                {
                    strNumData = strReportData.Split('.')[0];
                }
                #endregion

                if (strDataLen == 0)
                {
                    strDataLen = strReportData.Length;
                }

                //  2020/05/26  Ana回覆 N1 => 整數部分向左補0，小數向右補0補齊長度
                if (strEditMask == "N1")
                {
                    if (strDataLen <= strNumData.Length + strFracData.Length)
                    {
                        strReportData = strNumData + strFracData;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strFracData))
                        {
                            strReportData = strNumData.PadLeft(strDataLen, '0');
                        }
                        else
                        {
                            strReportData = (strNumData + strFracData).PadLeft(strDataLen, '0');
                        }
                    }
                }
                if (strEditMask == "N3")
                {
                    strReportData = string.Format("{0}{1}", KillHeaderZero(strNumData), strFracData);
                    strReportData = strReportData.PadLeft(strDataLen, ' ');
                }
                else if (strEditMask == "N4")
                {
                    strReportData = string.Format("{0}{1}", KillHeaderZero(strNumData), strFracData);
                    strReportData = strReportData.PadLeft(strDataLen, ' ');
                }
            }
            return strReportData;
        }
        private static string DataEditMaskN5_8(string strEditMask, int strDataLen, int nFrac, string strReportData)
        {
            //接收資料時，是包含小數位數的
            Regex oRegEx = new Regex("N[5-8]");
            if (oRegEx.IsMatch(strEditMask))
            {
                string strNumData = strReportData;  //整數
                string strFracData = "";

                //  小數點前長度
                #region 區分整數、小位數
                if (nFrac > 0)
                {
                    strNumData = strReportData.Split('.')[0];
                    strFracData = "." + (strReportData.Split('.').Length > 1 ? strReportData.Split('.')[1].PadRight(nFrac, '0') : string.Empty.PadRight(nFrac, '0'));
                }
                else
                {
                    strNumData = strReportData.Split('.')[0];
                }

                #endregion

                if (strDataLen == 0)
                {
                    strDataLen = strReportData.Length;
                }
                string strData = "";
                #region N5
                if (strEditMask == "N5")
                {
                    if (strNumData[0] == '+' || strNumData[0] == '-')
                    {
                        if (nFrac > 0)
                        {
                            strData = strNumData[0] + (strNumData.Substring(1) + strFracData).PadLeft(strDataLen, '0');
                        }
                        else
                        {
                            strData = strNumData[0] + strNumData.Substring(1).PadLeft(strDataLen, '0');
                        }
                    }
                    else
                    {
                        if (nFrac > 0)
                        {
                            strData = (strNumData + strFracData).PadLeft(strDataLen + 1, '0');
                        }
                        else
                        {
                            strData = strNumData.PadLeft(strDataLen, '0');
                        }
                    }
                    return strData;
                }
                #endregion

                #region N6 ~ N8
                if (strEditMask == "N6" || strEditMask == "N7" || strEditMask == "N8")
                {
                    if (strNumData[0] == '+' || strNumData[0] == '-')
                    {
                        if (strNumData.Substring(1).TrimStart('0').TrimStart() != string.Empty)
                        {
                            strData = strNumData[0] + ConvertionHelper.NumberString2MoneyString(strNumData.Substring(1).TrimStart('0').TrimStart(), 0);
                        }
                        else
                        {
                            strData = strNumData[0] + ConvertionHelper.NumberString2MoneyString("0", 0);
                        }
                    }
                    else
                    {
                        if (strNumData.TrimStart('0').TrimStart() != string.Empty)
                        {
                            strData = ConvertionHelper.NumberString2MoneyString(strNumData.TrimStart('0').TrimStart(), 0);
                        }
                        else
                        {
                            strData = ConvertionHelper.NumberString2MoneyString("0", 0);
                        }
                    }
                    //  逗號的最大數量    
                    int kMark = (strDataLen - nFrac) % 3 == 0 ? (strDataLen - nFrac) / 3 - 1 : (strDataLen - nFrac) / 3;
                    if (nFrac != 0)
                    {
                        //  小數點
                        kMark = kMark + 1;
                    }
                    strDataLen = strDataLen + kMark;
                    strReportData = string.Format("{0}{1}", strData, strFracData);
                    strReportData = strReportData.PadLeft(strDataLen, ' ');
                    return strReportData;
                }
                #endregion
            }

            return strReportData;
        }
        /// <summary>
        /// 去除不必要的前置零、空白
        /// </summary>
        /// <param name="strNumData"></param>
        /// <returns></returns>
        private static string KillHeaderZero(string strNumData)
        {
            Regex oKillZeroReg = new Regex(@"^(0{0,})([-+]?)(0{0,})([0-9]+)");
            //會有五組(含全部)
            strNumData = oKillZeroReg.Replace(strNumData.Trim(), "$2$4");
            if (string.IsNullOrEmpty(strNumData))
            {
                return "0";
            }
            else if (strNumData.StartsWith("."))
            {
                return string.Format("0{0}", strNumData);
            }
            return strNumData;
        }
    }

    /// <summary>
    /// 當輸入字串長度大於定義檔定義長度，根據定義檔長度限制輸入字串
    /// </summary>
    public partial class Formatter
    {
        private static string AlignLength(int lenght, int nFrac, string strReportData)
        {
            Regex oRegEx = new Regex(@"^(\s[-+]?)");
            string sign = "";
            string strNumData = strReportData;  //整數
            string strFracData = ""; //小數
            if (nFrac > 0)
            {
                strNumData = strReportData.Split('.')[0];
                strFracData = "." + (strReportData.Split('.').Length > 1 ? strReportData.Split('.')[1].PadRight(nFrac, '0') : string.Empty.PadLeft(nFrac, '0'));
                lenght = lenght + 1;
            }
            else
            {
                strNumData = strReportData.Split('.')[0];
            }

            if (strReportData.Contains("-") || strReportData.Contains("+"))
            {
                sign = strNumData[0].ToString();
                strNumData = strNumData.Substring(1);

            }

            if (lenght != 0 && lenght < strNumData.Length + (strFracData.Length == 0 ? 0 : strFracData.Length))
            {


                //後取
                if (strReportData.Contains("-") || strReportData.Contains("+"))
                {

                    if (nFrac > 0)
                    {
                        strFracData = strFracData.Substring(0, nFrac + 1);

                        var start = (strNumData + strFracData).Length - lenght;

                        strReportData = sign + (strNumData + strFracData).Substring(start, lenght);
                    }
                    else
                    {
                        var star = (strNumData + strFracData).Length - lenght;

                        strReportData = sign + strNumData.Substring(star, lenght);
                    }
                }
                else
                {
                    if (nFrac > 0)
                    {
                        strFracData = strFracData.Substring(0, nFrac + 1);

                        var start = (strNumData + strFracData).Length - lenght;

                        strReportData = (strNumData + strFracData).Substring(start, lenght);
                    }
                    else
                    {
                        var start = (strNumData + strFracData).Length - lenght;

                        strReportData = strNumData.Substring(start, lenght);
                    }
                }
            }


            return strReportData;
        }
    }

    /// <summary>
    /// EditMask H Series
    /// </summary>
    public partial class Formatter
    {
        private static string DataEditMaskH(string strEditMask, string strReportData)
        {
            if (strEditMask == "H" && !string.IsNullOrEmpty(strReportData))
            {
                return "".PadLeft(strReportData.Length, '*');
            }
            return strReportData;
        }
    }

    /// <summary>
    /// EditMask E Series
    /// </summary>
    public partial class Formatter
    {
        private static string DataEditMaskE1_4(string strEditMask, string strReportData)
        {
            DateTime date = new DateTime();
            bool isParsed = DateTime.TryParseExact(strReportData, "yyyyMMdd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date);
            if (isParsed == false) return strReportData;
            var taiwanCalender = new System.Globalization.TaiwanCalendar();
            strReportData = taiwanCalender.GetYear(date).ToString("00#") +
                taiwanCalender.GetMonth(date).ToString("0#") +
                taiwanCalender.GetDayOfMonth(date).ToString("0#");

            Regex oRegEx = new Regex("E[2-4]");
            if (oRegEx.IsMatch(strEditMask)) //E2~E4
            {
                int nPos = strEditMask[1] - '1';
                string splitChar = constDateMark[nPos].ToString();
                string strReplaceFormat = string.Format("$1{0}$2{0}$3", splitChar);
                if (strReportData.Length == 7)
                {
                    oRegEx = new Regex(@"(\d{3})(\d{2})(\d{2})", RegexOptions.None);
                    strReportData = oRegEx.Replace(strReportData, strReplaceFormat);

                }
            }
            return strReportData;
        }

        /// <summary>
        /// 日期格式
        /// </summary>
        /// <param name="strEditMask"></param>
        /// <param name="strReportData"></param>
        /// <returns></returns>
        private static string DataEditMaskE5_8(string strEditMask, string strReportData)
        {
            DateTime date = new DateTime();
            bool isParsed = DateTime.TryParseExact(strReportData, "yyyyMM",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date);
            if (isParsed == false) return strReportData;

            var taiwanCalender = new System.Globalization.TaiwanCalendar();
            strReportData = taiwanCalender.GetYear(date).ToString("00#") +
                taiwanCalender.GetMonth(date).ToString("0#");

            Regex oRegEx = new Regex("E[6-8]");
            if (oRegEx.IsMatch(strEditMask))
            {
                int nPos = strEditMask[1] - '5';
                string splitChar = constDateMark[nPos].ToString();
                string strReplaceFormat = string.Format("$1{0}$2", splitChar);
                if (strReportData.Length == 5)
                {

                    oRegEx = new Regex(@"(\d{3})(\d{2})", RegexOptions.None);
                    strReportData = oRegEx.Replace(strReportData, strReplaceFormat);
                }
            }
            return strReportData;
        }
    }
}
