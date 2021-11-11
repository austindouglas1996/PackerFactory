using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.RPCP.Common
{
    public static class Helper
    {
        public static List<T> SplitStringToList<T>(string args)
        {
            List<T> result;
            if (string.IsNullOrEmpty(args))
            {
                result = new List<T>();
            }
            else
            {
                List<T> list = new List<T>();
                string[] array = args.Split(new char[] {','});
                for (int i = 0; i < array.Length; i++)
                {
                    string value = array[i];
                    list.Add((T)((object)Convert.ChangeType(value, typeof(T))));
                }
                result = list;
            }
            return result;
        }

        public static string SplitArrayToString<T>(T[] array)
        {
            string result;
            if (array == null)
            {
                result = "";
            }
            else
            {
                if (array.Length == 0)
                {
                    result = "";
                }
                else
                {
                    string text = "";
                    for (int i = 0; i < array.Length; i++)
                    {
                        T t = array[i];
                        text = text + t.ToString() + ",";
                    }
                    text = text.TrimEnd(new char[]
                    {
                        ','
                    });
                    result = text;
                }
            }

            return result;
        }
    }
}
