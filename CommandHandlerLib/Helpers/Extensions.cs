using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Helpers
{
    public static class Extensions
    {
        public static T[] ConvertToArray<T>(IList list)
        {
            return list.Cast<T>().ToArray();
        }

        public static IList ConvertToArrayRuntime(IList list, Type elementType)
        {
            var convertMethod = typeof(Extensions).GetMethod("ConvertToArray", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(IList) }, null);
            var genericMethod = convertMethod.MakeGenericMethod(elementType);
            return (IList)genericMethod.Invoke(null, new object[] { list });
        }
    }
}
