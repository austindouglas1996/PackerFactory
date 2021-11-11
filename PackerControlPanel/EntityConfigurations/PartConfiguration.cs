using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Data.EntityConfigurations
{
    public class PartConfiguration : EntityTypeConfiguration<Part>
    {
        public PartConfiguration()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60);

            Property(p => p.Description)
                .IsOptional()
                .HasMaxLength(255);
        }
    }
}
