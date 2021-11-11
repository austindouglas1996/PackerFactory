using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryConsole.Helpers
{
    public class ConsoleTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleTable"/> class.
        /// </summary>
        /// <param name="columns"></param>
        public ConsoleTable(params string[] columns)
        {
            this.Columns = new List<string>(columns);
            this.Rows = new List<string[]>();
        }

        public List<string> Columns { get; protected set; }
        public List<string[]> Rows { get; protected set; }

        /// <summary>
        /// Adds a new column.
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public ConsoleTable AddColumn(params string[] names)
        {
            this.Columns.AddRange(names);
            return this;
        }

        /// <summary>
        /// Adds a new row.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public ConsoleTable AddRow(params string[] values)
        {
            if (values == null)
                throw new ArgumentNullException(values.GetType().ToString());

            if (!Columns.Any())
                throw new Exception("No existing columns.");

            if (Columns.Count != values.Count())
            {
                throw new Exception("The number of {Columns.Count} does not match the number of values {values.Length}");
            }

            this.Rows.Add(values);
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Max column length.
            var columnLengths = ColumnLengths();

            // Row format.
            var format = Enumerable.Range(0, Columns.Count)
                .Select(i => " | {" + i + ",-" + columnLengths[i] + "}")
                .Aggregate((s, a) => s + a) + " |";

            // Longest formatted line.
            var maxRowLength = Math.Max(0, Rows.Any() ? Rows.Max(row => string.Format(format, row).Length) : 0);
            var columnHeaders = string.Format(format, Columns.ToArray());

            // Longest line.
            var longestLine = Math.Max(maxRowLength, columnHeaders.Length);

            // Add rows.
            var results = Rows.Select(row => string.Format(format, row)).ToArray();

            // Row divider
            var divider = " " + string.Join("", Enumerable.Repeat("-", longestLine - 1)) + " ";

            sb.AppendLine(divider);
            sb.AppendLine(columnHeaders);

            foreach (var row in results)
            {
                sb.AppendLine(divider);
                sb.AppendLine(row);
            }

            sb.AppendLine(divider);
    
            return sb.ToString();
        }

        /// <summary>
        /// Gets the longest line of each column.
        /// </summary>
        /// <returns></returns>
        private List<int> ColumnLengths()
        {
            List<int> columnLengths = new List<int>();

            // Loop through the columns setting the length to the longest row or if the column is longer use the column length.
            for (int i = 0; i < Columns.Count(); i++)
            {
                columnLengths.Add(Math.Max(Columns[i].Length,
                    Rows
                    .Select(r => r.ElementAt(i))
                    .Union(new string[] { Columns.ElementAt(i) }.ToList())
                    .Select(x => x == null ? 0 : x.ToString().Length).Max()));
            }

            /*
             * Date: 04.14.2018
             * OLD WAY, IN CASE WE FUCK SOMETHING UP ;-;
            var columnLengths = Columns
                .Select((t, i) => Rows.Select(x => x[i])
                .Union(Columns)
                .Select(x => x.ToString().Length).Max())
                .ToList();
            */

            return columnLengths;
        }
    }
}
