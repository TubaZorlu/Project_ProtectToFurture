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
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.HasKey(x => x.ContanctId);
			builder.Property(x => x.ContanctId).IsRequired();
			builder.Property(x => x.Email).HasMaxLength(50);
			builder.Property(x => x.Message).HasMaxLength(1000);
			
		}
	}
}
