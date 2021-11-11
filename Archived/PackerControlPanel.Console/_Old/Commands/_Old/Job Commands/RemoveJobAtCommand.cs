using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;

    public class RemoveJobAtCommand : RemoveJobCommand
    {
        public RemoveJobAtCommand(IJobRepository jobs)
            : base(jobs)
        {
        }

        public override string Name => "RemoveJobAt";
        public override string Description => "Removes a job based on ID.";

        public override string Execute(object[] args)
        {
            int index = Convert.ToInt32(args[0]);
            bool skipQuestions = args.Count() > 1 ? Convert.ToBoolean(args[1]) : false;

            if (index < 0 || index > Jobs.GetAll().Count() - 1)
                return CommandHelper.ERROR_INDEX_OUT_OF_RANGE;

            Job job = Jobs.Get(index);
            return base.Execute(new object[] { job.Name, skipQuestions });
        }
    }
}
