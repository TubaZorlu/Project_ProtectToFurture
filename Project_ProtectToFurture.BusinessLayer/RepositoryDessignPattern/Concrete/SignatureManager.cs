using AutoMapper;
using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.EntityFramework;
using Project_ProtectToFurture.DataAccessLayer.Migrations;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.DTOLayer.SignatureDtos;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
	public class SignatureManager : ISignatureService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ISignatureDal _signatureDal;
		private readonly IMapper _mapper;

		public SignatureManager(IUnitOfWork unitOfWork, IMapper mapper, ISignatureDal signatureDal)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_signatureDal = signatureDal;
		}

		public void Create(SignatureCreateDto dto)
		{
			_unitOfWork.GetRepository<Signature>().Insert(_mapper.Map<Signature>(dto));
			_unitOfWork.Save();
		}

		public IDto GetById<IDto>(int id)
		{
			return _mapper.Map<IDto>(_unitOfWork.GetRepository<Signature>().GetById(id));
		}

		public IDto GetWithCampaignById<IDto>(int id)
		{
			return _mapper.Map<IDto>(_signatureDal.GetWithCampaign(id));
		}
	}
}
