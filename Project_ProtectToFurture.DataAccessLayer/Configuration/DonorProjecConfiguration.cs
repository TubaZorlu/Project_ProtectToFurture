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
    public class DonorProjecConfiguration : IEntityTypeConfiguration<DonorProject>
    {
        public void Configure(EntityTypeBuilder<DonorProject> builder)
        {
            //composete key
            builder.HasKey(x => new { x.ProjectId, x.DonorId });

            builder.HasOne(x=>x.Project).WithMany(x=>x.DonorProjects).HasForeignKey(x=>x.ProjectId);   
            builder.HasOne(x=>x.Donor).WithMany(x=>x.DonorProjects).HasForeignKey(x=>x.DonorId);   
            
        }
    }
}
