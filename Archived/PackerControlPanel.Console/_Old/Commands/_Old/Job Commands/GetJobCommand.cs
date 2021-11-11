using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;
    using System.Text.RegularExpressions;

    public class GetJobCommand : JobCommand
    {
        public GetJobCommand(IJobRepository jobs)
            : base(jobs)
        {
        }

        public override string Name => "GetJob";
        public override string Description => "Gets information on a job.";

        public override string Execute(object[] args)
        {
            Job job = null;

            if (Regex.IsMatch((string)args[0], @"^\d+$"))
            {
                job = Jobs.Get(Convert.ToInt32(args[0]));

                if (job == null)
                    return string.Format(CommandHelper.ERROR_ORDER_ID_NOT_FOUND, args[0]);
            }
            else if (args[0].GetType() == typeof(string))
            {
                job = Jobs.FirstOrDefault(j => j.Name == (string)args[0]);

                if (job == null)
                    return string.Format(CommandHelper.ERROR_ORDER_NOT_FOUND, args[0]);
            }

            ConsoleTable jobTable = new Job[] { job }.ToTable();
            ConsoleTable jobEntryTable = job.Entrys.ToArray().ToTable();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Job Information:");
            sb.AppendLine(jobTable.ToString());

            sb.AppendLine("Job Entrys tied to this order:");
            sb.AppendLine(jobEntryTable.ToString());

            return sb.ToString();
        }
    }
}
