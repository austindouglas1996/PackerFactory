using CommandHandlerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public class AboutCommand : ICommand
    {
        public string Name => "About";

        public string Library => "Default";

        public string Description => "Returns helpful information about the program.";

        public string Execute(object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Author: Austin Douglas \n Project Name: Alkon Projects - Receiving - PackerConsoleControlPanel \n Date: 2016-2018 \n Version: " + Program.Version);
            return sb.ToString();

        }
    }
}
