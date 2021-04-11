using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IServiceRepository<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
    }
}
