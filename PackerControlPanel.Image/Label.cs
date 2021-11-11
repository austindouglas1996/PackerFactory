using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public class Label : ILabel
    {
        public Label()
        {
            this.CountPrefix = "Box Qty:";
            this.MfrDates = new DateTime[] { };
            this.CreationDate = DateTime.Now;
        }

        public string PackerName { get; set; }

        public string PartName { get; set; }

        public string PartDescription { get; set; }

        public string WorkOrder { get; set; }

        public string LotOrder { get; set; }

        public string CountPrefix { get; set; }

        public int Count { get; set; }

        public char Shift { get; set; }

        public DateTime[] MfrDates { get; set; }

        public DateTime CreationDate { get; set; }
    }

    public interface ILabelBuilder
    {
        LabelBuilder SetPacker(string packerName);
        LabelBuilder SetPart(Part part);
        LabelBuilder SetPart(string partName, string partDescription);
        LabelBuilder SetJob(Job job);
        LabelBuilder SetJob(string workOrder);
        LabelBuilder SetLot(string lotNum);
        LabelBuilder SetCount(int count);
        LabelBuilder SetShift(char shift);
        LabelBuilder SetType(LabelOrderEntryType type);
        LabelBuilder SetDates(DateTime[] mfrDates, DateTime creationDate);

        Label Build();
    }

    public class LabelBuilder : ILabelBuilder
    {
        private Label _Label;

        public LabelBuilder()
        {
            this._Label = new Label();
            this._Label.CountPrefix = "Box:";
            this._Label.CreationDate = DateTime.Now;
        }

        public Label Build()
        {
            return _Label;
        }

        public LabelBuilder SetCount(int count)
        {
            _Label.Count = count;
            return this;
        }

        public LabelBuilder SetDates(DateTime[] mfrDates, DateTime creationDate)
        {
            _Label.MfrDates = mfrDates;
            _Label.CreationDate = creationDate;
            return this;
        }

        public LabelBuilder SetJob(Job job)
        {
            _Label.WorkOrder = job.Name;
            return this;
        }

        public LabelBuilder SetJob(string workOrder)
        {
            _Label.WorkOrder = workOrder;
            return this;
        }

        public LabelBuilder SetLot(string lotNum)
        {
            _Label.LotOrder = lotNum;
            return this;
        }

        public LabelBuilder SetPacker(string packerName)
        {
            _Label.PackerName = packerName;
            return this;
        }

        public LabelBuilder SetPart(Part part)
        {
            _Label.PartName = part.Name;
            _Label.PartDescription = part.Description;
            return this;
        }

        public LabelBuilder SetPart(string partName, string partDescription)
        {
            _Label.PartName = partName;
            _Label.PartDescription = partDescription;
            return this;
        }

        public LabelBuilder SetShift(char shift)
        {
            _Label.Shift = shift;
            return this;
        }

        public LabelBuilder SetType(LabelOrderEntryType type)
        {
            _Label.CountPrefix = EnumHelper.GetDescAttr(type.GetType(), Enum.GetName(type.GetType(), type)).Description;
            return this;
        }
    }
}
