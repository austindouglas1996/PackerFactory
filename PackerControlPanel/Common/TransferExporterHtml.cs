using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data.Properties;
using System.IO;

namespace PackerControlPanel.Data.Common
{
    public class TransferExporterHtml : ITransferExporter
    {
        private readonly string NoteFormat = "<tr name='note'><td colspan='8'><b>Note:</b> {0}</td></tr>";

        private string _savePath = "";

        /// <summary>
        /// Creates a new instance of the <see cref="TransferExporterHtml"/> class.
        /// </summary>
        /// <param name="savePath"></param>
        public TransferExporterHtml(string savePath)
        {
            if (!Directory.Exists(savePath))
                throw new DirectoryNotFoundException(savePath);

            _savePath = savePath;
        }

        /// <summary>
        /// Convert and export a transfer document into a .HTML file.
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        public string Export(Transfer transfer)
        {
            return Export(transfer.Entries.ToList(), transfer);
        }

        public string Export(List<TransferEntry> entries, Transfer transDoc, bool UseMinimalTable = false)
        {
            // Our template we'll use to replace data with.
            string TransferTemplate = Resources.TransferDetailedTemplate;

            // Created grouped entries.
            List<TransferGroup> grouped = PrepareEntries(entries.OrderBy(t => t.StoredLocation).ToList());

            // Our StringBuilder that will hold our document.
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(CreateHeader(transDoc));

            if (UseMinimalTable)
                sb.AppendLine(CreateMinimalTable(grouped));
            else
                sb.AppendLine(CreateSimpleTable(grouped));

            sb.AppendLine(CreateHeader(transDoc));
            sb.AppendLine(CreateDetailedTable(transDoc, grouped));

            TransferTemplate = TransferTemplate
                .Replace("{TRANSFER_NAME}", transDoc.Name)
                .Replace("{TRANSFER_CONTENTS}", sb.ToString());

            string fileNameSafe = transDoc.Name == null ? "" : transDoc.Name;
            foreach (var l in Path.GetInvalidFileNameChars())
                fileNameSafe = fileNameSafe.Replace(l, '.');

            string path = _savePath + "\\" + (fileNameSafe == null ? "noname" : fileNameSafe) + ".html";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(TransferTemplate);
            }

            return path;
        }

        /// <summary>
        /// Creates heather information for the transfer document.
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        private string CreateHeader(Transfer transfer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("<h2>Transfer ID: {0}", transfer.ID));
            sb.AppendLine(string.Format("<h2>Date: {0}</h2>", transfer.CreationTime.ToShortDateString()));

