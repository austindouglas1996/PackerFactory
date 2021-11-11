using CommandHandlerLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Helpers
{
    /// <summary>
    /// Provides help with dealing with method type commands.
    /// </summary>
    public static class MethodCommandHelper
    {
        /// <summary>
        /// Gets an array of <see cref="MethodInfo"/> class instances from a certain class located within an app.
        /// </summary>
        /// <param name="app">App to retrieve from.</param>
        /// <param name="nameSpace">Namespace to class.</param>
        /// <param name="className">Class namme.</param>
        /// <param name="methodName">[OPTIONAL] Method name.</param>
        /// <param name="flags">[OPTIONAL] Desired flags.</param>
        /// <returns></returns>
        public static MethodInfo[] GetMethodsFromAssembly(Assembly app, string nameSpace, string className, string methodName = "", BindingFlags flags = BindingFlags.Public | BindingFlags.Static)
        {
            if (string.IsNullOrWhiteSpace(nameSpace))
                throw new ArgumentNullException(nameSpace);

            else if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentNullException(className);

            /* 10-May-17: Assembly.GetTypes() DOES include nested types and no further action should be taken to get nested classes. */
            var classInfo = (from c in app.GetTypes()
                             where c.IsClass && c.Namespace == nameSpace && c.Name == className
                             select c).FirstOrDefault();

            // Maybe throw some type of exception to warn no methods were found?
            if (classInfo == null)
                return null;

            if (!string.IsNullOrWhiteSpace(methodName))
                return new MethodInfo[] { classInfo.GetMethod(methodName, flags) };
            else
            {
                return classInfo.GetMethods(flags);
            }
        }

        /// <summary>
        /// Searches a class for commands within a class and returns an array of <see cref="MethodCommand"/> class.
        /// </summary>
        /// <param name="mInfo"></param>
        /// <returns></returns>
        public static MethodCommand[] GetCommandsFromAssembly(Assembly app, string nameSpace, string className)
        {
            // Get public static methods.
            MethodInfo[] methods = GetMethodsFromAssembly(app, nameSpace, className, "", BindingFlags.Public | BindingFlags.Static);

            // None found.
            if (methods == null)
                return null;

            List<MethodCommand> commands = new List<MethodCommand>();
            foreach (var method in methods)
            {
                commands.Add(new MethodCommand(method));
            }

            return commands.ToArray();
        }
    }
}
