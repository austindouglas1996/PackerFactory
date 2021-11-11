using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib
{
    /// <summary>
    /// Represents the input used to determine which command to execute.
    /// </summary>
    public class CommandInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInput"/> class.
        /// </summary>
        /// <param name="input"></param>
        public CommandInput(string input)
        {
            // Special string to replace spaces with.
            string specialSpace = "|";

            // Replace any characters of the special character.
            if (input.Contains(specialSpace))
                input = input.Replace(specialSpace, "");

            // Holds the start and end index of each collectin of quotation marks.
            var quotationArray = new Dictionary<int, int>();

            if (input.Contains('"'))
            {
                // Load the start and end indexs into an array to be processed later.
                for (int i = input.IndexOf('"'); i < input.Length; i++)
                {
                    char c = input[i];
                    if (c != '"')
                        continue;

                    // Try to retrieve an existing holder without a valid value.
                    // (Invalid value would be -1)
                    var keyHolder = quotationArray.Where(q => q.Value == -1)
                        .ToDictionary(q => q.Key, q => q.Value);

                    // Set or create the key.
                    if (keyHolder.Count > 0)
                        // Set the key (The ending index).
                        quotationArray[keyHolder.Keys.ToList()[0]] = i;
                    else
                        // Create a new key holder (The starting index).
                        quotationArray.Add(i, -1);
                }

                // Replace the spaces in the string with a special string
                // this helps so before we split the string in pieces
                // to gather the method, and arguments we have combined any
                // arguments that have spaces within them.
                // Ex.
                // An argument that wants a full name "Robert Joe"
                // is safe from being confused as two arguments. (Robert as one and Joe as another)
                foreach (var quotation in quotationArray)
                {
                    if (quotation.Value == -1)
                        continue;

                    StringBuilder sb = new StringBuilder(input);
                    sb
                        // Remove everything behind the quote.
                        .Remove(quotation.Value, input.Length - quotation.Value)

                        // Remove everything infront of the quote.
                        .Remove(0, quotation.Key)

                        // Replace all spaces within the quote.
                        .Replace(" ", specialSpace);

                    // Remove the current string with the quote bounds.
                    input = input.Remove(quotation.Key, quotation.Value - quotation.Key);

                    // Insert the edited quote.
                    input = input.Insert(quotation.Key, sb.ToString());
                }

                // Remove the quotation marks within the string.
                input = input.Replace('"'.ToString(), "");
            }

            // Split the input into sections.
            var inputArray = input.Split(' ');

            // Replace the special spacing with a normal space again.
            for (int i = 0; i < inputArray.Length; i++)
                inputArray[i] = inputArray[i].Replace(specialSpace, " ");

            for (int i = 0; i < inputArray.Length; i++)
            {
                // The first one is always going to be the library and method name.
                if (i == 0)
                {
                    string[] s = inputArray[i].Split('.');
                    if (s.Length == 2)
                    {
                        this.Name = s[1];
                        this.LibraryName = s[0].ToLower();
                    }
                    else
                    {
                        this.Name = s[0];
                        this.LibraryName = "Default";
                    }
                }
                else
                {
                    // Add each argument into the array.
                    string argument = inputArray[i];
                    this.arguments.Add(argument);
                }
            }
        }

        /// <summary>
        /// Name of the command.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the library.
        /// </summary>
        public string LibraryName { get; set; }

        /// <summary>
        /// An array of arguments.
        /// </summary>
        public List<string> Arguments { get { return this.arguments; } }
        private List<string> arguments = new List<string>();
    }
}
