using EntityRepository;
using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Repository
{
    public interface IPartRepository : IRepository<Part>
    {
        Part Get(string name);
        int GetID(string name);
    }
}
