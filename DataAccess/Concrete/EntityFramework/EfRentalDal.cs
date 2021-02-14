using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetail()
        {
                using (RentACarContext context = new RentACarContext())
                {
                    var result = from rental in context.Rentals
                                 join car in context.Cars
                                 on rental.CarId equals car.Id
                                 join customer in context.Customers
                                 on rental.CustomerId equals customer.Id
                                 join user in context.Users
                                 on customer.UserId equals user.Id
                                 select new RentalDetailDto
                                 {
                                     FirstName = user.FirstName,
                                     LastName = user.LastName,
                                     CarName = car.Description,
                                     CarId = car.Id,
                                     DailyPrice = car.DailyPrice,
                                     ReturnDate = rental.ReturnDate,
                                     RentDate = rental.RentDate
                                 };
                    return result.ToList();
                }
            
        }
    }
}
