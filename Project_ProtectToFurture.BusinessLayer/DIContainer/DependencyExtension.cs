using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Project_ProtectToFurture.BusinessLayer.Mapping.BlogMapping;
using Project_ProtectToFurture.BusinessLayer.Mapping.ProjectMapping;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.BlogValidationRules;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DataAccessLayer.EntityFramework;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.DIContainer
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfwork>();
            services.AddDbContext<ProjectContext>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IDonarService, DonarManager>();
            services.AddScoped<IDonarDal, EfDonarDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<IProjectDal,EfProjectDal>();

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new BlogProfile());
                opt.AddProfile(new ProjectProfile());

            });
            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient<IValidator<BlogCreateDto>, CreateBlogValidator>();
            services.AddTransient<IValidator<BlogUpdateDto>, UpdateBlogValidator>();

        }
    }
}