            return sb.ToString();
        }

        /// <summary>
        /// Create a minimal table that includes only the important information.
        /// </summary>
        /// <param name="grouped"></param>
        /// <returns></returns>
        private string CreateSimpleTable(List<TransferGroup> grouped)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id='minimalContainer'>");

            // Table headers.
            sb.AppendLine(string.Format(
                @"<table>
                <tr><th>Part Name</th>
                <th>Work Order</th>
                <th>Received Location</th>
                <th>Stored Location</th>
                <th>Total Transferred</th></tr>"));

            foreach (var group in grouped)
            {
                // Table entries.
                sb.AppendLine(string.Format(
                    @"<tr><td>{0}</td>" +
                    "<td>#{1}</td>" +
                    "<td>{2}</td>" +
                    "<td>{3}</td>" +
                    "<td>{4}pc</td>",
                    group.Info.Job.Part.Name,
                    group.Info.Job.Name,
                    group.Info.ReceivedLocation,
                    group.Info.StoredLocation,
                    group.Total));

                // Add notes.
                foreach (Note note in group.GetNotes)
                {
                    sb.AppendLine(string.Format(NoteFormat, note.Message));
                }
            }

            // Finish
            sb.AppendLine("</table></div>");

            return sb.ToString();
        }

        /// <summary>
        /// Create a minimal table that includes only the important information.
        /// </summary>
        /// <param name="grouped"></param>
        /// <returns></returns>
        private string CreateMinimalTable(List<TransferGroup> grouped)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div id='minimalContainer'>");

            // Table headers.
            sb.AppendLine(string.Format(
                @"<table>
                <tr><th>Part Name</th>
                <th>Work Order</th>
                <th>Total Boxes</th>
                <th>Total Count</th></tr>"));

            foreach (var group in grouped)
            {
                int boxes = 0;
                foreach (var entry in group.Entries)
                    boxes += entry.ReceiverEntry.Boxes;

                // Table entries.
                sb.AppendLine(string.Format(
                    @"<tr><td>{0}</td>" +
                    "<td>#{1}</td>" +
                    "<td>{2}</td>" +
                    "<td>{3}pc</td>",
                    group.Info.Job.Part.Name,
                    group.Info.Job.Name,
                    boxes,group.Total));

                // Add notes.
                foreach (Note note in group.GetNotes)
                {
                    sb.AppendLine(string.Format(NoteFormat, note.Message));
                }
            }

            // Finish
            sb.AppendLine("</table></div>");

            return sb.ToString();
        }

        /// <summary>
        /// Create a detailed table that includes all information available.
        /// </summary>
        /// <param name="grouped"></param>
        /// <returns></returns>
        private string CreateDetailedTable(Transfer transfer, List<TransferGroup> grouped)
        {
            string EntryTemplate = Resources.TransferEntryTemplate;

            StringBuilder sb = new StringBuilder();

            foreach (TransferGroup group in grouped)
            {
                StringBuilder entryList = new StringBuilder();
                StringBuilder notes = new StringBuilder();

                foreach (var entryItem in group.Entries)
                {
                    entryList.AppendLine(string.Format(
                        "<tr><td>{0}</td><td>{1} X {2}</td><td>{3}pc</td></tr>",
                        entryItem.ReceiverEntry.Receiver.Name == null ? "No name" : group.Info.Entry.ReceiverEntry.Receiver.Name,
                        entryItem.ReceiverEntry.Boxes,
                        entryItem.ReceiverEntry.BoxCount,
                        entryItem.ReceiverEntry.Total));

                    foreach (var note in entryItem.Notes)
                    {
                        notes.AppendLine(string.Format(NoteFormat, note.Message));
                    }
                }

                string entry = EntryTemplate
                    .Replace("{PART_NAME}", group.Info.Job.Part.Name)
                    .Replace("{JOB_NAME}", "#" + group.Info.Job.Name)
                    .Replace("{RECEIVED_LOCATION}", group.Info.ReceivedLocation)
                    .Replace("{STORED_LOCATION}", group.Info.StoredLocation == "" ? "None" : group.Info.StoredLocation)
                    .Replace("{TOTAL_COUNT}", group.Total.ToString())
                    .Replace("{NOTES}", notes.ToString() == "" ? "" : notes.ToString())
                    .Replace("{TRANSFER_Name}", transfer.Name)
                    .Replace("{RECEIVER_ENTRIES}", entryList.ToString());

                sb.AppendLine(entry);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Prepares unfiltered transfer entries into sorted groups.
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        private List<TransferGroup> PrepareEntries(List<TransferEntry> entries)
        {
            List<TransferGroup> grouped = new List<TransferGroup>();

            for (int i = 0; i < entries.Count; i++)
            {
                TransferEntry entry = entries[i];
                TransferInfo ti = new TransferInfo(entry);

                // If we find a grouped entry that already exists we want to add it to the collection.
                bool foundKey = false;

                foreach (var key in grouped)
                {
                    if (foundKey)
                        break;

                    // Does this transfer entry have enough identical information to be added to a group?
                    if (ti.IsMatch(key.Info))
                    {
                        key.Entries.Add(entry);
                        foundKey = true;
                    }
                }

                // There is no existing group. Create a new group.
                if (!foundKey)
                {
                    grouped.Add(new TransferGroup(ti, entry));
                }
            }

            return grouped;
        }

        /// <summary>
        /// Contains a similiar group of transfer entries that can be combined together.
        /// </summary>
        private class TransferGroup
        {
            public TransferGroup(TransferInfo info)
                : this(info, null)
            {
            }

            public TransferGroup(TransferInfo info, params TransferEntry[] entries)
            {
                this.Info = info;
                this.Entries = new List<TransferEntry>(entries);
            }

            public int Total
            {
                get
                {
                    int total = 0;
                    foreach (var e in Entries)
                        total += e.ReceiverEntry.Total;

                    return total;
                }
            }

            public List<Note> GetNotes
            {
                get
                {
                    List<Note> notes = new List<Note>();
                    foreach (var entry in Entries)
                    {
                        notes.AddRange(entry.Notes.ToArray());
                    }
                    return notes;
                }
            }

            public TransferInfo Info { get; set; }
            public List<TransferEntry> Entries { get; set; }
        }

        /// <summary>
        /// Provides critical information based on a transfer entry.
        /// </summary>
        private class TransferInfo
        {
            public TransferInfo(TransferEntry entry)
            {
                this.Entry = entry;
                this.Part = entry.ReceiverEntry.Part;
                this.Job = entry.ReceiverEntry.Job;
                this.ReceivedLocation = entry.ReceiverEntry.Location;
                this.StoredLocation = entry.StoredLocation;
            }

            public TransferEntry Entry { get; private set; }
            public Part Part { get; private set; }
            public Job Job { get; private set; }
            public string ReceivedLocation { get; private set; }
            public string StoredLocation { get; private set; }

            public bool IsMatch(TransferInfo ti)
            {
                if (ti.Job == Job &&
                    ti.ReceivedLocation == ReceivedLocation &&
                    ti.StoredLocation == StoredLocation)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
