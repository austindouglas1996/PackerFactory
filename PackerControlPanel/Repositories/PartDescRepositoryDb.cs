using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using PackerControlPanel.Data.Repository;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;

namespace PackerControlPanel.Data.Repository
{
    public class PartDescRepositoryDb : XmlRepository<PartDescInfo, PartDescDbContext>, IPartDescRepository
    {
        public PartDescRepositoryDb(PartDescDbContext context)
            : base(context, "PartDesc.XML")
        {

        }

        public bool Contains(string partName)
        {
            return base.FirstOrDefault(p => p.PartName.ToLower() == partName.ToLower()) != null;
        }
    }
}