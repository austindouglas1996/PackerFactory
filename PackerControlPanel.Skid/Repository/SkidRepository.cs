using PackerControlPanel.Data.Repository;
using PackerControlPanel.Skids.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Skids.Repository
{
    public class SkidRepository : XmlRepository<Skid, SkidContext>, ISkidRepository
    {
        public SkidRepository(SkidContext context, string fileName) 
            : base(context, fileName)
        {
        }
    }
}
