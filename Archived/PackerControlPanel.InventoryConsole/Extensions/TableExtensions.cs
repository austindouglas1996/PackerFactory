using PackerControlPanel.Core.Domain;
using PackerControlPanel.InventoryConsole.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryConsole
{
    public static class TableExtensions
    {
        public static ConsoleTable ToTable(this Part[] partArray)
        {
            ConsoleTable tb = new ConsoleTable("ID", "Part Name", "Part Description", "Box Count", "Creation Date");

            foreach (var item in partArray)
            {
                var partIndex = item.ID;
                var partDescription = string.IsNullOrWhiteSpace(item.Description) ? "N/A" : item.Description;
                if (partDescription.Length > 20)
                    partDescription = partDescription.Remove(20, partDescription.Length - 21);

                bool hasParent = item.Parent != null;

                var dateFormat = "dd-MMM-yyyy";
                var result = new string[]
                {
                    partIndex.ToString(),
                    item.Name,
                    partDescription,
                    hasParent ? "(Inherited)" + item.DefaultBoxCount.ToString("0pc") : item.DefaultBoxCount.ToString("0pc"),
                    item.CreationDate.ToString(dateFormat)  == SqlDateTime.MinValue.ToString() ? "Unknown Date" : item.CreationDate.ToString(dateFormat)
                };

                tb.AddRow(result);
            }

            return tb;
        }
        public static ConsoleTable ToTable(this Job[] jobArray)
        {
            ConsoleTable ct = new ConsoleTable("ID", "Job Number", "Part ID/Name", "Complete quantity", "Creation Time", "End Time");

            foreach (var job in jobArray)
            {
                if (job == null)
                    throw new ArgumentNullException("job is null.");

                var result = new string[]
                {
                    job.ID.ToString(),
                    job.Name.ToString(),
                    job.Part == null ? "NullException" : string.Format("({0}) {1}", job.Part.ID.ToString(), job.Part.Name),
                    job.TotalReceived.ToString(),
                    job.CreationTime.ToString() == SqlDateTime.MinValue.ToString() ? "Unknown Date" : job.CreationTime.ToString(),
                    job.GetCurrentState.State == JobStateType.Complete ? job.CompletionTime.ToString() : job.GetCurrentState.State.ToString()
                };

                ct.AddRow(result);
            }

            return ct;
        }
        public static ConsoleTable ToTable(this Receiver[] receiverArray)
        {
            ConsoleTable ct = new ConsoleTable("ID", "Name", "Entries", "Creation Time");

            foreach (var receiver in receiverArray)
            {
                var result = new string[]
                {
                    receiver.ID.ToString(),
                    receiver.Name,
                    receiver.Entries.Count().ToString(),
                    receiver.CreationTime.ToShortDateString()
                };

                ct.AddRow(result);
            }

            return ct;
        }
        public static ConsoleTable ToTable(this ReceiverEntry[] entryArray)
        {
            ConsoleTable ct = new ConsoleTable("ID", "Receiver ID/Name", "Job ID/Name", "Part ID/Name", "Quantity", "Creation Time");

            // Total pieces.
            int total = 0;

            foreach (var entry in entryArray)
            {
                total += entry.Total;

                var result = new string[]
                {
                    entry.ID.ToString(),
                    string.Format("({0}) {1}", entry.ReceiverID.ToString(), entry.Receiver.Name),
                    string.Format("({0}) #{1}", entry.Job.ID.ToString(), entry.Job.Name),
                    string.Format("({0}) {1}", entry.Part.ID.ToString(), entry.Part.Name),
                    entry.Total.ToString(),
                    entry.CreationTime.ToString() == SqlDateTime.MinValue.ToString() ? "Unknown Date" : entry.CreationTime.ToString()
                };

                ct.AddRow(result);
            }

            return ct;
        }
        public static ConsoleTable ToTable(this Note[] noteArray)
        {
            ConsoleTable ntb = new ConsoleTable("Index", "Creation Date", "Message");
            noteArray.ToList().ForEach(n => ntb.AddRow(noteArray.ToList().IndexOf(n).ToString(), n.CreationTime.ToString("MMM-dd-yy"), n.Message));

            return ntb;
        }

    }
}
