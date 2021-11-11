using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;

    public class RemoveJobCommand : JobCommand
    {
        public RemoveJobCommand(IJobRepository jobs)
            : base(jobs)
        {
        }

        public override string Name => "Remove";
        public override string Description => "Removes an existing job from the collection.";

        public override string Execute(object[] args)
        {
            string name = (string)args[0];
            bool skipQuestions = args.Count() > 1 ? Convert.ToBoolean(args[1]) : false;

            Job job = Jobs.FirstOrDefault(j => j.Name == name);
            if (job == null)
                return string.Format(CommandHelper.ERROR_ORDER_NOT_FOUND, name);

            // Make sure the user wants to remove the part.
            if (!skipQuestions)
            {
                if (!CommandHelper.AskQuestion(string.Format("Are you sure you want to remove the job '{0}'?", name)))
                {
                    return "<y>Command cancelled.";
                }
            }

            Jobs.Remove(job);

            return string.Format("<g>Successfully removed the job '{0}'.", name);
        }
    }
}
