using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int RentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
        IResult Add(Rental rental);
    }
}
