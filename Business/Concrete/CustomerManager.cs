using Business.Abstract;
using Business.Contants;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if(customer.CompanyName == null) 
            {
                return new ErrorResult(Messages.CustomerNameOrUserId);
            }
            else
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetByUserId(int UserId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.UserId == UserId));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail());
        }
    }
}
