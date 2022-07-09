using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager: IRentalService
    {
        IRentalDal _iRentalDal;

        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (GetById(rental.Id).Data == null)
            {

                var result = GetByCarId(rental.CarId);

                if (result.Data != null)
                {
                    if (rental.RentDate < result.Data.Last().ReturnDate)
                    {
                        return new ErrorResult(Messages.InvalidRentalTime);
                    }
                }

                _iRentalDal.Add(rental);
                return new SuccessResult(Messages.ItemAdded);
            }
            else
            {
                return new ErrorResult(Messages.ItemExists);
            }
        }

        public IResult Update(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_iRentalDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Rental>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_iRentalDal.GetRentalDetails());
        }
    }
}