using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public interface ILabel
    {
        string PackerName { get; }

        string PartName { get; }
        string PartDescription { get; }

        string WorkOrder { get; }
        string LotOrder { get; }

        string CountPrefix { get; }
        int Count { get; }

        char Shift { get; }

        DateTime[] MfrDates { get; }
        DateTime CreationDate { get; }
    }
}
