using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public class ReceiverCommands
    {
        /// <summary>
        /// Gets or sets the loaded receiver.
        /// </summary>
        public static ReceiverBase LoadedReceiver { get; set; }

        /// <summary>
        /// Gets the array of receivers within the database.
        /// </summary>
        private static IReceiverRepository Receivers = CommandHelper.AlkonInventory.Receivers;
        private static IReceiverEntryRepository Entries = CommandHelper.AlkonInventory.ReceiverEntrys;

        public static string Create(string name)
        {
            if (LoadedReceiver != null)
            {
                if (CommandHelper.AskQuestion("A document is already loaded, Do you want to close it and create a new one?"))
                {
                    LoadedReceiver.Save();
                    LoadedReceiver = null;
                }
                else
                    return "<y>Command Cancelled.";
            }

            if (Receivers.GetByName(name) != null)
                throw new InvalidOperationException(string.Format(CommandHelper.ERROR_DOCUMENT_ALREADY_EXISTS, name));

            ReceiverBase receiver = new ReceiverBase();
            receiver.Name = name;
            receiver.CreationTime = DateTime.Now;

            LoadedReceiver = receiver;

            return string.Format("<g>Successfully created the receiver '{0}'.", name);
        }

        public static string Delete(string value)
        {
            ReceiverBase receiver = GetReceiver(value);

            if (CommandHelper.AskQuestion(string.Format(
                "Are you sure you want to delete the receiver '{0}' with '{1}' items?",
                receiver.Name, receiver.Entries.Count())))
            {
                Receivers.Remove(receiver);
                return string.Format("Removed receiver '{0}' with '{1}' items.", receiver.Name, receiver.Entries.Count());
            }
            else
                return "<y>Command cancelled.";           
        }

        public static string Load(string value)
        {
            if (LoadedReceiver != null)
            {
                if (CommandHelper.AskQuestion("A document is already loaded, Do you want to close it and load another?"))
                {
                    LoadedReceiver = null;
                }
                else
                    return "<y>Command Cancelled.";
            }

            ReceiverBase receiver = GetReceiver(value);

            LoadedReceiver = receiver;

            return string.Format("<g>Successfully loaded the receiver '{0}'.", receiver.Name);
        }

        public static string OpenAs(int type)
        {
            string helpMsg = "\n 0 - HTML Export";

            string saveLocation = Program.settings.ReceiverSavePath + LoadedReceiver.Name;

            switch (type)
            {
                case 0:
                    ReceiverHtmlExporter htmlExport =
                        new ReceiverHtmlExporter(saveLocation);

                    htmlExport.Export(LoadedReceiver);

                    return string.Format("Exported receiver in HTML format. Save Location {0}", saveLocation);
                default:
                    return helpMsg;               
            }
        }

        public static string AddItem(string partName, string jobName, int boxes, int boxCount, string[] manuDates = null)
        {
            int partId = CommandHelper.AlkonInventory.Parts.GetPartByName(partName).ID;
            int jobId = CommandHelper.AlkonInventory.Jobs.GetJobByName(jobName).ID;

            ReceiverEntry entry = new ReceiverEntry.Builder()
                .SetReceiver(LoadedReceiver.ID)
                .SetJob(jobId)
                .SetPart(partId)
                .SetInfo(boxes, boxCount)
                .SetManufactureDates(manuDates.ToDateTimeArray())
                .Build();

            // Convert to table.
            var entryTable = new ReceiverEntry[] { entry }.ToTable();

            // Date table.
            var dateTable = new ConsoleTable("Total", "Manufacture Dates");
            dateTable.AddRow(entry.Total.ToString(), string.Join(",", manuDates));

            // Write to console.
            Program.WriteToConsole(entryTable.ToString());
            Program.WriteToConsole(dateTable.ToString());

            if (CommandHelper.AskQuestion("Are you sure you want to add this to the receiver?"))
            {
                LoadedReceiver.Entries.Add(entry);
                return string.Format("<g>Added the entry successfully.");
            }
            else
                return "<r>Command cancelled.";
        }

        public static string GetEntry(int entryID)
        {

        }

        public static string GetOrder(string orderName)
        {

        }

        public static string RemoveEntry(int entryID)
        {

        }

        public static string RemoveOrder(string orderName)
        {

        }



        private static ReceiverBase GetReceiver(string value)
        {
            ReceiverBase receiver = null;

            if (value.StartsWith("id:"))
            {
                value.Replace("id:", "");

               receiver = Receivers.Get(Convert.ToInt32(value));

                if (receiver == null)
                    throw new IndexOutOfRangeException(string.Format("Unable to find a receiver with the ID of '{0}'.", value));
            }
            else
            {
                receiver = Receivers.FirstOrDefault(p => p.Name == value.ToString().ToLower());

                if (receiver == null)
                    throw new InvalidOperationException(string.Format("Unable to find a receiver by the name of '{0}'.", value.ToString().ToLower()));
            }

            return receiver;
        }

        private static ReceiverEntry GetEntry(int id)
        {
            ReceiverEntry entry = Entries.Get(id);

            if (entry == null)
                throw new IndexOutOfRangeException(string.Format("Unable to find a entry with the iD of {0}.", id));

            return entry;
        }
    }
}
