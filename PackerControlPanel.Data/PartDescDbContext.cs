using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data
{
    public class PartDescDbContext : DbContext
    {
        public PartDescDbContext()
            : this("PartDescDb", null)
        {

        }

        public PartDescDbContext(string connectionPath, IDatabaseInitializer<PartDescDbContext> initializer = null)
            : base(connectionPath)
        {
            if (initializer != null)
                Database.SetInitializer(initializer);
            else
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PartDescDbContext, DescConfiguration>());

            Configuration.ProxyCreationEnabled = false;

            PartDescriptions = Set<PartDescInfo>();
        }

        public virtual DbSet<PartDescInfo> PartDescriptions { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();     
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
