using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_ProtectToFurture.EntityLayer.CallenderEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DataAccessLayer.Configuration
{
	public class EventConfiguration : IEntityTypeConfiguration<Event>
	{
		public void Configure(EntityTypeBuilder<Event> builder)
		{
			builder.HasKey(x => x.id);
			builder.Property(x => x.id).IsRequired();
			builder.Property(x => x.title).HasMaxLength(100);
			builder.Property(x => x.color).HasMaxLength(10);
			builder.Property(x => x.textColor).HasMaxLength(10);
			builder.Property(x => x.description).HasMaxLength(1000);
		}
	}
}
