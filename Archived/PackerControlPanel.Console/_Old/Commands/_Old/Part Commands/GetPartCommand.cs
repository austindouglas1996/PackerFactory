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

    public class GetPartCommand : PartCommand
    {    
        public GetPartCommand(IPartRepository parts)
            : base(parts)
        {
        }

        public override string Name => "GetPart";
        public override string Description => "Returns information on a part based on name, or index.";

        public override string Execute(object[] args)
        {
            Part part = null;

            if (Regex.IsMatch((string)args[0], @"^\d+$"))
            {
                part = Parts.Get(Convert.ToInt32(args[0]));

                if (part == null)
                    return string.Format(CommandHelper.ERROR_INDEX_OUT_OF_RANGE);
            }
            else if (args[0].GetType() == typeof(string))
            {
                part = Parts.FirstOrDefault(p => p.Name == (string)args[0]);

                if (part == null)
                    return string.Format(CommandHelper.ERROR_PART_ID_NOT_FOUND, (string)args[0]);
            }

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
    }
}
