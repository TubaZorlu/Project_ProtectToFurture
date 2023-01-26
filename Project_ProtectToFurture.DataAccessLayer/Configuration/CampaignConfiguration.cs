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
	public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
	{
		public void Configure(EntityTypeBuilder<Campaign> builder)
		{
			builder.HasKey(x => x.CampaignId);
			builder.Property(x => x.CampaignId).IsRequired();
			builder.Property(x => x.CampaignName).IsRequired().HasMaxLength(100);

			builder.HasMany(x => x.Signatures)
				.WithOne(x => x.Campaign)
				.HasForeignKey(x => x.CampaignId);
		}
	}
}
