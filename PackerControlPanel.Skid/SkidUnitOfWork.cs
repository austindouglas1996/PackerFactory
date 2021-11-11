using EntityRepository;
using PackerControlPanel.Skids.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Skids
{
    public class SkidUnitOfWork : ISkidUnitOfWork, IUnitOfWork
    {
        private SkidContext _Context;

        public SkidUnitOfWork(SkidContext context)
        {
            this._Context = context;

            Skids = new SkidRepository(this._Context, "Skids.XML");
        }

        public ISkidRepository Skids { get; private set; }

        public int Complete()
        {
            this._Context.SaveChanges();
            return 0;
        }

        public void Dispose()
        {
            this._Context.Dispose();
            this._Context = null;
        }
    }
}
