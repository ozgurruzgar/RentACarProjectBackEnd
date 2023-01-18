using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByUserId(int UserId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();
        IResult Add(Customer customer);
    }
}
