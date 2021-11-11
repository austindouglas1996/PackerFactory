using System;
using System.Collections.Generic;
using System.Linq;

namespace PackerControlPanel.Image.Helpers
{
    public static class Helper
    {
        public static DateTime[] StringToDateTime(string[] dates)
        {
            List<DateTime> list = new List<DateTime>();
            for (int i = 0; i < dates.Length; i++)
            {
                string text = dates[i];
                string[] array = text.Split(new char[]
                {
                    '-'
                });
                if (array.Count<string>() >= 2)
                {
                    int month = Convert.ToInt32(array[0]);
                    int day = Convert.ToInt32(array[1]);
                    int year = (array.Count<string>() >= 3) ? Convert.ToInt32(array[2]) : DateTime.Now.Year;
                    list.Add(new DateTime(year, month, day));
                }
            }
            return list.ToArray();
        }

        public static string DateTimeToString(DateTime[] dates)
        {
            string val = "";

            for (int i = 0; i < dates.Count(); i++)
            {
                val += (dates[i].ToShortDateString());

                
                if (i != dates.Count())
                    val += ",";
            }

            return val;
        }
    }
}