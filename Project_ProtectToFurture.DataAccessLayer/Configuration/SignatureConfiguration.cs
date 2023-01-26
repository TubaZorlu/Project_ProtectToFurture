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
	public class SignatureConfiguration : IEntityTypeConfiguration<Signature>
	{
		public void Configure(EntityTypeBuilder<Signature> builder)
		{
			builder.HasKey(x => x.SignatureId);
			builder.Property(x => x.SignatureId).IsRequired();


			builder.HasOne(x => x.Campaign)
				.WithMany(x => x.Signatures)
				.HasForeignKey(x => x.CampaignId);

		}
	}
}
