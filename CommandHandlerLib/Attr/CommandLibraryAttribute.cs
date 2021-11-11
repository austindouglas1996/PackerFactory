using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Attributes
{
    /// <summary>
    /// Indiciates that a class should have a different name than what is specified.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandLibraryAttribute : Attribute
    {
        public CommandLibraryAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
