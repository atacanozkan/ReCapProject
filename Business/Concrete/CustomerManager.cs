using System;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.Constants;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _iCustomerDal;

        public CustomerManager(ICustomerDal iCustomerDal)
        {
            _iCustomerDal = iCustomerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.ItemNameInvalid);
            }
            _iCustomerDal.Add(customer);

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Update(Customer customer)
        {
            _iCustomerDal.Update(customer);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(Customer customer)
        {
            _iCustomerDal.Delete(customer);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customer>>(_iCustomerDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_iCustomerDal.Get(c => c.UserId == id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_iCustomerDal.GetCustomerDetails());
        }
    }
}