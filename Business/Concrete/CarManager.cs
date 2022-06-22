using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public Car GetById(int id)
        {
            return _iCarDal.GetById(id);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
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
    }
}