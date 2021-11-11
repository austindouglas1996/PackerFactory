using EntityRepository;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data.Helpers;
using PackerControlPanel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data
{
    public class PartDescDbWorker : IUnitOfWork
    {
        private PartDescDbContext _context;

        public PartDescDbWorker(PartDescDbContext context)
        {
            _context = context;

            PartDescriptions = new PartDescRepositoryDb(context);
        }

        public IPartDescRepository PartDescriptions {get; private set;}

        public int Complete()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.GetLogger().Log(e);
                throw e;
            }

            return 1;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
