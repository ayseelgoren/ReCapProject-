﻿using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=152000, ModelYear=2021, Description="Dacia Duster "},
                new Car{Id=2, BrandId=4, ColorId=2, DailyPrice=160000, ModelYear=2010, Description="Ford Focus "},
                new Car{Id=3, BrandId=3, ColorId=3, DailyPrice=180000, ModelYear=2015, Description="Nissan Juke "},
                new Car{Id=4, BrandId=4, ColorId=4, DailyPrice=163000, ModelYear=2021, Description="Opel Astra "},
                new Car{Id=5, BrandId=3, ColorId=1, DailyPrice=1670000, ModelYear=2000, Description="Renault Clio "},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
