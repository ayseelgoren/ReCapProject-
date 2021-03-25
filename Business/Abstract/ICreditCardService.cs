using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {

        IDataResult<List<CreditCard>> GetAll();
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);

        IResult Buy(BuyDetailDto buyDto);
        IResult Refund(BuyDetailDto buyDto);
    }
}
