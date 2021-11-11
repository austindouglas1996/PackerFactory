using EntityRepository;
using System;
using System.Linq;

namespace PackerControlPanel.Image
{
    public class LabelOrderEntry : IEntity
    {
        public LabelOrderEntry(LabelOrderEntryType type, int amountOfLabels, int amountPerLabel, DateTime[] mfrDates, char? shift)
        {
            this.Type = type;
            this.AmountOfLabels = amountOfLabels;
            this.AmountPerLabel = amountPerLabel;
            this.MfrDates = mfrDates;
            this.Shift = shift.HasValue ? shift.Value : char.MinValue;
        }

        public int ID { get; set; }
        public LabelOrderEntryType Type { get; set; }
        public char Shift { get; set; }
        public int AmountOfLabels { get; set; }
        public int AmountPerLabel { get; set; }
        public DateTime[] MfrDates { get; set; }
    }
}