using Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Abstract;
using Project_ProtectToFurture.DataAccessLayer.Abstract;
using Project_ProtectToFurture.DataAccessLayer.UnitOfWork;
using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.RepositoryDessignPattern.Concrete
{
    public class DonorManager : IDonorService
    {
        private readonly IDonorDal _donorDal;
        private readonly IUnitOfWork _unitOfWork;

        public DonorManager(IDonorDal donarDal, IUnitOfWork unitOfWork)
        {
            _donorDal = donarDal;
            _unitOfWork = unitOfWork;
        }

        public void TDelete(Donor t)
        {
            _donorDal.Delete(t);
            _unitOfWork.Save();
        }

        public List<Donor> TGetAll()
        {
            return _donorDal.GetAll();
        }

        public Donor TGetById(int id)
        {
            return _donorDal.GetById(id);
        }

        public void TInsert(Donor t)
        {
            _donorDal.Insert(t);
            _unitOfWork.Save();
        }

        public void TUpdate(Donor t)
        {
            //_donarDal.Update(t);
            //_unitOfWork.Save();
        }
    }
}
