using CommandHandlerLib.Attributes;
using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data;
using PackerControlPanel.Data.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Commands
{
    [CommandLibrary("Receiver")]
    public class ReceiverCommands
    {
        private const string DocumentNotLoaded = "Invalid state. No receiver is currently loaded.";

        private static Receiver _currentDocument;


        internal static Receiver CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                _currentDocument = value;
            }
        }

        private static IReceiverRepository Receivers
        {
            get
            {
                IReceiverRepository receivers = CommandUtility.AlkonInventory.Receivers;
                if (receivers == null)
                    throw new ArgumentException("receivers collection is null.");

                return receivers;
            }
        }
        private static IReceiverEntriesRepository Entries
        {
            get
            {
                IReceiverEntriesRepository entries = CommandUtility.AlkonInventory.ReceiverEntries;
                if (entries == null)
                    throw new ArgumentException("ReceiverEntries is null.");

                return entries;
            }
        }

        [Command("CreateNew", "Creates a new receiver in the database.")]
        public static string CreateNew(string name)
        {
            if (CurrentDocument != null)
                return "Invalid state. a document is already loaded please use the command 'Close' before creating another receiver.";

            try
            {
                if (Receivers.GetReceiverWithEntries(Receivers.GetReceiverID(name)) != null)
                    return "Invalid value. a receiver already exists by this name.";
            }
            catch (NullReferenceException e)
            {
                // Do Nothing.
            }

            Receiver newReceiver = new Receiver();
            newReceiver.Name = name;

            Receivers.Add(newReceiver);

            CurrentDocument = newReceiver;

            return string.Format("Created the receiver '{0}'.", name);
        }

        [Command("Load", "Loads an existing receiver and allows for editing.")]
        public static string Load(string value, string[] args = null)
        {
            if (args == null)
                args = new string[0];

            if (CurrentDocument != null)
                return "Invalid state. a document is already loaded please use the command 'Close' before creating another receiver.";

            Receiver receiver = null;

            try
            {
                if (args != null && args.Contains("id"))
                {
                    receiver = Receivers.Get(Convert.ToInt32(value));
                }
                else
                {
                    receiver = Receivers.GetReceiverWithEntries(Receivers.GetReceiverID(value));
                }
            }
            catch (NullReferenceException e)
            {
                return string.Format("Invalid value. Failed to find a receiver by the {0} '{1}'.", args.Contains("id") ? "ID" : "name", value);
            }
            catch (Exception e)
            {
                return "Fatal error occured. See errorLog.txt for details.";

            }

            CurrentDocument = receiver;

            return string.Format("The receiver '{0}' has been successfully loaded.", receiver.Name);
        }

        [Command("SaveAs", "Saves the receiver in its current state as some type of external source.")]
        public static string SaveAs(int receiverType, string savePath = "")
        {
            string defaultPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (CurrentDocument == null)
                return DocumentNotLoaded;

            // Set the default path if one is not present.
            if (savePath == "")
                savePath = defaultPath;

            IReceiverExporter exporter;

            switch (receiverType)
            {
                // XML.
                case 0:
                    exporter = new XmlReceiverExporter(savePath);
                    break;

                // HTML.
                case 1:
                    exporter = new HtmlReceiverExporter(savePath);
                    break;

                default:
                    throw new IndexOutOfRangeException("Invalid value. Use 0 for XML OR 1 for HTML.");
            }

            // Export.
            return exporter.Export(CurrentDocument);
        }

        [Command("Close", "Closes the receiver. A command required to be called before creating, or loading another receiver.")]
        public static string Close()
        {
            if (CurrentDocument == null)
                return "No receiver currently loaded. unable to close.";

            Receiver receiver = CurrentDocument;
            CurrentDocument = null;

            return string.Format("The receiver '{0}' has been closed.", receiver.Name);
        }

        [Command("CloseAndDelete", "Closes the receiver then also deletes all contents")]
        public static string CloseAndDelete()
        {
            Receiver receiver = CurrentDocument;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Close());
            sb.AppendLine(Delete(receiver.ID.ToString(), "id"));

            return sb.ToString();
        }

        [Command("Delete", "Deletes a receiver.")]
        public static string Delete(string value, params string[] args)
        {
            bool byID = args.Contains("id");
            Receiver oldReceiver = null;

            if (byID)
            {
                oldReceiver = Receivers.Get(Convert.ToInt32(value));
            }
            else
            {
                oldReceiver = Receivers.GetReceiverWithEntries(Receivers.GetReceiverID(value));
            }

            if (oldReceiver == null)
                return string.Format("Invalid value. Failed to find a receiver by the {0} of '{1}'.", byID ? "ID" : "name", value);

            Receivers.Remove(oldReceiver);

            return string.Format("Deleted the receiver '{0}' with the ID of '{1}'.", oldReceiver.Name, oldReceiver.ID);
        }

        
        [Command("AddEntry", "Adds a new entry into the receiver.")]
        public static string AddEntry(string partName, string jobName, int boxes, int boxCount, string manuDates = "")
        {
            return AddEntry(partName, jobName, new int[] { boxes }, new int[] { boxCount }, manuDates).ToList()[0];
        }

        [Command("AddEntry", "Adds a new entry into the receiver.")]
        public static IEnumerable<string> AddEntry(string partName, string jobName, int[] boxes, int[] boxCount, string manuDates = "")
        {
            var part = CommandUtility.AlkonInventory.Parts.GetPartWithJobs(partName);
            var job = CommandUtility.AlkonInventory.Jobs.GetJobByName(jobName);

            if (part == null)
            {
                // Ask to create the part?
                if (CommandUtility.AskQuestion(string.Format("<r>Unable to find the part '{0}'. Do you wish to create it now?", partName)))
                {
                    bool IsDefaultCount = false;
                    if (CommandUtility.AskQuestion(string.Format("<y>Is '{0}' the default box count?", boxCount[0])))
                        IsDefaultCount = true;

                    Utility.Write(PartCommands.AddPart(partName, IsDefaultCount == true ? boxCount[0] : -1));
                    part = CommandUtility.AlkonInventory.Parts.GetPartWithJobs(partName);
                }
                else
                    throw new ArgumentNullException(string.Format("<r>Failed to find the part '{0}'.", partName));
            }

            if (job == null)
            {
                // Ask to create the job?
                if (CommandUtility.AskQuestion(string.Format("<r>Unable to find the job '{0}.", jobName)))
                {
                    Utility.Write(JobCommands.AddJob(jobName, partName).ToList()[0]);
                    job = CommandUtility.AlkonInventory.Jobs.GetJobByName(jobName);
                }
                else
                    throw new ArgumentNullException(string.Format("<r>Failed to find the job '{0}'.", jobName));
            }

            return AddEntry(part.ID, job.ID, boxes, boxCount, manuDates);
        }

        [Command("AddEntry", "Adds a new entry into the receiver.")]
        public static string AddEntry(int partId, int jobId, int boxes, int boxCount, string manuDates = "")
        {
            return AddEntry(partId, jobId, new int[] { boxes }, new int[] { boxCount }, manuDates).ToList()[0];
        }

        [Command("AddEntry", "Adds a new entry into the receiver.")]
        public static IEnumerable<string> AddEntry(int partID, int jobId, int[] boxes, int[] boxCount, string manuDates = "")
        {
            if (CurrentDocument == null)
                throw new ArgumentException(DocumentNotLoaded);

            Part part = CommandUtility.AlkonInventory.Parts.Get(partID);
            Job job = CommandUtility.AlkonInventory.Jobs.Get(jobId);

            if (boxes.Count() != boxCount.Count())
                throw new IndexOutOfRangeException("<r>Both arrays must have the same amount of variables.");

            // Tell the user if part or job can't be found.
            if (part == null || job == null)
            {
                throw new ArgumentNullException(string.Format("<r>Invalid value. Failed to find {0} by ID of '{1}'.",
                    part == null ? "part" : "job",
                    part == null ? partID : jobId));
            }

            for (int i = 0; i < boxes.Count(); i ++)
            {
                // Create the entry.
                ReceiverEntry newEntry = new ReceiverEntry.Builder()
                    .SetPart(partID)
                    .SetJob(jobId)
                    .SetReceiver(CurrentDocument.ID)
                    .SetInfo(boxes[i], boxCount[i])
                    .SetManufactureDates(manuDates.Split(',').ToDateTimeArray())
                    .Build();

                Entries.Add(newEntry);

                yield return new ReceiverEntry[] { newEntry }.ToTable().ToString() + string.Format("<g>Added the new entry.");
            }
        }

        public static string GetReceivers()
        {
            return Receivers.GetAll().ToArray().ToTable().ToString();
        }

        public static string GetReceivers(DateTime d1, DateTime d2)
        {
            return Receivers.GetAll().Where(r => r.CreationTime.CompareTo(d1) > 0 && r.CreationTime.CompareTo(d2) < 2).ToArray().ToTable().ToString();
        }

        [Command("GetEntry", "Returns information about a entry.")]
        public static string GetEntry(int id)
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            ReceiverEntry entry = CurrentDocument.Entries.FirstOrDefault(e => e.ID == id);
            return new ReceiverEntry[] { entry }.ToTable().ToString();
        }

        [Command("GetEntries", "Returns information about all entries associated with the current receiver.")]
        public static string GetEntries()
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            return CurrentDocument.Entries.ToArray().ToTable().ToString();
        }

        [Command("GetEntries", "Returns information about all entries associated with the current receiver.")]
        public static string GetEntries(int receiverID)
        {
            var rDocument = Receivers.Get(receiverID);

            if (rDocument == null)
                throw new ArgumentNullException("<r>Invalid receiverID. Failed to find a receiver by the ID of " + receiverID);

            return rDocument.Entries.ToArray().ToTable().ToString();
        }

        [Command("GetEntries", "Returns information about all entries associated with the current receiver.")]
        public static string GetEntries(string receiverName)
        {
            return GetEntries(Receivers.GetReceiverID(receiverName));
        }

        [Command("GetEntriesByPart", "Returns informations about all entries that are associated with a certain part.")]
        public static string GetEntriesByPart(string partName)
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            Part part = CommandUtility.AlkonInventory.Parts.GetPartWithJobs(partName);
            if (part == null)
                return string.Format("<r>Invalid value. Failed to find a part by the name '{0}'.", partName);

            return CurrentDocument.Entries.Where(e => e.Part == part).ToArray().ToTable().ToString();
        }

        [Command("GetEntriesByJob", "Returns informations about all entries that are associated with a certain job.")]
        public static string GetEntriesByJob(string jobName)
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            Job job = CommandUtility.AlkonInventory.Jobs.GetJobByName(jobName);
            if (job == null)
                return string.Format("<r>Invalid value. Failed to find a job by the name '{0}'.", jobName);

            return CurrentDocument.Entries.Where(e => e.Job == job).ToArray().ToTable().ToString();
        }

        [Command("RemoveEntry", "Removes an entry from the receiver.")]
        public static string RemoveEntry(int id)
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            ReceiverEntry entry = Entries.Get(id);
            if (entry.ReceiverID != CurrentDocument.ID)
                return string.Format("<r>Invalid state. the entryID provided is not owned by the current receiver and is instead owned by '{0}'.", entry.ReceiverID);

            Entries.Remove(entry);

            return string.Format("<g>Removed the entry '{0}' from the receiver '{1}'.", entry.ID, CurrentDocument.Name);
        }

        [Command("RemoveEntries", "Removes all entries from the receiver.")]
        public static string RemoveEntries()
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            ReceiverEntry[] entries = CurrentDocument.Entries.ToArray();
            return RemoveEntries(entries);
        }

        [Command("RemoveEntriesByPart", "Removes all entries associated with a part.")]
        public static string RemoveEntriesByPart(string partName)
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            Part part = CommandUtility.AlkonInventory.Parts.GetPartWithJobs(partName);
            if (part == null)
                return string.Format("<r>Invalid value. Failed to find a part by the name '{0}'.", partName);

            ReceiverEntry[] entries = CurrentDocument.Entries.Where(p => p.Part == part).ToArray();
            return RemoveEntries(entries);
        }

        [Command("RemoveEntriesByJob", "Removes all entries associated with a job.")]
        public static string RemoveEntriesByJob(string jobName)
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            Job job = CommandUtility.AlkonInventory.Jobs.GetJobByName(jobName);
            if (job == null)
                return string.Format("<r>Invalid value. Failed to find a job by the name '{0}'.", jobName);

            ReceiverEntry[] entries = CurrentDocument.Entries.Where(j => j.Job == job).ToArray();
            return RemoveEntries(entries);
        }

        [Command("SetEntryLocation", "Sets the location of the desired entry.")]
        public static string SetEntryLocation(int[] entriesID, string location)
        {
            if (CurrentDocument == null)
                throw new InvalidOperationException("<r>No receiver currently loaded.");

            StringBuilder sb = new StringBuilder();

            List<ReceiverEntry> entries = new List<ReceiverEntry>();
            foreach (var entryID in entriesID)
            {
                try
                {
                    ReceiverEntry entry = CurrentDocument.Entries.FirstOrDefault(i => i.ID == entryID);
                    entry.Location = location;

                    CommandUtility.AlkonInventory.ReceiverEntries.Edit(entry);

                    sb.AppendLine(string.Format("<g>The entry #{0}({1}) has been set to '{2}'.", entry.ID, entry.Job.Name, entry.Location));
                }
                catch (NullReferenceException e)
                {
                    sb.AppendLine(string.Format("<r>Invalid value. Failed to find a entry by the ID of '{0}'. Location was not set.", entryID));
                }
            }


            return sb.ToString();
        }

        [IgnoreCommand]
        private static string RemoveEntries(ReceiverEntry[] entries)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The following entries have been removed:");
            sb.AppendLine(entries.ToTable().ToString());

            // Remove.
            foreach (var entry in entries)
            {
                Entries.Remove(entry);
            }
            
            return sb.ToString();
        }
    }
}
