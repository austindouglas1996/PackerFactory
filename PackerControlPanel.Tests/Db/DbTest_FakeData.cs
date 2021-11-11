using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Tests.Db
{
    public class DbTest_FakeData
    {
        private static Random rand = new Random();

        public static void ClearDB(PackerUnitOfWork worker)
        {
            worker.Parts.RemoveAll();
            worker.Jobs.RemoveAll();
            worker.Receivers.RemoveAll();
            worker.ReceiverEntries.RemoveAll();
            worker.DateEntries.RemoveAll();
            worker.Complete();
        }

        public static void FillFakeData(PackerUnitOfWork worker, int count)
        {
            FillPart(worker, count);
            worker.Complete();

            FillJob(worker, count);
            worker.Complete();

            FillFakeReceivers(worker, count, 1, 70);
            worker.Complete();
        }

        public static void FillPart(PackerUnitOfWork worker, int count)
        {
            for (int i = 0; i < count; i ++)
            {
                Part nPart = new Part();
                nPart.Name = "Part" + rand.Next(300, 10000);
                nPart.DefaultBoxCount = rand.Next(100, 800);
                nPart.Description = "Fake";

                worker.Parts.Add(nPart);
            }

            worker.Complete();
        }

        public static void FillJob(PackerUnitOfWork worker, int count)
        {
            List<Part> parts = worker.Parts.GetAll().ToList();
            int maxPart = parts.Count();

            for (int i = 0; i < count; i++)
            {
                Job job = new Job();
                job.Name = "job" + rand.Next(300, 10000);
                job.Part = parts[rand.Next(0, maxPart)];

                worker.Jobs.Add(job);
            }

            worker.Complete();
        }

        public static void FillFakeReceivers(PackerUnitOfWork worker, int count, int entriesMin, int entriesMax)
        {
            List<Part> parts = worker.Parts.GetAll().ToList();
            List<Job> jobs = worker.Jobs.GetAll().ToList();

            int entries = rand.Next(entriesMin, entriesMax);

            for (int i = 0; i < count; i++)
            {
                Receiver r = new Receiver();
                worker.Receivers.Add(r);
                worker.Complete();

                for (int k = 0; k < entries; k++)
                {
                    ReceiverEntry entry = new ReceiverEntry();
                    entry.Part = parts[rand.Next(0, parts.Count())];
                    entry.Job = jobs[rand.Next(0, jobs.Count())];
                    entry.Receiver = r;
                    entry.Boxes = rand.Next(2, 100);
                    entry.BoxCount = rand.Next(1, 800);

                    worker.ReceiverEntries.Add(entry);
                    worker.Complete();
                }
            }

            worker.Complete();
        }
    }
}
