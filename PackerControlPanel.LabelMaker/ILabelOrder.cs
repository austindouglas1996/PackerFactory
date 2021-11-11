using EntityRepository;
using PackerControlPanel.Image.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public interface ILabelOrder : ILabelOrder<LabelOrderListRepository>
    {
    }

    public interface ILabelOrder<TRepository> where TRepository : ILabelOrderRepository
    {
        string PackerName { get; set; }

        string PartName { get; set; }
        string PartDescription { get; set; }

        string WorkOrder { get; set; }
        string LotOrder { get; set; }

        int TotalBoxes { get; }
        int TotalBags { get; }
        int TotalPalettes { get; }

        int[] UniqueCounts { get; }
        DateTime[] UniqueMfrDates { get; }

        TRepository Entries { get; set; }

        ILabel[] CreateLabels();
    }
}
