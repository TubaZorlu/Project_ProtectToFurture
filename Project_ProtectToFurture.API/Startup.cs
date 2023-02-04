using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Project_ProtectToFurture.API.Hubs;

using Project_ProtectToFurture.DataAccessLayer.Context;
using System;
using System.Text;

namespace Project_ProtectToFurture.API
{
	public class Startup
	{
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {

				opt.RequireHttpsMetadata = false;
				opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidIssuer="http://localhost",
					ValidAudience ="http://localhost",
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Zorluzorluzorlu1.")),
					ValidateIssuerSigningKey=true,
					ValidateLifetime= true,
					ClockSkew=TimeSpan.Zero //herhangi bir geçikme olmasın

				};

			});



			services.AddDbContext<ProjectContext>();
			services.AddScoped<SignatureService>();
			services.AddCors();
			services.AddSignalR();
			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project_ProtectToFurture.API", Version = "v1" });
			});


		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project_ProtectToFurture.API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
				.SetIsOriginAllowed(origin => true));

			app.UseAuthentication();
			app.UseAuthorization();
		
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<SignatureHub>("/SignatureHub");
			});
		}
	}
}
