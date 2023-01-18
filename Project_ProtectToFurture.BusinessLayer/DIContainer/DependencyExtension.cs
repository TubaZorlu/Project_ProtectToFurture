using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Project_ProtectToFurture.BusinessLayer.Mapping.BlogMapping;
using Project_ProtectToFurture.BusinessLayer.Mapping.ContactMapping;
using Project_ProtectToFurture.BusinessLayer.Mapping.FeatureMapping;
using Project_ProtectToFurture.BusinessLayer.Mapping.ProjectMapping;
using Project_ProtectToFurture.BusinessLayer.Mapping.VolunteerMapping;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.BlogValidationRules;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.ContactValitaionRules;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.DonorValidationRules;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.FeatureValidationRules;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.ProjectValidationRules;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.VolunteerDto;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Context;
using Project_ProtectToFurture.DataAccessLayer.EntityFramework;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.DTOLayer.ContactDtos;
using Project_ProtectToFurture.DTOLayer.FeatureDtos;
using Project_ProtectToFurture.DTOLayer.ProjectDtos;
using Project_ProtectToFurture.DTOLayer.VolunteerDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
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

            services.AddScoped<IDonorService, DonorManager>();
            services.AddScoped<IDonorDal, EfDonorDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<IProjectDal,EfProjectDal>();

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new BlogProfile());
                opt.AddProfile(new ProjectProfile());
                opt.AddProfile(new VolunteerProfile());
                opt.AddProfile(new FeatureProfile());
                opt.AddProfile(new ContactProfile());

            });
            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient<IValidator<BlogCreateDto>, CreateBlogValidator>();
            services.AddTransient<IValidator<BlogUpdateDto>, UpdateBlogValidator>();

            services.AddTransient<IValidator<ProjectCreateDto>, CreateProjectValidator>();
            services.AddTransient<IValidator<ProjectUpdateDto>, UpdateProjectValidator>();

            services.AddTransient<IValidator<VolunteerCreateDto>, CreateVolunteerValidator>();
            services.AddTransient<IValidator<VolunteerUpdateDto>, UpdateVolunteerValidator>();

            services.AddTransient<IValidator<FeatureCreateDto>, CreateFeatureValidator>();
            services.AddTransient<IValidator<FeatureUpdateDto>, UpdateFeatureValidator>();

            services.AddTransient<IValidator<ContactCreateDto>, CreateContactValidator>();
            services.AddTransient<IValidator<Donor>, DonorValidator>();




        }
    }
}
