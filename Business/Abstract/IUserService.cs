using Core.Entities.Concrete;
using Core.Utitlities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int UserId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByUserMail(string email);
        IResult Add(User user);
    }
}
