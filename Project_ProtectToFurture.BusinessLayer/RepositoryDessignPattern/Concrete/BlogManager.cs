using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.BusinessLayer.ValidationRules.BlogValidationRules;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.Abstract;
using Project_ProtectToFurture.DTOLayer.BlogDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
	public class BlogManager : IBlogService
	{

		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;


		public BlogManager(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;

		}

		public void Create(BlogCreateDto dto)
		{		

            _unitOfWork.GetRepository<Blog>().Insert(_mapper.Map<Blog>(dto));
			_unitOfWork.Save();

			var blog = _unitOfWork.GetRepository<Blog>().GetAll().LastOrDefault();

            if (dto.ImageUrl != null)
            {
                             
                    var extension = Path.GetExtension(dto.ImageUrl.FileName);
                    var fileName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf", fileName);
                    var stream = new FileStream(location, FileMode.Create);
                    dto.ImageUrl.CopyTo(stream);
                    blog.ImageUrl = "/pdf/" + fileName;
					_unitOfWork.Save();
                
				
            }

        }

        public void Delete(int id)
		{
			var removeEntity = _unitOfWork.GetRepository<Blog>().GetById(id);
			_unitOfWork.GetRepository<Blog>().Delete(removeEntity);
			_unitOfWork.Save();
		}

		public List<BlogListDto> GetAll()
		{
			return _mapper.Map<List<BlogListDto>>(_unitOfWork.GetRepository<Blog>().GetAll());
		}

		public IDto GetById<IDto>(int id)
		{

			return _mapper.Map<IDto>(_unitOfWork.GetRepository<Blog>().GetById(id));
		}

      

        public void Update(BlogUpdateDto dto)
		{
			var updateEntity = _unitOfWork.GetRepository<Blog>().GetById(dto.BlogId);
			dto.ImageUrl=updateEntity.ImageUrl;
			if (updateEntity != null)
			{
			
				_unitOfWork.GetRepository<Blog>().Update(_mapper.Map<Blog>(dto), updateEntity);				
				_unitOfWork.Save();
			}

		}

       
    }
}
