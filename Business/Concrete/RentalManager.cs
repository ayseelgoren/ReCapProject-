using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        //[SecuredOperation("Rental.Add,Admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            if (_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == rental.ReturnDate).Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            _rentalDal.Add(rental);
             return new SuccessResult(Messages.RentalAdded);
        }


        [SecuredOperation("Rental.Delete,Admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }


        [SecuredOperation("Rental.Update,Admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
             _rentalDal.Update(rental);
             return new SuccessResult(Messages.RentalUpdated);
        }


        [CacheAspect] //key,value
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetAll);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetail(), Messages.UserRentals);
        }

        [CacheAspect] //key,value
        public IDataResult<Rental> LastRentalCar()
        {
            return new SuccessDataResult<Rental>(_rentalDal.LastRentalCar());
        }
    }
}
