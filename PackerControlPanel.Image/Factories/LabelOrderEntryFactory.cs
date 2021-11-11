using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image.Factories
{
    public abstract class LabelOrderEntryFactory : ILabelOrderEntryFactory
    {
        public abstract LabelOrderEntry Create(LabelOrderEntryType type, int amountOfLabels, int amountPerLabel, DateTime[] mfrDates, char? shift);
    }
}
