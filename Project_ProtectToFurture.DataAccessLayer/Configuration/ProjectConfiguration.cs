using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DataAccessLayer.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.ProjectId);
            builder.Property(x => x.ProjectId).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.FundNeed).IsRequired();
            builder.Property(x => x.Area).HasMaxLength(100);
            builder.Property(x => x.Details).HasMaxLength(500);

            builder.HasOne(x => x.Donor)
                .WithMany(x => x.Projects)
            .HasForeignKey(x => x.DonorId);
        }
    }
}
