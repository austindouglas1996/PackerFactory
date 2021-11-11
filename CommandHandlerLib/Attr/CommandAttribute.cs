using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class CommandAttribute : Attribute
    {
        public CommandAttribute()
        {
            this.CommandName = string.Empty;
        }

        public CommandAttribute(string name, string helpText = "")
        {
            this.CommandName = name;
            this.HelpText = helpText;
        }

        public string CommandName { get; set; }
        public string HelpText { get; set; }
    }
}
