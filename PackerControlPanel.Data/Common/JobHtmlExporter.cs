using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Common
{
    public class JobHtmlExporter
    {
        private readonly string NoteFormat = "<tr name='note'><td colspan='5'><b>Note:</b> {0}</td></tr>";

        private string _savePath = "";

        public JobHtmlExporter(string savePath)
        {
            if (!Directory.Exists(savePath))
                throw new DirectoryNotFoundException(savePath);

            _savePath = savePath;
        }

        public string Export(Job job)
        {
            string docTemplate = Resources.JobDetailedTemplate;
            docTemplate = docTemplate.Replace("{JOB_NAME}", job.Name);

            string jobTemplate = Resources.JobEntryTemplate;

            jobTemplate = jobTemplate.Replace("{JOB_NAME}", job.Name)
                .Replace("{PART_NAME}", job.Part.Name)
                .Replace("{COLLECTED}", job.TotalReceived.ToString() + "pc")
                .Replace("{FIRST_SEEN}", job.CreationDate.ToShortDateString())
                .Replace("{LAST_SEEN}", job.Entries.Last().CreationDate.ToShortDateString())
                .Replace("{STATUS}", job.GetCurrentState().State.ToString());

            StringBuilder entries = new StringBuilder();
            foreach (var entry in job.Entries)
            {
                entries.AppendLine(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>",
                    entry.ID.ToString(),
                    string.IsNullOrEmpty(entry.Receiver.Name) ? "No receiver name." : entry.Receiver.Name, 
                    (entry.Boxes.ToString() + " @ " + entry.BoxCount.ToString() + "pc"), 
                    entry.Total.ToString() + "pc", 
                    string.IsNullOrEmpty(entry.Location) ? "No location listed." : entry.Location));

                foreach (Note note in entry.Notes)
                {
                    entries.AppendLine(string.Format(NoteFormat, note.Message));
                }
            }

            jobTemplate = jobTemplate.Replace("{JOB_ENTRIES}", entries.ToString());
            docTemplate = docTemplate.Replace("{ITEM_CONTENTS}", jobTemplate.ToString());

            string fileNameSafe = job.Name == null ? "" : job.Name;
            foreach (var l in Path.GetInvalidFileNameChars())
                fileNameSafe = fileNameSafe.Replace(l, '.');

            string path = _savePath + "\\" + (fileNameSafe == null ? "noname" : fileNameSafe) + ".html";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(docTemplate);
            }

            return path;
        }
    }
}
