using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CommandHandlerLib.Attributes
{
    /// <summary>
    /// Indicates that a method, field or property should be hidden from being seen as a command.
    /// </summary>
    public class IgnoreCommandAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoreCommandAttribute"/> class.
        /// </summary>
        /// <param name="ignore"></param>
        public IgnoreCommandAttribute()
        {
        }
    }
}
