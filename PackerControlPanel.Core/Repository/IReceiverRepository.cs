using EntityRepository;
using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Repository
{
    public interface IReceiverRepository : IRepository<Receiver>
    {
        Receiver Get(string name);
        int GetID(string name);

        Receiver[] GetReceivers(DateTime startTime, DateTime endTime);
    }
}
