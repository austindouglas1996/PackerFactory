using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;

    public class RemovePartCommand : PartCommand
    {
        public RemovePartCommand(IPartRepository parts)
            : base(parts)
        {
        }

        public override string Name => "RemovePart";
        public override string Description => "Removes an existing part from the part collection.";

        public override string Execute(object[] args)
        {
            string name = (string)args[0];
            bool skipQuestions = args.Count() > 1 ? Convert.ToBoolean(args[1]) : false;

            Part part = Parts.FirstOrDefault(p => p.Name == name.ToLower());
            if (part == null)
                return string.Format("<r>Unable to find a part by the name '{0}'.", name);

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
    }
}
