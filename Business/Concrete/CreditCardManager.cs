using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        public IResult Buy(BuyDetailDto buyDto)
        {
            var result = _creditCardDal.Buy(buyDto);
            if (result.Success)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(result.Message);
            }
        }
        public IResult Refund(BuyDetailDto buyDto)
        {

            _creditCardDal.Refund(buyDto);
            return new SuccessResult();
        }
    }
}
