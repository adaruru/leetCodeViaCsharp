using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace DataProcessCheck
{
    public static class FortifyFixHelper
    {
        /// <summary>
        /// 取代 StreamReader sr, sr.ReadLine();
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string CustomReadLine(this StreamReader reader)
        {
            const int maxLength = 31457280;
            var sb = new StringBuilder();
            var buffer = new char[8192];
            int totalRead = 0;

            while (!reader.EndOfStream && totalRead <= maxLength)
            {
                var charsRead = reader.Read(buffer, 0, buffer.Length);
                if (charsRead == 0)
                    break;
                if (totalRead + charsRead > maxLength)
                    throw new Exception("CustomReadToEnd Response 讀取異常，內容超過 30MB 限制");
                sb.Append(buffer, 0, charsRead);
                totalRead += charsRead;
                var i = Array.IndexOf(buffer, '\n', 0, charsRead);
                if (i >= 0) break;
            }
            string fullText = sb.ToString();
            int newlineIndex = fullText.IndexOf('\n');
            return newlineIndex < 0
                ? fullText
                : fullText.Substring(0, (newlineIndex > 0 && fullText[newlineIndex - 1] == '\r') ? newlineIndex - 1 : newlineIndex);
        }

        /// <summary>
        /// 取代 StreamReader sr, sr.ReadToEnd();
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string CustomReadToEnd(this StreamReader reader)
        {
            const int maxLength = 31457280;
            var sb = new StringBuilder();
            var buffer = new char[8192];
            int totalRead = 0;

            while (!reader.EndOfStream && totalRead <= maxLength)
            {
                var charsRead = reader.Read(buffer, 0, buffer.Length);
                if (charsRead == 0)
                    break;
                if (totalRead + charsRead > maxLength)
                    throw new Exception("CustomReadToEnd Response 讀取異常，內容超過 30MB 限制");
                sb.Append(buffer, 0, charsRead);
                totalRead += charsRead;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 取代 Random rd, rd.Next()
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int SecureRandom(int length = 9)
        {
            if (length < 1 || length > 9)
                throw new Exception("Length must be between 1 and 9.");//int長度限制

            var randomNumber = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            var result = string.Concat(randomNumber.Select(b => (b % 10).ToString()));
            return int.Parse(result);
        }


        /// <summary>
        /// 取代 Random rd, rd.Next(0, 20)
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int SecureRandom(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new Exception("minValue 必須小於或等於 maxValue");
            if (minValue == maxValue)
                return minValue;

            // 計算範圍
            long diff = (long)maxValue - minValue + 1;
            byte[] uint32Buffer = new byte[4];

            using (var rng = RandomNumberGenerator.Create())
            {
                while (true)
                {
                    rng.GetBytes(uint32Buffer);
                    uint rand = BitConverter.ToUInt32(uint32Buffer, 0);

                    // 避免偏差
                    long max = (1 + (long)UInt32.MaxValue);
                    long remainder = max % diff;
                    if (rand < max - remainder)
                    {
                        return (int)(minValue + (rand % diff));
                    }
                }
            }
        }
    }
}