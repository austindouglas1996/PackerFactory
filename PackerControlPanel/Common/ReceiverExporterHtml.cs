using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PackerControlPanel.Core;
using PackerControlPanel.Data.Properties;
using PackerControlPanel.Core.Domain;

namespace PackerControlPanel.Data.Common
{
    public class ReceiverExporterHtml : IReceiverExporter
    {
        private string _savePath = "";
        private string _templateData;

        public ReceiverExporterHtml(string savePath, bool alternateStyle = false)
        {
            
            if (!Directory.Exists(savePath))
                throw new DirectoryNotFoundException(savePath);

            this._savePath = savePath;

            if (alternateStyle)
                this._templateData = Resources.ReceiverDetailedTemplate1;
            else
                this._templateData = Resources.ReceiverDetailedTemplate;
        }

        public string Export(Receiver receiver)
        {
            // Entries within the receiver.
            var entries = receiver.Entries.ToList();

            // Sort by location.
            entries = entries.OrderBy(r => r.Location).ToList();

            // The data to be placed in the template.
            string templateData = _templateData;
            string templateBody = "";

            // Table headers.
            string[] tableHeaders = new string[] { "Total", "Part Name", "Order #", "Contents", "Stored Location" };

            string entryFormat = "<tr>" + Enumerable.Range(0, tableHeaders.Count())
                    .Select(i => "<td name='element_" + tableHeaders[i] + "'>" + "{" + i + "}" + "<br><t name='element_barcode'>" + "*{" + i + "}*</t></td>")
                    .Aggregate((s, a) => s + a) + "</tr>";

            string descriptionFormat = "<tr name='Date'><td>Mfr. Dates:</td>" + Enumerable.Range(0, tableHeaders.Count() - 1)
                    .Select(i => i == tableHeaders.Count() -2 ? "<td>{0}</td>" : "<td></td>")
                    .Aggregate((s, a) => s + a);

            string noteFormat = "<tr name='note'><td colspan='8'><b>Note:</b> {0}</td></tr>";

            foreach (var entry in entries)
            {
                // Element to add to the body.
                string element = "";

                // Entry information in string format.
                string eTotal = entry.Total.ToString();
                string eName = entry.Part.Name;
                string eJob = entry.Job.Name == "" ? "Unknown" : entry.Job.Name;
                string eDesc = entry.Boxes.ToString() + " X " + entry.BoxCount.ToString();
                string eLoc = entry.Location;

                // Create element.
                element += string.Format(entryFormat, eTotal, eName, eJob, eDesc, eLoc);

                // Get manufacture dates.
                var entryManuDates = new List<string>();
                foreach (var entryDate in entry.ManuDates)
                    entryManuDates.Add(entryDate.Date.ToString("MMM-dd-yyyy"));

                // Create description.
                element += string.Format(descriptionFormat, string.Join(", ", entryManuDates));

                foreach (var note in entry.Notes.ToList())
                {
                    element += string.Format(noteFormat, note.Message);
                }

                // Add to body.
                templateBody += element;
            }

            // Replace tags.
            templateData = templateData.Replace("{RECEIVER_NAME}", receiver.Name)
                .Replace("{RECEIVER_ITEMS_CONTENTS}", templateBody)
                .Replace("{RECEIVER_VERSION}", Core.PackerControlPanel.VersionNum)
                .Replace("{RECEIVER_DATE}", receiver.CreationTime.ToShortDateString());

            string fileNameSafe = receiver.Name == null ? "" : receiver.Name;
            foreach (var l in Path.GetInvalidFileNameChars())
                fileNameSafe = fileNameSafe.Replace(l, '.');
            

            string path = _savePath + "\\" + (fileNameSafe == null ? "noname" : fileNameSafe) + ".html";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(templateData);
            }

            return path;
        }
    }
}
