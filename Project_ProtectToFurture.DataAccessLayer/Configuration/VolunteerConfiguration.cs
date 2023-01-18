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
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.HasKey(x => x.VolunteerId);
            builder.Property(x => x.VolunteerId).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(20).IsRequired();
            builder.Property(x => x.volunteerEmail).IsRequired();

            builder.HasOne(x => x.AppUser)
                    .WithMany(x => x.Volunteers)
                    .HasForeignKey(x => x.VolunteerId);

        }
    }
}
