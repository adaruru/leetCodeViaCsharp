using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataProcessCheck
{
    public class DateFormat
    {
        //取德
        public void ToChineseDate()
        {

            DateTime dNow = DateTime.Now;
            System.Globalization.TaiwanCalendar tc = new System.Globalization.TaiwanCalendar();
            DateTime d = new DateTime(2010, 8, 18, 1, 0, 0);


            string dateString2 = string.Format("{0:000}.{1:00}.{2:00}-{3:00}", tc.GetYear(d), tc.GetMonth(d), tc.GetDayOfMonth(d), d.Hour + 1);
            string dateString1 = string.Format("民國{0:000}年{1:00}月{2:00}日", tc.GetYear(d), tc.GetMonth(d), tc.GetDayOfMonth(d));
            string dateString3 = string.Format("-{0:00}", d.Hour + 1);


            Console.WriteLine(dateString1);
            Console.WriteLine(dateString2);
            Console.WriteLine(dateString3);
        }

        /// <summary>
        /// 取得現在民國日期時間{yyy.MM.dd-HH}
        /// </summary>
        /// <returns></returns>
        private string GetTaiwanCalendarDateTime()
        {
            System.Globalization.TaiwanCalendar tc = new System.Globalization.TaiwanCalendar();
            DateTime d = DateTime.Now;
            int hour = d.Hour;
            if (d.Minute != 0 || d.Second != 0)//判斷非整點無條件進位
            {
                hour++;//直接+1 23點多顯示24
            }
            string result = string.Format("{0:000}.{1:00}.{2:00}-{3:00}", tc.GetYear(d), tc.GetMonth(d), tc.GetDayOfMonth(d), hour);
            return result;
        }

        /// <summary>
        /// 現在時間簡單轉型格式
        /// </summary>
        /// <returns></returns>
        public string SimpleFormat()
        {
            var TXNDATE = DateTime.Now.ToString("yyyyMMdd"); //西元:年月日
            var TXNTIME = DateTime.Now.ToString("HHmmss"); //時間:時分秒
            return "";
        }

        /// <summary>
        /// 來源轉datetime
        /// </summary>
        /// <returns></returns>
        public DateTime GetMyTime()
        {
            DateTime newDate = DateTime.ParseExact("20111120", "yyyyMMdd", CultureInfo.InvariantCulture);
            return newDate;
        }

        /// <summary>
        /// 民國年時間+兩個月-一天
        /// </summary>
        /// <param name="TXNDATE"></param>
        /// <returns></returns>
        public string AddTwoMonths()
        {
            DateTime Date = DateTime.ParseExact("20201208", "yyyyMMdd", CultureInfo.InvariantCulture);
            var newData = Date.AddMonths(2).AddDays(-1);
            var DUEDATE = newData.ToString("yyyyMMdd"); //西元:年月日
            return DUEDATE;
        }
    }
}
