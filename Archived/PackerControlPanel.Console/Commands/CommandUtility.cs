using CommandHandlerLib;
using PackerControlPanel.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public static class CommandUtility
    {
        internal static CommandHandler CmdHandler { get; set; }
        internal static PackerUnitOfWork AlkonInventory { get; set; }

        internal static bool AskQuestion(string question)
        {
            while (true)
            {
                Utility.Write(question + "(Y/N)");

                // Get result.
                string result = PackerConsoleWin.Instance.Console.ReadKey().ToString().ToUpper();

                if (result != "Y" && result != "N")
                {
                    Utility.Write("Invalid responce. Please use 'Y' for yes OR 'N' for no.");
                    continue;
                }

                if (result == "Y")
                    return true;
                else
                    return false;
            }
        }
    }
}
