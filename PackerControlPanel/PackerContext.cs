using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data.EntityConfigurations;
using PackerControlPanel.Data.Migrations;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data
{
    public class PackerContext : DbContext
    {
        public PackerContext()
            : this("name=PackerContext", null)
        {

        }

        public PackerContext(string connectionPath, IDatabaseInitializer<PackerContext> initializer = null) 
            : base(connectionPath)
        {
            /*
            if (initializer != null)
                Database.SetInitializer<PackerContext>(initializer);
            else
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<PackerContext, Migrations.Configuration>());
            */

            Configuration.ProxyCreationEnabled = false;
            this.Database.CreateIfNotExists();

            /*
             * ***************DEBUG PURPOSES ONLY***************
             * DO NOT LOAD CONTENT ON STARTUP >:C
             */
            this.Parts.Load();
            this.Jobs.Load();
            this.Receivers.Load();
            this.ReceiverEntries.Load();
            this.DateEntries.Load();
            this.Transfers.Load();
            this.TransfersEntries.Load();
            this.Notes.Load();
            this.Skids.Load();
        }

        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Receiver> Receivers { get; set; }
        public virtual DbSet<ReceiverEntry> ReceiverEntries { get; set; }
        public virtual DbSet<ReceiverEntryDateEntry> DateEntries { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<TransferEntry> TransfersEntries { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Skid> Skids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PackerContext, Configuration>(true));
            //Database.SetInitializer(new SqliteDropCreateDatabaseWhenModelChanges<PackerContext>(modelBuilder));

            // Conventions.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Configurations.
            modelBuilder.Configurations.Add(new PartConfiguration());

            modelBuilder.Entity<Job>()
                .HasRequired(p => p.Part)
                .WithMany(j => j.Jobs)
                .HasForeignKey(p => p.PartID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ReceiverEntry>()
                .HasRequired(p => p.Receiver)
                .WithMany(a => a.Entries)
                .HasForeignKey(p => p.ReceiverID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ReceiverEntry>()
                .HasMany<Note>(n => n.Notes)
                .WithOptional(e => (ReceiverEntry)e.Parent)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ReceiverEntry>()
                .HasRequired(p => p.Part)
                .WithMany(a => a.Entries)
                .HasForeignKey(p => p.PartID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiverEntry>()
                .HasRequired(j => j.Job)
                .WithMany(a => a.Entries)
                .HasForeignKey(j => j.JobID)
                .WillCascadeOnDelete(true);

            
            modelBuilder.Entity<ReceiverEntryDateEntry>()
                .HasRequired(e => e.Entry)
                .WithMany(j => j.ManuDates)
                .WillCascadeOnDelete(true);
                

            modelBuilder.Entity<TransferEntry>()
                .HasRequired(t => t.Transfer)
                .WithMany(ta => ta.Entries)
                .HasForeignKey(i => i.TransferID)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
