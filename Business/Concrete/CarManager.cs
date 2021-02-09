using Business.Abstract;
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

        
        public void Add(Car car)
        {
            if (car.Description.Length >= 2)
            {
                if ( car.DailyPrice > 0)
                {
                    _carDal.Add(car);

                } else
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                }
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }


        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
