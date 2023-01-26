using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Project_ProtectToFurture.API.Hubs;
using Project_ProtectToFurture.DataAccessLayer.Context;

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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<SignatureHub>("/SignatureHub");
			});
		}
	}
}
