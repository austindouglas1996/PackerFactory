using CommandHandlerLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Exceptions
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException()
        {
        }

        public CommandNotFoundException(string msg)
            : base(msg)
        {
        }

        public CommandNotFoundException(ICommand cmd)
            : base(string.Format("{0}.{1} cannot be found.", cmd.Library, cmd.Name))
        {
        }

        public CommandNotFoundException(ICommand cmd, Exception inner)
            : base(string.Format("{0}.{1} cannot be found.", cmd.Library, cmd.Name), inner)
        {
        }
    }
}
