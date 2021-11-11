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
    public class ReceiverRepository : XmlRepository<Receiver, PackerContext>, IReceiverRepository
    {
        public ReceiverRepository(PackerContext context)
            : base(context, "Receivers.XML")
        {

        }

        public Receiver Get(string name)
        {
            return this.Context.Receivers
                .Include(re => re.Entries)
                .FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
        }

        public int GetID(string name)
        {
            return Get(name).ID;
        }

        public Receiver[] GetReceivers(DateTime startTime, DateTime endTime)
        {
            // https://stackoverflow.com/questions/5672862/check-if-datetime-instance-falls-in-between-other-two-datetime-objects
            // I got so confused, maybe i'm too tired x.x
            //return this.Context.Set<Receiver>().Where(r => r.CreationTime.Ticks > date1.Ticks && r.CreationTime.Ticks < date2.Ticks).ToArray();

            return this.Context.Receivers
                .Include(re => re.Entries)
                .Where(r => r.CreationTime <= startTime && r.CreationTime < endTime).ToArray();
        }
    }
}
