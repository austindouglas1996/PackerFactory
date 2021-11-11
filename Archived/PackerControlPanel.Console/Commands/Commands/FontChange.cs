using CommandHandlerLib;
using CommandHandlerLib.Commands;
using PackerControlPanel.Win32Console.Win.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.Win32Console.Commands
{
    public class FontChangeCommand : ICommand
    {
        private Settings settings;

        public FontChangeCommand(Settings settings)
        {
            this.settings = settings;
        }

        public string Name => "ChangeFont";

        public string Library => "Default";

        public string HelpText => "Change the default output font.";

        public CommandResult Execute(CommandArgs args)
        {
            if (args.Arguments.Count() < 1)
                throw new ArgumentOutOfRangeException("Invalid number of arguments provided.");

            string fontName = args.Arguments[0];

            settings.DefaultFont = new System.Drawing.Font(fontName, 12, System.Drawing.FontStyle.Regular);


            return new CommandResult(this, "Sucessfully changed the font.", CommandResultType.Success);
        }
    }
}
