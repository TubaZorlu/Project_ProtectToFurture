using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Project_ProtectToFurture.BusinessLayer.DIContainer;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.IdentityValidationRules;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Text;

namespace Project_ProtectToFurture.UILayer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddDependencies();

			//services.AddAutoMapper(typeof(Startup));

			services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

			//services.AddScoped<GetAboutByIdQueryHandler>();

			services.AddIdentity<AppUser, AppRole>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<ProjectContext>();


			services.ConfigureApplicationCookie(opt =>
			{
				//javascript kodları ile artık çekilemez
				opt.Cookie.HttpOnly= true;
				opt.Cookie.SameSite = SameSiteMode.Strict;
				opt.Cookie.SecurePolicy = CookieSecurePolicy.None;
				opt.Cookie.Name = "FinalProject";
				opt.ExpireTimeSpan= TimeSpan.FromDays(1);
				opt.LoginPath = new PathString("/WebSite/Default/Index/");
				opt.AccessDeniedPath = new PathString("/WebSite/Default/Index/");
			});

			//jwt token konfigürayonu 
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>{

				//jwt https ile çalışır, http ile çalıştığım için false çektim 
				opt.RequireHttpsMetadata = false;
				opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidIssuer = "http://localhost",
					ValidAudience = "http://localhost",
					//3 tip şifreleme var simetrik asimetrik ve hash şeklinde
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Zorluzorluzorlu1.")),
					ValidateIssuerSigningKey = true,
					ValidateLifetime= true,
					ClockSkew=TimeSpan.Zero,


				};

			});
			//fluentvalidation konfigürayonu
			services.AddControllersWithViews().AddFluentValidation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Login}/{action=Index}/{id?}");
			});
		}
	}
}
