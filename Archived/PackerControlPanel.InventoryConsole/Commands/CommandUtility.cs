using CommandHandlerLib;
using PackerControlPanel.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryConsole.Commands
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
                Form1.Console.WriteLine(question + "(Y/N)");

                // Get result.
                string result = Form1.Console.ReadKey().ToString().ToUpper();

                if (result != "Y" && result != "N")
                {
                    Form1.Console.WriteLine("Invalid responce. Please use 'Y' for yes OR 'N' for no.");
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
