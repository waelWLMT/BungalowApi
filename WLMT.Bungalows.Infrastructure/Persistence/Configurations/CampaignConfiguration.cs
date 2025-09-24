using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WLMT.Bungalows.Domain.Entities;

namespace WLMT.Bungalows.Infrastructure.Persistence.Configurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Budget)
               .HasPrecision(18, 2);
        }
    }
}
