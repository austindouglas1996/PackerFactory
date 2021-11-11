using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public class AddPartCommand : PartCommand
    {
        public AddPartCommand(IPartRepository parts)
            : base(parts)
        {
        }

        public override string Name => "AddPart";
        public override string Description => "Creates a new part into the part collection.";
        public override string Execute(object[] args)
        {
            string name = (string)args[0];
            int boxCount = Convert.ToInt32(args[1]);
            string description = args.Count() > 2 ? (string)args[2] : "";

            Part part = new Part();
            part.Name = name;
            part.DefaultBoxCount = boxCount;
            part.Description = description;

            if (Parts.Find(p => p.Name == name).Count() > 0)
                return "<r>A part already exists by this name. Failed to create part.";

            Parts.Add(part);

            return string.Format("<g>The part '{0}' with the default box count of '{1}pc' was successfully created.", name, boxCount);
        }
    }
}
