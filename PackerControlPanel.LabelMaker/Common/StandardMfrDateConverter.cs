using PackerControlPanel.Image.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public class StandardMfrDateConverter : IMfrDateConverter
    {
        public Tuple<DateTime[], int> DecipherLine(string line)
        {
            Tuple<DateTime[], int> result;
            string[] values = line.Split(' ');

            if (values.Length >= 2)
            {
                string[] dates = values[0].Split(',').ToArray();
                result = new Tuple<DateTime[], int>(Helper.StringToDateTime(dates), Convert.ToInt32(values[1]));
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments provided.");
            }

            return result;
        }

        public Dictionary<DateTime[], int>[] DecipherString(string value)
        {
            List<Dictionary<DateTime[], int>> values = new List<Dictionary<DateTime[], int>>();
            string line = string.Empty;

            using (StringReader reader = new StringReader(value))
            {
                Dictionary<DateTime[], int> cDim = new Dictionary<DateTime[], int>();

                do
                {
                    line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        values.Add(cDim);
                        cDim = new Dictionary<DateTime[], int>();
                    }
                    else
                    {
                        var processed = DecipherLine(line);
                        cDim.Add(processed.Item1, processed.Item2);
                    }
                }
                while (line != null);
            }

            return values.ToArray();
        }
    }
}
