using EntityRepository;
using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data
{
    public class PackerUnitOfWork : IUnitOfWork, IPackerUnitOfWork
    {
        private PackerContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context"></param>
        public PackerUnitOfWork(PackerContext context)
        {
            this.context = context;

            this.Parts = new PartRepository(context);
            this.Jobs = new JobRepository(context);
            this.Receivers = new ReceiverRepository(context);
            this.ReceiverEntries = new ReceiverEntriesRepository(context);
            this.DateEntries = new DateEntryRepository(context);
            this.Transfers = new TransferRepository(context);
            this.TransfersEntries = new TransferEntryRepository(context);
            this.Skids = new SkidRepository(context);


            Part pblank = this.Parts.Get("Blank");
            Job jblank = this.Jobs.Get(" ");

            if (pblank == null)
            {
                pblank = new Part("Blank", 0, "Default Part");
                this.Parts.Add(pblank);

                context.SaveChanges();
            }

            if (jblank == null)
            {
                jblank = new Job();
                jblank.Name = " ";
                jblank.Part = pblank;
                jblank.IsGlobal = true;
                this.Jobs.Add(jblank);

                context.SaveChanges();
            }
        }

        public IPartRepository Parts { get; private set; }
        public IJobRepository Jobs { get; private set; }
        public IReceiverRepository Receivers { get; private set; }
        public IReceiverEntriesRepository ReceiverEntries { get; private set; }
        public IDateEntryRepository DateEntries { get; private set; }
        public ITransferRepository Transfers { get; private set; }
        public ITransferEntryRepository TransfersEntries { get; private set; }
        public ISkidRepository Skids { get; private set; }

        /// <summary>
        /// Save all changes to the database.
        /// </summary>
        /// <returns></returns>
        public virtual int Complete()
        {
            return context.SaveChanges();
        }

        /// <summary>
        /// Dispose of this object.
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
