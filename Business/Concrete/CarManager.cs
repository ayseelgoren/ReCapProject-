using Business.Abstract;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        
        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2)
            {
                if ( car.DailyPrice < 0)
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                    return new ErrorResult("Ürün eklenmedi. Araba günlük fiyatı 0'dan büyük olmalıdır.");
                }

                _carDal.Add(car);
                return new SuccessResult("Ürün eklendi.");
          
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
                return new ErrorResult("Ürün eklenmedi. Araba ismi minimum 2 karakter olmalıdır.");
            }

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Ürün silindi.");
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }


        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Ürün güncellendi.");
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
