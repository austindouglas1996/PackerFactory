using CommandHandlerLib;
using CommandHandlerLib.Commands;
using PackerControlPanel.InventoryConsole.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryConsole.Commands
{
    public class CreateHyperLink : ICommand
    {
        private ConsolePanel panel;

        public CreateHyperLink(ConsolePanel panel)
        {
            this.panel = panel;
        }

        public string Name => "CreateHyperLink";

        public string Library => "Default";

        public string HelpText => "[DEBUG COMMAND] Creates a simple hyperlink.";

        public CommandResult Execute(CommandArgs args)
        {
            string text = args.Arguments[0];
            panel.Controls.Add(new ConsoleHyperLink(text, "Consolas", 16, new Colours() { Foreground = Color.White }));

            return new CommandResult(this, "Hyperlink created.", CommandResultType.Success);
        }
    }
}
