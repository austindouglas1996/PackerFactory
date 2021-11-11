using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;

    public class RemovePartAtCommand : RemovePartCommand
    {
        public RemovePartAtCommand(IPartRepository parts)
            : base(parts)
        {
        }

        public override string Name => "RemovePartAt";
        public override string Description => "Removes a part from the existing collection by ID.";

        public override string Execute(object[] args)
        {
            int index = Convert.ToInt32(args[0]);
            bool skipQuestions = args.Count() > 1 ? Convert.ToBoolean(args[1]) : false;

            if (index < 0 || index > Parts.GetAll().Count() - 1)
                return CommandHelper.ERROR_INDEX_OUT_OF_RANGE;

            Part part = Parts.Get(index);
            return base.Execute(new object[] { part.Name, skipQuestions });
        }
    }
}
