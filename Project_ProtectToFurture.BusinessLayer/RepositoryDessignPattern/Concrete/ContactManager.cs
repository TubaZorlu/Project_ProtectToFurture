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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IUnitOfWork _unitOfWork;

        public ContactManager(IContactDal contactDal, IUnitOfWork unitOfWork)
        {
            _contactDal = contactDal;
            _unitOfWork = unitOfWork;
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
            _unitOfWork.Save();
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll();
            
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public void TInsert(Contact t)
        {
            _contactDal.Insert(t);
            _unitOfWork.Save();
        }

        public void TUpdate(Contact t)
        {

            //_contactDal.Update(t);
            //_unitOfWork.Save();
        }
    }
}
