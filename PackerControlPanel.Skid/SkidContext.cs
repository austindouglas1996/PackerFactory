using PackerControlPanel.Skids.Domain;
using PackerControlPanel.Skids.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Skids
{
    public class SkidContext : DbContext
    {
        public SkidContext()
            : this("name=SkidContext")
        {
        }

        public SkidContext(string connectionPath)
            : base(connectionPath)
        {
            Configuration.ProxyCreationEnabled = false;
            this.Database.CreateIfNotExists();
        }

        public virtual DbSet<Skid> Skids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SkidContext, Configuration>(true));

            // Conventions.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
