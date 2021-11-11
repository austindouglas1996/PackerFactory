using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string Library { get; }
        string HelpText { get; }

        CommandResult Execute(CommandArgs args);
    }
}
