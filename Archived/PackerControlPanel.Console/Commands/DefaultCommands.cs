using CommandHandlerLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Commands
{

    [CommandLibrary("Default")]
    public class DefaultCommands
    {

        [Command("AskName", "")]
        public static string AskName()
        {
            PackerConsoleWin.Instance.Console.WriteLine("What's your name?");

            string name = PackerConsoleWin.Instance.Console.ReadLine();

            return "Welcome, " + name + "!";
        }
    }
}
