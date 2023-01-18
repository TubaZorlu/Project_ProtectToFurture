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
	public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
	{
		public void Configure(EntityTypeBuilder<Feature> builder)
		{
			builder.HasKey(x => x.FeatureId);
			builder.Property(x => x.FeatureId).IsRequired();
			builder.Property(x => x.Title).HasMaxLength(100);
			builder.Property(x => x.Descriptin).HasMaxLength(1000);
		}
	}
}
