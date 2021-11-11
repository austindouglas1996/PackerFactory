using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image.Factories
{
    public interface ILabelOrderEntryFactory
    {
        LabelOrderEntry Create(LabelOrderEntryType type, int amountOfLabels, int amountPerLabel, DateTime[] mfrDates, char? shift);
    }
}
