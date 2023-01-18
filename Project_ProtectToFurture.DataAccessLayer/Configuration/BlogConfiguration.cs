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
	public class BlogConfiguration : IEntityTypeConfiguration<Blog>
	{
		public void Configure(EntityTypeBuilder<Blog> builder)
		{
			builder.HasKey(x => x.BlogId);
			builder.Property(x => x.BlogId).IsRequired();
			builder.Property(x => x.Title).HasMaxLength(100);
			builder.Property(x => x.Description).HasMaxLength(1000);
			builder.Property(x => x.ImageUrl).HasMaxLength(500);
		
		}
	}
}
