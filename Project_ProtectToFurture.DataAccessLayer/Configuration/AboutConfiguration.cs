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
	public class AboutConfiguration : IEntityTypeConfiguration<About>
	{
		public void Configure(EntityTypeBuilder<About> builder)
		{
			builder.HasKey(x => x.AboutId);
			builder.Property(x => x.AboutId).IsRequired();
			builder.Property(x=>x.Title).HasMaxLength(200);
			builder.Property(x=>x.Title2).HasMaxLength(200);
			builder.Property(x => x.ImageUrl).HasMaxLength(500);
			builder.Property(x => x.Description).HasMaxLength(500);

			
		}
	}
}
