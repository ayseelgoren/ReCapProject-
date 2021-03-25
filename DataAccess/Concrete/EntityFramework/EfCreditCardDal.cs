using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, RentACarContext>, ICreditCardDal
    {
        public IResult Buy(BuyDetailDto buyDto)
        {
            using (RentACarContext contex = new RentACarContext())
            {

                var creditCard = contex.Set<CreditCard>().SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber
                && c.SecurityNumber == buyDto.SecurityNumber
                && c.MounthOfExpirationDate == buyDto.MounthOfExpirationDate
                && c.YearOfExpirationDate == buyDto.YearOfExpirationDate);
                if (creditCard != null)
                {
                    if (creditCard.Balance >= buyDto.Amount)
                    {
                        creditCard.Balance -= buyDto.Amount;
                        var updateCreditCard = contex.Entry(creditCard);
                        updateCreditCard.State = EntityState.Modified;
                        contex.SaveChanges();
                        return new SuccessResult("Ödemeniz gerçekleştirilmiştir.");
                    }
                    return new ErrorResult("Yetersiz Bakiye.");

                }
                else
                {
                    return new ErrorResult("Kart Bilgileri Hatalı.");
                }



            }
        }

        public bool Refund(BuyDetailDto buyDto)
        {
            using (RentACarContext contex = new RentACarContext())
            {
                var creditCard = contex.Set<CreditCard>().SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber);
                creditCard.Balance += buyDto.Amount;
                var updateCreditCard = contex.Entry(creditCard);
                updateCreditCard.State = EntityState.Modified;
                contex.SaveChanges();
                return true;
            }
        }
    }
}
