using CommandHandlerLib;
using CommandHandlerLib.Commands;
using PackerControlPanel.Data.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Commands
{
    public class ImportCommand : ICommand
    {
        public string Name => "import";

        public string Library => "Default";

        public string HelpText => "Helps with importing resources from older versions of PackerControlPanel.";

        public CommandResult Execute(CommandArgs args)
        {
            CommandInput cInput = args.Sender;
            List<string> cArgs = cInput.Arguments;

            string dirPath = cArgs.Count() > 0 ? cArgs[0].ToString() : throw new ArgumentException("Argument not provided. Directory path required.");

            if (!Directory.Exists(dirPath))
                throw new DirectoryNotFoundException(dirPath);

            V3ResourceImporter.Import(PackerConsoleWin.Instance.AlkonInventory, dirPath);

            return new CommandResult(this, "Import Successful.", CommandResultType.Success);    
        }
    }
}
