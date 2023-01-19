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
	public class DonorConfiguration : IEntityTypeConfiguration<Donor>
	{
		public void Configure(EntityTypeBuilder<Donor> builder)
		{
			builder.HasKey(x => x.DonorId);
			builder.Property(x => x.DonorId).IsRequired();
			builder.Property(x => x.DonorCity).HasMaxLength(20);
			builder.Property(x => x.DonorAdress).HasMaxLength(500);
			builder.Property(x => x.DonorSurname).HasMaxLength(50);
			builder.Property(x => x.DonorSurname).IsRequired();
			builder.Property(x => x.DonorName).IsRequired();
			builder.Property(x => x.DonorName).HasMaxLength(50);
			builder.Property(x => x.Amout).IsRequired();
			builder.Property(x => x.DonorEmail).IsRequired();
			builder.Property(x => x.DonorEmail).HasMaxLength(100);

			builder.HasMany(x => x.Projects)
				.WithOne(x => x.Donor)
				.HasForeignKey(x => x.DonorId);
				
				

		
		

				
		}
	}
}
