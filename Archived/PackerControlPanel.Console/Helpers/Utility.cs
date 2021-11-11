
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console
{
    public enum ConsoleFlags
    {
        None,
        Success,
        Warning,
        Error
    }

    public class Utility
    {
        public const string Space = "     ";

        /// <summary>
        /// Write to the console.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="flag"></param>
        public static void Write(string text, ConsoleFlags flag = ConsoleFlags.None)
        {
            Color flagA = flag == ConsoleFlags.None ? GetConsoleColor(ref text) : GetColorFromFlag(flag);
            PackerConsoleWin.Instance.Console.WriteLine("* " + text, flagA);
            
        }

        public static void Write(string text, Color color)
        {
            Write(text, color, 0);
        }

        public static void Write(string text, Color color, int spacing)
        {
            text = text.PadLeft(spacing + text.Length);
          
            
            PackerConsoleWin.Instance.Console.WriteLine(text, color);
        }

        /// <summary>
        /// Center a string.
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        public static string Center(string _string)
        {
            int screenWidth = 400;
            int stringWidth = _string.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2);
            return _string.PadLeft(spaces);
        }

        internal static string GetAbout()
        {
            return "";//Resources.About.Replace("{VERSION}", "0.4");
        }

        /// <summary>
        /// Get the type of colour to use based on the type of flag.
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        private static Color GetColorFromFlag(ConsoleFlags flag)
        {
            switch(flag)
            {
                case ConsoleFlags.Success:
                    return Color.Green;
                case ConsoleFlags.Warning:
                    return Color.Yellow;
                case ConsoleFlags.Error:
                    return Color.Red;
                case ConsoleFlags.None:
                default:
                    return Color.White;
            }
        }

        /// <summary>
        /// Extract the color code from a string if there is one and then return the desired color.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>OLD TYPE</remarks>
        private static Color GetConsoleColor(ref string input)
        {
            // Make sure the result should not have a special color.
            Color color = Color.White;

            if (input.StartsWith("<"))
            {
                // Color coded string start with <{COLOR}>
                int colorCodeEndPos = input.IndexOf('>', 1, input.Length - 1);

                // Retrieve the value.
                string colorCode = input.Substring(1, colorCodeEndPos - 1);

                // Remove colorCode from string.
                input = input.Remove(0, colorCodeEndPos + 1);

                if (colorCode == "g")
                    color = Color.Green;
                else if (colorCode == "y")
                    color = Color.Yellow;
                else if (colorCode == "r")
                    color = Color.Red;
                else if (colorCode == "b")
                    color = Color.Blue;
                // Make sure the color exists.
                else if (Enum.TryParse<Color>(colorCode, true, out color))
                {
                    // Use the selected color.
                    return color = (Color)Enum.Parse(typeof(Color), colorCode, true);
                }
            }

            return color;
        }
    }
}
