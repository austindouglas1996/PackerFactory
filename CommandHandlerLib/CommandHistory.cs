using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib
{
    public class CommandHistory : List<string>
    {
        public new void Add(string commandInput)
        {
            base.Add(commandInput + "\n");
        }
    }
}
