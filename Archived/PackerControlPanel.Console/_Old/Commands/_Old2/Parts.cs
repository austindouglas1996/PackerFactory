
using CommandHandlerLib;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public class PartCommands
    {
        private static IPartRepository Parts = CommandHelper.AlkonInventory.Parts;

        public static string Create(string partName, int boxCount, string description)
        {
            Part part = new Part();
            part.Name = partName;
            part.DefaultBoxCount = boxCount;
            part.Description = description;

            if (Parts.Find(p => p.Name == partName).Count() > 0)
                return "<r>A part already exists by this name. Failed to create part.";

            Parts.Add(part);

            return string.Format("<g>The part '{0}' with the default box count of '{1}pc' was successfully created.", partName, boxCount);
        }

        public static string GetAll()
        {
            ConsoleTable table = Parts.GetAll().ToArray().ToTable();

            if (table.Rows.Count() == 0)
                return "<r>Found 0 parts to display...";

            return "Part Information: \n" + table.ToString();
        }

        public static string Get(string value)
        {
            Part part = GetPart(value);

            ConsoleTable partTable = new Part[] { part }.ToTable();
            ConsoleTable noteTable = part.Notes.ToArray().ToTable();
            ConsoleTable jobTable = part.Jobs.Take(5).ToArray().ToTable();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Part Information:");
            sb.AppendLine(partTable.ToString());

            sb.AppendLine("Part Notes:");
            sb.AppendLine(noteTable.ToString());

            sb.AppendLine("Part jobs basic information (5 most recent):");
            sb.AppendLine(jobTable.ToString());

            return sb.ToString();
        }

        public static string RemoveAll(bool skipQuestions = false)
        {
            List<string> questions = new List<string>()
            {
                "Are you sure you want to remove all parts?",
                "Are you really, really, SURE you want to remove all parts???",
                "Removing all parts means deleting everything created? Are you sure?",
                "What you're about to do is delete lots of important stuff.. are you truely sure?",
                "Please seek a 2nd opinion and make sure you want to do this...",
                "Ask a 3rd opinion ARE YOU TRULY SURE?",
                "HAL 9000: I'm sorry, Dave but I'm afraid I cannot let you do that.",
                "FINE! Just say yes and everything created will be destroyed, RIP there are no backups, no going back."
            };

            if (!skipQuestions)
            {
                foreach (string question in questions)
                {
                    if (CommandHelper.AskQuestion("[WARNING] " + question))
                        continue;
                    else
                        return "[ERROR]  Command Cancelled. *NO CHANGES HAVE BEEN MADE*";
                }
            }

            Parts.RemoveAll();

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Program.WriteToConsole("<r> ALL DATA HAS BEEN DELETED. CLOSING PROGRAM");
            }

            Environment.Exit(0);

            return "";
        }

        public static string Remove(string value, bool skipQuestions = false)
        {
            Part part = GetPart(value);

            // Make sure the user wants to remove the part.
            if (!skipQuestions)
            {
                if (!CommandHelper.AskQuestion(string.Format("Are you sure you want to remove the part '{0}'?", name)))
                {
                    return "<y>Command cancelled.";
                }
            }

            Parts.Remove(part);

            return string.Format("<g>Successfully removed the part '{0}'. All jobs have also been deleted.", name);
        }

        private static Part GetPart(string value)
        {
            Part part = null;

            if (value.StartsWith("id:"))
            {
                value.Replace("id:", "");

                part = Parts.Get(Convert.ToInt32(value));

                if (part == null)
                    throw new IndexOutOfRangeException(string.Format(CommandHelper.ERROR_PART_ID_NOT_FOUND, value));
            }
            else
            {
                part = Parts.FirstOrDefault(p => p.Name == value.ToString().ToLower());

                if (part == null)
                    throw new InvalidOperationException(string.Format(CommandHelper.ERROR_PART_NOT_FOUND, value.ToString().ToLower()));
            }

            return part;
        }
    }
}
