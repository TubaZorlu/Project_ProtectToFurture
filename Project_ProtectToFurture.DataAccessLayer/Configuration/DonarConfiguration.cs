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
	public class DonarConfiguration : IEntityTypeConfiguration<Donar>
	{
		public void Configure(EntityTypeBuilder<Donar> builder)
		{
			builder.HasKey(x => x.DonarId);
			builder.Property(x => x.DonarId).IsRequired();
			builder.Property(x => x.DonarCity).HasMaxLength(20);
			builder.Property(x => x.DonarAdress).HasMaxLength(500);
			builder.Property(x => x.DonarSurname).HasMaxLength(50);
			builder.Property(x => x.DonarSurname).IsRequired();
			builder.Property(x => x.DonarName).IsRequired();
			builder.Property(x => x.DonarName).HasMaxLength(50);
			builder.Property(x => x.Amout).IsRequired();
			builder.Property(x => x.DonarEmail).IsRequired();
			builder.Property(x => x.DonarEmail).HasMaxLength(100);
		}
	}
}
