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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        private readonly IUnitOfWork _unitOfWork;

        public FeatureManager(IFeatureDal featureDal, IUnitOfWork unitOfWork)
        {
            _featureDal = featureDal;
            _unitOfWork = unitOfWork;
        }

        public void TDelete(Feature t)
        {
            _featureDal.Delete(t);
            _unitOfWork.Save();
        }

        public List<Feature> TGetAll()
        {
            return _featureDal.GetAll();
        }

        public Feature TGetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public void TInsert(Feature t)
        {
            _featureDal.Insert(t);
            _unitOfWork.Save();
        }
        public void TUpdate(Feature t)
        {
            //_featureDal.Update(t);
            //_unitOfWork.Save();

        }
    }
}
