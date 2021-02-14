using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal iCarDal)
        {
            _carDal = iCarDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarGetAll);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if(DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2)
            {
                if ( car.DailyPrice < 0)
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                    return new ErrorResult(Messages.CarCostGreaterThanZero);
                }

                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
          
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
                return new ErrorResult(Messages.CarNameCharacterLimit);
            }

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ColorUpdated);
        }

    }
}
