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
    public class DonarManager : IDonarService
    {
        private readonly IDonarDal _donarDal;
        private readonly IUnitOfWork _unitOfWork;

        public DonarManager(IDonarDal donarDal, IUnitOfWork unitOfWork)
        {
            _donarDal = donarDal;
            _unitOfWork = unitOfWork;
        }

        public void TDelete(Donar t)
        {
            _donarDal.Delete(t);
            _unitOfWork.Save();
        }

        public List<Donar> TGetAll()
        {
            return _donarDal.GetAll();
        }

        public Donar TGetById(int id)
        {
            return _donarDal.GetById(id);
        }

        public void TInsert(Donar t)
        {
            _donarDal.Insert(t);
            _unitOfWork.Save();
        }

        public void TUpdate(Donar t)
        {
            //_donarDal.Update(t);
            //_unitOfWork.Save();
        }
    }
}
