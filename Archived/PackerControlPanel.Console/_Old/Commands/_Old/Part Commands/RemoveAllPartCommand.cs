using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Repository;
    using System.Threading;

    public class RemoveAllPartCommand : PartCommand
    {
        public RemoveAllPartCommand(IPartRepository parts)
            : base(parts)
        {
        }

        public override string Name => "RemoveAll";
        public override string Description => "Removes all parts from the collection.";

        public override string Execute(object[] args)
        {
            bool skipQuestions = args.Count() > 0 ? Convert.ToBoolean(args[0]) : false;

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
    }
}
