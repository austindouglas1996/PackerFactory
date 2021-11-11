using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    using PackerControlPanel.Core.Domain;
    using PackerControlPanel.Core.Repository;

    public class GetAllPartCommand : PartCommand
    {
        public GetAllPartCommand(IPartRepository parts)
            : base(parts)
        {
        }

        public override string Name => "GetAll";
        public override string Description => "Displays basic information on all parts.";

        public override string Execute(object[] args)
        {
            ConsoleTable table = Parts.GetAll().ToArray().ToTable();

            if (table.Rows.Count() == 0)
                return "<r>Found 0 parts to display...";

            return "Part Information: \n" + table.ToString();
        }
    }
}
