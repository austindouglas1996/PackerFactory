using CommandHandlerLib;
using PackerControlPanel.Helper;
using PackerControlPanel.PanelConsole.Commands;
using PackerControlPanel.PanelConsole.Properties;
using PackerControlPanel.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole
{
    public class Program
    {
        public const string Version = "V0.3";

        /// <summary>
        /// Manages the entire inventory of parts, jobs and entries.
        /// </summary>
        internal static UnitOfWork AlkonInventory;

        /// <summary>
        /// Handles all executed commands.
        /// </summary>
        internal static CommandHandler cHandler;

        /// <summary>
        /// Handles the settings for the program.
        /// </summary>
        internal static AppSettings settings;
        
        /// <summary>
        /// Main entry point into the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var welcomeMSg = Resources.WelcomeMsg.Replace("{VERSION}", Version);
            Console.WriteLine(welcomeMSg);

            /*
            var aboutMsg = Resources.About.Replace("{VERSION}", Version);
            Console.WriteLine(aboutMsg);
            */

            AlkonContext alkonContext = new AlkonContext();
            AlkonInventory = new UnitOfWork(alkonContext);
            WriteToConsole("<g>Database connection established.");

            cHandler = new CommandHandler();
            CommandHelper.AlkonInventory = AlkonInventory;

            cHandler.AddCommand(new AboutCommand());

            Type parts = typeof(PartCommands);
            Type jobs = typeof(JobCommands);

            cHandler.AddLibrary(parts.Assembly, parts.Namespace, parts.Name);
            cHandler.AddLibrary(jobs.Assembly, jobs.Namespace, jobs.Name);

            if (!File.Exists("AppSettings.XML"))
            {
                settings = new AppSettings();
                WriteToConsole("<r>Unable to find an existing settings file. Creating a new settings file.");
            }
            else
            {
                try
                {
                    settings = AppSettings.LoadFromFile("AppSettings.XML");
                }
                catch (Exception e)
                {
                    DebugHelper.WriteExceptionToLog(e);
                    WriteToConsole("<y>Due to an unknown error a new setting file has been created successfully.");
                    settings = new AppSettings();
                }
            }

            Run();
        }

        /// <summary>
        /// Write a string to the console.
        /// </summary>
        /// <param name="input"></param>
        public static void WriteToConsole(string input)
        {
            ConsoleColor color = GetConsoleColor(ref input);
            WriteToConsole(input, color);
        }

        /// <summary>
        /// Write a string to the console with an already preselected foreground color.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="foreground"></param>
        public static void WriteToConsole(string input, ConsoleColor foreground = ConsoleColor.White)
        {
            if (string.IsNullOrEmpty(input))
                return;

            Console.ForegroundColor = foreground;
            Console.WriteLine("Console> " + input);
            Console.ResetColor();
        }

        /// <summary>
        /// Read from the console and get input from the user.
        /// </summary>
        /// <returns></returns>
        public static string ReadFromConsole()
        {
            Console.ForegroundColor = settings.Colors[2];
            Console.Write("Input> ");
            Console.ResetColor();

            return Console.ReadLine();
        }

        /// <summary>
        /// Run the default console, into a loop accepting commands.
        /// </summary>
        private static void Run()
        {
            while (true)
            {
                string text = ReadFromConsole();
                if (text == "exit")
                {
                    break;
                }

                try
                {
                    WriteToConsole(cHandler.ProcessInput(text));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Extract the color code from a string if there is one and then return the desired color.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static ConsoleColor GetConsoleColor(ref string input)
        {
            // Make sure the result should not have a special color.
            ConsoleColor color = ConsoleColor.White;

            if (input.StartsWith("<"))
            {
                // Color coded string start with <{COLOR}>
                int colorCodeEndPos = input.IndexOf('>', 1, input.Length - 1);

                // Retrieve the value.
                string colorCode = input.Substring(1, colorCodeEndPos - 1);

                // Remove colorCode from string.
                input = input.Remove(0, colorCodeEndPos + 1);

                if (colorCode == "g")
                    color = ConsoleColor.Green;
                else if (colorCode == "y")
                    color = ConsoleColor.Yellow;
                else if (colorCode == "r")
                    color = ConsoleColor.Red;
                else if (colorCode == "b")
                    color = ConsoleColor.Blue;
                // Make sure the color exists.
                else if (Enum.TryParse<ConsoleColor>(colorCode, true, out color))
                {
                    // Use the selected color.
                    return color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorCode, true);
                }
            }

            return color;
        }
    }
}
