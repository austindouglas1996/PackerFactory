using EntityRepository;
using PackerControlPanel.Image.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image.Repository
{
    public interface ILabelOrderRepository : IRepository<LabelOrderEntry>
    {
        LabelOrderEntryFactory CreateFactory();
    }
}
