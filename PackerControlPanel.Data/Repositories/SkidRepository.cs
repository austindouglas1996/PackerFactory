using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.Repository
{
    public class SkidRepository : XmlRepository<Skid, PackerContext>, ISkidRepository
    {
        public SkidRepository(PackerContext context, string fileName = "Skids.XML") 
            : base(context, fileName)
        {
        }
    }
}
