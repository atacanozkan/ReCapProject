using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _iUserDal;

        public UserManager(IUserDal iUserDal)
        {
            _iUserDal = iUserDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.ItemNameInvalid);
            }
            _iUserDal.Add(user);

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Update(User user)
        {
            _iUserDal.Update(user);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(User user)
        {
            _iUserDal.Delete(user);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<User>>(_iUserDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_iUserDal.Get(c=> c.Id == id));
        }

    }
}