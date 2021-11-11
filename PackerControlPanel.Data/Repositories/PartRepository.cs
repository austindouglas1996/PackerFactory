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
    public class PartRepository : XmlRepository<Part, PackerContext>, IPartRepository
    {
        public PartRepository(PackerContext context)
            : base(context, "Parts.XML")
        {

        }

        public Part Get(string name)
        {
            return this.Context.Parts
                .Include(j => j.Jobs)
                .Include(re => re.Entries)
                .AsEnumerable()
                .FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public int GetID(string name)
        {
            Part part = this.Context.Parts.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            return part == null ? -1 : part.ID;
        }
    }
}
