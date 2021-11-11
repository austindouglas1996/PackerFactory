using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Domain.V3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PackerControlPanel.Data.Helpers
{
    public class V3ResourceImporter
    {
        private const string PartPath = "pc.xml";
        private const string JobPath = "jc.xml";
        private const string JobEntryPath = "jce.xml";

        public static string Import(PackerUnitOfWork inventory, string dir)
        {
            StringBuilder sb = new StringBuilder();

            if (!Directory.Exists(dir))
                throw new DirectoryNotFoundException(dir);

            string partPath = dir + "pc.xml";
            string jobPath = dir + "jc.xml";
            string jobEntryPath = dir + "jce.xml";

            // No resource files exist?
            if (!File.Exists(partPath) &&
                !File.Exists(jobPath) &&
                !File.Exists(jobEntryPath))
                throw new InvalidOperationException("No v0.3 resource files exist in this directory.");

            // Collections.
            List<PartV3> parts = new List<PartV3>();
            List<JobV3> jobs = new List<JobV3>();
            List<JobEntryV3> jobEntries = new List<JobEntryV3>();

            try
            {
                if (File.Exists(partPath))
                    parts = (List<PartV3>)DeserializeType<List<PartV3>>(partPath);

                if (File.Exists(jobPath))
                    jobs = (List<JobV3>)DeserializeType<List<JobV3>>(jobPath);

                if (File.Exists(jobEntryPath))
                    jobEntries = (List<JobEntryV3>)DeserializeType<List<JobEntryV3>>(jobEntryPath);
            }
            catch (Exception e)
            {
                Logger.GetLogger().Log(new LogEntry(LoggingEventType.Fatal, e.Message, e));
                throw e;
            }

            sb.AppendLine("Stage 1 Complete - Loaded collection successfully.");
            Console.WriteLine("Stage 1 Complete - Loaded collection(s) successfully.");
            
            for (int i = 0; i < parts.Count; i++)
            {
                PartV3 part = parts[i];
                Part newPart = new Part();

                newPart.Name = part.Name;
                newPart.CreationDate = part.CreationDate;
                newPart.LastModifiedDate = part.LastModifiedDate;
                newPart.DefaultBoxCount = part.DefaultBoxCount;
                newPart.Description = part.Description;

                foreach (var note in part.Notes)
                {
                    newPart.Notes.Add(new Note(note.Message) { CreationTime = note.CreationTime });
                }

                inventory.Parts.Add(newPart);

                // Write progress.
                string progress = string.Format("Processing {0}/{1} - ID: {2} Name: {3}", i, parts.Count, part.ID, part.Name);
                sb.AppendLine(progress);
                Console.Write("\r" + progress);
            }

            sb.AppendLine("Saving progress.");
            Console.WriteLine("Saving progress.");
            inventory.Complete();

            // Set parent info.
            foreach (var part in parts)
            {
                if (part.ParentID != Guid.Empty)
                {
                    PartV3 parent = parts.FirstOrDefault(p => p.ID == part.ParentID);

                    if (parent != null)
                    {
                        inventory.Parts.Get(part.Name).Parent = inventory.Parts.Get(parent.Name);

                        string progress = string.Format("Found parent for v3ID: {0}. Parent set. v3PID: {1}", part.ID, part.ParentID);
                        sb.AppendLine(progress);
                        Console.WriteLine("\r" + progress);
                    }
                }
            }

            sb.AppendLine("Saving progress.");
            Console.WriteLine("Saving progress.");
            inventory.Complete();

            for (int i = 0; i < jobs.Count; i++)
            {
                JobV3 job = jobs[i];
                Job newJob;

                PartV3 part = parts.FirstOrDefault(p => p.ID == job.PartId);
                if (part == null)
                    continue;

                // Get the new ID.
                int partId = inventory.Parts.GetID(part.Name);

                newJob = new Job();
                newJob.PartID = partId;
                newJob.Name = job.JobName;
                newJob.CreationDate = job.CreationTime;
                newJob.CompletionDate = job.EndTime;

                if (job.EndTime == DateTime.MinValue)
                    newJob.SetState(JobStateType.InProgress, new Note("v0.3 Import Tool"));
                else
                    newJob.SetState(JobStateType.Complete, new Note("v0.3 Import Tool"));

                inventory.Jobs.Add(newJob);

                string progress = string.Format("Processing Job {0}/{1} - Name {2}", i, jobs.Count, job.JobName);
                sb.AppendLine(progress);
                Console.Write("\r" + progress);
            }

            sb.AppendLine("Saving progress.");
            Console.WriteLine("Saving progress.");
            inventory.Complete();

            Receiver newReceiver = new Receiver();
            inventory.Receivers.Add(newReceiver);

            for (int i = 0; i < jobEntries.Count; i++)
            {
                JobEntryV3 jobEntry = jobEntries[i];
                JobV3 oldJob = jobs.FirstOrDefault(j => j.Id == jobEntry.JobId);

                if (oldJob == null)
                    continue;

                Job job = inventory.Jobs.Get(oldJob.JobName);

                if (job == null)
                    continue;

                Part part = job.Part;

                ReceiverEntry newEntry = new ReceiverEntry.Builder()
                    .SetPart(part.ID)
                    .SetJob(job.ID)
                    .SetReceiver(newReceiver.ID)
                    .SetInfo(1, jobEntry.Quantity)
                    .Build();
                newEntry.Notes.Add(new Note("0.3v Import Tool"));

                inventory.ReceiverEntries.Add(newEntry);

                string progress = string.Format("Processing Job entry {0}/{1} - ID {2}", i, jobEntries.Count, jobEntry.Id);
                sb.AppendLine(progress);
                Console.Write("\r" + progress);
            }

            sb.AppendLine("Saving progress.");
            Console.WriteLine("Saving progress.");
            inventory.Complete();

            sb.AppendLine("Import complete.");
            Console.WriteLine("Import complete.");

            return sb.ToString();
        }

        private static T DeserializeType<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(path, FileMode.Open))
            {
                T result = (T)Convert.ChangeType(serializer.Deserialize(fs), typeof(T));
                return result;
            }
        }
    }
}
