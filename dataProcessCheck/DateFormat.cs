using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataProcessCheck
{
    public class DateFormat
    {
        public void ToChineseDate() {

			DateTime dNow = DateTime.Now;
			System.Globalization.TaiwanCalendar tc = new System.Globalization.TaiwanCalendar();		
			DateTime d = new DateTime(2010, 8, 18, 1, 0, 0);
			
			
			string dateString2 = string.Format("{0:000}.{1:00}.{2:00}-{3:00}", tc.GetYear(d), tc.GetMonth(d), tc.GetDayOfMonth(d),d.Hour + 1);
			string dateString1 = string.Format("民國{0:000}年{1:00}月{2:00}日", tc.GetYear(d), tc.GetMonth(d), tc.GetDayOfMonth(d));
			string dateString3 = string.Format("-{0:00}", d.Hour + 1);


			Console.WriteLine(dateString1);
			Console.WriteLine(dateString2);
			Console.WriteLine(dateString3);
		}
    }
}
