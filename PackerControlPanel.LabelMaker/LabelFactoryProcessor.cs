
using PackerControlPanel.Image.Factories;
using PackerControlPanel.Image.Repository;
using PackerControlPanel.Image.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Image
{
    public abstract class LabelFactoryProcessor<TLabelOrder> where TLabelOrder : ILabelOrder
    {
        public LabelFactoryProcessor(ILabelFactoryBaseView<TLabelOrder> baseFactory, LabelOrderBuilder<TLabelOrder> orderBuilder)
        {
            this.BaseFactory = baseFactory;
            this.OrderBuilder = orderBuilder;
        }

        public ILabelFactoryBaseView<TLabelOrder> BaseFactory { get; private set; }
        public LabelOrderBuilder<TLabelOrder> OrderBuilder { get; protected set; }

        public TLabelOrder[] Execute()
        {
            string errorMsg = "";

            if (!TryCanExecute(out errorMsg))
                throw new ArgumentException(errorMsg);

            var MfrDates_Baked = CreateMfrDateOrder();
            var orders = CreateOrders(MfrDates_Baked);

            return orders;
        }

        protected abstract bool TryCanExecute(out string errorMsg);
        protected abstract Stack<Tuple<DateTime[], char>> CreateMfrDateOrder();
        protected abstract TLabelOrder[] CreateOrders(Stack<Tuple<DateTime[], char>> mfrDatesOrdered);
    }

    public class LabelFactoryProcessorDefault : LabelFactoryProcessor<LabelOrder>
    {
        public LabelFactoryProcessorDefault(ILabelFactoryBaseView<LabelOrder> baseFactory, LabelOrderBuilder<LabelOrder> orderBuilder)
            : base(baseFactory, orderBuilder)
        {
        }

        protected override bool TryCanExecute(out string errorMsg)
        {
            if (this.BaseFactory == null)
                throw new InvalidOperationException("Controller is null.");

            var part = BaseFactory.GetPart;
            var job = BaseFactory.GetJob;

            if (job != null && job.Part.Name != part.Name)
            {
                if (!job.IsGlobal)
                {
                    errorMsg = string.Format("Invalid part/job match. The job #{0} belongs to '{1}' not '{2}'.", job.Name, job.Part.Name, part.Name);
                    return false;
                }
            }

            if (BaseFactory.Boxes == null ||
                BaseFactory.BoxCount == null ||
                BaseFactory.MfrDatesProcessed == null ||
                BaseFactory.Shift == null)
            {
                errorMsg = "Invalid data. Boxes, Boxcount, MfrDates or Shift is null.";
                return false;
            }

            if (BaseFactory.Boxes.Length != BaseFactory.BoxCount.Length)
            {
                errorMsg = "The groups of boxes does not match that of the group of box counts.";
                return false;
            }

            if (BaseFactory.MfrDatesProcessed.Length != BaseFactory.Shift.Length
                && BaseFactory.MfrDatesProcessed.Length > 0
                && BaseFactory.Shift.Length > 0)
            {
                errorMsg = "The amount of shifts does not match the amount of groups of mfr. dates.";
                return false;
            }

            // Total box counts. Make sure we have the same counts for everything.
            int totalBoxes = 0;
            int totalBoxesMfr = 0;

            // Messy linq. Get total now.
            BaseFactory.Boxes.ToList().ForEach(b => totalBoxes += b);
            BaseFactory.MfrDatesProcessed.ToList().ForEach(m => m.Values.ToList().ForEach(v => totalBoxesMfr += v));

            // No match. Throw exception
            if (totalBoxes != totalBoxesMfr && totalBoxesMfr > 0)
            {
                errorMsg = "The total amount of boxes does not match that of the total amount of boxes included in the manufacture dates.";
                return false;
            }

            errorMsg = "No errors.";
            return true;
        }

        protected override Stack<Tuple<DateTime[], char>> CreateMfrDateOrder()
        {
            // Create a stack of mfrDates and the shift that belongs with those dates.
            Stack<Tuple<DateTime[], char>> tempStack = new Stack<Tuple<DateTime[], char>>();
            Stack<Tuple<DateTime[], char>> mfrDatesOrder = new Stack<Tuple<DateTime[], char>>();

            // If the user provided a group of manufacture dates along with a possibility of 
            // shifts we need to process them before creating the labels.
            if (BaseFactory.MfrDatesProcessed.Length > 0)
            {
                // Go through each dimension of the processed dates and add them into the stack.
                for (int i = 0; i < BaseFactory.MfrDatesProcessed.Length; i++)
                {
                    foreach (var mfrDate in BaseFactory.MfrDatesProcessed[i])
                    {
                        char shift = char.MinValue;

                        // Make sure the shift dimensions go this deep.
                        if (BaseFactory.Shift.Length > 0)
                            shift = BaseFactory.Shift[i];

                        // Loop over the amount of boxes with that date.
                        for (int b = 0; b < mfrDate.Value; b++)
                        {
                            // Push to the top of the stack.
                            mfrDatesOrder.Push(
                                new Tuple<DateTime[], char>(mfrDate.Key, shift));
                        }

                    }
                }

                // Reverse the stack. 
                // Note: it's much easier to do this for me than creating a extenion method even though the extension method
                // would be more lightweight I just want easy ):
                do
                {
                    tempStack.Push(mfrDatesOrder.Pop());
                }
                while (mfrDatesOrder.Count != 0);

                // Set stack.
                mfrDatesOrder = tempStack;
            }

            return mfrDatesOrder;
        }

        protected override LabelOrder[] CreateOrders(Stack<Tuple<DateTime[], char>> mfrDatesOrdered)
        {
            List<LabelOrder> orders = new List<LabelOrder>();

            for (int i = 0; i < BaseFactory.BoxCount.Count(); i++)
            {
                // Create a new order.
                LabelOrder newOrder = base.OrderBuilder.SetPart(BaseFactory.GetPart)
                    .SetJob(BaseFactory.GetJob)
                    .SetLot(BaseFactory.LotOrder)
                    .SetPacker(BaseFactory.PackerName)
                    .Build();

                // Get a instance of the entry factory.
                LabelOrderEntryFactory entryFac = newOrder.Entries.CreateFactory();

                // Loop through the boxes creating the entries. The mfr. dates are set already in order.
                int boxes = BaseFactory.Boxes[i];
                for (int b = 0; b < boxes; b++)
                {
                    var MfrDate = mfrDatesOrdered.Count > 0 ? mfrDatesOrdered.Pop() : new Tuple<DateTime[], char>(new DateTime[] { }, 'N');
                    var dates = MfrDate.Item1;
                    var shift = MfrDate.Item2;

                    newOrder.Entries.Add(entryFac.Create(LabelOrderEntryType.Box, 1, BaseFactory.BoxCount[i], dates, shift));
                }

                orders.Add(newOrder);
            }

            return orders.ToArray();
        }
    }

    public class LabelFactoryProcessorDefaultOffline : LabelFactoryProcessorDefault
    {
        public LabelFactoryProcessorDefaultOffline(ILabelFactoryBaseView<LabelOrder> baseFactory, LabelOrderBuilder<LabelOrder> orderBuilder)
            : base(baseFactory, orderBuilder)
        {
        }

        protected override bool TryCanExecute(out string errorMsg)
        {
            errorMsg = "";
            return true;
        }
    }
}
