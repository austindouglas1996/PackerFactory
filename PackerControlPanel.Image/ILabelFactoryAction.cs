using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
using PackerControlPanel.Image.Drawings;
using System;
using System.Drawing.Printing;

namespace PackerControlPanel.Image
{
    public interface ILabelFactoryAction
    {
        string ExecuteAction(ILabelOrder[] orders, params object[] args);
    }

    public class LabelFactoryActionPrint : ILabelFactoryAction
    {
        private ILabelDrawing _drawing;
        private PrintController _printerController;
        private ILabel _labelToDraw;

        public LabelFactoryActionPrint(ILabelDrawing drawing, PrintController printerController)
        {
            this._drawing = drawing;
            this._printerController = printerController;
        }

        public string ExecuteAction(ILabelOrder[] orders, params object[] args)
        {
            // Create a new printer document.
            PrintDocument pd = new PrintDocument();
            pd.PrintController = _printerController;

            // Set the page to be printed.
            pd.PrintPage += new PrintPageEventHandler(DrawLabel);

            try
            {
                // Print the labels that belong with this order.
                foreach (var order in orders)
                {
                    var labels = order.CreateLabels();
                    foreach (var label in labels)
                    {
                        _labelToDraw = label;
                        pd.Print();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return "Done";
        }

        private void DrawLabel(object sender, PrintPageEventArgs ev)
        {
            _drawing.Draw(ev.Graphics, ev.PageBounds, _labelToDraw);
        }
    }

    public class LabelFactoryActionReceive : ILabelFactoryAction
    {
        private Receiver _receiver;
        private IPackerUnitOfWork _domain;

        public LabelFactoryActionReceive(PackerUnitOfWork domain, Receiver receiver)
        {
            this._domain = domain;
            this._receiver = receiver;
        }

        public string ExecuteAction(ILabelOrder[] orders, params object[] args)
        {
            foreach (var order in orders)
            {
                int partId = _domain.Parts.GetID(order.PartName);
                int jobId = _domain.Jobs.Get(order.WorkOrder).ID;

                ReceiverEntry newEntry = new ReceiverEntry.Builder()
                    .SetPart(partId)
                    .SetJob(jobId)
                    .SetReceiver(_receiver.ID)
                    .SetInfo(order.TotalBoxes, order.UniqueCounts[0])
                    .SetManufactureDates(order.UniqueMfrDates)
                    .Build();

                _domain.ReceiverEntries.Add(newEntry);

                /*
                 * It was changed at some point so each order has their own count.
                 * You will not get a order with more than one unique count so there is 
                 * no need to loop through all entries for receiving.
                 */

                /*
                foreach (var orderEntry in order.Entries.GetAll())
                {
                    ReceiverEntry newEntry = new ReceiverEntry.Builder()
                        .SetPart(partId)
                        .SetJob(jobId)
                        .SetReceiver(_receiver.ID)
                        .SetInfo(orderEntry.AmountOfLabels, orderEntry.AmountPerLabel)
                        .SetManufactureDates(orderEntry.MfrDates)
                        .Build();

                    _domain.ReceiverEntries.Add(newEntry);
                }*/
            }

            return "Done";
        }
    }
}
