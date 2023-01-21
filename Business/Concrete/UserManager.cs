using Business.Abstract;
using Business.Contants;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length >= 2 && user.LastName.Length >= 2 && user.UserId>0 && user.Password.Length>=2)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            else
            {
                return new ErrorResult(Messages.UserFNameLNameOrPassword);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IDataResult<User> GetById(int UserId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId == UserId));
        }
    }
}
