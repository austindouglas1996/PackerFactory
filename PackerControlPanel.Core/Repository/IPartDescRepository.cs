using System;
using System.Collections.Generic;
using EntityRepository;
using PackerControlPanel.Core.Domain;

namespace PackerControlPanel.Core.Repository
{
    public interface IPartDescRepository : IRepository<PartDescInfo>
    {
        bool Contains(string partName);
    }
}