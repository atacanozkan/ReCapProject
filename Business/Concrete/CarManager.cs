using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public void Add(Car car)
        {
            _iCarDal.Add(car);
        }

        public void Update(Car car)
        {
            _iCarDal.Update(car);
        }

        public void Delete(Car car)
        {
            _iCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _iCarDal.Get(c=> c.Id == id);
        }

        public Car GetByBrandId(int id)
        {
            return _iCarDal.Get(c => c.BrandId == id);
        }

        public Car GetByColorId(int id)
        {
            return _iCarDal.Get(c => c.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }
    }
}