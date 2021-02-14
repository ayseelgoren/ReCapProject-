using Business.Abstract;
using Business.Constants;
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

        //Arabanın kiralanmasından önce arabanın daha önce var olan kiralanmasının sona erip ermediği kontrol edilir.
        public IResult Add(Rental rental)
        {
            var control = CheckRental(rental.Id);
            if (control.Success == true)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalAddedError);
        }

        //Arabanın silinmesinden önce arabanın daha önce var olan kiralanmasının sona erip ermediği kontrol edilir.
        public IResult Delete(Rental rental)
        {
            var control = CheckRental(rental.Id);
            if (control.Success == true)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            return new ErrorResult(Messages.RentalDeletedError);
        }

        //Arabanın güncellenmesinden önce arabanın daha önce var olan kiralanmasının sona erip ermediği kontrol edilir.
        public IResult Update(Rental rental)
        {
            var control = CheckRental(rental.Id);
            if (control.Success == true)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            return new ErrorResult(Messages.RentalUpdatedError);
        }

        // Arabanın teslim edilip edilmediği kontrol ediliyor
        public IResult CheckRental(int id)
        {
            var result = _rentalDal.GetAll(r => r.Id == id && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetAll);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetail(), Messages.UserRentals);
        }
    }
}
