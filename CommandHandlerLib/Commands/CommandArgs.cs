using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib
{
    public struct CommandArgs
    {
        public CommandArgs(CommandInput sender)
            : this()
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            this.Sender = sender;
        }

        public List<string> Arguments
        {
            get { return this.Sender.Arguments; }
        }

        public CommandInput Sender
        {
            get;
            private set;
        }
    }
}
