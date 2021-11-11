using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image.Factories
{
    public class LabelOrderEntryFactoryDefault : LabelOrderEntryFactory
    {
        public sealed override LabelOrderEntry Create(LabelOrderEntryType type, int amountOfLabels, int amountPerLabel, DateTime[] mfrDates, char? shift)
        {
            return new LabelOrderEntry(type, amountOfLabels, amountPerLabel, mfrDates, shift);
        }
    }
}
