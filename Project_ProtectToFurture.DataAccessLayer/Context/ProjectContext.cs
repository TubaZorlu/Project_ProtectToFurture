using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_ProtectToFurture.DataAccessLayer.Configuration;
using Project_ProtectToFurture.EntityLayer.CallenderEvent;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.DataAccessLayer.Context
{
	public class ProjectContext:IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-CJELTSN\\MSSQLSERVER2019; Database=FinalProjectDb;integrated security=True;");
		}
		 
		public DbSet<About> Abouts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Donor> Donors { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Volunteer> Volunteers { get; set; }
		public DbSet<Signature> Signatures { get; set; }
		public DbSet<Campaign> Campaigns { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.ApplyConfiguration(new AboutConfiguration());
			modelBuilder.ApplyConfiguration(new BlogConfiguration());
			modelBuilder.ApplyConfiguration(new ContactConfiguration());
			modelBuilder.ApplyConfiguration(new DonorConfiguration());
			modelBuilder.ApplyConfiguration(new EventConfiguration());
			modelBuilder.ApplyConfiguration(new FeatureConfiguration());
			modelBuilder.ApplyConfiguration(new ProjectConfiguration());
			modelBuilder.ApplyConfiguration(new SignatureConfiguration());
			modelBuilder.ApplyConfiguration(new CampaignConfiguration());
		
			base.OnModelCreating(modelBuilder);

		}
	}
}
