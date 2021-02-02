using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace dataProcessCheck
{
    public partial class ConvertionHelper
    {
        public static T Ptr2Structure<T>(byte[] bytData, ref int nOffset)
        {
            try
            {
                #region 原程式 2013.03.08
                //Type type = typeof(T);
                //IntPtr oPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bytData, nOffset);
                //T obj = (T)Marshal.PtrToStructure(oPtr, type);
                //nOffset += Marshal.SizeOf(obj);
                //return obj;
                #endregion

                Type type = typeof(T);
                int nStructLen = Marshal.SizeOf(type);
                IntPtr ptr = Marshal.AllocHGlobal(nStructLen);  //建立一個 struct 大小的物件

                int nCopyLen = Math.Min(nStructLen, bytData.Length - nOffset);
                Marshal.Copy(bytData, nOffset, ptr, nCopyLen);
                T objData = (T)Marshal.PtrToStructure(ptr, type);
                Marshal.FreeHGlobal(ptr);
                nOffset += nStructLen;
                return objData;
            }
            catch (Exception) { }
            return default(T);
        }
        public static byte[] Ptr2ByteArray(byte[] bytData, int nOffset, int nByteLen)
        {
            #region 原程式 2013.03.08
            //IntPtr oPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bytData, nOffset);
            //byte[] bytRetData = new byte[nByteLen];
            //Marshal.Copy(oPtr, bytRetData, 0, nByteLen);
            //return bytRetData;
            #endregion

            byte[] bytRetData = new byte[nByteLen];
            Array.Copy(bytData, nOffset, bytRetData, 0, nByteLen);
            return bytRetData;
        }
        public static byte[] Structure2ByteArray(object obj)
        {
            int Length = Marshal.SizeOf(obj);
            byte[] rawData = new byte[Length];
            IntPtr ptr = Marshal.AllocHGlobal(Length);
            Marshal.StructureToPtr(obj, ptr, false);
            Marshal.Copy(ptr, rawData, 0, Length);
            Marshal.FreeHGlobal(ptr);
            return rawData;
        }
        /// <summary>
        /// 將 ByteArray 資料轉換為 Struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rawData"></param>
        /// <param name="objStru"></param>
        public static void ByteArray2Structure<T>(byte[] rawData, ref T objStru)
        {
            object objData = (object)objStru;
            int nStructLen = Marshal.SizeOf(objData);
            IntPtr ptr = Marshal.AllocHGlobal(nStructLen);
            int nCopyLen = Math.Min(nStructLen, rawData.Length);
            Marshal.Copy(rawData, 0, ptr, nCopyLen);
            objData = Marshal.PtrToStructure(ptr, objData.GetType());
            Marshal.FreeHGlobal(ptr);
            objStru = (T)objData;
        }
        /// <summary>
        /// 將 ByteArray 資料轉換為 Struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rawData"></param>
        /// <param name="nPos"></param>
        /// <param name="objStru"></param>
        public static void ByteArray2Structure<T>(byte[] rawData, int nPos, ref T objStru)
        {
            int nStructLen = Marshal.SizeOf(objStru);
            IntPtr ptr = Marshal.AllocHGlobal(nStructLen);
            int nCopyLen = Math.Min(nStructLen, rawData.Length - nPos);
            Marshal.Copy(rawData, nPos, ptr, nCopyLen);
            object objData = Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            objStru = (T)objData;
        }
    }

    public partial class ConvertionHelper
    {
        public static byte[] String2ByteArray(string data)
        {
            return String2ByteArray(data, true);
        }
        public static byte[] String2ByteArray(string data, bool IsUnicode)
        {
            if (IsUnicode)
            {
                System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
                byte[] bytMsg = enc.GetBytes(data);
                return bytMsg;
            }
            else
            {
                System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
                byte[] bytMsg = enc.GetBytes(data);
                byte[] bytMsg2 = new byte[bytMsg.Length / 2];
                for (int nPos = 0; nPos < bytMsg2.Length; nPos++)
                {
                    bytMsg2[nPos] = bytMsg[nPos * 2];
                }
                return bytMsg2;
            }
        }
        public static byte[] String2ByteArray(string data, int nDataLen)
        {
            System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
            byte[] bytMsg = new byte[nDataLen];
            enc.GetBytes(data).CopyTo(bytMsg, 0);
            return bytMsg;
        }

        public static string ByteArray2String(byte[] data)
        {
            // 2012.06.20 再次修改 PutDataToGM 有時為空值的問題，觀察以下程式碼是否有用
            //IntPtr oPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            //return Marshal.PtrToStringUni(oPtr);

            System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
            return enc.GetString(data);
        }
        public static string ByteArray2String(byte[] data, int nCharLen)
        {
            // 2012.06.20 再次修改 PutDataToGM 有時為空值的問題，觀察以下程式碼是否有用
            //IntPtr oPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            //return Marshal.PtrToStringUni(oPtr, nCharLen);

            System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
            return enc.GetString(data, 0, nCharLen);
        }

        public static string ByteArray2String(char[] data)
        {
            // 2012.06.20 再次修改 PutDataToGM 有時為空值的問題，觀察以下程式碼是否有用
            //IntPtr oPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            //return Marshal.PtrToStringUni(oPtr);

            // 需將 char array 轉成 byte array
            System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
            return enc.GetString(enc.GetBytes(data));
        }
        public static string ByteArray2String(char[] data, int nCharLen)
        {
            // 2012.06.20 再次修改 PutDataToGM 有時為空值的問題，觀察以下程式碼是否有用
            //IntPtr oPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            //return Marshal.PtrToStringUni(oPtr, nCharLen);

            // 需將 char array 轉成 byte array
            System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
            return enc.GetString(enc.GetBytes(data), 0, nCharLen);
        }
    }

    public partial class ConvertionHelper
    {
        ///// +++++++++++++++++++++++++++++++ 設定 ++++++++++++++++++++++++++++++
        /////   \u0800-\u4E00 (日文)
        /////   \u4E00-\u9fa5 (中文)
        /////   \u9fa5-\uFFFF (韓文或其他)
        /////   \u0080-\uFFFF 中日韓3byte以上的字符
        /////   \uFE30-\uFFA0 全型符號 
        ///// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ///// 假設資料來源為 [ 123 abc 456 def ]
        ///// 使用  (?<=\s)\d+(?=\s)  會得到  "123"、"456"
        ///// 使用  \s\d+\s           會得到  " 123 "、" 456 " 
        ///// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /////  oRegExp2 = "([0-9]{1,3})(?=([0-9]{3})+(?:$|\\.))"
        /////  var sNewValue = "12345678".replace(oRegExp2, "$1,");

        /// <summary>
        /// 金額撇節格式
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="nFrac"></param>
        /// <returns></returns>
        public static string NumberString2MoneyString(string strSource, int nFrac)
        {
            if (!string.IsNullOrEmpty(strSource))
            {
                Regex oRegEx1 = new Regex(@"^([+-]?)([0-9]*)(\.?)([0-9]*)$");
                if (oRegEx1.IsMatch(strSource))
                {
                    Match oMatch = oRegEx1.Match(strSource);
                    string sMark = oMatch.Groups[1].ToString(); //正負號
                    string sNum = oMatch.Groups[2].ToString();  //整數

                    Regex oRegExp2 = new Regex(@"([0-9]{1,3})(?=([0-9]{3})+(?:$|\.))");
                    string sNewValue = oRegExp2.Replace(sNum, "$1,");

                    string strDataFrac = oMatch.Groups[4].ToString();
                    if (nFrac > strDataFrac.Length)
                    {
                        strSource = string.Format("{0}{1}.{2}", sMark, sNewValue, strDataFrac.PadRight(nFrac, '0'));
                    }
                    else
                    {
                        strSource = string.Format("{0}{1}{2}{3}", sMark, sNewValue, oMatch.Groups[3], oMatch.Groups[4]);
                    }
                }
            }
            return strSource;
        }

        /// <summary>
        /// 半型轉全型
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string HelfString2FullString(string strSource)
        {
            const string HelfString = " !#\"$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";  //全型對照表
            const string AsciiFullString = "　！＃”＄％＆’（）＊＋，－．／０１２３４５６７８９：；＜＝＞？＠ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ〔＼〕＾＿‘ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ｛｜｝～";

            if (!string.IsNullOrEmpty(strSource))
            {
                //尋找所有 0x20-0x7f 的字元
                string strTemp = strSource;
                try
                {
                    string strMatch = @"[\x20-\x7F]";
                    Regex oRegEx = new Regex(strMatch);
                    while (oRegEx.IsMatch(strTemp))
                    {
                        Match oMatch = oRegEx.Match(strTemp);
                        //重新串接
                        string strTemp1 = strTemp.Substring(oMatch.Index, oMatch.Length);
                        string strTemp2 = strTemp1;
                        if (HelfString.IndexOf(strTemp1) != -1)
                        {
                            strTemp2 = AsciiFullString.Substring(HelfString.IndexOf(strTemp1), 1);
                        }
                        string strTemp3 = string.Format("{0}{1}{2}",
                                strTemp.Substring(0, oMatch.Index),
                                strTemp2,
                                strTemp.Substring(oMatch.Index + 1));
                        strTemp = strTemp3;
                    }
                    strSource = strTemp;
                }
                catch (Exception) { }
            }
            return strSource;
        }
        /// <summary>
        /// 全型轉半型
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string FullString2HelfString(string strSource)
        {
            const string HelfString = " !#\"$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";	//全型對照表
            const string AsciiFullString = "　！＃”＄％＆’（）＊＋，－．／０１２３４５６７８９：；＜＝＞？＠ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ〔＼〕＾＿‘ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ｛｜｝～";

            string strTemp = strSource;
            try
            {
                string strMatch = string.Format(@"[{0}]", AsciiFullString);
                Regex oRegEx = new Regex(strMatch);
                while (oRegEx.IsMatch(strTemp))
                {
                    Match oMatch = oRegEx.Match(strTemp);
                    //重新串接
                    string strTemp1 = strTemp.Substring(oMatch.Index, oMatch.Length);
                    string strTemp2 = strTemp1;
                    if (AsciiFullString.IndexOf(strTemp1) != -1)
                    {
                        strTemp2 = HelfString.Substring(AsciiFullString.IndexOf(strTemp1), 1);
                    }
                    string strTemp3 = string.Format("{0}{1}{2}",
                            strTemp.Substring(0, oMatch.Index),
                            strTemp2,
                            strTemp.Substring(oMatch.Index + 1));
                    strTemp = strTemp3;
                }
                strSource = strTemp;
            }
            catch (Exception) { }
            return strSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Big5ByteLen(string data)
        {
            byte[] bytMsg = Unicode2Big5(data);
            return bytMsg.Length;
        }
        public static byte[] Unicode2Big5(string data)
        {
            //System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            //byte[] bytMsg = enc.GetBytes(data);
            //return bytMsg;

            byte[] bytMsg = Encoding.GetEncoding(950).GetBytes(data);
            return bytMsg;
        }
        /// <summary>
        /// 數字字串轉日期格式
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="cMark"></param>
        /// <returns></returns>
        public static string NumberString2DateString(string strSource, char cMark)
        {
            if ((!string.IsNullOrEmpty(strSource)) && (strSource.Length <= 8))
            {
                Regex oRegEx = new Regex("([0-9]{1,3})(?=([0-9]{2})(?:$|))");
                string strMask = string.Format("$1{0}", cMark);
                strSource = oRegEx.Replace(strSource, strMask);
            }
            return strSource;
        }
    }

    public partial class ConvertionHelper
    {
        /// <summary>
        /// 將純數字字串轉 Pack 形式 (結尾 c 為正，d 為負)
        /// "470000",4位 --> 0x04 0x70 0x00 0x0c
        /// </summary>
        /// <param name="data">原數字字串</param>
        /// <param name="packLen">Pack 後長度</param>
        public static byte[] PackString2ByteArray(string data, int packLen)
        {
            byte[] bytData = new byte[packLen];
            Regex oReg = new Regex(@"^([+-]?)(\s*)(\d+$)");    //2011.08.12 由 ^[+-]?\d+$ 改為 ^([+-]?)(\s*)(\d+$)
            String sPreData = data.Trim();
            sPreData = sPreData.Replace(",", "");
            if (string.IsNullOrEmpty(sPreData))
            {
                sPreData = "0";
            }
            #region 修改前的作法
            /*                        
            if (oReg.IsMatch(sPreData))
            {
                string sTransData;
                if (sPreData.StartsWith("-"))
                {
                    sTransData = string.Format("{0}d", sPreData.Substring(1));
                }
                else if (sPreData.StartsWith("+"))
                {
                    sTransData = string.Format("{0}c", sPreData.Substring(1));
                } else {
                    sTransData = sPreData + "c";
                }

                bytData = String2HexByteArray(sTransData, packLen);
            }                        
            */
            #endregion

            if (oReg.IsMatch(sPreData))
            {
                Match oMatch = oReg.Match(sPreData);
                string sMark = oMatch.Groups[1].ToString(); //正負號
                string sNum = oMatch.Groups[3].ToString();  //整數

                string sTransData;
                if (sMark == "-")
                {
                    sTransData = string.Format("{0}d", sNum);
                }
                else if (sMark == "+")
                {
                    sTransData = string.Format("{0}c", sNum);
                }
                else
                {
                    sTransData = string.Format("{0}c", sPreData);
                }

                bytData = String2HexByteArray(sTransData, packLen);
            }

            return bytData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        private static string UnPackByteArray2Data(byte[] aryData)
        {
            string strHexData = "";
            foreach (byte oData in aryData)
            {
                strHexData = strHexData + string.Format("{0:X}", oData).PadLeft(2, '0').ToUpper();
            }
            #region 判別正負號
            if (strHexData.EndsWith("C") || strHexData.EndsWith("F"))
            {
                strHexData = strHexData.Substring(0, strHexData.Length - 1);
            }
            else if (strHexData.EndsWith("D"))
            {
                strHexData = "-" + strHexData.Substring(0, strHexData.Length - 1);
            }
            else
            {
                //2011.08.10 PTM151 UnPack 有誤，
                //中心丟 0x4040404040 要轉成 "" 或 "0";
                int nDataLen = strHexData.Length;
                strHexData = "0".PadRight(nDataLen, '0');
            }
            #endregion
            return strHexData;
        }

        /// <summary>
        /// 0x04 0x70 0x00 0x0c --> 470000
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        public static string UnPackByteArray2String(byte[] aryData)
        {
            return UnPackByteArray2String(aryData, 0);
        }
        public static string UnPackByteArray2String(byte[] aryData, int nDataLen)
        {
            string strHexData = UnPackByteArray2Data(aryData);
            strHexData = KillZero(strHexData);
            if (nDataLen != 0)
            {
                //2013.08.28 判斷正負值，再補值
                if (!strHexData.StartsWith(@"-"))
                {
                    return strHexData.PadLeft(nDataLen, '0');
                }
                strHexData = string.Format(@"-{0}", strHexData.Substring(1).PadLeft(nDataLen - 1, '0'));
            }
            return strHexData;
        }
        private static string KillZero(string strData)
        {
            Regex oReg = new Regex(@"^(0+)");
            return oReg.Replace(strData, "");
        }
        /// <summary>
        /// 將字串轉化為 Hex ByteAray 表示方式
        /// Ex. "80808080" --> 0x80 0x80 0x80 0x80
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static byte[] String2HexByteArray(string strData, int nByteLen)
        {
            byte[] bytData = new byte[nByteLen];

            Regex oReg = new Regex(@"^[0-9a-fA-F]+$");
            if (oReg.IsMatch(strData))
            {
                #region 補長度
                strData = strData.PadLeft(nByteLen * 2, '0');
                if (strData.Length > nByteLen * 2)
                {
                    strData = strData.Substring(strData.Length - nByteLen * 2, nByteLen * 2);
                }
                #endregion

                for (int nPos = 0; nPos < strData.Length / 2; nPos++)
                {
                    bytData[nPos] = Convert.ToByte(strData.Substring(nPos * 2, 2), 16);
                }
            }
            return bytData;
        }
        /// <summary>
        /// 將 ByteArray 轉化為 Hex String
        /// Ex 0x12 0x34 0x56 --> "123456"
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        public static string ByteArray2HexString(byte[] aryData)
        {
            return ByteArray2HexString(aryData, aryData.Length);
        }
        /// <summary>
        /// 將 ByteArray 轉化為 Hex String
        /// Ex 0x12 0x34 0x56 --> "123456"
        /// </summary>
        /// <param name="aryData"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static string ByteArray2HexString(byte[] aryData, int nLen)
        {
            //return System.BitConverter.ToString(aryData, 0, nLen).Replace("-", " ");
            StringBuilder strData = new StringBuilder();
            for (int nPos = 0; nPos < nLen; nPos++)
            {
                if (nPos >= aryData.Length)
                {
                    break;
                }
                //strData.Append(string.Format("{0:X2}", aryData[nPos]));
                strData.Append(string.Format("{0:X}", aryData[nPos]).PadLeft(2, '0').ToUpper());
            }
            return strData.ToString();
        }
    }
    public partial class ConvertionHelper
    {
        /// <summary>
        /// 將 EnumValue 的字串轉換為 Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strData"></param>
        /// <param name="oDefault"></param>
        /// <returns></returns>
        public static T EnumValue2Enum<T>(string strData, T oDefault)
        {
            try
            {
                Type type = typeof(T);
                int nIndex = (int)strData[0];
                if (Enum.IsDefined(type, nIndex))
                {
                    string strValue = Enum.GetName(type, nIndex);
                    return (T)Enum.Parse(type, strValue, true);
                }
            }
            catch (Exception) { }
            return oDefault;
        }
    }

    public partial class ConvertionHelper
    {
        public static DateTime StringDateToDate(string strDate)
        {
            if (strDate.Length == 8)
            {
                short year;
                if (short.TryParse(strDate.Substring(0, 4), out year))
                {
                    short month;
                    if (short.TryParse(strDate.Substring(4, 2), out month))
                    {
                        short day;
                        if (short.TryParse(strDate.Substring(6, 2), out day))
                        {
                            return new DateTime(year, month, day);
                        }
                    }
                }
            }
            throw new Exception("日期字串格是錯誤! " + strDate);
        }

        public static bool TryStringDateToDate(string strDate, out DateTime dt)
        {
            if (strDate.Length == 8)
            {
                short year;
                if (short.TryParse(strDate.Substring(0, 4), out year))
                {
                    short month;
                    if (short.TryParse(strDate.Substring(4, 2), out month))
                    {
                        short day;
                        if (short.TryParse(strDate.Substring(6, 2), out day))
                        {
                            dt = new DateTime(year, month, day);
                            return true;
                        }
                    }
                }
            }

            dt = default;
            return false;
        }
    }
}
