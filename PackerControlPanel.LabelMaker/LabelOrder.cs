using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityRepository;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Image.Repository;

namespace PackerControlPanel.Image
{
    public class LabelOrder : LabelOrder<LabelOrderListRepository>, ILabelOrder
    {
    }

    public class LabelOrder<TRepository> : ILabelOrder<TRepository> where TRepository : ILabelOrderRepository
    {
        public LabelOrder()
        {
            this.Entries = (TRepository)Activator.CreateInstance(typeof(TRepository));
        }

        public string PackerName { get; set; }
        public string PartName { get; set; }
        public string PartDescription { get; set; }
        public string WorkOrder { get; set; }
        public string LotOrder { get; set; }

        public int TotalBoxes
        {
            get { return Entries.GetAll().Where(p => p.Type == LabelOrderEntryType.Box).Count(); }
        }

        public int TotalBags
        {
            get { return Entries.GetAll().Where(p => p.Type == LabelOrderEntryType.Bag).Count(); }
        }

        public int TotalPalettes
        {
            get { return Entries.GetAll().Where(p => p.Type == LabelOrderEntryType.Palette).Count(); }
        }

        public int[] UniqueCounts
        {
            get
            {
                List<int> unique = new List<int>();
                Entries.GetAll().ToList().ForEach(p => unique.Add(p.AmountPerLabel));
                return unique.Distinct().ToArray();
            }
        }
        public DateTime[] UniqueMfrDates
        {
            get
            {
                List<DateTime> dates = new List<DateTime>();
                Entries.GetAll().ToList().ForEach(p => dates.AddRange(p.MfrDates));
                return dates.Distinct().ToArray();
            }
        }

        public TRepository Entries { get; set; }

        public ILabel[] CreateLabels()
        {
            List<ILabel> labels = new List<ILabel>();
            this.Entries.GetAll().ToList().ForEach(p => labels.Add(new LabelBuilder()
                .SetPacker(this.PackerName)
                .SetPart(this.PartName, this.PartDescription)
                .SetJob(this.WorkOrder)
                .SetLot(this.LotOrder)
                .SetCount(p.AmountPerLabel)
                .SetShift(p.Shift)
                .SetDates(p.MfrDates, DateTime.Today)
                .SetType(p.Type)
                .Build()));

            return labels.ToArray();
        }
    }

    public interface ILabelOrderBuilder<TLabelOrder> where TLabelOrder : ILabelOrder
    {
        LabelOrderBuilder<TLabelOrder> SetPacker(string packerName);
        LabelOrderBuilder<TLabelOrder> SetPart(Part part);
        LabelOrderBuilder<TLabelOrder> SetJob(Job job);
        LabelOrderBuilder<TLabelOrder> SetLot(string lotNum);

        TLabelOrder Build();
    }

    public class LabelOrderBuilder<TLabelOrder> : ILabelOrderBuilder<TLabelOrder>
        where TLabelOrder : ILabelOrder
    {
        private Part _part;
        private string _partDescription;
        private Job _job;
        private string _lotNum;
        private string _packerName;

        public LabelOrderBuilder()
        {
        }

        public TLabelOrder Build()
        {
            var _Order = (TLabelOrder)Activator.CreateInstance(typeof(TLabelOrder));

            _Order.PartName = _part.Name;
            _Order.PartDescription = _part.Description;
            _Order.WorkOrder = _job.Name;
            _Order.LotOrder = _lotNum;
            _Order.PackerName = _packerName;

            return _Order;
        }

        public LabelOrderBuilder<TLabelOrder> SetJob(Job job)
        {
            _job = job;
            return this;
        }

        public LabelOrderBuilder<TLabelOrder> SetLot(string lotNum)
        {
            _lotNum = lotNum;
            return this;
        }

        public LabelOrderBuilder<TLabelOrder> SetPacker(string packerName)
        {
            _packerName = packerName;
            return this;
        }

        public LabelOrderBuilder<TLabelOrder> SetPart(Part part)
        {
            if (part == null)
                throw new ArgumentNullException("Part is null.");

            _part = part;
            _partDescription = part.Description;
            return this;
        }
    }
}
