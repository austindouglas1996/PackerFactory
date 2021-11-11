using PackerControlPanel.InventoryConsole.Console;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryConsole.Extensions
{
    public static class ConsoleExtensions
    {
        public static void WriteLine(this IConsole console, string text, ConsoleFlags flag)
        {
            Color chosenColor = Color.White;
            switch (flag)
            {
                case ConsoleFlags.Error:
                    chosenColor = console.StyleOptions.Error;
                    break;
                case ConsoleFlags.Success:
                    chosenColor = console.StyleOptions.Success;
                    break;
                case ConsoleFlags.Warning:
                    chosenColor = console.StyleOptions.Warning;
                    break;
                case ConsoleFlags.None:
                    chosenColor = console.StyleOptions.FontForeColor;
                    break;
                default:
                    throw new ArgumentException("Invalid console flag selected.");
            }

            console.WriteLine(text, console.StyleOptions.OutputFont, chosenColor);
        }
    }
}
