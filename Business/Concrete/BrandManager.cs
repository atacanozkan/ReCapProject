using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
        public Brand GetById(int id)
        {
            return _brandDal.Get(b => b.Id == id);
        }
    }
}