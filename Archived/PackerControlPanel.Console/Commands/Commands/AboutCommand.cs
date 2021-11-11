using CommandHandlerLib;
using CommandHandlerLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Commands
{
    public class AboutCommand : ICommand
    {
        string ICommand.Name => "About";

        string ICommand.Library => "Default";

        string ICommand.HelpText => "Returns helpful information about the program";

        public CommandResult Execute(CommandArgs args)
        {
            string aboutFile = Utility.GetAbout();
            return new CommandResult(this, aboutFile, CommandResultType.NotSpecified);
        }
    }
}
