using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a string into a <see cref="DateTime"/> array.
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        public static DateTime[] ToDateTimeArray(this string[] dates)
        {
            List<DateTime> dateArray = new List<DateTime>();

            foreach (string date in dates)
            {
                string[] intervals = date.Split('-');

                if (intervals.Count() < 2)
                    continue;

                int month = Convert.ToInt32(intervals[0]);
                int day = Convert.ToInt32(intervals[1]);
                int year = intervals.Count() >= 3 ? Convert.ToInt32(intervals[2]) : DateTime.Now.Year;

                dateArray.Add(new DateTime(year, month, day));
            }

            return dateArray.ToArray();
        }
    }
}
