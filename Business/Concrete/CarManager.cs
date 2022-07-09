using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.ItemNameInvalid);
            }
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            _iCarDal.Add(car);

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c=> c.Id == id));
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }
    }
}