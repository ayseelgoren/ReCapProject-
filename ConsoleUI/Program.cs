using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            // GetAll
            Console.WriteLine("GetAll");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine();


            // GetById
            Console.WriteLine("GetById");
            Car car = new Car() { Id=2, BrandId=3, ColorId=3, DailyPrice=12000, Description= "Volkswagen Polo", ModelYear=2015 };
            Car carToFound = null;
            foreach (var c in carManager.GetById(car.Id))
            {
                carToFound = c;
            }
            Console.WriteLine("Id'si 2 olan araba : " + carToFound.Description);
            Console.WriteLine();


            // Update
            Console.WriteLine("Update");
            Console.WriteLine("Önce - "+carToFound.Description);
            carManager.Update(car);
            Console.WriteLine("Sonra - "+car.Description);
            Console.WriteLine();


            // Add
            Console.WriteLine("Add");
            Car car2 = new Car() { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 12000, Description = "Renault Megane", ModelYear = 2015 };
            carManager.Add(car2);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine();


            // Delete
            Console.WriteLine("Delete");
            carManager.Delete(car);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }
            Console.WriteLine();
        }
    }
}
