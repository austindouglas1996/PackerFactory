using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Helpers
{
    public static class EnumHelper
    {
        public static DescriptionAttribute GetDescAttr(Type type, string propName)
        {
            var memInfo = type.GetMember(propName);
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Count() > 0) ? (DescriptionAttribute)attributes[0] : throw new ArgumentNullException("Failed to retrieve description attribute.");
        }
    }
}
