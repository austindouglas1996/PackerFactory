using CommandHandlerLib.Attributes;
using CommandHandlerLib.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerLib.Commands
{
    public class MethodCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCommand"/> class.
        /// </summary>
        /// <param name="method"></param>
        public MethodCommand(MethodInfo method)
        {
            this.Method = method;
        }

        /// <summary>
        /// Gets a value indicating whether this command is set to be ignored.
        /// </summary>
        public bool IsHidden
        {
            get { return Method.GetCustomAttribute(typeof(IgnoreCommandAttribute)) == null ? true : false;}
        }

        /// <summary>
        /// Method to be executed.
        /// </summary>
        public MethodInfo Method
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the name of the command by <see cref="CommandAttribute"/> or returns the name of the method.
        /// </summary>
        public string Name
        {
            get
            {
                var commandAttr = (CommandAttribute)this.Method.GetCustomAttribute(typeof(CommandAttribute));
                if (commandAttr != null)
                    return commandAttr.CommandName;

                return Method.Name;
            }
        }

        /// <summary>
        /// Gets name of the library by <see cref="CommandLibraryAttribute"/> or returns the name of the declaring type.
        /// </summary>
        public string Library
        {
            get
            {
                var commandLibAttr = (CommandLibraryAttribute)this.Method.DeclaringType.GetCustomAttribute(typeof(CommandLibraryAttribute));
                if (commandLibAttr != null)
                    return commandLibAttr.Name;

                return Method.DeclaringType.Name;
            }
        }

        /// <summary>
        /// Gets the description provided by the method.
        /// </summary>
        public string HelpText
        {
            get
            {
                var commandAttr = (CommandAttribute)this.Method.GetCustomAttribute(typeof(CommandAttribute));
                if (commandAttr != null)
                    return commandAttr.HelpText;
                return string.Empty;
            }
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <returns></returns>
        /// <remarks>The only arguments presented should be the <see cref="CommandInput"/>.</remarks>
        public CommandResult Execute(CommandArgs args)
        {
            // Provided arguments.
            CommandInput cInput = args.Sender;
            CommandResult result = new CommandResult(this);

            // Full path to the class.
            string classPath = string.Format("{0}.{1}", Method.DeclaringType.Namespace, Method.DeclaringType.Name);

            // Retrieve the class.
            var classType = Method.DeclaringType.Assembly.GetType(classPath, true, true);

            // Convert arguments.
            List<object> args1 = ConvertArgsToParameterType(Method.GetParameters().ToList(), cInput.Arguments);

            // Execute the method.
            BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.OptionalParamBinding | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase;
            var finalResult = classType.InvokeMember(Method.Name, flags, null, null, args1.ToArray());

            // https://stackoverflow.com/questions/28701867/checking-if-type-or-instance-implements-ienumerable-regardless-of-type-t
            if (typeof(IEnumerator).IsAssignableFrom(finalResult.GetType()))
            {
                IEnumerable enumerable = finalResult as IEnumerable;

                if (enumerable == null)
                {
                    IEnumerator enumerator = finalResult as IEnumerator;
                    if (enumerator != null)
                        throw new InvalidCastException("Invalid cast. IEnumerator is not supported. Use IEnumerable instead.");
                }

                StringBuilder sb = new StringBuilder();
                foreach (var item in enumerable)
                    sb.AppendLine(item.ToString());

                result.Message += sb.ToString();
            }
            else
            {
                result.Message = finalResult.ToString();
            }


            return result;         
        }

        /// <summary>
        /// Try and convert an array of string values into the required parameter type.
        /// </summary>
        /// <param name="pInfo"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        internal static List<object> ConvertArgsToParameterType(List<ParameterInfo> pInfo, List<string> values)
        {
            var methodParamList = pInfo.ToList<object>();

            try
            {
                for (int i = 0; i < pInfo.Count; i++)
                {
                    // Get the parameter.
                    var methodParam = pInfo[i];

                    // The required type.
                    Type typeRequired = methodParam.ParameterType;

                    // No more arguments presented. Set the default value to stop an exception from being thrown.
                    if (i > values.Count() - 1)
                        methodParamList[i] = Type.Missing;
                    else
                    {
                        object value = null;

                        // Generic array.
                        if (typeRequired.IsArray)
                        {
                            Type elementType = typeRequired.GetElementType();
                            Type genericListType = typeof(List<>).MakeGenericType(typeRequired.GetElementType());

                            var genericList = (IList)Activator.CreateInstance(genericListType);
                            var elements = values.ElementAt(i).Split(',').ToArray();

                            foreach (var element in elements)
                                genericList.Add(Convert.ChangeType(element, elementType));

                            value = Extensions.ConvertToArrayRuntime(genericList, elementType);
                        }

                        // Enum.
                        else if (typeRequired.IsEnum)
                        {
                            Type enumType = typeRequired;
                            Type enumUnderlyingType = Enum.GetUnderlyingType(enumType);
                            Array enumValues = Enum.GetValues(enumType);

                            bool matchFound = false;
                            for (int e = 0; e < enumValues.Length; e++)
                            {
                                object enumValue = enumValues.GetValue(e);
                                object underLyingType = Convert.ChangeType(enumValue, enumUnderlyingType);

                                if (enumValue.ToString().ToLower() == values.ElementAt(i).ToLower() ||
                                    values.ElementAt(i) == underLyingType.ToString())
                                {
                                    value = Enum.ToObject(typeRequired, underLyingType);
                                    matchFound = true; break;
                                }
                            }

                            if (!matchFound)
                                throw new ArgumentOutOfRangeException(string.Format("{0} has no value that matches '{1}'", pInfo[i].Name, values[i]));

                            if (value == null)
                                throw new ArgumentException("Invalid value. Value is not one of the defined constants within the Enum.");
                        }

                        // Default.
                        else
                        {
                            value = Convert.ChangeType(values.ElementAt(i), typeRequired);
                        }

                        methodParamList[i] = value;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return methodParamList;
        }
    }
}
