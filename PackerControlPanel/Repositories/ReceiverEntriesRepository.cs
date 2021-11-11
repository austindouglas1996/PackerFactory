using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PackerControlPanel.Core;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Core.Domain;

namespace PackerControlPanel.Data.Repository
{
    public class ReceiverEntriesRepository : XmlRepository<ReceiverEntry, PackerContext>, IReceiverEntriesRepository
    {
        public ReceiverEntriesRepository(PackerContext context)
            : base(context, "ReceiverEntries.XML")
        {

        }

        public ReceiverEntry[] GetEntriesFromDate(DateTime date)
        {
            return base.GetAll().Where(r => r.CreationDate == date).ToArray();
        }

        public ReceiverEntry[] GetEntriesFromJob(int jobID)
        {
            return base.GetAll().Where(r => r.JobID == jobID).ToArray();
        }

        public ReceiverEntry[] GetEntriesFromJob(string jobName)
        {
            Job job = base.Context.Jobs.FirstOrDefault(j => j.Name == jobName);
            if (job == null)
                throw new ArgumentNullException(string.Format("Invalid Value. Failed to find a job by the name of '{0}'.", jobName));

            return base.GetAll().Where(r => r.Job == job).ToArray();
        }

        public ReceiverEntry[] GetEntriesFromPart(int partID)
        {
            return base.GetAll().Where(r => r.PartID == partID).ToArray();
        }

        public ReceiverEntry[] GetEntriesFromPart(string partName)
        {
            Part part = base.Context.Parts.FirstOrDefault(p => p.Name == partName);
            if (part == null)
                throw new ArgumentNullException(string.Format("Invalid Value. Failed to find a part by the name of '{0}'.", partName));

            return base.GetAll().Where(r => r.Part == part).ToArray();
        }

        public ReceiverEntry[] GetEntriesFromReceiver(int receiverID)
        {
            return base.GetAll().Where(r => r.ReceiverID == receiverID).ToArray();
        }

        public ReceiverEntry[] GetEntriesFromReceiver(string receiverName)
        {
            Receiver receiver = base.Context.Receivers.FirstOrDefault(r => r.Name == receiverName);
            if (receiver == null)
                throw new ArgumentNullException(string.Format("Invalid Value. Failed to find a receiver by the name of '{0}'.", receiverName));

            return base.GetAll().Where(r => r.Receiver == receiver).ToArray();
        }

        public ReceiverEntry GetEntryWithInfo(int id)
        {
            return this.Context.ReceiverEntries
                .Include(p => p.Part)
                .Include(j => j.Job)
                .Include(r => r.Receiver)
                .Include(d => d.ManuDates)
                .SingleOrDefault(e => e.ID == id);
        }
    }
}
